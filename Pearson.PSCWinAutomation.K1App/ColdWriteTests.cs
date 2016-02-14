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
using Pearson.PSCWinAutomationFramework.K1App;
using Pearson.PSCWinAutomationFramework._K1App;
using Pearson.PSCWinAutomationFramework.__k1App;

namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for ColdWriteTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class ColdWriteTests
    {
        public ColdWriteTests()
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

        //Sprint-24
        [TestMethod()]
        [TestCategory("AssessmentTests"), TestCategory("Sprint24")]
        [Priority(2)]
        [WorkItem(53685), WorkItem(53736), WorkItem(53743), WorkItem(53746), WorkItem(53748), WorkItem(53737)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyTheFunctionalityOfColdWriteIconOnTodayShelf_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                //TC53685
                Assert.IsTrue(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon not found for ela");

                //TC53736
                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteNotebookIconEnabled(), "notebook icon not enabled in cold write");

                //TC53743
                AssessmentCommonMethods.ClickColdWriteNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookCanvasOpenedAndBasicToolbars(), "notebook canvas not found");

                //TC53746
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWritePromptButtonOnTopLeft(), "cold write prompt button not found");
                //Assert.IsFalse(AssessmentCommonMethods.VerifyPlusAndSubmitButtononNotebook(), "pls and submit button airplane found");

                //TC53748
                AssessmentCommonMethods.ClickColdWritePromptButtonOnTopLeft();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");

                AssessmentCommonMethods.ClickAssessmentColdWriteOverlayBackButton();
                //TC53737
                Assert.IsFalse(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                NotebookCommonMethods.ClickBackButtonNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "todays lesson shelf not found");
                NavigationCommonMethods.Logout();
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
        [TestCategory("AssessmentTests"), TestCategory("Sprint24")]
        [Priority(2)]
        [WorkItem(53787)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyThatAssessmentResponseNotebookisSavedLocally_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon not found for ela");
                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                AssessmentCommonMethods.ClickColdWriteNotebookIcon();

                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                NotebookCommonMethods.ClickBackButtonNotebook();

                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                AssessmentCommonMethods.ClickColdWriteNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("test"), "text not found in notebook");

                NotebookCommonMethods.ClickBackButtonNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "todays lesson shelf not found");
                NavigationCommonMethods.Logout();
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
        [TestCategory("AssessmentTests"), TestCategory("Sprint24")]
        [Priority(2)]
        [WorkItem(53750), WorkItem(53758), WorkItem(53760)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyTheFunctionalityOfColdWriteIconOnTodayShelf_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                //TC53750
                Assert.IsTrue(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon not found for ela");

                //TC53758
                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                Assert.IsFalse(AssessmentCommonMethods.VerifyColdWriteNotebookIconEnabled(), "notebook icon not enabled in cold write");

                //TC53760
                AssessmentCommonMethods.ClickAssessmentColdWriteOverlayBackButton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "todays lesson shelf not found");
                NavigationCommonMethods.Logout();
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
        [TestCategory("AssessmentTests"), TestCategory("Sprint24")]
        [Priority(2)]
        [WorkItem(53783)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyThatColdWriteIconIsNotVisibleOnMediaLibrary_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");

                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "user not navigated to media library");

                Assert.IsFalse(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon found for media lib");
                NavigationCommonMethods.SwipeScreenUp();
                NavigationCommonMethods.SwipeScreenUp();
                NavigationCommonMethods.SwipeScreenUp();
                Assert.IsFalse(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon found for media lib");
                NavigationCommonMethods.Logout();
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
        [TestCategory("AssessmentTests"), TestCategory("Sprint24")]
        [Priority(2)]
        [WorkItem(53790), WorkItem(53783)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyThatColdWriteIconIsNotVisibleOnMediaLibrary_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");

                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "user not navigated to media library");

                Assert.IsFalse(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon found for media lib");
                NavigationCommonMethods.SwipeScreenUp();
                NavigationCommonMethods.SwipeScreenUp();
                NavigationCommonMethods.SwipeScreenUp();
                Assert.IsFalse(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon found for media lib");
                NavigationCommonMethods.Logout();
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
        [TestCategory("AssessmentTests")]
        [Priority(2)]
        [WorkItem(54058), WorkItem(54059), WorkItem(54061), WorkItem(54070)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Assessments_VerifyTappingOnSendButtonInitiatesStandardSendUIPopup()
        {
            try
            {
               Login loginTchr = Login.GetLogin("TeacherAutomation");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                
                Assert.IsTrue(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon not found for ela");
                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                AssessmentCommonMethods.ClickColdWriteNotebookIcon();

                Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon present on notebook");
                NotebookCommonMethods.ClickShareAirplaneIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "share notebook confirm prompt not found");
                NotebookCommonMethods.SelectTeacherinSharePrompt(loginTchr.PersonName);
                NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
                NotebookCommonMethods.CloseNotebookSentPopup();
                
                //TC54070
                ////AssessmentCommonMethods.ClickColdWritePromptButtonOnTopLeft();
                ////Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                ////AssessmentCommonMethods.ClickAssessmentColdWriteOverlayBackButton();
                ////Assert.IsFalse(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "todays lesson shelf not found");
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon not found for ela");
                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsFalse(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write opened even after submission");
                NavigationCommonMethods.Logout();
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
        [TestCategory("AssessmentTests")]
        [Priority(2)]
        [WorkItem(54065), WorkItem(54071)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Assessments_VerifyNoInternetConnectionMessage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentAutomation"));
                NavigationCommonMethods.NavigateToELAUnit(7);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyColdWriteIcon(), "Cold write icon not found for ela");
                NavigationCommonMethods.ClickColdWriteIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyColdWriteOverlay(), "cold write not opened");
                AssessmentCommonMethods.ClickColdWriteNotebookIcon();

                Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon not found");
                AutomationAgent.DisableNetwork();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAlertPopupTeacherSupport(), "No internet aler popup not found");
                NavigationCommonMethods.ClickToCloseNoInternetAlertPopupTeacherSupport();
                //TC54071
                Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon not found");

                //NotebookCommonMethods.ClickShareAirplaneIcon();
                //Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "share notebook confirm prompt not found");
                //AutomationAgent.DisableNetwork();
                //NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
                //Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentFailureMessage(), "notebook sent failure message not found");
                //NotebookCommonMethods.ClickToCloseNotebookSenFailureMessage();
                AutomationAgent.EnableNetwork();
                AssessmentCommonMethods.ClickColdWritePromptButtonOnTopLeft();
                AssessmentCommonMethods.ClickAssessmentColdWriteOverlayBackButton();
                NavigationCommonMethods.Logout();
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
