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
using System.Linq;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for ChellengeProblemCommonMethods
    /// </summary>
    
    public class ChallengeProblemCommonMethods
    {
        public ChallengeProblemCommonMethods()
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

        public static bool VerifyChallengeProblemButton(int taskNumber)
        {
            bool b = AutomationAgent.VerifyControlExists("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());

            return b;
        }

        public static bool VerifyChallengeProblemPage()
        {
            bool b1 = AutomationAgent.VerifyControlExists("LessonView", "ChallengeProblemPage");

            return b1;
        }


       

       /// <summary>
       /// Clcik to close challenge problem
       /// </summary>
        public static void ClickOnDoneButtonInChallengeProblem()
        {
            AutomationAgent.Wait(500);
            AutomationAgent.Click("DashboardView", "CloseButton");
            AutomationAgent.Wait(800);
        }

        /// <summary>
        /// Verifies Done Button presence
        /// </summary>
        /// <returns>true:Done button available; false: done button not available</returns>
        public static bool VerifyDoneButtonInChallengeProblem()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "CloseButton");
        }

        /// <summary>
        /// Verifies Notebook Icon
        /// </summary>
        /// <returns>true:Icon available;false:Notebook icon not found</returns>
        public static bool VerifyNotebookIcon()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookIcon");
        }

        /// <summary>
        /// Verifies Challenge problem appears as full screen
        /// </summary>
        /// <returns></returns>
        public static bool VerifyChallengeProblemPageFullScreen()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int PagePosX = AutomationAgent.GetControlPositionX("LessonView", "ChallengeProblemPageTitle");
            int PagePosWidth = AutomationAgent.GetControlWidth("LessonView", "ChallengeProblemPageTitle");

            int Diff = (ScreenSize / 2) - (PagePosX + (PagePosWidth / 2));

            if (Diff == 0)
                return true;

            else
                return false;
        }

        /// <summary>
        /// Verifies the Context icons for Challenge Problem
        /// </summary>
        /// <returns></returns>
        public static bool VerifyThreeContextIconsforChallengeProblem()
        {

            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                          AutomationAgent.VerifyControlExists("NotebookView", "NotebookIcon") &&
                          (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeTeacherGuideTitle") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies the title for challenege problem
        /// </summary>
        /// <returns></returns>
        public static bool VerifyChallengeProblemTitle()
        {
           string Title =  AutomationAgent.GetControlText("LessonView", "ChallengeProblemPage");

           return Title.Equals("Challenge Problem");
        }

        /// <summary>
        /// Verifies the tile of challenge problem to be at screen center
        /// </summary>
        /// <returns></returns>
        public static bool VerifyChallengeProblemTitleAtCenter()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int ChallengProbX = AutomationAgent.GetControlPositionX("LessonView", "ChallengeProblemPageTitle");
            int ChallengProbWidth = AutomationAgent.GetControlWidth("LessonView", "ChallengeProblemPageTitle");

            int diff = (ScreenSize / 2) - (ChallengProbX + (ChallengProbWidth / 2));
            if (diff == 0)
                return true;

            else
                return false;
        }
        /// <summary>
        /// To get the Position of Challenge problem page
        /// </summary>
        /// <returns></returns>
        public static string GetChallengeProblemPageTextPos()
        {
            string ChallengeProbX = (AutomationAgent.GetControlPositionX("LessonView", "ChallengeProblemPageTitle")).ToString();
            string ChallengeProbY = AutomationAgent.GetControlPositionY("LessonView", "ChallengeProblemPageTitle").ToString();

            return (ChallengeProbX + "," + ChallengeProbY);
        }

        public static bool VerifyDoneButtonAtTopRight()
        {
            
            int DonePosX = AutomationAgent.GetControlPositionX("DashboardView", "CloseButton");
            int DonePosY = AutomationAgent.GetControlPositionY("DashboardView", "CloseButton");

            if (DonePosX < 20 && DonePosY < 20)
                return true;

            else
                return false;
        }

        public static bool VerifyNotebookIconAtTopLeft()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int NbPosX = AutomationAgent.GetControlPositionX("NotebookView", "NotebookIcon");
            int NbPosY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookIcon");

            if ((NbPosX > (ScreenSize - 200)) && NbPosY < 20)
                return true;

            else
                return false;
        }
    }
}
