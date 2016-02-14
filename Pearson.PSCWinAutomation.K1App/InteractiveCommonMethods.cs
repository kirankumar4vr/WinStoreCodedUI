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


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for InteractiveCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
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

        public static void ClickSendToNotebookInteractive()
        {
            AutomationAgent.Click("InteractiveView", "InteractiveSendToNotebookButton");
        }

        public static bool VerifySendToNotebookConfirmationPopup()
        {
           return AutomationAgent.VerifyControlExists("InteractiveView", "InteractiveSendToNotebookPopup");
        }

        public static void ClickSendToNotebookPopupCancel()
        {
            AutomationAgent.Click("InteractiveView", "InteractiveSendToNotebookPopupCancel");
        }

        public static void ClickSendToNotebookPopupAccept()
        {
            AutomationAgent.Click("InteractiveView", "InteractiveSendToNotebookPopupAccept");
        }
    }
}
