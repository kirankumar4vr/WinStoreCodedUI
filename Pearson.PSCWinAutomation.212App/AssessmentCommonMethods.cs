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
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for AssessmentCommonMethods
    /// </summary>
    
    public class AssessmentCommonMethods
    {
        public AssessmentCommonMethods()
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
        /// Verifies Assessment in dashboard
        /// </summary>
        /// <param name="AssessmentAutomationAgent"></param>
        /// <param name="sectionAndPeriod">section</param>
        public static void VerifyAssessmentInDashboard(string sectionAndPeriod)
        {

            // WaitForGrade12ELAToAppear(AssessmentAutomationAgent);
            //AutomationAgent.Swipe(Direction.Right, 500, 731);
            LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            AutomationAgent.VerifyControlExists("DashboardView", "AssessmentLink", WaitTime.DefaultWaitTime, sectionAndPeriod);
        }
        /// <summary>
        /// Gets Additional info from XML
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>string array: Status</returns>
        public static string[] LoadUnitStatusFromAdditionalInfo(Login login)
        {
            TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
            String additionalInfo = taskInfo.AdditionalInfo;
            String[] unitStatus = additionalInfo.Split(',');
            return unitStatus;
        }
        /// <summary>
        /// Gets Additional info from XML
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>string array: Status</returns>
        public static string[] LoadMathUnitStatusFromAdditionalInfo(Login login)
        {
            TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");
            String additionalInfo = taskInfo.AdditionalInfo;
            String[] unitStatus = additionalInfo.Split(',');
            return unitStatus;
        }
        /// <summary>
        /// Clicks assessmnent is DAshboard
        /// </summary>
        /// <param name="sectionAndPeriod">string: object</param>
        public static void ClickAssessmentInDashBoard(string sectionAndPeriod)
        {
            AutomationAgent.Wait();

            if (AutomationAgent.VerifyControlExists("AssessmentView", "DashboardHubSection", WaitTime.DefaultWaitTime, 3.ToString()))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                AutomationAgent.Click("AssessmentView", "AssessmentsButton", WaitTime.DefaultWaitTime, 3.ToString());
                AutomationAgent.Wait(2000);
                WaitForPageToLoad();
            }
            else
            {
                AutomationAgent.Click("AssessmentView", "AssessmentsButton", WaitTime.DefaultWaitTime, 2.ToString());
                WaitForPageToLoad();
            }
        }
        /// <summary>
        /// Select Unit in unit Popup
        /// </summary>
        /// <param name="unitNumber">unit number</param>
        public static void AssessmentUnitSelection(int unitNumber)
        {
            AutomationAgent.Wait(4000);
            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            AutomationAgent.Click("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, unitNumber.ToString());

        }
        /// <summary>
        /// Clicks fixed assessment 
        /// </summary>
        /// <param name="FixedAssessmentNumber">Fixed ssessment number</param>
        public static void ClickFixedAssessmentNavigationArrow(int FixedAssessmentNumber)
        {
            WaitForPageToLoad();
            AutomationAgent.VerifyControlExists("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, FixedAssessmentNumber.ToString());
            AutomationAgent.Click("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, FixedAssessmentNumber.ToString());
            WaitForPageToLoad();
        }
        /// <summary>
        /// Gets text of Assessment Overview title page
        /// </summary>
        /// <returns>string: page title</returns>
        public static string GetTextFromAssessmentOverviewScreen()
        {
            WaitForPageToLoad();
            return AutomationAgent.GetControlText("AssessmentView", "AssessmentOverviewTitle");
        }
        /// <summary>
        /// Verifies Preview assessment link 
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyPreviewAssessmentLink()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "PreviewAssessmentLink");
        }
        /// <summary>
        /// Gets text of Preview Assessment Link
        /// </summary>
        /// <returns>string: Preview assessment text</returns>
        public static string GetPreviewAssessmentLinkText()
        {
            return AutomationAgent.GetControlText("AssessmentView", "PreviewAssessmentLink");
        }
        /// <summary>
        /// Clicks Preview assessment link
        /// </summary>
        public static void ClickPreviewAssessmentLinkButton()
        {
            AutomationAgent.Click("AssessmentView", "PreviewAssessmentButton");
            AutomationAgent.Wait(2000);
        }
        /// <summary>
        /// Verify Lesson Preview Screen
        /// </summary>
        /// <returns>bool: true(if found)</returns>
        public static bool VerifyLessonPreviewItemScreen()
        {
            AutomationAgent.Wait(5000);
            return AutomationAgent.VerifyControlExists("AssessmentView", "LessonPreviewItemScreen");
        }
        /// <summary>
        /// Verifies View Report button is active
        /// </summary>
        /// <returns>bool: true(if button active)</returns>
        public static bool VerifyViewReportButtonActive()
        {
            AutomationAgent.Wait(3000);
            return AutomationAgent.VerifyControlEnabled("AssessmentView", "ViewReportButton");
        }
        /// <summary>
        /// Verifies Release score button is active
        /// </summary>
        /// <returns>bool: true(if button active)</returns>
        public static bool VerifyReleaseScoreButtonActive()
        {
            AutomationAgent.Wait(5000);
            return AutomationAgent.VerifyControlEnabled("AssessmentView", "ReleaseScoreButton");
        }
        /// <summary>
        /// Clicks on Release score button 
        /// </summary>
        public static void ClickReleaseScoreButton()
        {
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("AssessmentView", "ReleaseScoreButton");
            AutomationAgent.Wait(500);
        }

        /// <summary>
        /// Verifies back button is present
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyBackButtonisDisplayed()
        {
            AutomationAgent.Wait(5000);
            return AutomationAgent.VerifyControlExists("AssessmentView", "BackButtonAssessment");
        }
        /// <summary>
        /// Clicks on back button
        /// </summary>
        public static void ClickBackButtonInAssessmentOverview()
        {
            AutomationAgent.Click("AssessmentView", "BackButtonAssessment");

            WaitForPageToLoad();
        }
        /// <summary>
        /// Verifies assessment manager page
        /// </summary>
        /// <returns>bool: true(if page displayed)</returns>
        public static bool VerifyAssessmentManagerScreen()
        {
            // WaitForPageToLoad();
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentManagerScreen");
        }
        /// <summary>
        /// Clicks on view report button
        /// </summary>
        public static void ClickViewReportButton()
        {
            AutomationAgent.Click("AssessmentView", "ViewReportButton");
        }
        /// <summary>
        /// GEts text of Assessment Result summary page title
        /// </summary>
        /// <returns>string: page title</returns>
        public static string GetTextFromAssessmentResultSummary()
        {
            return AutomationAgent.GetControlText("AssessmentView", "AssessmentResultSummaryReport");
        }
        /// <summary>
        /// Verifies Assessment Progress Overview Title in center
        /// </summary>
        /// <returns>bool: true(if title displayed in center)</returns>
        public static bool VerifyAssessmentProgressOverviewTitleInCentre()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int AssessmentOverviewX = AutomationAgent.GetControlPositionX("AssessmentView", "AssessmentOverviewTitle");
            int AssessmentOverviewWidth = AutomationAgent.GetControlWidth("AssessmentView", "AssessmentOverviewTitle");

            int diff = (ScreenSize / 2) - (AssessmentOverviewX + (AssessmentOverviewWidth / 2));
            if (diff == 0)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Verifies tools and Notifications icon
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyToolsAndNotificationsIconNavBar()
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "ToolsButtonNavBar") && AutomationAgent.VerifyControlExists("AssessmentView", "NotificationsIcon"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies Assessment overview title
        /// </summary>
        /// <returns>bool: true(if found)</returns>
        public static bool VerifyAssessmentOverviewTitle()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentOverviewTitle");
        }
        /// <summary>
        /// Gets the section name
        /// </summary>
        /// <returns>string: section name</returns>
        public static string GetSectionInAssessmentOverview()
        {
            return AutomationAgent.GetControlText("AssessmentView", "SectionName");
        }
        /// <summary>
        /// Gets the number of students
        /// </summary>
        /// <returns>string: Students</returns>
        public static string GetNumberOfStudentsInAssessmentOverview()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "NumberOfStudents");
            string[] s1 = s.Split('|');
            string studentsCount = s1[1].Replace("  ", "");
            return studentsCount;

        }
        /// <summary>
        /// Verifies the progress bar on screen
        /// </summary>
        /// <returns></returns>
        public static bool VerifyProgressBarInProgressOverview()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ProgressBarAssessment");
        }

        public static bool VerifyProgressTabsInProgressOverview()
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "NotStartedTab") &&
                AutomationAgent.VerifyControlExists("AssessmentView", "StartedTab") &&
                AutomationAgent.VerifyControlExists("AssessmentView", "SubmittedTab") &&
                AutomationAgent.VerifyControlExists("AssessmentView", "ScoredTab"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyScoreButton()
        {
            WaitForPageToLoad();
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreButton");
        }

        public static bool VerifyViewReportButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ViewReportButton");
        }

        public static bool VerifyReleaseScoresButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScoreButton");
        }

        public static bool VerifyUnlockAssessmentLink()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "UnlockAssessment");
        }

        public static void ClickUnlockAssessmentLink()
        {
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("AssessmentView", "UnlockAssessment");
        }

        public static bool VerifyLockUnlockOverlay()
        {
            AutomationAgent.Wait(1000);
            return AutomationAgent.VerifyControlExists("AssessmentView", "LockUnlockOverlayMessage");
        }

        public static void ClickDoneButtonUnlockOverlay()
        {
            AutomationAgent.Click("AssessmentView", "DoneButtonUnlockOverlay");
        }

        /// <summary>
        /// Teacher Unlocks a Student 
        /// </summary>
        public static string TeacherUnlocksAStudent(string AssessmentInDashboard, int studnetnumber)
        {
            AutomationAgent.Wait();
            ClickAssessmentInDashBoard(AssessmentInDashboard);
            //WaitForPageToLoad();
            AssessmentUnitSelection(10);
            ClickFixedAssessmentNavigationArrow(1);
            // WaitForPageToload(AssessmentAutomationAgent);
            string AssessmentName = GetAssessmentNameTitle();
            ClickUnlockAssessmentLink();
            ClickOnStudentName(studnetnumber);
            ClickDoneButtonUnlockOverlay();
            return AssessmentName;

        }

        public static string GetAssessmentNameTitle()
        {
            return AutomationAgent.GetControlText("AssessmentView", "AssessmentNameTitle");
        }
        /// <summary>
        /// Click on the student name
        /// </summary>
        public static void ClickOnStudentName(int student)
        {
            //TODO - Optimize this to click as per lock icon
            AutomationAgent.Wait();
            AutomationAgent.Click("AssessmentView", "StudentSelection", WaitTime.DefaultWaitTime, student.ToString());
        }

        public static void StudentAnswersAssessment(string status)
        {
            WaitForPageToLoad();
            //AutomationAgent.Wait(10000);
            ClickAssessmentTile();
            WaitForPageToLoad();
            //AutomationAgent.Wait(10000);
            //Check if Assessment is unlocked
            if (AssessmentTilePopUpFound())
            {
                ClickAssessmentStartButtonInPopUp();
                WaitForPageToLoad();
                //AutomationAgent.Wait(10000);


                string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');


                for (int i = Int32.Parse(Question[1]); i < Int32.Parse(Question[3]); i++)
                {
                    ClickAssessmentNextButton();
                }

                if (status.Equals("Started"))
                {

                    AutomationAgent.CloseApp();
                    AutomationAgent.LaunchApp();
                }
                else if (status.Equals("ReviewAndSubmit"))
                {
                    AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");
                    AutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");

                }
                else if (status.Equals("Submitted"))
                {
                    ClickSubmitButtonInLastQuestionOfAssessment();
                    NavigationCommonMethods.Logout();
                }

            }
        }

        public static void ClickSubmitButtonInLastQuestionOfAssessment()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");
            AutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");
            AutomationAgent.Click("AssessmentView", "SubmitAssessmentButton");
            String SubmitAssessmentTitle = AutomationAgent.GetControlText("AssessmentView", "SubmitAssessmentPopUpTitle");
            Assert.AreEqual("Submit Assessment", SubmitAssessmentTitle);
            AutomationAgent.Click("AssessmentView", "SubmitButtonPopup");

        }

        public static void ClickAssessmentNextButton()
        {
            AutomationAgent.Click("AssessmentView", "AssessmentNextButton");
            AutomationAgent.Wait(300);
        }
        public static void ClickPreviewAssessmentNextButton()
        {
            AutomationAgent.Click("AssessmentView", "PreviewAssessmentNextButton");
            AutomationAgent.Wait(300);
        }

        public static void ClickAssessmentTile()
        {
            AutomationAgent.Click("AssessmentView", "AssessmentLessonTile");
        }

        public static bool AssessmentTilePopUpFound()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StartAssessmentOverlay");
        }

        public static void ClickAssessmentStartButtonInPopUp()
        {
            AutomationAgent.Click("AssessmentView", "StartAssessmentButton");
        }

        public static void TeacherAtAssessmentManager(string AssessmentInDashboard)
        {
            AutomationAgent.Wait(5000);
            ClickAssessmentInDashBoard(AssessmentInDashboard);
            //WaitForPageToload(AssessmentAutomationAgent);
            AssessmentUnitSelection(10);
            //WaitForPageToload(AssessmentAutomationAgent);
        }
        /// <summary>
        /// Verify flag in student view
        /// </summary>
        public static bool VerifyFlagInStudentView()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FlagButton");
        }
        /// <summary>
        /// Verify timer in student view
        /// </summary>
        /// <returns>bool object: true if found</returns>
        public static bool VerifyTimerInStudentView()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "TimerButton");
        }

        public static void ClickTimerButtonInStudentView()
        {
            AutomationAgent.Click("AssessmentView", "AssessmentSummaryTestTimeButton");
        }

        public static bool VerifyTimerCollapsed(int TimerWidth)
        {
            int TimerCollapseWidth = AutomationAgent.GetControlWidth("AssessmentView", "AssessmentSummaryTestTimeButton");
            if (TimerWidth > TimerCollapseWidth)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static int GetTimerWidthExpanded()
        {
            int TimerWidthStudent = AutomationAgent.GetControlWidth("AssessmentView", "AssessmentSummaryTestTimeButton");
            return TimerWidthStudent;
        }

        public static void VerifyTimeElapsedStudentView()
        {
            string time1 = AutomationAgent.GetControlText("AssessmentView", "TimerText");
            AutomationAgent.Wait(3000);
            string time2 = AutomationAgent.GetControlText("AssessmentView", "TimerText");
            Assert.IsFalse(time1.Equals(time2));
        }

        public static bool VerifySummaryButtonInStudentView()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "SummaryButton");
        }

        public static string StudentTapsReviewAndSubmitButton()
        {
            AutomationAgent.Wait(10000);
            ClickAssessmentTile();
            AutomationAgent.Wait(10000);
            //Check if Assessment is unlocked
            if (AssessmentTilePopUpFound())
            {
                ClickAssessmentStartButtonInPopUp();
                AutomationAgent.Wait(10000);


                string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');


                for (int i = Int32.Parse(Question[2]); i < Int32.Parse(Question[6]); i++)
                {
                    ClickAssessmentNextButton();
                }
                AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");
                AutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");
                return Question[6];

            }
            else
            {
                return "false";
            }

        }

        public static bool VerifyAssessmentSummaryScreenStudentView()
        {

            AutomationAgent.Wait(2000);
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentSummaryTitle");
        }

        public static void WaitForPageToLoad()
        {
            AutomationAgent.Wait();
            for (int i = 0; i < 5; i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "PageLoadImage"))
                {
                    AutomationAgent.Wait(10000);
                }
                else
                {
                    break;
                }
            }
        }

        public static void ClickScoreButton()
        {
            AutomationAgent.Click("AssessmentView", "ScoreButton");
            WaitForPageToLoad();
        }


        public static bool VerifyScoringOverviewPage()
        {
            WaitForPageToLoad();
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoringOverviewTitle");
        }

        public static void ClickOnScoreBox(string scoreBoxValue = "1")
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, scoreBoxValue))
            {
                AutomationAgent.Click("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, scoreBoxValue);
            }
            else
            {
                AutomationAgent.Click("AssessmentView", "ScoreBoxFilled", WaitTime.DefaultWaitTime, scoreBoxValue);
            }
            WaitForPageToLoad();
        }

        public static bool VerifyScoringPanel()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ItemScoringTitle");
        }

        public static void ClickOnCrossIcon()
        {
            AutomationAgent.Click("AssessmentView", "CrossButton");
        }

        public static void ClickYesButtonInPopup()
        {
            AutomationAgent.Click("AssessmentView", "YesButtonPopup");
            WaitForPageToLoad();
        }

        public static void ClickOnTotalScoreButton()
        {
            AutomationAgent.Click("AssessmentView", "TotalScoreButton");
        }

        public static bool VerifyScoreFlyoutMenu()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreFlyoutPopup");
        }

        public static bool VerifyDashOptionInFlyout()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "DashButton");
        }

        public static void GiveTotalScoreToStudent(string score)
        {
            AutomationAgent.Click("AssessmentView", "ScoreValue", WaitTime.DefaultWaitTime, score);
        }

        public static bool VerifyStudentIsScored(string ScoreBoxValue = "1")
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxFilled", WaitTime.DefaultWaitTime, ScoreBoxValue);
        }

        public static bool VerifyCloseButtonOnScoringScreen()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CrossButton");
        }

        public static bool VerifyStopScoringPopupScreen()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StopScoringPopup");
        }

        public static bool VerifyYesButtonInStopScoringPopup()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "YesButtonPopup");
        }

        public static bool VerifyStopScoringTextInStopScoringPopup()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StopScoringText");
        }

        public static void ClickNOButtonInStopScoringPopup()
        {
            AutomationAgent.Click("AssessmentView", "NOButtonPopup");
        }
        public static bool VerifyNOButtonInStopScoringPopup()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NOButtonPopup");
        }

        public static void ClickCriterionButtonScore()
        {
            AutomationAgent.Click("AssessmentView", "RubricCriterion_Button");
        }

        public static string GetCriterionButtonScore()
        {
            return AutomationAgent.GetControlText("AssessmentView", "RubricCriterion_Button");
        }

        public static void SelectCriterionButtonScore(string score)
        {

            AutomationAgent.Click("AssessmentView", "ScoreRadioButton", WaitTime.DefaultWaitTime, score);
        }

        public static bool VerifyCriterionLevelScoreDisplaysAllNumbers()
        {
            return (
             AutomationAgent.VerifyControlExists("AssessmentView", "ScoreRadioButton", WaitTime.DefaultWaitTime, "--") &&
             AutomationAgent.VerifyControlExists("AssessmentView", "ScoreRadioButton", WaitTime.DefaultWaitTime, "1") &&
             AutomationAgent.VerifyControlExists("AssessmentView", "ScoreRadioButton", WaitTime.DefaultWaitTime, "2") &&
             AutomationAgent.VerifyControlExists("AssessmentView", "ScoreRadioButton", WaitTime.DefaultWaitTime, "3")
             );

        }


        public static void ClickSubmittedInStopScoringScreen()
        {
            AutomationAgent.Click("AssessmentView", "SubmittedStopScoringScreen");
        }

        public static string VerifyNumberofStudentsAvailableInSubmitted()
        {
            return AutomationAgent.GetControlText("AssessmentView", "SubmittedStopScoringScreen");
        }

        public static string VerifyNumberofStudentsAvailableInSubmittedAssessmentOverview()
        {
            return AutomationAgent.GetControlText("AssessmentView", "SubmittedTab");
        }

        public static string GetSubtitleofScoringOverview()
        {
            return AutomationAgent.GetControlText("AssessmentView", "ScoringOverviewSubtitle");
        }

        public static bool VerifyAssessmentNameInStopScoringScreen(string subtitle)
        {
            return AutomationAgent.VerifyAppChildrenByName(subtitle);
        }

        public static void ClickNotStartedInStopScoringScreen()
        {
            AutomationAgent.Click("AssessmentView", "NotStartedStopScoringScreen");
        }

        public static string VerifyNumberofStudentsAvailableInNotStarted()
        {
            return AutomationAgent.GetControlText("AssessmentView", "NotStartedStopScoringScreen");
        }
        public static string VerifyNumberofStudentsAvailableInNotStartedAssessmentOverview()
        {
            return AutomationAgent.GetControlText("AssessmentView", "NotStartedTab");
        }

        public static void ClickStartedInStopScoringScreen()
        {
            AutomationAgent.Click("AssessmentView", "StartedStopScoringScreen");
        }

        public static string VerifyNumberofStudentsAvailableInStarted()
        {
            return AutomationAgent.GetControlText("AssessmentView", "StartedStopScoringScreen");
        }
        public static string VerifyNumberofStudentsAvailableInScored()
        {
            return AutomationAgent.GetControlText("AssessmentView", "ScoredStopScoringScreen");
        }
        public static string VerifyNumberofStudentsAvailableInStartedAssessmentOverviewScreen()
        {
            return AutomationAgent.GetControlText("AssessmentView", "StartedTab");
        }
        public static bool VerifyStudentNameAvailableInNotStarted()
        {
            string[] childrenNames = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentListInGridView");
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentListInGridView");
        }
        public static bool VerifyStudentNameAvailableInStarted()
        {
            string[] childrenNames = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentListInGridView");
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentListInGridView");
        }
        public static int GetCountOfStudentNamesAvailableInStarted()
        {
            return AutomationAgent.GetChildrenControlCount("AssessmentView", "StudentListInGridView");

        }

        public static bool VerifyStudentNameAvailableInScored()
        {
            string[] childrenNames = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentListInGridView");
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentListInGridView");
        }

        public static bool VerifyStudentNameAvailableInSubmitted()
        {
            string[] childrenNames = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentListInGridView");
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentListInGridView");
        }

        public static bool VerifyAssessmentProgressOverviewPage()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentOverviewTitle");
        }


        public static bool VerifyListOfAllTheItemsAvailableinUnitTitleDropDown()
        {
            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            int count = 1;
            for (count = 1; count <= 10; count++)
            {
                if (!AutomationAgent.VerifyChildrensChildControlByName("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, count.ToString(), "Unit"))
                    break;
            }
            if (count < 10)
                return false;

            else
                return true;
        }

        public static bool VerifyAssessmentUnitSelection(int unitNumber)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, unitNumber.ToString());
        }

        public static void OpenUnitSelectionDropDown()
        {
            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
        }

        public static bool VerifyUserIsNavigatedToUnit(int unitnumber)
        {
            WaitForPageToLoad();
            string[] titletext = AutomationAgent.GetChildrenControlNames("AssessmentView", "UnitTitleDropDownButton");
            return titletext[0].Contains(unitnumber.ToString());
        }
        public static bool VerifyFlagButtonIsVisible()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FlagButton");
        }

        public static bool VerifyPreviousButtonInAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "PreviousButton");
        }
        public static bool VerifyPreviousButtonInPreviewAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "PreviewAssessmentPreviousButton");
        }

        public static bool VerifyPreviousButtonInScoring()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "PreviousButtonInScoring");
        }

        public static bool VerifyNextButtonInScoring()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NextButtonInScoring");
        }

        public static bool VerifyAndMoveToFirstItemOfAssessment()
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "PreviousButton"))
            {
                string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');

                for (int i = 1; i < Int32.Parse(Question[2]); i++)
                {
                    ClickAssessmentPreviousButton();
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public static void ClickAssessmentPreviousButton()
        {
            AutomationAgent.Click("AssessmentView", "PreviousButton");
        }
        public static void ClickPreviewAssessmentPreviousButton()
        {
            AutomationAgent.Click("AssessmentView", "PreviewAssessmentPreviousButton");
        }

        public static void ClickScoringPreviousButton()
        {
            AutomationAgent.Click("AssessmentView", "PreviousButtonInScoring");
        }
        public static void ClickScoringNextButton()
        {
            AutomationAgent.Click("AssessmentView", "NextButtonInScoring");
        }

        public static void ClickOnSummaryButton()
        {
            AutomationAgent.Click("AssessmentView", "SummaryButton");
            AutomationAgent.Wait(5000);
        }

        public static void VerifyNextAndPreviousButtonInAssessment()
        {
            AutomationAgent.Wait(5000);
            AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentNextButton");
            ClickAssessmentNextButton();
            VerifyPreviousButtonInAssessment();
        }
        public static bool VerifyReviewAndSumbitButtonExist()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');


            for (int i = Int32.Parse(Question[2]); i < Int32.Parse(Question[6]); i++)
            {
                ClickAssessmentNextButton();
            }
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");
        }

        public static bool VerifyReviewAndSumbitButton()
        {
            AutomationAgent.Wait(10000);
            ClickAssessmentTile();
            AutomationAgent.Wait(10000);
            //Check if Assessment is unlocked
            if (AssessmentTilePopUpFound())
            {
                ClickAssessmentStartButtonInPopUp();
                AutomationAgent.Wait(10000);


                string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');


                for (int i = Int32.Parse(Question[2]); i < Int32.Parse(Question[6]); i++)
                {
                    ClickAssessmentNextButton();
                }
                return AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");
            }
            else
                return false;
        }

        public static string GetNameOfTheAssessmentStart(int tile = 1)
        {
            string[] str = AutomationAgent.GetChildrenControlNames("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, tile.ToString());
            return str[0];
        }

        public static bool VerifyAssessmentAfterStudentSumbitTheAssessment(string name)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmnetNameAfterSumbitAssess", WaitTime.DefaultWaitTime, name);
        }

        public static void ClickSubmitButton()
        {
            AutomationAgent.Click("AssessmentView", "SubmitAssessmentButton");
            AutomationAgent.Wait(200);
        }

        public static bool VerifySubmitOverlay()
        {
            String SubmitAssessmentTitle = AutomationAgent.GetControlText("AssessmentView", "SubmitAssessmentPopUpTitle");
            Assert.AreEqual("Submit Assessment", SubmitAssessmentTitle);
            return (AutomationAgent.VerifyControlExists("AssessmentView", "SubmitButtonPopup") && AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentDialogCancelButton"));

        }

        public static void ClickCancelButtonOnSubmitAssessmentPopUp()
        {
            AutomationAgent.Click("AssessmentView", "AssessmentDialogCancelButton");
        }

        public static void ClickOnSubmitButtonOnSubmitButtonPopUp()
        {
            AutomationAgent.Click("AssessmentView", "SubmitButtonPopup");
        }

        /// <summary>
        /// Verify items with no responses on assessment summary screen
        /// </summary>
        /// <param name="total_Question"></param>
        public static void VerifyItemsWithNoResponsesOnAssessSummaryScreen(string total_Question)
        {
            for (int i = 1; i <= Int32.Parse(total_Question); i++)
            {
                string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "QuestionTileButtonInSummaryScreen", WaitTime.DefaultWaitTime, i.ToString());
                Assert.AreEqual(status[1], "Unanswered", "One of the ClickSubmitButtonInLastQuestionOfAssessment is answered");
            }
        }

        public static void TeacherAssessmentNavigation()
        {
            ClickAssessmentTile();
            AutomationAgent.Wait(10000);
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestionsTestPreview")).Split(' ');
            for (int i = Int32.Parse(Question[2]); i < Int32.Parse(Question[6]); i++)
            {
                ClickAssessmentNextButtonTestPreview();
            }
        }

        public static void ClickAssessmentNextButtonTestPreview()
        {
            AutomationAgent.Click("AssessmentView", "AssessmentNextButtonTestPreview");
        }

        public static bool VerifyStaticTextNearReleaseScores()
        {
            string ReleaseScoresText = AutomationAgent.GetControlText("AssessmentView", "NumberOfStudentsToReleaseScores");
            string StaticTextReleaseScores = Regex.Replace(ReleaseScoresText, "[0-9]", "#");
            Assert.AreEqual("Score # more to Release Scores", StaticTextReleaseScores);
            return AutomationAgent.VerifyControlExists("AssessmentView", "NumberOfStudentsToReleaseScores");
        }

        public static bool VerifyReleaseScoreButtonActiveScoringOverview()
        {
            return AutomationAgent.VerifyControlEnabled("AssessmentView", "ReleaseScoresScoringOverview");
        }
        public static void ClickReleaseScoreButtonActiveScoringOverview()
        {
            AutomationAgent.Click("AssessmentView", "ReleaseScoresScoringOverview");
        }

        public static bool VerifyLessThan80PercentObservationScored()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "ScoreProgressPercentage");
            string[] s1 = s.Split(' ');
            string Score = s1[0];
            int ScorePercentage = Int32.Parse(Score);
            if (ScorePercentage < 80)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetRubricHideButtonText()
        {
            return AutomationAgent.GetControlText("AssessmentView", "HideButtonText");
        }

        public static bool VerifyRubricHideButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "HideButtonText");
        }

        public static void ClickRubricHideButton()
        {
            AutomationAgent.Click("AssessmentView", "HideButtonRubric");
        }
        public static void ClickRubricHideButtonOnScoringScreen()
        {
            AutomationAgent.Click("AssessmentView", "HideButtonRubricInScoringScreen");
        }

        public static string GetRubricButtonText()
        {
            return AutomationAgent.GetControlText("AssessmentView", "RubricButtonText");
        }

        public static bool VerifyRubricButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RubricButtonText");
        }

        public static bool VerifyRubricIsOpen()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreListView");
        }

        public static bool VerifyAssessmentReportPage()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentResultSummaryReport");
        }

        public static bool VerifyRefreshIcon()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RefreshButton");
        }

        public static bool VerifyRefreshIconAtTopRight()
        {
            int RefreshPosX = AutomationAgent.GetControlPositionX("AssessmentView", "RefreshButton");
            int RefreshPosY = AutomationAgent.GetControlPositionY("AssessmentView", "RefreshButton");

            if (RefreshPosX < 1320 && RefreshPosY < 90)
                return true;

            else
                return false;
        }

        public static void ClickRefreshIcon()
        {
            AutomationAgent.Click("AssessmentView", "RefreshButton");
            WaitForPageToLoad();
        }

        public static string GetLastUpdatedDate()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "LastUpdatedDateAndTime");
            string[] s1 = s.Split(' ');
            string dateDisplayed = s1[0];
            return dateDisplayed;
        }

        public static string GetLastUpdatedTime()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "LastUpdatedDateAndTime");
            string[] s1 = s.Split(' ');
            string timeDisplayed = s1[2] + " " + s1[3];
            return timeDisplayed;
        }

        public static bool VerifyLastUpdatedSection()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "TeacherOverviewLastUpdatedTxtBlock");
        }

        public static string GetQuestionNumberFromTile(int random)
        {
            string[] questionnumbertile = AutomationAgent.GetChildrenControlNames("AssessmentView", "QuestionTileButtonInSummaryScreen", WaitTime.DefaultWaitTime, random.ToString());
            string[] questionnumber = questionnumbertile[0].Split(' ');
            return questionnumber[1];
        }

        public static string GetCurrentQuestionNo()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');

            return Question[2];
        }
        /// <summary>
        /// Click On Question Tile
        /// </summary>
        /// <param name="random"></param>
        public static void ClickOnQuestionTile(int random)
        {
            AutomationAgent.Click("AssessmentView", "TileInAssessSummaryScreen", WaitTime.DefaultWaitTime, random.ToString());
        }


        public static string[] GetBottomTextAboutQuestionStatus()
        {
            return AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestionsTestPreview").Split(' ');
        }


        public static bool VerifySubmitButtonInLastQuestionOfAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");
        }
        public static void ClickReviewAndSubmitButton()
        {
            AutomationAgent.Click("AssessmentView", "ReviewAndSubmitIsPresent");
        }

        /// <summary>
        /// Verify previous button active/inactive on the first question
        /// </summary>
        public static bool VerifyPreviousButtonActiveOnTheFirstQuestion()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');


            if (Question[2] == "1")
                return VerifyPreviousButtonInPreviewAssessment();

            else
            {

                while (VerifyPreviousButtonInPreviewAssessment())
                {

                    ClickPreviewAssessmentPreviousButton();
                }
                return VerifyPreviousButtonInPreviewAssessment();
            }
        }

        public static bool VerifyCountDecrementsAfterTappingPreviousButton()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
            if (Question[2] == "1")
            {
                ClickPreviewAssessmentNextButton();
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                ClickPreviewAssessmentPreviousButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) > Int32.Parse(Question2[2]));

            }

            else
            {
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                ClickPreviewAssessmentPreviousButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) > Int32.Parse(Question2[2]));


            }
        }

        public static bool VerifyCountIncrementsAfterTappingNextButton()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
            if (Question[2] == "4")
            {
                ClickPreviewAssessmentPreviousButton();
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                ClickPreviewAssessmentNextButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) < Int32.Parse(Question2[2]));

            }

            else
            {
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                ClickPreviewAssessmentNextButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) < Int32.Parse(Question2[2]));


            }
        }


        /// <summary>
        /// Click on close button
        /// </summary>
        public static void ClickOnCloseButton()
        {
            AutomationAgent.Click("AssessmentView", "CloseButton");
            if (AutomationAgent.VerifyControlExists("AssessmentView", "CloseButton"))
            {
                AutomationAgent.Click("AssessmentView", "CloseButton");
            }
        }
        /// <summary>
        /// Click on pending assessment
        /// </summary>
        public static void ClickOnPendingAssessmentLink()
        {
            AutomationAgent.Click("AssessmentView", "");
        }
        /// <summary>
        /// Fixed assessment tab not found
        /// </summary>
        /// <returns></returns>
        public static bool VerifyFixedAssessmentTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FixedAssessmentLink");
        }
        /// <summary>
        /// Verify Ongoing Assessments Tab
        /// </summary>
        /// <returns></returns>
        public static bool VerifyOnGoingAssessmentsTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "OnGoingLink");
        }

        public static void ClickOnUACheckList()
        {
            AutomationAgent.Click("AssessmentView", "UACheckList");
            WaitForPageToLoad();
        }
        /// <summary>
        /// Get the unit name and number
        /// </summary>
        public static string[] GetUnitNameANdNumber()
        {
            string[] UnitNumberName = AutomationAgent.GetChildrenControlNames("AssessmentView", "UnitTileFirst");
            return UnitNumberName;

        }
        /// <summary>
        /// Get text from the assessmnet unit title
        /// </summary>
        /// <returns></returns>
        public static string[] GetTextFromAssessmentUnitTile()
        {
            string[] UnitNumberName = AutomationAgent.GetChildrenControlNames("AssessmentView", "UnitTitleDropDownButton");
            return UnitNumberName;

        }
        /// <summary>
        /// Verify assesssment manger screen is scrollable
        /// </summary>
        public static bool VerifyAssessmentManagerScreenScrollable(int FixedAssessmentNumber)
        {

            AssessmentCommonMethods.SwipeUp();
            return AssessmentCommonMethods.VerifyFixedAssessmentNavigationArrow(FixedAssessmentNumber);
        }
        /// <summary>
        /// Verify fixed assessment navigation arrow
        /// </summary>
        /// <param name="p"></param>
        public static bool VerifyFixedAssessmentNavigationArrow(int FixedAssessmentNumber)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, FixedAssessmentNumber.ToString());
        }
        /// <summary>
        /// Swipes Screen to up
        /// </summary>
        public static void SwipeUp()
        {
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(567, 983, 620, 250);
        }
        /// <summary>
        /// Verify assessment button in dashboard
        /// </summary>
        /// <param name="p"></param>
        public static bool VerifyAssessmentButtonInDashBoard(string sectionAndPeriod)
        {
            AutomationAgent.Wait();

            if (AutomationAgent.VerifyControlExists("AssessmentView", "DashboardHubSection", WaitTime.DefaultWaitTime, 3.ToString()))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentsButton", WaitTime.DefaultWaitTime, 3.ToString());

            }
            else
            {
                return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentsButton", WaitTime.DefaultWaitTime, 2.ToString());

            }
        }

        /// <summary>
        /// Verify Cancel button on Start Assessment PopUp
        /// </summary>
        public static void VerifyCancelButtonOnStartAssessmentPopUp()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "CancelAssessmentButton", WaitTime.DefaultWaitTime, "");
        }
        /// <summary>
        /// Verify Start button on Start Assessment PopUp
        /// </summary>
        public static bool VerifyStartButtonOnStartAssessmentPopUp()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StartAssessmentButton", WaitTime.DefaultWaitTime, "");
        }
        /// <summary>
        /// Click Cancel button on Start Assessment PopUp
        /// </summary>
        public static void ClickCancelButtonOnStartAssessmentPopUp()
        {
            AutomationAgent.Click("AssessmentView", "CancelAssessmentButton");
        }


        public static void ClickUnlockAllStudentInUnlockAssessment()
        {
            if (VerifyLockAllStudentInUnlockAssessment())
            {
                ClickLockAllStudentInUnlockAssessment();
                AutomationAgent.Wait(3000);
            }
            AutomationAgent.Wait();
            AutomationAgent.Click("AssessmentView", "UnlockAllButton");
            AutomationAgent.Wait(3000);
        }

        public static bool VerifyUnlockAllStudentInUnlockAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "UnlockAllButton");
        }

        public static string GetCurrentStatusOfAssessmentLock()
        {
            AutomationAgent.Wait(1000);
            string[] childnames = AutomationAgent.GetChildrenControlNames("AssessmentView", "UnlockAssessment");
            return childnames[0];
        }

        public static bool VerifyLockAllStudentInUnlockAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "LockAllButton");
        }

        public static void ClickLockAllStudentInUnlockAssessment()
        {

            if (VerifyUnlockAllStudentInUnlockAssessment())
            {
                ClickUnlockAllStudentInUnlockAssessment();
                AutomationAgent.Wait(3000);
            }
            AutomationAgent.Wait();
            AutomationAgent.Click("AssessmentView", "LockAllButton");
            AutomationAgent.Wait(3000);
        }

        public static bool VerifyAssessmentNextButtonTestPreview()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentNextButtonTestPreview");
        }

        public static bool VerifyStandardsButtonAvailableinAssessmentPreview()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StandardsButtonAssessmentPreview");
        }

        public static void ClickStandardsButtonAvailableinAssessmentPreview()
        {
            AutomationAgent.Click("AssessmentView", "StandardsButtonAssessmentPreview");
        }

        public static bool VerifyRubricIsAvailableOnScreen()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "HideButtonRubric");
        }

        public static bool VerifyAssessmentOverviewContainsSectionName(string sectioName)
        {
            return AutomationAgent.VerifyAppChildrenByName(sectioName);
        }

        public static bool VerifyAssessmentOverviewContainsNumberOfStudents()
        {
            string studentstxt = AutomationAgent.GetControlText("AssessmentView", "AssessmentOverviewSectionNameAndStudentNo", WaitTime.DefaultWaitTime, "8");
            return studentstxt.Contains("Students");
        }

        public static bool VerifyNoStudentsLabel()
        {
            return AutomationAgent.VerifyAppChildrenByName("No Students");
        }
        /// <summary>
        /// Clicks on Started Progress Tab in Assessment Overview Screen
        /// </summary>
        public static void ClickStartedInAssessmentOverviewScreen()
        {
            AutomationAgent.Click("AssessmentView", "StartedTab");
        }
        /// <summary>
        /// Clicks on Not Started Progress Tab in Assessment Overview Screen
        /// </summary>
        public static void ClickNotStartedInAssessmentOverviewScreen()
        {
            AutomationAgent.Click("AssessmentView", "NotStartedTab");
        }
        /// <summary>
        /// Clicks on Submitted Progress Tab in Assessment Overview Screen
        /// </summary>
        public static void ClickSubmittedInAssessmentOverviewScreen()
        {
            AutomationAgent.Click("AssessmentView", "SubmittedTab");
        }
        /// <summary>
        /// Clicks on Scored Progress Tab in Assessment Overview Screen
        /// </summary>
        public static void ClickScoredInAssessmentOverviewScreen()
        {
            AutomationAgent.Click("AssessmentView", "ScoredTab");
        }


        public static bool VerifyObservationScoreCardActive()
        {
            ClickOnScoreBox();
            return !VerifyScoringOverviewPage();
        }

        public static bool VerifyCheckListScoringScreen()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CheckList");
        }

        public static bool VerifyObservationOneGetOpen()
        {
            AutomationAgent.Wait(2000);
            string observation_number = AutomationAgent.GetControlText("AssessmentView", "Observation1Checklist");
            return observation_number.Contains("#1");
        }

        public static void ClickNextStudentButton()
        {
            AutomationAgent.Click("AssessmentView", "RubricScoringNextStudentButton");
        }
        /// <summary>
        /// Verify screen behind spinner is inactive
        /// </summary>
        /// <returns></returns>
        public static bool VerifyScreenBehindSpinnerIsInactive()
        {
            int count = 0;
            bool trueorfalse = false;
            ClickRefreshIcon();
            while (AutomationAgent.VerifyControlExists("AssessmentView", "PageLoadImage") && count <= 5)
            {
                ClickBackButtonInAssessmentOverview();
                count++;
                trueorfalse = !VerifyAssessmentManagerScreen();
            }

            return trueorfalse;

        }

        public static bool VerifyScreenBehindSpinnerIsInactiveAssessManagerScreen()
        {
            int count = 0;
            bool trueorfalse = false;
            ClickRefreshIcon();
            while (AutomationAgent.VerifyControlExists("AssessmentView", "PageLoadImage") && count <= 5)
            {
                ClickBackButtonInAssessmentOverview();
                count++;
                trueorfalse = !DashboardCommonMethods.VerifyUserIsOnDashBoard();
            }

            return trueorfalse;
        }

        public static bool VerifyScreenBehindSpinnerIsInactiveInScoringOverview()
        {
            int count = 0;
            bool trueorfalse = false;
            ClickRefreshIcon();
            while (AutomationAgent.VerifyControlExists("AssessmentView", "PageLoadImage") && count <= 5)
            {
                ClickBackButtonInAssessmentOverview();
                count++;
                trueorfalse = !AssessmentCommonMethods.VerifyAssessmentProgressOverviewPage();
            }

            return trueorfalse;
        }
        public static void ClickOnUARubric()
        {
            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UARubric");
            WaitForPageToLoad();
        }

        public static bool VerifyNextButtonInAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentNextButton");
        }

        public static bool VerifyTestPlayerOpenInWebView()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "TestPlayerWebView");
        }

        public static void VerifyQuestionFirstDisplayed()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentQuestion1");
        }

        public static void VerifyQuestionSecondDisplayed()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentQuestion2");
        }

        public static void VerifyNavigationInTestPlayer()
        {
            VerifyNextButtonInAssessment();
            VerifyQuestionFirstDisplayed();
            ClickAssessmentNextButton();
            VerifyPreviousButtonInAssessment();
            VerifyQuestionSecondDisplayed();
        }

        public static void VerifyAssessmentTitlePresent()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentNameTitle");
        }
        public static void VerifyDateAndTimeFromScoringOverviewScreen()
        {
            string datetime = AutomationAgent.GetControlText("AssessmentView", "TeacherScoringOverviewLastUpdatedAtTxtBlock");
            string values = datetime.Replace("at", "");
            DateTime time = DateTime.Parse(values);
        }

        public static bool VerifyScoredCategory()
        {
            while (!AutomationAgent.VerifyControlExists("AssessmentView", "TeacherScoringOverviewNumberOfScoredTxtBlock"))
            {
                AssessmentCommonMethods.SwipeUp();

            }
            return true;


        }

        public static bool VerifyNotScoredCategory()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "TeacherScoringOverviewNOtScoredCategoryTxtBlock");
        }

        public static bool VerifyChecklistInCentreOfScreen()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int ChecklistX = AutomationAgent.GetControlPositionX("AssessmentView", "CheckListView");
            int ChecklistWidth = AutomationAgent.GetControlWidth("AssessmentView", "CheckListView");

            int diff = (ScreenSize / 2) - (ChecklistX + (ChecklistWidth / 2));
            if (diff == 0)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Verify Observation CheckList in the preview assessment link
        /// </summary>
        /// <returns></returns>
        public static bool VerifyObservationChecklist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "observationChecklist");
        }


        public static bool VerifyPreviousButtonINActiveOnTheFirstQuestionOfScoringScreen()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
            while (!Question[2].Equals("1"))
            {

                ClickScoringPreviousButton();
                Question = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
            }
            return !VerifyPreviousButtonInScoring();

        }

        public static bool VerifyNextButtonNotAvailableOnTheLastQuestionOfScoring()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenQuestionLabel")).Split(' ');
            for (int i = Int32.Parse(Question[1]); i <= Int32.Parse(Question[3]); i++)
            {
                ClickScoringNextButton();
            }
            return VerifyNextButtonInScoring();
        }


        public static void ClickOnShowSampleAnswerButton()
        {
            AutomationAgent.Click("AssessmentView", "SampleAnswerButton");
        }

        public static bool VerifyCrossButtonOnShowSampleAnswerModal()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CLoseButtonOnshowSamplModal");
        }

        public static void ClickOnCrossButtonOnShowSampleAnswerModal()
        {
            AutomationAgent.Click("AssessmentView", "CLoseButtonOnshowSamplModal");
        }

        public static bool VerifySampleAnswerPopUp()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "SampleAnswerDisplay");
        }

        public static bool VerifyTitleOfLockUnlockOverlay(string AssessmentName)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "TitleLockUnlockOverlay", WaitTime.DefaultWaitTime, AssessmentName);
        }

        public static string GetAssessmentNameTitleOnLockOverlay()
        {
            string name = AutomationAgent.GetControlText("AssessmentView", "TitleLockUnlockOverlay");
            return name;
        }

        public static void VerifyTimerContinuesInAssessmentSummaryScreen()
        {
            string time1 = AutomationAgent.GetControlText("AssessmentView", "TimerText");
            ClickOnSummaryButton();

            string time2 = AutomationAgent.GetControlText("AssessmentView", "AssessmentSummaryTestTimeButton");
            Assert.IsFalse(time1.Equals(time2));
        }

        public static bool VerifySubmitButtonAtRightCorner()
        {
            int xPos = AutomationAgent.GetControlPositionX("AssessmentView", "SubmitAssessmentButton");
            int yPos = AutomationAgent.GetControlPositionY("AssessmentView", "SubmitAssessmentButton");

            if (xPos >= 1000 && yPos <= 900)
                return true;
            else
                return false;
        }

        public static string TotalNoOfQuestionsInAssessment()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');

            return Question[6];
        }

        public static void VerifyQuestionNumbersInSummary(string total_Question)
        {

            for (int i = 1; i <= Int32.Parse(total_Question); i++)
            {
                string[] questionnumbertile = AutomationAgent.GetChildrenControlNames("AssessmentView", "QuestionTileButtonInSummaryScreen", WaitTime.DefaultWaitTime, i.ToString());
                Assert.AreEqual(questionnumbertile[0], ("Question " + i));
            }
        }

        public static void ClickFlagButton()
        {
            AutomationAgent.Click("AssessmentView", "FlagButton");
        }

        public static string GetFlagText()
        {
            string[] a = AutomationAgent.GetControlText("AssessmentView", "AnswerUanswerFlagText").Split(' ');
            return a[3];
        }

        public static void VerifySubTitleInSummaryPage()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "SummaryAssessmentSubTitle");
            AutomationAgent.VerifyControlExists("AssessmentView", "SummaryAssessmentSubTitleMessage");
        }

        public static bool VerifyLoadingIcon()
        {
            //To do , image fluctuation is variable.
            // return AutomationAgent.VerifyControlExists("AssessmentView", "PageLoadImage");
            return true;
        }

        public static bool VerifyRemoveFlagChangesItemState()
        {
            ClickFlagButton();
            string s = AutomationAgent.GetControlText("AssessmentView", "FlagButtonText");
            ClickFlagButton();
            string s2 = AutomationAgent.GetControlText("AssessmentView", "FlagButtonText");
            if (s.Equals(s2))
                return false;
            else
                return true;
        }

        public static bool VerifyFlaggedItem()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "FlagButtonText");
            if (s.Equals("REMOVE FLAG"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies The White colour of the Review Button 
        /// </summary>
        /// <param name="sampleColor">Color provided</param>
        /// <returns>bool: true(if sample color matches control color), false(if not)</returns>
        public static bool VerifyReviewButtonColorWhite(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ReviewAndSubmitIsPresent", sampleColor);
        }
        /// <summary>
        /// Verifies the Black colour of the Review Button's Text
        /// </summary>
        /// <param name="sampleColor1">Color provided</param>
        /// <returns>bool: true(if sample color matches control color), false(if not)</returns>
        public static bool VerifyReviewTextColorBlack(System.Drawing.Color sampleColor1)
        {
            bool a = AutomationAgent.VerifyControlExists("AssessmentView", "ReviewAndSubmitIsPresent");



            bool ColorCompare = false;
            AutomationAgent.ClickAndVerifyColorOfChildrenByInstance("AssessmentView", "ReviewAndSubmitText", sampleColor1, out ColorCompare, WaitTime.DefaultWaitTime, "", 3);
            return ColorCompare;
        }
        /// <summary>
        /// Verifies No Internet Connection Message Displays When Student tries to Submit the assessment Offline
        /// </summary>
        /// <returns>bool: true(if message present), false(if message not present)</returns>
        public static bool VerifyNoInternetSubmitAssessmentMsg()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NoInternetMsgSubmitAssessment");
        }
        /// <summary>
        /// Clicks on OK Button
        /// </summary>
        public static void ClickOKButton()
        {
            AutomationAgent.Click("CommonReadView", "WorkWillBeSentOKButton");
        }

        public static int GetUnansweredText()
        {
            string[] a = AutomationAgent.GetControlText("AssessmentView", "AnswerUanswerFlagText").Split(' ');
            return Int32.Parse(a[0]);
        }

        public static void TapAnyABCDChoiceInQuestion()
        {
            AutomationAgent.Wait(300);
            AutomationAgent.Click(483, 441);
            AutomationAgent.Wait(300);
        }
        /// <summary>
        /// Verify AnswersTab In Preview Screen of UARubric
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyAnswersTabInPreviewScreenUARubric()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AnswersTab");
        }

        /// <summary>
        /// Click Preview Assessment Link
        /// </summary>
        public static void ClickPreviewAssessmentLink()
        {
            AutomationAgent.Click("AssessmentView", "PreviewAssessmentLink");
        }
        /// <summary>
        /// Verify Questions Tab In Preview Screen of UARubric
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyQuestionsTabInPreviewScreenUARubric()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "QuestionsTab");
        }
        /// <summary>
        /// Verify Previous Button In Preview Screen Of UA Rubric
        /// </summary>
        /// <returns></returns>
        public static bool VerifyPreviousButtonInPreviewScreenOfUARubric()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "PreviousButton");
        }
        /// <summary>
        /// Verify NextButton In Preview Screen Of UARubric
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNextButtonInPreviewScreenOfUARubric()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentNextButton");
        }
        /// <summary>
        /// Verifies Flag button color is blue or not
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(is sample color matches), false (if not)</returns>
        public static bool VerifyFlagColorBlue(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "FlagButton", sampleColor);
        }
        /// <summary>
        /// Verify corresponding question number get open
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool VerifyCorrespondingQuestionNumberOpen(string questionno)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "QuestionNumber", WaitTime.DefaultWaitTime, questionno);
        }

        public static bool VerifyTwoViewsOnScoringReviewPage()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "QuestionTab") && AutomationAgent.VerifyControlExists("AssessmentView", "StudentResponseTab");
        }

        public static void ClickOnQuestionTabInScoring()
        {
            AutomationAgent.Click("AssessmentView", "QuestionTab");
        }


        public static bool VerifyCorrespondingQuestionNumberLabelOpen(string questionno)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoringQuestionNumberLabel", WaitTime.DefaultWaitTime, questionno);
        }

        public static bool VerifyRubricTabHighlightedInBoldForUARubric()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "RubricTab");
        }

        public static void ClickStandardsTab()
        {
            AutomationAgent.Click("AssessmentView", "StandardsTab");
        }
        public static bool VerifyStandardsTabHighlightedInBoldForUARubric()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "StandardsTab");
        }
        public static bool VerifyObservationCheckListTabHighlightedInBoldForUAChecklist()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "ObservationCheckListTab");
        }
        public static bool VerifyStandardsTabHighlightedInBoldForUAChecklist()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "StandardsTab");
        }
        /// <summary>
        /// Verify AnswersTab In Preview Screen of UAChecklist
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyAnswersTabInPreviewScreenUAChecklist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AnswersTab");
        }
        /// <summary>
        /// Verify Previous Button In Preview Screen Of UAChecklist
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyPreviousButtonInPreviewScreenOfUAChecklist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "PreviousButton");
        }
        /// <summary>
        /// Verify NextButton In Preview Screen Of UAChecklist
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyNextButtonInPreviewScreenOfUAChecklist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentNextButton");
        }
        public static void ClickOnUAChecklist()
        {
            AutomationAgent.Click("AssessmentView", "UACheckListBlock");
            WaitForPageToLoad();
        }

        public static bool VerifyQuestionsTabInPreviewScreenUAChecklist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "QuestionsTab");
        }
        /// <summary>
        /// Verify No Score Entry In RubricTab UARubric
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyNoScoreEntryInRubricTabUARubric()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "RubricTab", "1", WaitTime.SmallWaitTime, "");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        /// <summary>
        /// Verify NoScore Entry In ObservationTab UACheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyNoScoreEntryInObservationTabUACheckList()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "ObservationCheckListTab", "1", WaitTime.SmallWaitTime, "");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        /// <summary>
        /// Verify Standards Header In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyStandardsInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StandardHeader", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verify NotObserved Header In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyNotObservedInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NotObservedHeader", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verify Beginning Header In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyBeginningInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "BeginningHeader", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verify Group Header In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyGroupInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "Group", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verify Behaviour Header In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyBehaviourInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "BehaviourHeader", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verify Levels In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyLevelsInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "LevelsInRubricBlock", WaitTime.SmallWaitTime);
        }

        /// <summary>
        /// Verify Developing In Observation CheckList
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyDevelopingInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "DevelopingHeader", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verifies Score Button Active or Not
        /// </summary>
        /// <returns>bool: true(if Active), false(if not active)</returns>
        public static bool VerifyScoreButtonActive()
        {
            WaitForPageToLoad();
            return AutomationAgent.VerifyControlEnabled("AssessmentView", "ScoreButton");
        }
        /// <summary>
        /// Gets the number of Student who have not started the assessment
        /// </summary>
        /// <returns>int: number of students</returns>
        public static int GetNumberOfStudentsNotStartedAssessment()
        {
            return Int32.Parse(AutomationAgent.GetControlText("AssessmentView", "NotStartedTab"));
        }
        /// <summary>
        /// Gets the number of Student who have started the assessment
        /// </summary>
        /// <returns>int: number of students</returns>
        public static int GetNumberOfStudentsStartedAssessment()
        {
            return Int32.Parse(AutomationAgent.GetControlText("AssessmentView", "StartedTab"));
        }
        /// <summary>
        /// Gets the number of Student who have submitted the assessment
        /// </summary>
        /// <returns>int: number of students</returns>
        public static int GetNumberOfStudentsSubmittedAssessment()
        {
            return Int32.Parse(AutomationAgent.GetControlText("AssessmentView", "SubmittedTab"));
        }
        /// <summary>
        /// Gets the number of Student who have scored the assessment
        /// </summary>
        /// <returns>int: number of students</returns>
        public static int GetNumberOfStudentsScoredAssessment()
        {
            return Int32.Parse(AutomationAgent.GetControlText("AssessmentView", "ScoredTab"));
        }
        /// <summary>
        /// Verifies Not Started Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifyNotStartedProgressTabGray(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "NotStartedTab", sampleColor);
        }
        /// <summary>
        /// Verifies Started Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifyStartedProgressTabGray(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "StartedTab", sampleColor);
        }
        /// <summary>
        /// Verifies Submitted Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifySubmittedProgressTabGray(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "SubmittedTab", sampleColor);
        }
        /// <summary>
        /// Verifies scored Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifyScoredProgressTabGray(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoredTab", sampleColor);
        }
        /// <summary>
        /// Verifies Started Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifyStartedProgressTabBlue(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoredTab", sampleColor);
        }
        /// <summary>
        /// Verifies Not Started Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifyNotStartedProgressTabBlue(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoredTab", sampleColor);
        }
        /// <summary>
        /// Verifies Submitted Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifySubmittedProgressTabBlue(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoredTab", sampleColor);
        }
        /// <summary>
        /// Verifies scored Progress Tab Color
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <returns>bool: true(if the sampleColor matches the extracted color)</returns>
        public static bool VerifyScoredProgressTabBlue(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoredTab", sampleColor);
        }

        public static bool VerifyQuestionTabHighlightedInPreviewAssessmentScreen()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "QuestionsTab");
        }

        public static bool VerifyScoringColumnNumber()
        {
            string[] number = AutomationAgent.GetChildrenControlNames("AssessmentView", "ScoringPane", WaitTime.DefaultWaitTime, "");
            return number[0].Equals("#1") && number[1].Equals("#2") && number[2].Equals("#3");


        }

        public static bool VerifyNextButtonClickableAndIsPresentInPreviewAssessment()
        {

            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "QuestionLabel")).Split(' ');
            for (int i = Int32.Parse(Question[2]); i < Int32.Parse(Question[6]); i++)
            {
                Question[0].Contains("Question");
                VerifyAssessmentNextButtonTestPreview();
                ClickAssessmentNextButtonTestPreview();
            }
            return !VerifyAssessmentNextButtonTestPreview();
        }


        public static bool VerifyScoredTabSelectedInStopScoringScreenByDefault()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "ScoredStopScoringScreen");
        }

        public static int GetCountOfScoredInStopScoringScreen()
        {
            return Int32.Parse(AutomationAgent.GetControlText("AssessmentView", "ScoredStopScoringScreen"));

        }

        public static void ClickScoredOnStopScoringScreen()
        {
            AutomationAgent.Click("AssessmentView", "ScoredStopScoringScreen");

        }
        /// <summary>
        /// Verify Standards Appear For Specific Question
        /// </summary>
        /// <returns>bool:true(if present),false(if not present)</returns>
        public static bool VerifyStandardsAppearForSpecificQuestion()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScrollViewer", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verifies the text alignment of Started Progress Tab
        /// </summary>
        /// <param name="startedNo">int</param>
        /// <returns>bool: true(if the text alignment is right), false(if not)</returns>
        public static bool VerifyTextAlignmentInStartedTab(int startedNo)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "StartedTab");
            int a = Int32.Parse(s[0]);
            string text = a + "  " + s[1];
            if (text.Equals(startedNo + "  Started"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verify QuestionCard Is Displayed Per Student
        /// </summary>
        /// <param name="questioncard">int</param>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyQuestionCardIsDisplayedPerStudent(int questioncard)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxEmpty", WaitTime.SmallWaitTime, questioncard.ToString());
        }
        /// <summary>
        /// Get StudentName Under NotScored Category
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static string GetStudentNameUnderNotScoredCategory()
        {
            string abc = AutomationAgent.GetControlText("AssessmentView", "StudentNameText", WaitTime.DefaultWaitTime, "");
            return abc;
        }
        /// <summary>
        /// Verify DiscussionRubric Displayed
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyDiscussionRubricDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "DiscussionRubric", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verify DiscussionRubric Is In Centre
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyDiscussionRubricIsInCentre()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int RubricX = AutomationAgent.GetControlPositionX("AssessmentView", "RubricScroller");
            int RubricWidth = AutomationAgent.GetControlWidth("AssessmentView", "RubricScroller");

            int diff = (ScreenSize / 2) - (RubricX + (RubricWidth / 2));
            if (diff == 0)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Verify Rubric ItemScoring Page Displayed
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyRubricItemScoringPageDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RubricScoring", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verifies the text alignment of Submitted Progress Tab
        /// </summary>
        /// <param name="startedNo">int</param>
        /// <returns>bool: true(if the text alignment is right), false(if not)</returns>
        public static bool VerifyTextAlignmentInSubmittedTab(int submittedNo)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "SubmittedTab");
            int a = Int32.Parse(s[0]);
            string text = a + "  " + s[1];
            if (text.Equals(submittedNo + "  Submitted"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the text alignment of Not Started Progress Tab
        /// </summary>
        /// <param name="startedNo">int</param>
        /// <returns>bool: true(if the text alignment is right), false(if not)</returns>
        public static bool VerifyTextAlignmentInNotStartedTab(int notStartedNo)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "NotStartedTab");
            int a = Int32.Parse(s[0]);
            string text = a + "  " + s[1];
            if (text.Equals(notStartedNo + "  Not Started"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the text alignment of Scored Progress Tab
        /// </summary>
        /// <param name="startedNo">int</param>
        /// <returns>bool: true(if the text alignment is right), false(if not)</returns>
        public static bool VerifyTextAlignmentInScoredTab(int scoredNo)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "ScoredTab");
            int a = Int32.Parse(s[0]);
            string text = a + "  " + s[1];
            if (text.Equals(scoredNo + "  Scored"))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Verify Consistent Header In Observation CheckList
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyConsistentInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ConsistentHeader", WaitTime.SmallWaitTime);
        }

        /// <summary>
        /// Verify Description Of Criterion In Observation CheckList
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyDescriptionOfCriterionInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "DescriptionOfCriterion", WaitTime.SmallWaitTime);
        }

        /// <summary>
        /// Verify RadioButton Level Of Mastery In Observation CheckList
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyRadioButtonInObservationCheckList()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RadioButtonOfMastery", WaitTime.SmallWaitTime);
        }

        /// <summary>
        /// Verify Radio Button Of Mastery Darkened Observation
        /// </summary>
        /// <returns></returns>
        public static bool VerifyRadioButtonOfMasteryDarkenedObservation()
        {
            AutomationAgent.Click("AssessmentView", "RadioButtonOfMastery", WaitTime.DefaultWaitTime, "");
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "RadioButtonOfMastery", WaitTime.SmallWaitTime);
        }
        /// <summary>
        /// Verifies the text present below the Release Scores button in format
        /// </summary>
        /// <returns>bool: true(if text is similar), false(if not)</returns>
        public static bool VerifyTextBelowReleaseScoresButton()
        {
            int yPos = AutomationAgent.GetControlPositionY("AssessmentView", "ReleaseScoreButton");
            int yPos1 = AutomationAgent.GetControlPositionY("AssessmentView", "TitleLockUnlockOverlay", WaitTime.DefaultWaitTime, "9");
            string s = AutomationAgent.GetControlText("AssessmentView", "TitleLockUnlockOverlay", WaitTime.DefaultWaitTime, "9");
            string[] s1 = s.Split(' ');
            int num = Int32.Parse(s1[2]);
            string a = "Score  " + num + "  students to release scores";
            if (yPos1 > yPos && s.Equals("Score  " + num + "  students to Release Scores"))
                return true;
            else
                return false;
        }


        /// <summary>
        /// Verify Sample Answer Modal Displayed
        /// </summary>
        /// <returns>bool: true(if text is similar), false(if not)</returns>
        public static bool VerifySampleAnswerModalDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "SampleAnswerDisplay");
        }
        /// <summary>
        /// Verify SampleAnswer For Question Is Displayed
        /// </summary>
        /// <returns>bool: true(if text is similar), false(if not)</returns>
        public static bool VerifySampleAnswerForQuestionIsDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "SampleAnswerPane");
        }
        /// <summary>
        /// Click WhiteColor Question Card
        /// </summary>
        /// <param name="questioncard">string</param>
        public static void ClickWhiteColorQuestionCard(string questioncard)
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, questioncard))
            {
                AutomationAgent.Click("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, questioncard);
            }
        }
        /// <summary>
        /// Get the StudentName In Discussion Rubric
        /// </summary>
        /// <returns>string: StudentName</returns>
        public static string GetStudentNameInDiscussionRubric()
        {
            string[] abc = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentNameDisplayed", WaitTime.DefaultWaitTime, "");
            return abc[0];
        }


        public static void NavigateToAssessmentTasksFromSystemTrayMenu(TaskInfo taskInfo)
        {
            if (taskInfo.SubjectName == "ELA")
            {
                NavigateELATask(taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
            }
            else if (taskInfo.SubjectName == "Math")
            {
                NavigateMathTask(taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
            }
        }

        public static void NavigateELATask(int gradeNumber, int unitNumber, int lessonNumber, int taskNumber)
        {
            NavigationCommonMethods.NavigateToELA();
            NavigationCommonMethods.NavigateToELAGrade(gradeNumber);
            StartELAUnit(unitNumber);
            NavigationCommonMethods.OpenELALessonFromLessonBrowser(lessonNumber);
            AutomationAgent.Wait(1000);
            NavigationCommonMethods.NavigateToTaskPageInLesson(taskNumber);
        }

        public static void StartELAUnit(int unitNumber)
        {
            ClickELAUnit(unitNumber);
            NavigationCommonMethods.ClickStartInELAUnitLibrary(unitNumber);
        }

        public static void ClickELAUnit(int unitNumber)
        {
            AutomationAgent.Click("AssessmentView", "UnitLibraryUnitTiles", WaitTime.DefaultWaitTime, unitNumber.ToString());
        }

        public static void NavigateMathTask(int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }
        public static int GetListOfStudentsUnderStopScoringScoredCategory()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "StudentListInGridView", WaitTime.DefaultWaitTime, "");
            return count;
        }
        /// <summary>
        /// Verify NotStarted Tab In Unit Accomplishment
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyNotStartedTabInUnitAccomplishment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NotStartedTabOngAssessment");
        }
        /// <summary>
        /// Verify Locked For Text In Unit Assessment
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyLockedForTextInUnitAssessment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "UnlockAssessment");
        }
        /// <summary>
        /// Verify StartedTab In Unit Accomplishment
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyStartedTabInUnitAccomplishment()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StartedTabOngAssessment");
        }
        /// <summary>
        /// Verify Student List Dropdown On Item Scoring Page
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyStudentListDropdownOnItemScoringPage()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FlyoutPane");
        }
        /// <summary>
        /// Click Outside Of Student List Dropdown On Item Scoring Page
        /// </summary>
        public static void ClickOutsideOfStudentListDropdownOnItemScoringPage()
        {
            AutomationAgent.Click(590, 186);
        }
        /// <summary>
        /// Click StudentName On Item Scoring Page
        /// </summary>
        public static void ClickStudentNameOnItemScoringPage()
        {
            AutomationAgent.Click("AssessmentView", "StudentDropdownInItemScoring");
        }

        /// <summary>
        /// Verify Standards Unavialble Text
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyStandardsUnavialbleText()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StandardsUnavailableText");
        }
        /// <summary>
        /// Verify No Applicable Information Text
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyNoApplicableInformationText()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NoApplicableInformationText");
        }
        /// <summary>
        /// Verify Rubric Section Under StandardsTab
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyRubricSectionUnderStandardsTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RubricScroller");
        }
        /// <summary>
        /// Verifies Assessment Tile is grey or not
        /// </summary>
        /// <param name="sampleColor">Color</param>
        /// <param name="lessonNumber">int</param>
        /// <returns>bool: true(if color is grey), false(if not grey)</returns>
        public static bool VerifyAssessmentTileGreyed(System.Drawing.Color sampleColor, int lessonNumber)
        {
            return AutomationAgent.CompareControlImageColor("LessonBrowserView", "LessonTileButton", sampleColor, WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }
        /// <summary>
        /// Verifies Assessment Tile is Higlighted and blue or not
        /// </summary>
        /// <param name="sampleColor">Color</param>
        /// <param name="lessonNumber">int</param>
        /// <returns>bool: true(if color is blue), false(if not grey)</returns>
        public static bool VerifyAssessmentTileHiglighted(System.Drawing.Color sampleColor, int lessonNumber)
        {
            return AutomationAgent.CompareControlImageColor("LessonBrowserView", "LessonTileButton", sampleColor, WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }


        /// <summary>
        /// Verifies if Assessment Button available in Lesson browser or not 
        /// </summary>
        /// <param name="lessonNumber">int</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAssessmentButtonPresentInLessonBrowser(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        public static bool VerifySampleAnswerbutton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "SampleAnswerButton");
        }

        /// <summary>
        /// Click Criterion Title Toggle
        /// </summary>
        public static void ClickCriterionTitleToggle()
        {
            AutomationAgent.Click("AssessmentView", "AssessmentRubricCriterionViewModel");
        }
        /// <summary>
        /// Verify Criterion Desription Displayed
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCriterionDesriptionDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RubricCriterionTitleGroup1");
        }
        /// <summary>
        /// Get Criterion Description ClassName
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static string GetCriterionDescriptionClassName()
        {
            return AutomationAgent.GetControlClassName("AssessmentView", "RubricCriterionTitleGroup1");
        }
        /// <summary>
        /// Verify Content Below Rubric Header Is Scrollable
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyContentBelowRubricHeaderIsScrollable()
        {
            AutomationAgent.Swipe("AssessmentView", "RubricGroupTitle1", UITestGestureDirection.Up, WaitTime.DefaultWaitTime, "");
            return AutomationAgent.VerifyControlExists("AssessmentView", "RubricGroupTitle1");
        }
        /// <summary>
        /// Verify RubricContent On Student Scoring Screen
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyRubricContentOnStudentScoringScreen()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RubricScroller");
        }
        /// <summary>
        /// Verify Criterion Grouped Under Group Title
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCriterionGroupedUnderGroupTitle()
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "RubricTitleGroup1ListView") && AutomationAgent.VerifyControlExists("AssessmentView", "CriterionGroupedUnder1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetCountOfNotScoredInOngoing()
        {
            string count = AutomationAgent.GetControlText("AssessmentView", "OnGoingUnitNotScoredButton", WaitTime.DefaultWaitTime, "");
            return Int32.Parse(count);

        }

        public static bool VerifyStudentNameAvailableInNotScoredOngoing()
        {
            string[] childrenNames = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentListInGridView");
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentListInGridView");
        }

        public static int GetCountOfScoredInOngoing()
        {
            string count = AutomationAgent.GetControlText("AssessmentView", "OnGoingUnitScoredButton", WaitTime.DefaultWaitTime, "");
            return Int32.Parse(count);
        }

        public static bool VerifyStudentNameAvailableInScoredOngoing()
        {
            string[] childrenNames = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentListInGridView");
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentListInGridView");
        }
        /// <summary>
        /// Click Omit Button
        /// </summary>
        public static void ClickOmitButton()
        {
            AutomationAgent.Click("AssessmentView", "OmitButtonTextBlock");
        }
        /// <summary>
        /// Click Okbutton On Omit PopUp
        /// </summary>
        public static void ClickOkbuttonOnOmitPopUp()
        {
            AutomationAgent.Click("AssessmentView", "OkayButton");
        }
        /// <summary>
        /// Verify Omit PopUp Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyOmitPopUpPresent()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "OkayButton");
        }
        /// <summary>
        /// Verify Observation Column3 Grayed Out
        /// </summary>
        /// <param name="sampleColor"></param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyObservationColumn3GrayedOut(System.Drawing.Color sampleColor, string columnno)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "Observationcolumn3grayedout", sampleColor, WaitTime.DefaultWaitTime, columnno);
        }
        /// <summary>
        /// Click Observation Column3 score card
        /// </summary>
        public static void ClickObservationColumnscorecard(string scorecard)
        {
            AutomationAgent.Click("AssessmentView", "Observationcolumn3grayedout", WaitTime.DefaultWaitTime, scorecard);
        }
        /// <summary>
        /// Click Cancel button On Omit PopUp
        /// </summary>
        public static void ClickCancelbuttonOnOmitPopUp()
        {
            AutomationAgent.Click("AssessmentView", "CancelButton");
        }
        /// <summary>
        /// Verify Student Response Tab Present
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyStudentResponseTabPresent()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentResponseTab");
        }
        public static bool ClickStudentResponseTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentResponseTab");
        }
        public static bool VerifyStudentResponseTabHighlighted()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "StudentResponseTab");
        }
        /// <summary>
        /// Verify Omit Button Present In Centre Of Top Row
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyOmitButtonPresentInCentreOfTopRow()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int OmitbuttonX = AutomationAgent.GetControlPositionX("AssessmentView", "OmitButtonTextBlock");

            int diff = (ScreenSize / 2) - (OmitbuttonX);

            if (diff <= 150)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifies Text present in Stop Scoring Pop up 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool VerifyNotScoredNoOfStudentInScoringPopUp(string count)
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "NotScoredStudentInStopScoringPopUp", WaitTime.DefaultWaitTime, count);
            string[] s1 = s.Split(' ');
            string text = count + " " + s1[1] + " " + s1[2] + " " + s1[3];
            if (s.Contains(text))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify AddButton
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAddButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AddButtonTextBlock");
        }
        /// <summary>
        /// Verify AddButton Present In Centre Of Top Row
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAddButtonPresentInCentreOfTopRow()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int AddbuttonX = AutomationAgent.GetControlPositionX("AssessmentView", "AddButtonTextBlock");

            int diff = (ScreenSize / 2) - (AddbuttonX);

            if (diff <= 150)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Click AddButton
        /// </summary>
        public static void ClickAddButton()
        {
            AutomationAgent.Click("AssessmentView", "AddButtonTextBlock");
        }
        /// <summary>
        /// Verify Observation Column3 Active
        /// </summary>
        /// <param name="columnno">columnno</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyObservationColumnActive(string columnno)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, columnno);
        }
        /// <summary>
        /// Verify Not Scored Or Partially Scored Card WhiteColor
        /// </summary>
        /// <param name="sampleColor1">sampleColor1</param>
        /// <param name="columnno">columnno</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNotScoredOrPartiallyScoredCardWhiteColor(System.Drawing.Color sampleColor1, string columnno)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoreBoxEmpty", sampleColor1, WaitTime.DefaultWaitTime, columnno);
        }

        /// <summary>
        /// Verifies the No of students which are scored in Stop Scoring Pop Up Screen
        /// </summary>
        /// <param name="scoringNo">int</param>
        /// <returns>bool: true(if text is similar), false(if text is not similar)</returns>
        public static bool VerifyScoredNoOfStudentInScoringPopUp(int scoringNo)
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "ScoringStudentInStopScoringPopup", WaitTime.DefaultWaitTime, scoringNo.ToString());
            string[] s1 = s.Split(' ');
            string text = Int32.Parse(s1[0]) + " " + s1[1] + " " + s1[2] + " " + s1[3];
            if (s.Equals(text))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies if Question card is active or not
        /// </summary>
        /// <param name="questioncard">string</param>
        /// <returns>bool: true(if active), false(if not active)</returns>
        public static bool VerifyWhiteColorQuestionCard(string questioncard)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, questioncard);
        }
        /// <summary>
        /// Clicks on any of the gray question card
        /// </summary>
        /// <param name="questionCard">string: question card number</param>
        public static void ClickGrayColorQuestionCard(string questionCard)
        {
            AutomationAgent.Click("AssessmentView", "ScoreBoxFilled", WaitTime.DefaultWaitTime, questionCard);
        }
        /// <summary>
        /// Verifies the color of Question card is grey
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <param name="questionCard">string: question card number</param>
        /// <returns>bool: true(if color is grey), false(if color is not grey)</returns>
        public static bool VerifyQuestionCardIsGreyInColor(System.Drawing.Color sampleColor, string questionCard)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "ScoreBoxFilled", sampleColor, WaitTime.DefaultWaitTime, questionCard);
        }

        public static void ClickCriterionScoreButton(string button)
        {
            AutomationAgent.Click("AssessmentView", "RubricCriterionButtonForScore", WaitTime.DefaultWaitTime, button);
        }

        public static string GetTotalScorePopulated()
        {
            return AutomationAgent.GetControlText("AssessmentView", "TotalScoreButton");
        }

        public static void ClickOnStatusBasedFixedAssessments(string status)
        {
            for (int i = 1; i <= 5; i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "ListViewItem", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, i.ToString());
                    if (names[2].Contains(status) || names[1].Contains(status))
                    {
                        AutomationAgent.Click("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, i.ToString());
                        break;
                    }
                    else
                        continue;

                }
                else
                    break;

            }

        }

        public static bool VerifyUnlockAllText()
        {
            string text = AutomationAgent.GetControlText("AssessmentView", "UnlockAllButton", WaitTime.DefaultWaitTime, "");

            return text.Contains("UNLOCK ALL");


        }

        public static int GetStatusOfFixedAssessments(string status)
        {
            int i = 0;

            for (i = 1; i <= 5; i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "ListViewItem", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, i.ToString());
                    if (names[2].Contains(status) || names[1].Contains(status))
                    {
                        break;

                    }
                    else
                        continue;

                }
                else
                    break;

            }
            return i;
        }

        public static bool VerifyLockAllText()
        {
            string text = AutomationAgent.GetControlText("AssessmentView", "UnlockAllButton", WaitTime.DefaultWaitTime, "");

            return text.Contains("LOCK ALL");
        }

        public static bool VerifyTheStatusOnLockUnlockOverlay(string status)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StatusOnlockUnlockOverlay", WaitTime.DefaultWaitTime, status);
        }

        public static bool VerifySectionNameInLockUnlockOverlay(string sectioName)
        {
            return AutomationAgent.VerifyAppChildrenByName(sectioName);
        }
        /// <summary>
        /// Verifies if started Student's Row is grey or not
        /// </summary>
        /// <param name="sampleColor">Color</param>
        /// <returns>bool: true(if color is grey), false(if color is not grey)</returns>
        public static bool VerifyStartedStudentRowIsGreyed(System.Drawing.Color sampleColor)
        {
            int noOfStudents = AutomationAgent.GetChildrenControlCount("AssessmentView", "UnitAssessmentPane");
            int i;
            for (i = 1; i < noOfStudents; i++)
            {
                if (AutomationAgent.VerifyChildrenControlByName("AssessmentView", "StudentSelection", WaitTime.DefaultWaitTime, i.ToString(), "Started"))
                    break;
                else
                    continue;
            }
            return AutomationAgent.CompareControlImageColor("AssessmentView", "StudentSelection", sampleColor, WaitTime.DefaultWaitTime, i.ToString());
        }

        /// <summary>
        /// Click UANotebook
        /// </summary>
        public static void ClickUANotebook()
        {
            AutomationAgent.Swipe("AssessmentView", "ListViewOnGoing", UITestGestureDirection.Up);
            AutomationAgent.Click("AssessmentView", "UANotebookOngoing");
        }
        public static bool VerifyUANotebook()
        {
            AutomationAgent.Swipe("AssessmentView", "ListViewOnGoing", UITestGestureDirection.Up);
            return AutomationAgent.VerifyControlExists("AssessmentView", "UANotebookOngoing");
        }
        /// <summary>
        /// Verify Standards Content Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyStandardsContentPresent()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScrollViewer");
        }
        /// <summary>
        /// Verify QuestionsTab In Preview Screen UANotebook
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyQuestionsTabInPreviewScreenUANotebook()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "QuestionsTab");
        }
        /// <summary>
        /// Verify Contents Present Under QuestionsTab
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyContentsPresentUnderQuestionsTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScrollViewer");
        }
        /// <summary>
        /// Click On UACheckList From Student
        /// </summary>
        /// <param name="assesnumber">assesnumber</param>
        public static void ClickOnUACheckListFromStudent(int assesnumber)
        {
            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "StudentOngoingAssessment", WaitTime.DefaultWaitTime, assesnumber.ToString());
        }
        /// <summary>
        /// Click On UARubric From Student
        /// </summary>
        /// <param name="assesnumber">assesnumber</param>
        public static void ClickOnUARubricFromStudent(int assesnumber)
        {
            AutomationAgent.Click("AssessmentView", "StudentOngoingAssessment", WaitTime.DefaultWaitTime, assesnumber.ToString());
        }
        /// <summary>
        /// Click UAProject For Student
        /// </summary>
        /// <param name="assesnumber">assesnumber</param>
        public static void ClickUAProjectForStudent(int assesnumber)
        {
            AutomationAgent.Click("AssessmentView", "StudentOngoingAssessment", WaitTime.DefaultWaitTime, assesnumber.ToString());
        }
        /// <summary>
        /// Click Assessment In DashBoard In Student
        /// </summary>
        public static void ClickELAAssessmentInDashBoardInStudent()
        {
            AutomationAgent.Click("AssessmentView", "studentDashboardAssessment", WaitTime.DefaultWaitTime, "3");
        }
        /// <summary>
        /// Click UANotebook For Student
        /// </summary>
        /// <param name="assesnumber">assesnumber</param>
        public static void ClickUANotebookForStudent(int assesnumber)
        {
            AutomationAgent.Swipe("AssessmentView", "ListViewOnGoing", UITestGestureDirection.Up);
            AutomationAgent.Swipe("AssessmentView", "ListViewOnGoing", UITestGestureDirection.Up);
            AutomationAgent.Click("AssessmentView", "StudentOngoingAssessment", WaitTime.DefaultWaitTime, assesnumber.ToString());
        }

        public static bool VerifyReleaseScorePopUp()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScorePopUp", WaitTime.DefaultWaitTime, "");
        }

        public static bool VerifyReleaseScoreNobutton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScoreNoButton", WaitTime.DefaultWaitTime, "");
        }

        public static bool VerifyReleaseScoreYesbutton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScoreYesButton", WaitTime.DefaultWaitTime, "");
        }

        public static bool VerifyTextInReleaseScorePopUp()
        {
            return (AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScorePopUp", WaitTime.DefaultWaitTime, "") && AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScorePopUpText1", WaitTime.DefaultWaitTime, "") && AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScorePopUpText2", WaitTime.DefaultWaitTime, ""));


        }

        public static void ClickonReleaseScoreNobutton()
        {
            AutomationAgent.Click("AssessmentView", "ReleaseScoreNoButton");
        }

        public static void ClickonReleaseScoreYesbutton()
        {
            AutomationAgent.Click("AssessmentView", "ReleaseScoreYesButton");
        }

        public static void ClickPreviousStudentButton()
        {
            AutomationAgent.Click("AssessmentView", "PreviousStudentButton");
        }

        public static void ClickOnUANotebookCheckBox(string student)
        {
            AutomationAgent.Click("AssessmentView", "UANoteBookCheckBox", WaitTime.DefaultWaitTime, student);
        }
        public static void ClickOnUaNotebookStudentDropSownButton()
        {
            AutomationAgent.Click("AssessmentView", "StudentDropDownButton");
        }
        public static string GetStudentNameInNotebook()
        {
            return AutomationAgent.GetControlText("AssessmentView", "StudentDropDownButton");
        }
        public static void ClickToSelectStudentUnderAllGroupFlyout()
        {
            AutomationAgent.Click("AssessmentView", "StudentNameRadioButton", WaitTime.DefaultWaitTime, "2");
        }




        public static void ClickOnAddCommentButton()
        {
            AutomationAgent.Click("AssessmentView", "AddCommentButton");

        }

        public static bool VerifyCreateButtonInAddCOmmentOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CreateButtonInAddComment");
        }

        public static void AddTextToCommentOverlay(string Settext)
        {
            AutomationAgent.SetText("AssessmentView", "inputField", Settext);
        }

        public static void ClickONCreateButtonInAddCOmmentOverlay()
        {
            AutomationAgent.Click("AssessmentView", "CreateButtonInAddComment");
        }

        public static bool VerifyAddCOmmentOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CreateButtonInAddComment");
        }

        public static bool VerifyCommentSuccessfullyAdded()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CommentCreatedMessage");
        }

        public static void ClickOnOkButton()
        {
            AutomationAgent.Click("AssessmentView", "OverlayOkbutton");
        }
        public static void ClickOnEditCommentButton()
        {
            AutomationAgent.Click("AssessmentView", "EditComment");
        }

        public static bool VerifyEditCOmmentOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "EditComment");
        }

        public static bool VerifyDeleteButtonInEditCOmmentOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "DeleteButton");
        }

        public static void ClickOnDeleteButtonInEditCOmmentOverlay()
        {
            AutomationAgent.Click("AssessmentView", "DeleteButton");
        }

        public static bool VerifyAddedCommentDeleted()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AddCommentButton");
        }

        public static void ClickOnDoneButtonInEditCOmmentOverlay()
        {
            AutomationAgent.Click("AssessmentView", "DoneButton");
        }

        public static bool VerifyDataIsSavedInCommentOverlay(string text)
        {
            string a = AutomationAgent.GetText("AssessmentView", "inputField");
            return a.Contains(text);

        }

        public static bool VerifyStartedProgressTabSelected()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "StartedTab");

        }
        /// <summary>
        /// Verifies the Students name are ordered by their last name or not
        /// </summary>
        /// <returns>bool: true(if order is correct), false(if not)</returns>
        public static bool VerifyStudentsNameOrderNyLastName()
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "VerticalPane");
            string[] a = s[0].Split(' ');
            string[] b = s[1].Split(' ');
            int res = string.Compare(a[1], b[1], StringComparison.Ordinal);
            if (res < 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Click On Exercise Assessment For Student
        /// </summary>
        /// <param name="assesnumber">assesnumber</param>
        public static void ClickOnExerciseAssessmentForStudent(int assesnumber)
        {
            AutomationAgent.Click("AssessmentView", "StudentOngoingAssessment", WaitTime.DefaultWaitTime, assesnumber.ToString());
        }
        /// <summary>
        /// Click Done Button
        /// </summary>
        public static void ClickDoneButton()
        {
            AutomationAgent.Click("AssessmentView", "DoneButton");
        }
        /// <summary>
        /// Verify UAChecklist Is ReadOnly For Student
        /// </summary>
        /// <returns>bool: true(if read only), false(if not)</returns>
        public static bool VerifyUAChecklistIsReadOnlyForStudent()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "ObservationCheckListTab", "1", WaitTime.SmallWaitTime, "");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        /// <summary>
        /// Verify UANotebook Is ReadOnly For Student
        /// </summary>
        /// <returns>bool: true(if read only), false(if not)</returns>
        public static bool VerifyUANotebookIsReadOnlyForStudent()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "QuestionsTab", "1", WaitTime.SmallWaitTime, "");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        /// <summary>
        /// Verify UAProject Is ReadOnly For Student
        /// </summary>
        /// <returns>bool: true(if read only), false(if not)</returns>
        public static bool VerifyUAProjectIsReadOnlyForStudent()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "QuestionsTab", "1", WaitTime.SmallWaitTime, "");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public static void ClickOnStudentDropdownList()
        {
            AutomationAgent.Click("AssessmentView", "StudentNameDisplayed");
        }

        public static int GetCountOfScoredDiscussionRubric()
        {
            string count = AutomationAgent.GetControlText("AssessmentView", "ScoredCountRubric", WaitTime.DefaultWaitTime, "");
            string[] ab = count.Split('(');
            return Int32.Parse(count);
        }

        /// <summary>
        /// Select RadioButton for scoring In Reading Section
        /// </summary>
        /// <param name="radiobuttonno">radiobuttonno</param>
        public static void SelectRadioButtonforscoringInReadingSection(string radiobuttonno)
        {

            if (AutomationAgent.VerifyControlExists("AssessmentView", "ObservationChecklistViewReading", WaitTime.DefaultWaitTime))
            {
                AutomationAgent.Click("AssessmentView", "ObservationChecklistRadiobutonReading", WaitTime.DefaultWaitTime, radiobuttonno);
            }
        }
        /// <summary>
        /// Select RadioButton for scoring In Writing Section
        /// </summary>
        /// <param name="radiobuttonno">radiobuttonno</param>
        public static void SelectRadioButtonforscoringInWritingSection(string radiobuttonno)
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "ObservationChecklistViewWriting", WaitTime.DefaultWaitTime))
            {
                AutomationAgent.Click("AssessmentView", "ObservationChecklistRadiobutonWriting", WaitTime.DefaultWaitTime, radiobuttonno);
            }
        }
        /// <summary>
        /// Verify Observation Score Card Active
        /// </summary>
        /// <param name="scorecard">scorecard</param>
        /// <returns>bool: true(if active), false(if not)</returns>
        public static bool VerifyObservationScoreCardActive(string scorecard)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreBoxEmpty", WaitTime.DefaultWaitTime, scorecard);
        }
        /// <summary>
        /// Verify RadioButton for scoring In Writing Section DeSelected
        /// </summary>
        /// <param name="radiobuttonno">radiobuttonno</param>
        /// <returns>bool: true(if deselected), false(if not)</returns>
        public static bool VerifyRadioButtonforscoringInWritingSectionDeSelected(string radiobuttonno)
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "ObservationChecklistRadiobutonWriting", WaitTime.DefaultWaitTime, radiobuttonno);
        }
        /// <summary>
        /// Verify Confirm PopUp Displayed
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyConfirmPopUpDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "OmitConfirmText");
        }
        /// <summary>
        /// Verify Confirm Omit Message Displayed
        /// </summary>
        /// <returns>Omit message</returns>
        public static string VerifyConfirmOmitMessageDisplayed()
        {
            string omitconfirmtext = AutomationAgent.GetControlText("AssessmentView", "OmitConfirmText");
            return omitconfirmtext;
        }
        /// <summary>
        /// Gets the name of the first student appearing in not scored 
        /// </summary>
        /// <returns>string: name of the student</returns>
        public static string GetFirstStudentNameToScore()
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "VerticalPane");
            return s[0];
        }
        /// <summary>
        /// Gets the Text
        /// </summary>
        /// <param name="instance">int: instance number</param>
        /// <returns>string: text</returns>
        public static string GetTextFromTextBlock(int instance)
        {
            return AutomationAgent.GetControlText("AssessmentView", "AssessmentOverviewSectionNameAndStudentNo", WaitTime.DefaultWaitTime, instance.ToString());
        }
        /// <summary>
        /// Verifies the Name present in a particular category or not
        /// </summary>
        /// <param name="name">string: name of the student</param>
        /// <returns>bool: true(if name is present), false(if name is not present)</returns>
        public static bool VerifyNamePresentInParticularCategory(string name)
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "StudentGridView");
            string[] namelist = new string[20];
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentsNameListInGridView", WaitTime.DefaultWaitTime, i.ToString());
                namelist[i - 1] = s[0];
                if (namelist[i - 1].Contains(name))
                {
                    var = true;
                    break;
                }
                else
                    continue;
            }
            return var;
        }
        /// <summary>
        /// Clicks on Not Scored Radio button present in the Stop Scoring screen 
        /// </summary>
        public static void ClickNotScoredRubricButtonInStopScoring()
        {
            AutomationAgent.Click("AssessmentView", "NotScoredRubricButton");
        }


        public static bool VerifyQuestionTabInScoringHighlighted()
        {
            return AutomationAgent.VerifyXamlRadioButtonSelected("AssessmentView", "QuestionTab");
        }

        public static bool VerifyUAProject()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "UAProjectUnitA");
        }

        public static bool VerifyUAChecklist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "UACheckListUnitA");
        }

        public static bool VerifyTotalSubmittedStudentsOnItemScoringScreen(int total)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "StudentsSubmittedText", WaitTime.DefaultWaitTime, total.ToString());
        }

        public static void ClickonViewCommentButton()
        {
            AutomationAgent.Click("AssessmentView", "ViewCommentButton");
        }

        public static bool VerifyViewCommentOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ViewCommentButton", WaitTime.DefaultWaitTime, "");
        }

        public static bool VerifyViewCommentButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ViewCommentButton", WaitTime.DefaultWaitTime, "");
        }

        public static void ClicktoOpenScoredStudentInNotebook()
        {

            SwipeUp();
            SwipeUp();
            AutomationAgent.Click("AssessmentView", "UANoteBookCheckBox", WaitTime.DefaultWaitTime, "28");
            AutomationAgent.Click("AssessmentView", "DisabledButtonNOtebook", WaitTime.DefaultWaitTime, "28");
        }

        public static bool VerifyStatusCategories()
        {
            string[] name1 = AutomationAgent.GetControlText("AssessmentView", "NumberOfSubmitted_TxtBlock").Split(' ');
            string[] name2 = AutomationAgent.GetControlText("AssessmentView", "NumberOfScored_TxtBlock").Split(' ');
            string[] name3 = AutomationAgent.GetControlText("AssessmentView", "NumberOfNotStarted_TxtBlock").Split(' ');
            string[] name4 = AutomationAgent.GetControlText("AssessmentView", "NumberOfStarted_TxtBlock").Split(' ');

            return (name1[0].Contains("Submitted") && name2[0].Contains("Scored") && (name3[0] + name3[1]).Contains("NotStarted") && name4[0].Contains("Started"));
        }

        public static bool VerifyReleaseScoreButtonConvertedToDateTimeStamp()
        {
            string[] datetime = AutomationAgent.GetControlText("AssessmentView", "ScoresReleased", WaitTime.DefaultWaitTime, "").Split(' ');
            string values = datetime[2].Replace("\r\n", "");
            string finaldatetime = values + " " + datetime[4] + " " + datetime[5];

            try
            {
                DateTime time = DateTime.Parse(finaldatetime);
                return true;
            }

            catch (Exception e)
            {
                return false;
            }



        }

        public static bool VerifyReleaseScoreButtonConvertedToDateTimeStampOnScoringOverview()
        {
            string datetime = AutomationAgent.GetControlText("AssessmentView", "TeacherScoringOverview_ScoresReleasedDate", WaitTime.DefaultWaitTime, "");
            string values = datetime.Replace("at", "");


            try
            {
                DateTime time = DateTime.Parse(values);
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Verify Student NotScored Status In DropDown
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyStudentNotScoredStatusInDropDown()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "NotScoredTextDropdown", WaitTime.DefaultWaitTime, "1");
        }
        /// <summary>
        /// Verify StudentNames Present In Dropdown
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyStudentNamesPresentInDropdown()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "HeaderListView", WaitTime.DefaultWaitTime, "1");
        }
        /// <summary>
        /// Verify Count Of Students In NotScored Category
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyCountOfStudentsInNotScoredCategory()
        {
            string count = AutomationAgent.GetControlText("AssessmentView", "TeacherScoringOverviewNOtScoredCategoryTxtBlock");
            string[] first = count.Split(' ');
            string[] count1 = first[2].Split('(');
            string[] count2 = first[4].Split(')');
            if (count1[1] == count2[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify Count Of Students In Scored Category
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyCountOfStudentsInScoredCategory()
        {
            string count = AutomationAgent.GetControlText("AssessmentView", "ScoredCountRubric");
            string[] first = count.Split(' ');
            string[] count1 = first[1].Split('(');
            string[] count2 = first[3].Split(')');
            int count11 = int.Parse(count1[1]);
            int count12 = int.Parse(count2[0]);
            if (count11 <= count12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClickOnUACheckListInUnitA()
        {
            AutomationAgent.Click("AssessmentView", "UAChecklistTeamL");
            WaitForPageToLoad();
        }
        /// <summary>
        /// Verify Assessments present in the Particual Unit are in order
        /// </summary>
        /// <returns>bool: true(if Assessments are in order), false(if Assessments are not in order)</returns>
        public static bool VerifyUnitAssessmentsInOrder()
        {
            string[] s1 = AutomationAgent.GetControlText("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, "1").Split(' ');
            string[] s2 = AutomationAgent.GetControlText("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, "2").Split(' ');
            int res = string.Compare(s1[0], s2[0], StringComparison.Ordinal);
            if (res < 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies standard ‘no wifi’ notification present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyStandardNoWifiPopUp()
        {
            AutomationAgent.Wait(2000);
            bool a = AutomationAgent.VerifyControlExists("AssessmentView", "NoWifiPopUpHeader");
            bool b = AutomationAgent.VerifyControlExists("AssessmentView", "NoWifiPopUpBody");
            if (AutomationAgent.VerifyControlExists("AssessmentView", "NoWifiPopUpHeader") &&
               AutomationAgent.VerifyControlExists("AssessmentView", "NoWifiPopUpBody"))
            {
                AutomationAgent.Click("AssessmentView", "OkayButtonInPopUp");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verify UARubric Is ReadOnly For Student
        /// </summary>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyUARubricIsReadOnlyForStudent()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "RubricTab", "1", WaitTime.SmallWaitTime, "");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        /// <summary>
        /// Click On StudentName In Dropdown List
        /// </summary>
        public static void ClickOnStudentNameInDropdownList()
        {
            AutomationAgent.Click("AssessmentView", "StudentRadioButtonInDropdown");
        }
        /// <summary>
        /// Verifies if the student who has started the assessment is grey or not
        /// </summary>
        /// <param name="student">int: student No.</param>
        /// <param name="sampleColor">Color</param>
        /// <returns>bool: true(if grey), false(if not grey)</returns>
        public static bool VerifyStartedStudentInactiveAndGrey(int student, System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("AssessmentView", "StudentSelection", sampleColor, WaitTime.DefaultWaitTime, student.ToString());
        }
        /// <summary>
        /// Verifies if the students started number is 0 or not
        /// </summary>
        /// <param name="instance">instance</param>
        /// <returns>bool: true(if number is 0), false(if number is not 0)</returns>
        public static bool VerifyZeroStudentsStartedFieldInAssessmentRow(int instance, string StudentNo)
        {
            string s = "Started:  0 / " + StudentNo;
            return AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s, WaitTime.DefaultWaitTime, instance.ToString());
        }
        /// <summary>
        /// Verifies if the students started number similar or not
        /// </summary>
        /// <param name="instance">instance</param>
        /// <returns>bool: true(if similar), false(if not similar)</returns>
        public static bool VerifyStudentsNumberStartedFieldInAssessmentRow(int instance, int startedNo, string StudentNo)
        {
            string s = "Started:  " + startedNo + " / " + StudentNo;
            return AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s, WaitTime.DefaultWaitTime, instance.ToString());
        }


        /// <summary>
        /// Click QuestionTile
        /// </summary>
        /// <param name="questiontile"></param>
        public static void ClickQuestionTile(string questiontile)
        {
            AutomationAgent.Click("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, questiontile);
            AutomationAgent.Wait(3000);
        }
        /// <summary>
        /// Verify CheckAnswer Is Active
        /// </summary>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyCheckAnswerIsActive()
        {
            return AutomationAgent.VerifyControlEnabled("AssessmentView", "CheckAnswerButton");
        }
        /// <summary>
        /// Click ExercisesTab
        /// </summary>
        public static void ClickExercisesTab()
        {
            AutomationAgent.Click("AssessmentView", "Execrcisebutton");
        }
        /// <summary>
        /// Click Exercise Assessment From UnitLibrary
        /// </summary>
        /// <param name="exerciseno">exerciseno</param>
        public static void ClickExerciseAssessmentFromUnitLibrary(string exerciseno)
        {
            AutomationAgent.Click("AssessmentView", "BasicAssessmentViewModel", WaitTime.DefaultWaitTime, exerciseno);
        }
        /// <summary>
        /// Verify ExercisesTab Present
        /// </summary>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyExercisesTabPresent()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "Execrcisebutton");
        }
        /// <summary>
        /// Verify Name Of Exercise
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyNameOfExercise(string exercise)
        {
            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "AssessmentNamebutton", WaitTime.DefaultWaitTime, exercise);
            if (names[0].Contains("Exercise"))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// Verify Message Without Selecting Option
        /// </summary>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyMessageWithoutSelectingOption()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "OOpsText");
        }
        /// <summary>
        /// Click CheckAnswer button
        /// </summary>
        public static void ClickCheckAnswerbutton()
        {
            AutomationAgent.Click("AssessmentView", "CheckAnswerButton");
        }
        /// <summary>
        /// Verify Lessons tab Present
        /// </summary>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyLessonstabPresent()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "Lessonsbutton");
        }
        /// <summary>
        /// Click Summary button
        /// </summary>
        public static void ClickSummarybutton()
        {
            AutomationAgent.Click("AssessmentView", "Summarybutton");
        }

        public static bool VerifyReleaseScoreButtonFound()
        {
            AutomationAgent.Wait(5000);
            return AutomationAgent.VerifyControlExists("AssessmentView", "ReleaseScoreButton");
        }
        public static bool VerifyStatusOfOngoingChecklistAssessments(string name)
        {
            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "UACheckListbutton", WaitTime.DefaultWaitTime, "");

            return names[1].Equals(name);
        }

        public static bool VeriftScoreCardsAreClickableAfterScoresReleased()
        {

            SwipeUp();
            SwipeUp();
            AutomationAgent.Click("AssessmentView", "UANoteBookCheckBox", WaitTime.DefaultWaitTime, "28");
            AutomationAgent.Wait();
            return VerifyCheckListScoringScreen();

        }


        //public static bool VerifyOngoingAssessmentStatus(string status, int number)
        //{

        //        if (AutomationAgent.VerifyControlExists("AssessmentView", "ListViewItem", WaitTime.DefaultWaitTime, number.ToString()))
        //        {
        //            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, number.ToString());
        //            if (names[2].Contains(status) || names[1].Contains(status))
        //            {
        //                return true;
        //            }
        //        }
        //        else
        //            return false;

        //    }


        public static void clickOnAnswer()
        {
            AutomationAgent.Click("AssessmentView", "Answer");
        }

        public static bool VerifyItemsWithNoResponsesOnAssessSummaryScreenOFExercise(string total_question)
        {

            bool name = false;

            for (int i = 1; i <= Int32.Parse(total_question); i++)
            {
                string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, i.ToString());
                if (status[2].Equals("Unanswered") || status[1].Equals("Unanswered"))
                {
                    name = true;
                    continue;
                }
                else
                    if (status[2].Equals("Open-Ended Response") || status[1].Equals("Open-Ended Response"))
                    {
                        name = true;
                        continue;
                    }
                    else
                    {
                        name = false;
                        break;
                    }
            }
            return name;
        }

        //public static void ClickQuestionTile(string questiontile)
        //{
        //    AutomationAgent.Click("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, questiontile);
        //}

        public static bool VerifyTileWithUnanswered(string tile)
        {
            string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, tile.ToString());
            if ((null != status[2] && status[2].Equals("Unanswered")) || (null != status[1] && status[1].Equals("Unanswered")))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies List of All Assessments with their status present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyListOfAllAssessmentsStatusForStudents()
        {
            int total = AutomationAgent.GetChildrenControlCount("AssessmentView", "FixedAssessmentsList");
            string s = "Started";
            string s1 = "Not Started";
            string s2 = "Submitted";
            string s3 = "Scores Released";
            bool var = false;
            for (int i = 1; i < total; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s, WaitTime.DefaultWaitTime, i.ToString()) ||
                   AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s1, WaitTime.DefaultWaitTime, i.ToString()) ||
                   AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s2, WaitTime.DefaultWaitTime, i.ToString()) ||
                   AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s3, WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }

        public static bool VerifyListOfLessonsExist()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "LessonListGridInLesson");
        }
        /// <summary>
        /// Verifies the All Status Displayed corresponding to the Assessments in select unit drop down
        /// </summary>
        /// <returns>bool: true(if status present), false(if status not present)</returns>
        public static bool VerifyAllStatusInUnitSelectionDropDown(int unitNumber)
        {
            AutomationAgent.Wait(4000);
            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            AutomationAgent.Click("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, unitNumber.ToString());

            WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");

            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "HeaderListView");

            bool a = AutomationAgent.VerifyControlExists("AssessmentView", "DropdownUnitSelectRadioButton", WaitTime.DefaultWaitTime, "1");
            bool b = AutomationAgent.VerifyControlExists("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, "1");

            string s = "Pending";
            string s1 = "In Progress";
            string s2 = "Scoring Required";
            string s3 = "Delivered";
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "DropdownUnitSelectRadioButton", s, WaitTime.DefaultWaitTime, i.ToString()) ||
                       AutomationAgent.VerifyChildByName("AssessmentView", "DropdownUnitSelectRadioButton", s1, WaitTime.DefaultWaitTime, i.ToString()) ||
                       AutomationAgent.VerifyChildByName("AssessmentView", "DropdownUnitSelectRadioButton", s2, WaitTime.DefaultWaitTime, i.ToString()) ||
                       AutomationAgent.VerifyChildByName("AssessmentView", "DropdownUnitSelectRadioButton", s3, WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            return var;
        }

        public static void ClickOnOpenEndedQuestion()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Open-Ended\r\nResponse", WaitTime.DefaultWaitTime, i.ToString()))
                    AutomationAgent.Click("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, i.ToString());
            }
        }
        /// <summary>
        /// Verify CheckAnswer Button
        /// </summary>
        /// <returns>bool:true(if present),false(if not)</returns>
        public static bool VerifyCheckAnswerButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "CheckAnswerButton");
        }

        public static bool VerifyOpenEndedNOtIncludeInUnansweredCount(int count)
        {
            int unanswered_count = GetUnansweredText();
            return unanswered_count < count;
        }

        public static bool VerifySubmitbuttonOnSubmitButtonPopUp()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "SubmitButtonPopup");
        }

        public static bool VerifyCancelbuttonOnSubmitButtonPopUp()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentDialogCancelButton");
        }
        /// <summary>
        /// Verifies List of All Assessment Status Present for Teacher
        /// </summary>
        /// <returns>bool: true(if status are similar), false(if status are not similar)</returns>
        public static bool VerifyListOfAllAssessmentsStatusForTeacher()
        {
            int total = AutomationAgent.GetChildrenControlCount("AssessmentView", "FixedAssessmentsList");
            string s = "In Progress";
            string s1 = "Delivered";
            string s2 = "Pending";
            string s3 = "Scoring Required";
            bool var = false;
            for (int i = 1; i < total; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s, WaitTime.DefaultWaitTime, i.ToString()) ||
                   AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s1, WaitTime.DefaultWaitTime, i.ToString()) ||
                   AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s2, WaitTime.DefaultWaitTime, i.ToString()) ||
                   AutomationAgent.VerifyChildByName("AssessmentView", "FixedAssessmentsItemsButton", s3, WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }

        public static bool VerifyQuestionTabIsNoteditable()
        {
            try
            {
                AutomationAgent.SetText("AssessmentView", "QuestionTab", "1");
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public static bool VerifyQuestionNoIncrementsAfterTappingNextButton()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
            if (Question[2] == "6")
            {
                ClickAssessmentExercisePreviousButton();
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                ClickAssessmentExerciseNextButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) < Int32.Parse(Question2[2]));

            }

            else
            {
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                ClickAssessmentExerciseNextButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) < Int32.Parse(Question2[2]));


            }
        }

        public static bool VerifyQuestionNoDecrementsAfterTappingPreviousButton()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
            if (Question[2] == "1")
            {
                ClickAssessmentExerciseNextButton();
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                ClickAssessmentExercisePreviousButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) > Int32.Parse(Question2[2]));

            }

            else
            {
                string[] Question1 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                ClickAssessmentExercisePreviousButton();
                string[] Question2 = (AutomationAgent.GetControlText("AssessmentView", "ScoringScreenCurrentQuestionLabel")).Split(' ');
                return (Int32.Parse(Question1[2]) > Int32.Parse(Question2[2]));


            }
        }
        public static string NavigateAndClickOnReviewAndSumbitButton()
        {
            string[] Question = new string[10];
            Question = (AutomationAgent.GetControlText("AssessmentView", "NumberOfQuestions")).Split(' ');


            for (int i = Int32.Parse(Question[2]); i < Int32.Parse(Question[6]); i++)
            {
                ClickAssessmentNextButton();
            }
            ClickReviewAndSubmitButton();
            return Question[6].ToString();
        }


        public static bool VerifyTextInDeliveredAssessmentRow(string status)
        {
            bool name = false;
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "FixedAssessmentsList", WaitTime.DefaultWaitTime, "");
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "ListViewItem", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, i.ToString());
                    if ((names[2].Contains(status) || names[1].Contains(status)) && (names[1].Contains("Scores Released")))
                    {
                        name = true;
                        break;
                    }
                    else
                        continue;

                }
            }
            return name;

        }

        public static void ClicktoOpenScoredStudentInUAChecklist()
        {

            SwipeUp();
            SwipeUp();
            AutomationAgent.Click("AssessmentView", "DisabledButtonNOtebook", WaitTime.DefaultWaitTime, "28");
        }

        public static bool VerifyUnitAssessmentTile()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentLessonTile");
        }

        public static bool VerifyScoreFlyoutMenuRubric(string score)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoreRadioButton", WaitTime.DefaultWaitTime, score);
        }

        public static void ClicktoOpenScoredStudentInRubric()
        {
            SwipeUp();
            SwipeUp();
            AutomationAgent.Click("AssessmentView", "UANoteBookCheckBox", WaitTime.DefaultWaitTime, "28");
            AutomationAgent.Click("AssessmentView", "DisabledButtonNOtebook", WaitTime.DefaultWaitTime, "28");
        }
        /// <summary>
        /// Clicks on Start Lesson Button Present in the Students Dashboard
        /// </summary>
        public static void ClickELAStartLessonInStudentDashBoard(int instance)
        {
            AutomationAgent.Click("AssessmentView", "studentDashboardELAStartLessonButton", WaitTime.DefaultWaitTime, instance.ToString());
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Clicks on Flag Button present in the Question of Excercise
        /// </summary>
        public static void ClickOnFlagButtonInExercise()
        {
            AutomationAgent.Click("AssessmentView", "ExerciseFlagButton");
        }
        /// <summary>
        /// Clicks on Summary Button present in the question of any Excercise
        /// </summary>
        public static void ClickSummaryButtonInExercise()
        {
            AutomationAgent.Click("AssessmentView", "ExcerciseSummarybutton");
        }
        /// <summary>
        /// Verifies Challenge Problem Question Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyChallengeProblemQuestionTile()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Challenge Problem", WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }
        /// <summary>
        /// Verifies if Unanswered Question present in the summary or not
        /// </summary>
        /// <returns>bool: ture(if present), false(if not present)</returns>
        public static bool VerifyUnansweredQuestion()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Unanswered", WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }
        /// <summary>
        ///  Verifies if Correct Answered Question present in the summary or not
        /// </summary>
        /// <returns>bool: ture(if present), false(if not present)</returns>
        public static bool VerifyCorrectAnsweredQuestion()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Correct", WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }
        /// <summary>
        /// Click Revise Answer button
        /// </summary>
        public static void ClickReviseAnswerbutton()
        {
            AutomationAgent.Click("AssessmentView", "ReviseAnswerButton");
        }
        /// <summary>
        /// Click I Need Help button
        /// </summary>
        public static void ClickINeedHelpButton()
        {
            AutomationAgent.Click("AssessmentView", "INeedHelpButton");
        }
        /// <summary>
        /// Click I Understand Now button
        /// </summary>
        public static void ClickIUnderstandNowButton()
        {
            AutomationAgent.Click("AssessmentView", "IUnderstandNowButton");
        }
        /// <summary>
        /// Verifies Revised Question Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyRevisedQuestion()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "(Revised)", WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }
        /// <summary>
        /// Verifies if Open Ended Question is Present or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifyOpenEndedQuestion()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            bool var = false;
            for (int i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Open-Ended\r\nResponse", WaitTime.DefaultWaitTime, i.ToString()))
                    var = true;
            }
            return var;
        }
        /// <summary>
        /// Verifies if Specified Question is answered or not 
        /// </summary>
        /// <param name="questionNo">string: Question Number</param>
        /// <returns>true(if answered question is present), false(if not present)</returns>
        public static bool VerifyAnsweredQuestion(string questionNo)
        {
            if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Unanswered", WaitTime.DefaultWaitTime, questionNo))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Clicks on Math's Start Unit button present in the Teacher's Dashboard
        /// </summary>
        public static void ClickMathStartUnitButtonInTeacherDashboard()
        {
            AutomationAgent.Wait();

            if (AutomationAgent.VerifyControlExists("AssessmentView", "DashboardHubSection", WaitTime.DefaultWaitTime, 3.ToString()))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                AutomationAgent.Click("AssessmentView", "MathStartUnitButton", WaitTime.DefaultWaitTime, 3.ToString());
                AutomationAgent.Wait(2000);
            }
            else
            {
                AutomationAgent.Click("AssessmentView", "MathStartUnitButton", WaitTime.DefaultWaitTime, 2.ToString());
                AutomationAgent.Wait(200);
            }
        }
        /// <summary>
        /// Verifies if Excercise Page is opened or not
        /// </summary>
        /// <returns>bool: true(if opened), false(if not opened)</returns>
        public static bool VerifyExcerciseOpened()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ExcerciseTitle");
        }
        /// <summary>
        /// Gets the Title of the Excercise Opened
        /// </summary>
        /// <returns>string: title of the Excercise</returns>
        public static string GetExcerciseTitle()
        {
            return AutomationAgent.GetControlText("AssessmentView", "ExcerciseTitle");
        }

        public static void VerifyTextOnCorrectAnswerResponse()
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "CorrectAnswerText");
        }
        public static void VerifyCorectAnswerTextOnQuestionTile(string questiontile)
        {
            AutomationAgent.VerifyControlExists("AssessmentView", "CorrectAnswerTextOnQuestionTile", WaitTime.DefaultWaitTime, questiontile);
        }
        public static void ClickToSelectWrongAnswer()
        {
            AutomationAgent.Wait(10000);
            AutomationAgent.Click(55, 432);
        }
        public static bool VerifyTextOnInCorrectAnswerResponse()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "InCorrectAnswerText");
        }
        public static bool VerifyReviseAnswerbutton()
        {
            return (AutomationAgent.VerifyControlExists("AssessmentView", "ReviseAnswerButton") && AutomationAgent.VerifyControlEnabled("AssessmentView", "ReviseAnswerButton"));

        }
        public static bool VerifyInCorectAnswerTextOnQuestionTile(string questiontile)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "IncorrectAnswerTextOnQuestionTile", WaitTime.DefaultWaitTime, questiontile);
        }
        /// <summary>
        /// Gets the Open Ended Question Number
        /// </summary>
        /// <returns>int: question number</returns>
        public static int GetOpenEndedQuestionsNumber()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            int i;
            for (i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Open-Ended\r\nResponse", WaitTime.DefaultWaitTime, i.ToString()))
                    break;
            }
            return i;
        }
        /// <summary>
        /// Verifies Open Ended Question Tile doesn't display any Status
        /// </summary>
        /// <param name="questionNo">int: open ended question number</param>
        /// <returns>bool: true(if no status), false(if any status there)</returns>
        public static bool VerifyOpenEndedQuestionNoStatus(int questionNo)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, questionNo.ToString());
            if (s[1].Contains("Unanswered") && s[1].Contains("Correct") && s[1].Contains("Incorrect"))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Verifies if Excercise is in Pending Status or not with text Started: 0/x
        /// </summary>
        /// <returns>bool: true(if status pending), false(if status not pending)</returns>
        public static bool VerifyExerciseInPendingStatus()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "ListViewOnGoing");
            bool var = false;
            for (int i = 1; i < count; i++)
            {
                string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExcerciseButtonOnGoing", WaitTime.DefaultWaitTime, i.ToString());
                string[] num = s[2].Split(' ');
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExcerciseButtonOnGoing", "Pending", WaitTime.DefaultWaitTime, i.ToString()))
                    var = AutomationAgent.VerifyChildByName("AssessmentView", "ExcerciseButtonOnGoing", "Started:  " + Int32.Parse(num[2]) + " / " + Int32.Parse(num[4]), WaitTime.DefaultWaitTime, i.ToString());
            }
            return var;
        }
        /// <summary>
        /// Clicks on the Assessment Button Present in the Math Teacher's Dashboard
        /// </summary>
        public static void ClickAssessmentButtonInMathTeacherDashboard()
        {
            AutomationAgent.Wait();

            if (AutomationAgent.VerifyControlExists("AssessmentView", "DashboardHubSection", WaitTime.DefaultWaitTime, 2.ToString()))
            {
                AutomationAgent.Click("AssessmentView", "MathAssessmentsButton", WaitTime.DefaultWaitTime, 2.ToString());
                AutomationAgent.Wait(2000);
            }
            else
            {
                AutomationAgent.Click("AssessmentView", "MathAssessmentsButton", WaitTime.DefaultWaitTime, 1.ToString());
                AutomationAgent.Wait(200);
            }
        }
        /// <summary>
        /// Verifies if the Excercise has In Progress Status or not
        /// </summary>
        /// <returns>bool: true(if InProgress), false(if not InProgress)</returns>
        public static bool VerifyExerciseInProgressStatus()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "ListViewOnGoing");
            bool var = false;
            for (int i = 1; i < count; i++)
            {
                string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExcerciseButtonOnGoing", WaitTime.DefaultWaitTime, i.ToString());
                string[] num = s[2].Split(' ');
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExcerciseButtonOnGoing", "In Progress", WaitTime.DefaultWaitTime, i.ToString()))
                    var = AutomationAgent.VerifyChildByName("AssessmentView", "ExcerciseButtonOnGoing", "Started:  " + Int32.Parse(num[2]) + " / " + Int32.Parse(num[4]), WaitTime.DefaultWaitTime, i.ToString());
            }
            return var;
        }

        public static void ClickAssessmentExerciseNextButton()
        {
            AutomationAgent.Click(1253, 728);
        }

        public static void ClickAssessmentExercisePreviousButton()
        {
            AutomationAgent.Click(112, 728);
        }

        /// <summary>
        /// Click Yes I Got It button
        /// </summary>
        public static bool VerifyYesIGotItButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "YesIGotItButton");
        }
        /// <summary>
        /// Click I Understand Now button
        /// </summary>
        public static bool VerifyIUnderstandNowButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "IUnderstandNowButton");
        }

        public static void ClickInsideBlankSpace()
        {
            AutomationAgent.Click(109, 336);
        }

        public static void SendText(string text)
        {
            SendKeys.SendWait(text);
        }

        public static bool VerifyContextualText()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "HowDidYouDoText");
        }

        public static bool VerifyINeedHelpButton()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "INeedHelpButton");
        }
        /// <summary>
        /// Click Yes I Got It button
        /// </summary>
        public static void ClickYesIGotItButton()
        {
            AutomationAgent.Click("AssessmentView", "YesIGotItButton");
        }
        public static bool VerifyTextAFterClickingYesIGotItButton()
        {
            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "YesIGotItButton");
            return names[1].Contains("Excellent! Keep it up!");
        }

        public static bool VerifyTileWithYesIGotItText(string tile)
        {
            string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, tile.ToString());
            if ((null != status[2] && status[2].Contains("Yes, I got it")) || (null != status[1] && status[1].Contains("Yes, I got it")))
                return true;
            else
                return false;
        }

        public static bool VerifyTextAFterClickingIUnderstandNowButton()
        {

            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "IUnderstandNowButton");
            return names[1].Contains("Ok! You can ask for help.");
        }

        public static void ClickonNextButtonInStudentExercise()
        {
            //to do 
            AutomationAgent.Click(1155, 987);


        }

        public static bool VerifyTileWithNowIGetItText(string tile)
        {
            string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, tile.ToString());
            if ((null != status[2] && status[2].Contains("Now I Get It")) || (null != status[1] && status[1].Contains("Now I Get It")))
                return true;
            else
                return false;
        }
        public static bool VerifyTextAFterClickingINeedHelpButton()
        {
            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "INeedHelpButton");
            return names[1].Contains("Try Again, or ask for help.");
        }

        public static bool VerifyTileWithINeedHelpText(string tile)
        {
            string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, tile.ToString());
            if ((null != status[2] && status[2].Contains("I need help")) || (null != status[1] && status[1].Contains("I need help")))
                return true;
            else
                return false;
        }

        public static bool VerifyTileWithAnswered(string tile)
        {
            string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, tile.ToString());
            if ((null != status[2] && status[2].Equals("Answered")) || (null != status[1] && status[1].Equals("Answered")))
                return true;
            else
                return false;
        }

        public static void ClickToSelectCorrectAnswer()
        {
            AutomationAgent.Wait(10000);
            AutomationAgent.Click(228, 532);
        }

        /// <summary>
        /// Gets the Title of the Excercise Opened when student logs in
        /// </summary>
        /// <returns>string: title of the Excercise</returns>
        public static string GetStudentsExcerciseTitle()
        {
            return AutomationAgent.GetControlText("AssessmentView", "StudentExcerciseTitle");
        }

        /// <summary>
        /// Verify Incorrect Revised Text On QuestionTile
        /// </summary>
        /// <param name="tileno">tileno</param>
        /// <returns>bool: true(if present),false(if not)</returns>
        public static bool VerifyIncorrectRevisedTextOnQuestionTile(string tileno)
        {
            return (AutomationAgent.VerifyControlExists("AssessmentView", "IncorrectAnswerTextOnQuestionTile", WaitTime.DefaultWaitTime, tileno) && (AutomationAgent.VerifyControlExists("AssessmentView", "RevisedAnswerTextOnQuestionTile", WaitTime.DefaultWaitTime, tileno)));
        }
        /// <summary>
        /// Verify Correct Revised Text On Question Tile
        /// </summary>
        /// <param name="tileno">tileno</param>
        /// <returns>bool: true(if present),false(if not)</returns>
        public static bool VerifyCorrectRevisedTextOnQuestionTile(string tileno)
        {
            return (AutomationAgent.VerifyControlExists("AssessmentView", "CorrectAnswerTextOnQuestionTile", WaitTime.DefaultWaitTime, tileno) && (AutomationAgent.VerifyControlExists("AssessmentView", "RevisedAnswerTextOnQuestionTile", WaitTime.DefaultWaitTime, tileno)));
        }
        /// <summary>
        /// Gets the Count of the questions present in the particular excercise
        /// </summary>
        /// <returns>int: Qurstion No.</returns>
        public static int GetQuestionsCountInExcerciseSummary()
        {
            return AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
        }
        /// <summary>
        /// Verfies id Excercise has been completed or not
        /// </summary>
        /// <param name="excerciseNo">int: particular excercise number</param>
        /// <returns>bool: true(if excercise status is completed), false(if not)</returns>
        public static bool VerifyExcerciseCompleted(int excerciseNo)
        {
            return AutomationAgent.VerifyChildByName("AssessmentView", "AssessmentNamebutton", "Completed", WaitTime.DefaultWaitTime, excerciseNo.ToString());
        }
        /// <summary>
        /// Verify ScoringRequired Text is displayed or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyScoringRequiredTextDisplayed()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "ScoringRequiredText");
        }
        /// <summary>
        /// Click UnAnswered QuestionTile On Assessment Summary Screen
        /// </summary>
        /// <param name="questiontile">questiontile</param>
        public static void ClickUnAnsweredQuestionTileOnAssessmentSummaryScreen(string questiontile)
        {
            AutomationAgent.Click("AssessmentView", "QuestionTileButtonInSummaryScreen", WaitTime.DefaultWaitTime, questiontile);
        }
        /// <summary>
        /// Click Lock All And Reset Link
        /// </summary>
        public static void ClickLockAllAndResetLink()
        {
            AutomationAgent.Click("AssessmentView", "LockAndResetLink");
        }
        /// <summary>
        /// Click Cancel In LockAll And Reset PopUp
        /// </summary>
        public static void ClickCancelInLockAllAndResetPopUp()
        {
            AutomationAgent.Click("AssessmentView", "LockAndResetOverlayCancelButton");
        }
        /// <summary>
        /// Verify LockAndReset Overlay
        /// </summary>
        /// <returns>bool: true(if present), false(if not)</returns>
        public static bool VerifyLockAndResetOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "LockAndResetOverlay");

        }
        public static bool VerifyTileWithRevisedAndNowIGetItText(string tile)
        {
            string[] status = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, tile.ToString());
            if ((null != status[2] && status[2].Contains("(Revised)")) || (null != status[1] && status[1].Contains("(Revised)")) && (null != status[2] && status[2].Contains("Now I Get It")) || (null != status[3] && status[3].Contains("Now I Get It")))
                return true;
            else
                return false;
        }

        public static bool VerifySelfEvaluationButtons()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "INeedHelpButton") && AutomationAgent.VerifyControlExists("AssessmentView", "IUnderstandNowButton") && AutomationAgent.VerifyControlExists("AssessmentView", "YesIGotItButton"); return AutomationAgent.VerifyControlExists("AssessmentView", "INeedHelpButton") && AutomationAgent.VerifyControlExists("AssessmentView", "IUnderstandNowButton") && AutomationAgent.VerifyControlExists("AssessmentView", "YesIGotItButton");
        }

        public static string GetCurrentQuestionNoInMathExercise()
        {
            string[] Question = (AutomationAgent.GetControlText("AssessmentView", "QuestionNumberTextInMathExercise")).Split(' ');

            return Question[2];
        }

        public static void ClickExcerciseSummaryButton()
        {
            AutomationAgent.Click("AssessmentView", "ExcerciseSummarybutton");
        }

        public static int ClickUnansweredQuestion()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "QuestionTileGridView");
            int i = 1;
            for (i = 1; i <= count; i++)
            {
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExerciseTilebutton", "Unanswered", WaitTime.DefaultWaitTime, i.ToString()))
                    AutomationAgent.Click("AssessmentView", "ExerciseTilebutton", WaitTime.DefaultWaitTime, i.ToString());
            }

            return i;

        }

        public static int GetStatusOfUnitAccomplishments(string status)
        {
            int i = 0;

            for (i = 1; i <= 5; i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "ListViewItem", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "StudentOngoingAssessment", WaitTime.DefaultWaitTime, i.ToString());
                    if (names[2].Contains(status) || names[1].Contains(status))
                    {
                        break;

                    }
                    else
                        continue;

                }
                else
                    break;

            }
            return i;
        }

        public static bool VerifyExerciseInInProgressStatus()
        {
            int count = AutomationAgent.GetChildrenControlCount("AssessmentView", "ListViewOnGoing");
            bool var = false;
            for (int i = 1; i < count; i++)
            {
                string[] s = AutomationAgent.GetChildrenControlNames("AssessmentView", "ExcerciseButtonOnGoing", WaitTime.DefaultWaitTime, i.ToString());
                string[] num = s[2].Split(' ');
                if (AutomationAgent.VerifyChildByName("AssessmentView", "ExcerciseButtonOnGoing", "In Progress", WaitTime.DefaultWaitTime, i.ToString()))
                    var = AutomationAgent.VerifyChildByName("AssessmentView", "ExcerciseButtonOnGoing", "Started:  " + Int32.Parse(num[2]) + " / " + Int32.Parse(num[4]), WaitTime.DefaultWaitTime, i.ToString());
            }
            return var;
        }

        /// <summary>
        /// Gets Additional info from XML
        /// </summary>
        /// <param name="login">login</param>
        /// <returns>string array: Status</returns>
        public static string[] LoadUnitStatusFromAdditionalInfoMath(Login login)
        {
            TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");
            String additionalInfo = taskInfo.AdditionalInfo;
            String[] unitStatus = additionalInfo.Split(',');
            return unitStatus;
        }
        /// <summary>
        /// Click Math Assessment In DashBoard In Student
        /// </summary>
        public static void ClickMathAssessmentInDashBoardInStudent()
        {
            AutomationAgent.Click("AssessmentView", "studentDashboardAssessment", WaitTime.DefaultWaitTime, "4");
        }
        /// <summary>
        /// Clicks on Start Lesson Button Present in the Students Dashboard
        /// </summary>
        public static void ClickMathStartLessonInStudentDashBoard(int instance)
        {
            AutomationAgent.Click("AssessmentView", "studentDashboardMathStartLessonButton", WaitTime.DefaultWaitTime, instance.ToString());
            AutomationAgent.Wait(200);
        }
    }
}


    


    

