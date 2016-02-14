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


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for TeacherSupportTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class TeacherSupportTests
    {
        public TeacherSupportTests()
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




         [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(23246)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupportPageBackButtonRetainsPreviousScreen()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA grade is not appearing");
                NavigationCommonMethods.NavigateToTeacherSupport();
               Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(),"Teacher Support Page not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA grade is not appearing");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(),"Unit home screen not found");
                NavigationCommonMethods.NavigateToTeacherSupport();
               Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(),"Teacher Support Page not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(),"Unit home screen not found");

                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(),"Media Library  screen not found");
                NavigationCommonMethods.NavigateToTeacherSupport();
               Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(),"Teacher Support Page not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(),"Media Library screen not found");

                 NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(),"Notebook screen not found");
                NavigationCommonMethods.NavigateToTeacherSupport();
               Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(),"Teacher Support Page not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(),"Notebook  screen not found");

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
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(23247)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ZTeacherSupport_OfflineMessage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToTeacherSupport();
                AutomationAgent.DisableNetwork();
                AutomationAgent.Wait(500);
                NavigationCommonMethods.ClickGrowYourSkills();
                Assert.IsTrue(NavigationCommonMethods.VerifyNoInternetAlertPopupTeacherSupport(), "No internet alert popup not found");
                NavigationCommonMethods.ClickToCloseNoInternetAlertPopupTeacherSupport();
                NavigationCommonMethods.ClickPrepareYoyrLessons();
                Assert.IsTrue(NavigationCommonMethods.VerifyNoInternetAlertPopupTeacherSupport(), "No internet alert popup not found");
                NavigationCommonMethods.ClickToCloseNoInternetAlertPopupTeacherSupport();
                NavigationCommonMethods.ClickGetHelp();
                Assert.IsTrue(NavigationCommonMethods.VerifyNoInternetAlertPopupTeacherSupport(), "No internet alert popup not found");
                NavigationCommonMethods.ClickToCloseNoInternetAlertPopupTeacherSupport();
                AutomationAgent.EnableNetwork();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(22576), WorkItem(45893), WorkItem(45892)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_FrameOnlyBehaviorWhileTappingonEXPANDButtonANdZoomingDisabled()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode not expanded to screen");
                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode not expanded to screen");
                //TC45892
                int TeacherPaneWidth = TeacherSupportCommonMethods.GetWidthOfTeacherModePane();
                TeacherSupportCommonMethods.ZoomInTeacherModePane();
                int TeacherPaneWidthNow = TeacherSupportCommonMethods.GetWidthOfTeacherModePane();
                Assert.IsTrue(TeacherPaneWidthNow == TeacherPaneWidth, "zoomed in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(22579)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CloseTeacherMode_FrameWhenSystemTrayTapped()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                AutomationAgent.Wait();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is still opened in teacher mode");
                NavigationCommonMethods.OpenOrCloseSystemTray();
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
        [TestCategory("TeacherSupportTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(22706)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_TodayShelfVisible_LessonOverview()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenLessonOverview(), "Lesson overview is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(44001), WorkItem(22574), WorkItem(45882)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void  TeacherGuideFlyoutMenu_VerifyUnitOverviewDisplayedonTeacherGuidePanel()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutLessonOverviewEnabled(), "lesson overview enabled in teacher guide flyout");
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutLessonGuideEnabled(), "lesson overview enabled in teacher guide flyout");
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();

                //Media Lib
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(),"not navigated to media lib");
                NavigationCommonMethods.ClickTeacherModeButton();
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutLessonOverviewEnabled(), "lesson overview enabled in teacher guide flyout");
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutLessonGuideEnabled(), "lesson overview enabled in teacher guide flyout");
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();

                //Nb
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "not navigated to notebook");
                NavigationCommonMethods.ClickTeacherModeButton();
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutLessonOverviewEnabled(), "lesson overview enabled in teacher guide flyout");
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutLessonGuideEnabled(), "lesson overview enabled in teacher guide flyout");
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(22577)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_OpenUnitHomeScreenWhentheTeacherModeisENABLED()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                //Media Lib
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "not navigated to media lib");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");


                NavigationCommonMethods.NavigateToHome();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");

                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(22578)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeFrame_OpenTEACHERMODEFrameWhenNOTEBOOKBrowserIconTappedFromNavigationBar()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");


                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(22702)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_RightPaneContent_OpenCloseABOUTTHISLESSON()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenLessonOverview(), "Lesson overview is not opened in teacher mode");

                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                AutomationAgent.Wait(1000);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenLessonOverview(), "Lesson overview is opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(22704), WorkItem(22705), WorkItem(22644)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_MediaLibrary_ExpandAndContractTeacherMode()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                //Media Lib
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "not navigated to media lib");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode is not full screen");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyUnitOverviewTitleisAtScreenCenter(), "unit overview title not at screen center");

                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode is still full screen");

                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(44002)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuideFlyoutMenu_VerifyLesson_LessonGuide_UnitOverviewDisplayedonTeacherGuidePanel()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                NavigationCommonMethods.ClickTeacherModeButton();
                
                //Unit Overview
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenLessonOverview(), "Lesson overview is opened in teacher mode");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenLessonGuide(), "Lesson guide is opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();

                
                //Lesson Overview
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickLessonOverviewMenuItem();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is opened in teacher mode");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenLessonOverview(), "Lesson overview is not opened in teacher mode");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenLessonGuide(), "Lesson guide is opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();

                //Lesson Guide
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickLessonGuideMenuItem();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is opened in teacher mode");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenLessonOverview(), "Lesson overview is opened in teacher mode");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenLessonGuide(), "Lesson guide is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();


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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(22580)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_RightFrameonly_VerifyThatWhenRightFrameisExpandedItOverlapsMainFrame()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode is not full screen");
                NavigationCommonMethods.CloseTeacherMode();

                //Media Lib
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "not navigated to media lib");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode is not full screen");
                NavigationCommonMethods.CloseTeacherMode();

                //Nb
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "not navigated to notebook");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                TeacherSupportCommonMethods.ClickTeacherModeExpandButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherModeIsFullScreen(), "teacher mode is not full screen");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(44000)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuideFlyoutMenu_VerifyFlyoutMenuisDisplayedWhenTaponTeacherGuideIcon()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();

                //Lesson Guide
                NavigationCommonMethods.ClickTeacherModeButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutMenuItems(), "techer guide flyout menu items not verified");
                NavigationCommonMethods.ClickLessonGuideMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenLessonGuide(), "Lesson guide is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();


                //Media Lib
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "not navigated to media lib");
                NavigationCommonMethods.ClickTeacherModeButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutMenuItems(), "techer guide flyout menu items not verified");
                eReaderCommonMethods.TapOnEReaderScreen();
                

                //Nb
                AutomationAgent.Wait(1000);
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "not navigated to notebook");
                NavigationCommonMethods.ClickTeacherModeButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutMenuItems(), "techer guide flyout menu items not verified");
                eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherGuideFlyoutMenuItems(), "techer guide flyout menu items still found");

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
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(23245)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupport_OpenTeacherSupportfromSystemTray()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifySytemTrayContentsTeacherSupportButton(), "teacher support found");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.Logout();
                
                //Teacher
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToTeacherSupport();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page not found");
                NavigationCommonMethods.ClickGrowYourSkills();
                AutomationAgent.Wait();
                AutomationAgent.Wait();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Home - Google Chrome") || TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Home - Internet Explorer"), "App is still in focus");
                AutomationAgent.LaunchApp();

                NavigationCommonMethods.ClickPrepareYoyrLessons();
                AutomationAgent.Wait(); AutomationAgent.Wait();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Prepare Your Lesson | Teacher Support | Pearson System of Courses - Google Chrome") || TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Prepare Your Lesson | Teacher Support | Pearson System of Courses - Internet Explorer"), "App is still in focus");
                AutomationAgent.LaunchApp();
                
                NavigationCommonMethods.ClickGetHelp();
                AutomationAgent.Wait(); AutomationAgent.Wait();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Get Help | Teacher Support | Pearson System of Courses - Google Chrome") || TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Get Help | Teacher Support | Pearson System of Courses - Internet Explorer"), "App is still in focus");
                AutomationAgent.LaunchApp();

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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45393),WorkItem(45397)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_ClassRosterMyClassroomRoster()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyClassRosterPresentInTeacherMode(), "My classroom not found");
                TeacherSupportCommonMethods.ClickMyClassRosterInTeacherMode();
                AutomationAgent.Wait(4000);
                AutomationAgent.Wait(4000);
                //TC45397
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherCanSeeStudentsInClassRoster(), "teacher cant see students in class roster");
                if(!TeacherSupportCommonMethods.VerifyNoStudentsForTheTeacher())
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyStudentNameAlphabeticInClassRoster(), "student name not alphabetically sorted");

                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45396)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_ClassRosterOfflineMessage_Roster()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");

                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyClassRosterPresentInTeacherMode(), "My classroom not found");
                TeacherSupportCommonMethods.ClickMyClassRosterInTeacherMode();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyClassRosterOfflineMessage("You must be connected to the internet to retrieve the class roster."), "class roster offline message not found");

                NavigationCommonMethods.CloseTeacherMode();
                AutomationAgent.EnableNetwork();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45398)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_ClassRosterNoInternetConnection()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyClassRosterPresentInTeacherMode(), "My classroom not found");
                TeacherSupportCommonMethods.ClickMyClassRosterInTeacherMode();
                AutomationAgent.Wait(4000);
                AutomationAgent.Wait(4000);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherCanSeeStudentsInClassRoster(), "teacher cant see students in class roster");
                TeacherSupportCommonMethods.ClickStudentTileInClassRoster(1);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyShowPasswordButtonInStudentTile(1), "show password button not found");
                AutomationAgent.DisableNetwork();
                AutomationAgent.Wait();

                TeacherSupportCommonMethods.ClickShowPasswordButtonInStudentTile(1);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAlertPopupTeacherSupport(), "No internet alert popup not found");
                NavigationCommonMethods.ClickToCloseNoInternetAlertPopupTeacherSupport();
                NavigationCommonMethods.CloseTeacherMode();
                AutomationAgent.EnableNetwork();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45395), WorkItem(45880)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_ClassRosterNoPicturePasswordForStudent()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyClassRosterPresentInTeacherMode(), "My classroom not found");
                TeacherSupportCommonMethods.ClickMyClassRosterInTeacherMode();
                AutomationAgent.Wait(4000);
                AutomationAgent.Wait(4000);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherCanSeeStudentsInClassRoster(), "teacher cant see students in class roster");
                TeacherSupportCommonMethods.ClickStudentTileInClassRoster(1);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyShowPasswordButtonInStudentTile(1), "show password button not found");
                TeacherSupportCommonMethods.ClickShowPasswordButtonInStudentTile(1);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoPicturePasswordSetupPopupforStudent(), "No internet alert popup not found");
                NavigationCommonMethods.ClickToCloseNoInternetAlertPopupTeacherSupport();
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45547)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_MyLessonNotesIsDefaultTab()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyClassRosterPresentInTeacherMode(), "My classroom not found");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherCanSeeMyLessonNotesPaneInClassRoster(), "teacher cant see students in class roster");
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyTeacherCanSeeStudentsInClassRoster(), "teacher can see students in class roster");
                TeacherSupportCommonMethods.ClickMyClassRosterInTeacherMode();
                AutomationAgent.Wait(4000);
                AutomationAgent.Wait(4000);
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherCanSeeStudentsInClassRoster(), "teacher cant see students in class roster");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(45549)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_CreateAndSaveNoteOverlay()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                //TeacherSupportCommonMethods.ClickMyLessonNotesInTeacherMode();
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();

                if (!TeacherSupportCommonMethods.VerifyTapToAddNotesMesage())
                {
                    TeacherSupportCommonMethods.ClickMyLessonNotesEditInTeacherMode();
                    TeacherSupportCommonMethods.ClickAddNotesOverlayDeleteButton();
                }
                
                TeacherSupportCommonMethods.ClickMyLessonNotesPaneInTeacherMode();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyUIControlsofAddNotesOverlay(), "Add notes overlay not verified");
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyAddNotesOverlaySaveButtonEnabled(), "save button enabled");
                TeacherSupportCommonMethods.AddTextToAddNotesOverlay("test");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyAddNotesOverlaySaveButtonEnabled(), "save button not enabled");
                TeacherSupportCommonMethods.CloseAddNotesOverlayXButton();
                Assert.IsFalse(TeacherSupportCommonMethods.VerifyUIControlsofAddNotesOverlay(), "Add notes overlay still opened");
                
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45550), WorkItem(45551)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_CreateAndSaveNoteOverlayText()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                //TeacherSupportCommonMethods.ClickMyLessonNotesInTeacherMode();
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();

                if (!TeacherSupportCommonMethods.VerifyTapToAddNotesMesage())
                {
                    TeacherSupportCommonMethods.ClickMyLessonNotesEditInTeacherMode();
                    TeacherSupportCommonMethods.ClickAddNotesOverlayDeleteButton();
                }
                
                TeacherSupportCommonMethods.ClickMyLessonNotesPaneInTeacherMode();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyUIControlsofAddNotesOverlay(), "Add notes overlay not verified");
                TeacherSupportCommonMethods.AddTextToAddNotesOverlay("test");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyAddNotesOverlaySaveButtonEnabled(), "save button not enabled");

                TeacherSupportCommonMethods.ClickAddNotesOverlaySaveButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoteAddedInLessonNotePane("test"), "newly aded note not found");

                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45552)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_EditDeleteTextOnMyLessonNotesSection()
            
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                
                if (TeacherSupportCommonMethods.VerifyTapToAddNotesMesage())
                {
                    TeacherSupportCommonMethods.ClickMyLessonNotesPaneInTeacherMode();
                    TeacherSupportCommonMethods.AddTextToAddNotesOverlay("test");
                    TeacherSupportCommonMethods.ClickAddNotesOverlaySaveButton();
                    Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoteAddedInLessonNotePane("test"), "newly added note not found");
                }

                //Edit note
                TeacherSupportCommonMethods.ClickMyLessonNotesEditInTeacherMode();
                TeacherSupportCommonMethods.AddTextToAddNotesOverlay("tested");
               // TeacherSupportCommonMethods.ClickAddNotesOverlaySaveButton();
                TeacherSupportCommonMethods.ClickAddNotesOverlayDoneButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoteAddedInLessonNotePane("tested"), "updated note not found");

                //Delete note
                TeacherSupportCommonMethods.ClickMyLessonNotesEditInTeacherMode();
                TeacherSupportCommonMethods.ClickAddNotesOverlayDeleteButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTapToAddNotesMesage(), "tap to add notes of lesson message not found");
                NavigationCommonMethods.CloseTeacherMode();
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
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(45548)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherGuide_AddNotesForThisLesson()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();

                if (!TeacherSupportCommonMethods.VerifyTapToAddNotesMesage())
                {
                    TeacherSupportCommonMethods.ClickMyLessonNotesEditInTeacherMode();
                    TeacherSupportCommonMethods.ClickAddNotesOverlayDeleteButton();
                }
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTapToAddNotesMesage(), "tap to add notes fo lesson message not found");
                NavigationCommonMethods.CloseTeacherMode();
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
