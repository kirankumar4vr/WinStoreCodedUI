using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Pearson.PSCWinAutomation.Framework;
using System.Drawing;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class AssessmentTests
    {
        public AssessmentTests()
        {
        }
        

        #region Additional test attributes

        [TestInitialize]
        public void TestInitialize()
        {
            Logger.InsertTestHeaderLine(testContextInstance.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Logger.InsertTestEndLine(testContextInstance.TestName + " , Test Result: " + testContextInstance.CurrentTestOutcome.ToString());
        }

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

        [TestMethod()]//done
        [TestCategory("Assessment"),TestCategory("US9946"),TestCategory("US6595"), TestCategory("US6794"), TestCategory("US6750"), TestCategory("US5826"), TestCategory("US6989"),TestCategory("US6628"),TestCategory("US6589"),TestCategory("US6623"),TestCategory("US6646")]
        [Priority(1)]
        [WorkItem(16155),WorkItem(16153),WorkItem(15935), WorkItem(15937), WorkItem(19673), WorkItem(16368), WorkItem(16131), WorkItem(16134), WorkItem(16133), WorkItem(12176), WorkItem(16271), WorkItem(52389), WorkItem(19672), WorkItem(12175), WorkItem(16248), WorkItem(16250),WorkItem(19065), WorkItem(19075), WorkItem(16249), WorkItem(16255)]
        [Owner("Akanksha Gautam(akanksha.gautam),Silky Manocha(silky.manocha)")]
        public void VerifyThatScoreAndViewReportButtonIsActiveAsSoonAsOneStudentHasSubmittedTheAssessment()
        {
            try
            {
                //TC15935
                Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(studenttaskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(studenttaskInfo.Unit);
                AssessmentCommonMethods.ClickAssessmentTile();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp(), "Assessment PopUp is present");
                NavigationCommonMethods.Logout();

                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                ////AssessmentCommonMethods.ClickLockAllAndResetLink();

                //TC16368
                ////Assert.IsTrue(AssessmentCommonMethods.VerifyLockAndResetOverlay(), "Lock And Reset Overlay is not present");
                ////AssessmentCommonMethods.ClickCancelInLockAllAndResetPopUp();

                //TC16271
                ////Assert.IsFalse(AssessmentCommonMethods.VerifyLockAndResetOverlay(),"Lock And Reset Overlay is present");
                ////AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);

                //TC16249 ,16153,16155
                Assert.IsFalse(AssessmentCommonMethods.VerifyScoreButtonActive(), "Score Button Active");
                Assert.IsFalse(AssessmentCommonMethods.VerifyViewReportButtonActive(), "View Report Button Active");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoreButtonActive(), "Release Score Button is active");
                
                //TC16255
                AssessmentCommonMethods.ClickPreviewAssessmentLink();
                Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Item preview screen is not displayed");
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();

                //TC16131
                Assert.IsFalse(AssessmentCommonMethods.VerifyScoringRequiredTextDisplayed(), "Scoring Required Text is displayed");
                NavigationCommonMethods.Logout();


                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                string name = AssessmentCommonMethods.GetNameOfTheAssessmentStart(1);
                AssessmentCommonMethods.ClickAssessmentTile();
                AutomationAgent.Wait();
                //TC15937
                Assert.IsTrue(AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp(),"Assessment PopUp is not present");
                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                AssessmentCommonMethods.ClickOnSummaryButton();
                AutomationAgent.CloseApp();

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);

                //TC16133
                Assert.IsFalse(AssessmentCommonMethods.VerifyScoringRequiredTextDisplayed(), "Scoring Required Text is displayed");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(studentlogin);

                //TC12176
                AssessmentCommonMethods.ClickUnAnsweredQuestionTileOnAssessmentSummaryScreen("2");

                //TC12175
                AssessmentCommonMethods.ClickOnSummaryButton();
                AssessmentCommonMethods.ClickSubmitButton();
                AssessmentCommonMethods.ClickOnSubmitButtonOnSubmitButtonPopUp();

                //TC19672,//TC19673
                AssessmentCommonMethods.ClickAssessmentTile();
                Assert.IsFalse(AssessmentCommonMethods.VerifyTestPlayerOpenInWebView(), "Assessment opens up");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);

                //TC16134
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringRequiredTextDisplayed(),"Scoring Required Text is not displayed");

                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                //TC16248
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoreButtonActive(), "Score Button Active");

                //TC16250
                Assert.IsTrue(AssessmentCommonMethods.VerifyViewReportButtonActive(), "View Report Button Active");

                //TC19065,TC19075
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.VerifyScoringOverviewPage();
                AssessmentCommonMethods.ClickWhiteColorQuestionCard("1");
                AssessmentCommonMethods.VerifyScoringPanel();
                AssessmentCommonMethods.VerifyCorrespondingQuestionNumberLabelOpen("1");

                //TC52389
                AssessmentCommonMethods.ClickScoringNextButton();
                AssessmentCommonMethods.ClickOnShowSampleAnswerButton();
                AssessmentCommonMethods.VerifyCrossButtonOnShowSampleAnswerModal();
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerModalDisplayed(), "Sample Answer Modal is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerForQuestionIsDisplayed(), "Sample Answer for Question is not displayed");
                AssessmentCommonMethods.ClickOnCrossButtonOnShowSampleAnswerModal();

                AssessmentCommonMethods.ClickOnCloseButton();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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





        [TestMethod()]//done
        [TestCategory("Assessment"), TestCategory("US6595")]
        [Priority(2)]
        [ WorkItem(16145),WorkItem(16147), WorkItem(16155), WorkItem(16143), WorkItem(16154), WorkItem(16141), WorkItem(16146)]
        [Owner("Madhav Purohit(madhav.purohit), Mohammed Saquib(mohammed.saquib)")]
        public void AAAAssmentOverviewScreenAndItsScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen();
                Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                // 16139

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitleInCentre(), "Assessment Progress Overview is not in the center of the nav bar");
                AssessmentCommonMethods.VerifyToolsAndNotificationsIconNavBar();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "Title not found");
                string section = AssessmentCommonMethods.GetSectionInAssessmentOverview();
                Assert.AreEqual(section, UnitStatus[4], "section not found");
                string Students = AssessmentCommonMethods.GetNumberOfStudentsInAssessmentOverview();
                Assert.AreEqual("5 Students", Students, "Number of Students not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyProgressBarInProgressOverview(), "Progress bar is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyProgressTabsInProgressOverview(), "Progress tabs are not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoreButton(), "Score Button is not present");
                Assert.IsTrue(AssessmentCommonMethods.VerifyViewReportButton(), "View Report Button is not present");
                //Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoresButton(), "ReleaseScores Button is not present");
                Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLink(), "Preview Assessment Link is not visible");
                Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");
                //  16141

                int count = AssessmentCommonMethods.GetNumberOfStudentsSubmittedAssessment();
                if(count==0)
                {
                   Assert.IsFalse(AssessmentCommonMethods.VerifyScoreButtonActive(),"Score button not active");
                }
                //16147


                

                Assert.IsTrue(AssessmentCommonMethods.VerifyBackButtonisDisplayed(), "Release Score Button is active");
                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "Assessment Manager SCreen is displayed");
                //16143

                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "Title not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");
                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                Assert.IsTrue(AssessmentCommonMethods.VerifyLockUnlockOverlay(), "Lock/Unlock Overlay is not displayed");
                AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                // 16146

                Assert.IsTrue(AssessmentCommonMethods.VerifyViewReportButtonActive(), "View Report Button is Inactive");
                AssessmentCommonMethods.ClickViewReportButton();
                String ReportTitle = AssessmentCommonMethods.GetTextFromAssessmentResultSummary();
                Assert.AreEqual("Assessment Result Summary", ReportTitle, "Report Title Not Found");
                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                 //16154
                

                string PreviewAssessmentLink = AssessmentCommonMethods.GetPreviewAssessmentLinkText();
                Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLink(), "Preview Assessment Link is not visible");
                Assert.AreEqual("Preview Assessment", PreviewAssessmentLink, "Preview Assessment Link not visible");
                AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Lesson Preview Item Screen is not displayed");
                AssessmentCommonMethods.ClickOnCloseButton();
                //16145
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
        [TestCategory("Assessment"), TestCategory("US6498"), TestCategory("US6502"), TestCategory("US6512"), TestCategory("US8395"), TestCategory("US5810"), TestCategory("US6022")]
        [Priority(1)]
        [WorkItem(15809), WorkItem(15837), WorkItem(15838), WorkItem(15839), WorkItem(15828), WorkItem(15830), WorkItem(12306), WorkItem(12312), WorkItem(12178), WorkItem(15841), WorkItem(15842), WorkItem(15829), WorkItem(15843), WorkItem(15840), WorkItem(15844), WorkItem(15846), WorkItem(15847), WorkItem(15848), WorkItem(15849), WorkItem(15845), WorkItem(15832), WorkItem(12137), WorkItem(12192), WorkItem(12174), WorkItem(12190), WorkItem(12191), WorkItem(15835), WorkItem(12310), WorkItem(31780), WorkItem(31781)]
        [Owner("Madhav Purohit(madhav.purohit), Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj), ,Silky Manocha(silky.manocha), Akanksha Gautam(akanksha.gautam)")]
        public void AAAStudentAssesmentScreens()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 1);
                NavigationCommonMethods.Logout();

                Login studentlogin = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                string name = AssessmentCommonMethods.GetNameOfTheAssessmentStart(1);
                AssessmentCommonMethods.ClickAssessmentTile();
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();

                Assert.IsTrue(AssessmentCommonMethods.VerifyTimerInStudentView(), "Timer not found");
                //15841

                //
                Assert.IsTrue(AssessmentCommonMethods.VerifyFlagInStudentView(), "Flag not found");

                Assert.IsTrue(AssessmentCommonMethods.VerifyFlagButtonIsVisible(), "Flag button is not Visible");
                //15842

                Assert.IsTrue(AssessmentCommonMethods.VerifySummaryButtonInStudentView(), "Assessment summary button not found");
                //15828
                //AssessmentNameIsAvailableinStopScoringScreen();
                AssessmentCommonMethods.VerifyTimerContinuesInAssessmentSummaryScreen();

                //12306,//12178

                
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Screen not found");
                AssessmentCommonMethods.ClickOnQuestionTile(1);
                //15843,15845, 15829

                AssessmentCommonMethods.VerifyNextAndPreviousButtonInAssessment();
                //15840, 15844

                Assert.IsTrue(AssessmentCommonMethods.VerifyAndMoveToFirstItemOfAssessment(), "Student is not on first page of assessment");
                Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonInAssessment(), "Previous button is displayed");
                //15846

                AssessmentCommonMethods.ClickOnSummaryButton();
                Random rnd1 = new Random();
                int random = rnd1.Next(1, 4);
                String tiletotap = AssessmentCommonMethods.GetQuestionNumberFromTile(random);
                AssessmentCommonMethods.ClickOnQuestionTile(random);
                AutomationAgent.Wait();
                string QuestionNoCOunt = AssessmentCommonMethods.GetCurrentQuestionNo();
                Assert.AreEqual(tiletotap, QuestionNoCOunt, "Match not found");
                //15832, 12174



                 Assert.IsTrue(AssessmentCommonMethods.VerifyReviewAndSumbitButtonExist(), "Review And Submit button not found");
                //15847
                string total_Question = AssessmentCommonMethods.NavigateAndClickOnReviewAndSumbitButton();

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Assessment Summary screen not displayed");
                //15848, 12137

                AssessmentCommonMethods.VerifyItemsWithNoResponsesOnAssessSummaryScreen(total_Question);
                //15830,31780,31781

                AssessmentCommonMethods.ClickSubmitButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifySubmitOverlay(), "Submit Overlay not found");

                //TC12190
                AssessmentCommonMethods.VerifySubmitbuttonOnSubmitButtonPopUp();
                AssessmentCommonMethods.VerifyCancelbuttonOnSubmitButtonPopUp();

                AssessmentCommonMethods.ClickCancelButtonOnSubmitAssessmentPopUp();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Assessment Summary screen not displayed");
                //12192, US5810


                AssessmentCommonMethods.ClickSubmitButton();

                //TC12191

                AssessmentCommonMethods.ClickOnSubmitButtonOnSubmitButtonPopUp();
                //15835, 12310

                Assert.IsFalse(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Assessment Summary screen display");
                Assert.IsTrue(AssessmentCommonMethods.VerifyUnitAssessmentTile(), "Tile not found");
                //12312

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentAfterStudentSumbitTheAssessment(name), "Name not found");
                //15849

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
        [TestCategory("Assessment"), TestCategory("US9298"), TestCategory("US6499")]
        [Priority(1)]
        [WorkItem(15820),WorkItem(15822),WorkItem(44944), WorkItem(44935), WorkItem(44937), WorkItem(44945), WorkItem(44936), WorkItem(44933), WorkItem(44934), WorkItem(44940), WorkItem(44941), WorkItem(44999), WorkItem(44938),WorkItem(44939)]
        [Owner("Madhav Purohit(madhav.purohit), Akanksha Gautam(akanksha.gautam), Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyDesignSpecsForAssessmentSummaryForFixedAssessments()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 2);
                NavigationCommonMethods.Logout();

                Login studentlogin = Login.GetLogin("AssessmentStudent");
                TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(studenttaskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(studenttaskInfo.Unit);
                AssessmentCommonMethods.ClickAssessmentTile();
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                AutomationAgent.Wait(3000);
                string total_Question = AssessmentCommonMethods.TotalNoOfQuestionsInAssessment();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTimerInStudentView(), "Timer not found");

                AssessmentCommonMethods.VerifyTimeElapsedStudentView();
                //15820
                AssessmentCommonMethods.VerifyTimerContinuesInAssessmentSummaryScreen();
                //15822

                int TimerWidth = AssessmentCommonMethods.GetTimerWidthExpanded();
                AssessmentCommonMethods.ClickTimerButtonInStudentView();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTimerCollapsed(TimerWidth), "Timer is not collapsed");
                AssessmentCommonMethods.ClickTimerButtonInStudentView();
                Assert.IsFalse(AssessmentCommonMethods.VerifyTimerCollapsed(TimerWidth), "Timer is not expanded");
                //44944

                AssessmentCommonMethods.ClickOnQuestionTile(1);
                AssessmentCommonMethods.ClickAssessmentNextButton();
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickAssessmentPreviousButton();
                AssessmentCommonMethods.ClickOnSummaryButton();
                AssessmentCommonMethods.VerifyItemsWithNoResponsesOnAssessSummaryScreen(total_Question);
                //44937, 12172

                AssessmentCommonMethods.VerifySubTitleInSummaryPage();
                //44999

                AssessmentCommonMethods.VerifyQuestionNumbersInSummary(total_Question);
                //44933

                Assert.IsTrue(AssessmentCommonMethods.VerifySubmitButtonAtRightCorner());
                //44935


                AssessmentCommonMethods.VerifyItemsWithNoResponsesOnAssessSummaryScreen(total_Question);
                //44936

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Assessment summary screen not found");
                //44945

                int flagText = Int32.Parse(AssessmentCommonMethods.GetFlagText());

                AssessmentCommonMethods.ClickOnQuestionTile(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifySummaryButtonInStudentView(), "Summary Button not available");
                //44934

                AssessmentCommonMethods.ClickFlagButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyFlaggedItem(), "Button is in previous state");
                Color sampleColor = Color.FromArgb(255, 255, 255, 255);
                Assert.IsTrue(AssessmentCommonMethods.VerifyFlagColorBlue(sampleColor), "Flag button color is not blue");
                //44940

                AssessmentCommonMethods.ClickOnSummaryButton();
                int newFlagText = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                Assert.AreEqual(flagText + 1, newFlagText);
                //44941  


                int count = AssessmentCommonMethods.GetUnansweredText();
                AssessmentCommonMethods.ClickOnQuestionTile(1);
                AssessmentCommonMethods.TapAnyABCDChoiceInQuestion();
                AssessmentCommonMethods.ClickOnSummaryButton();
                int newCount = AssessmentCommonMethods.GetUnansweredText();
                Assert.AreEqual(newCount, count-1, "Counts are not similar");
                //44939

                AssessmentCommonMethods.ClickOnQuestionTile(1);
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                AssessmentCommonMethods.ClickOnSummaryButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithAnswered("1"),"Answered text not found");
                //44938


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
        [TestCategory("Assessment"), TestCategory("US6500"), TestCategory("US6022")]
        [Priority(2)]
        [WorkItem(15828), WorkItem(15829), WorkItem(15832), WorkItem(15830), WorkItem(12306), WorkItem(12178), WorkItem(12310), WorkItem(12312)]
        [Owner("Madhav Purohit(madhav.purohit), Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
        public void AAAAAStudentAssessmentSummaryButtonAvailableWhenTakingAnAssessment()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);
                NavigationCommonMethods.Logout();

                Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                AssessmentCommonMethods.ClickAssessmentTile();
                AutomationAgent.Wait();

                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                Assert.IsTrue(AssessmentCommonMethods.VerifySummaryButtonInStudentView(), "Assessment summary button not found");
                //15828
                //AssessmentNameIsAvailableinStopScoringScreen();
                AssessmentCommonMethods.VerifyTimerContinuesInAssessmentSummaryScreen();

                //12306,//12178

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Assessment summary screen not found");
                //15829

                Random rnd1 = new Random();
                int random = rnd1.Next(1, 5);
                String tiletotap = AssessmentCommonMethods.GetQuestionNumberFromTile(random);
                AssessmentCommonMethods.ClickOnQuestionTile(random);
                AutomationAgent.Wait();
                string QuestionNoCOunt = AssessmentCommonMethods.GetCurrentQuestionNo();
                Assert.AreEqual(tiletotap, QuestionNoCOunt, "Match not found");
                //15832, 12174

                string total_Question = AssessmentCommonMethods.NavigateAndClickOnReviewAndSumbitButton();
                AssessmentCommonMethods.VerifyItemsWithNoResponsesOnAssessSummaryScreen(total_Question);
                //15830
                
                AssessmentCommonMethods.ClickOnQuestionTile(1);
                string Questions = AssessmentCommonMethods.TotalNoOfQuestionsInAssessment();
                AssessmentCommonMethods.NavigateAndClickOnReviewAndSumbitButton();
                for (int i = 1; i < Int32.Parse(Questions); i++)
                {
                    AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                    AssessmentCommonMethods.ClickAssessmentNextButton();
                }
                AssessmentCommonMethods.ClickReviewAndSubmitButton();    
                AssessmentCommonMethods.ClickSubmitButton();
                AssessmentCommonMethods.ClickOnSubmitButtonOnSubmitButtonPopUp();
                //15835, 12310, 15834

                Assert.IsTrue(AssessmentCommonMethods.VerifyUnitAssessmentTile(), "Tile not found");
                //12312

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
        [TestCategory("Assessment"), TestCategory("US6779"), TestCategory("US9055"), TestCategory("US6722")]
        [Priority(2)]
        [WorkItem(18663),WorkItem(18992), WorkItem(18993), WorkItem(18994), WorkItem(18995), WorkItem(18996), WorkItem(43645), WorkItem(43646), WorkItem(43647), WorkItem(43648)]
        [Owner("Madhav Purohit(madhav.purohit),Silky Manocha(silky.manocha), Varun Bhardwaj(varun.bhardwaj)")]
        public void TeacherAbleToTapOnScoreBoxToOpenScoringPanel()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item summary page not dispalyed");
                AssessmentCommonMethods.ClickOnScoreBox();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringPanel(), "Scoring panel is not displayed");
                //18992

                AssessmentCommonMethods.ClickOnTotalScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoreFlyoutMenu(), "Flyout Not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyDashOptionInFlyout(), "Dash Option Not Found");

                //TC43647,TC43645
                AssessmentCommonMethods.GiveTotalScoreToStudent("--");
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStudentIsScored(), "Student is not scored");

                //18994
                //FlyOutWillContainAdditionalDashOptionInOrderToRemoveScore();

                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickOnTotalScoreButton();
                AssessmentCommonMethods.GiveTotalScoreToStudent("2");
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsTrue(AssessmentCommonMethods.VerifyLoadingIcon(),"Screen not refreshed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentIsScored(), "Student is not scored");

                //TC43646,TC43648,18663
                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickOnTotalScoreButton();
                AssessmentCommonMethods.GiveTotalScoreToStudent("--");
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStudentIsScored(), "Student is not unscored");
                //18996
                //TeacherAbleToRemoveScoreBySelectingDash();


                AssessmentCommonMethods.ClickOnScoreBox("3");
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringPanel(), "Scoring panel is not displayed");
                AssessmentCommonMethods.ClickCriterionButtonScore();
                Assert.IsTrue(AssessmentCommonMethods.VerifyCriterionLevelScoreDisplaysAllNumbers(), "Criterion Level Score not Displays Numbers From 0 To Highest Level Of Mastery");
                AssessmentCommonMethods.SelectCriterionButtonScore("--");
                //18993
                //TappingOnCriterionLevelScoreDisplaysNumbersFrom0ToHighestLevelOfMastery();

                AssessmentCommonMethods.ClickCriterionButtonScore();
                AssessmentCommonMethods.SelectCriterionButtonScore("1");
                string CriterionButtonScore = AssessmentCommonMethods.GetCriterionButtonScore();
                Assert.IsTrue(CriterionButtonScore == "1", "score is not updated as per selection");
                //18995
                //TeacherAbleToTapOnANumberAssignScoreasCriterionLevelScoreOnItem();
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US6774")]
        [Priority(2)]
        [WorkItem(19018), WorkItem(19020)]
        [Owner("Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
        public void TeacherAbleToClickCloseButtonOnScreen()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item summary page not dispalyed");
                AssessmentCommonMethods.ClickOnScoreBox();

                Assert.IsTrue(AssessmentCommonMethods.VerifyCloseButtonOnScoringScreen(), "Close button is not displayed in Scoring Screen");
                AssessmentCommonMethods.ClickOnCrossIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is not displayed");
                //19018,19020
                AssessmentCommonMethods.ClickYesButtonInPopup(); 

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
        [TestCategory("Assessment"), TestCategory("US6775")]
        [Priority(1)]
        [WorkItem(19014), WorkItem(19016), WorkItem(19021), WorkItem(19024), WorkItem(19029), WorkItem(19030), WorkItem(19031), WorkItem(19032), WorkItem(19033), WorkItem(19034), WorkItem(19038),WorkItem(19040), WorkItem(19041)]
        [Owner("Madhav Purohit(madhav.purohit),Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
        public void StpScoringAvailableOnStopScoringScreen()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                Assert.IsTrue(AssessmentCommonMethods.VerifyScoreButton(), "Score Button is not present");
                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Scoring Overview page not dispalyed");
                //19014
                //TeacherIsTakenToScoringOverviewPageWhenTappingScore();

                string subtitle = AssessmentCommonMethods.GetSubtitleofScoringOverview();
                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickOnCrossIcon();

                Assert.IsTrue(AssessmentCommonMethods.VerifyScoredTabSelectedInStopScoringScreenByDefault(), "Scored Tab is not selected by default");
                //19021

                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is not displayed");
                AssessmentCommonMethods.ClickNotStartedInStopScoringScreen();
                string NumberOfStudents = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInNotStarted();
                Assert.IsTrue(Int32.Parse(NumberOfStudents) < 1000, "Number of student submitted but not score is not available - can't covert in to int");
                //19024
                //NumberofStudentsNotScoredDisplaysOnStopScoringScreen();


                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentNameInStopScoringScreen(subtitle), "Assessment name not found");
                //19016
                //AssessmentNameIsAvailableinStopScoringScreen();

                

                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringTextInStopScoringPopup(), "Stop Scoring? text not found");
                //19029

                Assert.IsTrue(AssessmentCommonMethods.VerifyYesButtonInStopScoringPopup(), "Yes button not found");
                //19030
                //YesButtonAvailableOnStopScoringScreen();

                Assert.IsTrue(AssessmentCommonMethods.VerifyNOButtonInStopScoringPopup(), "No button not found");
                //19031
                //NoButtonAvailableOnStopScoringScreen();

                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "page not found");
                //19032
                //UserNavigatedToScoringSummaryPageWhenClickingYesToStopScoring();


                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickOnCrossIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is not displayed");
                AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringPanel(), "Scoring Panel not found");
                Assert.IsFalse(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item summary page not dispalyed");

                AssessmentCommonMethods.ClickOnCrossIcon();

                //19033
                //UserNOTNavigatedToScoringSummaryPageWhenClickingNoOnStopScoring();

                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is not displayed");
                AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is displayed");

                Assert.IsFalse(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item summary page not dispalyed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringPanel(), "User is not on able to continue scoring");
                AssessmentCommonMethods.ClickOnCrossIcon();
                //19034
                //UserAbleToContinueScoringAfterTappingNoToStopScoring();

               
               
                AssessmentCommonMethods.ClickNotStartedInStopScoringScreen();
                string StudentCountNotStarted = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInNotStarted();
                Assert.IsTrue(Int32.Parse(StudentCountNotStarted) < 1000, "Number of student submitted but not score is not available - can't covert in to int");

                if (Int32.Parse(StudentCountNotStarted) > 0)
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInNotStarted(), "Student name not found");
                //19037

               
                AssessmentCommonMethods.ClickStartedInStopScoringScreen();
                string StudentCount = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInStarted();
                Assert.IsTrue(Int32.Parse(StudentCount) < 1000, "Number of student submitted but not score is not available - can't covert in to int");

                if (Int32.Parse(StudentCount) > 0)
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInStarted(), "Student name not found");
                //19038
                //NameAndNumberofStudentsStartedisAvailableonStopScoringScreen();

                
                AssessmentCommonMethods.ClickScoredOnStopScoringScreen();
                string StudentCountScored = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInScored();
                Assert.IsTrue(Int32.Parse(StudentCountScored) < 1000, "Number of student submitted but not score is not available - can't covert in to int");

                if (Int32.Parse(StudentCount) > 0)
                    Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInScored(), "Student name not found");
                //19040

                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring Popup is not displayed");
                AssessmentCommonMethods.ClickSubmittedInStopScoringScreen();
                string Students = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInSubmitted();
                Assert.IsTrue(Int32.Parse(Students) < 1000, "Number of student submitted but not score is not available - can't covert in to int");
                AssessmentCommonMethods.ClickYesButtonInPopup();
                //19041
                //NumberofStudentsWhoHaveSubmittedButNotScoredAvailableOnStopScoringScreen();
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
        [TestCategory("Assessment"), TestCategory("US6540")]
        [Priority(2)]
        [WorkItem(16178), WorkItem(16180), WorkItem(16182), WorkItem(16183)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyThatTeacherWillViewAllUnitsPresentinSectionFromAssessmentManagerPage()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                Assert.IsTrue(AssessmentCommonMethods.VerifyListOfAllTheItemsAvailableinUnitTitleDropDown(), "All Units not Present in  Section in Assessment Manager Page");
                //16178
                //VerifyThatTeacherWillViewAllUnitsPresentinSectionFromAssessmentManagerPage

                AutomationAgent.Click(100, 100);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                Assert.IsTrue(AssessmentCommonMethods.VerifyUserIsNavigatedToUnit(10), "User is not navigated to correct unit");
                //16180
                //VerifyThatUnitDisplayIsClickable

                AssessmentCommonMethods.OpenUnitSelectionDropDown();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentUnitSelection(10), "Assessment unit selection drop down not opened");
                AutomationAgent.Click(100, 100);
                Assert.IsFalse(AssessmentCommonMethods.VerifyAssessmentUnitSelection(10), "Assessment unit selection drop down opened");
                //16182
                //VerifyThattheUnitDropDownCanBeDismissedByTappingAnywhereOnThePage

                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not moved back on dashboard");
                //16183
                //VerifyBackButtonFunctionalityDisplayedOnUnitDisplayBar
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
        [TestCategory("Assessment"), TestCategory("US8566")]
        [Priority(2)]
        [WorkItem(26309)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyTeacherAbletoViewAndNavigateThroughAllTheItemsOrQuestionsAvailableinAssessment()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                AssessmentCommonMethods.TeacherAssessmentNavigation();
                AssessmentCommonMethods.ClickOnCrossIcon();
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
        [TestCategory("Assessment"), TestCategory("US9402"), TestCategory("US6754")]
        [Priority(1)]
        [WorkItem(45895), WorkItem(45896), WorkItem(45900), WorkItem(45899)]
        [Owner("Madhav Purohit(madhav.purohit), Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyReleasScoresButtonInactiveWhenTeacherHasScoredLessThan80PercentObservationsInSectionOnAssessmentOverviewPage()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewPage(), "Assessment Overview page is nmot displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyLessThan80PercentObservationScored(), "More Than 80% Observations has been scored");
                Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoreButtonActive(), "Release Score Button is active");
                //45895
                Assert.IsTrue(AssessmentCommonMethods.VerifyStaticTextNearReleaseScores(), "Static Text near release scores is not displayed");
                //45899
                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Scoring Overview page not dispalyed");
                Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoreButtonActiveScoringOverview(), "Release Scores button on Scoring Overview page is active");
                //45896, 18666
                //VerifyReleasScoresButtonInactiveWhenTeacherHasScoredLessThan80PercentObservationsInSectionOnScoringOverviewPage();

                Assert.IsTrue(AssessmentCommonMethods.VerifyStaticTextNearReleaseScores(), "Static Text near release scores is not displayed");
                //45900
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
        [TestCategory("Assessment"), TestCategory("US9402")]
        [Priority(1)]
        [WorkItem(45897), WorkItem(45898), WorkItem(45901), WorkItem(45902), WorkItem(45903), WorkItem(45904)]
        [Owner("varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyReleaseScoresScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickOnUAChecklist();

                Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonActive(), "Release score button not active");
                Assert.IsFalse(AssessmentCommonMethods.VerifyStaticTextNearReleaseScores(), "Static Text not found");
                //45901,45987

                AssessmentCommonMethods.ClickReleaseScoreButton();
                AssessmentCommonMethods.ClickonReleaseScoreYesbutton();
                AutomationAgent.Wait();
                Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonConvertedToDateTimeStamp(), "Date time Stamp Not found");
                //45903

                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonActiveScoringOverview(), "Release Scores button on Scoring Overview page is active");
                //45898
                Assert.IsFalse(AssessmentCommonMethods.VerifyStaticTextNearReleaseScores(), "Static Text near release scores is not displayed");
                //45902

                AssessmentCommonMethods.ClickReleaseScoreButtonActiveScoringOverview();
                AssessmentCommonMethods.ClickonReleaseScoreYesbutton();
                AutomationAgent.Wait();
                Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreButtonConvertedToDateTimeStampOnScoringOverview(), "Date time Stamp Not found");
                //45904
                AutomationAgent.Wait();

                AssessmentCommonMethods.ClicktoOpenScoredStudentInUAChecklist();
                AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection("3");
                Assert.IsFalse(AssessmentCommonMethods.VerifyRadioButtonforscoringInWritingSectionDeSelected("3"),"Radion button not get selected hence score not editable");
                //45907

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
        [TestCategory("Assessment"), TestCategory("US9735")]
        [Priority(1)]
        [WorkItem(51756), WorkItem(51757), WorkItem(51758), WorkItem(51759),WorkItem(16262)]
        [Owner("Madhav Purohit(madhav.purohit), Mohammed Saquib(mohammed.saquib),Silky Manocha(silky.manocha)")]
        public void VerifyThatTeacherIsAbleToHiderubricForHumanScoredQuestionsUsingHideButtonOnRubricTeacherPreview()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                //TC16262
                AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                string HideButtonRubric = AssessmentCommonMethods.GetRubricHideButtonText();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricHideButton(), "Hide Button on rubric is not visible");
                Assert.AreEqual("Hide", HideButtonRubric, "Hide button on rubric not visible");
                AssessmentCommonMethods.ClickRubricHideButton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyRubricHideButton(), "Hide Button on rubric is visible");

                AssessmentCommonMethods.ClickRubricHideButton();
                //51756
               // VerifyThatTeacherIsAbleToHiderubricForHumanScoredQuestionsUsingHideButtonOnRubricTeacherPreview();

                Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Item Preview page is not displayed");
                AssessmentCommonMethods.ClickRubricHideButton();

                string RubricButton = AssessmentCommonMethods.GetRubricButtonText();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricButton(), "Rubric Button on rubric is not visible");
                Assert.AreEqual("Rubric", RubricButton, "Rubric button on rubric not visible");
                AssessmentCommonMethods.ClickRubricHideButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricIsOpen(), "Rubric is not visible");
                AssessmentCommonMethods.ClickOnCrossIcon();
               // 51757
                //VerifyThatTeacherIsAbleToOpenRubricForHumanScoredQuestionsUsingRubricButtonOnRubricInTeacherPreview();
                AssessmentCommonMethods.WaitForPageToLoad();
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringPanel(), "Item Scoring Page is not displayed");
                string RubricHideButton = AssessmentCommonMethods.GetRubricHideButtonText();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricHideButton(), "Hide Button on rubric is not visible");
                Assert.AreEqual("Hide", RubricHideButton, "Hide button on rubric not visible");
                AssessmentCommonMethods.ClickRubricHideButtonOnScoringScreen();
                Assert.IsFalse(AssessmentCommonMethods.VerifyRubricHideButton(), "Hide Button on rubric is visible");
                AssessmentCommonMethods.ClickRubricHideButtonOnScoringScreen();
               // 51758
               // VerifyThatTeacherIsAbleToHiderubricForHumanScoredQuestionsUsingHideButtonOnRubricItemScoringPage();
                AutomationAgent.Wait(1000);
                AssessmentCommonMethods.ClickRubricHideButtonOnScoringScreen();
                string ButtonRubric = AssessmentCommonMethods.GetRubricButtonText();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricButton(), "Rubric Button on rubric is not visible");
                Assert.AreEqual("Rubric", ButtonRubric, "Rubric button on rubric not visible");
                AssessmentCommonMethods.ClickRubricHideButtonOnScoringScreen();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricIsOpen(), "Rubric is not visible");
                //51759
                //VerifyThatTeacherIsAbleToOpenRubricForHumanScoredQuestionsUsingRubricButtonOnRubricItemScoringPage();
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US8995")]
        [Priority(1)]
        [WorkItem(44133)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ViewReportsButtonFromExerciseWillOpenGroupAssessmentReportForExercise()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickViewReportButton();
                String ReportTitle = AssessmentCommonMethods.GetTextFromAssessmentResultSummary();
                Assert.AreEqual("Assessment Result Summary", ReportTitle, "Report Title Not Found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentReportPage(), "Group Assessment report page is not visible");

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
        [TestCategory("Assessment"), TestCategory("US9227")]
        [Priority(1)]
        [WorkItem(45348), WorkItem(45350), WorkItem(45360), WorkItem(45361), WorkItem(45368), WorkItem(45369), WorkItem(45367)]
        [Owner("Madhav Purohit(madhav.purohit), Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj), Akanksha Gautam(akanksha.gautam)")]
        public void VerifyRefreshIconIsAvailableOnDiffferentScreens()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);

                AssessmentCommonMethods.WaitForPageToLoad();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIcon(), "Refresh icon is not visible");
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIconAtTopRight(), "Refresh Icon is not dispalyed at top right corner");
                //45348
                //VerifyRefreshIconIsAvailableOnAssessmentManagerScreen


                Assert.IsTrue(AssessmentCommonMethods.VerifyLastUpdatedSection(), "Last Updated Section is not displayed");
                //string OldTime1 = AssessmentCommonMethods.GetLastUpdatedTime();
                DateTime today = DateTime.Today;
                string currenttime1 = DateTime.Now.ToString("h:mm tt");
                string todayDate1 = today.ToString("MM-dd-yyyy");
                string lastUpdatedDate1 = AssessmentCommonMethods.GetLastUpdatedDate();
                AssessmentCommonMethods.ClickRefreshIcon();
                string NewTime1 = AssessmentCommonMethods.GetLastUpdatedTime();
                Assert.AreEqual(todayDate1, lastUpdatedDate1, "Last Updated Date is not updated as per system date");
                Assert.AreEqual(currenttime1, NewTime1, "Time is not updated after clicking refresh icon");
                //45350

                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewPage(), "Assessment Overview page is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIcon(), "Refresh icon is not visible");
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIconAtTopRight(), "Refresh Icon is not dispalyed at top right corner");
                //45360
                //VerifyRefreshIconIsAvailableOnAssessmentOverviewScreen();

                Assert.IsTrue(AssessmentCommonMethods.VerifyLastUpdatedSection(), "Last Updated Section is not displayed");
                //string OldTime = AssessmentCommonMethods.GetLastUpdatedTime();
                DateTime today1 = DateTime.Today;
                string currenttime = DateTime.Now.ToString("h:mm tt");
                string todayDate = today1.ToString("MM-dd-yyyy");
                string lastUpdatedDate = AssessmentCommonMethods.GetLastUpdatedDate();
                AssessmentCommonMethods.ClickRefreshIcon();
                string NewTime = AssessmentCommonMethods.GetLastUpdatedTime();
                Assert.AreEqual(todayDate, lastUpdatedDate, "Last Updated Date is not updated as per system date");
                Assert.AreEqual(currenttime, NewTime, "Time is not updated after clicking refresh icon");
                //45361
                //VerifyLatestDateAndTimeIsDisplayedInLastUpdatedSectionAfterRefreshIconIsClicked();

                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIcon(), "Refresh icon is not visible");
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIconAtTopRight(), "Refresh Icon is not dispalyed at top right corner");
                //45368
                //VerifyRefreshIconIsAvailableOnScoringOverviewScreen();

                //string Old = AssessmentCommonMethods.GetLastUpdatedTime();
                DateTime today2 = DateTime.Today;
                string todayDate2 = today2.ToString("MM-dd-yyyy");
                string current = DateTime.Now.ToString("h:mm tt");
                string lastUpdatedDate2 = AssessmentCommonMethods.GetLastUpdatedDate();
                AssessmentCommonMethods.ClickRefreshIcon();
                string NewTime2 = AssessmentCommonMethods.GetLastUpdatedTime();
                Assert.AreEqual(todayDate2, lastUpdatedDate2, "Last Updated Date is not updated as per system date");
                Assert.AreEqual(current, NewTime2, "Time is not updated after clicking refresh icon");
                //45369
                //VerifyDateAndTimeOnAfterClickingRefreshIcon();

                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                string lastUpdatedDate3 = AssessmentCommonMethods.GetLastUpdatedDate();
                string NewTime3 = AssessmentCommonMethods.GetLastUpdatedTime();
                Assert.AreEqual(todayDate2, lastUpdatedDate2, "Last Updated Date is not updated as per system date");
                Assert.AreEqual(NewTime3, NewTime2, "Time is not updated after clicking refresh icon");
                //45367

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
        [TestCategory("Assessment"), TestCategory("US8566")]
        [Priority(2)]
        [WorkItem(27038)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifytheFunctionalityofNextButtonInPreviewAssessmentFlow()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                AssessmentCommonMethods.ClickAssessmentTile();
                AutomationAgent.Wait();
                string[] QuestiondetailinBottom = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                for (int i = Int32.Parse(QuestiondetailinBottom[2]); i < Int32.Parse(QuestiondetailinBottom[6]); i++)
                {
                    AssessmentCommonMethods.ClickAssessmentNextButtonTestPreview();
                    string[] QuestiondetailinBottomNxtPage = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                    Assert.AreEqual(i + 1, Int32.Parse(QuestiondetailinBottomNxtPage[2]));
                }
                AssessmentCommonMethods.ClickOnCrossIcon();
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
        [TestCategory("Assessment"), TestCategory("US6812")]
        [Priority(1)]
        [WorkItem(19895),WorkItem(52106)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyPreviousButtonIsActiveOnAnyQuestionOtherThanFirstQuestionOnPreviewAassessmentPage()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonActiveOnTheFirstQuestion(), "Previous button found active on the first question");
                
                //TC52106
                AssessmentCommonMethods.ClickStandardsTab();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsUnavialbleText(),"Standards Unavilable text is not present");

                //TC52127
                Assert.IsFalse(AssessmentCommonMethods.VerifyRubricSectionUnderStandardsTab(), "Rubric section is present under standards tab");

                //TC52108
                Assert.IsTrue(AssessmentCommonMethods.VerifyNoApplicableInformationText(), "No Applicable Information avilable text is not present");

                AssessmentCommonMethods.ClickOnCrossIcon();
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
        [TestCategory("Assessment"), TestCategory("US6541"), TestCategory("US9946")]
        [Priority(2)]
        [WorkItem(16272), WorkItem(16264), WorkItem(16257), WorkItem(52390)]
        [Owner("Madhav Purohit(madhav.purohit), Silky Manocha(silky.manocha)")]
        public void PreviousButtonGrayedOutWhenTeacherPreviewingFIRSTQuestionOfAssessment()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);

                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(2);

                AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();

                //TC52390
                AssessmentCommonMethods.ClickScoringNextButton();
                AssessmentCommonMethods.ClickScoringNextButton();

                AssessmentCommonMethods.ClickOnShowSampleAnswerButton();
                AssessmentCommonMethods.VerifyCrossButtonOnShowSampleAnswerModal();
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerModalDisplayed(), "Sample Answer Modal is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerForQuestionIsDisplayed(), "Sample Answer for Question is not displayed");
                AssessmentCommonMethods.ClickOnCrossButtonOnShowSampleAnswerModal();

                //TC16264
                AssessmentCommonMethods.ClickStandardsButtonAvailableinAssessmentPreview();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsAppearForSpecificQuestion(), "Standards are not available");

                //TC16272
                Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonInAssessment(), "Previous button not found");

                AssessmentCommonMethods.ClickOnCloseButton();

                //TC16257
                Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLink(), "Preview Link is not present");

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
        [TestCategory("Assessment"), TestCategory("US6535")]
        [Priority(2)]
        [WorkItem(16125), WorkItem(16126), WorkItem(16127), WorkItem(16129)]
        [Owner("Mohammed Saquib(mohammed.saquib),Madhav Purohit(madhav.purohit)")]
        public void VerifyFeaturesOnAssessmentManagerMainScreens()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(9);
                string[] unitnameandnumber = AssessmentCommonMethods.GetUnitNameANdNumber();
                NavigationCommonMethods.NavigateToMyDashboard();
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.WaitForPageToLoad();
                string[] assessmentunittitlename = AssessmentCommonMethods.GetTextFromAssessmentUnitTile();
                string[] aftersplit = assessmentunittitlename[0].Split(':');
                Assert.AreEqual(unitnameandnumber[1].ToUpper().Replace(" ", ""), aftersplit[0].ToUpper().Replace(" ", ""), "Unit Number are not equal");
                Assert.AreEqual(unitnameandnumber[2].Replace(" ", ""), aftersplit[1].Replace(" ", ""), "Unit Name are not equal");

                AssessmentCommonMethods.OpenUnitSelectionDropDown();

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentUnitSelection(10), " unit selection drop down is not clickable");
                //16125
                //VerifyStatAndTitleOnAssessmentManagerPageFroTeacherView();
                AutomationAgent.Click(100, 100);
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreenScrollable(1));
                //16129
                //VerifyAssessmentManagerScreenScrollable();


                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.WaitForPageToLoad();
                Assert.IsTrue(AssessmentCommonMethods.VerifyFixedAssessmentTab(), "Fixed assessment tab not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyOnGoingAssessmentsTab(), "Ongoing assessment tab not found");
                //16126

                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                string ActualAssessmentTitle = AssessmentCommonMethods.GetTextFromAssessmentOverviewScreen();
                Assert.AreEqual("Assessment Progress Overview", ActualAssessmentTitle, "Assessment Title Mismatch");
                //16127
                //VerifyFunctionalityOfAssessmentRowFromAssessmentManagerPage

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
        [TestCategory("Assessment"), TestCategory("US6452")]
        [Priority(2)]
        [WorkItem(15938), WorkItem(15939)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void ViewAssessmentsButtonDisplaysOnTeacherDashboard()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentButtonInDashBoard(UnitStatus[4]));

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
         [TestCategory("Assessment"), TestCategory("US6591")]
         [Priority(2)]
         [WorkItem(16160)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void StudentCellfunctionalityUnlockingtheAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);

                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitleInCentre(), "Assessment Progress Overview is not in the center of the nav bar");
                 AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Lesson Preview Item Screen is not displayed");
                 AssessmentCommonMethods.ClickOnCloseButton();

                 AssessmentCommonMethods.WaitForPageToLoad();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewTitleInCentre(), "Assessment Progress Overview is not in the center of the nav bar");
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
         [TestCategory("Assessment"), TestCategory("US6496")]
         [Priority(1)]
         [WorkItem(15787), WorkItem(15788)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void OverlayDisplaysStudentTapsAssessmentTileButton()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 Login studentlogin = Login.GetLogin("FordAssessmentStudent");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                 AssessmentCommonMethods.AssessmentTilePopUpFound();
                 AssessmentCommonMethods.VerifyCancelButtonOnStartAssessmentPopUp();
                 AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp();
                 AssessmentCommonMethods.ClickCancelButtonOnStartAssessmentPopUp();
                 //15787
                 //OverlayDisplaysStudentTapsAssessmentTileButton

                 AssessmentCommonMethods.ClickCancelButtonOnStartAssessmentPopUp();
                 AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp();
                 //15788
                 //StudentTapStartOrCancelAssessmentOverlay
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
         [TestCategory("Assessment"), TestCategory("US6626")]
         [Priority(2)]
         [WorkItem(16239), WorkItem(16242)]
         [Owner("Madhav Purohit(madhav.purohit), Akanksha.Gautam(akanksha.gautam)")]
         public void TeacherAbletoUnlockAssessmentForIndividualStudents()
         {
             try
             {
                 Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");

                 Login studentLogin = Login.GetLogin("");


                 NavigationCommonMethods.LoginApp(teacherLogin);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(7);

                 //Color sampleColor = Color.FromArgb(255, 204, 204, 204);
                 //Assert.IsTrue(AssessmentCommonMethods.VerifyStartedStudentRowIsGreyed(sampleColor), "Started Student Row is not Grey in Color");
                 //16242

                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
                 Assert.IsTrue(LockedStudentNoAfter < LockedStudentNo || LockedStudentNoAfter > LockedStudentNo, "student is not unlocked");
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
         [TestCategory("Assessment"), TestCategory("US6626")]
         [Priority(2)]
         [WorkItem(16236), WorkItem(16350)]
         [Owner("Madhav Purohit(madhav.purohit), Varun Bhardwaj(varun.bhardwaj)")]
         public void ByDefaultAssessmentsAreLockedForAllStudentsUntilTeacherUnlocksAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockUnlockOverlay(), "Lock/Unlock Overlay is not displayed");
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
                 Assert.AreEqual(LockedStudentNoAfter, LockedStudentNo, "student is not unlocked");

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickUnlockAllStudentInUnlockAssessment();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                 AutomationAgent.Wait();
                 string AssessmentLockStatusafter1 = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter1 = AssessmentLockStatusafter1.Split(' ');
                 string Totalstudentafter1 = lockstatusafter1[2];
                 string[] lockednoafter1 = lockstatusafter1[2].Split('/');
                 int LockedStudentNoAfter1 = Int32.Parse(lockednoafter1[0]);

                 Assert.IsTrue(LockedStudentNoAfter1 == 0, "assessment not unlocked for all trhe student");
                 //16238
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
         [TestCategory("Assessment"), TestCategory("US6626")]
         [Priority(2)]
         [WorkItem(16241), WorkItem(16244)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void LockResetFeatureMustBeUsedtoReLockAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                
                 AssessmentCommonMethods.ClickUnlockAllStudentInUnlockAssessment();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 Assert.IsTrue(LockedStudentNo == 0, "assessment not unlocked for all trhe student");

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockAllStudentInUnlockAssessment(), "Unlock All is not displayed");
                 AssessmentCommonMethods.ClickLockAllStudentInUnlockAssessment();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
                 Assert.IsTrue(LockedStudentNoAfter > 0, "assessment not unlocked for all trhe student");

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
         [TestCategory("Assessment"), TestCategory("US6626")]
         [Priority(2)]
         [WorkItem(16245), WorkItem(16243), WorkItem(16346)]
         [Owner("Madhav Purohit(madhav.purohit), Akanksha Gautam(akanksha.gautam), Varun Bhardwaj(varun.bhardwaj)")]
         public void TeacherAbletoLockAssessmentForIndividualStudentifStudentHasNotYetStarted()
         {
             try
             {
                 Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");

                 Login studentLogin = Login.GetLogin("AssessmentStudent");
                 NavigationCommonMethods.LoginApp(studentLogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 Color sampleColor = Color.FromArgb(255, 169, 169, 169);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentTileGreyed(sampleColor, taskInfo.Lesson), "Assessment tile is not grey");
                 NavigationCommonMethods.Logout();

                 NavigationCommonMethods.LoginApp(teacherLogin);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(8);
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 //Lock for same student
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(1);
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);

                 Assert.IsTrue(LockedStudentNoAfter > LockedStudentNo || LockedStudentNoAfter < LockedStudentNo, "assessment not unlocked for all trhe student");
                 NavigationCommonMethods.Logout();
                 NavigationCommonMethods.LoginApp(studentLogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 Assert.IsFalse(AssessmentCommonMethods.VerifyAssessmentTileHiglighted(sampleColor, taskInfo.Lesson), "Assessment tile is not grey");
                 NavigationCommonMethods.Logout();
                 //16243

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

         [TestMethod()]//done
         [TestCategory("Assessment"), TestCategory("US6542")]
         [Priority(1)]
         [WorkItem(17704)]
         [Owner("Mohammed Saquib(mohammed.saquib)")]
         public void LockForCountReflectionOnAssessmentOverviewScreen()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 
                 AssessmentCommonMethods.ClickUnlockAllStudentInUnlockAssessment();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 Assert.IsTrue(LockedStudentNo == 0, "assessment not unlocked for all the student");

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockAllStudentInUnlockAssessment(), "Unlock All is not displayed");
                 AssessmentCommonMethods.ClickLockAllStudentInUnlockAssessment();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
                 Assert.IsTrue(LockedStudentNoAfter > 0, "assessment not unlocked for all the student");

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
         [TestCategory("Assessment"), TestCategory("US6542")]
         [Priority(1)]
         [WorkItem(16323), WorkItem(16344)]
         [Owner("Mohammed Saquib(mohammed.saquib)")]
         public void VerifyCountOfLockedLabelIncrementsWhenTeacherLocksAnyStudent()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickUnlockAllStudentInUnlockAssessment();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);



                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(8);
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);

                 Assert.IsTrue(LockedStudentNoAfter > LockedStudentNo || LockedStudentNoAfter < LockedStudentNo, "assessment not unlocked for all the student");
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
         [TestCategory("Assessment"), TestCategory("US6542")]
         [Priority(1)]
         [WorkItem(16324), WorkItem(16357)]
         [Owner("Mohammed Saquib(mohammed.saquib)")]
         public void VerifyCountOfLockedLabelIncrementsDecrementsWhenTeacherUnlocksAnyStudent()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(8);
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);

                 Assert.IsTrue(LockedStudentNo > LockedStudentNoAfter || LockedStudentNo < LockedStudentNoAfter, "assessment not unlocked for all the student");
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
         [TestCategory("Assessment"), TestCategory("US6542")]
         [Priority(1)]
         [WorkItem(16325)]
         [Owner("Mohammed Saquib(mohammed.saquib)")]
         public void VerifyFunctionalityOfDoneButtonOnLockUnlockPopup()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(6);
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyLockUnlockOverlay(), "LockUnlock Overlay is not found");

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);

                 Assert.IsTrue(LockedStudentNo > LockedStudentNoAfter || LockedStudentNo < LockedStudentNoAfter, "assessment not unlocked for all the student");
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
         [TestCategory("Assessment"), TestCategory("US6542"), TestCategory("US6623")]
         [Priority(1)]
         [WorkItem(16329), WorkItem(16362), WorkItem(16371), WorkItem(16372)]
         [Owner("Mohammed Saquib(mohammed.saquib)")]
         public void VerifyLockUnlockScreenDisappearsWwhenTeacherClicksOutsideThePopUp()
         {
             try
             {
                 Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");

                 NavigationCommonMethods.LoginApp(teacherLogin);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockUnlockOverlay(), "LockUnlock Overlay is not found");
                 AutomationAgent.Click(1215, 789);
                 //AssessmentCommonMethods.ClickOnStudentName(7);
                 Assert.IsFalse(AssessmentCommonMethods.VerifyLockUnlockOverlay(), "LockUnlock Overlay is  found");
                 //AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string[] no = AssessmentCommonMethods.GetNumberOfStudentsInAssessmentOverview().Split(' ');
                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyZeroStudentsStartedFieldInAssessmentRow(1, no[0]), "Students are not 0 in Started field of Assessment Row");
                 //16372

                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 string[] no1 = AssessmentCommonMethods.GetNumberOfStudentsInAssessmentOverview().Split(' ');
                 int startedNo = AssessmentCommonMethods.GetNumberOfStudentsStartedAssessment();
                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentsNumberStartedFieldInAssessmentRow(1, startedNo, no1[0]), "Students are not are not similar");
                 //16373

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
         [TestCategory("Assessment"), TestCategory("US8566")]
         [Priority(2)]
         [WorkItem(27023), WorkItem(27037), WorkItem(27024)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void VerifyThatTeacherisNotAbletoSubmitTheAssessmentAndThereIsNoNextButtonOnLast()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 string[] QuestiondetailinBottom = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                 for (int i = Int32.Parse(QuestiondetailinBottom[2]); i < Int32.Parse(QuestiondetailinBottom[6]); i++)
                 {
                     AssessmentCommonMethods.ClickAssessmentNextButtonTestPreview();
                     string[] QuestiondetailinBottomNxtPage = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                     Assert.AreEqual(i + 1, QuestiondetailinBottomNxtPage[2]);
                 }

                 Assert.IsFalse(AssessmentCommonMethods.VerifySubmitButtonInLastQuestionOfAssessment(), "submit button available");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyAssessmentNextButtonTestPreview(), "next button available");
                 //27023,27037

                 AssessmentCommonMethods.ClickOnCrossIcon();
                 Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "lesson browser page not found");
                 //27024
                 //VerifyTheFunctionalityofTheCrossIconOnTopOfPreviewAssessmentPage();

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
         [TestCategory("Assessment"), TestCategory("US8566")]
         [Priority(2)]
         [WorkItem(27036)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void VerifyThatPreviousButtonisDisabledonFirstQuestionofTheAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonInAssessment(), "previous button enabled for 1st question");
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "lesson browser page not found");
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
         [TestCategory("Assessment"), TestCategory("US8566")]
         [Priority(2)]
         [WorkItem(27040)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void VerifytheFunctionalityofThePreviousButtoninPreviewAssessmentFlow()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();

                 AssessmentCommonMethods.ClickAssessmentNextButtonTestPreview();
                 string[] QuestiondetailinBottomNxtPage = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();

                 AssessmentCommonMethods.ClickAssessmentPreviousButton();
                 string[] QuestiondetailinBottomPrevPage = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                 Assert.IsTrue(Int32.Parse(QuestiondetailinBottomPrevPage[2]) < Int32.Parse(QuestiondetailinBottomNxtPage[2]), "previous button not moving assessment to previous page");
                 AssessmentCommonMethods.ClickOnCrossIcon();
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
         [TestCategory("Assessment"), TestCategory("US8566")]
         [Priority(2)]
         [WorkItem(26308)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void VerifyThatStartAssessmentDialogNotDisplayedonClickingAssessmentTileLessonBrowser()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp(), "start assessment doalog appearing");
                 AssessmentCommonMethods.ClickOnCrossIcon();
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
         [TestCategory("Assessment"), TestCategory("US8566")]
         [Priority(2)]
         [WorkItem(27020), WorkItem(27017)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void VerifyTeacherisAbletoViewStandardsAndThatTeacherisAbletoInteractWithEachQuestionUsingMouse()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 string[] QuestiondetailinBottom = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                 for (int i = Int32.Parse(QuestiondetailinBottom[2]); i < Int32.Parse(QuestiondetailinBottom[6]); i++)
                 {
                     Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsButtonAvailableinAssessmentPreview(), "standards button not available");
                     AssessmentCommonMethods.ClickStandardsButtonAvailableinAssessmentPreview();
                     AssessmentCommonMethods.ClickAssessmentNextButtonTestPreview();
                     string[] QuestiondetailinBottomNxtPage = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                     Assert.AreEqual(i + 1, QuestiondetailinBottomNxtPage[2]);
                 }
                 AssessmentCommonMethods.ClickOnCrossIcon();
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
         [TestCategory("Assessment"), TestCategory("US8566")]
         [Priority(2)]
         [WorkItem(27016)]
         [Owner("Madhav Purohit(madhav.purohit)")]
         public void VerifyTeacherisAbleViewRubricifAvailableCorrespondingToAnyQuestionInReadOnlyMode()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 string[] QuestiondetailinBottom = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                 bool isRubricavailable = false;
                 for (int i = Int32.Parse(QuestiondetailinBottom[2]); i < Int32.Parse(QuestiondetailinBottom[6]); i++)
                 {
                     if (AssessmentCommonMethods.VerifyRubricIsAvailableOnScreen())
                     {
                         isRubricavailable = true;
                         break;
                     }
                     AssessmentCommonMethods.ClickAssessmentNextButtonTestPreview();
                     string[] QuestiondetailinBottomNxtPage = AssessmentCommonMethods.GetBottomTextAboutQuestionStatus();
                     Assert.AreEqual(i + 1, QuestiondetailinBottomNxtPage[2]);
                 }
                 Assert.IsTrue(isRubricavailable, "Teacher can't see rubric for assessment");
                 AssessmentCommonMethods.ClickOnCrossIcon();
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
        [TestCategory("Assessment"), TestCategory("US6627")]
        [Priority(2)]
        [WorkItem(16205), WorkItem(16201), WorkItem(16206), WorkItem(16203), WorkItem(16211), WorkItem(16213)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionAndNumberofStudentsInSectionIsListed()
        {
            try
            {

                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "not on assessment overview screen");
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewContainsSectionName(UnitStatus[4]), "assessment overview screen does not contains Section name");
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewContainsNumberOfStudents(), "assessment overview screen does not contains number of students");
                //16205,16201

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "not on assessment overview screen");
                Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLink(), " assessment overview screen does not contains preview assessment link");
                //16206


                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "not on assessment overview screen");
                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "assessment manager screen not available");
                //16203
                
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "not on assessment overview screen");
                string NumberOfStudentsNS = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInNotStartedAssessmentOverview();
                if (Int32.Parse(NumberOfStudentsNS) == 0)
                {
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoStudentsLabel(), "No students labe message not found");
                }
                AssessmentCommonMethods.ClickStartedInAssessmentOverviewScreen();
                string NumberOfStudentsStarted = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInStartedAssessmentOverviewScreen();
                if (Int32.Parse(NumberOfStudentsStarted) == 0)
                {
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoStudentsLabel(), "No students labe message not found");
                }
                AssessmentCommonMethods.ClickSubmittedInAssessmentOverviewScreen();
                string NumberOfStudentsSubmt = AssessmentCommonMethods.VerifyNumberofStudentsAvailableInSubmittedAssessmentOverview();
                if (Int32.Parse(NumberOfStudentsSubmt) == 0)
                {
                    Assert.IsTrue(AssessmentCommonMethods.VerifyNoStudentsLabel(), "No students labe message not found");
                }
                //16211

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "not on assessment overview screen");
                Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                string[] lockstatus = AssessmentLockStatus.Split(' ');
                string Totalstudent = lockstatus[2];
                string[] lockedno = lockstatus[2].Split('/');
                int LockedStudentNo = Int32.Parse(lockedno[0]);

                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                AssessmentCommonMethods.ClickOnStudentName(10);
                AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                string Totalstudentafter = lockstatusafter[2];
                string[] lockednoafter = lockstatusafter[2].Split('/');
                int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
               
                Assert.IsTrue(LockedStudentNo > LockedStudentNoAfter || LockedStudentNo < LockedStudentNoAfter, "assessment not unlocked for all the student");
                //16213

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
        [TestCategory("Assessment"), TestCategory("US9404")]
        [Priority(1)]
        [WorkItem(51999), WorkItem(51994), WorkItem(51995), WorkItem(51997), WorkItem(52000), WorkItem(52001), WorkItem(52015), WorkItem(52017), WorkItem(52018)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyObservationScoreCard()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickOnUACheckList();
                AssessmentCommonMethods.ClickScoreButton();

                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentsNameOrderNyLastName(), "Students Name is not ordered by their Last Name");
                //51999

                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item summary page not dispalyed");
                //51994

                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIcon(), "Screen behing loading spinner is active");
                AssessmentCommonMethods.VerifyDateAndTimeFromScoringOverviewScreen();
                //51995

                Assert.IsTrue(AssessmentCommonMethods.VerifyNotScoredCategory(), "Not scored category not found");

                Assert.IsTrue(AssessmentCommonMethods.VerifyScoredCategory(), "Category not found");
                //51997

                Assert.IsTrue(AssessmentCommonMethods.VerifyObservationScoreCardActive(), "Card Not Active");
                //52000

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringColumnNumber(), "#1 #2 #3 not found");
                //52001

               

                AssessmentCommonMethods.ClickOnScoreBox();

                Assert.IsTrue(AssessmentCommonMethods.VerifyCheckListScoringScreen(), "Checklist scoring screen not found");
                //52015

                AssessmentCommonMethods.ClickNextStudentButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyObservationOneGetOpen(), "Checklist scoring screen not found");
                //52017

                Assert.IsTrue(AssessmentCommonMethods.VerifyChecklistInCentreOfScreen(), "Check List is not in the centre");
                //52018

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US9361")]
        [Priority(1)]
        [WorkItem(45502), WorkItem(45504), WorkItem(45506), WorkItem(45507), WorkItem(45511)]
        [Owner("Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyCrossIconOnStopScoringScreen()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickOnUACheckList();
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();

                AssessmentCommonMethods.ClickOnCrossIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(),"Stop scoring screen not found");
                //45502

                Assert.IsTrue(AssessmentCommonMethods.VerifyYesButtonInStopScoringPopup(),"Yes button not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyNOButtonInStopScoringPopup(),"No button not found");
                //45504

                AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item preview page not found");
                //45506

                AssessmentCommonMethods.ClickOnCrossIcon();

                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop scoring screen not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item preview page not found");
                //45507
               
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
        [TestCategory("Assessment"), TestCategory("US9404")]
        [Priority(1)]
        [WorkItem(52017)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyObservationNumber()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickOnUACheckList();
                AssessmentCommonMethods.ClickScoreButton();


                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US9488")]
        [Priority(1)]
        [WorkItem(45564), WorkItem(45566)]
        [Owner("Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyScreenBehindSpinnerIsInactiveOngoingAssess()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickOnUACheckList();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenBehindSpinnerIsInactive(), "Screen behing loading spinner is active");

                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickRefreshIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenBehindSpinnerIsInactive(), "Screen behing loading spinner is active");

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
        [TestCategory("Assessment"), TestCategory("US9488")]
        [Priority(1)]
        [WorkItem(45561), WorkItem(45562), WorkItem(45563), WorkItem(45565)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyScreenBehindSpinnerIsInactive()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.WaitForPageToLoad();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenBehindSpinnerIsInactiveAssessManagerScreen(), "Screen behing loading spinner is active");
                //45561

                AssessmentCommonMethods.WaitForPageToLoad();
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenBehindSpinnerIsInactive(), "Screen behing loading spinner is active");
                //45562

                AssessmentCommonMethods.WaitForPageToLoad();
                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenBehindSpinnerIsInactiveInScoringOverview(), "Screen behing loading spinner is active");
                //45563

                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                AssessmentCommonMethods.ClickOnUARubric();
                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenBehindSpinnerIsInactiveInScoringOverview(), "Screen behing loading spinner is active");
                //45565

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

       // [TestMethod()]
        [TestCategory("Assessment"), TestCategory("US6497")]
        [Priority(1)]
        [WorkItem(15807), WorkItem(15804), WorkItem(15806), WorkItem(15808), WorkItem(15805)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void BackwardButtonAvailableInTestPlayer()
        {
            try
            {

                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.VerifyAssessmentOverviewTitle();
                Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Unlock Assessment Link is not visible");

                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                AssessmentCommonMethods.ClickOnStudentName(20);
                AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                NavigationCommonMethods.Logout();


                Login studentlogin = Login.GetLogin("FordAssessmentStudent");
                TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                AssessmentCommonMethods.AssessmentTilePopUpFound();
                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                AssessmentCommonMethods.VerifyTestPlayerOpenInWebView();
                AssessmentCommonMethods.VerifyNavigationInTestPlayer();
                AssessmentCommonMethods.VerifyAssessmentTitlePresent();
                AutomationAgent.CloseApp();
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
        [TestCategory("Assessment"), TestCategory("US6596")]
        [Priority(1)]
        [WorkItem(16199), WorkItem(16204)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void AssessmentScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyBackButtonisDisplayed(), "Back Button not found.");
                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "assessment manager screen not available");
                //16199

                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Item screen not present");
                AssessmentCommonMethods.ClickOnCrossIcon();
                //16204

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
        [TestCategory("Assessment"), TestCategory("US9846")]
        [Priority(1)]
        [WorkItem(52325)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyObservationChecklist()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickOnUACheckList();
                AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyObservationChecklist(), "Observation check list not found");
                AssessmentCommonMethods.ClickOnCrossIcon();
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
        [TestCategory("Assessment"), TestCategory("US6773"), TestCategory("US6771")]
        [Priority(1)]
        [WorkItem(18593), WorkItem(18596), WorkItem(19012), WorkItem(19005), WorkItem(19006), WorkItem(19003)]
        [Owner("Mohammed Saquib(mohammed.saquib),Silky Manocha(silky.manocha)")]
        public void VerifyPreviousButtonIsNotAvailableWhenonFirstQuestionOfTheAssessmentWhileScoring()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox("1");

                //TC18593
                Assert.IsTrue(AssessmentCommonMethods.VerifyPreviousButtonINActiveOnTheFirstQuestionOfScoringScreen(), "Previous button found active on the first question");

                //TC19005
                AssessmentCommonMethods.ClickStudentNameOnItemScoringPage();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentListDropdownOnItemScoringPage(), "Student List dropdown is not displayed");

                //TC19003
                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNotScoredStatusInDropDown(), "Student not scored status is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNamesPresentInDropdown(), "Student name is not present in dropdown");

                //TC19006
                AssessmentCommonMethods.ClickOutsideOfStudentListDropdownOnItemScoringPage();
                Assert.IsFalse(AssessmentCommonMethods.VerifyStudentListDropdownOnItemScoringPage(), "Student List dropdown is displayed");

                //TC19012
                String QuestionNo = AssessmentCommonMethods.GetCurrentQuestionNo();
                AssessmentCommonMethods.ClickNextStudentButton();
                String QuestionNoForNextStudent = AssessmentCommonMethods.GetCurrentQuestionNo();
                Assert.AreEqual<string>(QuestionNo, QuestionNoForNextStudent);

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US6773")]
        [Priority(1)]
        [WorkItem(18594), WorkItem(18595)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyPreviousButtonIsNotAvailableWhenonLastQuestionOfTheAssessmentWhileScoring()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();

                Assert.IsTrue(AssessmentCommonMethods.VerifyNextButtonNotAvailableOnTheLastQuestionOfScoring(), "Previous button found active on the first question");

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US6889"), TestCategory("US6749"), TestCategory("US6727"), TestCategory("US6748")]
        [Priority(2)]
        [WorkItem(19635), WorkItem(19633), WorkItem(19638), WorkItem(19125), WorkItem(19352), WorkItem(19126), WorkItem(18692), WorkItem(18693), WorkItem(19634), WorkItem(18690), WorkItem(18689), WorkItem(19354), WorkItem(19288), WorkItem(19287), WorkItem(19353), WorkItem(19127), WorkItem(19128), WorkItem(18694)]
        [Owner("Mohammed Saquib(mohammed.saquib),Silky Manocha(silky.manocha)")]
        public void CloseIconIsAvailableOnModalDisplay()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();

                //TC19354
                Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerbutton(), "Sample Answer button is present");

                //TC19288
                Assert.IsTrue(AssessmentCommonMethods.VerifyContentBelowRubricHeaderIsScrollable(), "Rubric content is not scrollable");

                //TC19346,//TC19635
                AssessmentCommonMethods.ClickOnTotalScoreButton();
                AssessmentCommonMethods.GiveTotalScoreToStudent("2");
                AssessmentCommonMethods.ClickOnTotalScoreButton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyScoreFlyoutMenu(), "Score Popup is  displayed");

                //TC19287
                Assert.IsTrue(AssessmentCommonMethods.VerifyRubricContentOnStudentScoringScreen(), "Rubric content is not present");

                AssessmentCommonMethods.ClickScoringNextButton();

                //TC19353
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerbutton(), "Sample Answer button is not present");

                //TC19126
                Assert.IsTrue(AssessmentCommonMethods.VerifyCriterionGroupedUnderGroupTitle(), "Criterion Grouped not under Group title");
                //TC19127
                AssessmentCommonMethods.ClickCriterionTitleToggle();
                Assert.IsTrue(AssessmentCommonMethods.VerifyCriterionDesriptionDisplayed(), "Criterion description is not displayed");
                AssessmentCommonMethods.ClickCriterionTitleToggle();
                Assert.IsFalse(AssessmentCommonMethods.VerifyCriterionDesriptionDisplayed(), "Criterion description is not displayed");

                //TC19128
                String classname = AssessmentCommonMethods.GetCriterionDescriptionClassName();
                Assert.AreEqual<string>("TextBlock", classname, "Criterian Description is not TextBlock");


                //TC19125,//TC19352,//TC19638,//TC19633

                AssessmentCommonMethods.ClickCriterionScoreButton("1");
                AssessmentCommonMethods.SelectCriterionButtonScore("1");

                AssessmentCommonMethods.ClickCriterionScoreButton("2");
                AssessmentCommonMethods.SelectCriterionButtonScore("1");

                AssessmentCommonMethods.ClickCriterionScoreButton("3");
                AssessmentCommonMethods.SelectCriterionButtonScore("1");

                AssessmentCommonMethods.ClickCriterionScoreButton("4");
                AssessmentCommonMethods.SelectCriterionButtonScore("1");

                string totalscore = AssessmentCommonMethods.GetTotalScorePopulated();
                Assert.AreEqual<string>("4", totalscore, "Total score is not equal");
                //19634

                AssessmentCommonMethods.ClickNextStudentButton();
                AssessmentCommonMethods.ClickPreviousStudentButton();

                string totalscoreremains = AssessmentCommonMethods.GetTotalScorePopulated();
                Assert.AreEqual<string>("4", totalscoreremains, "Total score is not equal");

                AssessmentCommonMethods.ClickOnShowSampleAnswerButton();
                AssessmentCommonMethods.VerifyCrossButtonOnShowSampleAnswerModal();

                //18690
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerModalDisplayed(), "Sample Answer Modal is not displayed");

                //18689
                Assert.IsTrue(AssessmentCommonMethods.VerifySampleAnswerForQuestionIsDisplayed(), "Sample Answer for Question is not displayed");

                //18692
                AssessmentCommonMethods.ClickOnCrossButtonOnShowSampleAnswerModal();

                Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerPopUp(), "Sample Answer pop up found");

                //18693
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("BelvaAssessmentStudent");
                TaskInfo taskInfo1 = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login1);

                String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login1);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus1[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickScoringNextButton();

                //TC18694
                Assert.IsFalse(AssessmentCommonMethods.VerifySampleAnswerbutton(), "Sample Answer button is present");

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US6728")]
        [Priority(2)]
        [WorkItem(19614)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyScoreAssignToStudentPersist()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();
                
                AssessmentCommonMethods.ClickOnTotalScoreButton();
                AssessmentCommonMethods.GiveTotalScoreToStudent("2");
                AssessmentCommonMethods.ClickNextStudentButton();
                AssessmentCommonMethods.ClickPreviousStudentButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentIsScored(), "Student is not scored");

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
               
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
        [TestCategory("Assessment"), TestCategory("US6910")]
        [Priority(1)]
        [WorkItem(20080)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void LoadingIconOnScoringOverviewPage()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyLoadingIcon(), "Loading Icon Not found");

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

        //[TestMethod()]
        [TestCategory("Assessment"), TestCategory("US6713")]
        [Priority(1)]
        [WorkItem(18583)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyStudentOnTestTunnelAfterClosingApp()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);
                NavigationCommonMethods.Logout();

                Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(studentlogin);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                AssessmentCommonMethods.ClickAssessmentTile();
                AutomationAgent.Wait();
                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTimerInStudentView(), "Timer not found");
                AutomationAgent.CloseApp();

                NavigationCommonMethods.LoginApp(studentlogin);
                Assert.IsTrue(AssessmentCommonMethods.VerifyTimerInStudentView(), "Timer not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyReviewAndSumbitButtonExist(), "Review And Submit button not found");
                AssessmentCommonMethods.ClickReviewAndSubmitButton();


                AssessmentCommonMethods.ClickSubmitButton();
                AssessmentCommonMethods.ClickOnSubmitButtonOnSubmitButtonPopUp();

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
        [TestCategory("Assessment"), TestCategory("US6721")]
        [Priority(1)]
        [WorkItem(18712), WorkItem(18713)]
        [Owner("Mohammed Saquib(mohammed.saquib), Akanksha Gautam(akanksha.gautam)")]
        public void AssessmentManagerScreenFromScoringOverviewScreen()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "Assessment Overview Page not present");
                AssessmentCommonMethods.ClickScoreButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Item summary page not dispalyed");
                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "Assessment Overview Page not present");
                //18713

                AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "Assessment Manager SCreen is displayed");
                //18712
                
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
         [TestCategory("Assessment"), TestCategory("US6776")]
         [Priority(2)]
         [WorkItem(19054), WorkItem(19044), WorkItem(19043), WorkItem(19050), WorkItem(19051)]
         [Owner("Mohammed Saquib(mohammed.saquib), Akanksha Gautam(akanksha.gautam)")]
         public void VerifyStopScoringScreenDisappearsWwhenTeacherClicksOutsideThePopUp()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 Color sampleColor = Color.FromArgb(255, 51, 51, 51);
                 NavigationCommonMethods.LoginApp(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                 string[] no = AssessmentCommonMethods.GetNumberOfStudentsInAssessmentOverview().Split(' ');
                 int scoredNo = AssessmentCommonMethods.GetNumberOfStudentsScoredAssessment();

                 AssessmentCommonMethods.ClickScoreButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyWhiteColorQuestionCard("1"), "White Color Question card is not present");
                 AssessmentCommonMethods.ClickWhiteColorQuestionCard("1");
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(),"Stop scoring screen not found");
                 string count = (Int32.Parse(no[0]) - scoredNo).ToString();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNotScoredNoOfStudentInScoringPopUp(count), "text in stop scoring popup not present");
                 //19044

                 AutomationAgent.Click(1215, 789);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop scoring screen not found");
                 //19054

                 AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();
                 AssessmentCommonMethods.ClickOnTotalScoreButton();
                 AssessmentCommonMethods.SelectCriterionButtonScore("2");
                 int scoringNo = 1;
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyScoredNoOfStudentInScoringPopUp(scoringNo), "");
                 count = (Int32.Parse(count) - scoringNo).ToString();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNotScoredNoOfStudentInScoringPopUp(count), "text in stop scoring popup not present");
                 AssessmentCommonMethods.ClickYesButtonInPopup();
                 //19043

                 Assert.IsFalse(AssessmentCommonMethods.VerifyWhiteColorQuestionCard("1"), "White Color Question card is still present");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionCardIsGreyInColor(sampleColor, "1"), "Color is not grey");
                 //19050

                 AssessmentCommonMethods.ClickGrayColorQuestionCard("1");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyScoringPanel(), "Scoring panel is present");
                 //19051

                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
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
         [TestCategory("Assessment"), TestCategory("US5858")]
         [Priority(1)]
         [WorkItem(12105), WorkItem(12106), WorkItem(12107), WorkItem(12108), WorkItem(12109), WorkItem(12112), WorkItem(15826), WorkItem(15827)]
         [Owner("Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj)")]
         public void VerifyFunctionalityOfTimerInTestTunnel()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);
                 NavigationCommonMethods.Logout();

                 Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTimerInStudentView(), "Timer not found");
                 //12105

                 AssessmentCommonMethods.VerifyTimeElapsedStudentView();
                 //12106, 12107, 12108

                 
                 int TimerWidth = AssessmentCommonMethods.GetTimerWidthExpanded();
                 AssessmentCommonMethods.ClickTimerButtonInStudentView();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTimerCollapsed(TimerWidth), "Timer is not collapsed");
                 AssessmentCommonMethods.ClickTimerButtonInStudentView();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyTimerCollapsed(TimerWidth), "Timer is not expanded");
                 //12109

                 string time1 = AutomationAgent.GetControlText("AssessmentView", "TimerText");
                
                 AutomationAgent.CloseApp();
                 AutomationAgent.Wait();

                 
                 
                 NavigationCommonMethods.LoginApp(studentlogin);

                 string time2 = AutomationAgent.GetControlText("AssessmentView", "TimerText");
                 AssessmentCommonMethods.VerifyTimerInStudentView();

                 Assert.IsFalse(time1.Equals(time2));
                 //12112,15826,15827

                 Assert.IsTrue(AssessmentCommonMethods.VerifyReviewAndSumbitButtonExist(), "Review And Submit button not found");
                 AssessmentCommonMethods.ClickReviewAndSubmitButton();


                 AssessmentCommonMethods.ClickSubmitButton();
                 AssessmentCommonMethods.ClickOnSubmitButtonOnSubmitButtonPopUp();

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

        // [TestMethod()]
         [TestCategory("Assessment"), TestCategory("US5825")]
         [Priority(2)]
         [WorkItem(12120), WorkItem(12122)]
         [Owner("Akanksha Gautam(akanksha.gautam)")]
         public void UserRemovesFlagThenItemChangesToDefaultState()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);
                 NavigationCommonMethods.Logout();

                 Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 string name = AssessmentCommonMethods.GetNameOfTheAssessmentStart(1);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyFlaggedItem(), "Item not flagged");
                 
                 Assert.IsTrue(AssessmentCommonMethods.VerifyRemoveFlagChangesItemState(), "State of item is not changed");
                 //12120

                 AssessmentCommonMethods.ClickOnSummaryButton();
                 AssessmentCommonMethods.ClickOnQuestionTile(1);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyRemoveFlagChangesItemState(), "State of item is not changed");
                 //12122
                 AutomationAgent.CloseApp();

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

         //[TestMethod()]
         [TestCategory("Assessment"), TestCategory("US9491")]
         [Priority(2)]
         [WorkItem(45558), WorkItem(45559), WorkItem(45560)]
         [Owner("Akanksha Gautam(akanksha.gautam)")]
         public void VerifyReviewButtonsColorAndFunctionalityOnTheLastQuestionInExercises()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);
                 NavigationCommonMethods.Logout();

                 Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 string name = AssessmentCommonMethods.GetNameOfTheAssessmentStart(1);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();

                 string total_Question = AssessmentCommonMethods.TotalNoOfQuestionsInAssessment();

                 AssessmentCommonMethods.ClickOnSummaryButton();
                 AssessmentCommonMethods.ClickOnQuestionTile(4);

                 Color sampleColor = Color.FromArgb(255, 255, 255, 255);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyReviewButtonColorWhite(sampleColor), "Review Button Color is not similar to sample color");

                 Color sampleColor1 = Color.FromArgb(255, 0, 0, 0);
                 bool clrbool1 = AssessmentCommonMethods.VerifyReviewTextColorBlack(sampleColor1);
                 //45558


                 AssessmentCommonMethods.ClickOnSummaryButton();
                 AssessmentCommonMethods.ClickOnQuestionTile(1);
                 
                 for (int i = 1; i < Int32.Parse(total_Question);i++)
                 {
                     Assert.IsTrue(AssessmentCommonMethods.VerifyNextButtonInAssessment(), "Next Button is not present");
                     AssessmentCommonMethods.ClickAssessmentNextButton();
                     AutomationAgent.Wait(500);
                 }
                 Assert.IsFalse(AssessmentCommonMethods.VerifyNextButtonInAssessment(), "Next Button is still present");
                 Assert.IsTrue(AssessmentCommonMethods.VerifySubmitButtonInLastQuestionOfAssessment(), "Next Button is still present");
                 //45559

                 AssessmentCommonMethods.ClickReviewAndSubmitButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Assessment Summary Page not present");
                 //45560

                 AutomationAgent.CloseApp();

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
         [TestCategory("Assessment"), TestCategory("US7160")]
         [Priority(2)]
         [WorkItem(20082)]
         [Owner("Akanksha Gautam(akanksha.gautam)")]
         public void StudentNotAbleToSubmitAssessmentInOfflineMode()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 4);
                 NavigationCommonMethods.Logout();

                 Login studentlogin = Login.GetLogin("BelvaAssessmentStudent");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 string name = AssessmentCommonMethods.GetNameOfTheAssessmentStart(1);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();

                 AssessmentCommonMethods.ClickOnSummaryButton();
                 AutomationAgent.DisableNetwork();
                 AutomationAgent.Wait(300);
                 AssessmentCommonMethods.ClickSubmitButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNoInternetSubmitAssessmentMsg(), "No Internet Connection Message Not Present");
                 AssessmentCommonMethods.ClickOKButton();
                 //20082

                 AutomationAgent.CloseApp();

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
         [TestCategory("Assessment"), TestCategory("US9846")]
         [Priority(1)]
         [WorkItem(52308), WorkItem(52307), WorkItem(52321), WorkItem(52324), WorkItem(52323), WorkItem(52336), WorkItem(52317), WorkItem(52318), WorkItem(52327), WorkItem(52328), WorkItem(52320), WorkItem(52333), WorkItem(52126), WorkItem(52103), WorkItem(52107)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void VerifyTeacherAnswersTabPreviewScreenUARubricOngoingAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnUARubric();
                 AssessmentCommonMethods.ClickPreviewAssessmentLink();

                 //TC52320
                 AssessmentCommonMethods.VerifyNoScoreEntryInRubricTabUARubric();


                 //TC52317
                 Assert.IsTrue(AssessmentCommonMethods.VerifyRubricTabHighlightedInBoldForUARubric(), "Rubric tab is not highlighted in bold");

                 //TC52318
                 AssessmentCommonMethods.ClickStandardsTab();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsTabHighlightedInBoldForUARubric(), "Standards tab is not highlighted in bold");
                 
                 //TC52126
                 Assert.IsFalse(AssessmentCommonMethods.VerifyRubricSectionUnderStandardsTab(),"Rubric section is not present under standards tab");

                 //TC52103
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsUnavialbleText(), "Standards Unavilable text is not present");
                 
                 //TC52107
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNoApplicableInformationText(), "No Applicable Information text is not present");

                 //TC52308
                 Assert.IsFalse(AssessmentCommonMethods.VerifyAnswersTabInPreviewScreenUARubric(), "Answers tab is present in Preview Screen of UA Rubric");

                 //TC52307
                 Assert.IsFalse(AssessmentCommonMethods.VerifyQuestionsTabInPreviewScreenUARubric(), "Questions tab is present in Preview Screen of UA Rubric ");

                 //TC52321
                 Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonInPreviewScreenOfUARubric(), "Previous button is present in Preview Screen of UA Rubric");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyNextButtonInPreviewScreenOfUARubric(), "Next button is present in Preview Screen of UA Rubric");

                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickOnUAChecklist();
                 AssessmentCommonMethods.ClickPreviewAssessmentLink();

                 //TC52333
                 AssessmentCommonMethods.VerifyNoScoreEntryInObservationTabUACheckList();

                 //TC52327
                 Assert.IsTrue(AssessmentCommonMethods.VerifyObservationCheckListTabHighlightedInBoldForUAChecklist(), "Rubric tab is not highlighted in bold");

                 //TC52328
                 AssessmentCommonMethods.ClickStandardsTab();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsTabHighlightedInBoldForUAChecklist(), "Standards tab is not highlighted in bold");

                 //TC52324
                 Assert.IsFalse(AssessmentCommonMethods.VerifyAnswersTabInPreviewScreenUAChecklist(), "Answers tab is present in Preview Screen of UA Checklist");

                 //TC52323
                 Assert.IsFalse(AssessmentCommonMethods.VerifyQuestionsTabInPreviewScreenUAChecklist(), "Answers tab is present in Preview Screen of UA Checklist ");

                 //TC52336
                 Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonInPreviewScreenOfUAChecklist(), "Previous button is present in Preview Screen of UA Checklist");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyNextButtonInPreviewScreenOfUAChecklist(), "Next button is present in Preview Screen of UA Checklist");
                 AssessmentCommonMethods.ClickOnCrossIcon();
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
         [TestCategory("Assessment"), TestCategory("US6765")]
         [Priority(1)]
         [WorkItem(19275), WorkItem(19280), WorkItem(19281), WorkItem(19293)]
         [Owner("Mohammed Saquib(mohammed.saquib) , Varun Bhardwaj(varun.bhardwaj)")]
         public void StudentResponseViewScreen()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);

                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();

                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                 int submitted = AssessmentCommonMethods.GetNumberOfStudentsSubmittedAssessment();
                 int scored = AssessmentCommonMethods.GetNumberOfStudentsScoredAssessment();

                 int total = submitted + scored;


                 AssessmentCommonMethods.ClickScoreButton();
                 AssessmentCommonMethods.ClickOnScoreBox("3");

                 Assert.IsTrue(AssessmentCommonMethods.VerifyTotalSubmittedStudentsOnItemScoringScreen(total));
                 //19275

                 Assert.IsTrue(AssessmentCommonMethods.VerifyCorrespondingQuestionNumberLabelOpen("3"), "Corresponding question didnt get open");
                 //19293

                 Assert.IsTrue(AssessmentCommonMethods.VerifyCorrespondingQuestionNumberOpen("3" + "."), "Corresponding question number not get open");
                 //19280

                 Assert.IsTrue(AssessmentCommonMethods.VerifyTwoViewsOnScoringReviewPage(), "Question And StudentResponse not found");
                 //19281





                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
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
         [TestCategory("Assessment"), TestCategory("US9348")]
         [Priority(1)]
         [WorkItem(45530), WorkItem(45534), WorkItem(45533), WorkItem(45535), WorkItem(45537), WorkItem(45531), WorkItem(45532), WorkItem(45536), WorkItem(45539), WorkItem(45538), WorkItem(45540)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void StandardIncludedHeaderUAAccomplishmentChecklist()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnUAChecklist();

                 AssessmentCommonMethods.ClickScoreButton();
                 AssessmentCommonMethods.ClickOnScoreBox();

                 //TC45530
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStandardsInObservationCheckList(), "Standard Header is not present in Observation Checklist");

                 //TC45533
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNotObservedInObservationCheckList(), "Not Observed Header is not present in Observation Checklist");

                 //TC45536
                 Assert.IsTrue(AssessmentCommonMethods.VerifyConsistentInObservationCheckList(), "Consistent Header is not present in Observation Checklist");

                 //TC45539
                 Assert.IsTrue(AssessmentCommonMethods.VerifyRadioButtonInObservationCheckList(), "Consistent Header is not present in Observation Checklist");

                 //TC45538
                 Assert.IsTrue(AssessmentCommonMethods.VerifyDescriptionOfCriterionInObservationCheckList(), "Description of criterion is not present in Observation Checklist");

                 //TC45540
                 Assert.IsTrue(AssessmentCommonMethods.VerifyRadioButtonOfMasteryDarkenedObservation(), "Radio Button In Level of Mastery is not darkened");

                 //TC45534
                 Assert.IsTrue(AssessmentCommonMethods.VerifyBeginningInObservationCheckList(), "Beginning Header is not present in Observation Checklist");

                 //TC45537
                 Assert.IsTrue(AssessmentCommonMethods.VerifyGroupInObservationCheckList(), "Group is not present in Observation Checklist");

                 //TC45531
                 Assert.IsTrue(AssessmentCommonMethods.VerifyBehaviourInObservationCheckList(), "Behaviour Header is not present in Observation Checklist");

                 //TC45532
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLevelsInObservationCheckList(), "Levels are not present in Observation Checklist");

                 //TC45535
                 Assert.IsTrue(AssessmentCommonMethods.VerifyDevelopingInObservationCheckList(), "Developing is not present in Observation Checklist");

                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
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
         [TestCategory("Assessment"), TestCategory("US6627/US6596")]
         [Priority(1)]
         [WorkItem(16200), WorkItem(16251), WorkItem(16281), WorkItem(16207), WorkItem(16285), WorkItem(16284), WorkItem(16286), WorkItem(16287), WorkItem(16208), WorkItem(16254)]
         [Owner("Akanksha Gautam(akanksha.gautam)")]
         public void AAAAAAChangesReflectNumberAndColorOfStudentsProgressingThroughAssessmentCycle()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.TeacherUnlocksAStudent(UnitStatus[4], 2);
                 string s = AssessmentCommonMethods.GetSectionInAssessmentOverview();
                 string num = AssessmentCommonMethods.GetNumberOfStudentsInAssessmentOverview();
                 string[] s1 = num.Split(' ');
                 int i = Int32.Parse(s1[0]);
                 Assert.AreEqual(s, UnitStatus[4]);
                 Assert.AreEqual(num, i + " Students");
                 //16200

                 Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoreButtonActive(), "Release Score Button is active");
                 AssessmentCommonMethods.ClickReleaseScoreButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentProgressOverviewPage(), "Assessment overview page not present");
                 //16251

                 int notStarted = AssessmentCommonMethods.GetNumberOfStudentsNotStartedAssessment();
                 int started = AssessmentCommonMethods.GetNumberOfStudentsStartedAssessment();
                 int submitted = AssessmentCommonMethods.GetNumberOfStudentsSubmittedAssessment();
                 int scored = AssessmentCommonMethods.GetNumberOfStudentsScoredAssessment();

                 NavigationCommonMethods.Logout();

                 Login studentlogin = Login.GetLogin("AssessmentStudentKesler");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 string name = AssessmentCommonMethods.GetNameOfTheAssessmentStart(1);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                 AssessmentCommonMethods.ClickOnSummaryButton();
                 AssessmentCommonMethods.ClickSubmitButton();
                 AssessmentCommonMethods.ClickOnSubmitButtonOnSubmitButtonPopUp();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentAfterStudentSumbitTheAssessment(name), "Name not found");
                 NavigationCommonMethods.Logout();

                 NavigationCommonMethods.LoginApp(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AutomationAgent.Wait();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextBelowReleaseScoresButton(), "Text Below Release Scores Button not present");
                 //16281

                 int notStarted1 = AssessmentCommonMethods.GetNumberOfStudentsNotStartedAssessment();
                 int started1 = AssessmentCommonMethods.GetNumberOfStudentsStartedAssessment();
                 int submitted1 = AssessmentCommonMethods.GetNumberOfStudentsSubmittedAssessment();
                 int scored1 = AssessmentCommonMethods.GetNumberOfStudentsScoredAssessment();

                 Assert.IsTrue(notStarted >= notStarted1, "Statement not true");
                 Assert.IsTrue(started <= started1, "Statement not true");
                 Assert.IsTrue(submitted <= submitted1, "Statement not true");
                 Assert.IsTrue(scored <= scored1, "Statement not true");
                 //16207

                 Color sampleColor = Color.FromArgb(255, 187, 187, 187);

                 Assert.IsTrue(AssessmentCommonMethods.VerifyStartedProgressTabGray(sampleColor));
                 Assert.IsTrue(AssessmentCommonMethods.VerifySubmittedProgressTabGray(sampleColor));
                 Assert.IsTrue(AssessmentCommonMethods.VerifyScoredProgressTabGray(sampleColor));

                 AssessmentCommonMethods.ClickStartedInAssessmentOverviewScreen();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextAlignmentInStartedTab(started1), "Started tab's text Alignment is not the same");
                 //16285

                 Assert.IsFalse(AssessmentCommonMethods.VerifyStartedProgressTabGray(sampleColor));
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNotStartedProgressTabGray(sampleColor));

                 AssessmentCommonMethods.ClickNotStartedInAssessmentOverviewScreen();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextAlignmentInNotStartedTab(notStarted1), "Started tab's text Alignment is not the same");
                 //16284

                 Assert.IsFalse(AssessmentCommonMethods.VerifyNotStartedProgressTabGray(sampleColor));

                 AssessmentCommonMethods.ClickSubmittedInAssessmentOverviewScreen();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextAlignmentInSubmittedTab(submitted1), "Submitted tab's text Alignment is not the same");
                 //16286

                 Assert.IsFalse(AssessmentCommonMethods.VerifySubmittedProgressTabGray(sampleColor));

                 AssessmentCommonMethods.ClickScoredInAssessmentOverviewScreen();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextAlignmentInScoredTab(scored1), "Scored tab's text Alignment is not the same");
                 //16287

                 Assert.IsFalse(AssessmentCommonMethods.VerifyScoredProgressTabGray(sampleColor));
                 //16208

                 Assert.IsTrue(AssessmentCommonMethods.VerifyViewReportButtonActive(), "View Report Button is not Active");
                 //16254

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
         [TestCategory("Assessment"), TestCategory("US6812")]
         [Priority(1)]
         [WorkItem(19893), WorkItem(19295), WorkItem(19294), WorkItem(19880), WorkItem(19883), WorkItem(19894), WorkItem(19897), WorkItem(19898), WorkItem(19902), WorkItem(19903), WorkItem(19904)]
         [Owner("Mohammed Saquib(mohammed.saquib),Silky Manocha(silky.manocha)")]
         public void PreviewAssessmentScreenScenario()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);

                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                 AssessmentCommonMethods.ClickPreviewAssessmentLinkButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Lesson Preview Item Screen is not displayed");
                 //19880

                 //TC19893
                 AssessmentCommonMethods.VerifyQuestionTabIsNoteditable();

                 Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionTabHighlightedInPreviewAssessmentScreen(), "Question Tab is not highlighted");
                 //19883
                 Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonActiveOnTheFirstQuestion(), "Previous button found active on the first question");
                 //19894
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCountIncrementsAfterTappingNextButton(), "Count is not Incrementing");
                 //1990,19294
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCountDecrementsAfterTappingPreviousButton(), "Count is not decrementing");
                 //19903,19901,19295
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNextButtonClickableAndIsPresentInPreviewAssessment(), "Previous button found active on the first question");
                 //19897, 19898, 19902, 19904

                 AssessmentCommonMethods.ClickOnCloseButton();

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
         [TestCategory("Assessment"), TestCategory("US9120"), TestCategory("US9119")]
         [Priority(1)]
         [WorkItem(45413), WorkItem(45412), WorkItem(45404), WorkItem(45403), WorkItem(45408), WorkItem(45407), WorkItem(45410), WorkItem(45409), WorkItem(44776), WorkItem(44777), WorkItem(44774), WorkItem(44773), WorkItem(44772), WorkItem(45400), WorkItem(45414), WorkItem(45401), WorkItem(45416), WorkItem(45415), WorkItem(45417), WorkItem(45402), WorkItem(45405), WorkItem(45406), WorkItem(44775), WorkItem(44769), WorkItem(44768)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void ScoreButtonAvailableOnUnitAccomplishmentOverviewPage()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnUARubric();

                 //TC45400, //TC44775
                 Assert.IsTrue(AssessmentCommonMethods.VerifyScoreButton(), "Score button is not present");

                 //TC44769
                 Assert.IsFalse(AssessmentCommonMethods.VerifyNotStartedTabInUnitAccomplishment(), "Not Started tab is present");

                 //TC44768
                 Assert.IsFalse(AssessmentCommonMethods.VerifyStartedTabInUnitAccomplishment(), "Started tab is present");

                 //TC44772
                 Assert.IsFalse(AssessmentCommonMethods.VerifyUnlockAssessmentLink(), "Lock/Unlock Assessment Link is present");

                 //TC44773
                 Assert.IsFalse(AssessmentCommonMethods.VerifyLockedForTextInUnitAssessment(), "Locked For text is displayed");

                 //TC44774
                 Assert.IsTrue(AssessmentCommonMethods.VerifyPreviewAssessmentLink(), "Preview Assessment is not present");

                 //TC44770
                 int countNotScored = AssessmentCommonMethods.GetCountOfNotScoredInOngoing();
                 if (countNotScored > 0)
                 {
                     Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInNotScoredOngoing(), "Student names are not available");
                 }
                 //TC44771
                 int countScored = AssessmentCommonMethods.GetCountOfScoredInOngoing();
                 if (countScored > 0)
                 {
                     Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInScoredOngoing(), "Student names are not available");
                 }

                 //TC45414 , TC45401
                 AssessmentCommonMethods.ClickScoreButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Scoring Overview Page is not displayed");
                 AssessmentCommonMethods.ClickOnScoreBox();
                 AssessmentCommonMethods.ClickOnCloseButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStopScoringPopupScreen(), "Stop Scoring PopUp is not displayed");

                 //TC45416,TC45415,TC45417
                 AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyDiscussionRubricDisplayed(), "Discussion Rubric Panel is not displayed");
                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyRubricItemScoringPageDisplayed(), "Item scoring page is displayed");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyScoringOverviewPage(), "Scoring overview page is not displayed");

                 //TC45402
                 Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionCardIsDisplayedPerStudent(1), "One Question Card is not available");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyQuestionCardIsDisplayedPerStudent(2), "Two question cards are available");

                 //TC45405,TC45406,//TC45409,//TC45403
                 int countno = AssessmentCommonMethods.GetCountOfScoredDiscussionRubric();
                 if (countno == 0)
                 {
                     Assert.AreEqual<int>(countno, 0, "Student Not Scored doesnt appear under not scored category");
                 }
                 string StudentName = AssessmentCommonMethods.GetStudentNameUnderNotScoredCategory();
                 AssessmentCommonMethods.ClickOnScoreBox("1");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyDiscussionRubricDisplayed(), "Discussion Rubric is not displayed for that student");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyDiscussionRubricIsInCentre(), "Discussion Rubric is not in centre");
                 string DisRubStudentName = AssessmentCommonMethods.GetStudentNameInDiscussionRubric();
                 string[] s = StudentName.Split(' ');
                 for (int i = 0; i < s.Length; i++)
                 {
                     Assert.IsTrue(DisRubStudentName.Contains(s[i]));
                 }
                 AssessmentCommonMethods.ClickNextStudentButton();
                 string DisRubStudentNamenext = AssessmentCommonMethods.GetStudentNameInDiscussionRubric();
                 Assert.AreNotEqual<string>(DisRubStudentName, DisRubStudentNamenext);

                 //TC45410
                 AssessmentCommonMethods.ClickPreviousStudentButton();
                 string DisRubStudentNameprevious = AssessmentCommonMethods.GetStudentNameInDiscussionRubric();
                 Assert.AreEqual<string>(DisRubStudentName, DisRubStudentNameprevious);

                 //TC45408,TC45407
                 AssessmentCommonMethods.ClickCriterionScoreButton("1");
                 AssessmentCommonMethods.SelectCriterionButtonScore("1");

                 AssessmentCommonMethods.ClickCriterionScoreButton("2");
                 AssessmentCommonMethods.SelectCriterionButtonScore("1");

                 AssessmentCommonMethods.ClickCriterionScoreButton("3");
                 AssessmentCommonMethods.SelectCriterionButtonScore("1");

                 string totalscore = AssessmentCommonMethods.GetTotalScorePopulated();
                 Assert.AreEqual<string>("3", totalscore, "");

                 //TC45412
                 string StudentName1 = AssessmentCommonMethods.GetStudentNameInDiscussionRubric();
                 AssessmentCommonMethods.ClickOnStudentDropdownList();

                 //TC45413
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNamesPresentInDropdown(), "Student Names are not present in dropdown");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNotScoredStatusInDropDown(), "Student not scored status is not present in dropdown");

                 AssessmentCommonMethods.ClickOnStudentNameInDropdownList();
                 string StudentName2 = AssessmentCommonMethods.GetStudentNameInDiscussionRubric();
                 Assert.AreNotEqual<string>(StudentName1, StudentName2);

                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.ClickYesButtonInPopup();

                 //TC45404
                 int countno1 = AssessmentCommonMethods.GetCountOfScoredDiscussionRubric();
                 if (countno1 > 0)
                 {
                     Assert.AreEqual<int>(countno1, 1, "Student Scored doesnt appear under scored category");
                 }

                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();

                 //TC44777, //TC44776                 
                 AssessmentCommonMethods.VerifyViewReportButton();
                 AssessmentCommonMethods.ClickViewReportButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentReportPage(), "Assessment Report Page is not present");
                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();

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
         [TestCategory("Assessment"), TestCategory("US6647")]
         [Priority(1)]
         [WorkItem(15850), WorkItem(15851), WorkItem(15852), WorkItem(15854), WorkItem(15855), WorkItem(15853), WorkItem(15856)]
         [Owner("Akanksha Gautam(akanksha.gautam)")]
         public void ATeacherCanOpenAssessmentTaskAfterItsDownloadedToTheDevice()
         {
             try
             {
                 Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(teacherLogin);
                 Login studentlogin = Login.GetLogin("AssessmentStudent");
                 TaskInfo studenttaskInfo = studentlogin.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentButtonPresentInLessonBrowser(taskInfo.Lesson), "Assessment Button Not present");
                 //15850

                 Color sampleColor = Color.FromArgb(255, 169, 169, 169);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentTileGreyed(sampleColor, taskInfo.Lesson), "Assessment tile is not grey");
                 //15851

                 AssessmentCommonMethods.ClickAssessmentTile();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentButtonPresentInLessonBrowser(taskInfo.Lesson), "Assessment Button Not present");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp(), "Lesson Preview Item Screen not present");
                 //15852

                 NavigationCommonMethods.Logout();
                 NavigationCommonMethods.LoginApp(teacherLogin);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);

                 LessonBrowserCommonMethods.ClickLessonFirstTime(taskInfo.Lesson);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Lesson Preview Item Screen not present");
                 //15854

                 AssessmentCommonMethods.ClickOnCloseButton();

                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickOnStudentName(8);
                 AssessmentCommonMethods.ClickOnStudentName(1);
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                 NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                 AssessmentCommonMethods.ClickAssessmentTile();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Lesson Preview Item Screen not present");
                 //15855

                 AssessmentCommonMethods.ClickOnCloseButton();

                 NavigationCommonMethods.Logout();
                 NavigationCommonMethods.LoginApp(studentlogin);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 NavigationCommonMethods.NavigateToELA();
                 NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                 NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);

                 LessonBrowserCommonMethods.ClickLessonFirstTime(taskInfo.Lesson);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp(), "Lesson Preview Item Screen not present");
                 //15853, 15856

                 AssessmentCommonMethods.ClickCancelButtonOnStartAssessmentPopUp();
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
         [TestCategory("Assessment"), TestCategory("US9404")]
         [Priority(1)]
         [WorkItem(51998), WorkItem(52026), WorkItem(52027), WorkItem(52002), WorkItem(52022), WorkItem(52024), WorkItem(52028), WorkItem(52021), WorkItem(52004), WorkItem(52005), WorkItem(52020), WorkItem(52009), WorkItem(52013), WorkItem(52008), WorkItem(52010), WorkItem(52019), WorkItem(52011), WorkItem(52012), WorkItem(52016), WorkItem(52006), WorkItem(52014), WorkItem(52007), WorkItem(52003)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void VerifyNextPreviousOnItemScoringPage()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);

                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnUAChecklist();

                 AssessmentCommonMethods.ClickScoreButton();

                 //TC51998
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCountOfStudentsInNotScoredCategory(), "");

                 //TC52003
                 Color sampleColor1 = Color.FromArgb(255, 255, 255);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNotScoredOrPartiallyScoredCardWhiteColor(sampleColor1, "1"), "NotScored Or PartiallyScored card is not of White Color");

                 AssessmentCommonMethods.ClickOnScoreBox("1");

                 //TC52026
                 AssessmentCommonMethods.ClickOnStudentDropdownList();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNamesPresentInDropdown(), "");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNotScoredStatusInDropDown(), "");


                 //TC52021
                 AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection("2");
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
                 Color sampleColor11 = Color.FromArgb(255, 255, 255);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNotScoredOrPartiallyScoredCardWhiteColor(sampleColor11, "1"), "NotScored Or PartiallyScored card is not of White Color");


                 //TC52004
                 AssessmentCommonMethods.ClickOnScoreBox("1");
                 for (int i = 1; i <= 17; i += 4)
                 {
                     AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection(i.ToString());
                 }
                 for (int i = 1; i <= 5; i += 4)
                 {
                     AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection(i.ToString());
                 }
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyObservationScoreCardActive("2"), "Observation score card 2 is not active");
                 AssessmentCommonMethods.ClickObservationColumnscorecard("2");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCheckListScoringScreen(), "Checklist scoring screen is displayed");

                 //TC52027
                 AssessmentCommonMethods.ClickOnStudentDropdownList();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNamesPresentInDropdown(), "");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNotScoredStatusInDropDown(), "");

                 //TC52005
                 for (int i = 1; i <= 17; i += 4)
                 {
                     AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection(i.ToString());
                 }
                 for (int i = 1; i <= 5; i += 4)
                 {
                     AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection(i.ToString());
                 }

                 //TC52020
                 AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection("2");
                 AssessmentCommonMethods.VerifyRadioButtonforscoringInWritingSectionDeSelected("1");
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyObservationScoreCardActive("3"), "Observation score card 2 is not active");
                 AssessmentCommonMethods.ClickObservationColumnscorecard("3");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCheckListScoringScreen(), "Checklist scoring screen is displayed");

                 //TC52028
                 AssessmentCommonMethods.ClickOnStudentDropdownList();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNamesPresentInDropdown(), "");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNotScoredStatusInDropDown(), "");


                 //TC52010
                 AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection("2");
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();

                 AssessmentCommonMethods.ClickOmitButton();
                 AssessmentCommonMethods.VerifyConfirmPopUpDisplayed();
                 string textconfirm = AssessmentCommonMethods.VerifyConfirmOmitMessageDisplayed();
                 Assert.AreEqual<string>(textconfirm, "This will delete all students data for Observation #3.");
                 AssessmentCommonMethods.ClickCancelbuttonOnOmitPopUp();

                 //TC52022
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCountOfStudentsInNotScoredCategory(), "");

                 //TC52009
                 AssessmentCommonMethods.ClickOnScoreBox("3");
                 for (int i = 1; i <= 17; i += 4)
                 {
                     AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection(i.ToString());
                 }
                 for (int i = 1; i <= 5; i += 4)
                 {
                     AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection(i.ToString());
                 }
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();
                 AssessmentCommonMethods.ClickOmitButton();
                 AssessmentCommonMethods.VerifyConfirmPopUpDisplayed();
                 string textconfirm1 = AssessmentCommonMethods.VerifyConfirmOmitMessageDisplayed();
                 Assert.AreEqual<string>(textconfirm1, "This will delete all students data for Observation #3.");
                 AssessmentCommonMethods.ClickCancelbuttonOnOmitPopUp();

                 //TC52002,//TC52024
                 Assert.IsTrue(AssessmentCommonMethods.VerifyCountOfStudentsInScoredCategory(), "");

                 //TC52006
                 Assert.IsTrue(AssessmentCommonMethods.VerifyOmitButtonPresentInCentreOfTopRow(), "Omit button is not present in the centre of top row");

                 //TC52012
                 AssessmentCommonMethods.ClickOmitButton();
                 AssessmentCommonMethods.ClickCancelbuttonOnOmitPopUp();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyOmitPopUpPresent(), "Omit Pop is present");

                 Color sampleColor2 = Color.FromArgb(156, 155, 155);
                 Assert.IsFalse(AssessmentCommonMethods.VerifyObservationColumn3GrayedOut(sampleColor2, "3"), "Observation column 3 is grayed out");

                 //TC52011,TC52008
                 AssessmentCommonMethods.ClickOmitButton();
                 AssessmentCommonMethods.ClickOkbuttonOnOmitPopUp();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyOmitPopUpPresent(), "Omit Pop is present");
                 AssessmentCommonMethods.ClickOmitButton();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyOmitPopUpPresent(), "Omit Pop is present");

                 Color sampleColor3 = Color.FromArgb(156, 155, 155);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyObservationColumn3GrayedOut(sampleColor3, "3"), "Observation column 3 is not grayed out");

                 AssessmentCommonMethods.ClickObservationColumnscorecard("3");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyCheckListScoringScreen(), "Checklist scoring screen is displayed");

                 //TC52014
                 AssessmentCommonMethods.ClickAddButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyObservationColumnActive("3"), "Observation column 3 is not active");

                 //TC52007,//TC52013
                 AssessmentCommonMethods.ClickOmitButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAddButton(), "Add button is not present");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAddButtonPresentInCentreOfTopRow(), "Add button is not present in the centre of top row");

                 AssessmentCommonMethods.ClickOnScoreBox("1");

                 //TC52019,//TC52016
                 Assert.IsFalse(AssessmentCommonMethods.VerifyStudentResponseTabPresent(), "Student response tab is present");

                 Assert.IsFalse(AssessmentCommonMethods.VerifyPreviousButtonInScoring(), "Previous button is present on scoring page");
                 Assert.IsFalse(AssessmentCommonMethods.VerifyNextButtonInScoring(), "Next button is present on scoring page");

                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickYesButtonInPopup();

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



         [TestMethod()]//done
         [TestCategory("Assessment"), TestCategory("US10024")]
         [Priority(1)]
         [WorkItem(52546), WorkItem(52567), WorkItem(52533), WorkItem(52527), WorkItem(52526), WorkItem(52529), WorkItem(52528), WorkItem(52530), WorkItem(52563), WorkItem(52561), WorkItem(52565)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void VerifyStudentResponseUAChecklistAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("BelvaAssessmentStudent");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickELAAssessmentInDashBoardInStudent();


                 //TC52527
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnUACheckListFromStudent(1);

                 //TC52561
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUAChecklistIsReadOnlyForStudent(), "");

                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.VerifyAssessmentManagerScreen();

                 //TC52526,//TC52567
                 AssessmentCommonMethods.ClickOnUARubricFromStudent(2);

                 Assert.IsTrue(AssessmentCommonMethods.VerifyUARubricIsReadOnlyForStudent(), "");

                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.VerifyAssessmentManagerScreen();

                 //TC52529
                 AssessmentCommonMethods.AssessmentUnitSelection(2);
                 AssessmentCommonMethods.ClickUAProjectForStudent(1);

                 //TC52565
                 AssessmentCommonMethods.VerifyUAProjectIsReadOnlyForStudent();

                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.VerifyAssessmentManagerScreen();

                 //TC52528
                 AssessmentCommonMethods.AssessmentUnitSelection(2);
                 AssessmentCommonMethods.ClickUANotebookForStudent(3);

                 //TC52563
                 AssessmentCommonMethods.VerifyUANotebookIsReadOnlyForStudent();

                 AssessmentCommonMethods.ClickOnCloseButton();
                 AssessmentCommonMethods.VerifyAssessmentManagerScreen();

                 NavigationCommonMethods.Logout();

                 //TC52530,//TC52546
                 Login login1 = Login.GetLogin("BelvaAssessmentStudent");
                 TaskInfo taskInfo1 = login.GetTaskInfo("Math", "Assessment");
                 NavigationCommonMethods.LoginApp(login1);
                 String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfoMath(login1);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickMathAssessmentInDashBoardInStudent();
                 AssessmentCommonMethods.AssessmentUnitSelection(1);
                 AssessmentCommonMethods.ClickOnExerciseAssessmentForStudent(1);
                 AssessmentCommonMethods.ClickQuestionTile("1");
                 AssessmentCommonMethods.ClickSummaryButtonInExercise();

                 //TC52533
                 AssessmentCommonMethods.ClickDoneButton();
                 AssessmentCommonMethods.VerifyAssessmentManagerScreen();

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
         [TestCategory("Assessment"), TestCategory("US6624")]
         [Priority(1)]
         [WorkItem(16354)]
         [Owner("Varun Bhardwaj(varun.bhardwaj)")]
         public void VerifyFunctionalitynLockUnlockPopUpWhenInProgressAssessmentIsSelected()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 int countbefore = AssessmentCommonMethods.GetStatusOfFixedAssessments("In Progress");
                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("In Progress");
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();

                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickLockAllStudentInUnlockAssessment();
                 AutomationAgent.Wait(3000);

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
                 Assert.IsTrue(LockedStudentNo.Equals(LockedStudentNoAfter) || LockedStudentNo < LockedStudentNoAfter, "assessment not unlocked for all trhe student");

                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
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
         [TestCategory("Assessment"), TestCategory("US6624")]
         [Priority(1)]
         [WorkItem(16341)]
         [Owner("Varun Bhardwaj(varun.bhardwaj)")]
         public void VerifyProgressStatusOnLockUnlockOverlay()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("Pending");
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();

                 Assert.IsTrue(AssessmentCommonMethods.VerifyTheStatusOnLockUnlockOverlay("Pending"), "The status didntmatch on the lockunlock overlay");
                 Assert.IsTrue(AssessmentCommonMethods.VerifySectionNameInLockUnlockOverlay(UnitStatus[4]), "assessment overview screen does not contains Section name");
                 AssessmentCommonMethods.ClickLockAllStudentInUnlockAssessment();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockAllText(), "Text not found");
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
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
         [TestCategory("Assessment"), TestCategory("US6624")]
         [Priority(1)]
         [WorkItem(16353)]
         [Owner("Varun Bhardwaj(varun.bhardwaj)")]
         public void VerifyTexOfTheButtonOnLockUnlockPopUpWhenInProgressAssessmentIsSelected()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("In Progress");
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickLockAllStudentInUnlockAssessment();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockAllText(), "Text not found");
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
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
         [TestCategory("Assessment"), TestCategory("US6794")]
         [Priority(1)]
         [WorkItem(16320), WorkItem(16321)]
         [Owner("Varun Bhardwaj(varun.bhardwaj)")]
         public void VerifyFunctionalityOfLockAllButtonOnLockUnlockPopupWhenAssessmentIsInProgress()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("In Progress");



                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');
                 int LockedStudentNo = Int32.Parse(lockedno[0]);

                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickLockAllStudentInUnlockAssessment();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyLockAllText(), "LockAll text not found");
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                 string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatusafter = AssessmentLockStatusafter.Split(' ');
                 string Totalstudentafter = lockstatusafter[2];
                 string[] lockednoafter = lockstatusafter[2].Split('/');
                 int LockedStudentNoAfter = Int32.Parse(lockednoafter[0]);
                 Assert.IsTrue(LockedStudentNo.Equals(LockedStudentNoAfter) || LockedStudentNo < LockedStudentNoAfter, "assessment not unlocked for all trhe student");
                 //16321
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
         [TestCategory("Assessment"), TestCategory("US6794")]
         [Priority(1)]
         [WorkItem(16349), WorkItem(16190)]
         [Owner("Varun Bhardwaj(varun.bhardwaj), Akanksha Gautam(akanksha.gautam)")]
         public void VerifyTextOfLockUnlockPopUpWhenPendingAssessmentSelected()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnitAssessmentsInOrder(), "Assessments are not in Order");
                 //16190

                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("Pending");
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();
                 AssessmentCommonMethods.ClickUnlockAllStudentInUnlockAssessment();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyUnlockAllText(), "Text not found");
                 //16349

                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
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
         [TestCategory("Assessment"), TestCategory("US6624,US6724")]
         [Priority(1)]
         [WorkItem(16348), WorkItem(16319), WorkItem(16339), WorkItem(16342), WorkItem(16352)]
         [Owner("Mohammed Saquib(mohammed.saquib), Varun Bhardwaj(varun.bhardwaj), Akanksha Gautam(akanksha.gautam)")]
         public void VerifyTitleOnLockUnlockPopUp()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);

                 int statusbefore = AssessmentCommonMethods.GetStatusOfFixedAssessments("Pending");
                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("Pending");
                 string AssessmentName = AssessmentCommonMethods.GetAssessmentNameTitle();
                 AssessmentCommonMethods.ClickUnlockAssessmentLink();

                 Color sampleColor = Color.FromArgb(255, 204, 204, 204);
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStartedStudentRowIsGreyed(sampleColor), "Started Student Row is not Grey in Color");
                 //16348

                 String AssessmentNameOnLockOverlayTitle = AssessmentCommonMethods.GetAssessmentNameTitleOnLockOverlay();

                 Assert.AreEqual(AssessmentName, AssessmentNameOnLockOverlayTitle, "Title not found");
                 //16339
                 string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                 string[] lockstatus = AssessmentLockStatus.Split(' ');
                 Assert.IsTrue(lockstatus[0].Equals("Locked"));
                 Assert.IsTrue(lockstatus[1].Equals("for"));
                 string Totalstudent = lockstatus[2];
                 string[] lockedno = lockstatus[2].Split('/');

                 try
                 {
                     int LockedStudentNo = Int32.Parse(lockedno[0]);
                     int LockedStudentNo1 = Int32.Parse(lockedno[1]);
                 }

                 catch (AssertFailedException Ex)
                 {

                     Assert.Fail("Type is not expected as int");
                 }
                 //16342

                 AssessmentCommonMethods.ClickUnlockAllStudentInUnlockAssessment();
                 AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                 int statusafter = AssessmentCommonMethods.GetStatusOfFixedAssessments("Pending");
                 Assert.IsTrue(statusafter.Equals(statusbefore), "The status get changed from pending to In progress");
                 //16352, 16319
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
         [TestCategory("Assessment"), TestCategory("US9960")]
         [Priority(1)]
         [WorkItem(52115), WorkItem(52111), WorkItem(52113), WorkItem(52125)]
         [Owner("Silky Manocha(silky.manocha)")]
         public void VerifyContentsUAOngoingAssessment()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(2);
                 AssessmentCommonMethods.ClickUANotebook();
                 AssessmentCommonMethods.ClickPreviewAssessmentLink();

                 //TC52111
                 AssessmentCommonMethods.VerifyQuestionsTabInPreviewScreenUANotebook();
                 AssessmentCommonMethods.VerifyQuestionTabHighlightedInPreviewAssessmentScreen();

                 //TC52113
                 AssessmentCommonMethods.VerifyContentsPresentUnderQuestionsTab();

                 //TC52115
                 AssessmentCommonMethods.ClickStandardsTab();
                 AssessmentCommonMethods.VerifyStandardsContentPresent();

                 //TC52125
                 AssessmentCommonMethods.VerifyRubricSectionUnderStandardsTab();

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
         [TestCategory("Assessment"), TestCategory("US6758"), TestCategory("US6623")]
         [Priority(1)]
         [WorkItem(18985), WorkItem(18986), WorkItem(18987), WorkItem(18988), WorkItem(18989), WorkItem(16376)]
         [Owner("Varun Bhardwaj(varun.bhardwaj)")]
         public void VerifyRealesaScoreScenarios()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnStatusBasedFixedAssessments("Delivered");

                 AssessmentCommonMethods.ClickReleaseScoreButton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScorePopUp(), "release score pop up not found");
                 //18985

                 Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreNobutton(), "Release Score No Button not available");
                 Assert.IsTrue(AssessmentCommonMethods.VerifyReleaseScoreYesbutton(), "Release Score Yes Button not available");
                 //18986

                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextInReleaseScorePopUp(), "Texts Not found");
                 //18987

                 AssessmentCommonMethods.ClickonReleaseScoreNobutton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "Title not found");
                 //18988

                 AssessmentCommonMethods.ClickReleaseScoreButton();
                 AssessmentCommonMethods.ClickonReleaseScoreYesbutton();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyStaticTextNearReleaseScores(), "Static Text near release scores is not displayed");
                 //18989

                 AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyTextInDeliveredAssessmentRow("Delivered"),"the texts in the delivered assessment row not found");
                 //16376

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
         [TestCategory("Assessment"), TestCategory("US9361"), TestCategory("US6730")]
         [Priority(1)]
         [WorkItem(45511), WorkItem(45510), WorkItem(45509), WorkItem(45512), WorkItem(19344)]
         [Owner("Akanksha Gautam(akanksha.gautam)")]
         public void VerifyAtudentNameDisplayedInScoredCategoryWhenCompleteRubricScored()
         {
             try
             {
                 Login login = Login.GetLogin("AssessmentTeacher");
                 TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                 NavigationCommonMethods.LoginApp(login);
                 String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                 NavigationCommonMethods.NavigateToMyDashboard();
                 AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                 AssessmentCommonMethods.AssessmentUnitSelection(10);
                 AssessmentCommonMethods.ClickOnUARubric();
                 AssessmentCommonMethods.ClickScoreButton();

                 string name = AssessmentCommonMethods.GetFirstStudentNameToScore();

                 AssessmentCommonMethods.ClickWhiteColorQuestionCard("1");

                 AssessmentCommonMethods.ClickOnCrossIcon();
                 AssessmentCommonMethods.ClickNotScoredRubricButtonInStopScoring();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNamePresentInParticularCategory(name), "Name is present in Scored Category");
                 //45511

                 string s = AssessmentCommonMethods.GetTextFromTextBlock(7);
                 AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();

                 AssessmentCommonMethods.ClickCriterionScoreButton("1");
                 AssessmentCommonMethods.SelectCriterionButtonScore("2");
                 AssessmentCommonMethods.ClickOnCrossIcon();
                 Assert.IsFalse(AssessmentCommonMethods.VerifyNamePresentInParticularCategory(name), "Name is present in Scored Category");
                 AssessmentCommonMethods.ClickNotScoredRubricButtonInStopScoring();
                 Assert.IsTrue(AssessmentCommonMethods.VerifyNamePresentInParticularCategory(name), "Name is present in Scored Category");
                 //45510

                 AssessmentCommonMethods.ClickNOButtonInStopScoringPopup();
                 AssessmentCommonMethods.ClickCriterionScoreButton("2");
                 AssessmentCommonMethods.SelectCriterionButtonScore("2");
                 AssessmentCommonMethods.ClickCriterionScoreButton("3");
                 AssessmentCommonMethods.SelectCriterionButtonScore("2");
                 AssessmentCommonMethods.ClickOnCrossIcon();

                 Assert.IsTrue(AssessmentCommonMethods.VerifyNamePresentInParticularCategory(name), "Name is not present in Scored Category");
                 //45509

                 string s1 = AssessmentCommonMethods.GetTextFromTextBlock(7);
                 Assert.AreNotEqual(s, s1, "strings are equal");
                 //45512

                 AssessmentCommonMethods.ClickYesButtonInPopup();
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
        [TestCategory("Assessment"), TestCategory("US9118")]
        [Priority(1)]
        [WorkItem(44639)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyAssessmentUnderOngoingAssessments()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(2);
                Assert.IsTrue(AssessmentCommonMethods.VerifyUANotebook(), "Notebook link not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyUAProject(), "Project link not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyUAChecklist(), "Checklist link not found");


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
        [TestCategory("Assessment"), TestCategory("US6750")]
        [Priority(1)]
        [WorkItem(19074)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyListOfCategories()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickScoreButton();

                Assert.IsTrue(AssessmentCommonMethods.VerifyStatusCategories(), "Status categories are not in line");
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
        [TestCategory("Assessment"), TestCategory("US6770")]
        [Priority(2)]
        [WorkItem(19000), WorkItem(19001)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyStateOfTabSelection()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickStartedInAssessmentOverviewScreen();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStartedProgressTabSelected(), "Started Tab not selected");

                AssessmentCommonMethods.ClickPreviewAssessmentLink();
                AssessmentCommonMethods.ClickOnCrossIcon();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStartedProgressTabSelected(), "Started Tab not selected");
                AssessmentCommonMethods.ClickScoreButton();

                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStartedProgressTabSelected(), "Started Tab not selected");

                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickOnQuestionTabInScoring();
                Assert.IsTrue(AssessmentCommonMethods.VerifyQuestionTabInScoringHighlighted(), "Question tab is not highlighted hence not navigated to question tab screen");

                AssessmentCommonMethods.ClickStudentResponseTab();
                Assert.IsTrue(AssessmentCommonMethods.VerifyStudentResponseTabHighlighted(), "Student response tab is not highlighted hence not navogated to response tab screen");
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();

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
        [TestCategory("Assessment"), TestCategory("US9659")]
        [Priority(2)]
        [WorkItem(53582), WorkItem(53584), WorkItem(53585), WorkItem(53586), WorkItem(53587), WorkItem(53588), WorkItem(53589), WorkItem(53590), WorkItem(53591), WorkItem(53592), WorkItem(53594)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyAddCommentScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(2);
                AssessmentCommonMethods.ClickUANotebook();


                AssessmentCommonMethods.ClickScoreButton();
                AssessmentCommonMethods.ClickOnUANotebookCheckBox("1");
                AssessmentCommonMethods.ClickOnScoreBox();
                AssessmentCommonMethods.ClickOnUaNotebookStudentDropSownButton();
                AssessmentCommonMethods.ClickToSelectStudentUnderAllGroupFlyout();
                AssessmentCommonMethods.ClickOnAddCommentButton();

                Assert.IsTrue(AssessmentCommonMethods.VerifyAddCOmmentOverlay(), "Overlay not  Found");
                //53582

                Assert.IsTrue(AssessmentCommonMethods.VerifyCreateButtonInAddCOmmentOverlay(), "Create button not found");
                //53584

                AutomationAgent.Click(378, 344);
                string text = "Add the comment";
                AssessmentCommonMethods.AddTextToCommentOverlay(text);
                AssessmentCommonMethods.ClickONCreateButtonInAddCOmmentOverlay();
                Assert.IsFalse(AssessmentCommonMethods.VerifyAddCOmmentOverlay(), "Overlay Found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyCommentSuccessfullyAdded(), "Comment Not added");
                AssessmentCommonMethods.ClickOnOkButton();
                //53585

                AssessmentCommonMethods.ClickOnEditCommentButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyEditCOmmentOverlay(), "Overlay not found");
                //53586

                Assert.IsTrue(AssessmentCommonMethods.VerifyDeleteButtonInEditCOmmentOverlay(), "Delete Button not found");
                //53587

                AssessmentCommonMethods.ClickOnDeleteButtonInEditCOmmentOverlay();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAddedCommentDeleted(), "Added comment not get deleted");
                //53588

                AssessmentCommonMethods.ClickOnEditCommentButton();
                AssessmentCommonMethods.ClickOnDoneButtonInEditCOmmentOverlay();
                Assert.IsFalse(AssessmentCommonMethods.VerifyEditCOmmentOverlay(), "Overlay not found");
                //53589

                AssessmentCommonMethods.ClickOnEditCommentButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyDataIsSavedInCommentOverlay(text), "DAta not found");
                AssessmentCommonMethods.ClickOnDoneButtonInEditCOmmentOverlay();
                //53590

                //Score the student


                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();
                AssessmentCommonMethods.ClickRefreshIcon();
                AssessmentCommonMethods.ClickReleaseScoreButton();
                AssessmentCommonMethods.ClickonReleaseScoreYesbutton();

                AutomationAgent.Wait();


                AssessmentCommonMethods.ClicktoOpenScoredStudentInNotebook();



                AssessmentCommonMethods.ClickOnUaNotebookStudentDropSownButton();
                AssessmentCommonMethods.ClickToSelectStudentUnderAllGroupFlyout();

                Assert.IsTrue(AssessmentCommonMethods.VerifyViewCommentButton(), "Button not found");
                //53592


                AssessmentCommonMethods.ClickonViewCommentButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyViewCommentOverlay(), "Overlay not found");
                //53591

                Assert.IsTrue(AssessmentCommonMethods.VerifyDataIsSavedInCommentOverlay(text), "DAta not found");
                //53594




                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();

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
        [TestCategory("Assessment"), TestCategory("US9404")]
        [Priority(1)]
        [WorkItem(52023), WorkItem(52025)]
        [Owner("Silky Manocha(silky.manocha)")]
        public void VerifyNotScoredOnAddButton()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(2);
                AssessmentCommonMethods.ClickOnUACheckListInUnitA();
                AssessmentCommonMethods.ClickScoreButton();

                //TC52025
                AssessmentCommonMethods.ClickOmitButton();

                Color sampleColor2 = Color.FromArgb(156, 155, 155);
                Assert.IsTrue(AssessmentCommonMethods.VerifyObservationColumn3GrayedOut(sampleColor2, "3"), "Observation column 3 is grayed out");

                AssessmentCommonMethods.ClickOnScoreBox("1");
                for (int i = 1; i <= 17; i += 4)
                {
                    AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection(i.ToString());
                }
                for (int i = 1; i <= 5; i += 4)
                {
                    AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection(i.ToString());
                }
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();

                AssessmentCommonMethods.ClickOnScoreBox("2");
                for (int i = 1; i <= 17; i += 4)
                {
                    AssessmentCommonMethods.SelectRadioButtonforscoringInReadingSection(i.ToString());
                }
                for (int i = 1; i <= 5; i += 4)
                {
                    AssessmentCommonMethods.SelectRadioButtonforscoringInWritingSection(i.ToString());
                }
                AssessmentCommonMethods.ClickOnCrossIcon();
                AssessmentCommonMethods.ClickYesButtonInPopup();

                Assert.IsTrue(AssessmentCommonMethods.VerifyCountOfStudentsInScoredCategory(), "Count of Students in Scored Category is not correct");

                //TC52023
                AssessmentCommonMethods.ClickAddButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyCountOfStudentsInNotScoredCategory(), "Count of Students in Not Scored Category is not correct");

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
        [TestCategory("Assessment"), TestCategory("US4217")]
        [Priority(1)]
        [WorkItem(8181)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void StandardNotificationWiFiNeededAppearsWhenTeacherTapsAssessmentsWithWiFiOFF()
        {
            try
            {
                Login login = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.LoginApp(login);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                Assert.IsTrue(AssessmentCommonMethods.VerifyStandardNoWifiPopUp(), "Status categories are not in line");
                //8181

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
        [TestCategory("Assessment"), TestCategory("US6542"), TestCategory("US6626")]
        [Priority(2)]
        [WorkItem(16242), WorkItem(16315), WorkItem(16240)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UnlockedButtonStartedTextDisplayedAsInactive()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                Login studentLogin = Login.GetLogin("AssessmentStudent");

                NavigationCommonMethods.LoginApp(teacherLogin);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                string AssessmentLockStatus = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                string[] lockstatus = AssessmentLockStatus.Split(' ');
                string Totalstudent = lockstatus[2];
                string[] lockedno = lockstatus[2].Split('/');
                int LockedStudentNo = Int32.Parse(lockedno[0]);

                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                AssessmentCommonMethods.ClickOnStudentName(1);
                AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                AssessmentCommonMethods.ClickAssessmentStartButtonInPopUp();
                AutomationAgent.CloseApp();

                NavigationCommonMethods.LoginApp(teacherLogin);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                Color sampleColor = Color.FromArgb(255, 204, 204, 204);
                Assert.IsTrue(AssessmentCommonMethods.VerifyStartedStudentInactiveAndGrey(1, sampleColor), "Started Student is active");
                //16242, 16315

                AssessmentCommonMethods.ClickOnStudentName(1);

                AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();

                string AssessmentLockStatusafter = AssessmentCommonMethods.GetCurrentStatusOfAssessmentLock();
                string[] lockstatus1 = AssessmentLockStatusafter.Split(' ');
                string Totalstudent1 = lockstatus1[2];
                string[] lockedno1 = lockstatus1[2].Split('/');
                int LockedStudentN1 = Int32.Parse(lockedno1[0]);
                Assert.IsTrue((LockedStudentN1 + 1).Equals(LockedStudentNo), "teacher able to lock the studnet who has tsarted the assessment");
                //16240


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
        [TestCategory("Assessment"), TestCategory("US8958"), TestCategory("US8960"), TestCategory("US9794"), TestCategory("US5665"), TestCategory("US8996"),TestCategory("US9946")]
        [Priority(1)]
        [WorkItem(52391), WorkItem(44743), WorkItem(44742), WorkItem(44741), WorkItem(44723), WorkItem(44722), WorkItem(44738), WorkItem(44727), WorkItem(44717), WorkItem(44718), WorkItem(44715), WorkItem(44714), WorkItem(44713), WorkItem(44729), WorkItem(44711), WorkItem(46604), WorkItem(43498), WorkItem(46606), WorkItem(46605), WorkItem(44733), WorkItem(43550), WorkItem(11897), WorkItem(11899), WorkItem(11900), WorkItem(11901), WorkItem(11902), WorkItem(43552)]
        [Owner("Silky Manocha(silky.manocha) , Mohammed Saquib(mohammed.saquib) ")]
        public void VerifyCheckAnswerExercises()
        {
            try
            {
                Login login = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);

                //TC11902
                Assert.IsTrue(AssessmentCommonMethods.VerifyListOfLessonsExist(), "List of Lessons is not present");

                //TC46604,//TC43498
                AssessmentCommonMethods.ClickExercisesTab();
                Assert.IsTrue(AssessmentCommonMethods.VerifyExercisesTabPresent(), "Exercises tab is not present");
                Assert.IsTrue(AssessmentCommonMethods.VerifyLessonstabPresent(), "Lessons tab is not present");

                //TC46606
                AssessmentCommonMethods.VerifyNameOfExercise("1");


                //TC44711,TC11900,//TC44710,//TC44741       
                AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");
                AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView();
                int flagCount = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                AssessmentCommonMethods.ClickQuestionTile("1");
                AssessmentCommonMethods.ClickSummarybutton();
                AssessmentCommonMethods.VerifyTileWithUnanswered("1");
                AssessmentCommonMethods.ClickQuestionTile("1");
                Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer is not active");

                //TC44733,//TC44741
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.VerifyMessageWithoutSelectingOption();
                AssessmentCommonMethods.ClickSummarybutton();
                int flagCount1 = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                int count = AssessmentCommonMethods.GetUnansweredText();
                Assert.IsTrue(flagCount1.Equals(flagCount), "Flag Count is incremented");
                AssessmentCommonMethods.ClickQuestionTile("1");

                //TC44713,//TC44727,//TC44712,46350
                AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                AssessmentCommonMethods.ClickSummarybutton();
                int newcount = AssessmentCommonMethods.GetUnansweredText();
                Assert.IsTrue(count.Equals(newcount + 1), "Unanswered Count didnt decrements!");
                AssessmentCommonMethods.VerifyTileWithUnanswered("1");
                AssessmentCommonMethods.ClickQuestionTile("1");
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.VerifyTextOnCorrectAnswerResponse();

                //TC44721
                Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer button is active");
                Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerbutton(), "Revise button is present");

                //TC44714,//TC44742
                AssessmentCommonMethods.ClickSummarybutton();
                AssessmentCommonMethods.VerifyCorectAnswerTextOnQuestionTile("1");
                int flagCount2 = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                
                Assert.IsTrue(flagCount2.Equals(flagCount - 1), "Flag Count is not decremented");
                
                AssessmentCommonMethods.ClickQuestionTile("3");

                //TC44715,//TC44717,//TC44718,//TC52391
                AssessmentCommonMethods.ClickToSelectWrongAnswer();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.VerifyTextOnInCorrectAnswerResponse();
                AssessmentCommonMethods.VerifyReviseAnswerbutton();
                AssessmentCommonMethods.ClickSummarybutton();
                AssessmentCommonMethods.VerifyInCorectAnswerTextOnQuestionTile("3");
                int flagCount3 = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                Assert.IsTrue(flagCount3.Equals(flagCount - 2), "Flag Count is not decremented");

                //TC44719,//TC44743
                AssessmentCommonMethods.ClickQuestionTile("3");
                AssessmentCommonMethods.ClickReviseAnswerbutton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerbutton(), "Revise button is present");
                AssessmentCommonMethods.VerifyCheckAnswerButton();
                AssessmentCommonMethods.VerifyCheckAnswerIsActive();
                AssessmentCommonMethods.ClickSummarybutton();
                int flagCount4 = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                Assert.IsTrue(flagCount4.Equals(flagCount - 1), "Flag Count is not incremented");
                AssessmentCommonMethods.ClickQuestionTile("3");

                //TC44720,//TC44722
                AssessmentCommonMethods.ClickToSelectWrongAnswer();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer button is active");
                Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerbutton(), "Revise button is present");
                AssessmentCommonMethods.ClickSummarybutton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyIncorrectRevisedTextOnQuestionTile("3"), "InCorrect Revised Text is not present On Question Tile");
                AssessmentCommonMethods.ClickQuestionTile("2");

                //TC44723
                AssessmentCommonMethods.ClickToSelectWrongAnswer();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickSummarybutton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyInCorectAnswerTextOnQuestionTile("2"), "InCorect Answer Text is not present On Question Tile");
                AssessmentCommonMethods.ClickQuestionTile("2");
                AssessmentCommonMethods.ClickReviseAnswerbutton();
                AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickSummarybutton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyCorrectRevisedTextOnQuestionTile("3"), "Correct Revised Text is not present On Question Tile");
                AssessmentCommonMethods.ClickQuestionTile("3");

                //TC44729,//TC44728
                AssessmentCommonMethods.VerifyQuestionNoIncrementsAfterTappingNextButton();

                //TC44731,//TC44730
                AssessmentCommonMethods.VerifyQuestionNoDecrementsAfterTappingPreviousButton();

                //TC43550,//TC44738
                AssessmentCommonMethods.ClickSummarybutton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "");

                //TC44734
                AssessmentCommonMethods.ClickQuestionTile("5");
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.VerifyINeedHelpButton();
                AssessmentCommonMethods.VerifyYesIGotItButton();
                AssessmentCommonMethods.VerifyIUnderstandNowButton();

                //TC44735
                Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer button is active");

                AssessmentCommonMethods.ClickSummarybutton();
                AssessmentCommonMethods.ClickDoneButton();
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("ErikaAssessmentStudent");
                TaskInfo taskInfo1 = login.GetTaskInfo("Math", "Assessment");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo1.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo1.Unit);

                //TC46605
                Assert.IsFalse(AssessmentCommonMethods.VerifyExercisesTabPresent(), "Exercises tab is present");

                //TC11897
                Login login2 = Login.GetLogin("AssessmentTeacher");
                TaskInfo studenttaskInfo = login2.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(login2);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsFalse(AssessmentCommonMethods.VerifyExercisesTabPresent(), "Exercises tab is present");

                NavigationCommonMethods.Logout();

                //TC11899
                Login login3 = Login.GetLogin("AdeleAlamedaTeacher");
                TaskInfo taskInfo2 = login.GetTaskInfo("Math", "Assessment");
                NavigationCommonMethods.LoginApp(login3);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo2.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo2.Unit);

                //TC11901
                Assert.IsTrue(AssessmentCommonMethods.VerifyListOfLessonsExist(), "");
                AssessmentCommonMethods.ClickExercisesTab();
                AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");
                AssessmentCommonMethods.VerifyLessonPreviewItemScreen();
                AssessmentCommonMethods.ClickOnCloseButton();

                NavigationCommonMethods.Logout();

                //TC43552
                Login login4 = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo taskInfo3 = login.GetTaskInfo("Math", "Assessment");
                NavigationCommonMethods.LoginApp(login4);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo3.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo3.Unit);
                AssessmentCommonMethods.ClickExercisesTab();
                AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");
                AssessmentCommonMethods.ClickQuestionTile("1");
                AssessmentCommonMethods.ClickExcerciseSummaryButton();
                AssessmentCommonMethods.ClickDoneButton();

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
        [TestCategory("Assessment"), TestCategory("US9660")]
        [Priority(2)]
        [WorkItem(52261), WorkItem(52262), WorkItem(52260)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void VerifyAssessmentManagerScreenStudentUser()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                Login studentLogin = Login.GetLogin("AssessmentStudentKorff");

                NavigationCommonMethods.LoginApp(teacherLogin);
                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                AssessmentCommonMethods.ClickUnlockAssessmentLink();
                AssessmentCommonMethods.ClickOnStudentName(3);
                AssessmentCommonMethods.ClickDoneButtonUnlockOverlay();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(studentLogin);
                AssessmentCommonMethods.ClickELAAssessmentInDashBoardInStudent();
                string[] unitName = AssessmentCommonMethods.GetTextFromAssessmentUnitTile();
                AssessmentCommonMethods.AssessmentUnitSelection(10);
                string[] unitName1 = AssessmentCommonMethods.GetTextFromAssessmentUnitTile();
                Assert.AreNotEqual(unitName[0], unitName1[0], "Unit name are similar");
                //52261

                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);
                Assert.IsTrue(AssessmentCommonMethods.VerifyStartButtonOnStartAssessmentPopUp(), "Start Button Not present");
                AssessmentCommonMethods.ClickCancelButtonOnStartAssessmentPopUp();
                //52262

                Assert.IsTrue(AssessmentCommonMethods.VerifyListOfAllAssessmentsStatusForStudents(), "Status are not visible");
                //52260

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
        [TestCategory("Assessment"), TestCategory("US9027")]
        [Priority(1)]
        [WorkItem(46302), WorkItem(46303), WorkItem(46347)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyStudentExerciseScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
              

                String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);

               
                AssessmentCommonMethods.ClickMathAssessmentInDashBoardInStudent();
                AssessmentCommonMethods.ClickOnExerciseAssessmentForStudent(1);
                string total_question = "6";
                Assert.IsTrue(AssessmentCommonMethods.VerifyItemsWithNoResponsesOnAssessSummaryScreenOFExercise(total_question),"One of the tile is answered");
                //46302

                AssessmentCommonMethods.ClickQuestionTile("1");
                AssessmentCommonMethods.ClickExcerciseSummaryButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(),"Summary Screen Not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithUnanswered("1"), "Unanswered Not found");
                //46303,46347
               
                
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
  [TestCategory("Assessment"), TestCategory("US6794")]
  [Priority(2)]
  [WorkItem(16177)]
  [Owner("Varun Bhardwaj(varun.bhardwaj)")]
  public void VerifyFixedOngoingAssessments()
  {
      try
      {
          Login login = Login.GetLogin("AssessmentTeacher");
          TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
          NavigationCommonMethods.LoginApp(login);
          String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
          NavigationCommonMethods.NavigateToMyDashboard();
          AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
          AssessmentCommonMethods.OpenUnitSelectionDropDown();
          Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentUnitSelection(10), "Pop Up not found");
          AutomationAgent.Click(100, 100);

          
          AssessmentCommonMethods.AssessmentUnitSelection(10);
          Assert.IsTrue(AssessmentCommonMethods.VerifyOnGoingAssessmentsTab(), "Ongoing Tab not found");
          Assert.IsTrue(AssessmentCommonMethods.VerifyFixedAssessmentTab(), "Fixed Assessment Tab not found");

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
  [TestCategory("Assessment"), TestCategory("US8995")]
  [Priority(1)]
  [WorkItem(44098), WorkItem(44120), WorkItem(44130), WorkItem(44125), WorkItem(44135), WorkItem(44127)]
  [Owner("Varun Bhardwaj(varun.bhardwaj)")]
  public void VerifyExerciseAssessmentOverviewScreen()
  {
      try
      {
          Login login = Login.GetLogin("AdeleAlamedaTeacher");
          TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");

          NavigationCommonMethods.LoginApp(login);
          NavigationCommonMethods.NavigateToMyDashboard();

          //Navigate to math unit
          String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
          AssessmentCommonMethods.ClickAssessmentButtonInMathTeacherDashboard();
          
          AssessmentCommonMethods.ClickNotStartedInAssessmentOverviewScreen();
          Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInNotStarted(), "Student Name not available in started");
          //44098

          AssessmentCommonMethods.ClickStartedInAssessmentOverviewScreen();
          Assert.IsTrue(AssessmentCommonMethods.VerifyStudentNameAvailableInStarted(), "Student Name not available in started");
          //44120

          Assert.IsFalse(AssessmentCommonMethods.VerifyScoreButton(), "Score button found");
          //44130

          Assert.IsFalse(AssessmentCommonMethods.VerifyLockedForTextInUnitAssessment(), "Locked for test is available");
          //44125

          Assert.IsFalse(AssessmentCommonMethods.VerifyReleaseScoreButtonActive(), "release score button not found");
          //44135

          AssessmentCommonMethods.ClickPreviewAssessmentLink();
          Assert.IsTrue(AssessmentCommonMethods.VerifyLessonPreviewItemScreen(), "Item preview screen is not displayed");
          //44127



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
  [TestCategory("Assessment"), TestCategory("US9926")]
  [Priority(1)]
  [WorkItem(52311), WorkItem(52312)]
  [Owner("Varun Bhardwaj(varun.bhardwaj)")]
  public void VerifyOpenEndedQuestionScenarios()
  {
      try
      {
          Login login = Login.GetLogin("AlontaeAssessmentStudent");
          TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");

          NavigationCommonMethods.LoginApp(login);
          NavigationCommonMethods.NavigateToMyDashboard();

          AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
          AssessmentCommonMethods.ClickExercisesTab();
          AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");

          int count = AssessmentCommonMethods.GetQuestionsCountInExcerciseSummary(); 
          Assert.IsTrue(AssessmentCommonMethods.VerifyOpenEndedNOtIncludeInUnansweredCount(count), "open ended count is included in unanswered count");
          //52311

          int num = AssessmentCommonMethods.GetOpenEndedQuestionsNumber();
          AssessmentCommonMethods.ClickQuestionTile(num.ToString());
          Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerButton(), "Check answer button found on the open ended question");
          //52312

          AssessmentCommonMethods.ClickSummaryButtonInExercise();
          for (int i = 1; i <= count;i++ )
          {
              if (!i.Equals(num))
              {
                  AssessmentCommonMethods.ClickQuestionTile(i.ToString());
                  AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                  if (AssessmentCommonMethods.VerifyCheckAnswerButton())
                  {
                      AssessmentCommonMethods.ClickCheckAnswerbutton();
                  }                     
              }
              AssessmentCommonMethods.ClickSummaryButtonInExercise();
          }
          AssessmentCommonMethods.ClickDoneButton();
          Assert.IsTrue(AssessmentCommonMethods.VerifyExcerciseCompleted(1), "Particular Excercise not been completed");
          //52313

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
          [TestCategory("Assessment"), TestCategory("US9660")]
          [Priority(2)]
          [WorkItem(45102), WorkItem(45103), WorkItem(45104), WorkItem(45105), WorkItem(45106)]
          [Owner("Akanksha Gautam(akanksha.gautam)")]
          public void StatusAppearsInUnitSelectionDropdown()
          {
              try
              {
                  Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                  TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");

                  NavigationCommonMethods.LoginApp(teacherLogin);
                  NavigationCommonMethods.NavigateToMyDashboard();
                  String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(teacherLogin);
                  AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);

                  Assert.IsTrue(AssessmentCommonMethods.VerifyAllStatusInUnitSelectionDropDown(10), "Status are not present in the Unit Selection Drop Down");
                  Assert.IsTrue(AssessmentCommonMethods.VerifyListOfAllAssessmentsStatusForTeacher(), "Status are not appropriate");
                  //45102, 45103, 45104, 45105, 45106
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
          [TestCategory("Assessment"), TestCategory("US6728")]
          [Priority(2)]
          [WorkItem(19615)]
          [Owner("Varun Bhardwaj(varun.bhardwaj)")]
          public void VerifyTeacherCannotEditReleaseScore()
          {
              try
              {
                  Login login = Login.GetLogin("AssessmentTeacher");
                  TaskInfo taskInfo = login.GetTaskInfo("ELA", "Assessment");
                  NavigationCommonMethods.LoginApp(login);

                  String[] UnitStatus = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);
                  NavigationCommonMethods.NavigateToMyDashboard();
                  AssessmentCommonMethods.ClickAssessmentInDashBoard(UnitStatus[4]);
                  AssessmentCommonMethods.AssessmentUnitSelection(10);
                  AssessmentCommonMethods.ClickOnUARubric();
                  AssessmentCommonMethods.ClickScoreButton();
                  AssessmentCommonMethods.ClickOnScoreBox();

                  AssessmentCommonMethods.ClickCriterionScoreButton("1");
                  AssessmentCommonMethods.SelectCriterionButtonScore("1");

                  AssessmentCommonMethods.ClickCriterionScoreButton("2");
                  AssessmentCommonMethods.SelectCriterionButtonScore("1");

                  AssessmentCommonMethods.ClickCriterionScoreButton("3");
                  AssessmentCommonMethods.SelectCriterionButtonScore("1");

                  AssessmentCommonMethods.ClickReleaseScoreButtonActiveScoringOverview();
                  AutomationAgent.Wait(5000);
                  AssessmentCommonMethods.ClickRefreshIcon();

                  AssessmentCommonMethods.ClicktoOpenScoredStudentInRubric();
                  AutomationAgent.Wait();
                  AssessmentCommonMethods.ClickCriterionScoreButton("1");
                  Assert.IsFalse(AssessmentCommonMethods.VerifyScoreFlyoutMenuRubric("1"), "Flyout found");



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
          [TestCategory("Assessment"), TestCategory("US8959")]
          [Priority(1)]
          [WorkItem(44611), WorkItem(44612), WorkItem(44614), WorkItem(44615), WorkItem(44616), WorkItem(44617), WorkItem(44618)]
          [Owner("Akanksha Gautam(akanksha.gautam)")]
          public void ExerciseItems()
          {
              try
              {
                  Login studentLogin = Login.GetLogin("AlontaeAssessmentStudent");
                  TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "Assessment");

                  NavigationCommonMethods.LoginApp(studentLogin);
                  AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                  AssessmentCommonMethods.ClickExercisesTab();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("3");
                  int flagCount = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                  AssessmentCommonMethods.ClickQuestionTile("1");
                  AssessmentCommonMethods.ClickOnFlagButtonInExercise();
                  AssessmentCommonMethods.ClickSummaryButtonInExercise();
                  int flagCount1 = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                  Assert.IsTrue(flagCount.Equals(flagCount1 - 1), "Flag Count is not incremented");
                  //44611

                  Assert.IsTrue(AssessmentCommonMethods.VerifyChallengeProblemQuestionTile(), "Challenge Problem Question Tile Not present");
                  //44612

                  Assert.IsTrue(AssessmentCommonMethods.VerifyUnansweredQuestion(), "Unanswered Question Not present");
                  //44615

                  AssessmentCommonMethods.ClickQuestionTile("1");
                  AssessmentCommonMethods.ClickOnFlagButtonInExercise();
                  AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                  AssessmentCommonMethods.ClickCheckAnswerbutton();
                  AssessmentCommonMethods.ClickINeedHelpButton();
                  AssessmentCommonMethods.ClickSummaryButtonInExercise();
                  Assert.IsTrue(AssessmentCommonMethods.VerifyCorrectAnsweredQuestion(), "Correct Question Not present");
                  //44616

                  Assert.IsTrue(AssessmentCommonMethods.VerifyAnsweredQuestion("1"), "Answered Question Is not present");
                  //44614

                  AssessmentCommonMethods.ClickQuestionTile("2");
                  AssessmentCommonMethods.ClickToSelectWrongAnswer();
                  AssessmentCommonMethods.ClickCheckAnswerbutton();
                  AssessmentCommonMethods.ClickReviseAnswerbutton();
                  AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                  AssessmentCommonMethods.ClickCheckAnswerbutton();
                  AssessmentCommonMethods.ClickINeedHelpButton();
                  AssessmentCommonMethods.ClickSummaryButtonInExercise();
                  Assert.IsTrue(AssessmentCommonMethods.VerifyRevisedQuestion(), "Revised Question Not present");
                  //44617

                  Assert.IsTrue(AssessmentCommonMethods.VerifyOpenEndedQuestion(), "Revised Question Not present");
                  //44618

                  AssessmentCommonMethods.ClickDoneButton();
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
          [TestCategory("Assessment"), TestCategory("US9049")]
          [Priority(1)]
          [WorkItem(44554), WorkItem(44557), WorkItem(44555), WorkItem(44556)]
          [Owner("Akanksha Gautam(akanksha.gautam)")]
          public void ExercisesCanBeAccessedUnderExerciseTabInTheLessonBrowser()
          {
              try
              {
                  Login studentLogin = Login.GetLogin("AlontaeAssessmentStudent");
                  Login teacherLogin = Login.GetLogin("AdeleAlamedaTeacher");
                  TaskInfo taskInfo = studentLogin.GetTaskInfo("ELA", "Assessment");

                  NavigationCommonMethods.LoginApp(studentLogin);
                  AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                  AssessmentCommonMethods.ClickExercisesTab();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");
                  Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Student Excercise Not Opened");
                  //44554

                  string excercise = AssessmentCommonMethods.GetStudentsExcerciseTitle();
                  AssessmentCommonMethods.ClickDoneButton();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("3");
                  string newExcercise = AssessmentCommonMethods.GetStudentsExcerciseTitle();
                  Assert.AreNotEqual(excercise, newExcercise, "Excercise titles are similar");
                  //44557

                  AssessmentCommonMethods.ClickDoneButton();
                  NavigationCommonMethods.Logout();

                  NavigationCommonMethods.LoginApp(teacherLogin);
                  NavigationCommonMethods.NavigateMyDashboard();
                  AssessmentCommonMethods.ClickMathStartUnitButtonInTeacherDashboard();
                  AssessmentCommonMethods.ClickExercisesTab();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");
                  Assert.IsTrue(AssessmentCommonMethods.VerifyExcerciseOpened(), "Excercise Not Opened");
                  //44555

                  string title = AssessmentCommonMethods.GetExcerciseTitle();
                  AssessmentCommonMethods.ClickBackButtonInAssessmentOverview();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("3");
                  string newTitle = AssessmentCommonMethods.GetExcerciseTitle();
                  Assert.AreNotEqual(title, newTitle, "Titles are similar");
                  //44556

                  AssessmentCommonMethods.ClickOnCloseButton();
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
          [TestCategory("Assessment"), TestCategory("US9123")]
          [Priority(1)]
          [WorkItem(44520), WorkItem(44521), WorkItem(44517), WorkItem(44525), WorkItem(44522), WorkItem(44524), WorkItem(44526)]
          
          [Owner("Akanksha Gautam(akanksha.gautam)")]
          public void ExerciseOpenEndedQuestions()
          {
              try
              {
                  Login studentLogin = Login.GetLogin("AlontaeAssessmentStudent");
                  TaskInfo taskInfo = studentLogin.GetTaskInfo("Math", "Assessment");

                  NavigationCommonMethods.LoginApp(studentLogin);
                  AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                  AssessmentCommonMethods.ClickExercisesTab();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("3");
                  int flagCount = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                  Assert.IsTrue(AssessmentCommonMethods.VerifyOpenEndedQuestion(), "Open Ended Question Text Not present in the Tile");
                  //44521

                  int question = AssessmentCommonMethods.GetOpenEndedQuestionsNumber();
                  AssessmentCommonMethods.ClickQuestionTile(question.ToString());
                  Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerButton(), "Check Answer Button not present");
                  //44517, 44520

                  AssessmentCommonMethods.ClickOnFlagButtonInExercise();
                  AssessmentCommonMethods.ClickSummaryButtonInExercise();
                  Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentSummaryScreenStudentView(), "Student Excercise Not Opened");
                  //44525

                  int newFlagCount = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                  Assert.AreEqual(newFlagCount, flagCount + 1, "Flag counts are similar");
                  //44522, 44524

                  Assert.IsTrue(AssessmentCommonMethods.VerifyOpenEndedQuestionNoStatus(question), "Some Status shows in Open Ended Question Tile");
                  //44526

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
          [TestCategory("Assessment"), TestCategory("US8994")]
          [Priority(1)]
          [WorkItem(44533), WorkItem(44534), WorkItem(44535)]
          [Owner("Akanksha Gautam(akanksha.gautam)")]
          public void ExercisesStatusDisplayStudentsStartedForStudentsInAssessmentManager()
          {
              try
              {
                  Login studentLogin = Login.GetLogin("AlontaeAssessmentStudent");
                  Login teacherLogin = Login.GetLogin("AdeleAlamedaTeacher");

                  NavigationCommonMethods.LoginApp(teacherLogin);
                  NavigationCommonMethods.NavigateMyDashboard();
                  AssessmentCommonMethods.ClickAssessmentButtonInMathTeacherDashboard();
                  Assert.IsTrue(AssessmentCommonMethods.VerifyExerciseInPendingStatus(), "Exercise not in pending status");
                  //44533

                  NavigationCommonMethods.Logout();
                  NavigationCommonMethods.LoginApp(studentLogin);
                  NavigationCommonMethods.NavigateMyDashboard();
                  AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                  AssessmentCommonMethods.ClickExercisesTab();
                  AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("2");
                  AssessmentCommonMethods.ClickQuestionTile("3");
                  AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                  AssessmentCommonMethods.ClickCheckAnswerbutton();
                  AssessmentCommonMethods.ClickINeedHelpButton();
                  AssessmentCommonMethods.ClickSummaryButtonInExercise();
                  AssessmentCommonMethods.ClickDoneButton();
                  NavigationCommonMethods.Logout();

                  NavigationCommonMethods.LoginApp(teacherLogin);
                  NavigationCommonMethods.NavigateMyDashboard();
                  AssessmentCommonMethods.ClickAssessmentButtonInMathTeacherDashboard();
                  Assert.IsTrue(AssessmentCommonMethods.VerifyExerciseInProgressStatus(), "Exercise not in InProgress status");
                  //44534, 44535

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
        [TestCategory("Assessment"), TestCategory("US9027")]
        [Priority(1)]
        [WorkItem(46304), WorkItem(46305), WorkItem(46307), WorkItem(46309), WorkItem(46312), WorkItem(46313), WorkItem(46316), WorkItem(46317), WorkItem(46318), WorkItem(46346), WorkItem(46322), WorkItem(46327), WorkItem(46329), WorkItem(46330), WorkItem(46331), WorkItem(46332), WorkItem(46333), WorkItem(46336), WorkItem(46337), WorkItem(46339), WorkItem(46341)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyMathAssessmentSummaryTilesScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();


                String[] UnitStatus = AssessmentCommonMethods.LoadMathUnitStatusFromAdditionalInfo(login);


                AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                AssessmentCommonMethods.ClickExercisesTab();
                AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("6");


                AssessmentCommonMethods.ClickQuestionTile("6");
                AutomationAgent.Wait(5000);
                AssessmentCommonMethods.ClickInsideBlankSpace();
                AssessmentCommonMethods.SendText("Tester");
                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                

                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithUnanswered("6"), "Unanswered not found");
                //46304,46336

                AssessmentCommonMethods.ClickQuestionTile("6");
                AutomationAgent.Wait();
                Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer not active");
                //46305


                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickYesIGotItButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTextAFterClickingYesIGotItButton(), "Given Text not found");
                AssessmentCommonMethods.ClickIUnderstandNowButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTextAFterClickingIUnderstandNowButton(), "Given Text not found");
                AssessmentCommonMethods.ClickINeedHelpButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTextAFterClickingINeedHelpButton(), "Given Text not found");
                //46337

                Assert.IsTrue(AssessmentCommonMethods.VerifyContextualText(), "Contextual TextNot found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyINeedHelpButton(), "I need help button not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyYesIGotItButton(), "Yes I Got It button not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyIUnderstandNowButton(), "I Understand Button button not found");
                //46307

                AssessmentCommonMethods.ClickYesIGotItButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTextAFterClickingYesIGotItButton(), "Given Text not found");
                //46309

                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithYesIGotItText("6"), "Tile with yes i got it text not found");
                //46312

                AssessmentCommonMethods.ClickQuestionTile("6");
                Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer active");
                //46313
               string questionumber =  AssessmentCommonMethods.GetCurrentQuestionNoInMathExercise();
                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                string nextquestionumber = AssessmentCommonMethods.GetCurrentQuestionNoInMathExercise();

                Assert.IsTrue(Int32.Parse(questionumber)+1 == Int32.Parse(nextquestionumber), "Question number didnt increment");
                //46339
                AssessmentCommonMethods.ClickAssessmentExercisePreviousButton();
                string previousquestionumber = AssessmentCommonMethods.GetCurrentQuestionNoInMathExercise();
                Assert.IsTrue(Int32.Parse(previousquestionumber)+1 == Int32.Parse(nextquestionumber), "Question number didnt decrement");
                //46341

                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                AssessmentCommonMethods.ClickInsideBlankSpace();
                AssessmentCommonMethods.SendText("AnotherTester");

                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickIUnderstandNowButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTextAFterClickingIUnderstandNowButton(), "Given Text not found");
                //46316
                Assert.IsTrue(AssessmentCommonMethods.VerifyReviseAnswerbutton(),"Revise answer button not found");
                //46317

                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithNowIGetItText("7"), "Tile with Now i got it text not found");
                //46318

                AssessmentCommonMethods.ClickQuestionTile("7");
                AutomationAgent.Wait(5000);
                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                AssessmentCommonMethods.ClickInsideBlankSpace();
                AssessmentCommonMethods.SendText("Tester2");

                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickINeedHelpButton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTextAFterClickingINeedHelpButton(), "Given Text not found");
                AssessmentCommonMethods.VerifyReviseAnswerbutton();
                //46323, 46327
                
                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                int FlagCount = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithINeedHelpText("8"), "Tile with I need help text not found");
                //46324

                AssessmentCommonMethods.ClickQuestionTile("8");
                Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check Answer active");
                //46325



                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickINeedHelpButton();
                AutomationAgent.Wait(3000);
                AssessmentCommonMethods.ClickReviseAnswerbutton();
                Assert.IsTrue(AssessmentCommonMethods.VerifyCheckAnswerIsActive(),"Check answer is not active!");

                Assert.IsFalse(AssessmentCommonMethods.VerifySelfEvaluationButtons(),"self evalution button found");
                //46328


                AssessmentCommonMethods.ClickOnFlagButtonInExercise();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                int newFlagCount = Int32.Parse(AssessmentCommonMethods.GetFlagText());
                Assert.AreEqual(newFlagCount, FlagCount + 1, "Flag counts are similar");
                //46346

                AssessmentCommonMethods.ClickQuestionTile("9");
                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickIUnderstandNowButton();
                AutomationAgent.Wait(5000);

                AssessmentCommonMethods.ClickReviseAnswerbutton();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickIUnderstandNowButton();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();

                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithRevisedAndNowIGetItText("10"), "Tile with Revised text not found");
                //46322

                AssessmentCommonMethods.ClickQuestionTile("10");
                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickINeedHelpButton();
                AutomationAgent.Wait(5000);


                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                AssessmentCommonMethods.VerifyTileWithINeedHelpText("11");
                AssessmentCommonMethods.ClickQuestionTile("11");

                AssessmentCommonMethods.ClickReviseAnswerbutton();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithUnanswered("11"), "Unanswered not found");
                //46330
                AssessmentCommonMethods.ClickQuestionTile("11");
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickINeedHelpButton();
                Assert.IsFalse(AssessmentCommonMethods.VerifyCheckAnswerIsActive(), "Check answer is active!");
                Assert.IsFalse(AssessmentCommonMethods.VerifyReviseAnswerbutton(), "Revise answer button found");
                //46329

                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                AssessmentCommonMethods.VerifyTileWithINeedHelpText("11");
                //46331

                AssessmentCommonMethods.ClickQuestionTile("11");
                AssessmentCommonMethods.ClickonNextButtonInStudentExercise();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickINeedHelpButton();
                AutomationAgent.Wait(5000);


                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                AssessmentCommonMethods.VerifyTileWithINeedHelpText("12");
                AssessmentCommonMethods.ClickQuestionTile("12");

                AssessmentCommonMethods.ClickReviseAnswerbutton();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickIUnderstandNowButton();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();

                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithNowIGetItText("12"), "Tile with Revised text not found");
                //46332

                AssessmentCommonMethods.ClickQuestionTile("5");
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickINeedHelpButton();
                AutomationAgent.Wait(5000);


                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                AssessmentCommonMethods.VerifyTileWithINeedHelpText("5");
                AssessmentCommonMethods.ClickQuestionTile("5");

                AssessmentCommonMethods.ClickReviseAnswerbutton();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickYesIGotItButton();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();

                Assert.IsTrue(AssessmentCommonMethods.VerifyTileWithYesIGotItText("5"), "Tile with Revised text not found");
                //46333
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
        [TestCategory("Assessment"), TestCategory("US9027")]
        [Priority(1)]
        [WorkItem(46351)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyMathAssessmentCheckAnswerScenarios()
        {
            try
            {
                Login login = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();


                String[] UnitStatus = AssessmentCommonMethods.LoadMathUnitStatusFromAdditionalInfo(login);


                AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                AssessmentCommonMethods.ClickExercisesTab();
                AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");
                int count = AssessmentCommonMethods.GetUnansweredText();
                int tilenumber = AssessmentCommonMethods.ClickUnansweredQuestion();
                AutomationAgent.Wait(4000);


                AssessmentCommonMethods.ClickToSelectWrongAnswer();




                AssessmentCommonMethods.ClickCheckAnswerbutton();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();
                int count2 = AssessmentCommonMethods.GetUnansweredText();
                AssessmentCommonMethods.ClickQuestionTile(tilenumber.ToString());
                AssessmentCommonMethods.ClickReviseAnswerbutton();
                AssessmentCommonMethods.ClickSummaryButtonInExercise();

                int newcount = AssessmentCommonMethods.GetUnansweredText();
                Assert.IsTrue((count2 + 1).Equals(newcount));
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
        [TestCategory("Assessment"), TestCategory("US6647")]
        [Priority(2)]
        [WorkItem(15933)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyUnitAssessmentTile()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("AssessmentTeacher");
                TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Assessment");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                AssessmentCommonMethods.VerifyUnitAssessmentTile();
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
        [TestCategory("Assessment"), TestCategory("US9118")]
        [Priority(1)]
        [WorkItem(44640), WorkItem(44641), WorkItem(44642), WorkItem(44643), WorkItem(44644)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyuniTaccomplishmentInProgressStatus()
        {
            try
            {

                Login login = Login.GetLogin("AlontaeAssessmentStudent");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();


                String[] UnitStatus = AssessmentCommonMethods.LoadMathUnitStatusFromAdditionalInfo(login);


                AssessmentCommonMethods.ClickMathStartLessonInStudentDashBoard(4);
                AssessmentCommonMethods.ClickExercisesTab();
                AssessmentCommonMethods.ClickExerciseAssessmentFromUnitLibrary("1");

                AutomationAgent.Wait(4000);


                AssessmentCommonMethods.ClickToSelectCorrectAnswer();
                AssessmentCommonMethods.ClickCheckAnswerbutton();
                NavigationCommonMethods.Logout();

                Login teacherlogin = Login.GetLogin("AdeleAlamedaTeacher");
                TaskInfo taskInfo1 = teacherlogin.GetTaskInfo("Math", "Assessment");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                String[] UnitStatus1 = AssessmentCommonMethods.LoadUnitStatusFromAdditionalInfo(login);

                AssessmentCommonMethods.ClickAssessmentButtonInMathTeacherDashboard();
                Assert.IsTrue(AssessmentCommonMethods.VerifyExerciseInInProgressStatus(), "Exercise not in pending status");

                AssessmentCommonMethods.AssessmentUnitSelection(2);
                Assert.IsTrue(AssessmentCommonMethods.VerifyExerciseInPendingStatus(), "Exercise not in pending status");




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
 
