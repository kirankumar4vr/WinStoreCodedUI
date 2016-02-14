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


namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class NavigationTests
    {
        public NavigationTests()
        {
        }

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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(20768)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTappingOutsideCloseSystemTray()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.TapOnScreen(400, 200);
                Assert.IsFalse(NavigationCommonMethods.VerifySystemTrayState(), "System tray is not closed");
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
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(20763)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ValidateLogoutButton()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToUnitLibrary();
                string assertFailureMessage;
                Assert.IsTrue(NavigationCommonMethods.VerifyLogoutPopupAndVerifyBehaviorOnCancelLogout(out assertFailureMessage), assertFailureMessage);
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(24248)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WelcomeLandingPagePrivacyStatement()
        {
            try
            {
                AutomationAgent.LaunchApp();

                if (NavigationCommonMethods.VerifySystemTrayPresent())
                        NavigationCommonMethods.Logout();
                
                Assert.IsTrue(LoginCommonMethods.VerifyTermsOfUsePresent(), "Terms of Use not found");
                Assert.IsTrue(LoginCommonMethods.VerifyPrivacyStatementPresent(), "Privacy policy not found");
                LoginCommonMethods.ClickPrivacyStatement();
                Assert.IsTrue(LoginCommonMethods.VerifyPrivacyStatementPopupPresent(), "Privacy statement not found");
                LoginCommonMethods.ClickToClosePrivacyStatementPopup();
                Assert.IsFalse(LoginCommonMethods.VerifyPrivacyStatementPopupPresent(), "Terms of Use not found");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(27195)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BackButtonNavigationStackManagementTappingBackButtonAfterWrongPicPassword()
        {
            try
            {
                AutomationAgent.LaunchApp();
                if (NavigationCommonMethods.VerifySystemTrayPresent())
                    NavigationCommonMethods.Logout();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(LoginCommonMethods.VerifyLogInScreenForAlreadySetupStudent(), "Log in screen not available");
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

        
       // [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(23219)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherFacingStyledOfflineAlertMessage()
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
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
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
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(20366)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTappingSystemTrayOpens()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayState(), "System tray is not opened");
                NavigationCommonMethods.TapOnScreen(400, 200);
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
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(20369)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarOnlyActiveTappableWhenTrayClosed()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayState(), "System tray is not opened");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsFalse(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
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
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(20764)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarSystemtrayTapSystemTrayButton()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayState(), "System tray is not opened");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayState(), "System tray is not opened");
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
        [TestCategory("NavigationTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(22795)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarFullGlobalNavigationDisplayForStudent()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationBarButtons(), "Navigation bar button cant verified");

                NavigationCommonMethods.NavigateToHome();
                Assert.IsTrue(NavigationCommonMethods.VerifyHomeButtonHighlighted(), "Home button not highlighted");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit Home screen not found");
                
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");

                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "Notebook screen not found");
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
        [TestCategory("NavigationTests")]
        [Priority(3)]
        [WorkItem(43610), TestCategory("K1SmokeTests")]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SystemTrayUIUXUpdates()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySytemTrayContentsForStudent(), "System tray contents for student not verfified");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySytemTrayContentsForTeacher(), "System tray contents for student not verfified");
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
        [TestCategory("NavigationTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(20765)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarValidationofContentsSystemTray_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyUserImageInSystemTray(), "User Image in system tray not found");
                Assert.IsTrue(NavigationCommonMethods.VerifySytemTrayContentsForTeacher(), "System tray contents for teacher not verified");
                
                
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitSelectionHasSelectedState(), "Teacher support button for student is available");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateToSettings();
                NavigationCommonMethods.NavigateBackFromConfigSettings();
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifySettingsButtonHasSelectedState(), "Settings button is having selected state");

                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateToTeacherSupport();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherSupportButtonHasSelectedState(), "Settings button is having selected state");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(20766)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarValidationofContentsSystemTray_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySytemTrayContentsForStudent(), "System tray contents for student not verfified");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherSupportButton(), "Teacher support button for student is available");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitSelectionHasSelectedState(), "Teacher support button for student is available");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateToSettings();
                NavigationCommonMethods.NavigateBackFromConfigSettings();
                
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifySettingsButtonHasSelectedState(), "Settings button is having selected state");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(20767)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarVerificationStateButtonDisplayingUnderSystemTray_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifySytemTrayContentsForTeacher(), "System tray contents for teacher not verfified");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitSelectionHasSelectedState(), "Teacher support button for student is available");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateToSettings();
                NavigationCommonMethods.NavigateBackFromConfigSettings();
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifySettingsButtonHasSelectedState(), "Settings button is having selected state");

                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateToTeacherSupport();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherSupportButtonHasSelectedState(), "Settings button is having selected state");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(22025)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TodayShelfImageDisplayAndValidationofBackButtononImageViewer()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyImageThumbnailinELA(), "image thumbnail not found");
                int posXBefore = NavigationCommonMethods.GetXPosofImageThumbnail();
                NavigationCommonMethods.ClickImageThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyImageHasBackButton(), "back button not available for image player");
                UnitSelectionCommonMethods.ClickImageBackButton();
                int posXAfter = NavigationCommonMethods.GetXPosofImageThumbnail();
                Assert.IsTrue(posXAfter == posXBefore, "scroll position not remembered");
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
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(20262)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarValidationofHomeButtonWhentheUserIsInNotebookScreen()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "Notebook screen not found");
                NavigationCommonMethods.NavigateToHome();
                Assert.IsTrue(NavigationCommonMethods.VerifyHomeButtonHighlighted(), "Home button not highlighted");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit Home screen not found");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(22796), WorkItem(22797)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigationBarFullGlobalNavigationDisplayForTeacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationBarButtons(), "Navigation bar button cant verified");

                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationBarButtonsEquallySpaced(), "Navigation bar button are not equally  spaced");

                NavigationCommonMethods.NavigateToHome();
                Assert.IsTrue(NavigationCommonMethods.VerifyHomeButtonHighlighted(), "Home button not highlighted");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit Home screen not found");

                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationBarButtons(), "Navigation bar button cant verified");

                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationBarButtons(), "Navigation bar button cant verified");

                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "Notebook screen not found");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(1)]
        [WorkItem(20353)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Navigationbar_ValidationofHomeButtonWhenTeacherModeisActive()
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

                NavigationCommonMethods.NavigateToHome();
                Assert.IsTrue(NavigationCommonMethods.VerifyHomeButtonHighlighted(), "Home button not highlighted");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit Home screen not found");

                NavigationCommonMethods.CloseTeacherMode();
                //    NavigationCommonMethods.Logout();
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
        [TestCategory("NavigationTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(52065), WorkItem(52068), WorkItem(52067), WorkItem(52066), WorkItem(52070)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SystemTrayMenuUpdate_TeacherSystemTray()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyUserImageInSystemTray(), "User Image in system tray not found");
                Assert.IsTrue(NavigationCommonMethods.VerifySytemTrayContentsForTeacher(), "System tray contents for teacher not verified");

                //Sub Menus
                NavigationCommonMethods.ClickInboxInSystemTray();
                
                Assert.IsTrue(NavigationCommonMethods.VerifyInboxSubMenusInSystemTray(), "inbox submenu not verified");

                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyAssessmentManagerSubMenusInSystemTray(), "assessment manager submenu not verified");
                //TC52070
                Assert.IsFalse(NavigationCommonMethods.VerifyInboxSubMenusInSystemTray(), "inbox submenu still open");

                NavigationCommonMethods.ClickAssessmentReportsInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyAssessmentReportsSubMenusInSystemTray(), "assessment report submenu not verified");


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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(23963), WorkItem(26202)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyGenericErrorMessageOnCCAndMTE()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyMTEOrCCNoInternetMessage(), "No internet popup is not available");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                NavigationCommonMethods.NavigateToUnitLibrary();
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyMTEOrCCNoInternetMessage(), "No internet popup is not available");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(52069)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifySystemTrayMenu()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                string assertFailureMessage;
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayMenu(out assertFailureMessage), assertFailureMessage);
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(46618)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DeltaContentUpdates_DisplayofUpdateContentButtonSettingsPage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found-Unit not downloaded");
                NavigationCommonMethods.NavigateToSettings();
                Assert.IsTrue(NavigationCommonMethods.VerifySettingsPage(), "User not navigated to settings page");
                Assert.IsTrue(NavigationCommonMethods.VerifyUpdateContentsButtonInSettingsPage(), "Update contents button not found in settings page");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(46619)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DeltaContentUpdates_TappingUpdateContentButtonCausesAppToQueueUpdatesToAnyInstalledUnits()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToSettings();
                Assert.IsTrue(NavigationCommonMethods.VerifySettingsPage(), "User not navigated to settings page");
                Assert.IsTrue(NavigationCommonMethods.VerifyUpdateContentsButtonInSettingsPage(), "Update contents button not found in settings page");
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(44537)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDisabledSnappedView()
        {
            try
            {
                AutomationAgent.LaunchApp();
                string assertFailureMessage;
                Assert.IsTrue(NavigationCommonMethods.ResizeAppAndVerifyMessage(out assertFailureMessage), assertFailureMessage);
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
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(24260)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifySystemTraySettingContent()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(NavigationCommonMethods.VerifySettingsMenuInSystemTray(), "Settings button doesn't exist in System tray ");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateToSettings();
                string assertFailureMessage;
                Assert.IsTrue(NavigationCommonMethods.VerifySettingPageContentBeforeContentDownload(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToUnitLibrary();
                NavigationCommonMethods.NavigateToMathUnit(0); 
                while (NavigationCommonMethods.VerifyCancelContentDownloadingButton())
                {
                    AutomationAgent.Wait();
                }
                NavigationCommonMethods.NavigateToSettings();
                Assert.IsTrue(NavigationCommonMethods.VerifySettingPageContentAfterContentDownload(out assertFailureMessage), assertFailureMessage);
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
