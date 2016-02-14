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
using Pearson.PSCWinAutomationFramework.__k1App;
using Pearson.PSCWinAutomationFramework._K1App;


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for InboxBookBuilderCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InboxBookBuilderCommonMethods
    {
        public InboxBookBuilderCommonMethods()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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

        public static void ShareBookWithTeacher(Login student, Login teacher, BookShape shape)
        {
            BookBuilderCommonMethods.CreateBook(student.UserName, student.PersonName, shape);
            string assertFailureMessage;
            //TC53953
            Assert.IsTrue(BookBuilderCommonMethods.VerifyBookIsAtCenterOfScreen(out assertFailureMessage), assertFailureMessage);
            //TC53965
            Assert.IsTrue(BookBuilderCommonMethods.VerifyShareIconIsAtRightSideOfEditButton(), "Share icon not at rigt of edit button");
            BookBuilderCommonMethods.ClickShareIconInBookBuilder();

            //TC53966
            Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "Share confirmation not found");
            Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationTeacherListScroll(), "teacher list no scrolling");
            //TC53967
            NotebookCommonMethods.ClickXCloseIconInSharePrompt();

            Assert.IsFalse(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "Share confirmation still found");
            BookBuilderCommonMethods.ClickShareIconInBookBuilder();
            NotebookCommonMethods.SelectTeacherinSharePrompt(teacher.PersonName);

            NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
            //TC53968
            Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
            NotebookCommonMethods.CloseNotebookSentPopup();
        }

        public static bool VerifySharedBookHasTitleAndAuthorName()
        {
            throw new NotImplementedException();
        }
    }
}
