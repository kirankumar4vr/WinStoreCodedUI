using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = Microsoft.VisualStudio.TestTools.UITest.Input.MouseButtons;
using Pearson.PSCWinAutomation.Framework;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for ContentManagerCommonMethods
    /// </summary>
    
    public class ContentManagerCommonMethods
    {
        public ContentManagerCommonMethods()
        {
        }

       
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        /// <summary>
        /// Verifies App Version Label presence
        /// </summary>
        /// <returns></returns>
        public static bool VerifyAppVersionLabelPresent()
        {
            return AutomationAgent.VerifyControlExists("ContentManagerView", "AppVersionLabel");
        }

        /// <summary>
        /// Verifies Config Code Label presence
        /// </summary>
        /// <returns></returns>
        public static bool VerifyConfigCodeLabelPresent()
        {
            return AutomationAgent.VerifyControlExists("ContentManagerView", "ConfigCodeLabel");
        }
        /// <summary>
        /// Verifies Config Code Label presence
        /// </summary>
        /// <returns></returns>
        public static bool VerifyCachingServerStatusLabelPresent()
        {
            return AutomationAgent.VerifyControlExists("ContentManagerView", "ContentMgrCachingServerLabel");
        }

        public static bool VerifyGlobalNavIconsForContentManager()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
              AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton") &&
              AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
              
            {
                return true;
            }

            else
                return false;
        }

        public static string GetAppVersionFromContentManager()
        {
            return AutomationAgent.GetControlText("ContentManagerView", "AppVersionLabel");
        }

        public static string GetCachingServerFromContentManager()
        {
            return AutomationAgent.GetControlText("ContentManagerView", "ContentMgrCachingServerLabel");
        }

        public static string GetConfigInfoFromContentManager()
        {
           return AutomationAgent.GetControlText("ContentManagerView", "ConfigCodeLabel");
        }
        public static bool VerifyCheckUpdateButton()
        {
           return  AutomationAgent.VerifyControlExists("ContentManagerView", "CheckUpdate");
        }
        /// <summary>
        /// Clicks on Check Update control
        /// </summary>
        public static void ClickOnCheckUpdate()
        {
            AutomationAgent.Wait();
            AutomationAgent.Wait();
            if (AutomationAgent.VerifyControlExists("ContentManagerView", "CheckUpdate"))
            { 
            }
            else
            {
                WaitForCheckToUpdatesToAppear();
            }
            AutomationAgent.Click("ContentManagerView", "CheckUpdate");
        }

        /// <summary>
        /// Verifies No new update message
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNoNewupdateMsg()
        {
            int trial = 5;
            while (!AutomationAgent.VerifyControlExists("ContentManagerView", "CheckUpdate") && trial>0)
            {
                CommonReadCommonMethods.Sleep();
                trial--;
            }
            return AutomationAgent.VerifyControlExists("ContentManagerView", "NoUpdateMsg");
            
        }
        /// <summary>
        ///Verifies Downloading items control
        /// </summary>
        /// <returns></returns>
        public static bool VerifyDownloadingItemsMessage()
        {
            AutomationAgent.Wait(5000);
            string controltext = AutomationAgent.GetControlText("ContentManagerView", "DownloadingItems");
           if (controltext.Contains("Downloading"))
               return true;

           else
               return false;
        }

        public static bool VerifyShowDetailsButtonPresent()
        {
            AutomationAgent.Wait();
            AutomationAgent.Wait();
            if (AutomationAgent.VerifyControlExists("ContentManagerView", "CheckUpdate"))
                AutomationAgent.Click("ContentManagerView", "CheckUpdate");

            
            AutomationAgent.WaitForControlExists("DashboardView", "ShowDetailsSpinner",5000);
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowDetailsSpinner");
        }

        public static void ClickShowDetails()
        {
            AutomationAgent.Click("DashboardView", "ShowDetailsSpinner");
        }

        public static bool VerifyQueueContent()
        {
            return AutomationAgent.VerifyControlExists("ContentManagerView", "DownloadingQueueItem");
        }

        public static void WaitForCheckToUpdatesToAppear()
        {
            //int trial = 20;
            int trial = 10;
            while (!AutomationAgent.VerifyControlExists("ContentManagerView", "CheckUpdate") && trial > 0)
            {
                AutomationAgent.Wait();
                trial--;
            }
        }

        public static string GetUpdatedDateFromContentManager()
        {
            return AutomationAgent.GetControlText("ContentManagerView", "CheckUpdatedDate");
        }

        public static int GetDownloadingItemsNumber()
        {
            int itemsno = 0;
            string controltext = AutomationAgent.GetControlText("ContentManagerView", "DownloadingItems");
            if (controltext.Contains("Downloading"))
            {
                controltext = controltext.Replace("Downloading  ", "").Replace("  items ", "");
                itemsno = Int32.Parse(controltext);
            }

            return itemsno;


        }
        /// <summary>
        /// Verifies Old updates available or not 
        /// </summary>
        /// <returns>bool: true(if available), false(if not available)</returns>
        public static bool VerifyUpdatesAvaialble()
        {
            AutomationAgent.Wait(2000);
            int count = AutomationAgent.GetChildrenControlCount("ContentManagerView", "ContentManagerListView");
            if (count < 1)
                return false;
            else
                return true;
        }

        public static string GetDateFromUpdateGroup(int groupNo)
        {
            return AutomationAgent.GetControlText("ContentManagerView", "DatesInUpdatesGroup", WaitTime.DefaultWaitTime, groupNo.ToString());
        }
        /// <summary>
        /// Verify sectioned grade in downloading queue
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="grade"></param>
        /// <returns>bool: true(if found)</returns>
        public static bool VerifyDownloadingQueueItem(string subject, int grade)
        {
            AutomationAgent.Wait(10000);
            bool gradeFound = false;
            int count = AutomationAgent.GetChildrenControlCount("ContentManagerView", "ContentManagerUpdatesQueue");
            for (int i = 3; i <= count / 2 - 2; i++)
            {
                string item = AutomationAgent.GetControlText("ContentManagerView", "DownloadItemInQueue", WaitTime.DefaultWaitTime, i.ToString());
                if (item.Contains(subject + " Grade " + grade))
                {
                    gradeFound = true;
                    break;
                }
                else
                {
                    gradeFound = false;
                }
            }
            return gradeFound;

        }
        /// <summary>
        /// Verifies check for updates or downloading appears in content manager
        /// </summary>
        /// <returns>bool: true(if found)</returns>
        public static bool VerifyCheckToUpdatesOrDownloadingItemsAppear()
        {
            AutomationAgent.Wait();
            AutomationAgent.Wait();
            if (AutomationAgent.VerifyControlExists("ContentManagerView", "DownloadingItems") || AutomationAgent.VerifyControlExists("ContentManagerView", "CheckUpdate"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the Queue Content Present in the Show details of Content Manager Page
        /// </summary>
        /// <returns>string: Downloading content information</returns>
        public static string GetQueueContent()
        {
            return AutomationAgent.GetControlText("ContentManagerView", "DownloadingQueueItemContent", WaitTime.DefaultWaitTime, "1");
        }
    }
}
