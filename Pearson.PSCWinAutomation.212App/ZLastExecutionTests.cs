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


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for ZLastExecutionTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class ZLastExecutionTests
    {
        public ZLastExecutionTests()
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
        [TestCategory("ContentManagerTests")]
        [WorkItem(22409)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DownloadingItemsCompletedListofDownloadQueueIsBlank()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickContentManagerButton();

                if (!ContentManagerCommonMethods.VerifyShowDetailsButtonPresent())
                {
                    NavigationCommonMethods.NavigateToELA();
                    LessonBrowserCommonMethods.ClickAddGrades();
                    int gradeNo = LessonBrowserCommonMethods.SelectGrade();
                    LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                    AutomationAgent.Wait(20000);
                    NavigationCommonMethods.ClickContentManagerButton();
                }

                ContentManagerCommonMethods.ClickShowDetails();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
                ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear();
                Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingItemsMessage(), "downloading content no appears");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(22410)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void QueueisUpdatedAndTotalNumberDownloadItemsinDownloadQueueisDecremented()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickContentManagerButton();

                if (!ContentManagerCommonMethods.VerifyShowDetailsButtonPresent())
                {
                    NavigationCommonMethods.NavigateToELA();
                    LessonBrowserCommonMethods.ClickAddGrades();
                    int gradeNo = LessonBrowserCommonMethods.SelectGrade();
                    LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                    AutomationAgent.Wait(20000);
                    NavigationCommonMethods.ClickContentManagerButton();
                }

                ContentManagerCommonMethods.ClickShowDetails();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
                int DownloadingItems = ContentManagerCommonMethods.GetDownloadingItemsNumber();
                AutomationAgent.Wait();
                int DownloadingItemsdecremented = ContentManagerCommonMethods.GetDownloadingItemsNumber();
                if (DownloadingItemsdecremented == DownloadingItems)
                {
                    AutomationAgent.Wait();
                    DownloadingItemsdecremented = ContentManagerCommonMethods.GetDownloadingItemsNumber();
                }

                Assert.IsTrue(DownloadingItemsdecremented <= DownloadingItems, "no. of downloading items not getting decremented");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(21797)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ContentManagerContentUpdateLogShowsUpdatesByDate()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickContentManagerButton();
                AutomationAgent.Wait();
                if (!ContentManagerCommonMethods.VerifyUpdatesAvaialble())
                {
                    NavigationCommonMethods.NavigateToELA();
                    LessonBrowserCommonMethods.ClickAddGrades();
                    LessonBrowserCommonMethods.SelectGrade();
                    LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                    NavigationCommonMethods.ClickContentManagerButton();
                }

                string date = ContentManagerCommonMethods.GetDateFromUpdateGroup(1);
                DateTime date1 = DateTime.Parse(date);
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }

        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(22406)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DownloadItemsAreInQueueDownloadQueueiNotVisible()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                AutomationAgent.Wait();
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(), "Show details no found");
                ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear();
                AutomationAgent.Wait();
                ContentManagerCommonMethods.ClickOnCheckUpdate();
                AutomationAgent.Wait();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewupdateMsg(), "no new updates label not found");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }

        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(22407)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DownloadItemsAreIncrementedIfAdded()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickContentManagerButton();
                int DownloadingItems = ContentManagerCommonMethods.GetDownloadingItemsNumber();
                AutomationAgent.Wait();
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                AutomationAgent.Wait();
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
                int DownloadingItemsIncrement = ContentManagerCommonMethods.GetDownloadingItemsNumber();
                AutomationAgent.Wait();
                Assert.IsTrue(DownloadingItemsIncrement > DownloadingItems, "no. of downloading items not getting increment");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22115)]
        [Priority(3)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TeacherDashboardClassWorkAndClassRosterAppearing()
        {

            try
            {
                Login login = Login.GetLogin("kdelay4236");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade12");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                if (!DashboardCommonMethods.VerifyUserIsOnDashBoard())
                {
                    LessonBrowserCommonMethods.ClickAddGrades();
                    LessonBrowserCommonMethods.SelectSpecificGrade(taskInfo.Grade);
                    LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                    NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                    NavigationCommonMethods.WaitForGradeDownloading();
                    NavigationCommonMethods.NavigateToMath();
                    NavigationCommonMethods.NavigateMyDashboard();
                    DashboardCommonMethods.SwipeLeft();
                }
                Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(secInfo.AdditionalInfo), "Class Work Button not present in the dashboard");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class Roster Button not present");
                NavigationCommonMethods.Logout();
                Login login1 = Login.GetLogin("baugustine1");
                taskInfo = login1.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                if (!DashboardCommonMethods.VerifyUserIsOnDashBoard())
                {
                    LessonBrowserCommonMethods.ClickAddGrades();
                    LessonBrowserCommonMethods.SelectSpecificGrade(taskInfo.Grade);
                    LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                    NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                    NavigationCommonMethods.WaitForGradeDownloading();
                    NavigationCommonMethods.NavigateToMath();
                    NavigationCommonMethods.NavigateMyDashboard();
                    DashboardCommonMethods.SwipeLeft();
                }
                Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(secInfo.AdditionalInfo), "Class Work Button not present in the dashboard");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class Roster Button not present");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22111)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherLinkedLessonRemovedImageLinkingStartUnit()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                string ELAUnitTitle = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(secInfo.AdditionalInfo), "Start unit not found");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
                string ELAUnitTitle1 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                string ELALessonTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateToMyDashboard();
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
                string ELALessonTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle1, "ELA Unit Title are not equal");
                Assert.AreEqual<string>(ELALessonTitle, ELALessonTitle1, "Math Lesson Title are not equal");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginApp(login1);
                taskInfo = login1.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.RemoveGrade(9);
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade(9);
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.WaitForGradeDownloading();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "dashboard not found");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
                string ELAUnitTitle2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle2, "ELA Unit Title are not equal after add and remove grade");
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                NavigationCommonMethods.Logout();

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(20546)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLinkedLessonRemovedImageLinkingStartUnit()
        {
            try
            {

                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                string ELAUnitTitle = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
                string ELAUnitTitle1 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                string ELALessonTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateToMyDashboard();
                DashboardCommonMethods.ClickOnDashBoardContinueLesson(taskInfo.AdditionalInfo);
                string ELALessonTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle1, "ELA Unit Title are not equal");
                Assert.AreEqual<string>(ELALessonTitle, ELALessonTitle1, "Math Lesson Title are not equal");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginApp(login1);
                taskInfo = login1.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.RemoveGrade(9);
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade(9);
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.WaitForGradeDownloading();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "dashboard not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
                TaskInfo secInfo = Login.GetLogin("Sec9Apatton").GetTaskInfo("ELA", "Grade9");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string ELAUnitTitle2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle2, "ELA Unit Title are not equal after add and remove grade");
                NavigationCommonMethods.Logout();

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19384)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void LogOutRightAfterAddingNewGradesNoUnexpectedBehaviorsObserved()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Continue Button Enabled");
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen Is Not Available");
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15897), WorkItem(22156), WorkItem(17701), WorkItem(22155)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenUserEntersUnitLessonsAutomaticallyStartToDownloadInSequence()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsStartToDownload(), "Lesson download not started");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonDownloadinSequence(), "Lesson download not in sequence");
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade(2);
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                AutomationAgent.Wait();
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnitsProgressSinner(), "Preparing Units text not present");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is  Availble");
                NavigationCommonMethods.ClickContentManagerButton();
                ContentManagerCommonMethods.ClickShowDetails();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        [WorkItem(20098)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void QueueDownloadIndicatorIsVisibleForGradesQueued()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeX = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeY = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                NavigationCommonMethods.NavigateToELAGrade(gradeY);
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnitsProgressSinner(), "Preparing Units text not present");
                NavigationCommonMethods.NavigateToELAGrade(gradeX);
                Assert.IsTrue(NavigationCommonMethods.VerifyWaitingToDownloadProgressSinner(), "Waiting To Download text not present");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15974)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void IfUsedAddedMultipleGradesTheNewGradesWillBeginTheCourseLevelPackageDownload()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int SelectedGrade1 = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                LessonBrowserCommonMethods.ClickAddGrades();
                int SelectedGrade2 = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                NavigationCommonMethods.NavigateToELAGrade(SelectedGrade1);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
                NavigationCommonMethods.NavigateToELAGrade(SelectedGrade2);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(16090)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GradesontheribbonareclickableandGethighlighted()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "CheckAndUncheckGrades is not found");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeCancelButtonEnabled(), "AddGradeCancelButton is not Enable");
                int SelectedGrade1 = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                LessonBrowserCommonMethods.ClickAddGrades();
                int SelectedGrade2 = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(SelectedGrade1), "Unit is Not Present");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(SelectedGrade2), "Unit is Not Present");
                NavigationCommonMethods.NavigateToELAGrade(SelectedGrade1);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGradeButtonActive(SelectedGrade1), "Grade Button not Active");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
                NavigationCommonMethods.NavigateToELAGrade(SelectedGrade2);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGradeButtonActive(SelectedGrade2), "Grade Button not Active");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15968)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void XAddGradesDisabledOrNotAppearingWhenAllGradesHaveBeenAdded()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonPresent(), "Add grade button not present");
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectAllGradeInELA();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeButtonPresent(), "Add grade button still present");
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(16087)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void RightafterAddinggradesnewgradeappearonthetopRibbonoftheUnitLibrary()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "CheckAndUncheckGrades is not found");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeCancelButtonEnabled(), "AddGradeCancelButton is not Enable");
                int SelectedLesson = LessonBrowserCommonMethods.SelectGrade();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(SelectedLesson), "Unit is Not Present");
                NavigationCommonMethods.Logout();


            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15972)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AfterSelectingAnyGradeTheUserWillSeeNewGradeOnTopRibbonOfUnitLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeAdded = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(gradeAdded), "Specified grade not present");
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15978)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenCoursePackageDownloadedThenAllUnitThumbnailsAreVisibleOnUnitLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int SelectedGrade = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                CommonReadCommonMethods.Sleep();
                NavigationCommonMethods.NavigateToELAGrade(SelectedGrade);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitThumbnails(), "Unit Thumbnails not present");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(16105)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitLibraryRemoveThisGradeButtonIsDisabledForTheFollowing()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive(), "Remove this grade button is active which should not be");
                LessonBrowserCommonMethods.ClickAddGrades();
                int grade = LessonBrowserCommonMethods.SelectGrade();
                NavigationCommonMethods.NavigateToELAGrade(grade);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Progress Bar not present");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive(), "Remove this grade button is active which should not be");
                NavigationCommonMethods.Logout();

                login = Login.GetLogin("GustadMody");
                taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);

                NavigationCommonMethods.NavigateToELA();
                while (LessonBrowserCommonMethods.VerifyRemoveGradeButtonPresent())
                {
                    if (NavigationCommonMethods.VerifyUnitTileButton(taskInfo.Unit))
                    {
                        NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                        LessonBrowserCommonMethods.ClickOnBackButton();
                        LessonBrowserCommonMethods.ClickOnBackButton();
                        if (LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive())
                        {
                            LessonBrowserCommonMethods.RemoveGrade();
                        }
                    }

                    else if (LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive())
                    {
                        LessonBrowserCommonMethods.RemoveGrade();
                    }
                }
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyRemoveGradeButtonPresent(), "Remove Grade Button still present");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15967)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserAbleToAddAnyGradeByTappingButton()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "CheckAndUncheckGrades is not found");
                int GradeNo = LessonBrowserCommonMethods.SelectGrade();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15873), WorkItem(46749)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyRemoveGradeButton()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeAdded = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(gradeAdded);
                while (!LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive())
                {
                    AutomationAgent.Wait();
                }
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive(), "Remove grade button inactive");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15971)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitLibraryAddGradesButtonEnabledWhenDownloadInProgress()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeAdded = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(gradeAdded);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "Add Grade button inactive");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(1)]
        [WorkItem(22868)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ThreeStatesForCoursePackageDownloadQueued()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int UnitNo = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(UnitNo);
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyActivitySpinnerExists(), "Activity Spinner not found");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(22867)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ThreeStatesForCoursePackageDownloadInProgress()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int GradeNo = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(GradeNo);
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(15975), WorkItem(17697)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenCoursePackageDownloadInProgressThenSpinnerVisible()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonPresent(), "Add grade button not present");
                LessonBrowserCommonMethods.ClickAddGrades();
                int grade = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                LessonBrowserCommonMethods.WaitForGradeToDownload();
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(20143), WorkItem(20099)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenYouAddGradeThenQueuedIndicatorIsShown()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeX = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(gradeX);
                Assert.IsTrue(NavigationCommonMethods.VerifyWaitingToDownloadProgressSinner(), "Waiting To Download  not found");
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeY = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(gradeY);
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(17698)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AddingGradesDoesntTriggerLessonDownload()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeX = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(gradeX);
                Assert.IsTrue(NavigationCommonMethods.VerifyWaitingToDownloadProgressSinner(), "Waiting To Download  not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                NavigationCommonMethods.WaitForGradeDownloading();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(1);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(1);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(1), "Lesson are downloaded");
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(23113)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void verifyViewLessonAlertWhenGradeNotyetDownloaded()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                if (!NavigationCommonMethods.VerifyGradePersent(2))
                {
                    LessonBrowserCommonMethods.ClickAddGrades();
                    LessonBrowserCommonMethods.SelectGrade(2);
                    LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                    NavigationCommonMethods.WaitForGradeDownloading();
                    AutomationAgent.Wait();
                }
                NavigationCommonMethods.NavigateToELAGrade(2);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(1);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(1);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);

                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.RemoveGrade(2);
                AutomationAgent.Wait();

                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(5);
                NotebookCommonMethods.TapOnScreen(519, 63);
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                WorkBrowserCommonMethods.ClickOnViewInLessonButton();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyViewInLessonPresentInUpperRightCorner(), "Message for not downloaded grade is not found");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMessageWhenGradeIsNOtDownloaded(), "Message for not downloaded grade is not found");
                CommonReadCommonMethods.ClickOkButton();
                WorkBrowserCommonMethods.CloseNotebook();
                NavigationCommonMethods.Logout();
            }

            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }
        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(23255)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenLessonDoesntExistOnDeviceThenNotebookStillVisibleDashboard()
        {

            try
            {
                string string1 = "First Page";
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskinfo);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyRecentNoteBookInDashboard(), "Recent Notebook is not found in dashbaord");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.RemoveGrade(taskinfo.Grade);
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyRecentNoteBookInDashboard(), "Recent Notebook is not found in dashbaord");
                NavigationCommonMethods.Logout();

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        #region DisableNetwork

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15904)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YNoWiFiIconVisibleOnThumbnailsPopUpMessage()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                AutomationAgent.DisableNetwork();
                Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                AutomationAgent.EnableNetwork();
                Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
                NavigationCommonMethods.Logout();
            }

            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19368)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YLessonPreviewDownloadNoWiFiconOnlyForNotYetDownloaded()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade + 1);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit + 2);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson + 2);
                AutomationAgent.DisableNetwork();
                Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson + 2), "Previewcard Found");
                AutomationAgent.EnableNetwork();
                AutomationAgent.Wait();
                Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
                NavigationCommonMethods.Logout();

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15894)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YNoWiFIconOnlyForLessonsNotYetDownloaded()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonProgressBar");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
                AutomationAgent.DisableNetwork();
                Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                AutomationAgent.EnableNetwork();
                Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson));
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Lesson Previewcard Is Not  Found");
                Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
                LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson + 3);
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson + 3), "Lesson Previewcard Is Not  Found");
                Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.Logout();
            }

            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15895)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YNoWiFiIconsAreShownOnlyForLessonsNotYetDownloaded()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
                NavigationCommonMethods.ClickSystemTrayButton();
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                NavigationCommonMethods.Logout();
                AutomationAgent.EnableNetwork();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }


        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(26214)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void YAppRememberUserForOfflineUseIfUserLoggedInAtLeastOnce()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System Tray icon not available");
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System Tray icon not available");
                NavigationCommonMethods.Logout();
                AutomationAgent.EnableNetwork();

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17683)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void YWhenWifiOffAndUserInitiallyLogsInThenNetworkUnavailableMessageAppearsRequiresHardReset()
        {

            try
            {
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec6Efoster"));
                Assert.IsTrue(LoginCommonMethods.VerifyNoWifiPopUp(), "No Wifi popup not found");
                LoginCommonMethods.ClickUsernamePasswordOkButton();
                AutomationAgent.EnableNetwork();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }

        [TestMethod()]
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(1)]
        [WorkItem(17684)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YAppRemembersUserForOfflineUseIfUserLoggedInAtLeastOnce()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.Logout();
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                NavigationCommonMethods.Logout();
                AutomationAgent.EnableNetwork();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(26213)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void YWhenWifiOffAndStaffUserInitiallyLogsInThenNetworkUnavailableMessageAppears()
        {

            try
            {
                AutomationAgent.DisableNetwork();
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "LoginScreen Not Found");
                NavigationCommonMethods.LoginApp(Login.GetLogin("awhite"));
                Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Not Prompting");
                LoginCommonMethods.ClickUsernamePasswordOkButton();
                AutomationAgent.EnableNetwork();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(26212)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YWhenWifiOffAndNonSectionedUserInitiallyLogsInThenNetworkUnavailableMessageAppears()
        {

            try
            {
                AutomationAgent.DisableNetwork();
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "LoginScreen Not Found");
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("GustadMody"));
                Assert.IsTrue(LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Not Prompting");
                LoginCommonMethods.ClickUsernamePasswordOkButton();
                AutomationAgent.EnableNetwork();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }



        }

        [TestMethod()]
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(1)]
        [WorkItem(20515)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void YUserGetsNoWifiMessageYouMustBeConnectedToTheInternetToLogIn()
        {

            try
            {
                AutomationAgent.DisableNetwork();
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "LoginScreen Not Found");
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("Student1"));
                Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Not Prompting");
                LoginCommonMethods.ClickUsernamePasswordOkButton();
                AutomationAgent.EnableNetwork();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Student1"));
                Assert.AreEqual<bool>(false, LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Prompting");
                //Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not Found");
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22157)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void YInitialLoginAfterNoWiFiAnotherUserLoggedIn()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Login login = Login.GetLogin("Sec9Apatton");
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                AutomationAgent.DisableNetwork();
                Assert.IsTrue(LoginCommonMethods.VerifyNoWifiPopUp(), "No Wifi pop up not present");
                LoginCommonMethods.ClickUsernamePasswordOkButton();
                AutomationAgent.CloseApp();
                AutomationAgent.LaunchApp();
                login = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Continue button is not present");
                int UnitNo1 = LoginCommonMethods.ClickAndContinueGradeSelected();
                AutomationAgent.EnableNetwork();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(15970)]
        [Owner("Madhav Purohit(madhav.purohit)"), TestCategory("212SmokeTests")]
        public void ZAddGradesButtonDisabledWhenNoWifi()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
                AutomationAgent.DisableNetwork();
                AutomationAgent.Wait();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Active");
                NavigationCommonMethods.Logout();
                AutomationAgent.EnableNetwork();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22608)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void YReceivedNotebooksNotDownloadedNoWiFi()
        {
            try
            {

                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                AutomationAgent.DisableNetwork();
                AutomationAgent.LaunchApp();
                Assert.IsTrue(NotebookCommonMethods.VerifyNoWifiInBrowseOverlay(), "Wifi Icon is not found");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
                AutomationAgent.EnableNetwork();
                NavigationCommonMethods.Logout();
            }

            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(16028)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void YWhenYouTapAnyLinkWhileWiFiOffErrorMessageAppears()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.ClickTeacherSupportButtonInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page Not Found");
                AutomationAgent.DisableNetwork();
                TeacherSupportCommonMethods.ClickOnGrowYourSkills();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAccessMessage(), "No Internet access message not found");
                TeacherSupportCommonMethods.ClickOnMessageCloseButton();
                TeacherSupportCommonMethods.ClickOnPrepareYourLesson();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAccessMessage(), "No Internet access message not found");
                TeacherSupportCommonMethods.ClickOnMessageCloseButton();
                TeacherSupportCommonMethods.ClickOnGetHelp();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAccessMessage(), "No Internet access message not found");
                TeacherSupportCommonMethods.ClickOnMessageCloseButton();
                AutomationAgent.EnableNetwork();
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }



        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15631)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void ZWifiRequiredOnGradeSelection()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButton Is Not Active");
                LessonBrowserCommonMethods.ClickAddGrades();
                AutomationAgent.DisableNetwork();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNoWiFiPopUp(), "Wifi is available");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGrade Continue Button is Enabled");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeCancelButtonEnabled(), "AddGrade Cancel Button is not Enabled");
                LessonBrowserCommonMethods.ClickCancelButton();
                AutomationAgent.EnableNetwork();
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        [WorkItem(15985)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ZUnitLibraryWhenWiFiOffDuringGradeDownloadThenNoWiFiIconVisible()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int UnitNo = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(UnitNo);
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                AutomationAgent.DisableNetwork();
                Assert.IsFalse(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                NavigationCommonMethods.Logout();
                AutomationAgent.EnableNetwork();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
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
        [WorkItem(16095)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ZWhenWifiOffAndBackOnThenDownloadResumes()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                int gradeNo = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickAddGradeContinueButton();
                NavigationCommonMethods.NavigateToELAGrade(gradeNo);
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                AutomationAgent.DisableNetwork();
                AutomationAgent.LaunchApp();
                Assert.IsFalse(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                AutomationAgent.EnableNetwork();
                AutomationAgent.LaunchApp();
                Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
                Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
                NavigationCommonMethods.Logout();

            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                NavigationCommonMethods.Logout();
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }
        #endregion
    }
}
