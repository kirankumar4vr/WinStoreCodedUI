using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Configuration;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Management;
using System.Drawing;
using System.Threading;
using Windows.Management.Deployment;
using System.Security.Principal;
using System.Windows.Forms;
using Point = Microsoft.VisualStudio.TestTools.UITest.Input.Point;

namespace Pearson.PSCWinAutomation.Framework
{
    /// <summary>
    /// Summary description for AutomationAgent
    /// </summary>

    public static class AutomationAgent
    {
        public static string startupPath = System.IO.Directory.GetCurrentDirectory();
        public static string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        public static string xmlfilepath = Path.Combine(outPutDirectory, "Controls.xml");
        public static string xmlfile_path = new Uri(xmlfilepath).LocalPath;
        public static XElement rootXElement = XElement.Load(xmlfile_path);
        public static XElement controlXElement;
        public static XamlControl xamlControl;
        public static HtmlControl htmlControl;
        public static DirectUIControl directUIControl;
        public static XamlWindow xamlAppWindow;
        public static string windowName;
        public static List<int> networkDeviceIds = new List<int>();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();
        private static Control PopulateControl(string viewName, string controlName, string dynamicVariable)
        {
            Control control = new Control();
            AutomationAgent.controlXElement = rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == viewName).Elements("Control").Where(cntrl => cntrl.Attribute("ControlName").Value == controlName).FirstOrDefault<XElement>();
            if (dynamicVariable == "")
            {
                control = new Control(controlXElement, viewName);
            }
            else if (dynamicVariable != "")
            {
                control = new Control(controlXElement, viewName, dynamicVariable);
            }
            return control;
        }

        /// <summary>
        /// Installs the App
        /// </summary>
        /// <returns>bool Installation status</returns>
        public static bool InstallAppBundle(string appBundleUri)
        {
            bool returnValue = true;
            try
            {
                Uri packageUri = new Uri(appBundleUri);
                Windows.Management.Deployment.PackageManager packageManager = new Windows.Management.Deployment.PackageManager();
                Windows.Foundation.IAsyncOperationWithProgress<DeploymentResult, DeploymentProgress> deploymentOperation = packageManager.AddPackageAsync(packageUri, null, Windows.Management.Deployment.DeploymentOptions.None);
                ManualResetEvent opCompletedEvent = new ManualResetEvent(false); // this event will be signaled when the deployment operation has completed.
                deploymentOperation.Completed = (depProgress, status) => { opCompletedEvent.Set(); };
                Logger.InsertLogLine(string.Format("Installing package {0}", appBundleUri));
                Logger.InsertLogLine("Waiting for installation to complete...");
                opCompletedEvent.WaitOne();
                if (deploymentOperation.Status == Windows.Foundation.AsyncStatus.Error)
                {
                    Windows.Management.Deployment.DeploymentResult deploymentResult = deploymentOperation.GetResults();
                    Logger.InsertLogLine(string.Format("Installation Error: {0}", deploymentOperation.ErrorCode));
                    Logger.InsertLogLine(string.Format("Detailed Error Text: {0}", deploymentResult.ErrorText));
                    returnValue = false;
                }
                else if (deploymentOperation.Status == Windows.Foundation.AsyncStatus.Canceled)
                {
                    Logger.InsertLogLine("Installation Canceled");
                    returnValue = false;
                }
                else if (deploymentOperation.Status == Windows.Foundation.AsyncStatus.Completed)
                {
                    Logger.InsertLogLine("Installation succeeded!");
                }
                else
                {
                    returnValue = false;
                    Logger.InsertLogLine("Installation status unknown");
                }
            }
            catch (Exception ex)
            {
                Logger.InsertLogLine(string.Format("AddPackageSample failed, error message: {0}", ex.Message));
                Logger.InsertLogLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                return false;
            }
            return returnValue;
        }

        /// <summary>
        /// Launch App mentioned in App.config
        /// </summary>
        /// <returns>AppWindow</returns>
        public static XamlWindow LaunchApp()
        {
            Logger.InsertLogLine("Launching the App");
            xamlAppWindow = new XamlWindow();
            xamlAppWindow.SearchProperties.Add(XamlWindow.PropertyNames.AutomationId, ConfigurationManager.AppSettings["AppName"].ToString(), XamlWindow.PropertyNames.Name, ConfigurationManager.AppSettings["WindowName"].ToString());
            if (!xamlAppWindow.Exists)
            {
            xamlAppWindow = XamlWindow.Launch(ConfigurationManager.AppSettings["AppName"].ToString());
                xamlAppWindow.CloseOnPlaybackCleanup = true;
            }
            xamlAppWindow.CloseOnPlaybackCleanup = true;
            return xamlAppWindow;
        }

