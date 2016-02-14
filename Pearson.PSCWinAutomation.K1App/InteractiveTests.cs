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
using Pearson.PSCWinAutomationFramework.__k1App;
using Pearson.PSCWinAutomationFramework._K1App;



namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for InteractiveTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InteractiveTests
    {
        public InteractiveTests()
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
        [TestCategory("InteractiveTests")]
        [Priority(1)]
        [WorkItem(34132), WorkItem(45008)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_SaveInteractivetoNotebook_ConfirmationPrompt()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyInteractiveThumbnailinELA(), "interactive thumbnail not found");
                NavigationCommonMethods.ClickInteractiveThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                InteractiveCommonMethods.ClickSendToNotebookInteractive();
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
                InteractiveCommonMethods.ClickSendToNotebookPopupCancel();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                InteractiveCommonMethods.ClickSendToNotebookInteractive();
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
                InteractiveCommonMethods.ClickSendToNotebookPopupAccept();
                AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "interactive thumnail not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                UnitSelectionCommonMethods.ClickInteractiveBackButton();
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
        [TestCategory("InteractiveTests")]
        [Priority(1)]
        [WorkItem(34133)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_SaveInteractivetoNotebook_NotebookCanvasEditView()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyInteractiveThumbnailinELA(), "interactive thumbnail not found");
                NavigationCommonMethods.ClickInteractiveThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                InteractiveCommonMethods.ClickSendToNotebookInteractive();
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
                InteractiveCommonMethods.ClickSendToNotebookPopupCancel();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                InteractiveCommonMethods.ClickSendToNotebookInteractive();
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
                InteractiveCommonMethods.ClickSendToNotebookPopupAccept();
                AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "interactive thumnail not found in notebook");
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconEnabled(), "hand icon not enabled");
                NotebookCommonMethods.ClickBackButtonNotebook();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                UnitSelectionCommonMethods.ClickInteractiveBackButton();
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
        [TestCategory("InteractiveTests")]
        [Priority(1)]
        [WorkItem(45007)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Launch3DInteractives_MediaLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Lib screen not verified");
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnailShelf2Items(1);

                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                UnitSelectionCommonMethods.ClickInteractiveBackButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Lib screen not verified");
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(45005)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Launch3DInteractives_TodayShelf()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyInteractiveThumbnailinELA(), "interactive thumbnail not found");
                NavigationCommonMethods.ClickInteractiveThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                InteractiveCommonMethods.ClickSendToNotebookInteractive();
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
                InteractiveCommonMethods.ClickSendToNotebookPopupCancel();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                UnitSelectionCommonMethods.ClickInteractiveBackButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
