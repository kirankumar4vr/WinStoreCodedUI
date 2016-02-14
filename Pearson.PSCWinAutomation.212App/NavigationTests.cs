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
    /// Summary description for NavigationTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class NavigationTests
    {
        public NavigationTests()
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
        [TestCategory("NavigationTests")]
        [Priority(2)]
        [WorkItem(16044)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AddImageForLogOutButtonInSystemTraySectionTeacher()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyLogoutButton(), "Logout Button not found");
                NavigationCommonMethods.ClickOnSystemTrayClose();
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
        [WorkItem(16047)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AddImageForLogOutButtonInSystemTrayStudent()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyLogoutButton(), "Logout Button not found");
                NavigationCommonMethods.ClickOnSystemTrayClose();
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
        [WorkItem(16043)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionTeacherUpdateContentButtonImageInSystemTray()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerButton(), "Content Manager Button Not found");
                NavigationCommonMethods.ClickOnSystemTrayClose();

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
        [WorkItem(16042)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NonSectionTeacherUpdateContentButtonImageInSystemTray()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("GustadMody"));
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryButton(), "Unit Library Button Not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerButton(), "Content Manager Button Not found");
                NavigationCommonMethods.ClickOnSystemTrayClose();
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
        [WorkItem(19380)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GlobalNavigationOpenToolsGamesIconAsStudent()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(NavigationCommonMethods.VerifyGamesAndToolsSubMenuMenu(), "Game and Tools sub Menu not found");
               // Assert.IsTrue(NavigationCommonMethods.VerifySubMenuContainsAinAnd(), "A not found in And word not found");
                NavigationCommonMethods.ClickOnToolsIcon();
                //Assert.IsTrue(NavigationCommonMethods.VerifySnapshotToolButton(), "Snapshot Icon not found");
                AutomationAgent.Click(100, 700);
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
        [WorkItem(19398)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GlobalNavigationOpenToolsGamesIconAsTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(NavigationCommonMethods.VerifyGamesAndToolsSubMenuMenu(), "Game and Tools sub Menu not found");
               // Assert.IsTrue(NavigationCommonMethods.VerifySubMenuContainsAinAnd(), "A not found in And word not found");
                NavigationCommonMethods.ClickOnToolsIcon();
               // Assert.IsTrue(NavigationCommonMethods.VerifySnapshotToolButton(), "Snapshot Icon not found");
                AutomationAgent.Click(100, 700);
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
        [WorkItem(19418)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GlobalNavigationOpenToolsGamesIconWithinLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(NavigationCommonMethods.VerifyGamesAndToolsSubMenuMenu(), "Game and Tools sub Menu not found");
                AutomationAgent.Click(100, 700);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(NavigationCommonMethods.VerifyGamesAndToolsSubMenuMenu(), "Game and Tools sub Menu not found");
               // Assert.IsTrue(NavigationCommonMethods.VerifySubMenuContainsAinAnd(), "A not found in And word not found");
                //NavigationCommonMethods.ClickOnToolsIcon();
                //Assert.IsTrue(NavigationCommonMethods.VerifySnapshotToolButton(), "Snapshot Icon not found");
                AutomationAgent.Click(100, 700);
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
        [WorkItem(20028)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeIconDisplaysForTheFollowingLocations()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);


                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not Present");
                NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not Present");
                NavigationCommonMethods.ClickMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not Present");
                NavigationCommonMethods.ClickStartInMathLessonPreview(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not Present");
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
        [WorkItem(16070)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GlobalNavigationVerifyChromeIconSetForSectionedTeacher()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                Assert.IsTrue(NavigationCommonMethods.VerifyChromeIconSetInMathTeacher(), "Chrome Icon can not be verified for MathTeacher");

                TaskInfo taskInfo1 = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo1);
                //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(9, 1, 1, 2);
                Assert.IsTrue(NavigationCommonMethods.VerifyChromeIconSetInELATeacher(), "Chrome Icon can not be verified for ELATeacher");
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
        [WorkItem(16069)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GlobalNavigationVerifyChromeIconSetForSectionedStudent()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                Assert.IsTrue(NavigationCommonMethods.VerifyChromeIconSetInMathStudent(), "Chrome Icon can't be verified for Math");
                TaskInfo taskInfo1 = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo1);
                Assert.IsTrue(NavigationCommonMethods.VerifyChromeIconSetInELAStudent(), "Chrome Icon can't be verified for ELA");
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
        //[TestCategory("NavigationTests")]
        //[WorkItem(20026)]
        //[Priority(1)]
        //[Owner("Madhav Purohit(madhav.purohit)")]
        //public void TeacherMode3SectionsAreUnitOverviewAboutThisLessonTeacherGuide()
        //{
        //    try
        //    {
        //        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        //        NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(9, 1, 1, 2);
        //        NavigationCommonMethods.ClickOnTeacherModeIcon();
        //        Assert.IsTrue(NavigationCommonMethods.VerifyTeacherGuideExpands(), "Teacher Mode Not Expanded");
        //        Assert.IsTrue(NavigationCommonMethods.VerifyUnitOverviewCollapse(), "Unit Library not collapsed");
        //        Assert.IsTrue(NavigationCommonMethods.VerifyAboutThisLessonCollapse(), "About this lesson not collapsed");
        //        //NavigationCommonMethods.ClickOnUnitOverviewInTeacherMode();
        //        //Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyUnitOverviewExpands());
        //        //NavigationCommonMethods.ClickOnAboutThisLessonInTeacherMode();
        //        //Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyAboutThisLessonExpands());
        //        //NavigationCommonMethods.Logout(navigationAutomationAgent);
        //    }
        //    catch (AssertFailedException Ex)
        //    {
        //        string msg = Ex.Message;
        //        Logger.InsertExceptionMessage(msg);
        //        throw;
        //    }
        //    catch (Exception Ex)
        //    {
        //        string msg = Ex.Message;
        //        Logger.InsertExceptionMessage(msg);
        //        throw;
        //    }
        //}





        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16045)]
        [Priority(1)]
        [Owner("Kiran Anantapalli(Kiran.Anantapalli)")]
        public void VerifyNonSectionedTeacherAccessingUnitLibrary()
        {
            try
            {
                Login login = Login.GetLogin("Grade2Sswanson2");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookOpen();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Content grid is not available");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitTileButton(taskInfo.Unit), "Unit 1 Tile button is not available");
                NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                NavigationCommonMethods.Logout();
                throw;
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                NavigationCommonMethods.Logout();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(16049)]
        [Priority(1)]
        [Owner("Kiran Anantapalli(Kiran.Anantapalli)")]
        public void VerifyNonSectionedTeacherAccessingUnitLibraryFromLesson()
        {
            try
            {
                Login login = Login.GetLogin("Grade2Sswanson2");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Content grid is not available");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitTileButton(taskInfo.Unit), "Unit 1 Tile button is not available");
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
        [WorkItem(16050)]
        [Priority(1)]
        [Owner("Kiran Anantapalli(Kiran.Anantapalli)")]
        public void VerifySectionedTeacherAccessingUnitLibrary()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyMathUnitLibraryButtonExists(), "Math Unit Library Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyElaUnitLibraryButtonExists(), "ELA Unit Library Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyMyDashboardButtonExists(), "My Dashboard Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserButtonExists(), "Work Browser Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportButtonExists(), "Teacher Support Button does not exist");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Content grid is not available");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitTileButton(taskInfo.Unit), "Unit 1 Tile button is not available");
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
        [WorkItem(16051)]
        [Priority(1)]
        [Owner("Kiran Anantapalli(Kiran.Anantapalli)")]
        public void VerifySectionedTeacherAccessingUnitLibraryFromLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyMathUnitLibraryButtonExists(), "Math Unit Library Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyElaUnitLibraryButtonExists(), "ELA Unit Library Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyMyDashboardButtonExists(), "My Dashboard Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserButtonExists(), "Work Browser Button does not exist");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportButtonExists(), "Teacher Support Button does not exist");

                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Content grid is not available");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitTileButton(taskInfo.Unit), "Unit 1 Tile button is not available");
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
        [WorkItem(16052)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionTeacherPort3SystemTray()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.VerifySystemTrayOpen();
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA page not opened");
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(NavigationCommonMethods.VerifyMathPage(), "Math page not opened");
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Not opened");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.ClickTeacherSupportButtonInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher support page not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager not opened");
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginButtonAvailable(), "Login button not found");
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
        [WorkItem(19066)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionStudentPort3SystemTray()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System tray not opened");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA page not opened");
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(NavigationCommonMethods.VerifyMathPage(), "Math page not opened");
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Not opened");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager not opened");
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginButtonAvailable(), "Login button not found");
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
        [WorkItem(16088)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ThreeStatesForCoursePackageDownloadCompleted()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Content grid is not available");
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.UnitThumbnailWithUnitNameInDashboard(taskInfo.Grade), "Unit Thumbnail for grade 9 not found");
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
        [Priority(2)]
        [WorkItem(20440)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenUnitXThumbnailIsTappedAndSwipedAndOpenedUnitYThenBackSendsUsToUnitYPreviewCard()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(taskinfo.Unit), "Unit Preview card not found for 2 Unit");
                NavigationCommonMethods.ClickUnitPreviewCard(taskinfo.Unit+1);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskinfo.Unit+1);
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(taskinfo.Unit+1), "Unit Preview card not found for 3 Unit");
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
        [WorkItem(15864), WorkItem(46746)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SwipeLetfRightOnTheUnitPreviewScreenWhenThereAreMoreContentToBeDisplayed()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.AreEqual<bool>(true, NavigationCommonMethods.VerifyUnitPreviewCard(taskinfo.Unit), "Unit Preview card not found for 2 Unit");
                Assert.IsTrue(NavigationCommonMethods.VerifyMoreUnitsCardDisplayed(taskinfo.Unit+1), "More Units card is not displayed");
                NavigationCommonMethods.SwipeUnitNavigate(taskinfo.Unit+1);
                Assert.IsTrue(NavigationCommonMethods.VerifyEdgeOfNextUnitCardDisplayed(taskinfo.Unit+1), "EdgeOfNextUnit card is not displayed ");
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
        [Priority(2)]
        [WorkItem(20039)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitXThumbnailIsTappedUnitXPreviewCardOpened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewCard(taskinfo.Unit), "Unit Preview card not found for 2 Unit");
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
        [WorkItem(21827)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserViewsButtonSystemTrayContentManager()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerButton(), "Content Manager Button Not found");
                NavigationCommonMethods.ClickOnSystemTrayClose();
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
        [WorkItem(21829)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContentManagerButtonTakesUserContentManagerScreen()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                AutomationAgent.Wait();
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerButton(), "Content Manager Button Not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager Page not found");
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

       // [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15891)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void lessondownloadprogressprogressbaroverthumbnailpreviewnotopen()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade+2);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson), "ProgessBar Not Found");
                Assert.IsFalse(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
               // LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson + 1);
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
        [WorkItem(16111)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void UnitLibraryLowestGradeOnDeviceDefaultGradeShownInHighlightedState()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                //LoginCommonMethods.VerifyLoggingInSpinner();
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryButton(), "UnitLibraryButton is not founnd");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(taskinfo.Grade), "Grade in HighlightedState  is not found");
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
        [WorkItem(22376)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void AccesstoAllUnitspageforsectioned()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "SystemTray Not Open");
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayIcons(), "System Tray Icons Not Found");
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(NavigationCommonMethods.VerifyMathPage(), "Math Page not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "UnitLibrary Not Found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA Page not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "UnitLibrary Not Found");
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

        //[TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(31231)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Lessondownloadinprogressprogressbaroverthumbnailpreviewnotopen()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit + 1);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson), "ProgessBar Not Found");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson);
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
        [Priority(2)]
        [WorkItem(16046)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AddImageLogOutButtonInSystemTraySectionTeacher()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyLogoutButton(), "Logout Button not found");
                NavigationCommonMethods.ClickOnSystemTrayClose();
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
        [WorkItem(25838)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsNotVisibleForStudents()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");
                
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Present");
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskinfo.Unit);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Present");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskinfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Present");
                NavigationCommonMethods.ClickELALessonContinueButton(taskinfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Present");
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
        [WorkItem(16091)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void UnitLibraryChromeTitlesAreELAUnitsAndMathUnits()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryTitleELAUnits(), "UnitLibrary Title is not ELA Units");
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryTitleMathUnits(), "UnitLibrary Title is not Math Units");
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
        [WorkItem(20038)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void UnitPreviewNavigationIconsShouldBeVisibleToolsNotificationTeacherMode()
        {

            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationIcons(), "UnitPreview Navigation Icons are not Available");
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyNavigationIcons(), "UnitPreview Navigation Icons are not Availale");
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
        [WorkItem(16092)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void NoBackButtonOnUnitLibrary()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "Back Button is not found in unit library");
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                Assert.IsFalse(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "Back Button is found in unit library");
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.NavigateToMath();
                TaskInfo taskinfo1 = login.GetTaskInfo("Math", "ChallengeProblem");

                AutomationAgent.Wait(500);
                NavigationCommonMethods.NavigateToMathGrade(taskinfo1.Grade);
                NavigationCommonMethods.ClickMathUnit(taskinfo1.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "Back Button is not found in unit library");
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                Assert.IsFalse(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "Back Button is found in unit library");
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
        [WorkItem(16113)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DisplayWithUnitNumberTitleImageDescriptionandStartButton()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitNameAndTitleOnUnitPreview(taskInfo.Unit.ToString()), "UnitNameAndTitleOnUnitPreview is not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyStartButtonInUnitPreview(), "StartButtonInUnitPreview is not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewTextContent(), "UnitPreviewTextContent is not found");
                NavigationCommonMethods.NavigateToMath();
                AutomationAgent.Wait(500);
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                //Assert.IsTrue(NavigationCommonMethods.VerifyUnitNameAndTitleOnUnitPreview(), "UnitNameAndTitleOnUnitPreview is not found");
                //Assert.IsTrue(NavigationCommonMethods.VerifyStartButtonInUnitPreview(), "StartButtonInUnitPreview is not found");
                Assert.IsTrue(NavigationCommonMethods.UnitPreviewImageContentMath(), "PreviewImageContentMath is not found");
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
        [WorkItem(16048)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void AccesstoUnitLibrarypagefornonsectionedteacherstask()
        {
            try
            {
                Login login = Login.GetLogin("GustadMody");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System tray not opened");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);                
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Library Page is Not present");
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
        [WorkItem(16112)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitPreviewCarouselAllUnitsAreDisplayedInAscendingOrder()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewUnitsAreInOrder(), "Units in Unit Preview are not in ascending order");
                NavigationCommonMethods.NavigateToMath();
                CommonReadCommonMethods.Sleep();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitPreviewUnitsAreInOrder(), "Units in Unit Preview are not in ascending order");
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
        [WorkItem(31820)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UnitLabelsAreUpdatedCorrectly()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                string unitNo = NavigationCommonMethods.GetUnitNameAndTitleOnUnitPreview(taskInfo.Unit);
                Assert.AreEqual(unitNo, "UNIT  " + taskInfo.Unit, "Unit numbers are not similar");
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                unitNo = DashboardCommonMethods.GetLessonBrowserPageTitle();
                Assert.IsTrue(unitNo.Contains("Unit " + taskInfo.Unit + ": "));
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                unitNo = NavigationCommonMethods.GetBackButtonsTextInLessonTaskPage(taskInfo.Unit);
                Assert.AreEqual(unitNo, "Unit " + taskInfo.Unit, "Unit Numbers are not similar");
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
        [WorkItem(24406)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserCanSeeInteractivesGamesPublishedForSpecificGrade()
        {
            try
            {
                int newGrade = 4;
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsFalse(NavigationCommonMethods.VerifyGamesInToolsAndGamesMenu(), "Games Menu still present");
                NotebookCommonMethods.TapOnScreen(600, 40);
                if (!NavigationCommonMethods.VerifyGradePersent(newGrade))
                {
                    LessonBrowserCommonMethods.AddSpecificGrade(newGrade);
                    NavigationCommonMethods.NavigateToELAGrade(newGrade);
                    LessonBrowserCommonMethods.WaitForGradeToDownload();
                }
                NavigationCommonMethods.NavigateToELAGrade(newGrade);
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(NavigationCommonMethods.VerifyGamesInToolsAndGamesMenu(), "Games Menu Not present");
                NavigationCommonMethods.ClickGamesInToolsAndGamesMenu();
                Assert.IsTrue(NavigationCommonMethods.VerifyGrade4BlobBusterMenu(), "Blob Buster Text not similar");
                NotebookCommonMethods.TapOnScreen(600, 40);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                NavigationCommonMethods.ClickLessonBrowserBackButton();
                LessonBrowserCommonMethods.RemoveGrade();
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
        [WorkItem(15875)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ReturningToViewedEpisodeWhileUserExitingLessonByTappingReturnNavigationButton()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                NavigationCommonMethods.StartELANextEpisodeLesson(taskInfo.Lesson + 6);
                NavigationCommonMethods.ClickBackButtonInLessonPage();
                Assert.IsTrue(NavigationCommonMethods.VerifyNextEpisodeLessonPresent(taskInfo.Lesson + 6));
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
        [WorkItem(20040)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StartIsGreenForMathAndBlueForELA()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Color sampleColor = Color.FromArgb(255, 0, 50, 195);
                Assert.IsTrue(NavigationCommonMethods.VerifyElAStartButtonColor(sampleColor, taskInfo.Unit), "ELA start button is not blue");
                LessonBrowserCommonMethods.ClickBackButton();
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                Color sampleColor1 = Color.FromArgb(255, 30, 120, 40);
                Assert.IsTrue(NavigationCommonMethods.VerifyMathStartButtonColor(sampleColor1, taskInfo.Unit), "Math start button is not green");
                LessonBrowserCommonMethods.ClickBackButton();
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
        [WorkItem(20042)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitLibraryUnitsScrollablIfThereAreMoreThan8Units()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                Assert.IsTrue(NavigationCommonMethods.VerifyMoreThanEightUnitInUnitLibrary(), "More Than Eight Units Are Not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitTileVisible(taskInfo.Unit), "Unit Tile not visible");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsFalse(NavigationCommonMethods.VerifyUnitTileVisible(taskInfo.Unit), "Unit Tile not visible");
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitTileVisible(taskInfo.Unit), "Unit Tile not visible");
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
        [WorkItem(20152)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SectionTeacherShowSharedHistoryIconInEveryScreen()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard");
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Notification icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(NavigationCommonMethods.VerifyListOfSharedItemsInNotification());
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Notification icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(NavigationCommonMethods.VerifyListOfSharedItemsInNotification());
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Notification icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(NavigationCommonMethods.VerifyListOfSharedItemsInNotification());
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Notification icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(NavigationCommonMethods.VerifyListOfSharedItemsInNotification());
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Notification icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(NavigationCommonMethods.VerifyListOfSharedItemsInNotification());
                NotebookCommonMethods.TapOnScreen(500, 500);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                NotebookCommonMethods.TapOnScreen(519, 63);
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                WorkBrowserCommonMethods.ClickOnViewInLessonButton();
                Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Notification icon not present");
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                Assert.IsTrue(NavigationCommonMethods.VerifyListOfSharedItemsInNotification());
                NotebookCommonMethods.TapOnScreen(500, 500);
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
        [WorkItem(15865)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void AppChromeScreenTitleCorrectUnitPreviewGradeXMathOrELA()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo elaInfo = login.GetTaskInfo("ELA", "Notebook");
                TaskInfo mathInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(elaInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(elaInfo.Unit);
                string screenTitle = NavigationCommonMethods.GetScreenTitleLabel(elaInfo.Unit);
                Assert.AreEqual(screenTitle, "Grade " + elaInfo.Grade + " " + elaInfo.SubjectName);
                NavigationCommonMethods.NavigateToMathGrade(mathInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(mathInfo.Unit);
                string screenTitle1 = NavigationCommonMethods.GetScreenTitleLabel(elaInfo.Unit);
                Assert.AreEqual(screenTitle1, "Grade " + mathInfo.Grade + " " + mathInfo.SubjectName);
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
        [WorkItem(15874)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void IfBrowsedGradeXContentReturnToUnitLibraryGradeXUsingBackButtons()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo elaInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(elaInfo);
                NavigationCommonMethods.GoToParentTillAvailable();
                Assert.IsTrue(NavigationCommonMethods.VerifyDefaultGradeInHighlightedState(elaInfo.Grade), "Specified Grade is not higlighted/Selected");
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



        /*Network dependent*/

        #region NetworkDependent

        ////[TestMethod()]
        ////[TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        ////[WorkItem(20098)]
        ////[Priority(2)]
        ////[Owner("Akanksha Gautam(akanksha.gautam)")]
        ////public void QueueDownloadIndicatorIsVisibleForGradesQueued()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeX = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeY = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeY);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnitsProgressSinner(), "Preparing Units text not present");
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeX);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyWaitingToDownloadProgressSinner(), "Waiting To Download text not present");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15974)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void IfUsedAddedMultipleGradesTheNewGradesWillBeginTheCourseLevelPackageDownload()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int SelectedGrade1 = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int SelectedGrade2 = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        NavigationCommonMethods.NavigateToELAGrade(SelectedGrade1);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
        ////        NavigationCommonMethods.NavigateToELAGrade(SelectedGrade2);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}


        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(16090)]
        ////[Priority(2)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void GradesontheribbonareclickableandGethighlighted()
        ////{

        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToMath();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "CheckAndUncheckGrades is not found");
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeCancelButtonEnabled(), "AddGradeCancelButton is not Enable");
        ////        int SelectedGrade1 = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int SelectedGrade2 = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(SelectedGrade1), "Unit is Not Present");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(SelectedGrade2), "Unit is Not Present");
        ////        NavigationCommonMethods.NavigateToELAGrade(SelectedGrade1);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyGradeButtonActive(SelectedGrade1), "Grade Button not Active");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
        ////        NavigationCommonMethods.NavigateToELAGrade(SelectedGrade2);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyGradeButtonActive(SelectedGrade2), "Grade Button not Active");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Not Unit Download ProgressBar");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15968)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void ZAddGradesDisabledOrNotAppearingWhenAllGradesHaveBeenAdded()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonPresent(), "Add grade button not present");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectAllGradeInELA();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeButtonPresent(), "Add grade button still present");
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}




        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(21756)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ELAMoretoExploreandMATHConceptCorner()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System tray not opened");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExploreButtonTopMenu(), "More To Explore Button Not present");
                NavigationCommonMethods.ClickMoreToExploreButtonInNavBar();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More To Explore Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System tray not opened");
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerButtonTopMenu(), "Concept corner Button Not present");
                DashboardCommonMethods.ClickConceptCornerIcon();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "concept corner not opened"); ;
                NotebookCommonMethods.ClickOnDoneCloseButton();
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

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(16087)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void RightafterAddinggradesnewgradeappearonthetopRibbonoftheUnitLibrary()
        ////{

        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToMath();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "CheckAndUncheckGrades is not found");
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeCancelButtonEnabled(), "AddGradeCancelButton is not Enable");
        ////        int SelectedLesson = LessonBrowserCommonMethods.SelectGrade();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(SelectedLesson), "Unit is Not Present");
        ////        NavigationCommonMethods.Logout();


        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}


        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15972)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void AfterSelectingAnyGradeTheUserWillSeeNewGradeOnTopRibbonOfUnitLibrary()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeAdded = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(gradeAdded), "Specified grade not present");
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}



        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15978)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void WhenCoursePackageDownloadedThenAllUnitThumbnailsAreVisibleOnUnitLibrary()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int SelectedGrade = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        CommonReadCommonMethods.Sleep();
        ////        NavigationCommonMethods.NavigateToELAGrade(SelectedGrade);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitThumbnails(), "Unit Thumbnails not present");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(16105)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void UnitLibraryRemoveThisGradeButtonIsDisabledForTheFollowing()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive(), "Remove this grade button is active which should not be");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int grade = LessonBrowserCommonMethods.SelectGrade();
        ////        NavigationCommonMethods.NavigateToELAGrade(grade);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyUnitDownloadProgressBar(), "Progress Bar not present");
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive(), "Remove this grade button is active which should not be");
        ////        NavigationCommonMethods.Logout();

        ////        login = Login.GetLogin("GustadMody");
        ////        taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.LoginApp(login);

        ////        NavigationCommonMethods.NavigateToELA();
        ////        while (LessonBrowserCommonMethods.VerifyRemoveGradeButtonPresent())
        ////        {
        ////            if (NavigationCommonMethods.VerifyUnitTileButton(taskInfo.Unit))
        ////            {
        ////                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
        ////                LessonBrowserCommonMethods.ClickOnBackButton();
        ////                LessonBrowserCommonMethods.ClickOnBackButton();
        ////                if (LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive())
        ////                {
        ////                    LessonBrowserCommonMethods.RemoveGrade();
        ////                }
        ////            }

        ////            else if (LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive())
        ////            {
        ////                LessonBrowserCommonMethods.RemoveGrade();
        ////            }
        ////        }
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyRemoveGradeButtonPresent(), "Remove Grade Button still present");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}
        
        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(30096)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void StudentDashboardCCUserIsDirectedToSpecificWebpageRelevantToTheLessonThatIsLastViewedLesson()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NavigationCommonMethods.ClickConceptCornerButtonInNavBar();
                Assert.IsTrue(NavigationCommonMethods.VerifyConceptCornerPageRelevantToLastViewedLesson(), "concept corner not opned as per relevant page");
                NotebookCommonMethods.ClickOnDoneCloseButton();
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
        [WorkItem(30097)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void StudentDashboardMTEUserIsDirectedToSpecificWebpage()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NavigationCommonMethods.NavigateToMyDashboard();
                NavigationCommonMethods.ClickMoreToExploreButtonInDashboard();
                // Assert.IsTrue(NavigationCommonMethods.VerifyMoreToExplorePageRelevantToLastViewedLesson());
                NotebookCommonMethods.ClickOnDoneCloseButton();
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


        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[Priority(2)]
        ////[WorkItem(15970)]
        ////[Owner("Madhav Purohit(madhav.purohit)"), TestCategory("212SmokeTests")]
        ////public void ZAddGradesButtonDisabledWhenNoWifi()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
        ////        AutomationAgent.DisableNetwork();
        ////        AutomationAgent.Wait();
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Active");
        ////        NavigationCommonMethods.Logout();
        ////        AutomationAgent.EnableNetwork();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}
        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15967)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void UserAbleToAddAnyGradeByTappingButton()
        ////{

        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "CheckAndUncheckGrades is not found");
        ////        int GradeNo = LessonBrowserCommonMethods.SelectGrade();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGradeContinueButton is not Enable");
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }

        ////}


        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(15969)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserAbleToSeeGradeSelectionScreen()
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
                LessonBrowserCommonMethods.ClickCancelButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButtonActive is Not Active");
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

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15631)]
        ////[Priority(2)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void ZWifiRequiredOnGradeSelection()
        ////{

        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToMath();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "AddGradeButton Is Not Active");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        AutomationAgent.DisableNetwork();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyNoWiFiPopUp(), "Wifi is available");
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "AddGrade Continue Button is Enabled");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeCancelButtonEnabled(), "AddGrade Cancel Button is not Enabled");
        ////        LessonBrowserCommonMethods.ClickCancelButton();
        ////        AutomationAgent.EnableNetwork();
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }

        ////}




        ////[TestMethod()]
        ////[TestCategory("NavigationTests"), TestCategory("212SmokeTests")]
        ////[WorkItem(15985)]
        ////[Priority(1)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void ZUnitLibraryWhenWiFiOffDuringGradeDownloadThenNoWiFiIconVisible()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int UnitNo = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToMath();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(UnitNo);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        AutomationAgent.DisableNetwork();
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        NavigationCommonMethods.Logout();
        ////        AutomationAgent.EnableNetwork();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15873), WorkItem(46749)]
        ////[Priority(1)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void VerifyRemoveGradeButton()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeAdded = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeAdded);
        ////        while (!LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive())
        ////        {
        ////            AutomationAgent.Wait();
        ////        }
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyRemoveGradeButtonActive(), "Remove grade button inactive");
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
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15971)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void UnitLibraryAddGradesButtonEnabledWhenDownloadInProgress()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeAdded = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeAdded);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonActive(), "Add Grade button inactive");
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
        ////[TestCategory("NavigationTests")]
        ////[Priority(1)]
        ////[WorkItem(22868)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void ThreeStatesForCoursePackageDownloadQueued()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int UnitNo = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToMath();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(UnitNo);
        ////        NavigationCommonMethods.ClickContentManagerButton();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyActivitySpinnerExists(), "Activity Spinner not found");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}


        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[Priority(1)]
        ////[WorkItem(22867)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void ThreeStatesForCoursePackageDownloadInProgress()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int GradeNo = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToMath();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(GradeNo);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}


        [TestMethod()]
        [TestCategory("NavigationTests")]
        [WorkItem(29936)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ELAMoreToExplore()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System tray not opened");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA not opened");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NavigationCommonMethods.ClickMoreToExploreButtonInNavBar();
                Assert.IsTrue(DashboardCommonMethods.VerifyMoreToExploreOpened(), "More To Explore Not Opened");
                DashboardCommonMethods.ClickOnCloseButton();
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
        [WorkItem(29937)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MATHConceptCorner()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.VerifySystemTrayOpen();
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "Dashboard not found");
                NavigationCommonMethods.NavigateToMath();
                Assert.IsTrue(NavigationCommonMethods.VerifyMathPage(), "Math not found");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NavigationCommonMethods.ClickConceptCornerButtonInNavBar();
                Assert.IsTrue(DashboardCommonMethods.VerifyConceptCornerOpened(), "Concept Corner not opened");
                DashboardCommonMethods.ClickOnCloseButton();
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

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(15975), WorkItem(17697)]
        ////[Priority(2)]
        ////[Owner("Akanksha Gautam(akanksha.gautam)")]
        ////public void WhenCoursePackageDownloadInProgressThenSpinnerVisible()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeButtonPresent(), "Add grade button not present");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int grade = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(grade);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        LessonBrowserCommonMethods.WaitForGradeToDownload();
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(16095)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void ZWhenWifiOffAndBackOnThenDownloadResumes()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeNo = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeNo);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        AutomationAgent.DisableNetwork();
        ////        AutomationAgent.LaunchApp();
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        AutomationAgent.EnableNetwork();
        ////        AutomationAgent.LaunchApp();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        NavigationCommonMethods.Logout();
                
        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(20143), WorkItem(20099)]
        ////[Priority(2)]
        ////[Owner("Akanksha Gautam(akanksha.gautam)")]
        ////public void WhenYouAddGradeThenQueuedIndicatorIsShown()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeX = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeX);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyWaitingToDownloadProgressSinner(), "Waiting To Download  not found");
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeY = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeY);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}

        ////[TestMethod()]
        ////[TestCategory("NavigationTests")]
        ////[WorkItem(17698)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void AddingGradesDoesntTriggerLessonDownload()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        int gradeX = LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.NavigateToELAGrade(gradeX);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyWaitingToDownloadProgressSinner(), "Waiting To Download  not found");
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnits(), "Preparing units not found");
        ////        NavigationCommonMethods.WaitForGradeDownloading();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.ClickELAUnitFromUnitLibrary(1);
        ////        NavigationCommonMethods.StartELAUnitInUnitLibrary(1);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(1), "Lesson are downloaded");
        ////        NavigationCommonMethods.Logout();

        ////    }
        ////    catch (AssertFailedException Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        NavigationCommonMethods.Logout();
        ////        throw;
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        string msg = Ex.Message;
        ////        Logger.InsertExceptionMessage(msg);
        ////        throw;
        ////    }
        ////}
        #endregion
    }
}