        /// <summary>
        /// Verifies whether child of desktop exists
        /// </summary>
        /// <param name="name">name of child element to search</param>
        /// <returns>true:if child available;false:not part of desktop child</returns>
        public static bool VerifyDesktopChildByName(string name)
        {
            Logger.InsertLogLine("Verifying desktop child by Name");
            UITestControlCollection children = XamlWindow.Desktop.GetChildren();

            for (int i = 0; i < children.Count; i++)
            {
                string childName = children[i].Name;
                if (name == children[i].Name)
                {
                    return true;
                }
            }

            return false;

        }
        /// <summary>
        /// Closing the APP
        /// </summary>
        public static void CloseApp()
        {
            Logger.InsertLogLine("Closing the App");
            xamlAppWindow.Close();
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ConfigurationManager.AppSettings["AppProcessName"].ToString());
            if (procs != null)
            {
                foreach (System.Diagnostics.Process proc in procs)
                {
                    proc.Close();
                    proc.Kill();
                    proc.Dispose();
                }
            }
            Wait(3000);
        }

        /// <summary>
        /// Get HTML control object
        /// </summary>
        /// <param name="control">COntrol name from controls.xml</param>
        /// <param name="dynamicVariable">dynamic var</param>
        /// <param name="waitTime"></param>
        /// <returns>HtmlControl</returns>
        public static HtmlControl GetHtmlControl(Control control, string dynamicVariable, int waitTime)
        {
            if (control.ControlType == "HtmlDocument")
            {
                Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument htmlDocument = new Microsoft.VisualStudio.TestTools.UITesting.HtmlControls.HtmlDocument(GetXamlWebViewControl(PopulateControl(control.ViewName, control.ParentControl, dynamicVariable), dynamicVariable, waitTime));
                foreach (string key in control.SearchProperties.Keys)
                {
                    htmlDocument.SearchProperties.Add(key, control.SearchProperties[key]);
                }
                htmlDocument.WindowTitles.Add(windowName);
                return htmlDocument;
            }
            else
            {
                HtmlControl htmlControl = new HtmlControl(GetHtmlControl(PopulateControl(control.ViewName, control.ParentControl, dynamicVariable), dynamicVariable, waitTime));
                foreach (string key in control.SearchProperties.Keys)
                {
                    htmlControl.SearchProperties.Add(key, control.SearchProperties[key]);
                }
                htmlControl.WindowTitles.Add(windowName);
                return htmlControl;
            }
        }

        public static XamlWebView GetXamlWebViewControl(Control control, string dynamicVariable, int waitTime)
        {
            XamlWebView xamlWebView = new XamlWebView(GetXamlControl(PopulateControl(control.ViewName, control.ParentControl, dynamicVariable), dynamicVariable, waitTime));
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlWebView.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlWebView.WindowTitles.Add(windowName);
            return xamlWebView;
        }

        /// <summary>
        /// Get XAML control object
        /// </summary>
        /// <param name="control">COntrol name from controls.xml</param>
        /// <param name="dynamicVariable">dynamic var</param>
        /// <param name="waitTime"></param>
        /// <returns>XamlControl</returns>
        public static XamlControl GetXamlControl(Control control, string dynamicVariable, int waitTime)
        {
            if (control.ParentControl == "AppWindow")
            {
                XamlControl xamlControl = new XamlControl(xamlAppWindow);
                foreach (string key in control.SearchProperties.Keys)
                {
                    xamlControl.SearchProperties.Add(key, control.SearchProperties[key]);
                }
                xamlControl.WindowTitles.Add(windowName);
                return xamlControl;
            }
            else
            {
                XamlControl xamlControl = new XamlControl(GetXamlControl(PopulateControl(control.ViewName, control.ParentControl, dynamicVariable), dynamicVariable, waitTime));
                foreach (string key in control.SearchProperties.Keys)
                {
                    xamlControl.SearchProperties.Add(key, control.SearchProperties[key]);
                }
                xamlControl.WindowTitles.Add(windowName);
                return xamlControl;
            }
        }

        public static DirectUIControl GetDirectUIControl(Control control, string dynamicVariable, int waitTime)
        {
            if (control.ParentControl == "AppWindow")
            {
                DirectUIControl directUIControl = new DirectUIControl(xamlAppWindow);
                foreach (string key in control.SearchProperties.Keys)
                {
                    directUIControl.SearchProperties.Add(key, control.SearchProperties[key]);
                }
                directUIControl.WindowTitles.Add(windowName);
                return directUIControl;
            }
            else
            {
                DirectUIControl directUIControl = new DirectUIControl(GetDirectUIControl(PopulateControl(control.ViewName, control.ParentControl, dynamicVariable), dynamicVariable, waitTime));
                foreach (string key in control.SearchProperties.Keys)
                {
                    directUIControl.SearchProperties.Add(key, control.SearchProperties[key]);
                }
                directUIControl.WindowTitles.Add(windowName);
                return directUIControl;
            }
        }

        /// <summary>
        /// Set text to xml text box
        /// </summary>
        /// <param name="viewName">from control.xml</param>
        /// <param name="controlName">from control.xml</param>
        /// <param name="textToSet">string text to set</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>

        public static void SetText(string viewName, string controlName, string textToSet, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Setting text: " + textToSet + " to control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            XamlEdit xamlTextbox = new XamlEdit(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlTextbox.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlTextbox.WindowTitles.Add(windowName);
            xamlTextbox.WaitForControlExist(waitTime);
            xamlTextbox.Text = textToSet;
        }

        public static void SendText(string text)
        {
            SendKeys.SendWait(text);
        }
        /// <summary>
        /// Clicks available control
        /// </summary>
        /// <param name="viewName">from control.xml</param>
        /// <param name="controlName">from control.xml</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        public static void Click(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            Logger.InsertLogLine("Click on control: " + control.ControlName + " in View : " + viewName);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                Gesture.Tap(new Point(xamlControl.BoundingRectangle.X + xamlControl.BoundingRectangle.Width / 2, xamlControl.BoundingRectangle.Y + xamlControl.BoundingRectangle.Height / 2));
            }
            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                htmlControl.WaitForControlExist(waitTime);
                Gesture.Tap(new Point(htmlControl.BoundingRectangle.X + htmlControl.BoundingRectangle.Width / 2, htmlControl.BoundingRectangle.Y + htmlControl.BoundingRectangle.Height / 2));
                //Gesture.Tap(htmlControl);
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                Gesture.Tap(directUIControl);
            }
        }

        /// <summary>
        /// Double clicking on available control on screen
        /// </summary>
        /// <param name="viewName">from control.xml</param>
        /// <param name="controlName">from control.xml</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        public static void DoubleClick(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Double Click on control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
            Gesture.DoubleTap(xamlControl);
        }

        /// <summary>
        /// Clicks specific screen coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public static void Click(int x1, int y1)
        {
            Logger.InsertLogLine("Click on coordinates X1: " + x1.ToString() + "Y1: " + y1.ToString());
            Point point1 = new Point(x1, y1);
            Gesture.Tap(point1);
        }
        /// <summary>
        /// Double Clicks specific screen coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public static void DoubleClick(int x1, int y1)
        {
            Logger.InsertLogLine("Double Click on coordinates X1: " + x1.ToString() + "Y1: " + y1.ToString());
            Point point1 = new Point(x1, y1);
            Gesture.DoubleTap(point1);
        }
        /// <summary>
        /// Slides the screen
        /// </summary>
        /// <param name="x1">x pos1</param>
        /// <param name="y1">y pos 1</param>
        /// <param name="x2">x pos2 to slide</param>
        /// <param name="y2">y pos2 to slide</param>
        public static void Slide(int x1, int y1, int x2, int y2)
        {
            Logger.InsertLogLine("Slide on coordinates X1: " + x1.ToString() + "Y1: " + y1.ToString() + " to coordinates X2:" + x2.ToString() + "Y2:" + y2.ToString());
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Gesture.Slide(point1, point2);
        }
        /// <summary>
        /// Stretch the screen at specific coordinates
        /// </summary>
        /// <param name="x1">x pos1</param>
        /// <param name="y1">y pos 1</param>
        /// <param name="x2">x pos2 to slide</param>
        /// <param name="y2">y pos2 to slide</param>
        /// <param name="distance">distance to stretch</param>
        public static void Stretch(int x1, int y1, int x2, int y2, uint distance)
        {
            Logger.InsertLogLine("Stretch on coordinates X1: " + x1.ToString() + "Y1: " + y1.ToString() + " to coordinates X2:" + x2.ToString() + "Y2:" + y2.ToString() + "Unit distance:" + distance.ToString());
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Gesture.Stretch(point1, point2, distance);
        }
        /// <summary>
        /// Stretch a control available
        /// </summary>
        /// <param name="viewName">from controls.xml</param>
        /// <param name="controlName">from controls.xml</param>
        /// <param name="relativeX1">initial pos x</param>
        /// <param name="relativeY1">initial pos y</param>
        /// <param name="relativeX2">relative pos x</param>
        /// <param name="relativeY2">relative pos x</param>
        /// <param name="distance">distance to stretch</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        public static void StrechControl(string viewName, string controlName, int relativeX1, int relativeY1, int relativeX2, int relativeY2, uint distance, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Double Click on control: " + controlName + " in View : " + viewName + "Relative pos X1: " + relativeX1.ToString() + "Y1: " + relativeY1.ToString() + " to relative pos X2:" + relativeX2.ToString() + "relativeY2:" + relativeY2.ToString() + "Unit distance:" + distance.ToString());
            Point point1 = new Point(relativeX1, relativeY1);
            Point point2 = new Point(relativeX2, relativeY2);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
            Gesture.Stretch(xamlControl, point1, point2, distance);
        }
        /// <summary>
        /// Verifies whether control available on screen
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>true:control found;false:not available</returns>
        public static bool VerifyControlExists(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify Control exists - Control: " + controlName + " in View : " + viewName);
            bool ControlExists = false;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlExists = xamlControl.Exists;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlExists = htmlControl.Exists;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                ControlExists = directUIControl.Exists;
            }
            return ControlExists;
        }
        /// <summary>
        /// Verify whether control is enabled or not
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>true:control enabled;false:control disabled</returns>
        public static bool VerifyControlEnabled(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify Control Enabled - Control: " + controlName + " in View : " + viewName);
            bool ControlEnabled = false;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlEnabled = xamlControl.Enabled;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlEnabled = htmlControl.Enabled;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                ControlEnabled = directUIControl.Enabled;
            }
            return ControlEnabled;


        }
        /// <summary>
        /// Long click on an control
        /// </summary>
        /// <param name="viewName">from controls.xml</param>
        /// <param name="controlName">from controls.xml</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        public static void LongClickControl(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Long click on Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
            Gesture.PressAndHold(xamlControl);
        }

        /// <summary>
        /// Swipe available control
        /// </summary>
        /// <param name="viewName">from controls.xml</param>
        /// <param name="controlName">from controls.xml</param>
        /// <param name="direction">direction to slide</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        public static void Swipe(string viewName, string controlName, UITestGestureDirection direction, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "", uint SwipeLength=50)
        {
            Logger.InsertLogLine("Swipe Control exists - Control: " + controlName + " in View : " + viewName + "Direction:" + direction.ToString());
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
            Gesture.Swipe(xamlControl, direction, SwipeLength);
        }
        /// <summary>
        /// Waits for control to appear on screen
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        public static void WaitForControlExists(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Wait for control exist - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
            xamlControl.WaitForControlExist(waitTime);
        }

        /// <summary>
        /// Gets text of available control on screen
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>string:control text</returns>
        public static string GetControlText(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control text - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                return xamlControl.GetProperty(XamlControl.PropertyNames.Name).ToString();
            }
            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                return htmlControl.GetProperty(HtmlControl.PropertyNames.InnerText).ToString();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                return directUIControl.GetProperty(DirectUIControl.PropertyNames.Name).ToString();
            }
            else
            {
                return "controlzone is not identified";
            }
        }


        /// <summary>
        /// Get text written in xaml text box
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static string GetText(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get text- Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            XamlEdit xamlTextbox = new XamlEdit(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlTextbox.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlTextbox.WindowTitles.Add(windowName);
            xamlTextbox.WaitForControlExist(waitTime);
            return xamlTextbox.Text;

        }

        /// <summary>
        /// Verifies whether app is in focus
        /// </summary>
        /// <returns>true:in focus;false:not focus</returns>
        public static bool VerifyAppIsInFocus()
        {
            Logger.InsertLogLine("Verifying the App in focus or not");
            return xamlAppWindow.HasFocus;
        }

        /// <summary>
        /// Wait time
        /// </summary>
        /// <param name="waitTime"></param>

        public static void Wait(int waitTime = WaitTime.DefaultWaitTime)
        {
            System.Threading.Thread.Sleep(waitTime);
        }
        /// <summary>
        /// Verifies whether toggle button is pressed
        /// </summary>
        /// <param name="viewName">from controls.xml</param>
        /// <param name="controlName">from controls.xml</param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>true:toggle button pressed;false:not pressed</returns>
        public static bool VerifyXamlToggleButtonPressed(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify xaml toggle button pressed - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);

            XamlToggleButton xamlToggleButton = new XamlToggleButton(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlToggleButton.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlToggleButton.WindowTitles.Add(windowName);
            xamlToggleButton.WaitForControlExist(waitTime);
            return xamlToggleButton.Pressed;
        }

        /// <summary>
        /// Get clickable points of control
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static string GetControlClickablePoint(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control clickable point - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
            string dtr = xamlControl.GetClickablePoint().ToString();
            return xamlControl.GetClickablePoint().ToString();
        }
        /// <summary>
        /// Disable all the network of device
        /// </summary>
        public static void DisableNetwork()
        {
            Logger.InsertLogLine("Disable Network");
            string strWQuery = "SELECT DeviceID, ProductName, "
                + "NetEnabled, NetConnectionStatus "
                + "FROM Win32_NetworkAdapter "
                + "WHERE Manufacturer <> 'Microsoft'";

            string product;
            int connectionStatus;
            bool netEnabled;

            ObjectQuery oQuery = new ObjectQuery(strWQuery);
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
            ManagementObjectCollection networkAdapters = oSearcher.Get();
            foreach (ManagementObject moNetworkAdapter in networkAdapters)
            {
                try
                {
                    product = moNetworkAdapter["ProductName"].ToString();
                    netEnabled = Convert.ToBoolean(moNetworkAdapter["NetEnabled"].ToString());
                    connectionStatus = Convert.ToInt32(moNetworkAdapter["NetConnectionStatus"].ToString());
                    networkDeviceIds.Add(Convert.ToInt32(moNetworkAdapter["DeviceId"].ToString()));
                }
                catch (NullReferenceException)
                {
                    // Ignore some other devices (like the bluetooth), that need user 
                    // interaction to enable or disable.
                }
            }
            foreach (int deviceId in networkDeviceIds)
            {
                strWQuery = string.Format("SELECT DeviceID, ProductName, "
                    + "NetEnabled, NetConnectionStatus "
                    + "FROM Win32_NetworkAdapter " + "WHERE DeviceID = {0}", deviceId);
                try
                {
                    oQuery = new ObjectQuery(strWQuery);
                    oSearcher = new ManagementObjectSearcher(oQuery);
                    networkAdapters = oSearcher.Get();

                    foreach (ManagementObject networkAdapter in networkAdapters)
                    {
                        networkAdapter.InvokeMethod("Disable", null);
                    }
                }
                catch (NullReferenceException)
                {
                    // If there is a NullReferenceException, the result of the enable or 
                    // disable network adapter operation will be fail
                }
            }
            System.Threading.Thread.Sleep(5000);
            networkAdapters.Dispose();
            Logger.InsertLogLine("Network disabled");
        }

        /// <summary>
        /// Enables all network
        /// </summary>
        public static void EnableNetwork()
        {
            Logger.InsertLogLine("Enable network");
            foreach (int deviceId in networkDeviceIds)
            {
                string strWQuery = string.Format("SELECT DeviceID, ProductName, "
                    + "NetEnabled, NetConnectionStatus "
                    + "FROM Win32_NetworkAdapter " + "WHERE DeviceID = {0}", deviceId);
                try
                {
                    ObjectQuery oQuery = new ObjectQuery(strWQuery);
                    ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oQuery);
                    ManagementObjectCollection networkAdapters = oSearcher.Get();

                    foreach (ManagementObject networkAdapter in networkAdapters)
                    {
                        networkAdapter.InvokeMethod("Enable", null);
                    }
                }
                catch (NullReferenceException)
                {
                    // If there is a NullReferenceException, the result of the enable or 
                    // disable network adapter operation will be fail
                }
            }
            System.Threading.Thread.Sleep(5000);
            Logger.InsertLogLine("Network Enabled");
        }


        /// <summary>
        /// Get width of particular control
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>int control width</returns>
        public static int GetControlWidth(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control Width - Control: " + controlName + " in View : " + viewName);
            int ControlWidth = 0;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlWidth = xamlControl.Width;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlWidth = htmlControl.Width;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                ControlWidth = directUIControl.Width;
            }
            return ControlWidth;
        }
        /// <summary>
        /// Gets control height on screen
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>int height</returns>
        public static int GetControlHeight(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control height - Control: " + controlName + " in View : " + viewName);
            int ControlWidth = 0;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlWidth = xamlControl.Height;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlWidth = htmlControl.Height;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                ControlWidth = directUIControl.Height;
            }
            return ControlWidth;
        }
        /// <summary>
        /// Gets controls x coordinate on screen
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static int GetControlPositionX(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control Position X - Control: " + controlName + " in View : " + viewName);
            int ControlPos = 0;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlPos = xamlControl.BoundingRectangle.X;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlPos = htmlControl.BoundingRectangle.X;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                ControlPos = directUIControl.BoundingRectangle.X;
            }
            return ControlPos;
        }

        /// <summary>
        /// Gets Y coordinated of control
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static int GetControlPositionY(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control position Y - Control: " + controlName + " in View : " + viewName);
            int ControlPos = 0;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlPos = xamlControl.BoundingRectangle.Y;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlPos = htmlControl.BoundingRectangle.Y;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                ControlPos = directUIControl.BoundingRectangle.Y;
            }
            return ControlPos;
        }


        public static int GetAppWindowWidth()
        {
            Logger.InsertLogLine("Get App window width");
            return xamlAppWindow.Width;
        }

        public static int GetAppWindowHeight()
        {
            Logger.InsertLogLine("Get App window height");
            return xamlAppWindow.Height;
        }

        public static void PressHold(int x1, int y1)
        {
            Logger.InsertLogLine("PressHold on coordinates X1: " + x1.ToString() + "Y1: " + y1.ToString());
            Point point1 = new Point(x1, y1);
            Gesture.PressAndHold(point1);
        }
        /// <summary>
        /// Gets children count of parent control
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static int GetChildrenControlCount(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Childreh control count- Control: " + controlName + " in View : " + viewName);
            int ChildrenCount = 0;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ChildrenCount = xamlControl.GetChildren().Count;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ChildrenCount = htmlControl.GetChildren().Count;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                ChildrenCount = directUIControl.GetChildren().Count;
            }
            return ChildrenCount;
        }

        public static bool VerifyChildByName(string viewName, string controlName, string childName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            bool exists = false;
            UITestControlCollection children = null;
            UITestControl child = null;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }
            for (int i = 0; i < children.Count; i++)
            {
                child = children[i];
                string name = child.GetProperty("Name").ToString();
                if (name.Contains(childName))
                {
                    exists = true;
                }
            }
            return exists;
        }

        /// <summary>
        /// Gets controls class applied on it
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static string GetControlClassName(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control class Name - Control: " + controlName + " in View : " + viewName);
            string ClassName = null;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ClassName = xamlControl.ClassName;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ClassName = htmlControl.ClassName;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                ClassName = directUIControl.ClassName;
            }
            return ClassName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static bool VerifyControlHighlighted(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify Control highlighted - Control: " + controlName + " in View : " + viewName);
            bool ControlHasFocus = false;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                ControlHasFocus = xamlControl.HasFocus;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                ControlHasFocus = htmlControl.HasFocus;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                ControlHasFocus = directUIControl.HasFocus;
            }
            return ControlHasFocus;
        }

        /// <summary>
        /// Drags dragging control and Drops in dropping control
        /// </summary>
        /// <param name="draggingControlViewName">view name of the dragging control</param>
        /// <param name="draggingControlName">dragging control name</param>
        /// <param name="droppingControlViewName">view name of the dropping control</param>
        /// <param name="droppingControlName">dropping control name</param>
        /// <param name="waitTime">wait time</param>
        /// <param name="draggingControlDynamicVariable">dynamic variable for the dragging control</param>
        /// <param name="droppingControlDynamicVariable">dynamic variable for the dropping control</param>
        public static void DragAndDrop(string draggingControlViewName, string draggingControlName, string droppingControlViewName, string droppingControlName, int waitTime = WaitTime.DefaultWaitTime, string draggingControlDynamicVariable = "", string droppingControlDynamicVariable = "")
        {
            Control draggingControl = PopulateControl(draggingControlViewName, draggingControlName, draggingControlDynamicVariable);
            Control droppingControl = PopulateControl(droppingControlViewName, droppingControlName, droppingControlDynamicVariable);
            XamlControl xamlDraggingControl = GetXamlControl(draggingControl, draggingControlDynamicVariable, waitTime);
            XamlControl xamlDroppingControl = GetXamlControl(droppingControl, droppingControlDynamicVariable, waitTime);
            Mouse.StartDragging(xamlDraggingControl);
            Mouse.StopDragging(xamlDroppingControl);
        }

        /// <summary>
        /// Stops dragging at the point
        /// </summary>
        /// <param name="pointX">X Co-ordinate of the point</param>
        /// <param name="pointY">Y Co-ordinate of the point</param>
        public static void StopDragging(int pointX, int pointY)
        {
            Mouse.StopDragging(new Point(pointX, pointY));
        }
        /// <summary>
        /// Verifies whether control is visible
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>true:control visible on screen;false:not visible</returns>
        public static bool VerifyControlVisible(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify Control visible - Control: " + controlName + " in View : " + viewName);
            bool ControlVisible = false;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            XamlButton xamlButton = new XamlButton(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlButton.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlButton.WindowTitles.Add(windowName);
            xamlButton.WaitForControlExist(waitTime);

            Point point = new Point();
            ControlVisible = xamlButton.TryGetClickablePoint(out point);


            return ControlVisible;
        }

        /// <summary>
        /// Verifies xaml list item selected or not
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static bool VerifyXamlListItemSelected(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify XAML List Item Selected - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);

            XamlListItem xamlListItem = new XamlListItem(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlListItem.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlListItem.WindowTitles.Add(windowName);
            xamlListItem.WaitForControlExist(waitTime);
            return xamlListItem.Selected;
        }

        /// <summary>
        /// Verifies xaml radio button selected or not
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static bool VerifyXamlRadioButtonSelected(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify XAML radio button Selected - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);

            XamlRadioButton xamlRadioBtn = new XamlRadioButton(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlRadioBtn.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlRadioBtn.WindowTitles.Add(windowName);
            xamlRadioBtn.WaitForControlExist(waitTime);
            return xamlRadioBtn.Selected;
        }
        /// <summary>
        /// Verifies Xaml check box checked
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>true:checked;false not checked</returns>
        public static bool VerifyCheckBoxChecked(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Verify Check Box Checked - Control: " + controlName + " in View : " + viewName);
            Control control = PopulateControl(viewName, controlName, dynamicVariable);

            XamlCheckBox xamlToggleButton = new XamlCheckBox(xamlAppWindow);
            foreach (string key in control.SearchProperties.Keys)
            {
                xamlToggleButton.SearchProperties.Add(key, control.SearchProperties[key]);
            }
            xamlToggleButton.WindowTitles.Add(windowName);
            xamlToggleButton.WaitForControlExist(waitTime);
            return xamlToggleButton.Checked;
        }

        public static Bitmap GetControlBitmap(UITestControl control)
        {
            SetProcessDPIAware();
            Microsoft.VisualStudio.TestTools.UITest.Input.Rectangle rectangel = control.BoundingRectangle;
            Bitmap bmp = new Bitmap(rectangel.Width, rectangel.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rectangel.Left, rectangel.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            }
            return bmp;
        }

        public static bool VerifyChildrensChildControlByName(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "", string ChildName = "")
        {
            Logger.InsertLogLine("Get Childreh control count- Control: " + controlName + " in View : " + viewName);
            UITestControlCollection children = new UITestControlCollection();
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }

            for (int i = 0; i < children.Count; i++)
            {
                string chname = children[i].Name;

                UITestControlCollection children1 = new UITestControlCollection();

                children1 = children[i].GetChildren();

                for (int j = 0; j < children.Count; j++)
                {
                    string chchname = children1[j].Name;
                    if (children1[j].Name.Contains(ChildName))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        /// <summary>
        /// Gets children count of parent control
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static string[] GetChildrenControlNames(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Childreh controls Name- Control: " + controlName + " in View : " + viewName);
            UITestControlCollection children = new UITestControlCollection();
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }

            string[] myList = new string[50];
            for (int i = 0; i < children.Count; i++)
            {
                myList[i] = children[i].Name;
            }
            return myList;
        }

        public static void ClickAndVerifyColorOfChildrenByInstance(string viewName, string controlName, Color samplecolor, out bool ColorCompareResult, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "", int ChildInstance = 1)
        {
            ColorCompareResult = false;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            Logger.InsertLogLine("Get Childreh control count- Control: " + controlName + " in View : " + viewName);
            Logger.InsertLogLine("Click on children's child: " + ChildInstance.ToString() + "in control: " + control.ControlName + " in View : " + viewName);
            UITestControlCollection children = new UITestControlCollection();
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }

            for (int j = 0; j < children.Count; j++)
            {
                if (j == ChildInstance - 1)
                {
                    UITestControl uicontrol = children[j];
                    ColorCompareResult = CompareControlImageColor(uicontrol, samplecolor);
                    Gesture.Tap(new Point(children[j].BoundingRectangle.X + children[j].BoundingRectangle.Width / 2, children[j].BoundingRectangle.Y + children[j].BoundingRectangle.Height / 2));
                }
            }
        }
        /// <summary>
        /// Move the mouse to a specific point
        /// </summary>
        /// <param name="pointX">int: x position</param>
        /// <param name="pointY">int: y position</param>
        public static void MouseMoveToAPosition(int pointX, int pointY)
        {
            Point point1 = new Point(pointX, pointY);
            Mouse.Hover(point1);
        }


        /// <summary>
        /// Drags and Holds a control at a specific point
        /// Note: Make sure to call Stop dragging by passing the holdingPointX & holdingPointY as parameters after verifying the holding control otherwise Mouse continuous to hold
        /// </summary>
        /// <param name="draggingControlViewName">view name of the dragging control</param>
        /// <param name="draggingControlName">dragging control name</param>
        /// <param name="holdingPointX">X co ordinate of point at which control should be held</param>
        /// <param name="holdingPointY">Y co ordinate of point at which control should be held</param>
        /// <param name="waitTime">Wait Time</param>
        /// <param name="draggingControlDynamicVariable">dynamic variable for the dragging control</param>
        public static void DragAndHold(string draggingControlViewName, string draggingControlName, int holdingPointX, int holdingPointY, int waitTime = WaitTime.DefaultWaitTime, string draggingControlDynamicVariable = "")
        {
            Control draggingControl = PopulateControl(draggingControlViewName, draggingControlName, draggingControlDynamicVariable);
            XamlControl xamlDraggingControl = GetXamlControl(draggingControl, draggingControlDynamicVariable, waitTime);
            Mouse.StartDragging(xamlDraggingControl);
            Mouse.Move(new Point(holdingPointX, holdingPointY));
        }


        /// <summary>
        /// Gets controls in bitmap for comparison
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns></returns>
        public static Bitmap GetControlBitmap(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control bitmap - Control: " + controlName + " in View : " + viewName);

            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                return GetControlBitmap(xamlControl);
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                return GetControlBitmap(htmlControl);
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                return GetControlBitmap(directUIControl);
            }
            else
            {
                return GetControlBitmap(xamlAppWindow);
            }
        }


        public static void CreateScreenshot()
        {
            Logger.CreateScreenshot(GetControlBitmap(xamlAppWindow));
            }

        /// <summary>
        /// Compares Control Image colors
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="controlColor"></param>
        /// <param name="waitTime"></param>
        /// <param name="dynamicVariable"></param>
        /// <returns>true:if color matches; false:color mismatch</returns>
        public static bool CompareControlImageColor(string viewName, string controlName, Color controlColor, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Compare Control Image color - Control: " + controlName + " in View : " + viewName + "Color" + controlColor.ToString());

            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            UITestControl uiControl;
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                uiControl = xamlControl;
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                uiControl = htmlControl;
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                uiControl = directUIControl;
            }
            else
            {
                uiControl = xamlAppWindow;
            }
            return CompareControlImageColor(uiControl, controlColor);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstImage"></param>
        /// <param name="secondImage"></param>
        /// <returns></returns>
        public static bool CompareImage(Bitmap firstImage, Bitmap secondImage)
        {
            Logger.InsertLogLine("Compare Image First Image: " + firstImage + " SeconImage : " + secondImage);

            MemoryStream ms = new MemoryStream();
            firstImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String firstBitmap = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;

            secondImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String secondBitmap = Convert.ToBase64String(ms.ToArray());

            return firstBitmap.Equals(secondBitmap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool CompareControlImageColor(UITestControl control, Color color)
        {
            Logger.InsertLogLine("Compare Control Image Color - Control");
            Bitmap cntrlImg = GetControlBitmap(control);
            Color cntrlImgClr;
            Random rnd = new Random(0);
            int x, y, count = 0;
            for (int i = 0; i < 5; i++)
            {
                x = rnd.Next(cntrlImg.Width / 4, 3 * cntrlImg.Width / 4);
                y = rnd.Next(cntrlImg.Height / 4, 3 * cntrlImg.Height / 4);
                cntrlImgClr = cntrlImg.GetPixel(x, y);
                if (cntrlImgClr == color)
                    count++;
            }
            //return count > 3;
            return count > 1;
        }

        public static string GetControlFontName(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "")
        {
            Logger.InsertLogLine("Get Control class Name - Control: " + controlName + " in View : " + viewName);
            string FontName = null;
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                FontName = xamlControl.Font;
            }
            return FontName;
        }

        public static bool VerifyChildrenControlByName(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "", string ChildName = "")
        {
            Logger.InsertLogLine("Get Childreh control count- Control: " + controlName + " in View : " + viewName);
            UITestControlCollection children = new UITestControlCollection();
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }

            for (int i = 0; i < children.Count; i++)
            {
                string chname = children[i].Name;
                if (children[i].Name.Contains(ChildName))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ClickChildrensChildByName(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "", string ChildName = "")
        {
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            Logger.InsertLogLine("Get Childreh control count- Control: " + controlName + " in View : " + viewName);
            Logger.InsertLogLine("Click on children's child: " + ChildName + "in control: " + control.ControlName + " in View : " + viewName);
            UITestControlCollection children = new UITestControlCollection();
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
            }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }

            for (int i = 0; i < children.Count; i++)
            {
                string chname = children[i].Name;

                UITestControlCollection children1 = new UITestControlCollection();

                children1 = children[i].GetChildren();
                
                for (int j = 0; j < children.Count; j++)
                {
                    string chchname = children1[j].Name;
                    if (children1[j].Name.Contains(ChildName))
                    {
                        Gesture.Tap(new Point(children1[j].BoundingRectangle.X + children1[j].BoundingRectangle.Width / 2, children1[j].BoundingRectangle.Y + children1[j].BoundingRectangle.Height / 2));
                    }
                }
            }
        }

        public static void ClickChildrensChildByNameAtFirstLevel(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime, string dynamicVariable = "", string ChildName = "")
        {
            Control control = PopulateControl(viewName, controlName, dynamicVariable);
            Logger.InsertLogLine("Get Childreh control count- Control: " + controlName + " in View : " + viewName);
            Logger.InsertLogLine("Click on children's child: " + ChildName + "in control: " + control.ControlName + " in View : " + viewName);
            UITestControlCollection children = new UITestControlCollection();
            if (control.ControlZone == "Native")
            {
                xamlControl = GetXamlControl(control, dynamicVariable, waitTime);
                xamlControl.WaitForControlExist(waitTime);
                children = xamlControl.GetChildren();
        }

            else if (control.ControlZone == "Web")
            {
                htmlControl = GetHtmlControl(control, dynamicVariable, waitTime);
                children = htmlControl.GetChildren();
            }
            else if (control.ControlZone == "DirectUI")
            {
                directUIControl = GetDirectUIControl(control, dynamicVariable, waitTime);
                directUIControl.WaitForControlExist(waitTime);
                children = directUIControl.GetChildren();
            }

            for (int j = 0; j < children.Count; j++)
            {
                string chname = children[j].Name;

                if (children[j].Name.Contains(ChildName))
                {
                    Gesture.Tap(new Point(children[j].BoundingRectangle.X + children[j].BoundingRectangle.Width / 2, children[j].BoundingRectangle.Y + children[j].BoundingRectangle.Height / 2));
                }
            }
        }


        /// <summary>
        /// Verifies direct children of App window by Name
        /// </summary>
        /// <param name="ChildName"></param>
        /// <returns></returns>
        public static bool VerifyAppChildrenByName(string ChildName)
        {
            Logger.InsertLogLine("Verify Children control of App by Name " + ChildName);
            UITestControlCollection children = new UITestControlCollection();
            children = xamlAppWindow.GetChildren();
            for (int i = 0; i < children.Count; i++)
            {
                string chname = children[i].Name;
                if (children[i].Name.Contains(ChildName))
                {
                    return true;
            }
        }
            return false;
        }

        /// <summary>
        /// Verifies direct children of App window by Name
        /// </summary>
        /// <param name="ChildName"></param>
        /// <returns></returns>
        public static void ClickAppChildrenByName(string ChildName)
        {
            Logger.InsertLogLine("Click Children control of App by Name " + ChildName);
            UITestControlCollection children = new UITestControlCollection();
            children = xamlAppWindow.GetChildren();
            for (int i = 0; i < children.Count; i++)
            {
                string chname = children[i].Name;
                if (children[i].Name.Contains(ChildName))
                {
                    Gesture.Tap(new Point(children[i].BoundingRectangle.X + children[i].BoundingRectangle.Width / 2, children[i].BoundingRectangle.Y + children[i].BoundingRectangle.Height / 2));
                }
            }
        }

        public static void LongClick(int x1, int y1)
        {
            Logger.InsertLogLine("Click on coordinates X1: " + x1.ToString() + "Y1: " + y1.ToString());
            Point point1 = new Point(x1, y1);
            Gesture.PressAndHold(point1);
        }

    }


    public static class WaitTime
    {
        public const int DefaultWaitTime = 2000;
        public static readonly float WaitTimeMultiplier = float.Parse(ConfigurationManager.AppSettings["WaitTimeMultiplier"].ToString());
        public static readonly int SmallWaitTime = (int)(int.Parse(ConfigurationManager.AppSettings["SmallWaitTime"].ToString()) * WaitTimeMultiplier);
        public static readonly int MediumWaitTime = (int)(int.Parse(ConfigurationManager.AppSettings["MediumWaitTime"].ToString()) * WaitTimeMultiplier);
        public static readonly int LargeWaitTime = (int)(int.Parse(ConfigurationManager.AppSettings["LargeWaitTime"].ToString()) * WaitTimeMultiplier);
    }

    public enum Direction
    {
        Right,
        Left,
        Down,
        Up
    };

    
}
