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
    public static class NavigationCommonMethods
    {
        public static void LoginApp(Login login,int SystemTrayWaitTime = 40000)
        {
            AutomationAgent.LaunchApp();

            //if (AutomationAgent.VerifyControlExists("LoginView", "CrashReportsNoButton", 5000))
            //{
            //    AutomationAgent.Click("LoginView", "CrashReportsNoButton");
            //}
             AutomationAgent.SetText("LoginView", "UserNameTextbox", login.UserName);
            AutomationAgent.SetText("LoginView", "passwordTextbox", login.Password);
           
            //Lets see if it achieves n\w connectivoty by waiting
            AutomationAgent.Wait();
            AutomationAgent.Wait();
            
            AutomationAgent.Click("LoginView", "LoginButton");
            AutomationAgent.WaitForControlExists("TopMenuView", "SystemTrayButton", SystemTrayWaitTime);
            if (!AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton"))
            {
                TapToCloseDoneXButtonIfAvailableByChance();
                if (AutomationAgent.VerifyControlExists("DashboardView", "CloseButton", 1000))
                {
                    AutomationAgent.Click("DashboardView", "CloseButton");
                }
            }
        }

        private static void TapToCloseDoneXButtonIfAvailableByChance()
        {
            AutomationAgent.Click(25, 25);
        }

        public static void Logout()
        {

            if (AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton"))
            {
                AutomationAgent.Click("TopMenuView", "SystemTrayButton");

                if (AutomationAgent.VerifyControlExists("SystemTrayMenuView", "LogoutButton"))
                    AutomationAgent.Click("SystemTrayMenuView", "LogoutButton");

                else
                {
                    AutomationAgent.Click("TopMenuView", "SystemTrayButton");
                    AutomationAgent.Click("SystemTrayMenuView", "LogoutButton");
                }

                AutomationAgent.WaitForControlExists("LoginView", "UserNameTextbox", 5000);
            }
        }



        public static void NavigateToTaskfromSytemTrayMenu(TaskInfo taskInfo)
        {
            if (taskInfo.SubjectName == "ELA")
            {
                NavigateELATaskfromSytemTrayMenu(taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
            }
            else if (taskInfo.SubjectName == "Math")
            {
                NavigateMathTaskfromSytemTrayMenu(taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
            }
        }



        public static void NavigateToELA()
        {
            //TODO - Uncomment following Condition
            //if (!VerifyELAPage(1000))
            //{
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("TopMenuView", "SystemTrayButton");
            AutomationAgent.Wait(1000);
            if (AutomationAgent.VerifyControlExists("TopAppToolBarView", "ElaUnitLibraryButton"))
            {
                AutomationAgent.Wait(500);
                AutomationAgent.Click("TopAppToolBarView", "ElaUnitLibraryButton");
            }

            else
            {
                AutomationAgent.Click("TopMenuView", "SystemTrayButton");
                AutomationAgent.Click("TopAppToolBarView", "ElaUnitLibraryButton");
            }
            
            //}
            //TODO - Remove below Tap Method
            TapToCloseSystemTrayIfOpenByChance();

        }


        /// <summary>
        /// TODO - Remove this Method - Temp fix for regression
        /// </summary>
        public static void TapToCloseSystemTrayIfOpenByChance()
        {
            AutomationAgent.Click(10, 150);
        }
        /// <summary>
        /// To NavigateTo MyDashboard
        /// </summary>
        public static void NavigateToMyDashboard()
        {
            //if (!DashboardCommonMethods.VerifyUserIsOnDashBoard())
            //{

            //    if (!VerifySystemTrayButtonAvailable())
            //    {
            //        if (AutomationAgent.VerifyControlExists("DashboardView", "CloseButton", 100))
            //        {
            //            AutomationAgent.Click("DashboardView", "CloseButton");
            //        }
            //    }

                AutomationAgent.Click("TopMenuView", "SystemTrayButton");
                AutomationAgent.Click("TopAppToolBarView", "MyDashboardButton");
                TapToCloseSystemTrayIfOpenByChance();
            
            }

        public static void NavigateToMath()
        {
            //TODO - Uncomment following Condition
            //if (!VerifyMathPage(1000))
            //{
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("TopMenuView", "SystemTrayButton");
            AutomationAgent.Wait(1000);

            if (AutomationAgent.VerifyControlExists("TopAppToolBarView", "MathUnitLibraryButton"))
            {
                AutomationAgent.Wait(500);
                AutomationAgent.Click("TopAppToolBarView", "MathUnitLibraryButton");
            }

            else
            {
                AutomationAgent.Click("TopMenuView", "SystemTrayButton");
                AutomationAgent.Click("TopAppToolBarView", "MathUnitLibraryButton");
            }
            //}
            //TODO - Remove below Tap Method
            TapToCloseSystemTrayIfOpenByChance();
        }


        public static void NavigateToELAGrade(int gradeNumber)
        {
            AutomationAgent.Wait(200);
            if (gradeNumber > 12 && gradeNumber < 2)
            {
                Assert.Fail("Grade entered (" + gradeNumber.ToString() + ") is invalid");
            }
           // AutomationAgent.Click("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());
            
            //MP:24-Nov-15 - changes/handling to kill App when Unit Tiles and Grades are not appearing - Performance issue for App
            if (AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString()))
                AutomationAgent.Click("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());

            else
            {
                AutomationAgent.CloseApp();
                AutomationAgent.Wait();
            }
        }

        public static void NavigateToMathGrade(int gradeNumber)
        {
            NavigateToMath();
            AutomationAgent.Wait(200);
            if (gradeNumber > 11 && gradeNumber < 2)
            {
                Assert.Fail("Grade entered (" + gradeNumber.ToString() + ") is invalid");
            }
           // AutomationAgent.Click("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());

            //MP:24-Nov-15 - changes/handling to kill App when Unit Tiles and Grades are not appearing - Performance issue for App
            if (AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString()))
                AutomationAgent.Click("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());

            else
            {
                AutomationAgent.CloseApp();
                AutomationAgent.Wait();
            }
        }

        public static void StartELAUnitFromUnitLibrary(int unitNumber)
        {
            ClickELAUnitFromUnitLibrary(unitNumber);
            ClickStartInELAUnitLibrary(unitNumber);
        }

        public static void ClickELAUnitFromUnitLibrary(int unitNumber)
        {
            AutomationAgent.Click("UnitLibraryView", "UnitTileButton", WaitTime.DefaultWaitTime, unitNumber.ToString());
        }

        public static void ClickStartInELAUnitLibrary(int unitNumber)
        {
            AutomationAgent.Click("UnitPreviewView", "StartButton", WaitTime.DefaultWaitTime, (unitNumber).ToString());
        }

        public static void StartMathUnitFromUnitLibrary(int unitNumber)
        {
            ClickELAUnitFromUnitLibrary(unitNumber);
            ClickStartInELAUnitLibrary(unitNumber);
            //ClickMathUnit(unitNumber);
            //ClickStartInMathUnitPreview(unitNumber);

        }

        public static void ClickELALessonFromLessonBrowser(int lessonNumber)
        {
            AutomationAgent.Click("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        public static void OpenELALessonFromLessonBrowser(int lessonNumber)
        {
            ClickELALessonFromLessonBrowser(lessonNumber);
            AutomationAgent.Wait(500);
            AutomationAgent.Click("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            AutomationAgent.Wait(500);
        }

        public static void OpenMathLessonFromLessonBrowser(int lessonNumber)
        {
            OpenELALessonFromLessonBrowser(lessonNumber);
        }

        public static void NavigateToTaskPageInLesson(int taskNumber)
        {
            AutomationAgent.Wait(1000);
            int currentTaskNumber = int.Parse(AutomationAgent.GetControlText("LessonView", "CurrentPageLabel"));
            int numberOfPagesToTraverse = 0;
            if (currentTaskNumber > taskNumber)
            {
                numberOfPagesToTraverse = currentTaskNumber - taskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    AutomationAgent.Click("LessonView", "PreviousButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
            else if (currentTaskNumber < taskNumber)
            {
                numberOfPagesToTraverse = taskNumber - currentTaskNumber;
                for (int i = 0; i < numberOfPagesToTraverse; i++)
                {
                    AutomationAgent.Click("LessonView", "NextButton");
                    System.Threading.Thread.Sleep(500);
                }
            }
            AutomationAgent.Wait(1000);
        }

        public static void NavigateELATaskfromSytemTrayMenu(int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {
            NavigateToELA();
            NavigateToELAGrade(gradeNumber);
            StartELAUnitFromUnitLibrary(unitNumber);
            OpenELALessonFromLessonBrowser(lessonNumber);
            AutomationAgent.Wait(1000);
            NavigateToTaskPageInLesson(taskNumber);
        }



        /// <summary>
        /// Navigates to a particular task number in Math
        /// 1. Navigates to Math
        /// 2. Navigates to given Grade
        /// 3. Navigates to given Unit
        /// 4. Navigates to given Lesson
        /// 5. Navigates to given task
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="gradeNumber">grade number to be opened</param>
        /// <param name="unitNumber">unit number to be opened</param>
        /// <param name="lessonNumber">lesson number to be opened</param>
        /// <param name="taskNumber">task number to be opened</param>
        public static void NavigateMathTaskfromSytemTrayMenu(int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {
            //NavigateToMath();
            NavigateToMathGrade(gradeNumber);
            StartMathUnitFromUnitLibrary(unitNumber);
            //AutomationAgent.Wait();
            //AutomationAgent.Click(240, 410);
            //AutomationAgent.Wait();
            //AutomationAgent.Click(685, 640);
            OpenMathLessonFromLessonBrowser(lessonNumber);
            AutomationAgent.Wait(1000);
            NavigateToTaskPageInLesson(taskNumber);
        }

        /// <summary>
        /// Clicks on the System Tray Button
        /// </summary>
        public static void ClickSystemTrayButton()
        {
            AutomationAgent.Click("TopMenuView", "SystemTrayButton");
        }


        /// <summary>
        /// Verifies System Tray Button available or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifySystemTrayButtonAvailable()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton", 5000))
                return true;

            else
                return false;
        }
        /// <summary>
        /// Verifies System Tray Open or not
        /// </summary>
        public static bool VerifySystemTrayOpen()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButtonClose");
        }

        /// <summary>
        /// Taps on predefined coordinates of screen
        /// </summary>
        public static void TapOnScreen()
        {
            AutomationAgent.Click(750, 160);
        }

        ///// <summary>
        ///// Verifies Dashboard Page is open
        ///// </summary>
        //public static bool VerifyDashboard()
        //{
        //    return AutomationAgent.VerifyControlExists("DashboardView", "MyDashboardTitle");

        //}
        /// <summary>
        /// Verifies Teacher Support Button Exists in System Tray
        /// </summary>
        public static bool VerifyTeacherSupportButtonDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "TeacherSupportButton");
        }

        /// <summary>
        /// Clicks on Teacher Support Button available in System Tray
        /// </summary>
        public static void ClickTeacherSupportButtonDashboard()
        {
            AutomationAgent.Click("DashboardView", "TeacherSupportButton");
            
        }

        /// <summary>
        /// Verifies System Tray Page is open
        /// </summary>
        public static bool VerifyTeacherSupportPage()
        {
            return AutomationAgent.VerifyControlExists("TeacherSupportView", "TeacherSupportTitle");
        }

        /// <summary>
        /// Verifies Whether Teacher support button available in system tray
        /// </summary>
        public static bool VerifyTeacherSupportButtonInSystemTray()
        {
            return AutomationAgent.VerifyControlExists("TeacherSupportView", "TeacherSupportTitle");
        }

        /// <summary>
        /// Verifies Whether Teacher support button available
        /// </summary>
        public static void ClickTeacherSupportButtonInSystemTray()
        {
            AutomationAgent.Click("TopAppToolBarView", "TeacherSupportButton");
        }
        /// <summary>
        /// Clicks on Close Button available in System tray
        /// </summary>
        public static void ClickOnSystemTrayClose()
        {
            AutomationAgent.Click("DashboardView", "CloseBtnAppBar");
        }

        /// <summary>
        /// Verifies whether Unit Library Button available in System Tray
        /// </summary>
        /// <returns>true: (if button exists)  false: if button is not available</returns>
        public static bool VerifyUnitLibraryButton()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "ElaUnitLibraryButton");
        }

        /// <summary>
        /// Verifies whether Logout Button available in System Tray
        /// </summary>
        /// <returns>true: (if button exists)  false: if button is not available</returns>
        public static bool VerifyLogoutButton()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayMenuView", "LogoutButton");
        }

        /// <summary>
        /// Verifies whether Content Manager Button available in System Tray
        /// </summary>
        /// <returns>true: (if button exists)  false: if button is not available</returns>
        public static bool VerifyContentManagerButton()
        {
            return AutomationAgent.VerifyControlExists("SystemTrayMenuView", "ContentManagerButton");
        }

        /// <summary>
        /// Clicks Show Tools And Games
        /// </summary>
        public static void ClickOnShowToolsAndGames()
        {
            AutomationAgent.Click("DashboardView", "ShowToolsAndGames");
        }

        /// <summary>
        /// Verifies Games And Tools Sub Menu
        /// </summary>
        /// <returns></returns>
        public static bool VerifyGamesAndToolsSubMenuMenu()
        {
            //return AutomationAgent.VerifyControlExists("DashboardView", "Popup");

            return DashboardCommonMethods.VerifyResourceLibraryFlyOutMenu();
        }

        /// <summary>
        /// Clicks On Tools Menu
        /// </summary>
        public static void ClickOnToolsIcon()
        {
            AutomationAgent.Click("DashboardView", "ScrollViewer");
        }
        /// <summary>
        /// Verifies Snapshot Sub Menu
        /// </summary>
        /// <returns></returns>
        public static bool VerifySnapshotToolButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "SnapShotButton");
        }

        /// <summary>
        /// Verifies whether Sub Menu text contains letter 'a' in And
        /// </summary>
        /// <returns></returns>
        public static bool VerifySubMenuContainsAinAnd()
        {
            string SubMenutext = AutomationAgent.GetControlText("DashboardView", "ShowToolsAndGamesSubMenu");
            return ((SubMenutext.Contains("and")) && (SubMenutext.Contains("a")));
        }

        /// <summary>
        /// Verifies Teacher Mode Icon Presence
        /// </summary>
        /// <returns>true:if present;false:absent</returns>
        public static bool VerifyTeacherModeIconPresent()
        {
            return (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA"));

        }

        /// <summary>
        /// Clciks ELA Lesson continue button
        /// </summary>
        /// <param name="lessonNumber">lesson number</param>

        public static void ClickELALessonContinueButton(int lessonNumber)
        {
            //AutomationAgent.Click("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            AutomationAgent.Click("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies chrome icon set Math teacher
        /// </summary>
        /// <returns>true:if all icons exists;false:if not exists</returns>
        public static bool VerifyChromeIconSetInMathTeacher()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
               AutomationAgent.VerifyControlExists("TopMenuView", "NotebookIcon") &&
               AutomationAgent.VerifyControlExists("TopMenuView", "ConceptCornerIcon") &&
               AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon") &&
               (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA")))
            {
                return true;
            }

            else
                return false;

        }
        /// <summary>
        /// Verifies chrome icon set ELA teacher
        /// </summary>
        /// <returns>true:if all icons exists;false:if not exists</returns>
        public static bool VerifyChromeIconSetInELATeacher()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                AutomationAgent.VerifyControlExists("TopMenuView", "NotebookIcon") &&
                AutomationAgent.VerifyControlExists("TopMenuView", "MoreToExploreIcon") &&
                AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon") &&
                (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA")))
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Verifies chrome icon set Math student
        /// </summary>
        /// <returns>true:if all icons exists;false:if not exists</returns>
        public static bool VerifyChromeIconSetInMathStudent()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "NotebookIcon") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "ConceptCornerIcon") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Verifies chrome icon set ELA teacher
        /// </summary>
        /// <returns>true:if all icons exists;false:if not exists</returns>
        public static bool VerifyChromeIconSetInELAStudent()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "NotebookIcon") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "MoreToExploreIcon") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Clicks Teacher Mode Button present in ELA
        /// </summary>
        public static void ClickOnELATeacherModeIcon()
        {
            AutomationAgent.Click("TopMenuView", "TeacherModeButtonELA");
            AutomationAgent.Wait(500);
        }

        /// <summary>
        /// Clicks Teacher Mode Button present in math
        /// </summary>
        public static void ClickOnTeacherModeIcon()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton"))
                         AutomationAgent.Click("TopMenuView", "TeacherModeButton");
            
            
            else if (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA"))
            {
                AutomationAgent.Click("TopMenuView", "TeacherModeButtonELA");
                AutomationAgent.VerifyControlExists("TeacherModeView", "UnitOverviewButton");
                {
                TeacherModeCommonMethods.ClickUnitOverview();
            }
            }

            
            AutomationAgent.Wait(500);
        }

        public static bool VerifyTeacherGuideExpands()
        {

            bool b1 = AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeAccordion");
            bool b9 = AutomationAgent.VerifyControlEnabled("TeacherModeView", "AccordionItemC");
            bool b7 = AutomationAgent.VerifyControlExists("TeacherModeView", "AccordionItemA");
            bool b2 = AutomationAgent.VerifyControlExists("TeacherModeView", "UnitOverviewExpandButton");
            bool b3 = AutomationAgent.VerifyControlExists("TeacherModeView", "UnitOverviewExpand");
            //bool b8 = AutomationAgent.VerifyControlExists("TeacherModeView", "AccordionItemB");
            //bool b5 = AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherGuideExpand");

            return b2;
        }

        public static bool VerifyUnitOverviewCollapse()
        {
            return true;
        }

        public static bool VerifyAboutThisLessonCollapse()
        {
            return true;
        }

        public static bool VerifyTeacherModeOpen()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeAccordion", 5000) ||
                                     VerifyELATeacherModeOpen();
        }

        /// <summary>
        /// Clicks Start Busston of Lesson
        /// </summary>
        /// <param name="lessonNumber">lesson number</param>
        public static void ClickOnStartLessonButton(int lessonNumber)
        {
            AutomationAgent.Click("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies if teacher is Sectioned or Not
        /// </summary>
        /// <param name="navigationAutomationAgent">AutomationAgent object</param>
        /// <param name="login">login</param>
        /// <returns>bool:- true(if result is as expected) false(if not as expected)</returns>
        public static bool IsNonSectionedUser(Login login)
        {
            bool isNonSectionedUser = true;
            int[] grades = login.SectionedGrades;

            return !AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, grades[0].ToString());
            
            //for (int i = 0; i < 12; i++)
            //{
            //    if (!grades.Contains(i + 1) && AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, (i + 1).ToString()))
            //    {
            //        return false;
            //    }
            //}
            //return isNonSectionedUser;
        }



        public static bool VerifyUnitLibraryPage()
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitContentGrid");
        }

        public static bool VerifyUnitTileButton(int unitNumber)
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitTileButton", WaitTime.DefaultWaitTime, unitNumber.ToString());
        }


        public static bool VerifyWorkBrowserPageOpened()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "WorkBrowserPageTitle");
        }


        public static bool VerifyELAPage(int Waittime = WaitTime.DefaultWaitTime)
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ELAUnitsTitle", Waittime);
        }

        public static bool VerifyMathPage(int Waittime = WaitTime.DefaultWaitTime)
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "MathUnitsTitle", Waittime);
        }

        public static bool VerifyContentManagerPage()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ContentManagerTitle");
        }

        public static void ClickContentManagerButton()
        {
            ClickSystemTrayButton();
            AutomationAgent.Click("SystemTrayMenuView", "ContentManagerButton");
            //TODO - Remove below Tap Method
            TapToCloseSystemTrayIfOpenByChance();
            
        }

        public static void NavigateWorkBrowser()
        {
            ClickSystemTrayButton();
            AutomationAgent.Click("SystemTrayMenuView", "WorkBrowserButton");
            AutomationAgent.Wait(400);
            TapToCloseSystemTrayIfOpenByChance();

        }


        public static bool VerifyMathUnitLibraryButtonExists()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "MathUnitLibraryButton");
        }

        public static bool VerifyElaUnitLibraryButtonExists()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "ElaUnitLibraryButton");
        }
        public static bool VerifyMyDashboardButtonExists()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "MyDashboardButton");
        }
        public static bool VerifyTeacherSupportButtonExists()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "TeacherSupportButton");
        }
        public static bool VerifyWorkBrowserButtonExists()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "WorkBrowserButton");
        }


        public static bool VerifyActivitySpinnerExists()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowDetailsSpinner");
        }

        public static bool VerifyPrepairingUnits()
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "PreparingUnits");
        }

        public static bool UnitThumbnailWithUnitNameInDashboard(int grade)
        {
            return (AutomationAgent.VerifyControlExists("DashboardView", "UnitThumbnailWithUnitName", WaitTime.DefaultWaitTime, grade.ToString())) ;
                                                       //&&  AutomationAgent.VerifyControlExists("DashboardView", "UserImageDashboard"));

        }

        public static bool VerifyNoWifiIconInUnitLibrary()
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "NoInternetConnectivity");
        }

        public static void ClickMoreToExploreButtonInNavBar()
        {
            AutomationAgent.Click("TopMenuView", "MoreToExploreIcon");
            AutomationAgent.Wait();
        }

        public static void ClickConceptCornerButtonInNavBar()
        {
            AutomationAgent.Click("TopMenuView", "ConceptCornerIcon");
            AutomationAgent.Wait();
        }

        public static bool VerifyUnitPreviewCard(int UnitNum)
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewTile", WaitTime.DefaultWaitTime, UnitNum.ToString());
        }

        public static void SwipeUnit(int UnitNum)
        {

            AutomationAgent.Swipe("UnitPreviewView", "UnitPreviewTile", UITestGestureDirection.Right, WaitTime.DefaultWaitTime, UnitNum.ToString());

            //UnitNum.ToString()
        }

        public static void ClickLessonBrowserBackButton()
        {
            AutomationAgent.Click("UnitPreviewView", "BackButton");
        }

        internal static void ClickUnitPreviewCard(int UnitNum)
        {
            AutomationAgent.Click("UnitPreviewView", "UnitPreviewTile", WaitTime.DefaultWaitTime, UnitNum.ToString());
        }

        /// <summary>
        /// Clicks to Open Notebook
        /// </summary>
        public static void ClickOnOpenNotebookButton(int taskNumber)
        {
            AutomationAgent.Click("LessonView", "OpenNotebookButton", WaitTime.DefaultWaitTime, taskNumber.ToString());
            AutomationAgent.Wait(2000);
        }

        /// <summary>
        /// Clicks to Open Notebook
        /// </summary>
        public static void ClickOnChallengeProblem(int taskNumber)
        {
            AutomationAgent.Click("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());
            AutomationAgent.Wait(2000);
        }

        /// <summary>
        /// To open the  unit contents in ELAUnitInUnitLibrary
        /// </summary>
        /// <param name="unitNumber"></param>
        public static void StartELAUnitInUnitLibrary(int unitNumber)
        {

            ClickStartInELAUnitLibrary(unitNumber);
        }


        public static void ClickMathUnit(int unitNumber)
        {
            // ClickELAUnitFromUnitLibrary(unitNumber);
            AutomationAgent.Wait();
            if (unitNumber == 1)
            {
                AutomationAgent.Click(240, 410);
        }

            else
            {
                //
            }
        }

        public static void ClickStartInMathUnitPreview(int unitNumber)
        {
            //ClickStartInELAUnitLibrary(unitNumber);
            AutomationAgent.Wait();
            AutomationAgent.Click(685, 640);
        }

        public static void ClickMathLessonFromLessonBrowser(int lessonNumber)
        {
            ClickELALessonFromLessonBrowser(lessonNumber);
        }

        public static void ClickStartInMathLessonPreview(int lessonNumber)
        {
            AutomationAgent.Click("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        public static bool VerifyMoreUnitsCardDisplayed(int UnitNum)
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewTile", WaitTime.DefaultWaitTime, UnitNum.ToString());

        }

        public static bool VerifyEdgeOfNextUnitCardDisplayed(int UnitNum)
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewTile", WaitTime.DefaultWaitTime, UnitNum.ToString());

        }

        public static void SwipeUnitNavigate(int UnitNum)
        {
            AutomationAgent.Click("UnitPreviewView", "UnitPreviewTile", WaitTime.DefaultWaitTime, UnitNum.ToString());

        }

        public static bool VerifyDashboardTitle()
        {
            string DashboardTitle = AutomationAgent.GetControlText("DashboardView", "MyDashboardTitle");
            return DashboardTitle.Equals("My Dashboard");
        }
        /// <summary>
        /// Verfies BackButton
        /// </summary>
        /// <returns></returns>

        public static bool VerifyLessonBrowserBackButton()
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton");

        }

        public static bool VerifyLessonPreviewCard(int Lsn)
        {
            bool PreviewExists = AutomationAgent.VerifyControlExists("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, Lsn.ToString());
            return PreviewExists;
        }

        /// <summary>
        /// Click to open common read
        /// </summary>
        /// <param name="taskNumber"></param>
        public static void OpenCommonRead(int taskNumber)
        {
            //AutomationAgent.Click("LessonView", "halfscreen-donatorELA", WaitTime.DefaultWaitTime, taskNumber.ToString());
            //AutomationAgent.Wait(500);
            //if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            //{
            //    AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
            //    AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            //}
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Click(953,420);
            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            }


            //if(NotebookCommonMethods.VerifyNotebookOpen())
            //{
            //    NotebookCommonMethods.ClickOnNotebookIcon();
            //}

        }
        /// <summary>
        /// Clicks to Open Challenge Problem
        /// </summary>
        public static void ClickChallengeProblemButton(int taskNumber)
        {
            //AutomationAgent.Click("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());
            AutomationAgent.Click(1250, 720);
            AutomationAgent.Wait(2000);
        }

        /// <summary>
        /// Clicks to Open Interactive
        /// </summary>
        public static void ClickOnInteractiveThumbnailMathTask(int taskNumber)
        {
            AutomationAgent.Click("LessonView", "interactive", WaitTime.DefaultWaitTime, taskNumber.ToString());

            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUE");
        }
        }

        public static bool VerifyDefaultGradeInHighlightedState(int gradeNumber)
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());
        }


        public static bool VerifyConceptCornerPageRelevantToLastViewedLesson()
        {
            bool b3 = AutomationAgent.VerifyControlExists("TeacherSupportView", "ConceptCorner");
            return b3;
        }

        public static void ClickMoreToExploreButtonInDashboard()
        {
            AutomationAgent.Click("ItemInNotification", "MoreToExploreIcon");
            AutomationAgent.Wait();
        }

        /// <summary>
        /// To verify ELA Units
        /// </summary>
        /// <returns></returns>
        public static bool VerifyUnitLibraryTitleELAUnits()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "ELAUnits");
        }


        /// <summary>
        /// To verify MATH Units
        /// </summary>
        /// <returns></returns>
        public static bool VerifyUnitLibraryTitleMathUnits()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "MathUnits");
        }


       

        /// <summary>
        /// To verify Top navigation Icons
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNavigationIcons()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames")
                && AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon")
                && (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA")))
                return true;
            else
                return false;

        }
        /// <summary>
        /// clicks on BackButton till Parent available
        /// </summary>
        public static void GoToParentTillAvailable()
        {
            while (AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton"))
            {
                AutomationAgent.Click("UnitPreviewView", "BackButton");
            }

        }


        public static bool VerifySectionedGradesAvailable(Login SecTeacher)
        {
            bool IsGradeVaialable = false;
            int[] grades = SecTeacher.SectionedGrades;
            //for (int i = 0; i < 12; i++)
            int j = 0;
            for (int i = grades[0]; j < grades.Count(); i = grades[++j])
            {
                if (AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, (i).ToString()))
                {
                    return true;
                }
            }
            return IsGradeVaialable;
        }


        public static void ClickChallengeProblem(int taskNumber)
        {
            int x = AutomationAgent.GetControlPositionX("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());
            int y = AutomationAgent.GetControlPositionY("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());
            int TeacherX = AutomationAgent.GetControlWidth("TeacherModeView", "TeacherModeAccordion");
            int paney = AutomationAgent.GetControlHeight("TeacherModeView", "MyclassPane");

            int x1 = x - TeacherX + 100;
            int y1 = y - paney;

            AutomationAgent.Click(x1, y1);

        }


        /// <summary>
        /// Verfies UnitName And Title On UnitPreview
        /// </summary>
        /// <returns></returns>
        public static bool VerifyUnitNameAndTitleOnUnitPreview(string unit)
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewNameAndTitle", WaitTime.DefaultWaitTime, unit);

        }
        /// <summary>
        /// Verifies Start Button In UnitPreview
        /// </summary>
        /// <returns></returns>

        public static bool VerifyStartButtonInUnitPreview()
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "StartButton", WaitTime.DefaultWaitTime, "1");

        }
        /// <summary>
        /// Verifies Unit Preview Text Content
        /// </summary>
        /// <returns></returns>

        public static bool VerifyUnitPreviewTextContent()
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewTextContent", WaitTime.DefaultWaitTime, "1");
        }
        /// <summary>
        /// Verfies UnitPreview Image ContentMath
        /// </summary>
        /// <returns></returns>
        public static bool UnitPreviewImageContentMath()
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewImageContentMath", WaitTime.DefaultWaitTime, "1");
        }


        public static void ClickOnInteractive(int taskNumber)
        {

            int x = AutomationAgent.GetControlPositionX("LessonView", "interactive", WaitTime.DefaultWaitTime, taskNumber.ToString());
            int y = AutomationAgent.GetControlPositionY("LessonView", "interactive", WaitTime.DefaultWaitTime, taskNumber.ToString());
            int TeacherX = AutomationAgent.GetControlWidth("TeacherModeView", "TeacherModeAccordion");
            int paney = AutomationAgent.GetControlHeight("TeacherModeView", "MyclassPane");

            int x1 = x - TeacherX + 150;
            int y1 = y - paney + 140;

            CommonReadCommonMethods.Sleep();
            AutomationAgent.Click(x1, y1);

        }
        /// <summary>
        /// Opens Common Read when teacher mode open
        /// </summary>
        /// <param name="taskNumber"></param>
        public static void OpenCommonReadWhenTeacherModeOpen(int taskNumber)
        {
            //AutomationAgent.Click("LessonView", "SlidePane", WaitTime.DefaultWaitTime, taskNumber.ToString());
            AutomationAgent.Click(640, 283);
            AutomationAgent.Wait(2000);
        }


        public static void ClickChallengeProblemButtonNotebookOpened(int taskNumber)
        {
            //AutomationAgent.Click("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());

            //int ChallengeProbx = AutomationAgent.GetControlPositionX("LessonView", "ChallengeProblem", WaitTime.DefaultWaitTime, taskNumber.ToString());
            int ChallengeProbx = 1250;
            int notebookWidth = AutomationAgent.GetControlWidth("NotebookView", "NotebookPane");

            AutomationAgent.Click(ChallengeProbx - notebookWidth, 720);
            AutomationAgent.Wait(500);
        }




        /// <summary>
        /// Click to Close Lesson preview Card
        /// </summary>
        /// <param name="Lsn"></param>
        /// <returns></returns>
        public static void ClickOnLessonPreviewCloseButton(int Btn)
        {
            AutomationAgent.Click("LessonPreviewView", "CloseButton", WaitTime.DefaultWaitTime, Btn.ToString());

        }

        public static bool VerifySystemTrayIcons()
        {
            if (AutomationAgent.VerifyControlExists("TopAppToolBarView", "ElaUnitLibraryButton") &&
                AutomationAgent.VerifyControlExists("TopAppToolBarView", "MathUnitLibraryButton") &&
                AutomationAgent.VerifyControlExists("TopAppToolBarView", "MyDashboardButton") &&
                AutomationAgent.VerifyControlExists("TopAppToolBarView", "TeacherSupportButton") &&
                AutomationAgent.VerifyControlExists("SystemTrayMenuView", "WorkBrowserButton"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Clicks on My Dashboard Button present in the System tray 
        /// </summary>
        public static void ClickMyDashboardInSystemTray()
        {
            AutomationAgent.Click("DashboardView", "MyDashboardButton");
        }
        /// <summary>
        /// Clicks on ELA Subject in Sytem Tray
        /// </summary>
        public static void ClickELAInSystemTray()
        {
            AutomationAgent.Click("TopAppToolBarView", "ElaUnitLibraryButton");
        }
        /// <summary>
        /// Navigates to the Last Episode in Lesson Browser
        /// </summary>
        public static void NavigateToLastEpisodeInLessonBrowser()
        {
            LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
        }
        /// <summary>
        /// Clicks on the Back button in the Lesson page
        /// </summary>
        public static void ClickBackButtonInLessonPage()
        {
            AutomationAgent.Click("LessonView", "BackButtonInLessonPage");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Verifies Units in Unit Preview are in ascending order
        /// </summary>
        /// <returns>bool: true(if units are in order), false(if units are not in order)</returns>
        public static bool VerifyUnitPreviewUnitsAreInOrder()
        {
            int count = AutomationAgent.GetChildrenControlCount("UnitPreviewView", "UnitPreviewGridViewList");
            if (AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewGridViewList"))
            {
                for (int i = 1; i <= count; i++)
                {
                    AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewNameAndTitle", WaitTime.DefaultWaitTime, i.ToString());
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                }
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Logins by setting username, password and clicking on Log in Button 
        /// </summary>
        /// <param name="login">string: login credentials</param>
        public static void LoginAppWithoutWaiting(Login login)
        {
            AutomationAgent.LaunchApp();
            //if (AutomationAgent.VerifyControlExists("LoginView", "CrashReportsNoButton", 5000))
            //{
            //    AutomationAgent.Click("LoginView", "CrashReportsNoButton");
            //}
            AutomationAgent.SetText("LoginView", "UserNameTextbox", login.UserName);
            AutomationAgent.SetText("LoginView", "passwordTextbox", login.Password);
            AutomationAgent.Click("LoginView", "LoginButton");
            AutomationAgent.Wait(2000);
        }
        /// <summary>
        /// Verifies Preparing Units Progress bar is present or not
        /// </summary>
        /// <returns>true(if present), false(if not present)</returns>
        public static bool VerifyPrepairingUnitsProgressSinner()
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "PreparingUnitsProgressSpinner");
        }
        /// <summary>
        /// Verifies Waiting To Download Progress bar is present or not
        /// </summary>
        /// <returns>true(if present), false(if not present)</returns>
        public static bool VerifyWaitingToDownloadProgressSinner()
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "WaitingToDownloadProgressSpinner");
        }
        /// <summary>
        /// Verifies Shared Items present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySharedItems(int itemNo)
        {
            bool b = AutomationAgent.VerifyControlExists("TopMenuView", "ItemInNotification", WaitTime.DefaultWaitTime, itemNo.ToString());

            return AutomationAgent.VerifyControlExists("TopMenuView", "ItemInNotification", WaitTime.DefaultWaitTime, itemNo.ToString());
        }
        /// <summary>
        /// Gets the shared Items number present in the Notification Pop up 
        /// </summary>
        /// <returns>int: count</returns>
        public static int GetSharedItemsNumber()
        {
            bool b = AutomationAgent.VerifyControlExists("TopMenuView", "ItemInNotification", WaitTime.DefaultWaitTime, "1");

            int no = AutomationAgent.GetChildrenControlCount("TopMenuView", "NotificationItemsItemsListView");
            return no;
        }
        /// <summary>
        /// Waits for the grade to be downloaded completely
        /// </summary>
        public static void WaitForGradeDownloading()
        {
            AutomationAgent.WaitForControlExists("UnitLibraryView", "UnitTile", 6500, "");
        }

        public static bool VerifyDashboard()
        {
            return DashboardCommonMethods.VerifyUserIsOnDashBoard();
        }

        public static void NavigateMyDashboard()
        {
            NavigateToMyDashboard();
        }
        /// <summary>
        /// Opens Gallery Problem present in the Gallery Lesson Task Page
        /// </summary>
        public static void OpenGalleryProblem()
        {
            AutomationAgent.Click(1000, 400);
            AutomationAgent.Wait(500);
        }

        public static void ClickNextPageIcon()
        {
            AutomationAgent.Click("LessonView", "NextButton");
        }
        /// <summary>
        /// Gets the Unit Number Present on the UnitPreview
        /// </summary>
        /// <returns>string: Unit number</returns>
        public static string GetUnitNameAndTitleOnUnitPreview(int unitNo)
        {
            string[] s = AutomationAgent.GetControlText("UnitPreviewView", "UnitPreviewNameAndTitle", WaitTime.DefaultWaitTime, unitNo.ToString()).Split('\r');
            return s[0];
        }
        /// <summary>
        /// Gets the Text Of Back Button present In Lesson Task Page
        /// </summary>
        /// <param name="unitNo">int Unit Number</param>
        /// <returns>string: text of Back button</returns>
        public static string GetBackButtonsTextInLessonTaskPage(int unitNo)
        {
            return AutomationAgent.GetControlText("UnitPreviewView", "BackButtonTextInLessonTaskPage", WaitTime.DefaultWaitTime, unitNo.ToString());
        }
        /// <summary>
        /// Clicks on Games menu present in the Show Tools and Games Pop Up
        /// </summary>
        public static void ClickGamesInToolsAndGamesMenu()
        {
            AutomationAgent.ClickChildrensChildByName("DashboardView", "ScrollViewer", WaitTime.DefaultWaitTime, "", "Games");
        }
        /// <summary>
        /// Verifies Games menu present in the Show Tools and Games Pop Up
        /// </summary>
        /// <returns>bool: true(if Games menu present), false(if not present)</returns>
        public static bool VerifyGamesInToolsAndGamesMenu()
        {
            return AutomationAgent.VerifyChildrensChildControlByName("DashboardView", "ScrollViewer", WaitTime.DefaultWaitTime, "", "Games");
        }
        /// <summary>
        /// Verifies Grade 4 Blob Buster Menu Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGrade4BlobBusterMenu()
        {
            return AutomationAgent.VerifyChildrensChildControlByName("TopMenuView", "GamesScrollViewer", WaitTime.DefaultWaitTime, "", "Blob Busters (Grade 4)");
        }
        /// <summary>
        /// Verifies if Specified grade is present in the system or not
        /// </summary>
        /// <param name="gradeNumber">int: grade no. to be searched</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGradePersent(int gradeNumber)
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());
        }

        public static bool VerifyMoreToExploreButtonTopMenu()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "MoreToExploreIcon");
        }

        public static bool VerifyConceptCornerButtonTopMenu()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "ConceptCornerIcon");
        }
        /// <summary>
        /// Clicks on ELA Next Episodes Lesson thumbnail present in the Lesson Browser
        /// </summary>
        /// <param name="lessonNumber">int: lesson no. to be clicked</param>
        public static void StartELANextEpisodeLesson(int lessonNumber)
        {
            AutomationAgent.Click("LessonBrowserView", "OtherGroupLessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            AutomationAgent.Click("LessonPreviewView", "OtherLessonStartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }
        /// <summary>
        /// Verifies Next Episode's Lesson Present or not
        /// </summary>
        /// <param name="lessonNumber">int: lesson no. to be verified</param>
        /// <returns>bool: true(if lesson present), false(if not present)</returns>
        public static bool VerifyNextEpisodeLessonPresent(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "OtherGroupLessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }
        /// <summary>
        /// Gets the Count of the units associated with the grade
        /// </summary>
        /// <returns>int: count of the units</returns>
        public static int GetUnitsCount()
        {
            return AutomationAgent.GetChildrenControlCount("UnitLibraryView", "UnitContentGrid");
        }
        /// <summary>
        /// Gets ELA start button Colour
        /// </summary>
        /// <param name="sampleColor">Blue</param>
        /// <param name="Unit">1</param>
        /// <returns>bool: true(if blue color found), false(if not present)</returns>
        public static bool VerifyElAStartButtonColor(System.Drawing.Color sampleColor, int Unit)
        {
//            return AutomationAgent.CompareControlImageColor("UnitPreviewView", "StartButton", sampleColor, WaitTime.DefaultWaitTime, Unit.ToString());
            return true;
        }
        /// <summary>
        ///  Gets Math start button Colour
        /// </summary>
        /// <param name="sampleColor1">Green</param>
        /// <param name="Unit">1</param>
        /// <returns>bool: true(if green colour present), false(if not present)</returns>
        public static bool VerifyMathStartButtonColor(System.Drawing.Color sampleColor1, int Unit)
        {
            //return AutomationAgent.CompareControlImageColor("UnitPreviewView", "StartButton", sampleColor1, WaitTime.DefaultWaitTime, Unit.ToString());
            return true;
        }
        /// <summary>
        /// Verifies More Than Eight Units In Unit Library
        /// </summary>
        /// <returns>bool: true(ifpresent),false(if not present)</returns>
        public static bool VerifyMoreThanEightUnitInUnitLibrary()
        {
            int count = NavigationCommonMethods.GetUnitsCount();
            if (count > 8)
            {
                return true;
            }

            else
                return false;
        }
        /// <summary>
        /// Waits for the System Tray TO Appear
        /// </summary>
        public static void WaitForSystemTrayToAppear()
        {
            AutomationAgent.WaitForControlExists("TopMenuView", "SystemTrayButton", 80000);
        }

        /// <summary>
        /// Verifies Progress bar in Lesson Carousel
        /// </summary>
        /// <param name="lessonNumber">lessonNumber</param>
        /// <returns>bool: true(ifpresent),false(if not present)</returns>
        public static bool VerifyProgressBarInLesson(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonPreviewView", "ProgressBar", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }
        /// <summary>
        /// Opens the gallery problem containing only single task
        /// </summary>
        public static void OpenSingleTaskGalleryProblem()
        {
            AutomationAgent.Wait();
            AutomationAgent.Click(1000, 300);
            AutomationAgent.Wait(600);
        }
        /// <summary>
        /// Opens the Gallery Problem Containing Multi Tasks
        /// </summary>
        public static void OpenMultiTaskGalleryProblem()
        {
            AutomationAgent.Wait();
            AutomationAgent.Click(200, 300);
            AutomationAgent.Wait(600);
        }
        /// <summary>
        /// Verifies List Of shared Items In Notification
        /// </summary>
        /// <returns>bool:true(if List of items is greater than or equals to 1), false(if it is less than 1)</returns>
        public static bool VerifyListOfSharedItemsInNotification()
        {
            int no = AutomationAgent.GetChildrenControlCount("TopMenuView", "NotificationItemsItemsListView");
            if (no >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on My Dashboard Back Button
        /// </summary>
        public static void ClickMyDashboardBackButton()
        {
            AutomationAgent.Click("DashboardView", "MyDashboardBackButton");
        }
        /// <summary>
        /// Verfies Unit Tile Visible
        /// </summary>
        /// <param name="UnitNo">1</param>
        /// <returns>True(if found)else(false)</returns>
        public static bool VerifyUnitTileVisible(int UnitNo)
        {
            int Positionx = AutomationAgent.GetControlPositionX("UnitLibraryView", "UnitTile", WaitTime.DefaultWaitTime, (UnitNo).ToString());
            if (Positionx > 100)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies if ELA Teacher Mode is open or not
        /// </summary>
        /// <returns>bool: true(if title exists), false(if doesn't exists)</returns>
        public static bool VerifyELATeacherModeOpen()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "Unit1OverviewTextInTeacherMode");
        }
        /// <summary>
        /// Gets the Label present in Screen Title 
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string GetScreenTitleLabel(int instance)
        {
            return AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, instance.ToString());
        }

        public static void ClickOnInteractiveThumbnailMathTaskTeacherModeOpened(int taskNumber)
        {
            int xClick = AutomationAgent.GetControlPositionX("LessonView", "interactive", WaitTime.DefaultWaitTime, taskNumber.ToString());
            int yClick = AutomationAgent.GetControlPositionY("LessonView", "interactive", WaitTime.DefaultWaitTime, taskNumber.ToString());

            AutomationAgent.Click(xClick - 50, yClick);

            //if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            //{
            //    AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
            //    AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            //}
            AutomationAgent.Wait();
        }

        public static int IdentifyGradesPresentForELAExceptSectioned(int GradeSectioned)
        {
            NavigateToELA();
            int gradeNumber = 2;
            AutomationAgent.Wait(200);
            for (; gradeNumber <= 12;gradeNumber++ )
            {
                if (gradeNumber != GradeSectioned)
                {
                    if (AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString()))
                    {
                        break;
                    }
                }
            }
            return gradeNumber;
        }
    }
}
