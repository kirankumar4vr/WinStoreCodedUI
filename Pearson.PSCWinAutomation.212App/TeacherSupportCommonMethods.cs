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
    class TeacherSupportCommonMethods
    {
       /// <summary>
       /// Clicks on Grow Your Skill Button
       /// </summary>
        public static void ClickOnGrowYourSkills()
        {
            AutomationAgent.Click("TeacherSupportView", "GrowYourSkills");
        }

        /// <summary>
        /// Clicks on Prepare Your Lesson Button
        /// </summary>
        public static void ClickOnPrepareYourLesson()
        {
            AutomationAgent.Click("TeacherSupportView", "PrepareYourLesson");
        }

        /// <summary>
        /// Clicks on Get Help Button
        /// </summary>
        public static void ClickOnGetHelp()
        {
            AutomationAgent.Click("TeacherSupportView", "GetHelp");
        }

        /// <summary>
        /// Verifies whether PSoC app active or not
        /// </summary>
        /// <returns>true: if app is in focus, false:if not in focus</returns>
        public static bool VerifyBrowserOpenedforTeacherSupport(string BrowserControl)
        {
            return AutomationAgent.VerifyDesktopChildByName(BrowserControl);
        }
        /// <summary>
        /// Verifies No Internet Access Message 
        /// </summary>
        /// <returns>bool: true(if message is similar), false(if not similar)</returns>
        public static bool VerifyNoInternetAccessMessage()
        {
            string message = AutomationAgent.GetControlText("TeacherSupportView", "NoInternetAccessMessage");
            if (message == "There is no internet access at this time. Please try again later.")
                return true;

            else
                return false;
        }
        /// <summary>
        /// Clicks on the Close button present in the message
        /// </summary>
        public static void ClickOnMessageCloseButton()
        {
            AutomationAgent.Click("LoginView", "CloseButton");
        }
        /// <summary>
        /// Clicks on the Teacher Support Button present in the Dashboard
        /// </summary>
        public static void ClickTeacherSupportButtonInDashboard()
        {
            AutomationAgent.Click("DashboardView", "TeacherSupportButton");
            AutomationAgent.Wait();
        }
        /// <summary>
        /// Verifies the Teacher Support Page present or not
        /// </summary>
        /// <returns>bool: true(if all the elements specified are present), false(if any of the element not present)</returns>
        public static bool VerifyTeacherSupportPage()
        {
            if (AutomationAgent.VerifyControlExists("TeacherSupportView", "TeacherSupportTitle") &&
               AutomationAgent.VerifyControlExists("TeacherSupportView", "GrowYourSkills") &&
               AutomationAgent.VerifyControlExists("TeacherSupportView", "PrepareYourLesson") &&
               AutomationAgent.VerifyControlExists("TeacherSupportView", "GetHelp"))
                return true;
            else
                return false;
        }
    }
}
