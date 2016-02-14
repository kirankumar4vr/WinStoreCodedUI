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

namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for NavigationCommonMethods
    /// </summary>
    public static class NavigationCommonMethods
    {
        /// <summary>
        /// Navigate to Teacher / Admin login screen
        /// </summary>
        public static void NavigateToTeacherAdminLogin()
        {
            if (AutomationAgent.VerifyControlExists("LoginView", "TeacherAdminLoginButton"))
            {
                AutomationAgent.Click("LoginView", "TeacherAdminLoginButton");
            }
            else
            {
                NavigateToPreviousOrHomeScreen();
                if (AutomationAgent.VerifyControlExists("LoginView", "TeacherAdminLoginButton"))
                {
                    AutomationAgent.Click("LoginView", "TeacherAdminLoginButton");
                }
                else
                {
                    Logout();
                }
            }
        }

        /// <summary>
        /// Navigates to app home screen by tapping back button(s)
        /// </summary>
        public static void NavigateToPreviousOrHomeScreen(int noOfBack = 5)
        {
            while (noOfBack > 0 && AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                AutomationAgent.Click("LoginView", "NavigationBarGoBackButton");
                noOfBack--;
            }
        }

        /// <summary>
        /// Tap on screen using given x and y coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public static void TapOnScreen(int x1, int y1)
        {
            AutomationAgent.Click(x1, y1);
        }

        /// <summary>
        /// Navigates to Student Login startup screen
        /// </summary>
        /// <param name="login">Login object</param>
        public static void ClickStudentLogin(Login login)
        {
            //AutomationAgent.Click("LoginView", "LoginSelectionButton");
            //AutomationAgent.Click("LoginView", "StudentLoginStartup");

            AutomationAgent.Click("LoginView", "StudentLoginHomePage");
            AutomationAgent.Click("LoginView", "StudentLoginStartupButton");
        }

        /// <summary>
        /// Sleeps for 5 ms.
        /// </summary>
        public static void Sleep(int time = 5000)
        {
            System.Threading.Thread.Sleep(time);
        }

        public static void LaunchAppLogin()
        {
            AutomationAgent.LaunchApp();
            if (!AutomationAgent.VerifyControlExists("LoginView", "TeacherAdminLoginButton"))
            {
                if (AutomationAgent.VerifyControlExists("LoginView", "SystemTray"))
                    Logout();
            }
        }


        /// <summary>
        /// Logs into the app using Teacher / Admin screen
        /// </summary>
        /// <param name="login">Login object</param>
        public static void LoginUsingTeacherAdminWaitingForSystemTray(Login login)
        {
            AutomationAgent.LaunchApp();


            AutomationAgent.Wait();
            if (AutomationAgent.VerifyControlExists("LoginView", "SystemTray"))
            {   //Logout();
                OpenOrCloseSystemTray();

                if (!VerifyLoggedInUserNameInSystemTray(login.PersonName))
                {
                    OpenOrCloseSystemTray();
                    Logout();
                    NavigationCommonMethods.NavigateToTeacherAdminLogin();
                    AutomationAgent.SetText("LoginView", "UserNameTextboxOnTeacherAdminScreen", login.UserName);
                    AutomationAgent.SetText("LoginView", "PasswordTextboxOnTeacherAdminScreen", login.Password);
                    AutomationAgent.Click("LoginView", "LoginButtonOnTeacherAdminScreen");
                    AutomationAgent.WaitForControlExists("LoginView", "SystemTray", 80000);
                }
                else
                {
                    OpenOrCloseSystemTray();
                  //  NavigateToUnitLibrary();
                }
            }

            else
            {
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                AutomationAgent.SetText("LoginView", "UserNameTextboxOnTeacherAdminScreen", login.UserName);
                AutomationAgent.SetText("LoginView", "PasswordTextboxOnTeacherAdminScreen", login.Password);
                AutomationAgent.Click("LoginView", "LoginButtonOnTeacherAdminScreen");
                AutomationAgent.WaitForControlExists("LoginView", "SystemTray", 80000);
            }
            //}
        }

        private static bool VerifyLoggedInUserNameInSystemTray(string UserName)
        {
            if (AutomationAgent.VerifyControlExists("SystemTrayView", "SystemTrayUserNameTextBlock"))
            {

                string UserNameInSystemTray = AutomationAgent.GetControlText("SystemTrayView", "SystemTrayUserNameTextBlock");
                return UserNameInSystemTray.Equals(UserName);
            }

            else
                return false;
        }

        /// <summary>
        /// Logs out of the application
        /// </summary>
        public static void Logout()
        {
            AutomationAgent.Click("LoginView", "SystemTray");
            AutomationAgent.Click("LoginView", "LogoutButton");
            NavigationCommonMethods.Sleep();
            AutomationAgent.Click("LoginView", "LogoutConfirm");
        }

        /// <summary>
        /// Navigates to unit library
        /// </summary>
        /// <param name="noOfBack">no of times we need to click back button</param>
        public static void NavigateToUnitLibrary(int noOfBack = 5)
        {
            while (noOfBack > 0 && !AutomationAgent.VerifyControlExists("LoginView", "SystemTray"))
            {
                AutomationAgent.Click("LoginView", "NavigationBarGoBackButton");
                noOfBack--;
            }
            AutomationAgent.Click("LoginView", "SystemTray");
            AutomationAgent.Click("SystemTrayView", "UnitSelectionSelectedButton");
        }

        /// <summary>
        /// Navigates to Book Builder
        /// </summary>
        /// <param name="noOfBack">no of times we need to click back button</param>
        public static void NavigateToBookBuilder(int noOfBack = 5)
        {
            while (noOfBack > 0 && !AutomationAgent.VerifyControlExists("LoginView", "SystemTray"))
            {
                AutomationAgent.Click("LoginView", "NavigationBarGoBackButton");
                noOfBack--;
            }
            AutomationAgent.Click("LoginView", "SystemTray");
            AutomationAgent.Click("BookBuilderView", "BookBuilderMenu");
        }

        /// <summary>
        /// Opens system tray
        /// </summary>
        public static void OpenOrCloseSystemTray()
        {
            AutomationAgent.Click("LoginView", "SystemTray");
        }

        public static void NavigateToTeacherSupport()
        {
            OpenOrCloseSystemTray();
            AutomationAgent.Click("SystemTrayView", "TeacherSupportButton");
            AutomationAgent.Wait(500);
        }

        public static void ClickGrowYourSkills()
        {
            AutomationAgent.Click("TeacherSupportView", "GrowYourSkillsBtn");
        }

        public static void ClickPrepareYoyrLessons()
        {
            AutomationAgent.Click("TeacherSupportView", "PrepareYourLessonBtn");
        }

        public static void ClickGetHelp()
        {
            AutomationAgent.Click("TeacherSupportView", "GetHelpBtn");
        }


        public static bool VerifyNoInternetAlertPopupTeacherSupport()
        {
            return (AutomationAgent.VerifyControlExists("TeacherSupportView", "NoInternetConnectionPopupMessageHeader", 500) && AutomationAgent.VerifyControlExists("TeacherSupportView", "NoInternetConnectionPopupMessageBody", 500));
        }

        public static void ClickToCloseNoInternetAlertPopupTeacherSupport()
        {
            AutomationAgent.Click("TeacherSupportView", "NoInternetConnectionPopupClose");
        }

        /// <summary>
        /// Verifies if tray menu is available (system tray is closed)
        /// </summary>
        /// <returns>true if tray is closed</returns>
        public static bool VerifySystemTrayState()
        {
            return AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderMenu");
        }

        /// <summary>
        /// Verifies log out pop up components and verifies its behavior on cancel 
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all elements exist</returns>
        public static bool VerifyLogoutPopupAndVerifyBehaviorOnCancelLogout(out string assertFailureMessage)
        {
            bool exist = true;
            assertFailureMessage = string.Empty;
            AutomationAgent.Click("LoginView", "SystemTray");
            AutomationAgent.Click("LoginView", "LogoutButton");
            if (!AutomationAgent.VerifyChildByName("LoginView", "Popup", "Log Out"))
            {
                assertFailureMessage += "Logout popup doesn't exist. ";
                exist = false;
            }
            AutomationAgent.Click("LoginView", "LogoutCancel");
            AutomationAgent.Click("LoginView", "SystemTray");
            
            if(!(LoginCommonMethods.VerifyELAGradeAppears()))
            {
                assertFailureMessage += "Unit selection screen doesn't appear. ";
                exist = false;
            }
            return exist;
        }

        public static void NavigateToMathUnit(int UnitNo)
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("GradeSelectionView", "GradeSelectionMathButton", WaitTime.DefaultWaitTime, UnitNo.ToString());
        }

        public static bool VerifyUnitHomeScreen()
        {
            return (AutomationAgent.VerifyControlExists("GradeSelectionView", "UnitHomeScreenTodayBtn") &&
                AutomationAgent.VerifyControlExists("GradeSelectionView", "UnitHomeScreenForegroundImage"));
        }

        public static void NavigateToMediaLibrary()
        {
            AutomationAgent.Click("NavigationBarView", "NavigationBarMediaLibraryBtn");
            AutomationAgent.Wait(500);
        }

        public static bool VerifyMediaLibraryScreen()
        {
            return AutomationAgent.VerifyControlExists("MediaLibraryView", "MediaLibraryGridModel", WaitTime.DefaultWaitTime, "1");
        }

        public static void NavigateToNotebook()
        {
            AutomationAgent.Click("NavigationBarView", "NavigationBarNotebookBtn");
            AutomationAgent.Wait(500);
        }

        public static bool VerifyNotebookScreen()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageImage");
        }

        public static bool VerifyNavigationBarButtons()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "SystemTray") &&
                AutomationAgent.VerifyControlExists("NavigationBarView", "NavigationBarHomeBtn") &&
                AutomationAgent.VerifyControlExists("NavigationBarView", "NavigationBarMediaLibraryBtn") &&
                AutomationAgent.VerifyControlExists("NavigationBarView", "NavigationBarNotebookBtn") &&
                AutomationAgent.VerifyControlExists("NavigationBarView", "NavigationBarMTEBtn"));


        }

        public static void NavigateToHome()
        {
            AutomationAgent.Click("NavigationBarView", "NavigationBarHomeBtn");
            AutomationAgent.Wait(500);
        }

        public static bool VerifyHomeButtonHighlighted()
        {
            return AutomationAgent.VerifyXamlToggleButtonPressed("NavigationBarView", "NavigationBarHomeBtn");
        }

        public static bool VerifySytemTrayContentsForStudent()
        {

              bool b = AutomationAgent.VerifyControlExists("SystemTrayView", "SystemTrayUserNameTextBlock");
                bool m =AutomationAgent.VerifyControlExists("SystemTrayView", "BookBuilderButton");
            bool v =AutomationAgent.VerifyControlExists("SystemTrayView", "InboxButton") ;
             bool d = AutomationAgent.VerifyControlExists("SystemTrayView", "UnitSelectionSelectedButton") ;
            bool c1 = AutomationAgent.VerifyControlExists("SystemTrayView", "SettingsButton") ;
            bool c =AutomationAgent.VerifyControlExists("SystemTrayView", "LogoutButton");



            if (
             AutomationAgent.VerifyControlExists("SystemTrayView", "SystemTrayUserNameTextBlock") &&
                AutomationAgent.VerifyControlExists("SystemTrayView", "BookBuilderButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "InboxButton") &&
             AutomationAgent.VerifyControlExists("SystemTrayView", "UnitSelectionSelectedButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "SettingsButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "LogoutButton")
            )
            {
                return (VerifyUserNameTopAligned() && VerifyLogoutButtonBottomAligned());
            }

            else
                return false;

        }

        public static bool VerifyUserNameTopAligned()
        {
            int UserNameY = AutomationAgent.GetControlPositionY("SystemTrayView", "SystemTrayUserNameTextBlock");

            if (UserNameY < 50)
                return true;

            else
                return false;
        }

        public static bool VerifyLogoutButtonBottomAligned()
        {
            int ScreenHeight = AutomationAgent.GetAppWindowHeight();
            int LogoutY = AutomationAgent.GetControlPositionY("SystemTrayView", "LogoutButton");

            if ((ScreenHeight - LogoutY) < 100)
                return true;

            else
                return false;
        }

        public static bool VerifySytemTrayContentsForTeacher()
        {
            if (
             AutomationAgent.VerifyControlExists("SystemTrayView", "SystemTrayUserNameTextBlock") &&
                AutomationAgent.VerifyControlExists("SystemTrayView", "BookBuilderButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "InboxButton") &&
             AutomationAgent.VerifyControlExists("SystemTrayView", "UnitSelectionSelectedButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "TeacherSupportButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "SettingsButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsReportButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsManagerButton") &&
            AutomationAgent.VerifyControlExists("SystemTrayView", "LogoutButton")
            )
            {
                return (VerifyUserNameTopAligned() && VerifyLogoutButtonBottomAligned());
            }

            else
                return false;
        }

        public static bool VerifyTeacherSupportButton()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "TeacherSupportButton");
        }

        public static bool VerifyUnitSelectionHasSelectedState()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "UnitSelectionSelectedButton");
        }

        public static bool VerifySettingsButtonHasSelectedState()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "SettingsSelectedButton");
        }

        public static void NavigateToSettings()
        {
            OpenOrCloseSystemTray();
            AutomationAgent.Click("SystemTrayView", "SettingsButton");
            AutomationAgent.Wait(500);
        }

        public static void NavigateBackFromConfigSettings()
        {
           // AutomationAgent.Click("SystemTrayView", "BackButtonConfigSettings");
        }

        public static bool VerifyTeacherSupportButtonHasSelectedState()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "TeacherSupportSelectedButton");
        }

        public static bool VerifyUserImageInSystemTray()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "UserImageInSystemTray");
        }

        public static void NavigateToELAUnit(int UnitNo)
        {

            AutomationAgent.Wait(1000);
            if(UnitNo>4)
            {
                UnitSelectionCommonMethods.SwipeElaGradeToGrade1(10);
            }

            try
            {
                AutomationAgent.Click("UnitSelectionView", "GradeSelectionELAButton", WaitTime.DefaultWaitTime, (UnitNo+1).ToString());
            }
            catch(Exception ex)
            {

                //AutomationAgent.Click(550, 380);
                AutomationAgent.Click(593, 446);
            }
            AutomationAgent.Wait(500);
        }

        public static void ClickUnitHomeScreenTodayBtn()
        {
            AutomationAgent.Wait(500);
            AutomationAgent.Click("GradeSelectionView", "UnitHomeScreenTodayBtn");

            while(!UnitSelectionCommonMethods.VerfiyLessonNumberDisplayed(1))
            {
                UnitSelectionCommonMethods.ClickTodaysLessonButtonPrevious();
            }


        }

        public static void SwipeUnitsLeft()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Slide(1016, 709, 615, 704);
        }

        public static void SwipeUnitsRight()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Slide(318, 429, 1027, 393);
        }

        public static bool VerifyBookLogIcon()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "BookLogThumbnail", WaitTime.DefaultWaitTime, "11");
        }

        public static bool VerifyVideoThumbnailinELA()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodayLessonVideoThumbnail", WaitTime.DefaultWaitTime, "8");
        }

        public static void ClickVideoThumbnailinELA()
        {
            AutomationAgent.Click("LessonsViewInEla", "TodayLessonVideoThumbnail", WaitTime.DefaultWaitTime, "8");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyImageThumbnailinELA()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodayLessonImageThumbnail", WaitTime.DefaultWaitTime, "2");
            
        }

        public static void ClickImageThumbnailinELA()
        {
            AutomationAgent.Click("LessonsViewInEla", "TodayLessonImageThumbnail", WaitTime.DefaultWaitTime, "2");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyTodaysLessonShelf()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodaysViewScrollViewer");
        }

        public static int GetXPosofImageThumbnail()
        {
            return AutomationAgent.GetControlPositionX("LessonsViewInEla", "TodayLessonImageThumbnail", WaitTime.DefaultWaitTime, "2");
        }

        public static void ClickBookLogIcon()
        {
            AutomationAgent.Click("LessonsViewInEla", "BookLogThumbnail", WaitTime.DefaultWaitTime, "11");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyDesignLayoutOfBookLog()
        {
            return (AutomationAgent.VerifyControlExists("BookLogView", "BookLogAddButton") &&
                    AutomationAgent.VerifyControlExists("BookLogView", "BookLogUnitHeader") &&
                    AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"));
        }

        public static int GetXPosOfBookLogThumbnail()
        {
            AutomationAgent.Wait(500);
            return AutomationAgent.GetControlPositionX("LessonsViewInEla", "BookLogThumbnail", WaitTime.DefaultWaitTime, "11");
        }



        public static void SwipeScreenUp()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Slide(730, 260, 730, 650);
        }

        public static void SwipeScreenDown()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Slide(730, 650, 730, 250);
        }

        public static void ClickBackButtoneReader()
        {
            //if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(2000);
                eReaderCommonMethods.TapOnEReaderScreen();
            
            AutomationAgent.Click("EReaderView", "GoBackButtonEReader");
        }
        public static bool VerifyBackButtonInImage()
        {
            AutomationAgent.Wait(2000);
            eReaderCommonMethods.TapOnEReaderScreen();
            if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
                return false;

            int BackButtonX = AutomationAgent.GetControlPositionX("EReaderView", "GoBackButtonEReader");
            int BackButtonY = AutomationAgent.GetControlPositionY("EReaderView", "GoBackButtonEReader");

            if (BackButtonX < 100 && BackButtonY < 100)
                return true;

            else
                return false;
        }

        public static bool VerifyInteractiveThumbnailinELA()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodayLessonInteractiveThumbnail", WaitTime.DefaultWaitTime, "5");
        }

        public static void ClickInteractiveThumbnailinELA()
        {
            AutomationAgent.Click("LessonsViewInEla", "TodayLessonInteractiveThumbnail", WaitTime.DefaultWaitTime, "5");
            AutomationAgent.Wait();
        }

        public static bool VerifyCancelContentDownloadingButton()
        {
            return AutomationAgent.VerifyControlExists("UnitSelectionView", "GradesSelectionCancelButton",10000);
        }

        public static void ClickCancelContentDownloadingButton()
        {
            AutomationAgent.Click("UnitSelectionView", "GradesSelectionCancelButton");
        }



        public static void ClickTeacherModeButton()
        {
            AutomationAgent.Click("NavigationBarView", "NavigationBarTeacherModeBtn");
        }

        public static void ClickUnitOverviewMenuItem()
        {
            AutomationAgent.Click("TeacherModeView", "UnitOverviewMenuItem");
        }

        public static bool VerifyTeacherModeOpenUnitOverview()
        {
            AutomationAgent.Wait(1000);

            if(AutomationAgent.VerifyControlExists("TeacherModeView", "UnitOverviewTeacherMode"))
            {
            int posx = AutomationAgent.GetControlPositionX("TeacherModeView", "UnitOverviewTeacherMode");
            return posx > 0;
            }

            else
            return false;
        }

        public static void CloseTeacherMode()
        {
            int screenwidth = AutomationAgent.GetAppWindowWidth();
            AutomationAgent.Wait(500);
            AutomationAgent.Click(screenwidth - 20, 35);
        }

        public static bool VerifyNavigationBarButtonsEquallySpaced()
        {
            int widthHomeBtn  = AutomationAgent.GetControlWidth("NavigationBarView", "NavigationBarHomeBtn");
            int widthMediaLibBtn = AutomationAgent.GetControlWidth("NavigationBarView", "NavigationBarMediaLibraryBtn") ;
            int widthNotebookBtn =AutomationAgent.GetControlWidth("NavigationBarView", "NavigationBarNotebookBtn") ;
            int widthMTEBtn = AutomationAgent.GetControlWidth("NavigationBarView", "NavigationBarMTEBtn");

            return (widthHomeBtn == widthMediaLibBtn && widthMTEBtn == widthNotebookBtn && widthHomeBtn == widthNotebookBtn);
        }

        public static bool VerifyEReaderThumbnailinELA(string EreaderThumbnail = "3")
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodayLessonEReaderThumbnail", WaitTime.DefaultWaitTime, EreaderThumbnail);
       
        }

        public static void ClickEReaderThumbnailinELA(string EreaderThumbnail = "3")
        {
            AutomationAgent.Click("LessonsViewInEla", "TodayLessonEReaderThumbnail", WaitTime.DefaultWaitTime, EreaderThumbnail);
            AutomationAgent.Wait(1000);

            eReaderCommonMethods.NavigateToFirstPageEReader();
        }
       

        public static bool VerifyTeacherModeOpenLessonOverview()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "LessonOverviewTeacherMode");
        }

        public static bool VerifyTeacherModeOpenLessonGuide()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "LessonGuideTeacherMode");
        }

        public static void ClickLessonOverviewMenuItem()
        {
            AutomationAgent.Click("TeacherModeView", "LessonOverviewMenuItem");
        }

        public static void ClickLessonGuideMenuItem()
        {
            AutomationAgent.Click("TeacherModeView", "LessonGuideMenuItem");
        }

        public static bool VerifySytemTrayContentsTeacherSupportButton()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "TeacherSupportButton");
        }

        public static bool VerifySystemTrayPresent()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "SystemTray");
        }

        public static bool VerifyColdWriteIcon()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "ColdWriteThumbnail", WaitTime.DefaultWaitTime, "10");
        }

        public static void ClickColdWriteIcon()
        {
            AutomationAgent.Click("LessonsViewInEla", "ColdWriteThumbnail", WaitTime.DefaultWaitTime, "10");
        }

        public static void NavigateInboxKGInSystemTray()
        {
            AutomationAgent.Click("SystemTrayView", "InboxButton");
            AutomationAgent.Click("SystemTrayView", "InboxSubMenuKindergartenButton");
        }

        public static void ClickAssessmentReportsInSystemTray()
        {
            AutomationAgent.Click("SystemTrayView", "AssessmentsReportButton");
        }

        public static void ClickAssessmentManagerSystemTray()
        {
            AutomationAgent.Wait(500);
            AutomationAgent.Click("SystemTrayView", "AssessmentsManagerButton");
        }

        public static bool VerifyInboxSubMenusInSystemTray()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "InboxSubMenuKindergartenButton") &&
                AutomationAgent.VerifyControlExists("SystemTrayView", "InboxSubMenuGrade1Button");
        }

        public static bool VerifyAssessmentManagerSubMenusInSystemTray()
        {

            //return AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsManagerSubMenuKindergartenButton") &&
            //     AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsManagerSubMenuGrade1Button");
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentManagerSectionButton");

            //return AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsManagerSubMenuKindergartenButton") ||
            //     AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsManagerSubMenuGrade1Button");

        }

        public static bool VerifyAssessmentReportsSubMenusInSystemTray()
        {

            return   AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsReportSubMenuGrade1Button");
           

            //return AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsReportSubMenuKindergartenButton") ||
            //     AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsReportSubMenuGrade1Button");

        }

        public static bool VerifyMTEOrCCNoInternetMessage()
        {
            AutomationAgent.Click("NavigationBarView", "NavigationBarMTEBtn");
            return LoginCommonMethods.VerifyNoInternetAlertPopup();
        }

        public static bool VerifySystemTrayMenu(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("SystemTrayView", "BookBuilderButton"))
            {
                exists = false;
                assertFailureMessage += "Book Builder Button is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SystemTrayView", "InboxButton"))
            {
                exists = false;
                assertFailureMessage += "Inbox Button is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SystemTrayView", "UnitSelectionSelectedButton"))
            {
                exists = false;
                assertFailureMessage += "Unit Selection Button is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SystemTrayView", "SettingsButton"))
            {
                exists = false;
                assertFailureMessage += "Settings Button is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SystemTrayView", "LogoutButton"))
            {
                exists = false;
                assertFailureMessage += "Logout Button is not available. ";
            }
            return exists;
        }

        public static bool VerifyBackPackIcon()
        {
            return AutomationAgent.VerifyControlExists("BackPackView", "BackPackIcon");
        }

        public static void ClickBackPackIcon()
        {
            AutomationAgent.Click("BackPackView", "BackPackIcon");
        }

        public static bool VerifyUpdateContentsButtonInSettingsPage()
        {
            return AutomationAgent.VerifyControlExists("SettingsView", "UpdateContentButton");
        }

        public static bool VerifySettingsPage()
        {
            return AutomationAgent.VerifyControlExists("SettingsView", "SettingsPage");
        }

        public static void AddDownloadNewELAUnit(int UnitNo)
        {
            AutomationAgent.Click("UnitSelectionView", "GradeSelectionELAButton", WaitTime.DefaultWaitTime, UnitNo.ToString());
        }

        public static bool VerifyAssessmentManagerMenuInSystemTray()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsManagerButton");
        }

        public static bool VerifyAssessmentReportMenuInSystemTray()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayView", "AssessmentsReportButton");
        }

        public static bool ResizeAppAndVerifyMessage(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            AutomationAgent.MouseMoveToAPosition(0, 200);
            AutomationAgent.LongClick(0, 20);
            TapOnScreen(10, 50);
            if (!AutomationAgent.VerifyControlExists("AppView", "HelpMessage"))
            {
                exists = false;
                assertFailureMessage += "Help message is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("AppView", "ChildImage"))
            {
                exists = false;
                assertFailureMessage += "Child Image is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("AppView", "HelpMenu"))
            {
                exists = false;
                assertFailureMessage += "Help Menu is not available. ";
            }
            return exists;
        }

        public static bool VerifySettingsMenuInSystemTray()
        {
            OpenOrCloseSystemTray();
            return AutomationAgent.VerifyControlExists("SystemTrayView", "SettingsButton");
        }

        public static bool VerifySettingPageContentBeforeContentDownload(out string assertFailureMessage)
        {
            assertFailureMessage = String.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("SettingsView", "SettingsPage"))
            {
                exists = false;
                assertFailureMessage += "Settings Page is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SettingsView", "AppVersion"))
            {
                exists = false;
                assertFailureMessage += "App Version is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SettingsView", "ConfigVersion"))
            {
                exists = false;
                assertFailureMessage += "Config Version is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SettingsView", "ConfigServer"))
            {
                exists = false;
                assertFailureMessage += "Config Server is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("SettingsView", "NoContentMessage"))
            {
                exists = false;
                assertFailureMessage += "NoContentMessage is not available. ";
            }
            return exists;
        }

        public static bool VerifySettingPageContentAfterContentDownload(out string assertFailureMessage)
        {
            assertFailureMessage = String.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("SettingsView", "ContentDownloadedMessage"))
            {
                exists = false;
                assertFailureMessage += "Content Downloaded Message is not available. ";
            }
            return exists;
        }

        public static void ClickInboxInSystemTray()
        {
            AutomationAgent.Click("SystemTrayView", "InboxButton");
        }
    }
}