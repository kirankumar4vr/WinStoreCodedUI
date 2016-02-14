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
    /// Summary description for WorkBrowserTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class WorkBrowserTests
    {
        public WorkBrowserTests()
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

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34181)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TheLessonDropdownStillDisplaysAllLessonsAfterSelectingLesson()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonFilterDropDown(), "All Lessons Filter Drop down not present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonsChecked(), "All Lessons not checked");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34190)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonDropdownShouldPopulateListOfLessons()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonFilterDropDown(), "All Lessons Filter Drop down not present");
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyListOfLessonsInAllLessonsDropDown(), "List Of lessons for selected unit is present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34186)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WorkBrowserShouldBeFilteredWithSectionsSubjectsSortedByMostRecent()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                string subject = taskInfo.SubjectName;
                int grade = taskInfo.Grade;
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                string subjectAndGrade = WorkBrowserCommonMethods.GetSectionDropDownSubjectAndGrade();
                Assert.IsTrue(subjectAndGrade.Contains(subject + grade.ToString()));
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySubjectSortByMostRecent(), "Subject not sorted by Most Recent");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34183)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonDropdownDisabledByDefaultUntilUserSelectsAUnit()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonFilterDropDown(), "All Lessons Filter Drop down not present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoLessonPresentInAllLessonsDropDown(), "List Of lessons for selected unit is present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyListOfLessonsInAllLessonsDropDown(), "List Of lessons for selected unit is present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20519)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void NotebookPreviewHeaderVerifyIfAddingPagesWorksCorrectly()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser page not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                string pageNo = WorkBrowserCommonMethods.GetNotebookPage();
                Assert.AreEqual(pageNo, "( 1 / 1 )", "page no is not (1/1)");
                NotebookCommonMethods.AddNewNotebookPage();
                pageNo = WorkBrowserCommonMethods.GetNotebookPage();
                Assert.AreEqual(pageNo, "( 2 / 2 )", "page no is not (2/2)");
                NotebookCommonMethods.ClickLeftArrowIcon();
                pageNo = WorkBrowserCommonMethods.GetNotebookPage();
                Assert.AreEqual(pageNo, "( 1 / 2 )", "page no is not (1/2)");
                NotebookCommonMethods.AddNewNotebookPage();
                pageNo = WorkBrowserCommonMethods.GetNotebookPage();
                Assert.AreEqual(pageNo, "( 2 / 3 )", "page no is not (2/3)");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34185)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TappingGoToWorkBrowserButtonStudentLandsToWorkBrowserPage()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                DashboardCommonMethods.ClickOnItemInNotification(1);
                DashboardCommonMethods.ClickOnGoToWorkBrowserButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Page not opened");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyTeacherInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyTeacherTabSelected(), "Drop down is not My Teacher");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34184)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UserAbleToSelectOneLessonAtATimeFromDropdown()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonFilterDropDown(), "All Lessons Filter Drop down not present");
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyOnlyOneListSelected(), "More than one lesson can be selected at a time");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34180)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonDropdownShouldPopulateWithListOfLessons()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAllLessonFilterDropDown(), "All Lessons Filter Drop down not present");
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyListOfLessonsInAllLessonsDropDown(), "List Of lessons for selected unit is present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(34179)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UserAbleToSelect1UnitAtATime()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyOnlyOneListSelected(), "More than one lesson can be selected at a time");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22345)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TapGoToWorkBrowserButtonDropdownShouldCloseWorkBrowserShouldOpen()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(DashboardCommonMethods.VerifyNotificationOverlayOpen(), "Notification Overlay not present");
                DashboardCommonMethods.ClickOnItemInNotification(1);
                DashboardCommonMethods.ClickOnGoToWorkBrowserButton();
                Assert.IsFalse(DashboardCommonMethods.VerifyNotificationOverlayOpen(), "Notification Overlay still present");
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Page not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyClassTabSelected(), "My Class Tab not selected");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22458)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SharedWorkDropDownForTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(DashboardCommonMethods.VerifyNotificationOverlayOpen(), "Notification Overlay not present");
                DashboardCommonMethods.ClickOnItemInNotification(1);
                DashboardCommonMethods.ClickOnGoToWorkBrowserButton();
                Assert.IsFalse(DashboardCommonMethods.VerifyNotificationOverlayOpen(), "Notification Overlay still present");
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Page not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyClassTabSelected(), "My Class Tab not selected");
                string[] text = WorkBrowserCommonMethods.GetSectionDropDownSelectedText().Split('|');
                Assert.IsTrue((taskInfo.AdditionalInfo).Contains(text[1].Trim()), "texts are not similar");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22356)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonDropdownDisabledByDefaultUntilUserSelectsUnit()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoLessonPresentInAllLessonsDropDown(), "List Of lessons for selected unit is present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyListOfLessonsInAllLessonsDropDown(), "List Of lessons for selected unit is present");
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20526)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SortedByOtherFieldsWorkBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on dashboard");
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySubjectSortByMostRecent(), "Sort by is not Most recent");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickStudentInSortByFilter();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                WorkBrowserCommonMethods.SelectLessonInAllLessonDropDown(2);
                DateTime date = DateTime.ParseExact(WorkBrowserCommonMethods.GetMyClassNotebooksModifiedDate(1), "MM/dd/yy", null);
                DateTime date1 = DateTime.ParseExact(WorkBrowserCommonMethods.GetMyClassNotebooksModifiedDate(3), "MM/dd/yy", null);
                Assert.IsTrue(date <= date1, "date is not lesser then the next date");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20508)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GlobalNavDismissUsingDoneButton()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser page not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyDoneButtonPlacedInUpparLeftCorner(), "Done Button Is not found At uppar left corner");
                WorkBrowserCommonMethods.CloseNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser page not present");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22328)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void IfSharedWorkHasntBeenDownloadedThereWillBeAnIndicationToDoSo()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = login.PersonName;
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser page not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                if (!WorkBrowserCommonMethods.VerifyNotebookTapToDownloadPresent())
                {
                    NavigationCommonMethods.Logout();
                    Login login1 = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo = login1.GetTaskInfo("ELA", "Grade9");
                    NavigationCommonMethods.LoginApp(login1);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickTextIconInNotebook();
                    CommonReadCommonMethods.Sleep();
                    NotebookCommonMethods.TapOnScreen(1200, 700);
                    NotebookCommonMethods.AddTextInNotebook("ABCD");
                    NotebookCommonMethods.ClickShareButton();
                    NotebookCommonMethods.SelectRecipientByName(taskInfo.AdditionalInfo);
                    CommonReadCommonMethods.ClickNextInSelectRecipients();
                    NotebookCommonMethods.SelectRecipientByName(studentName);
                    CommonReadCommonMethods.ClickNextInSelectRecipients();
                    NotebookCommonMethods.AddMessage("Test Sharing");
                    CommonReadCommonMethods.ClickSendInSelectRecipients();
                    Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                    Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                    NavigationCommonMethods.Logout();
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateWorkBrowser();
                    WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                    WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                    WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                    WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                    Assert.IsTrue(WorkBrowserCommonMethods.VerifyNotebookTapToDownloadPresent(), "Tap To Download Button Not found");
                }
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20514)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookPreviewHeaderVerifyTaskTitleCorrect()
        {
            try
            {
                string string1 = "First Page";
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                string TaskTitle = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                string words = NotebookCommonMethods.GetTextInTextZone();
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                string TaskTitle1 = WorkBrowserCommonMethods.GetLessonTitleOfNotebook();
                string words2 = NotebookCommonMethods.GetTextInTextZone().Replace("\r", "");
                Assert.AreEqual(words, words2, "words and words2 are not equal");
                Assert.AreEqual(TaskTitle, TaskTitle1, "words and words2 are not equal");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20511)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookPreviewHeaderVerifyLessonTitleCorrect()
        {
            try
            {
                string string1 = "First Page";
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                string Lessontitle = WorkBrowserCommonMethods.GetLessonTitleOfNotebook();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                string Lessontitle2 = WorkBrowserCommonMethods.GetLessonTitleOfNotebook();
                Assert.AreEqual(Lessontitle, Lessontitle2, "Lessontitle and Lessontitle2 are not equal");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonTitleAreaIsTop(),"Lesson Title Is not found At top");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20529)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WorkBrowserTabSelectionSortedByDisplaysForTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard Page");
                NavigationCommonMethods.NavigateWorkBrowser();
                string text = WorkBrowserCommonMethods.GetSectionDropDownSelectedText();
                Assert.IsTrue(text.Contains("My Work"), "Text Doesn't contains My Work");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonOption(), "Lesson option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(3);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAlphabeticalOption(), "Alphabetical option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonOption(), "Lesson option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentOption(), "Student option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonOption(), "Lesson option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20524)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WorkBrowserTabSelectionSortedByDisplaysForStudent()
        {
            try
            {
                Login login = Login.GetLogin("StudentAaliyah");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard Page");
                NavigationCommonMethods.NavigateWorkBrowser();
                string text = WorkBrowserCommonMethods.GetSectionDropDownSelectedText();
                Assert.IsTrue(text.Contains("My Work"), "Text Doesn't contains My Work");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(1);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonOption(), "Lesson option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(1);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(4);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyAlphabeticalOption(), "Alphabetical option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(1);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyStudentOption(), "Student option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonOption(), "Lesson option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyTeacherInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(1);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyLessonOption(), "Lesson option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22247), WorkItem(20528), WorkItem(22466)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SentWork()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                TaskInfo nbTaskInfo = teacherLogin.GetTaskInfo("ELA", "Notebook");
                TaskInfo crTaskInfo = teacherLogin.GetTaskInfo("ELA", "CommonRead");
                TaskInfo SecTaskInfo = teacherLogin.GetTaskInfo("ELA", "Grade9");
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = studentLogin.PersonName;

                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacherLogin.GetTaskInfo("ELA", "Notebook"));
                string taskName = DashboardCommonMethods.GetLessonBrowserTaskTitle(nbTaskInfo.Lesson);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(SecTaskInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(studentName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoOfSentNotebooks(taskName), "No Number of notebooks present");
                WorkBrowserCommonMethods.ClickSentInNotbookBottomTile(taskName);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentWorkOverlay(), "Sent Work Overlay not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentWorkDetails(nbTaskInfo.Unit, nbTaskInfo.Lesson, nbTaskInfo.TaskNumber, taskName), "Sent Work Details Are Not Proper");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyRecipientAndDate(studentName), "Recipient and Date are not appropriate");
                WorkBrowserCommonMethods.ClickCloseButtonInSentOrReceivedWorkOverlay();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacherLogin.GetTaskInfo("ELA", "CommonRead"));
                string taskName1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(crTaskInfo.Lesson);
                NavigationCommonMethods.OpenCommonRead(crTaskInfo.TaskNumber);
                CommonReadCommonMethods.GetAnnotationMenu(1008, 404);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadAnnotationMenus(), "Common Read Contextual menus not present");
                CommonReadCommonMethods.ClickOnAnnotationLink();
                CommonReadCommonMethods.SetTextInAnnotationEditor("Test1");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                NotebookCommonMethods.SelectRecipientByName(SecTaskInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(studentName);
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoOfSentCommonReads(1), "No Number of Common Reads present");
                WorkBrowserCommonMethods.ClickCommonReadSentButton(1);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentWorkOverlay(), "Sent Work Overlay not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommonReadSentWorkDetails(crTaskInfo.Unit, crTaskInfo.Lesson, crTaskInfo.TaskNumber, taskName1, studentName), "Recipient and Date are not appropriate");
                WorkBrowserCommonMethods.ClickCloseButtonInSentOrReceivedWorkOverlay();
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

        //[TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22241)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void DefaultView()
        {
            try
            {
                Login login = Login.GetLogin("StudentAaliyah");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                string text = WorkBrowserCommonMethods.GetSectionDropDownSelectedText();
                Assert.IsTrue(text.Contains("My Work"), "Text Doesn't contains My Work");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMostRecentOption(), "Most Recent option not present");
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                if (!WorkBrowserCommonMethods.VerifyWorkDoneOrRecievedPresent())
                    NavigationCommonMethods.Logout();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoSharedWorkText(), "No shared Work Text not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                if (WorkBrowserCommonMethods.VerifyWorkDoneOrRecievedPresent())
                    NavigationCommonMethods.Logout();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoWorkText(), "No shared Work Text not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(3);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();




                if (WorkBrowserCommonMethods.VerifyWorkDoneOrRecievedPresent())
                    NavigationCommonMethods.Logout();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoResultsText(), "No shared Work Text not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(4);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                if (WorkBrowserCommonMethods.VerifyWorkDoneOrRecievedPresent())
                    NavigationCommonMethods.Logout();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoResultsText(), "No shared Work Text not present");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29810)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyHeaderColorsCorrectMathElaSharedPersonalNotebooks()
        {
            try
            {

                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(3);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                NotebookCommonMethods.ClickPersonalNoteTitle();
                Color sampleColor = Color.FromArgb(255, 255, 147, 0);
                AutomationAgent.Wait(500);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourOrange(sampleColor), "Notebook Button is not orange");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22337)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserAbleToSelect1UnitAtATimeFromUnit()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyOnlyOneListSelected(), "More than one Units are selected at a time");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22347)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NavigatingNotificationDropdownWorkBrowserTilesFirstSection()
        {
            try
            {
                string string1 = "First Page";
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.ClickShareButton();
                CommonReadCommonMethods.SelectRecipient(1);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                NavigationCommonMethods.Logout();


                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(DashboardCommonMethods.VerifyNotificationOverlayOpen(), "Notification Overlay not present");
                DashboardCommonMethods.ClickOnItemInNotification(1);
                DashboardCommonMethods.ClickOnGoToWorkBrowserButton();
                Assert.IsFalse(DashboardCommonMethods.VerifyNotificationOverlayOpen(), "Notification Overlay still present");
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Page not present");
                string text = WorkBrowserCommonMethods.GetSectionDropDownSelectedText();
                Assert.IsTrue(text.Contains("Sec-34 Per-5"), "Text Doesn't contains My Class");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(3);
                string text1 = WorkBrowserCommonMethods.GetSectionDropDownSelectedText();
                Assert.IsTrue(text1.Contains("My Class"), "Text Doesn't contains My Class");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22331)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserWorkGroupedByUnitLesson()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                string unit = WorkBrowserCommonMethods.GetUnitNameSelected();
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                WorkBrowserCommonMethods.SelectLessonInAllLessonDropDown(2);
                string lesson = WorkBrowserCommonMethods.GetLessonNameSelected();
                string[] grouping = WorkBrowserCommonMethods.GetTileGroupingUnitAndLesson(1).Split(' ');
                Assert.IsTrue(unit.Contains(grouping[0]), "");
                Assert.IsTrue(lesson.Contains(grouping[3]), "");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22332)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TheCombinationUnitLessonDescendingBasedUnitLessonNumbersDescending()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickLessonInSortByFilter();
                WorkBrowserCommonMethods.ClickAllUnitsFilterDropDown();
                WorkBrowserCommonMethods.SelectFirstUnitInAllUnitsDropDown(2);
                WorkBrowserCommonMethods.ClickAllLessonFilterDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyUnitAndLessonAreInDescendingOrder(),"Unit And Lesson Are not In Descending Order");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22335), WorkItem(22350)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SharedWorkDateIsAlwaysBasedOnSentDate()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = teacherLogin.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacherLogin.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(secInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(studentLogin.PersonName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                DateTime today = DateTime.Today;
                string todayDate = today.ToString("MM/dd/yy");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyTeacherInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                string sentDate = WorkBrowserCommonMethods.GetMyTeacherModifiedDate(1);
                Assert.AreEqual(todayDate, sentDate, "Student is not able to view Shared Work based on sent date");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22130)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SharedNotebooksTurnCommentsOnOff()
        {
            try
            {
                string string1 = "First Page";
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.ClickShareButton();
                CommonReadCommonMethods.SelectRecipient(1);
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Share The Work");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                Login teacherLogin= Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadSharedFirstnotebook();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommentBubbleIconInNotebook(), "Comment Bubble is not found");
                WorkBrowserCommonMethods.ClickCommentBubbleInNotebook();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommentBubbleOpenWithTapping(), "Comment Bubble is not Open");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22129)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void SharedNotebooksCommentBubbleOpenDefault()
        {
            try
            {

                string string1 = "First Page";
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.ClickShareButton();
                CommonReadCommonMethods.SelectRecipient(1);
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Share The Work");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadSharedFirstnotebook();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommentBubbleIconInNotebook(), "Comment Bubble is not found");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommentBubbleOpenWithTapping(), "Comment Bubble is not Open");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22325), WorkItem(22326)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void DisplayReceivedItemsFromEachStudentReversedChronologically()
        {
            try
            {
                Login studentLois = Login.GetLogin("StudentLois");
                TaskInfo nbTaskInfo = studentLois.GetTaskInfo("ELA", "Notebook");
                Login studentBruce = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = studentBruce.PersonName;
                TaskInfo SecTaskInfo = studentBruce.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(studentLois);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLois.GetTaskInfo("ELA", "Notebook"));
                string taskName = DashboardCommonMethods.GetLessonBrowserTaskTitle(nbTaskInfo.Lesson);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("ABCD");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(studentName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(studentBruce);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyFirstNotebookTitle(taskName));
                WorkBrowserCommonMethods.ClickToDownloadSharedFirstnotebook();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen();
                NotebookCommonMethods.SendText("ABCD");
                WorkBrowserCommonMethods.CloseNotebook();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyFirstNotebookTitle(taskName), "First Notebook Title is not present");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22131)]
        [Priority(3)]
        [Owner("Aalmeen (aalmeen.khan)")]
        public void SharedNotebooksVerifyCommentsLayout()
        {
            try
            {
                string string1 = "First Page";
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.ClickShareButton();
                CommonReadCommonMethods.SelectRecipient(1);
                NotebookCommonMethods.ClickNextInSelectPages();
                NotebookCommonMethods.AddMessage("Share The Work");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadSharedFirstnotebook();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommentBubbleIconInNotebook(), "Comment Bubble is not found");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCommentBubbleOpenWithTapping(), "Comment Bubble is not Open");
                WorkBrowserCommonMethods.VerifyFullNameAndDateInCommentBubble(studentLogin.PersonName);
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22011)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TappingDownloadTriggersDownloadProgressBar()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "CommonRead");
                TaskInfo secInfo = teacherLogin.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacherLogin.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                NotebookCommonMethods.SelectRecipientByName(secInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(studentLogin.PersonName);
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                CommonReadCommonMethods.ClickAnnotatedtext(1008, 404);
                CommonReadCommonMethods.ClickDeleteButtonAnnotationWindow();
                CommonReadCommonMethods.DeleteAnnotation();
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyTeacherInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyProgressBarWhenTappingDownload(), "Progress bar not present");
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
        [WorkItem(22243)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ReceivedNotebook()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                TaskInfo nbTaskInfo = teacherLogin.GetTaskInfo("ELA", "Notebook");
                TaskInfo crTaskInfo = teacherLogin.GetTaskInfo("ELA", "CommonRead");
                TaskInfo SecTaskInfo = teacherLogin.GetTaskInfo("ELA", "Grade9");
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = studentLogin.PersonName;

                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacherLogin.GetTaskInfo("ELA", "Notebook"));
                string taskName = DashboardCommonMethods.GetLessonBrowserTaskTitle(nbTaskInfo.Lesson);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(SecTaskInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(studentName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNoOfReceivedNotebooks(taskName), "No Number of notebooks present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedButtonInNotebook(taskName), "Received Notebook button still present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyTeacherInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedButtonInNotebook(taskName), "Received Notebook button still present");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22174)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SeeMoreChangedMoreSentWorkOverlay()
        {
            try
            {
                string string1 = "First Page";
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                string taskName = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(secInfo.AdditionalInfo);
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(2), "Recipient not selected");
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(3), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Share The Work");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");

                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.ClickSentButtonInNotebook(taskName);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMoreInSentOverlay(), "More is not found in sent overlay");
                WorkBrowserCommonMethods.ClickCloseButtonInSentOrReceivedWorkOverlay();
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22003)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void IfSentOrReceivedIconsArePresentTappingOnItOpensSentOrReceivedOverlay()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                TaskInfo nbTaskInfo = teacherLogin.GetTaskInfo("ELA", "Notebook");
                TaskInfo crTaskInfo = teacherLogin.GetTaskInfo("ELA", "CommonRead");
                TaskInfo SecTaskInfo = teacherLogin.GetTaskInfo("ELA", "Grade9");
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = studentLogin.PersonName;

                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(nbTaskInfo);
                string taskName = DashboardCommonMethods.GetLessonBrowserTaskTitle(nbTaskInfo.Lesson);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("ABCD");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(SecTaskInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(studentName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("ELA", "Notebook"));
                string taskName1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(nbTaskInfo.Lesson);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("ABCD");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(teacherLogin.PersonName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");

                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentButtonInNotebook(taskName1), "Sent button not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedButtonInNotebook(taskName), "Received button not present");
                WorkBrowserCommonMethods.ClickSentButtonInNotebook(taskName1);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentWorkOverlay(), "Sent Work Overlay not present");
                WorkBrowserCommonMethods.ClickCloseButtonInSentOrReceivedWorkOverlay();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifySentWorkOverlay(), "Sent Work Overlay still present");
                WorkBrowserCommonMethods.ClickReceivedButtonInNotebook(taskName);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(), "Received Work Overlay not present");
                WorkBrowserCommonMethods.ClickCloseButtonInSentOrReceivedWorkOverlay();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(), "Received Work Overlay still present");
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

        ////[TestMethod()]
        ////[TestCategory("WorkBrowserTests")]
        ////[WorkItem(23113)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void verifyViewLessonAlertWhenGradeNotyetDownloaded()
        ////{
        ////    try
        ////    {

        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.NavigateToELA();
        ////        if (!NavigationCommonMethods.VerifyGradePersent(2))
        ////        {
        ////            LessonBrowserCommonMethods.ClickAddGrades();
        ////            LessonBrowserCommonMethods.SelectGrade(2);
        ////            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////            NavigationCommonMethods.WaitForGradeDownloading();
        ////            AutomationAgent.Wait();
        ////        }
        ////        NavigationCommonMethods.NavigateToELAGrade(2);
        ////        NavigationCommonMethods.StartELAUnitFromUnitLibrary(1);
        ////        NavigationCommonMethods.OpenELALessonFromLessonBrowser(1);
        ////        NotebookCommonMethods.ClickOnNotebookIcon();
        ////        NotebookCommonMethods.ClickEraseIconInNotebook();
        ////        NotebookCommonMethods.ClickClearPage();
        ////        NotebookCommonMethods.ClickTextIconInNotebook();
        ////        CommonReadCommonMethods.Sleep();
        ////        NotebookCommonMethods.TapOnScreen(1200, 700);

        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.RemoveGrade(2);
        ////        AutomationAgent.Wait();

        ////        NavigationCommonMethods.NavigateWorkBrowser();
        ////        WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
        ////        WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(5);
        ////        NotebookCommonMethods.TapOnScreen(519, 63);
        ////        WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
        ////        WorkBrowserCommonMethods.ClickOnViewInLessonButton();
        ////        Assert.IsTrue(WorkBrowserCommonMethods.VerifyViewInLessonPresentInUpperRightCorner(), "Message for not downloaded grade is not found");
        ////        Assert.IsTrue(WorkBrowserCommonMethods.VerifyMessageWhenGradeIsNOtDownloaded(), "Message for not downloaded grade is not found");
        ////        CommonReadCommonMethods.ClickOkButton();
        ////        WorkBrowserCommonMethods.CloseNotebook();
        ////        NavigationCommonMethods.Logout();
        ////    }

        ////    catch (Exception Ex)
        ////    {
        ////        Logger.InsertExceptionMessage(Ex.Message);
        ////        AutomationAgent.CreateScreenshot();
        ////        AutomationAgent.CloseApp();
        ////        throw;
        ////    }
        ////}

        [TestMethod()]
        [TestCategory("WorkBrowserTests")]
        [WorkItem(20771), WorkItem(22246)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ViewingSharedOverlayForReceiveSharedWorkInWorkBrowser()
        {
            try
            {
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = teacherLogin.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateWorkBrowser();
                string taskName = WorkBrowserCommonMethods.GetNotebookTaskName(1);
                int no = WorkBrowserCommonMethods.GetSpecificNotebookReceivedNumber(taskName);
                if (no < 2)
                {
                    NavigationCommonMethods.Logout();
                    NavigationCommonMethods.LoginApp(studentLogin);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("ELA", "Notebook"));
                    for (int j = taskInfo.TaskNumber; j >= 1; j--)
                    {
                        if (DashboardCommonMethods.GetLessonBrowserTaskTitle(j).Equals(taskName))
                            break;
                        else
                            LessonBrowserCommonMethods.GoToPreviousTaskPage();
                    }
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickTextIconInNotebook();
                    NotebookCommonMethods.TapOnScreen(1200, 700);
                    NotebookCommonMethods.SendText("Test");
                    for (int i = 1; i <= 4; i++)
                    {
                        NotebookCommonMethods.ClickShareButton();
                        NotebookCommonMethods.SelectRecipientByName(teacherLogin.PersonName);
                        CommonReadCommonMethods.ClickNextInSelectRecipients();
                        NotebookCommonMethods.AddMessage("Test Sharing");
                        CommonReadCommonMethods.ClickSendInSelectRecipients();
                        Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Work will be sent alert not found");
                        Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Work is sent alert not found");
                    }
                    NavigationCommonMethods.Logout();
                    NavigationCommonMethods.LoginApp(teacherLogin);
                    NavigationCommonMethods.NavigateWorkBrowser();
                }
                WorkBrowserCommonMethods.ClickReceivedButtonInNotebook(taskName);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(), "Received Work Overlay not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNotebookItemsInOrder(), "Notebooks are not in order");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedNotebookDetails(1, taskInfo.Unit, taskInfo.Lesson, taskInfo.AdditionalInfo, studentLogin.PersonName), "Received notebook details are not appropriate");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedNotebooksScrollable(), "Notebooks are not scrollable");
                WorkBrowserCommonMethods.ClickCloseButtonInSentOrReceivedWorkOverlay();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedWorkOverlay(), "Received Work Overlay not present");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29811)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyHeaderColorDarkBlueELANotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Color sampleColor = Color.FromArgb(255, 0, 50, 195);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourBlueForEla(sampleColor), "Notebook Title Color is not Blue");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29820)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyHeaderColorLightBlueForReceivedELANotebook()
        {
            try
            {

                string string1 = "First Page";
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NotebookCommonMethods.ClickShareButton();
                CommonReadCommonMethods.SelectRecipient(1);
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Share The Work");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadNB(1);
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Color LightBlueColour = Color.FromArgb(255, 192, 202, 229);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourBlueForEla(LightBlueColour), "Notebook Title Color is not light Blue");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(29812)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyHeaderColorDarkGreenMathNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Color GreenColour = Color.FromArgb(255, 0, 133, 18);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourGreenForMath(GreenColour), "Notebook Title Color is not green");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(21996)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TileHeaderMyWorkTabDisplaysDarkBlueELAAndDarkGreenMaths()
        {
            try
            {
                string string1 = "First Page";
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                string TaskTitle = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                string TaskTitle1 = WorkBrowserCommonMethods.GetLessonTitleOfNotebook();
                Color sampleColor = Color.FromArgb(255, 0, 50, 195);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourBlueForEla(sampleColor), "Notebook Title Color is not Blue");
                Assert.AreEqual(TaskTitle, TaskTitle1, "Notebook title's are not same");
                WorkBrowserCommonMethods.CloseNotebook();

                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                string MathTaskTitle = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(1);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                string MathTaskTitle1 = WorkBrowserCommonMethods.GetLessonTitleOfNotebook();
                Assert.AreEqual(MathTaskTitle, MathTaskTitle1, "Notebook title's are not same");
                Color GreenColour = Color.FromArgb(255, 0, 133, 18);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourGreenForMath(GreenColour), "Notebook Title Color is not green");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22348)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UserFilteredToMyWorkAllUsersEditedCRAndNBDisplaysInChronologicalOrder()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo nbtaskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo crtaskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                int nbCount = WorkBrowserCommonMethods.GetWorkCountInWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                int crCount = WorkBrowserCommonMethods.GetWorkCountInWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                if(nbCount <2 && crCount<2)
                {
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(nbtaskInfo);
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickTextIconInNotebook();
                    NotebookCommonMethods.TapOnScreen(1200, 700);
                    NotebookCommonMethods.SendText("ABCD");
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NavigationCommonMethods.NavigateToTaskPageInLesson(nbtaskInfo.TaskNumber+1);
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickTextIconInNotebook();
                    NotebookCommonMethods.TapOnScreen(1200, 700);
                    NotebookCommonMethods.SendText("XYZ");
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(crtaskInfo);
                    NavigationCommonMethods.OpenCommonRead(crtaskInfo.TaskNumber);
                    CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                    CommonReadCommonMethods.ClickOnDoneButton();
                    NavigationCommonMethods.NavigateToTaskPageInLesson(crtaskInfo.TaskNumber+1);
                    NavigationCommonMethods.OpenCommonRead(crtaskInfo.TaskNumber);
                    CommonReadCommonMethods.CreateAnnotation(980, 404, "Test");
                    CommonReadCommonMethods.ClickOnDoneButton();
                    NavigationCommonMethods.NavigateWorkBrowser();
                }
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkNotebooksInOrder(), "Notebooks in Work Browser are not in order");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyMyWorkCommonReadssInOrder(), "Common Reads in Work Browser are not in order");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22322)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SectionedStudentFiltersMyClassDisplaystudentInSortLabelBelowSortedBy()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickStudentInSortByFilter();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySubjectSortByStudent(), "Sort By filter is not student");
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
        [TestCategory("WorkBrowserTests")]
        [WorkItem(22330), WorkItem(22324)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SortByStudentShouldBeOrganizedAlphabeticallyFromAToZ()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(2);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenSortByDropDown();
                WorkBrowserCommonMethods.ClickStudentInSortByFilter();
                Assert.IsTrue( WorkBrowserCommonMethods.VerifyStudentOrganizedAlphabetically(),"Student Is not Organized");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySubjectSortByStudent(), "Sort By filter is not student");
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
    }
}
