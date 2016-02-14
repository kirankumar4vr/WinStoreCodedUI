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
    /// Summary description for DashboardTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class DashboardTests
    {
        public DashboardTests()
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
        [TestCategory("DashboardTests")]
        [WorkItem(21851)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyOptionsAvailableOnTheThumnailPresentOnDashboardForSectionedTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dahboard Not found");
                DashboardCommonMethods.SwipeLeft();
                DashboardCommonMethods.SwipeLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(taskInfo.AdditionalInfo), "Class roster not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(taskInfo.AdditionalInfo), "Class Work Nor found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "Camera icon not found");
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
        [WorkItem(23153)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyThatResourceLibraryFlyOutMenuOpensInDashboard()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                DashboardCommonMethods.ClickOnResourceLibraryIcon();
                Assert.IsTrue(DashboardCommonMethods.VerifyResourceLibraryFlyOutMenu(), "Resource flyout not found");
                NavigationCommonMethods.ClickSystemTrayButton();
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
        [WorkItem(15918)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedStudentWillSeeHisAssociatedGradeOnTheDashboardOnInitialLogin()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsFalse(NavigationCommonMethods.IsNonSectionedUser(Login.GetLogin("StudentBruceSec9Apatton")), "Grade is not available for the logged in user");
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
        [WorkItem(33501)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void OnlyNotebookThumbnailsAppearNotPersonalNotebooks()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                string title = "MyPersonalNoteTitle";
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickNotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(), "Personal Note is not found");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsFalse(NotebookCommonMethods.VerifyPersonalNoteFound(), "Personal Note is found");
                Assert.IsTrue(DashboardCommonMethods.VerifyPersonalNotebookNotPresent(title), "PersonalNotebook is available in Dashboard");
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
        [WorkItem(23252)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardMyRecentWorkNotebooksVisibleMax5AtBottomOfDashboard()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                taskInfo.TaskNumber = 1;
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Not on DashBoard");
                int noOfNotebooks = DashboardCommonMethods.GetCountOfNotebooksInDashboard();

                if (noOfNotebooks < 6)
                {
                    //Add Notebooks
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    for (int i = noOfNotebooks; i < 9; i++)
                    {
                        NotebookCommonMethods.ClickTextIconInNotebook();
                        AutomationAgent.Wait(500);
                        NotebookCommonMethods.TapOnScreen(1200, 700);
                        NotebookCommonMethods.AddTextInNotebook("ABCD");
                        AutomationAgent.Wait(500);
                        NotebookCommonMethods.TapOnScreen(1200, 400);
                        AutomationAgent.Wait(500);
                        NavigationCommonMethods.ClickNextPageIcon();
                        AutomationAgent.Wait(500);
                        NavigationCommonMethods.NavigateMyDashboard();
                    }
                }
                Assert.IsTrue(DashboardCommonMethods.VerifyNotebooksAtBottomOfDashboard(), "No NoteBooks at bottom");
                Assert.IsTrue((noOfNotebooks >= 5), "Notebook count is not 5");
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
        [WorkItem(23253)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardMyRecentWorkNotebooksAppearInSequentialOrderSortedByDate()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on Dashboard");
                Assert.IsTrue(DashboardCommonMethods.VerifyNotebooksAtBottomOfDashboard(), "Can't verify dasnboard notebooks");
                int count = 0;//DashboardCommonMethods.GetCountOfNotebooksInDashboard();
                count = 2;
                for (int i = 1; i <= count; i++)
                {
                    if (i == 1)
                    {

                        AutomationAgent.Slide(1244, 676, 300, 653);
                    }
                    DashboardCommonMethods.ClickNotebookInDashboard(i);
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickTextIconInNotebook();
                    NotebookCommonMethods.TapOnScreen(762, 706);
                    NotebookCommonMethods.SendText("Test" + i);
                    NotebookCommonMethods.TapOnScreen(542, 252);
                    NotebookCommonMethods.ClickOnDoneCloseButton();

                }
                int j = 1;
                for (int k = count; k >= 2; k--)
                {
                    DashboardCommonMethods.ClickNotebookInDashboard(j);
                    string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone();
                    Assert.AreEqual<bool>(true, WordsInTextBox.Contains("Test" + k), "Text does not found");
                    NotebookCommonMethods.ClickOnDoneCloseButton();

                    j++;
                }
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
        [TestCategory("DashboardTests")]
        [WorkItem(21705)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherInitiallyLogsInTitleDashboardSaysMyDashboard()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboardTitle(), "Dashboard Title is not My Dashboard");
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
        [Priority(2)]
        [WorkItem(21706)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSeeMessageHelloTeacherNameTopLeft()
        {
            try
            {
                Login UserLogin = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(UserLogin);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                string UserNameFull = DashboardCommonMethods.GetHelloCurrentUserName().Replace("\r\n", ",");
                string[] UserName = UserNameFull.Split(',');
                string[] ActualUserName = UserLogin.PersonName.Split(' ');
                Assert.AreEqual(UserName[0], "Hello");
                Assert.AreEqual(UserName[1]," " + ActualUserName[0]+ " " + ActualUserName[1]);
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
        [WorkItem(21708)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherCanSeeCCMTEAndTeacherSupportIconsonDashboard()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerButton(), "Concept Corner button not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreButton(), "More to explore button not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportButtonDashboard(), "Teacher Support button Not found");
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
        [WorkItem(21732)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ClassWorkButtonAppearsOnTeacherDashboard()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(taskInfo.AdditionalInfo), "Class Work icon Not found");
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
        [Priority(2)]
        [WorkItem(27448), WorkItem(27223)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TapingOnELAUnitOrMyDashboardClosesTeacherMode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.SwipeLeft();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                //NavigationCommonMethods.GoToParentTillAvailable();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                //NavigationCommonMethods.GoToParentTillAvailable();
                LessonBrowserCommonMethods.ClickBackButton();
                LessonBrowserCommonMethods.ClickBackButton();
                    //LessonBrowserCommonMethods.ClickBackButton();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode opened");
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
        [Priority(2)]
        [WorkItem(22107)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void IfTeacherAccessedOtherUnitsButtonLinkLastAccessedUnit()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.SwipeLeft();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string UnitNumberX = DashboardCommonMethods.GetLessonBrowserPageTitle();
                char[] CharArray = UnitNumberX.ToCharArray();
                int CurrentUnit = Int32.Parse(CharArray[5].ToString());
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                AutomationAgent.Wait(500);
                NavigationCommonMethods.ClickUnitPreviewCard(CurrentUnit + 1);
                AutomationAgent.Wait(2000);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(CurrentUnit + 1);
                string UnitNumberY = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.GoToParentTillAvailable();
                DashboardCommonMethods.SwipeLeft();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string NewUnitNumber = DashboardCommonMethods.GetLessonBrowserPageTitle();
               // Assert.AreNotEqual(UnitNumberX, NewUnitNumber, "UnitNumber is same");
                Assert.AreNotEqual(UnitNumberY, NewUnitNumber, "UnitNumber is same");
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
        [Priority(2)]
        [WorkItem(22108)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void IfTeacherAccessedContentUnitLibraryThenDashboardButtonlinkingNotAffected()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                if(LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                        NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                
                string TaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyDashboardContinueLessons(secInfo.AdditionalInfo), "Continue Lesson is not found");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson + 1);
                string NewTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.TaskNumber);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyDashboardContinueLessons(secInfo.AdditionalInfo), "Continue Lesson is not found");
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string FinalTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(1);
                Assert.AreNotEqual(TaskTitle, NewTaskTitle, "TaskTitle is same");
                Assert.AreEqual(NewTaskTitle, FinalTaskTitle, "TaskTitle is not same");
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
        [WorkItem(21710)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardWhenInitiallyLogsInDashboardButtonsReadStartUnit()
        {
            try
            {
                Login SecTeacher = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = SecTeacher.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(SecTeacher);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifySectionedGradesAvailable(SecTeacher), "Sectioned Grades not available in screen");
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.SwipeLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
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
        [Priority(2)]
        [WorkItem(21711)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ATeacherDashboardButtonsReadContinueLessonIfLessonHasBeenStarted()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
               // Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(secInfo.AdditionalInfo), "Start unit not found");
                //Assert.IsFalse(DashboardCommonMethods.VerifyDashboardContinueLessons(secInfo.AdditionalInfo), "Continue Lesson not found");
                
                string StartConttext = DashboardCommonMethods.GetTextDashboardStartContinueLessons(secInfo.AdditionalInfo);
                Assert.IsTrue(StartConttext.ToLower().Contains("start"), "start button text not found");
                Assert.IsFalse(StartConttext.ToLower().Contains("continue"), "continue button text  found");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                
                NavigationCommonMethods.NavigateMyDashboard();
                //Assert.IsTrue(DashboardCommonMethods.VerifyDashboardContinueLessons(secInfo.AdditionalInfo), "Continue Lesson not found");
                Assert.IsTrue(StartConttext.ToLower().Contains("continue"), "continue button text not found");
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
        [Priority(2)]
        [WorkItem(21728)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardClassRosterButtonAppearsOnTeacherDashboard()
        {
            try
            {
                Login SecTeacher = Login.GetLogin("Sec9Apatton");
                TaskInfo secInfo = SecTeacher.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(SecTeacher);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifySectionedGradesAvailable(SecTeacher), "Sectioned Grades not available in screen");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class Roster Not found");
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
        [Priority(2)]
        [WorkItem(20684)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void WhenStudentInitiallyloginTitle0fDashboardSaysMyDashboard()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboardTitle(), "Dashboard Title is not My Dashboard");
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
        [Priority(2)]
        [WorkItem(20687)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void WhenStudentInitiallyloginThenStudentSeeTodaysDayAndDateAtTopRight()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyDayAndDateOnDashBoard(), "Day and Date is not found");
                DateTime today = DateTime.Today;
                string todayDate = today.ToLongDateString();
                string Date = DashboardCommonMethods.GetDateDisplayed();
                Assert.AreEqual(todayDate, Date, "Current Date is not displayed on student dashboard");
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
        [Priority(2)]
        [WorkItem(20690)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenStudentInitiallyloginThenStudentSeeHelloWithName()
        {
            try
            {

                Login UserLogin = Login.GetLogin("StudentBruceSec9Apatton");
                string[] studentName = UserLogin.PersonName.Split(' ');
                NavigationCommonMethods.LoginApp(UserLogin);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyHelloWithStudentName(), "Hello with Student Name is not found");
                string UserNameFull = DashboardCommonMethods.GetHelloStudentName().Replace("\r\n", ",");
                Assert.AreEqual(UserNameFull, "Hello, " + studentName[0], "Hello user name not found");
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
        [Priority(2)]
        [WorkItem(20689)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenstudentinitiallyloggsinThenthestudentseestheProfilePhotoimage()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyStudentDashboardProfilePhoto(), "No Profile Photo On DashBoard");
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
        [Priority(2)]
        [WorkItem(21761)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void IfthereisnoimagesavedyetindashboardstudentwillseePlaceholdertoaddphoto()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyProfilePhotoCameraIcon(), "No Camera Icon");
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
        [Priority(2)]
        [WorkItem(21779)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Teachercanremovephoto()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                if (!DashboardCommonMethods.VerifyProfilePhoto())
                {
                    NotebookCommonMethods.TapOnScreen(247, 314);
                    DashboardCommonMethods.ClickCameraIconInDashboard();
                    DashboardCommonMethods.ClickCameraRollButton();
                    DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                    DashboardCommonMethods.ClickSelectAnImage();
                    DashboardCommonMethods.ClickCameraOKButton();
                }
                Assert.IsTrue(DashboardCommonMethods.VerifyProfilePhoto(), "No Profile Photo");
                DashboardCommonMethods.ClickOnProfilePhoto();
                DashboardCommonMethods.ClickDeletePhoto();
                Assert.IsFalse(DashboardCommonMethods.VerifyProfilePhoto(), "Profile Photo Exists");
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
        [Priority(2)]
        [WorkItem(21785)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Studentcanremovephoto()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                if (!DashboardCommonMethods.VerifyProfilePhotoStudent())
                {
                    NotebookCommonMethods.TapOnScreen(247, 314);
                    DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                    DashboardCommonMethods.ClickCameraRollButton();
                    DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                    DashboardCommonMethods.ClickSelectAnImage();
                    DashboardCommonMethods.ClickCameraOKButton();
                }
                Assert.IsTrue(DashboardCommonMethods.VerifyProfilePhotoStudent(), "No Profile Photo");
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickDeletePhoto();
                Assert.IsFalse(DashboardCommonMethods.VerifyProfilePhotoStudent(), "Profile Photo Exists");
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
        [Priority(2)]
        [WorkItem(22116)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DefultImagePlaceholderAppearsIfNoTeacherPhotoChosen()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraDeleteButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
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
        [Priority(2)]
        [WorkItem(21780)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void TeacherRetakePhotoAlsoCancelHisChoiceTheMiddle()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraCancelButton();
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraDeleteButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
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
        [Priority(2)]
        [WorkItem(21786)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void StudentRetakePhotoAlsoCancelHisChoiceTheMiddle()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraCancelButton();
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraDeleteButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
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
        [Priority(2)]
        [WorkItem(21762)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UsercantaponanywhereinimageboxandcanAddphotofromcameraroll()
        {
            try
            {

                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");

                if (DashboardCommonMethods.VerifyProfilePhotoStudent())
                {
                    DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                    DashboardCommonMethods.ClickDeletePhoto();
                }
                
                Assert.IsFalse(DashboardCommonMethods.VerifyProfilePhotoStudent(), "Profile Photo Exists");
                NotebookCommonMethods.TapOnScreen(247, 314);
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyProfilePhotoStudent(), " No Profile Photo Exists");
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
        [TestCategory("DashboardTests")]
        [Priority(2)]
        [WorkItem(22618), WorkItem(22619)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CharacterlimitreflectsonCharacterCountinReminders()
        {
            try
            {

                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(DashboardCommonMethods.verifyReminderOnDashBoard(), "Reminder is Not Present");
                DashboardCommonMethods.ClickOnReminder();
                Assert.IsTrue(DashboardCommonMethods.InsertTextInReminder(501), "Adding more than 500 char allowed");
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

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [Priority(2)]
        [WorkItem(22616)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CharacterCountwhencreatingnewReminder()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(DashboardCommonMethods.verifyReminderOnDashBoard(), "Reminder is Not Present");
                DashboardCommonMethods.ClickOnReminder();
                int countbefore = DashboardCommonMethods.Getcharactercount();
                DashboardCommonMethods.InsertTextInReminder(1);
                int countafter = DashboardCommonMethods.Getcharactercount();
                Assert.AreEqual((countbefore + 1), countafter, "Count is Not Equal");
                DashboardCommonMethods.ClickOnReminderCancelButton();
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
        [Priority(2)]
        [WorkItem(21764)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void TeacherCanTapAllphotoAreaToPromptCameraRoll()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                DashboardCommonMethods.ClickCameraIconInDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(), "Camera roll button is not found");
                DashboardCommonMethods.TapOnScreen(100, 200);
                Assert.IsFalse(DashboardCommonMethods.VerifyCameraRollButton(), "Camera Roll button is found");
                DashboardCommonMethods.ClickCameraIconInDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(), "Camera Roll button is not present");
                DashboardCommonMethods.ClickCameraIconInDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(), "Camera Roll button is Present");
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
        [Priority(2)]
        [WorkItem(21765)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void TeacherCanTakePhotoThePhotoWillSaveToClassPhotosForEachClass()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
                DashboardCommonMethods.ClickCameraIconInDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(), "Camera roll button is not found");

                if (DashboardCommonMethods.VerifySectionThirdInDashboard())
                {
                    DashboardCommonMethods.ClickCameraImageSecondOnDashboard();
                    DashboardCommonMethods.ClickCameraRollButton();
                    DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                    DashboardCommonMethods.ClickSelectAnImage();
                    DashboardCommonMethods.ClickCameraOKButton();
                    DashboardCommonMethods.ClickCameraIconInDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(), "Camera roll button is not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyDeletePhotoButton(), "Delete Photo Button is not found");
                }
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Grade2Sswanson2"));
                DashboardCommonMethods.ClickCameraIconInDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraRollButton(), "Camera roll button is not found");
                Assert.IsFalse(DashboardCommonMethods.VerifyDeletePhotoButton(), "Delete Photo Button is found");
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
        [TestCategory("DashboardTests")]
        [Priority(2)]
        [WorkItem(22614)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ReminderarealignedattheBottomoftheTeacherDashboard()
        {
            try
            {

                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "No DashBoard");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                if (DashboardCommonMethods.VerifyNewReminder(1))
                {
                    Assert.IsTrue(DashboardCommonMethods.VerfiyReminderAtBottom(), "Reminder Is Not On Bottom");
                }
                else
                {
                    DashboardCommonMethods.ClickOnReminder();
                    DashboardCommonMethods.InsertTextInReminder(1);
                    DashboardCommonMethods.ClickOncreateReminderButton();
                    Assert.IsTrue(DashboardCommonMethods.VerfiyReminderAtBottom(), "Reminder Is Not On Bottom");
                }
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

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [Priority(2)]
        [WorkItem(22621)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeachercanDeleteTODOs()
        {
            try
            {

                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyNewReminder(1), "Reminder is Not Present");
                DashboardCommonMethods.DeleteReminder();
                Assert.IsFalse(DashboardCommonMethods.VerifyNewReminder(1), "Reminder is Not Present");
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
        [WorkItem(19137)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SectionStudentProfileIssues()
        {

            try
            {
                //Sectioned Student
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Is Not Avaialble");
                Assert.IsFalse(DashboardCommonMethods.VerifyTeacherSupportButtonPresent(), "TeacherSupportButton Is Present");
                NavigationCommonMethods.Logout();

                //Sectioned Teacher
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Is Not Avaialble");
                Assert.IsTrue(DashboardCommonMethods.VerifyTeacherSupportButtonPresent(), "TeacherSupportButton Is Not Present");
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
        [TestCategory("DashboardTests")]
        [Priority(3)]
        [WorkItem(22622)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherCanEditToDos()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                DashboardCommonMethods.ClickOnReminder();
                DashboardCommonMethods.InsertTextInReminder(2);
                string WordsInTextBox = DashboardCommonMethods.GetTextFromReminderEditBox();
                Assert.IsTrue(WordsInTextBox.Contains("ff"));
                DashboardCommonMethods.ClickOncreateReminderButton();
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
        [Priority(2)]
        [WorkItem(22134)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void WhenItapaddphotoandotherButtonSimultaneouslyIshouldnotseeaddphotomenuwhenImovedoutoftheDashboad()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                DashboardCommonMethods.ClickSecondCameraIconInDashboard(secInfo.AdditionalInfo);
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                AutomationAgent.Wait(1000);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage() || LessonBrowserCommonMethods.VerifyLessonOpenedToRead(), "Lesson Browser Page Is Not Present");
                Assert.IsFalse(DashboardCommonMethods.VerifyPhotoMenu(), "Add Photo Menu Is Present");
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
        [TestCategory("DashboardTests")]
        [WorkItem(22617)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void CharacterCountWhenAddingEditingTextOnExistingReminders()
        {
            try
            {
                int text = 1;
                int text1 = 2;
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                DashboardCommonMethods.ClickOnReminder();
                DashboardCommonMethods.InsertTextInReminder(text);
                DashboardCommonMethods.ClickOncreateReminderButton();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyNewReminder(text), "Reminder is Not Present");
                DashboardCommonMethods.ClickExistingReminder(text);
                string s = DashboardCommonMethods.GetCharacterCountAtTopRight(text + 3);
                Assert.AreEqual(s, text + " / 500  characters max", "Character Count not similar to the text");
                int countbefore = DashboardCommonMethods.Getcharactercount();
                DashboardCommonMethods.InsertTextInReminder(text1);
                int countafter = DashboardCommonMethods.Getcharactercount();
                Assert.AreEqual((countbefore + 1), countafter, "Count is Not Equal");
                DashboardCommonMethods.InsertTextInReminder(text);
                int countNew = DashboardCommonMethods.Getcharactercount();
                Assert.AreEqual((countafter - 1), countNew, "Count is Not Equal");
                DashboardCommonMethods.ClickOnReminderDeleteButton();
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
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

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22315)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void RemindersReflectingNumberOfRemindersCreated()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard Page not present");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                int remCount = DashboardCommonMethods.GetCountOfRemindersInDashboard();
                DashboardCommonMethods.ClickOnReminder();
                DashboardCommonMethods.InsertTextInReminder(1);
                DashboardCommonMethods.ClickOncreateReminderButton();
                int newRemCount = DashboardCommonMethods.GetCountOfRemindersInDashboard();
                Assert.AreEqual(newRemCount, remCount + 1);
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
        [Priority(2)]
        [WorkItem(20632)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void IfUserHasAccessedALessonButtonWillLinkToLastAccessedTaskOfLesson()
        {
            try
            {
                //Login login = Login.GetLogin("StudentAaliyah");
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                
                string elaTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickMathStartUnitInDashboard();
                //if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                  //  NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                
                //string mathTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                //NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);

                string elaTaskTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual(elaTaskTitle, elaTaskTitle1, "Task Titles are not similar");
                //NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickMathContinueLessonInDashboard();
               // DashboardCommonMethods.ClickOnDashBoardStartUnitStudent(secInfo.AdditionalInfo);
                //string mathTaskTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                //Assert.AreEqual(mathTaskTitle, mathTaskTitle1, "Task Titles are not similar");
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
        [Priority(2)]
        [WorkItem(21725)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TeacherCanSeeSwipeSectionTilesLeftAndRightIndicatorVisible()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo sec9Info = login.GetTaskInfo("ELA", "Grade9");
                TaskInfo sec12Info = login.GetTaskInfo("ELA", "Grade12");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard Page not present");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                //int pos = DashboardCommonMethods.GetPositionOfScrollbar();
                Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboardVisible(sec9Info.AdditionalInfo), "Reminder is not present in the dasdhboard");
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                //int newPos = DashboardCommonMethods.GetPositionOfScrollbar();
                //Assert.IsFalse(DashboardCommonMethods.VerifyStartUnitInDashboardVisible(sec9Info.AdditionalInfo), "start unit is  present in the dasdhboard");
                //Assert.AreNotEqual(pos, newPos, "Positions are different of Horizontal scrollbar");
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
        [Priority(2)]
        [WorkItem(21727)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TeacherCanGetTheAccessToTheLessonByClickingOnContinueLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyDashboardContinueLessons(secInfo.AdditionalInfo), "Continue Lesson is not found");
                if (DashboardCommonMethods.VerifyStartUnitInDashboard(secInfo.AdditionalInfo))
                {
                    DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                    if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                    {
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser Page not present");
                        NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                    }
                }
                else
                {
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                }
                string TaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyDashboardContinueLessons(secInfo.AdditionalInfo), "Continue Lesson not present in Dashboard");
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string newTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual(TaskTitle, newTaskTitle, "Titles are not similar");
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
        [Priority(3)]
        [WorkItem(22110)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void OnlySectionedContentIsLinkedToTeachersDashboardButtons()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                string taskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string taskTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual(taskTitle, taskTitle1, "Task Ttiles are not similar");

                int grade = NavigationCommonMethods.IdentifyGradesPresentForELAExceptSectioned(taskInfo.Grade);
                if(grade>12)
                {
                    grade = login.SectionedGrades[0];
                }

                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                string newTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string newTaskTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                if(grade!=login.SectionedGrades[0])
                     Assert.AreNotEqual(newTaskTitle, newTaskTitle1, "Task Ttiles are similar");

                else
                    Assert.AreEqual(newTaskTitle, newTaskTitle1, "Task titles are not similar, even single grade sectioned user");
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
        [TestCategory("DashboardTests")]
        [WorkItem(22620)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherCanAddUnlimitedToDoNotes()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    for (int i = 1; i < 5; i++)
                    {
                        DashboardCommonMethods.ClickOnReminder();
                        DashboardCommonMethods.InsertTextInReminder(1);
                        DashboardCommonMethods.ClickOncreateReminderButton();
                        Assert.IsTrue(DashboardCommonMethods.VerifyNewReminder(i), "New reminder not getting created No." + i);
                    }
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
        [WorkItem(23251)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void STUDENTDASHBOARDPlaceholderAppearsInMyRecentWorkArea()
        {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                    //Assert.IsTrue(DashboardCommonMethods.GetCountOfNotebooksInDashboard() == 0, "Placeholder for no recent work to display not found");
                    Assert.IsTrue(DashboardCommonMethods.VerifyRecentNoteBookInDashboard(), "Placeholder for no recent work to display not found");
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
        [TestCategory("DashboardTests")]
        [WorkItem(22317)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardVerifyReminderModificationtime()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    if (!DashboardCommonMethods.VerifyNewReminder(1))
                    {
                        DashboardCommonMethods.ClickOnReminder();
                        DashboardCommonMethods.InsertTextInReminder(1);
                        DashboardCommonMethods.ClickOncreateReminderButton();
                    }
                Assert.IsTrue(DashboardCommonMethods.GetReminderModificationTime(1, "Today"), "reminder not created today");
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

        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22610)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardToDoNotesaAreSortedByDate()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                if (!DashboardCommonMethods.VerifyNewReminder(1))
                {
                    DashboardCommonMethods.ClickOnReminder();
                    DashboardCommonMethods.InsertTextInReminder(1);
                    DashboardCommonMethods.ClickOncreateReminderButton();
                }
                Assert.IsTrue(DashboardCommonMethods.GetReminderModificationTime(1, "Today"), "reminder not created today");

                if (DashboardCommonMethods.VerifyNewReminder(2))
                {
                    if (!DashboardCommonMethods.GetReminderModificationTime(2, "Today") ||
                        !DashboardCommonMethods.GetReminderModificationTime(2, "Yesterday"))
                    {
                        Assert.Fail("reminders not correctly sorted");
                    }
                }


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






        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22615), WorkItem(22320)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardReminderExtendSwipeIndicatorVisibleReflectsThePages()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    for (int i = 0; i < 3; i++)
                    {
                        DashboardCommonMethods.ClickOnReminder();
                        DashboardCommonMethods.InsertTextInReminder(1);
                        DashboardCommonMethods.ClickOncreateReminderButton();
                    }

                    int paginationindicator1 = DashboardCommonMethods.GetPaginationIndicatorReminderPos(1);
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    for (int i = 0; i < 3; i++)
                    {
                        DashboardCommonMethods.ClickOnReminder();
                        DashboardCommonMethods.InsertTextInReminder(1);
                        DashboardCommonMethods.ClickOncreateReminderButton();
                    }
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    int paginationindicator2 = DashboardCommonMethods.GetPaginationIndicatorReminderPos(1);
                    Assert.IsTrue(paginationindicator2 < paginationindicator1, "pagination indicator count not increased");
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


        //[TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(22316)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardNoRemindersThenNoMessageIsDisplayed()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                    while (DashboardCommonMethods.VerifyNewReminder(1))
                    {
                        DashboardCommonMethods.DeleteReminder();
                    }
                    Assert.IsFalse(DashboardCommonMethods.VerifyNewReminder(1), "Reminder no message not found");
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
        [WorkItem(22148)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherWillSeeHisAssociatedGradeOnTheDashboardOnInitialLogin()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.AreEqual<bool>(true, DashboardCommonMethods.VerifyUserIsOnDashBoard(), "use not on dashboard");
                NavigationCommonMethods.NavigateToELA();
                Assert.AreEqual<bool>(false, NavigationCommonMethods.IsNonSectionedUser(Login.GetLogin("Sec9Apatton")), "sec grades not found");
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
        [WorkItem(18612)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenSectionedGradesDownloadedUserMovedToDashboard()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToELA();
                    NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                    Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(taskInfo.Grade), "Default grade not in highlited state");
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
        [WorkItem(21787)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardStudentcanRepositionResizePhoto()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "Camera icon not found");

                NotebookCommonMethods.TapOnScreen(247, 314);
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.AddPhotoInDashboardWithesizeAndReposition();
                DashboardCommonMethods.ClickCameraOKButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyProfilePhotoStudent(), " No Profile Photo Exists");
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickDeletePhoto();
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
        [WorkItem(21778)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardStudentcanRepositionResizePhoto()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "Camera icon not found");

                NotebookCommonMethods.TapOnScreen(247, 314);
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.AddPhotoInDashboardWithesizeAndReposition();
                DashboardCommonMethods.ClickCameraOKButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyProfilePhotoStudent(), " No Profile Photo Exists");
                DashboardCommonMethods.ClickCameraIconInDashboardStudent();
                DashboardCommonMethods.ClickDeletePhoto();
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
        [TestCategory("DashboardTests")]
        [WorkItem(22607)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardToDoNotesSavedAsPerUser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                DashboardCommonMethods.DeleteReminder();
                Assert.IsFalse(DashboardCommonMethods.VerifyNewReminder(1), "Reminder still found");

                login = Login.GetLogin("Sec6Efoster");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                DashboardCommonMethods.ClickOnReminder();
                DashboardCommonMethods.InsertTextInReminder(1);
                DashboardCommonMethods.ClickOncreateReminderButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyNewReminder(1), "Reminder not found for user 2");
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();

                login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                Assert.IsFalse(DashboardCommonMethods.VerifyNewReminder(1), "Reminder also got created for user 1");
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
        [WorkItem(23279)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ASTUDENTDASHBOARDSeeAllDoesNotAppearsIFLessThan6NotebooksAreAvailable()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                taskInfo.TaskNumber = 1;
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Not on DashBoard");
                Assert.IsTrue(DashboardCommonMethods.VerifyNotebooksAtBottomOfDashboard(), "No NoteBooks at bottom");
               int noOfNotebooks = DashboardCommonMethods.GetCountOfNotebooksInDashboard();
               if (noOfNotebooks < 6)
               {
                   Assert.IsFalse(DashboardCommonMethods.VerifySeeAllButtonInDashboard(), "See All Button available on dashboard");
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
        [TestCategory("DashboardTests")]
        [WorkItem(23280)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void STUDENTDASHBOARDSeeAllAppearsIFMORETHAN5NotebooksAreAvailable()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                taskInfo.TaskNumber = 1;
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Not on DashBoard");
                Assert.IsTrue(DashboardCommonMethods.VerifyNotebooksAtBottomOfDashboard(), "No NoteBooks at bottom");
                int noOfNotebooks = DashboardCommonMethods.GetCountOfNotebooksInDashboard();

                if (noOfNotebooks < 6)
                {
                    //Add Notebooks
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    for (int i = noOfNotebooks; i < 7; i++)
                    {
                        NotebookCommonMethods.ClickTextIconInNotebook();
                        AutomationAgent.Wait(500);
                        NotebookCommonMethods.TapOnScreen(1200, 700);
                        NotebookCommonMethods.AddTextInNotebook("ABCD");
                        AutomationAgent.Wait(500);
                        NotebookCommonMethods.TapOnScreen(1200, 400);
                        AutomationAgent.Wait(500);
                        NavigationCommonMethods.ClickNextPageIcon();
                        AutomationAgent.Wait(500);
                    }
                }
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifySeeAllButtonInDashboard());
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
        [Priority(1)]
        [WorkItem(14404)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SectionStudentSharedHistoryIconInEveryScreenChromeBar()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard");
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Shared Work Notification Icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(DashboardCommonMethods.VerifyListOfSharedItems(1), "List of shared items are not present");
                NotebookCommonMethods.TapOnScreen(1000, 35);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Shared Work Notification Icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(DashboardCommonMethods.VerifyListOfSharedItems(1), "List of shared items are not present");
                NotebookCommonMethods.TapOnScreen(1000, 35);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickOnNotebookIcon();
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                NotebookCommonMethods.TapOnScreen(519, 63);
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                WorkBrowserCommonMethods.ClickOnViewInLessonButton();
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Shared Work Notification Icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(DashboardCommonMethods.VerifyListOfSharedItems(1), "List of shared items are not present");
                NotebookCommonMethods.TapOnScreen(1000, 35);
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
        [Priority(2)]
        [WorkItem(16078)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SharingNotificationsPopUpOpenPopupAndVerifyLayot()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                string name = login.PersonName;
                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                DashboardCommonMethods.ClickOnItemInNotification(1);
                Assert.IsTrue(DashboardCommonMethods.VerifyItemsFormatInNotificationOverlay(name), "Items in Notification are not formatted properly");
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
        [Priority(2)]
        [WorkItem(22106)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TeacherDashboardSectionTitlesAreOnlySectionTags()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard");
                string title = DashboardCommonMethods.GetELAThumbnailTitle(taskInfo.AdditionalInfo);
                NavigationCommonMethods.NavigateWorkBrowser();
                string title1 = WorkBrowserCommonMethods.GetSectionDropDownSelectedText();
                Assert.IsTrue(title1.Contains(title), "Titles are not similar");
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
        [WorkItem(20634)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentlinksToRecentlyUsedContentPreservedAfterAppCrashedUserLoggedOutAndIn()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                string taskTitleELA = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                string taskTitleMath = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                NavigationCommonMethods.NavigateToMyDashboard();
                AutomationAgent.CloseApp();
                AutomationAgent.LaunchApp();
                NavigationCommonMethods.LoginApp(login);
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string taskTitleELA1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual<string>(taskTitleELA, taskTitleELA1, "Task Title's  of ELA Are not equal");
                NavigationCommonMethods.NavigateToMyDashboard();
                DashboardCommonMethods.ClickMathContinueLessonInDashboard();
                string taskTitleMath1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual<string>(taskTitleMath, taskTitleMath1, "Task Title's of Math Are not equal");
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(login);
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                
                string taskTitleELA2 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual<string>(taskTitleELA, taskTitleELA2, "Task Title's  of ELA Are not equal");
                NavigationCommonMethods.NavigateToMyDashboard();
                DashboardCommonMethods.ClickMathContinueLessonInDashboard();
                string taskTitleMath2 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual<string>(taskTitleMath, taskTitleMath2, "Task Title's of Math Are not equal");
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

        //Network Dependent

        [TestMethod()]
        [TestCategory("DashboardTests")]
        [WorkItem(23147)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NonSectionedUsersDontSeeMTECC()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("GustadMody"));
                Assert.IsFalse(NavigationCommonMethods.VerifyDashboard(), "Dashboard  found");
                Assert.IsFalse(DashboardCommonMethods.VerifyMoreToExploreButton(), "More to explore  found");
                Assert.IsFalse(DashboardCommonMethods.VerifyConceptCornerButton(), "Concept corner  found");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentGustadMody"));
                Assert.IsFalse(NavigationCommonMethods.VerifyDashboard(), "Dashboard  found");
                Assert.IsFalse(DashboardCommonMethods.VerifyMoreToExploreButton(), "More to explore  found");
                Assert.IsFalse(DashboardCommonMethods.VerifyConceptCornerButton(), "Concept corner  found");
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
        [WorkItem(22767)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CCorMTEForbaugustine1Andkdelay4236WorkJustLikeForAnyOtherTeacher()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("kdelay4236"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                DashboardCommonMethods.ClickMoreToExploreButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                DashboardCommonMethods.ClickConceptCornerButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept corner not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(Login.GetLogin("baugustine1"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                DashboardCommonMethods.ClickMoreToExploreButton();
                AutomationAgent.Wait();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                DashboardCommonMethods.ClickConceptCornerButton();
                AutomationAgent.Wait();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept corner not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
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
        [WorkItem(21707)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherCanSeeSharedworkNotificationsDropdownicon()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Shared work notifications not found");
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
        [WorkItem(22477)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MoreToExploreOpensViaDashboardButton()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                DashboardCommonMethods.ClickMoreToExploreButton();
                AutomationAgent.Wait();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                DashboardCommonMethods.ClickOnCloseButton();
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
        [WorkItem(22487)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ConceptCornerOpensViaDashboardButton()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                DashboardCommonMethods.ClickConceptCornerButton();
                AutomationAgent.Wait();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept corner not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
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
        [WorkItem(22760)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTappingOnCCOrMTETakesTeacherToTheLandingPage()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerButton(), "Concept Corner button not found");
                DashboardCommonMethods.ClickConceptCornerButton();
                AutomationAgent.Wait(2000);
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept Corner not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreButton(), "More to explore button not found");
                DashboardCommonMethods.ClickMoreToExploreButton();
                AutomationAgent.Wait(2000);
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore Not opened ");
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dahboard Not found");
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
        [WorkItem(21952)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GoToWorkBrowserButtonTakesUserToWorkBrowser()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User Landing page is not Dashboard");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                AutomationAgent.Wait();
                Assert.IsTrue(DashboardCommonMethods.VerifyNotificationOverlayPresent(), "Notification overlay not present");
                AutomationAgent.Wait();
                DashboardCommonMethods.ClickOnItemInNotification(1);
                Assert.IsTrue(DashboardCommonMethods.VerifyGoToWorkBrowserButton(), "Go To Work Browser Button not present");
                DashboardCommonMethods.ClickOnGoToWorkBrowserButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(), "Work Browser Page is not present");
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
        [WorkItem(22765)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DashboardOpeningMtaCcSlideUpTransition()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                DashboardCommonMethods.ClickMoreToExploreButton();
                AutomationAgent.Wait(5000);
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                DashboardCommonMethods.ClickOnCloseButton();
                DashboardCommonMethods.ClickConceptCornerButton();
                AutomationAgent.Wait(5000);
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept corner not opened");
                DashboardCommonMethods.ClickOnCloseButton();
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
        [WorkItem(22766)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DashboardLeavingMtaCCViaDONESlideDownTransitionLandingBackOnTheDashboard()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dahboard Not found");
                DashboardCommonMethods.ClickMoreToExploreButton();
                AutomationAgent.Wait(5000);
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dahboard Not found");
                DashboardCommonMethods.ClickConceptCornerButton();
                AutomationAgent.Wait(5000);
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dahboard Not found");
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
        [WorkItem(23254)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenStudentTapsNotebookThumbnailInDashboardNotebookOpens()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickNotebookInDashboard(1);
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyWorkBrowserViewInLesson(), "Work browser view not verified");
                NotebookCommonMethods.ClickOnDoneCloseButton();
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
        ////[TestCategory("DashboardTests")]
        ////[WorkItem(22115)]
        ////[Priority(3)]
        ////[Owner("Akanksha Gautam(akanksha.gautam)")]
        ////public void TeacherDashboardClassWorkAndClassRosterAppearing()
        ////{

        ////    try
        ////    {
        ////        Login login = Login.GetLogin("kdelay4236");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade12");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateMyDashboard();
        ////        if (!DashboardCommonMethods.VerifyUserIsOnDashBoard())
        ////        {
        ////            LessonBrowserCommonMethods.ClickAddGrades();
        ////            LessonBrowserCommonMethods.SelectSpecificGrade(taskInfo.Grade);
        ////            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////            NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////            NavigationCommonMethods.WaitForGradeDownloading();
        ////            NavigationCommonMethods.NavigateToMath();
        ////            NavigationCommonMethods.NavigateMyDashboard();
        ////            DashboardCommonMethods.SwipeLeft();
        ////        }
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(secInfo.AdditionalInfo), "Class Work Button not present in the dashboard");
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class Roster Button not present");
        ////        NavigationCommonMethods.Logout();
        ////        Login login1 = Login.GetLogin("baugustine1");
        ////        taskInfo = login1.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        if (!DashboardCommonMethods.VerifyUserIsOnDashBoard())
        ////        {
        ////            LessonBrowserCommonMethods.ClickAddGrades();
        ////            LessonBrowserCommonMethods.SelectSpecificGrade(taskInfo.Grade);
        ////            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////            NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////            NavigationCommonMethods.WaitForGradeDownloading();
        ////            NavigationCommonMethods.NavigateToMath();
        ////            NavigationCommonMethods.NavigateMyDashboard();
        ////            DashboardCommonMethods.SwipeLeft();
        ////        }
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyClassWorkInDashboard(secInfo.AdditionalInfo), "Class Work Button not present in the dashboard");
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class Roster Button not present");
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
        [TestCategory("DashboardTests")]
        [WorkItem(20796)]
        [Priority(3)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void StudentDashbaordSeparateLayoutsAreAppearingForSectionedStudents()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                Assert.IsTrue(DashboardCommonMethods.VerifyOneCourseLayOut(), "Layout is not according to One Course");
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentAaliyah"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                Assert.IsTrue(DashboardCommonMethods.VerifyDoubleCourseLayOut(), "Layout is not according to Double Course");
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
        [WorkItem(20602)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardStartUnitLinksToFirstUnitForMathELAofSectionedGrade()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
                string GradeNo = DashboardCommonMethods.GetLessonBrowserBackButtonTitle();
                if(GradeNo.Contains("Unit"))
                {
                    LessonBrowserCommonMethods.ClickOnBackButton();
                    GradeNo = DashboardCommonMethods.GetLessonBrowserBackButtonTitle();
                }
                
                string UnitNumberX = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                string UnitNumbery = DashboardCommonMethods.GetLessonBrowserPageTitle();
                Assert.AreEqual(UnitNumberX, UnitNumbery, "UnitNumber  is not same");
                Assert.IsTrue(GradeNo.Contains("Grade 9 ELA"), "Grade 9 not found");
                //NavigationCommonMethods.ClickLessonBrowserBackButton();
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
        [WorkItem(20601)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void IfUserAccessedOtherUnitButtonLinkLastAccessedUnit()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = Login.GetLogin("Sec9Apatton").GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string UnitNumber = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                string UnitNumbery = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string UnitNumberx = DashboardCommonMethods.GetLessonBrowserPageTitle();
                Assert.AreEqual(UnitNumber, UnitNumberx, "UnitNumber  is not same");

                //NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickMathStartUnitInDashboard();
                //string UnitNumberMath = DashboardCommonMethods.GetLessonBrowserPageTitle();
                //NavigationCommonMethods.NavigateToMath();
                //NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                //NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                //string UnitNumber2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                //NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickMathStartUnitInDashboard();
                //string UnitNumberMath2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                //Assert.AreEqual(UnitNumberMath, UnitNumberMath2, "UnitNumber  is not same");
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
        [WorkItem(21721)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherCanSeeAllSectionsTeachTheirDashboard()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifySectionGradeInDashboard(), "Section First is not Found");
                Assert.IsTrue(DashboardCommonMethods.VerifySectionFirstInDashboard(), "Section First is not Found");
                Assert.IsTrue(DashboardCommonMethods.VerifySectionSecondInDashboard(), "Section Second Is not found");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                //Chnge fter sigle section user
                //Assert.IsTrue(DashboardCommonMethods.VerifySectionThirdInDashboard(), "Third Second Is not found");
                Assert.IsFalse(DashboardCommonMethods.VerifySectionThirdInDashboard(), "Third Second Is not found");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsFalse(DashboardCommonMethods.VerifySectionThirdInDashboard(), "Third Second Is not found");
                Assert.IsTrue(DashboardCommonMethods.VerifySectionFirstInDashboard(), "Section First is not Found");
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
        [Priority(2)]
        [WorkItem(21763)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherAddClassPhotoForEachTeacherTaughtSections()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyCameraIconInDashboard(), "CameraIcon is not found on Dashboard");
                DashboardCommonMethods.ClickFirstSectionCameraIcon();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();

                if (DashboardCommonMethods.VerifySectionThirdInDashboard())
                {
                    DashboardCommonMethods.ClickSecondSectionCameraIconOnDashboard();
                    DashboardCommonMethods.ClickCameraRollButton();
                    DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                    DashboardCommonMethods.ClickSelectAnImage();
                    DashboardCommonMethods.ClickCameraOKButton();
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();

                    DashboardCommonMethods.ClickThirdSectionCameraIconOnDashboard();
                    DashboardCommonMethods.ClickCameraRollButton();
                    DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                    DashboardCommonMethods.ClickSelectAnImage();
                    DashboardCommonMethods.ClickCameraOKButton();
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                }
                DashboardCommonMethods.ClickCameraIconInDashboard();
                DashboardCommonMethods.ClickCameraRollButton();
                DashboardCommonMethods.ClickCameraImageFromCameraIcon();
                DashboardCommonMethods.ClickSelectAnImage();
                DashboardCommonMethods.ClickCameraOKButton();
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
        [WorkItem(22763)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardMoreToExploreAndConceprCorner()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Student1"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreButtonStudent(), "More to explore button not found");
                DashboardCommonMethods.ClickMoreToExploreButtonStudent();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                Assert.IsTrue(DashboardCommonMethods.VerifyDoneButtonInMTENativeView(), "More To Explore done button not found in PSoC view");
                DashboardCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerButtonStudent(), "Concept Corner button not found");
                DashboardCommonMethods.ClickConceptCornerButtonStudent();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept Corner is not opened");
                Assert.IsTrue(DashboardCommonMethods.VerifyDoneButtonInCCNativeView(), "Concept corner done button not found in PSoC view");
                DashboardCommonMethods.ClickOnCloseButton();
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
        [WorkItem(22113)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashbaordSeparateLayoutsAreAppearingForSectionedTeacher()
        {

            try
            {
                Login login = Login.GetLogin("baugustine1");
                NavigationCommonMethods.LoginApp(Login.GetLogin("baugustine1"));
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                Assert.IsTrue(DashboardCommonMethods.VerifySecondCourseLayOutTeacher(secInfo.AdditionalInfo), "Layout is not according to Second Course");
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
        [WorkItem(22112)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashbaordLayoutsWithOneClassAndCourse1()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                Assert.IsTrue(DashboardCommonMethods.VerifyOneCourseLayOutTeacher(), "Layout is not according to One Course");
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
        [WorkItem(22114)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardButtonLinkingWith1ClassAndCourseAndWith1ClassAndourses()
        {

            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyOneCourseLayOutTeacher(), "Layout is not according to One Course");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("baugustine1");
                TaskInfo taskInfo1 = login1.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo1.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo1.Unit);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifySecondCourseLayOutTeacher(secInfo.AdditionalInfo), "Layout is not according to Second Course");
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
        [Priority(2)]
        [WorkItem(31822)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UnitLabelsAreUpdatedOnStudentDashboard()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnDashBoardStartUnitStudent(taskInfo.AdditionalInfo);
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                if(LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                    NavigationCommonMethods.ClickLessonBrowserBackButton();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                //NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit + 2);
                AutomationAgent.Wait();
                NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit + 2);
                string unitNo = DashboardCommonMethods.GetLessonBrowserPageTitle();
                Assert.IsTrue(unitNo.Contains("Unit "),"Unit no. incorrect");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard");
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
        [WorkItem(20544)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDashboardLinkedWithSectionedContent()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "NonSectionedTask");
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                string GradeNo = taskInfo.Grade.ToString();
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.NavigateToMyDashboard();
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                //DashboardCommonMethods.ClickOnDashBoardStartUnitStudent(secInfo.AdditionalInfo);

                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);

                NavigationCommonMethods.ClickLessonBrowserBackButton();
                string NewGrade = DashboardCommonMethods.GetTextOfBackToParentButton();
                Assert.IsTrue(NewGrade.Contains(GradeNo), "Gradeno and New Grade are equal");
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
        [WorkItem(22716)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardHighestGradeFirst()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo secInfoFirst = Login.GetLogin("Sec9Apatton").GetTaskInfo("ELA", "Grade12");
                TaskInfo secInfoSecond = Login.GetLogin("Sec9Apatton").GetTaskInfo("ELA", "Grade9");

                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not present");
                //int GradeOne = DashboardCommonMethods.GetTextOfSectionedGrade(2);
                //int SectionFirst = DashboardCommonMethods.GetTextOfSectionFirst();
                //int SectionSecond = DashboardCommonMethods.GetTextOfSectionSecond();

                

                //LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                //LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                //int GradeSecond = DashboardCommonMethods.GetTextOfSecondSectionedGrade();
                Assert.IsTrue(DashboardCommonMethods.VerifySectionTilesInOrderDescending(secInfoSecond.AdditionalInfo), "Section tiles does not appear in order, highest Unit first");
               // Assert.IsTrue(SectionFirst < SectionSecond, "Section tiles does not appear in ascending Section Number");
                //LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                //LessonBrowserCommonMethods.SwipeLessonPreviewRight();
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
        [TestCategory("DashboardTests")]
        [WorkItem(22761)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentMTEAndCCUserDirectedToSpecificWebpageRelevantToLastViewedLesson()
        {
            try
            {
                Login login = Login.GetLogin("Student1");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                string UnitTitleELA = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreButtonStudent(), "More to explore button not found");
                DashboardCommonMethods.ClickMoreToExploreButtonStudent();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                //string UnitTitleMTE = DashboardCommonMethods.GetMoreToExploreUnitTitle();
                //Assert.AreEqual(UnitTitleELA, UnitTitleMTE,"Unit Title in MTE not specific to last viewed lesson");
                DashboardCommonMethods.ClickOnCloseButton();
                taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit);
                string UnitTitleMath = DashboardCommonMethods.GetLessonBrowserPageTitle();
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerButtonStudent(), "Concept Corner button not found");
                DashboardCommonMethods.ClickConceptCornerButtonStudent();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept Corner is not opened");
                //string UnitTitleCC = DashboardCommonMethods.GetConceptCornerUnitTitle();
                //Assert.AreEqual(UnitTitleMath, UnitTitleCC, "Unit Title in MTE not specific to last viewed lesson");
                DashboardCommonMethods.ClickOnCloseButton();
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
        [TestCategory("DashboardTests")]
        [WorkItem(22762)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentMTEAndCCIfNoLastViewedLessonUserGetsToTheRelevantSiteHomepage()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                string GradeELA = DashboardCommonMethods.GetGradeNumber("ELA");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dahboard Not found");
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreButtonStudent(), "More to explore button not found");
                DashboardCommonMethods.ClickMoreToExploreButtonStudent();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More to explore not opened");
                //string Grade = DashboardCommonMethods.GetMoreToExploreGrade();
                //Assert.AreEqual(GradeELA, Grade, "Unit Title in MTE not specific to last viewed lesson");
                DashboardCommonMethods.ClickOnCloseButton();
                taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit);
                string GradeMath = DashboardCommonMethods.GetGradeNumber("Math");
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerButtonStudent(), "Concept Corner button not found");
                DashboardCommonMethods.ClickConceptCornerButtonStudent();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept Corner is not opened");
                //string Grade1 = DashboardCommonMethods.GetConceptCornerUnitTitle();
                //Assert.AreEqual(GradeMath, Grade1, "Unit Title in MTE not specific to last viewed lesson");
                DashboardCommonMethods.ClickOnCloseButton();
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
        [WorkItem(20726)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLinkstoRecentlyUsedContents()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                
                TaskInfo secInfo = Login.GetLogin("Sec9Apatton").GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                string ELALessonTitle = NotebookCommonMethods.GetTaskTitleInTaskPage();
                taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                string MathLessonTitle = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("Student1");
                NavigationCommonMethods.LoginApp(login1);
                taskInfo = login1.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.Logout();

                Login login2 = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo1 = login2.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login2);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                        NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo1.Lesson);
                string elaTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo1.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickMathStartUnitInDashboard();
                if (LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                        NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo1.Lesson);
                string mathTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo1.Lesson);
                NavigationCommonMethods.NavigateMyDashboard();
                //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                string elaTaskTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo1.Lesson);
                Assert.AreEqual(elaTaskTitle, elaTaskTitle1, "Task Titles are not similar");
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickMathContinueLessonInDashboard();
                string mathTaskTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo1.Lesson);
                Assert.AreEqual(mathTaskTitle, mathTaskTitle1, "Task Titles are not similar");
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
        [WorkItem(22109)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherLinkstoRecentlyUsedContents()
        {
           
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(secInfo.AdditionalInfo), "Start unit not found");
                    DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                    string UnitTitle = DashboardCommonMethods.GetLessonBrowserPageTitle();
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                    NavigationCommonMethods.NavigateToMath();
                    NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                    NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                    NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit);
                    NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                    NavigationCommonMethods.Logout();

                    Login login1 = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login1);
                    taskInfo = login1.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateToMyDashboard();
                    Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(secInfo.AdditionalInfo), "Start unit not found");
                    DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                    NavigationCommonMethods.ClickLessonBrowserBackButton();
                    NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                    NavigationCommonMethods.Logout();

                    NavigationCommonMethods.LoginApp(login);
                    TaskInfo taskInfo1 = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.NavigateMyDashboard();
                    //DashboardCommonMethods.ClickOnDashBoardContinueLesson();
                    DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
                    NavigationCommonMethods.ClickLessonBrowserBackButton();
                    string UnitTitle2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
                    Assert.AreEqual<string>(UnitTitle, UnitTitle2, "Unit Title and UnitTitle2 Are not equal");
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
        ////[TestCategory("DashboardTests")]
        ////[WorkItem(22111)]
        ////[Priority(3)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void TeacherLinkedLessonRemovedImageLinkingStartUnit()
        ////{
        ////    try
        ////    {

        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateMyDashboard();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
        ////        NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
        ////        string ELAUnitTitle = DashboardCommonMethods.GetLessonBrowserPageTitle();
        ////        NavigationCommonMethods.NavigateToMyDashboard();
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(secInfo.AdditionalInfo), "Start unit not found");
        ////        DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
        ////        string ELAUnitTitle1 = DashboardCommonMethods.GetLessonBrowserPageTitle();
        ////        NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
        ////        string ELALessonTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
        ////        NavigationCommonMethods.NavigateToMyDashboard();
        ////        DashboardCommonMethods.ClickOnDashBoardContinueLesson();
        ////        string ELALessonTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
        ////        Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle1, "ELA Unit Title are not equal");
        ////        Assert.AreEqual<string>(ELALessonTitle, ELALessonTitle1, "Math Lesson Title are not equal");
        ////        NavigationCommonMethods.Logout();

        ////        Login login1 = Login.GetLogin("GustadMody");
        ////        NavigationCommonMethods.LoginApp(login1);
        ////        taskInfo = login1.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.RemoveGrade(9);
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectGrade(9);
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.WaitForGradeDownloading();
        ////        NavigationCommonMethods.Logout();

        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToMyDashboard();
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "dashboard not found");
        ////        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
        ////        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
        ////        DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
        ////        string ELAUnitTitle2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
        ////        Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle2, "ELA Unit Title are not equal after add and remove grade");
        ////        LessonBrowserCommonMethods.SwipeLessonPreviewRight();
        ////        LessonBrowserCommonMethods.SwipeLessonPreviewRight();
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

        ////[TestMethod()]
        ////[TestCategory("DashboardTests")]
        ////[WorkItem(20546)]
        ////[Priority(3)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void StudentLinkedLessonRemovedImageLinkingStartUnit()
        ////{
        ////    try
        ////    {

        ////        Login login = Login.GetLogin("StudentBruceSec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
        ////        string ELAUnitTitle = DashboardCommonMethods.GetLessonBrowserPageTitle();
        ////        NavigationCommonMethods.NavigateToMyDashboard();
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
        ////        DashboardCommonMethods.ClickOnDashBoardStartUnit(taskInfo.AdditionalInfo);
        ////        string ELAUnitTitle1 = DashboardCommonMethods.GetLessonBrowserPageTitle();
        ////        NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
        ////        string ELALessonTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
        ////        NavigationCommonMethods.NavigateToMyDashboard();
        ////        DashboardCommonMethods.ClickOnDashBoardContinueLesson(taskInfo.AdditionalInfo);
        ////        string ELALessonTitle1 = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
        ////        Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle1, "ELA Unit Title are not equal");
        ////        Assert.AreEqual<string>(ELALessonTitle, ELALessonTitle1, "Math Lesson Title are not equal");
        ////        NavigationCommonMethods.Logout();

        ////        Login login1 = Login.GetLogin("GustadMody");
        ////        NavigationCommonMethods.LoginApp(login1);
        ////        taskInfo = login1.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.RemoveGrade(9);
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectGrade(9);
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.WaitForGradeDownloading();
        ////        NavigationCommonMethods.Logout();

        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToMyDashboard();
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "dashboard not found");
        ////        Assert.IsTrue(DashboardCommonMethods.VerifyStartUnitInDashboard(taskInfo.AdditionalInfo), "Start unit not found");
        ////        TaskInfo secInfo = Login.GetLogin("Sec9Apatton").GetTaskInfo("ELA", "Grade9");
        ////        DashboardCommonMethods.ClickOnDashBoardStartUnit(secInfo.AdditionalInfo);
        ////        string ELAUnitTitle2 = DashboardCommonMethods.GetLessonBrowserPageTitle();
        ////        Assert.AreEqual<string>(ELAUnitTitle, ELAUnitTitle2, "ELA Unit Title are not equal after add and remove grade");
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
        [TestCategory("DashboardTests")]
        [WorkItem(22149)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherProperBehaviorInitialLogin()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(taskInfo.Grade), "Default grade not in highlited state");
                NavigationCommonMethods.WaitForGradeDownloading();
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
