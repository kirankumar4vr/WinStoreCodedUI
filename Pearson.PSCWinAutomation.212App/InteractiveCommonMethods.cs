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
    /// Summary description for InteractiveCommonMethods
    /// </summary>
    
    public class InteractiveCommonMethods
    {
        public InteractiveCommonMethods()
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
        /// Verify Math Chrome Visible or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifyMathChromeVisible()
        {
            return AutomationAgent.VerifyControlExists("InteractiveView", "Appchrome");
        }

        /// <summary>
        /// Verify Close button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyTopLeftDoneButton()
        {
            return AutomationAgent.VerifyControlExists("InteractiveView", "CloseButton");
        }

        /// <summary>
        /// Clicks to close interactive
        /// </summary>
        public static void ClickOnInteractiveDoneButton()
        {
            AutomationAgent.Wait(500);
            AutomationAgent.Click("InteractiveView", "CloseButton");
            AutomationAgent.Wait(500);
        }

        /// <summary>
        /// Verifies save to Notebook icon availability
        /// </summary>
        /// <returns></returns>
        public static bool VerifySendToNotebookAvailable()
        {
            return AutomationAgent.VerifyControlExists("InteractiveView", "SendToNotebookIcon");
        }

        /// <summary>
        /// Verifies Lesson Task Page
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonTaskPage()
        {
            return AutomationAgent.VerifyControlExists("InteractiveView", "LessonTaskChrome");
        }

       

        /// <summary>
        /// Verifies Interactive is opened or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifyInteractiveOpen()
        {
            //return AutomationAgent.VerifyControlExists("InteractiveView", "Appchrome") || AutomationAgent.VerifyControlExists("InteractiveView", "CloseButton");
            return AutomationAgent.VerifyControlExists("InteractiveView", "Appchrome");
//            return AutomationAgent.VerifyControlExists("InteractiveView", "Appchrome") && AutomationAgent.VerifyControlExists("InteractiveView", "CloseButton");
        }

        /// <summary>
        /// Verify Lesson Task Number
        /// </summary>
        /// <param name="LessonTask"></param>
        /// <returns></returns>
        public static bool VerifyLessonTaskNumber(int LessonTask)
        {
            if (AutomationAgent.GetControlText("InteractiveView", "LessonTaskChrome").Contains("Lesson "+LessonTask.ToString())) 
                    return true;

            else
            return false;
        }

        public static bool VerifySendToNotebookAtTopRight()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int NbPosX = AutomationAgent.GetControlPositionX("InteractiveView", "SendToNotebookIcon");
            int NbPosY = AutomationAgent.GetControlPositionY("InteractiveView", "SendToNotebookIcon");

            if ((NbPosX > (ScreenSize - 200)) && NbPosY < 20)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Clicks on Send To Notebook Icon present at the Top of Interactive Page
        /// </summary>
        public static void ClickSendToNotebookIcon()
        {
            AutomationAgent.Click("InteractiveView", "SendToNotebookIcon");
            AutomationAgent.Wait(2000);
        }
        /// <summary>
        /// Verifies Save Interactive Alert Box containing message and Two Button CANCEL & CONTINUE
        /// </summary>
        /// <returns>bool: true(if all the elements of Alert Box present), false(if any of the element not present)</returns>
        public static bool VerifySaveInteractiveAlert()
        {
            if (AutomationAgent.VerifyControlExists("NoteBookMathView", "SaveInteractiveAlertMessage") &&
               AutomationAgent.VerifyControlExists("NoteBookMathView", "CANCEL") &&
                AutomationAgent.VerifyControlExists("NoteBookMathView", "Okay"))
               //AutomationAgent.VerifyControlExists("NoteBookMathView", "CONTINUE"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Cancel button present in the Save Interactive Alert 
        /// </summary>
        public static void ClickCancelInSaveInteractiveAlert()
        {
            AutomationAgent.Click("NoteBookMathView", "CANCEL");
        }
        /// <summary>
        /// Clicks on Continue In Save Interactive Alert
        /// </summary>
        public static void ClickContinueInSaveInteractiveAlert()
        {
            //AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("NoteBookMathView", "Okay");
            AutomationAgent.Wait(500);

            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            }

            if (AutomationAgent.VerifyControlExists("NotebookView", "HandIcon"))
            {
                NotebookCommonMethods.ClickHandIconInNotebook();
                NotebookCommonMethods.ClickHandIconInNotebook();
            }
        }
        /// <summary>
        /// Edits interactive 
        /// </summary>
        public static void EditInteractive()
        {
            AutomationAgent.Slide(690, 110, 331, 312);
            AutomationAgent.Wait(2000);
        }

        /// <summary>
        /// Clicks Interactive thumbnail
        /// </summary>
        public static void ClickInteractiveThumbnail()
        {
            AutomationAgent.Click("NoteBookMathView", "PARTImage");
            AutomationAgent.Wait(2000);
        }
    }
}
