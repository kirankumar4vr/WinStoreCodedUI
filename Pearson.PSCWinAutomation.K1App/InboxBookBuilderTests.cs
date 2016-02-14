using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using System.Configuration;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Pearson.PSCWinAutomation.Framework;
using Pearson.PSCWinAutomationFramework._K1App;
using Pearson.PSCWinAutomationFramework.__k1App;

namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for InboxBookBuilderTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InboxBookBuilderTests
    {
        public InboxBookBuilderTests()
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

        [TestMethod()]
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(53953), WorkItem(53965), WorkItem(53966), WorkItem(53967), WorkItem(53968), WorkItem(53970)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ABookBuilderBookWhichIsToBeSharedAndShareButtonToBeSharedTeacherShouldBeAtWorkingAndCorrectPosition()
        {
            try
            {
                Login student = Login.GetLogin("StudentKevin");
                Login teacher = Login.GetLogin("TeacherAdbul");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                NavigationCommonMethods.NavigateToBookBuilder();
                int countBefore = BookBuilderCommonMethods.GetBookCount();
                if (countBefore > 0)
                {
                    BookBuilderCommonMethods.DeleteBook();
                }
                BookShape shape = BookShape.Portrait;
                InboxBookBuilderCommonMethods.ShareBookWithTeacher(student, teacher, shape);
                //TC53970
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                //NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }



        [TestMethod()]
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(54667)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BTeacherInbox_SharedBookBuilderUI_PortraitBookUI()
        {
            try
            {
                Login student = Login.GetLogin("StudentKevin");
                Login teacher = Login.GetLogin("TeacherAdbul");
                //NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                //NavigationCommonMethods.NavigateToBookBuilder();
                //int countBefore = BookBuilderCommonMethods.GetBookCount();
                //if (countBefore > 0)
                //{
                //    BookBuilderCommonMethods.DeleteBook();
                //}
                //BookShape shape = BookShape.Landscape;
                //InboxBookBuilderCommonMethods.ShareBookWithTeacher(student, teacher, shape);
                ////TC53970
                //BookBuilderCommonMethods.DeleteBook();
                //NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

                InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(teacher);
                 string assertFailureMessage;
                //TC54667
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShapeInbox(BookShape.Portrait), "Book shape not correct");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }


        [TestMethod()]
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(54668)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BTeacherInbox_SharedBookBuilderUI_SquareBookUI()
        {
            try
            {
                Login student = Login.GetLogin("StudentKevin");
                Login teacher = Login.GetLogin("TeacherAdbul");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                NavigationCommonMethods.NavigateToBookBuilder();
                int countBefore = BookBuilderCommonMethods.GetBookCount();
                if (countBefore > 0)
                {
                    BookBuilderCommonMethods.DeleteBook();
                }
                BookShape shape = BookShape.Square;
                InboxBookBuilderCommonMethods.ShareBookWithTeacher(student, teacher, shape);
                //TC53970
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

                InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(teacher);
                string assertFailureMessage;
                //TC54668
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShapeInbox(shape), "Book shape not correct portrait");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(54669)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BTeacherInbox_SharedBookBuilderUI_LandscapeBookUI()
        {
            try
            {
                Login student = Login.GetLogin("StudentKevin");
                Login teacher = Login.GetLogin("TeacherAdbul");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                NavigationCommonMethods.NavigateToBookBuilder();
                int countBefore = BookBuilderCommonMethods.GetBookCount();
                if (countBefore > 0)
                {
                    BookBuilderCommonMethods.DeleteBook();
                }
                BookShape shape = BookShape.Landscape ;
                InboxBookBuilderCommonMethods.ShareBookWithTeacher(student, teacher, shape);
                //TC53970
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

                InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(teacher);
                string assertFailureMessage;
                //TC54669
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShapeInbox(shape), "Book shape not correct portrait");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }



        [TestMethod()]
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(54671), WorkItem(54670), WorkItem(54672)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BTeacherInbox_SharedBookBuilderUI_BookCoverPageSnapshot()
        {
            try
            {
                Login student = Login.GetLogin("StudentKevin");
                Login teacher = Login.GetLogin("TeacherAdbul");
                //NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                //NavigationCommonMethods.NavigateToBookBuilder();
                //int countBefore = BookBuilderCommonMethods.GetBookCount();
                //if (countBefore > 0)
                //{
                //    BookBuilderCommonMethods.DeleteBook();
                //}
                //BookShape shape = BookShape.Landscape;
                //InboxBookBuilderCommonMethods.ShareBookWithTeacher(student, teacher, shape);
                ////TC53970
                //BookBuilderCommonMethods.DeleteBook();
                //NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

                InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(teacher);
                string assertFailureMessage;
                //InboxCommonMethods.ClickOnSharedItemInbox();
                //TC54670
                Assert.IsTrue(InboxCommonMethods.VerifyNewBannerLabelForSharedItemInbox(), "New banner lable for inbox item not found");

                //TC54671
                Assert.IsTrue(InboxBookBuilderCommonMethods.VerifySharedBookHasTitleAndAuthorName(), "SHared book title autohor name not found");
                //TC54672
                Assert.IsFalse(NotebookCommonMethods.VerifyHandIconPresent(), "hand icon or any editable tool found");
                Assert.IsFalse(NotebookCommonMethods.VerifyCrayonToolIconPresent(), "crayon pen tool present to edit");
                
                
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }




        [TestMethod()]
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(53969)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ShareBookBuilderBookWithTeacher_VerifyFailureAlertBox()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                int countBefore = BookBuilderCommonMethods.GetBookCount();
                if (countBefore > 0)
                {
                    BookBuilderCommonMethods.DeleteBook();
                }
                BookShape shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyShareIconIsAtRightSideOfEditButton(), "Share icon not at rigt of edit button");
                BookBuilderCommonMethods.ClickShareIconInBookBuilder();

                Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "Share confirmation not found");
                BookBuilderCommonMethods.ClickShareIconInBookBuilder();
                AutomationAgent.DisableNetwork();
                NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentFailureMessage(), "notebook sent failure message not found");
                NotebookCommonMethods.ClickToCloseNotebookSenFailureMessage();
                AutomationAgent.EnableNetwork();
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                //NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }
    }
}
