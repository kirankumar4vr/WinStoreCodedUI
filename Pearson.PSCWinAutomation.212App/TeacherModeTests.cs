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
    /// Summary description for TeacherModeTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class TeacherModeTests
    {
        public TeacherModeTests()
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(23939)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherTapsAnywhereInTheAppFlyOutClosesOff()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode Fly out not opened");
                NotebookCommonMethods.TapOnScreen(500, 500);
                Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teaceh mode opened");
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(23936)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void FlyOutMenuDisplaysWhenTeacherTapsOnTeacherGuideIcon()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode Fly out not opened");
                NotebookCommonMethods.TapOnScreen(500, 500);
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
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(23938)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void FlyOutMenuDisplaysWithUnitOverviewLessonOverviewTaskGuide()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenus(), "Teacher Mode Fly Out Menus not present");
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenus(), "Teacher Mode Fly Out Menus not present");
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyOutMenus(), "Teacher Mode Fly Out Menus not present");
                NotebookCommonMethods.TapOnScreen(500, 500);
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
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(23937)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void FlyOutMenuDisplaysWithTeacherGuideHeader()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode Fly out Is not opened  and doesn't have teacher guide header");
                NotebookCommonMethods.TapOnScreen(500, 500);
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
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(25097)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TaskNotesBoxNotVisibleForStudents()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideIcon(), "TeacherGuideIcon is still Present");
                Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode Is opened");
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(21736)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenopennotebookinalessonThenteachermodegetsclosed()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "No Teacher Mode Icon");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                NotebookCommonMethods.TapOnScreen(500, 330);
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "NoteBook Not open");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode opened");
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(21740)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenopenaGalleryProblemThenteachermodestaysopened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "No Teacher Mode Icon");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                LessonBrowserCommonMethods.OpenGalleryProblemTeacherModeOpened(taskInfo.TaskNumber);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemPage(), "GalleryProblem Page is Not Open");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                LessonBrowserCommonMethods.ClickOnCloseCloseButton();
                NavigationCommonMethods.ClickOnTeacherModeIcon();
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
        [TestCategory("TeacherModeTests")]
        [Priority(1)]
        [WorkItem(21741)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenIopenaChallengeProblemThenTeachermodestaysopened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("Math", "ChallengeProblem");

                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "No Teacher Mode Icon");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(taskinfo.TaskNumber), "Challenge problem button not found");
                NavigationCommonMethods.ClickChallengeProblem(taskinfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
                NavigationCommonMethods.ClickOnTeacherModeIcon();
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
        [TestCategory("TeacherModeTests")]
        [WorkItem(21738)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GivenTeacherModeIsOpenedWhenOpenAVideoTeacherModeStaysOpened()
        {
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToELA();
                    NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                    NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                    NavigationCommonMethods.ClickOnTeacherModeIcon();
                    Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(), "Video Not opened");
                    LessonBrowserCommonMethods.ClickToCloseVideo();
                    Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser Page Is Not Available");
                    //NavigationCommonMethods.ClickToCloseTeacherMode();
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

        [TestMethod()]
        [TestCategory("TeacherModeTests")]
        [WorkItem(23925)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeachermodeisavailablewhentheteacherexittheTeachermodefromInteractive()
        {

            try
            {
                //Login login = Login.GetLogin("Sec9Apatton");
                //NavigationCommonMethods.LoginApp(login);
                //TaskInfo taskinfo = login.GetTaskInfo("Math", "ChallengeProblem");
                //NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskinfo);
                //Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "teacher mode icon not found");
                //NavigationCommonMethods.ClickOnTeacherModeIcon();
                //Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                //NavigationCommonMethods.ClickOnInteractive(taskinfo.TaskNumber);
                //Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is closed");
                //Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                //NavigationCommonMethods.ClickOnTeacherModeIcon();
                //Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode is opened");
                //InteractiveCommonMethods.ClickOnInteractiveDoneButton();
                //NavigationCommonMethods.Logout();

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher mode not opened");
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTaskTeacherModeOpened(taskInfo.TaskNumber);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher mode not opened");
                Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive not opened");
                InteractiveCommonMethods.ClickOnInteractiveDoneButton();
                NavigationCommonMethods.ClickOnTeacherModeIcon();
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
        [TestCategory("TeacherModeTests")]
        [Priority(3)]
        [WorkItem(21760)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TeacherModeIsSupportedOnFollowingLocations()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is not opened");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is still opened");
                NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is not opened");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is still opened");
                NavigationCommonMethods.ClickMathLessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is not opened");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is still opened");
                NavigationCommonMethods.ClickStartInMathLessonPreview(taskInfo.Lesson);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is not opened");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode Is still opened");
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(22432)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentDetailPage()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                DashboardCommonMethods.SwipeLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class roster not found");
                DashboardCommonMethods.ClickClassRosterInDashboard(secInfo.AdditionalInfo);
                Assert.IsTrue(TeacherModeCommonMethods.VerifyClassRosterOpened(), "Class roster not opened");
                TeacherModeCommonMethods.ClickStudentTileInClassRoster(1);
                Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(), "student information not found");
                Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationControls(), "student infromation controls not found");
                LessonBrowserCommonMethods.ClickBackButton();
                Assert.IsFalse(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(), "student information still found");
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(22430)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ClassRosterPage()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo secInfo = login.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                DashboardCommonMethods.SwipeLeft();
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterInDashboard(secInfo.AdditionalInfo), "Class roster not found");
                DashboardCommonMethods.ClickClassRosterInDashboard(secInfo.AdditionalInfo);
                NavigationCommonMethods.ClickMyDashboardBackButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User is not on dashboard");
                DashboardCommonMethods.SwipeLeft();
                DashboardCommonMethods.ClickClassRosterInDashboard(secInfo.AdditionalInfo);
                Assert.IsTrue(TeacherModeCommonMethods.VerifyClassRosterOpened(), "Class roster not opened");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterPageHeader(secInfo.AdditionalInfo), "Class roster page controls not verified");
                Assert.IsTrue(DashboardCommonMethods.VerifyClassRosterStudentNameAndAvatar(1), "Class roster student name tile and avatar controls not verified");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                TeacherModeCommonMethods.ClickStudentTileInClassRoster(1);
                Assert.IsTrue(TeacherModeCommonMethods.VerifyStudentInformationControls(), "student infromation cotrols not found");
                NavigationCommonMethods.ClickBackButtonInLessonPage();
                Assert.IsFalse(TeacherModeCommonMethods.VerifyStudentInformationRosterOpened(), "student information still found");
                NavigationCommonMethods.ClickMyDashboardBackButton();
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
        [TestCategory("TeacherModeTests")]
        [Priority(2)]
        [WorkItem(33956)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenTeacherGuideUnavailableThenAlertSayingContentUnavailable()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                // TeacherModeCommonMethods.ClickUnitOverview();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyContentUnavailable(), "Content Unavailable are not found ");
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
