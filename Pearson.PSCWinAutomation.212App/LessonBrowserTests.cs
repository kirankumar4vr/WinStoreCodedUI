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
    /// Summary description for LessonBrowserTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class LessonBrowserTests
    {
        public LessonBrowserTests()
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20030)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentVisibleForSectionedTeachers()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not found");
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode not opened");
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(25148)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentVisibleForNonSectionedTeachers()
        {
            try
            {
                Login login = Login.GetLogin("Grade2Sswanson2");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "Notebook");



                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskinfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not found");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode not opened");
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20029)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsNotVisibleForSectionedStudents()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
                NavigationCommonMethods.ClickELALessonContinueButton(taskInfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
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
        [WorkItem(25491)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsNotVisibleForNonSectionedStudents()
        {
            try
            {
               
                Login login = Login.GetLogin("Student1");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
                NavigationCommonMethods.ClickELALessonContinueButton(taskInfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon found");
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
        [WorkItem(19953)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonBrowserChromeItemsForSectionedTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForSectionedTeachers(), "Chrome Icon Not validated");
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
        [WorkItem(26215)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonBrowserChromeItemsForNonSectionedStudent()
        {
            try
            {
                Login login = Login.GetLogin("Student1");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForNonSectionedStudents(), "Chrome icons not found");
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
        [WorkItem(26216)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonBrowserChromeItemsForSectionedStudent()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForSectionedStudents(), "Chrome items not validated");
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
        [WorkItem(26217)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonBrowserChromeItemsForNonSectionedTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Grade2Sswanson2");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserChromeItemsForNonSectionedTeachers(), "Chrome items not validated");
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
        [WorkItem(19362)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StartContinueButtonIsInAvailableStateWhenLessonActive()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(9);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                NavigationCommonMethods.ClickELALessonContinueButton(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELATaskOpen(), "ELA Task Not opened");
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
        [WorkItem(17672), WorkItem(46745)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ViewIntroVideoInLessonBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(), "Video Not opened");
                LessonBrowserCommonMethods.ClickToCloseVideo();
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
        [WorkItem(17674)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenVideoIsCompletedDismissedInLessonBrowserUserIsReturnedToLessonBrowser()
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
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(), "Video Not opened");
                    LessonBrowserCommonMethods.ClickToCloseVideo();
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser episode cell not found");
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(taskInfo.Unit);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyVideoComplete(), "Video not completed");
                    AutomationAgent.Wait(10000);
                    if (!LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                        AutomationAgent.Wait(10000);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser episode cell not found");
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

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20077)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonCarouselShouldNotCoverTheNavigationBar()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon Not found");
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode not opened");
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(16114)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitPreviewStartMovesYouToTheLessonBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser Page Not opened");
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
        [WorkItem(15887)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ConfirmAppChromeTitleCorrectLessonBrowserUnitxUnitName()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserAppChromeTitleContainsUnitNoAndName(1), "Lesson Browser App chrome Title doesnot contain name and number");
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
        [WorkItem(15886)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BackButtonWhenInLessonBrowserIsLabelledGradeXSubjectSubjectInCaps()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserBackButtonTextContainsGradeNoAndName(taskInfo.Grade), "Lesson Browser back button doesnot contain name and number");
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
        [WorkItem(18573)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsVisibleForBothSectionedAndNonSectionedTeachers()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson browser page not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon not present");
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                Assert.IsTrue(TeacherModeCommonMethods.VerifyTeacherModeFlyoutOpen(), "Teacher Mode not opened");
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19059)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherContentIsNotVisibleForStudents()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson browser page not found");
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon present");
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
        [WorkItem(16193)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeIconDisplaysForTheFollowingLocationsUnitPreviewLessonBrowserLessonPreviewLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon not present");
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.VerifyLessonBrowserPage();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon not present");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon not present");
                NavigationCommonMethods.ClickELALessonContinueButton(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher Mode Icon not present");
                AutomationAgent.Wait(500);
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
        [WorkItem(15900)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OnlyLessonsThatAreDownloadedShouldOpenLessonPreview()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson+1);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson + 1), "ELA Start Button Not Active");
               // Assert.IsFalse(LessonBrowserCommonMethods.VerifyELAStartButtonActive(5), "ELA Start Button Not Active");
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
        [WorkItem(20477)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void ImageGetsOpenedFullscreen()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Image");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                //Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageExistinLesson(), "Image Does Not Exist In Lesson");
                LessonBrowserCommonMethods.TapOnScreen();
                Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageFullScreen(), "Image Is Not Full Screen");
                LessonBrowserCommonMethods.ClickDoneButton();
                NavigationCommonMethods.NavigateToTaskPageInLesson(taskInfo.TaskNumber);
                //Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageExistinLesson(), "Image Does Not Exist In Lesson");
                LessonBrowserCommonMethods.TapOnScreen();
                Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageFullScreen(), "Image Is Not Full Screen");
                LessonBrowserCommonMethods.ClickDoneButton();
                //Assert.AreEqual(true, LessonBrowserCommonMethods.VerifyImageExistinLesson(), "Image Does Not Exist In Lesson");
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
        [WorkItem(20202)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemChromeTitleSaysGalleryProblem()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);

                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenGalleryProblem(taskInfo.TaskNumber);
                string title = LessonBrowserCommonMethods.GetLessonTitleGalleryProblem();
                Assert.AreEqual(title, "Gallery Problem", "Title incorrect");
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
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
        [WorkItem(20216)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemChromeIconsAreBackToolsAndGamesNotebookIcon()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenGalleryProblem(taskInfo.TaskNumber);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemChromeBarIcons(), "Chrome icons not verified");
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
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
        [WorkItem(20189)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemDoneButtonBringsUserBackToGalleryLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenGalleryProblem(taskInfo.TaskNumber);

                Assert.IsFalse(LessonBrowserCommonMethods.VerifyGalleryProblemLessonTaskPage(taskInfo.Lesson), "Gallery Problem task page not found");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemPage(), "Gallery Problem page not found");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyDoneButtonInGalleryProblemPage(), "Done button not found");
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemLessonTaskPage(taskInfo.Lesson), "Gallery Problem task page not found");
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
        [WorkItem(20192)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryLessonUnitXButtonInChromeSendsUserBackToLessonBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemLessonTaskPage(6), "Gallery Problem Lesson task not found");
                string backButtonText = LessonBrowserCommonMethods.GetUnitBackButtonText();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyBackButtonExists(), "Back button title incorrect");
                Assert.AreEqual(backButtonText, "Unit 1", "Back button title incorrect");
                LessonBrowserCommonMethods.ClickBackButton();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyGalleryProblemLessonTaskPage(6), "Gallery Problem Lesson task not found");
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
        [WorkItem(31809)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryLessonContainsIconsOnTheChromeBarForTeachers()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryLessonChromeIconsForTeacher());
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
        [WorkItem(20195)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryLessonsCanBeAccessedLikeAnyOtherLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickMathUnit(taskInfo.Unit);
                // Assert.IsTrue(LessonBrowserCommonMethods.VerifyMathUnitPreview(1), "Math unit preview not verified");
                NavigationCommonMethods.ClickStartInMathUnitPreview(taskInfo.Unit);
                NavigationCommonMethods.ClickMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyMathLessonPreview(taskInfo.Lesson), "Math unit preview not verified");
                NavigationCommonMethods.ClickStartInMathLessonPreview(taskInfo.Lesson);
                string lessonTitle = LessonBrowserCommonMethods.GetLessonTitle();
                Assert.IsTrue(lessonTitle.Contains("Gallery"), "Title is not correct");
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
        [WorkItem(31810)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryLessonContainsIconsOnTheChromeBarForStudents()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryLessonChromeIconsForStudents(), "Chrome icons not verified");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconPresent(), "Teacher mode not present");
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
        [WorkItem(20483)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryLessonChromeTitleIsLessonXGallery()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                int i = taskInfo.Lesson;
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                string title = LessonBrowserCommonMethods.GetLessonTitle();
                Assert.AreEqual(title, "Lesson " + i + ": Gallery");
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
        [WorkItem(15881)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SwipeThroughLessonEpisodesOneEpisodeAvailable()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(9);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(2);
               // NavigationCommonMethods.ClickStartInELAUnitLibrary(3);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(3);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifySingleEpisodeUnit(), "Single EpisodeUnit Is not found");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(1);
                string episodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(1);
                LessonBrowserCommonMethods.SwipeLessonPreview(4);
                string newEpisodeTitle = LessonBrowserCommonMethods.GetEpisodeTitle(1);
                Assert.AreEqual(episodeTitle, newEpisodeTitle, "Episode title incorrect");
                NotebookCommonMethods.TapOnScreen(400, 60);
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
        [WorkItem(20200)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GalleryLessonIconsOnChromeBarAreGamesAndToolsNotebookConceptCornerNotificationAndTeacherModeForTeacher()
        {
            try
            {
                Login teacherLogin = Login.GetLogin("Sec9Apatton");
                Login studentLogin = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(teacherLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacherLogin.GetTaskInfo("Math", "Notebook"));
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGamesToolIconinLesson(), "Games And Tool Icon Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNotebookIconinLesson(), "Notebook Icon Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNotificationButtoninLesson(), "Notification Button Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyConceptCornerButtoninLesson(), "ConceptCorner Icon Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconInLesson(), "TeacherMode Icon Is Not Present In Lesson");
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(studentLogin);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(studentLogin.GetTaskInfo("Math", "Notebook"));
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGamesToolIconinLesson(), "Games And Tool Icon Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNotebookIconinLesson(), "Notebook Icon Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNotificationButtoninLesson(), "Notification Button Is Not Present In Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyConceptCornerButtoninLesson(), "ConceptCorner Icon Is Not Present In Lesson");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyTeacherModeIconInLesson(), "TeacherMode Icon Is  Present For Student Login");
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
        [WorkItem(20201)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GalleryProblemOpensWhenTappingAnywhereOnTheImageThumbnails()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                LessonBrowserCommonMethods.TapOnScreen(292, 326);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "Gallery Problem Is Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                LessonBrowserCommonMethods.TapOnScreen(360, 408);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "Gallery Problem Is Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                LessonBrowserCommonMethods.TapOnScreen(802, 232);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "Gallery Problem Is Not Opened");
                LessonBrowserCommonMethods.ClickOnCloseCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                LessonBrowserCommonMethods.TapOnScreen(1226, 249);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "Gallery Problem Is Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
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
        [WorkItem(20204)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GalleryProblemopenswhentappinganywhereontheimagethumbnail()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenNoteBook();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNoteBookTiltle(), "NoteBook Title Is Not Found");
                string NoteBookTitle = LessonBrowserCommonMethods.GetGalleryNoteBookTitle();
                LessonBrowserCommonMethods.OpenGalleryProblem(1);
                LessonBrowserCommonMethods.OpenNoteBook();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNoteBookTiltle(), "NoteBook Title Is Not Found");
                string NewNoteBookTitle = LessonBrowserCommonMethods.GetGalleryNoteBookTitle();
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

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(20190)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GalleryProblemsusercanswipethroughtasks()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenGalleryProblem(taskInfo.TaskNumber);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "MultiTask Gallery Problem Is Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                LessonBrowserCommonMethods.TapOnScreen(802, 232);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "MultiTask Gallery Problem Is Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                LessonBrowserCommonMethods.TapOnScreen(1226, 249);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemOpenedInLeson(), "MultiTask Gallery Problem Is Not Opened");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryPageOpened(), "Gallery Page Is Not Opened");
                //NavigationCommonMethods.NavigateToMathGrade(9);
                //NavigationCommonMethods.StartMathUnitFromUnitLibrary(3);
                //LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                //NavigationCommonMethods.OpenMathLessonFromLessonBrowser(12);
                //LessonBrowserCommonMethods.OpenGalleryProblem(1);
                //Assert.IsTrue(LessonBrowserCommonMethods.VerifySingleTaskGalleryPage(), "Single Task Gallery Problem Is Not OpenedGallery Problem Is Not Opened");
                //NotebookCommonMethods.ClickOnDoneCloseButton();
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
        [WorkItem(20205)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenNotebookOpenGalleryProblemContentNeedsToBeReformattedToFitHalfScreen()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenGalleryProblem(taskInfo.TaskNumber);
                LessonBrowserCommonMethods.OpenNoteBook();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNotebookSplitsScreen(), "NoteBook does not split screen to half");
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
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
        [WorkItem(16074)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenNonSectionedUserLogsInFirstTimeThenUserIsMovedDirectlyToUnitLibary()
        {
            try
            {

                NavigationCommonMethods.LoginApp(Login.GetLogin("GustadMody"));
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitLibraryPage(), "Unit Library Page Not Open");
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
        [WorkItem(20199)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void GalleryProblemThumbnailsareverticallyscrollable()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGallerylessonpagerighttoleftscrollable(), "Gallery lesson page Not vertically scrollable");
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
        [TestCategory("LessonBrowserTests"), TestCategory("212SmokeTests")]
        [WorkItem(15876)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SwipeleftseenextepisodeontheLessonBrowser()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonExistsinLeftofLessonBrowser(), "Lesson Not Exists in Left of LessonBrowser");
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
        [WorkItem(15880)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SwipeleftrightthroughELAlessonepisodes()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(taskInfo.Lesson), "No Start Button");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson+1), "Previewcard Found");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(taskInfo.Lesson+1), "No Start Button");
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(taskInfo.Lesson), "No Start Button");
                NotebookCommonMethods.TapOnScreen(400, 60);
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
        [WorkItem(20187)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Galleryproblemaspartoflessoncontentrenderedassublessonswithtasks()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");

                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.LessonBrowserScrollLeft();
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.OpenGalleryProblem(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                LessonBrowserCommonMethods.TapOnScreen(363, 393);
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
                LessonBrowserCommonMethods.OpenGalleryProblemSecond(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                LessonBrowserCommonMethods.TapOnScreen(363, 393);
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
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
        [WorkItem(15888)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Lessonsareorderedbylessonnumberinascending()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsAreInOrder(), "Lessons Are not In order");
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
        [WorkItem(16302)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonBrowserchromeitemsTraybackUnittitleToolsGamesNotificationBadgeTeacherGuide()
        {
            try
            {
                //Sectioned Student
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserAppChromeTitleContainsUnitNoAndName(taskInfo.Unit), "No Unit Number And Name");
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "No Back Button");
                Assert.IsTrue(DashboardCommonMethods.VerifyNotificationOverlayPresent(), "No Notification Overlay");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGamesToolIconinLesson(), "No GameTools Icon");
                NavigationCommonMethods.Logout();
                //Non-Sectioned Student
                login = Login.GetLogin("StudentGustadMody");
                 taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserAppChromeTitleContainsUnitNoAndName(taskInfo.Unit), "No Unit Number And Name");
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "No Back Button");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGamesToolIconinLesson(), "No GameTools Icon");
                NavigationCommonMethods.Logout();
                //Non-sectoned Teacher
                login = Login.GetLogin("GustadMody");
                 taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserAppChromeTitleContainsUnitNoAndName(taskInfo.Unit), "No Unit Number And Name");
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "No Back Button");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconInLesson(), "No Teacher Mode Icon");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGamesToolIconinLesson(), "No GameTools Icon");
                NavigationCommonMethods.Logout();
                //Sectioned Teacher
                 login = Login.GetLogin("Sec9Apatton");
                 taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserAppChromeTitleContainsUnitNoAndName(taskInfo.Unit), "No Unit Number And Name");
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonBrowserBackButton(), "No Back Button");
                Assert.IsTrue(DashboardCommonMethods.VerifyNotificationOverlayPresent(), "No Notification Overlay");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyTeacherModeIconInLesson(), "No Teacher Mode Icon");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGamesToolIconinLesson(), "No GameTools Icon");
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
        [WorkItem(15898)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NodelayInViewingLessonWhenUsersSwipeThroughLessons()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewAvailableonScreen(taskInfo.Lesson), "Lesson preview Not opened");
                DateTime FirstLessonPreview = DateTime.Now;
                LessonBrowserCommonMethods.SwipeLessonPreview(taskInfo.Lesson+1);
                DateTime SecondLessonPreview = DateTime.Now;
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewAvailableonScreen(taskInfo.Lesson+1), "Lesson preview Not opened");
                TimeSpan diffDatetime = SecondLessonPreview.Subtract(FirstLessonPreview);
                Assert.IsTrue(diffDatetime.Seconds < 2, "Time taken to open lesson preview is having delays");
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson+1);
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
        [WorkItem(14961)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void ViewIntroVideoInTheLessonBrowser()
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
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(taskInfo.Unit);
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(), "Video Not opened");
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFullScreen(), "Video Is Not FullScreen");
                    LessonBrowserCommonMethods.ClickToCloseVideo();

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





        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(17673)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SmoothTransitionFromTheIntroVideoToTheLessonBrowserPageWhenIntroVideoEnds()
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
                    LessonBrowserCommonMethods.ClickOnPlayButtonInVideo(taskInfo.Unit);
                    Assert.IsFalse(LessonBrowserCommonMethods.VerifyVideoComplete(), "Video Is Not Completed");
                    AutomationAgent.Wait(10000);
                    if (!LessonBrowserCommonMethods.VerifyLessonBrowserPage())
                        AutomationAgent.Wait(10000);

                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser Page Is Not Available");
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






        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19372)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonCarouselOpensItShouldDefaultToPositionOfSelectedLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewOpened(taskInfo.Lesson), "Lesson Preview for the specified Lesson is not opened");
                NavigationCommonMethods.ClickOnLessonPreviewCloseButton(taskInfo.Lesson);
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
        [WorkItem(19373)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonCarouselShouldNotCoverNavigationBar()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewOpened(taskInfo.Lesson), "Lesson Preview for the specified Lesson is not opened");
                NavigationCommonMethods.ClickOnLessonPreviewCloseButton(taskInfo.Lesson);
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
        [WorkItem(15878)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonBrowserCanBeScrolled()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                for (int i = 1; i <= 4; i++)
                {
                    int count = LessonBrowserCommonMethods.GetELALessonsGroupCount();
                    if (count >= 4)
                    {
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser not present");
                        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                        Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser is still present");
                        break;
                    }
                    else
                    {
                        NavigationCommonMethods.ClickBackButtonInLessonPage();
                        NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit + i);
                    }
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15883)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonsCannotBeScrolled()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                for (int i = 1; i <= 4; i++)
                {
                    int count = LessonBrowserCommonMethods.GetMathLessonsGroupCount();
                    if (count <= 6)
                    {
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser not present");
                        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser is still present");
                        break;
                    }
                    else
                    {
                        NavigationCommonMethods.ClickBackButtonInLessonPage();
                        NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit + i);
                    }
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15884)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ViewELALessonBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser Page not present");
                for (int i = 1; i <= 4; i++)
                {
                    int count = LessonBrowserCommonMethods.GetELALessonsGroupCount();
                    if (count >= 4)
                    {
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser not present");
                        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyELALessonThumbnailText(taskInfo.Lesson + 6), "Lesson thumbnail Text present at the below of the thumbnail");
                        Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser is still present");
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonNumbersOfLessonCards(taskInfo.Lesson), "Lesson Numbers not present");
                        break;
                    }
                    else
                    {
                        NavigationCommonMethods.ClickBackButtonInLessonPage();
                        NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit + i);
                    }
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15885)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ViewContentsOnMathLessonBrowserScreen()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "Lesson Browser Page not present");

                for (int i = 1; i <= 4; i++)
                {
                    int count = LessonBrowserCommonMethods.GetMathLessonsGroupCount();
                    if (count > 10)
                    {
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser not present");
                        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyMathLessonThumbnailText(taskInfo.Lesson + 6), "Lesson thumbnail Text present at the below of the thumbnail");
                        Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Specific Lesson in Lesson Browser is still present");
                        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonNumbersOfLessonCards(taskInfo.Lesson), "Lesson Numbers not present");
                        break;
                    }
                    else
                    {
                        NavigationCommonMethods.ClickBackButtonInLessonPage();
                        NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit + i);
                    }
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15877)]
        [Priority(3)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SwipeThroughELALessonEpisodesWhenOnlyOneEpisodeExists()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                int count = NavigationCommonMethods.GetUnitsCount();
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                for (int i = taskInfo.Unit; i <= count; i++)
                {
                    if (i < 3)
                    {
                        NavigationCommonMethods.ClickStartInELAUnitLibrary(i);
                    }
                    else
                    {
                        LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                        NavigationCommonMethods.ClickStartInMathUnitPreview(i);
                    }
                    if (LessonBrowserCommonMethods.VerifySingleEpisodeUnit())
                        break;
                    else
                    {
                        NavigationCommonMethods.ClickBackButtonInLessonPage();
                    }
                }
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Lesson Not present");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPresent(taskInfo.Lesson), "Lesson Not present");
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
        [WorkItem(20197)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void GalleryProblemLayoutConsistsOf2Or3Columns()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "GalleryProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyGalleryProblemsInColumns(), "Gallery Problems not in Columns");
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


        /*Network Dependent*/
        #region NetworkDependent

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19370)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DownloadCompletedLessonPreviewCardBrightActiveStartBlueAndWorking()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                NavigationCommonMethods.ClickELALessonContinueButton(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonOpenedToRead(), "lesson not opened");
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
        [WorkItem(15892)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonDownloadCompletedThumbnailBrightPreviewOpensAfterTap()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson), "Progress bar exists");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewOpened(taskInfo.Lesson), "Lesson Not Opened");
                NavigationCommonMethods.ClickOnStartLessonButton(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonOpenedToRead(), "Lesson not opened");
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
        [WorkItem(15899)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DownloadedLessonShouldNotHaveSpinnerProgressBar()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                NavigationCommonMethods.ClickELALessonContinueButton(taskInfo.Lesson);
                LessonBrowserCommonMethods.ClickOnBackButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserEpisodeCell(), "Lesson Browser episode cell not found");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson), "Progress bar exists");
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
        ////[TestCategory("LessonBrowserTests")]
        ////[WorkItem(15904)]
        ////[Priority(1)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void NoWiFiIconVisibleOnThumbnailsPopUpMessage()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
        ////        NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit);
        ////        AutomationAgent.DisableNetwork();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        AutomationAgent.EnableNetwork();
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
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
        ////[TestCategory("LessonBrowserTests")]
        ////[WorkItem(19368)]
        ////[Priority(1)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void LessonPreviewDownloadNoWiFiconOnlyForNotYetDownloaded()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade+1);
        ////        NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit + 2);
        ////        NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson + 2);
        ////        AutomationAgent.DisableNetwork();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson + 2), "Previewcard Found");
        ////        AutomationAgent.EnableNetwork();
        ////        AutomationAgent.Wait();
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
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
        ////[TestCategory("LessonBrowserTests")]
        ////[WorkItem(15894)]
        ////[Priority(1)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void NoWiFIconOnlyForLessonsNotYetDownloaded()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonProgressBar");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
        ////        AutomationAgent.DisableNetwork();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        AutomationAgent.EnableNetwork();
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
        ////        NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Lesson Previewcard Is Not  Found");
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
        ////        LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson + 3);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson + 3), "Lesson Previewcard Is Not  Found");
        ////        Assert.IsFalse(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Is found");
        ////        NavigationCommonMethods.ClickSystemTrayButton();
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
        ////[TestCategory("LessonBrowserTests")]
        ////[WorkItem(15895)]
        ////[Priority(1)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void NoWiFiIconsAreShownOnlyForLessonsNotYetDownloaded()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
        ////        LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
        ////        NavigationCommonMethods.ClickSystemTrayButton();
        ////        AutomationAgent.DisableNetwork();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitInUnitLibrary(taskInfo.Unit);
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyNoWifiIconInUnitLibrary(), "No Wifi Icon Not found");
        ////        NavigationCommonMethods.Logout();
        ////        AutomationAgent.EnableNetwork();
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
        [TestCategory("LessonBrowserTests"), TestCategory("212SmokeTests")]
        [WorkItem(15983)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CancelReturnsToPreviousScreen()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(taskInfo.Grade), "ELA grade not found");
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.ClickCancelButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAGradeButton(taskInfo.Grade), "ELA grade not found");
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
        [WorkItem(15922)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContinueButtonIsDisabledOnAddGradeIfNoGradeSelected()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Continue Button Enabled");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [WorkItem(15984)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContinueTogglesActiveOnTappingNonExistingGrade()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                LessonBrowserCommonMethods.SelectGrade();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Continue Button Disabled");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [WorkItem(15981)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyUserCanCheckAndUncheckGrades()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyCheckAndUncheckGrades(), "Can't check uncheck grades");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [WorkItem(15982)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AlreadyDownloadedGradesAreGrayedAndCannotBeSelected()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAlreadyDownloadedGradeGrayedAndCannotBeSelected(taskInfo.Grade.ToString()), "Grade can be selected");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        ////[TestCategory("LessonBrowserTests")]
        ////[WorkItem(19384)]
        ////[Priority(1)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void LogOutRightAfterAddingNewGradesNoUnexpectedBehaviorsObserved()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectGrade();
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Continue Button Enabled");
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        NavigationCommonMethods.Logout();
        ////        Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen Is Not Available");
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15979)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void UserRecommendedToSelectOnlyTwoGradesWhenAddingGrades()
        {
            try
            {
                //Sectioned Teacher
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyMessageToSelectOnlyTwoGrades(), "SelectOnlyTwoGrades Message Not Avaialble");
                LessonBrowserCommonMethods.ClickCancelButton();
                NavigationCommonMethods.Logout();

                //Non-Sectioned Teacher
                NavigationCommonMethods.LoginApp(Login.GetLogin("GustadMody"));
                NavigationCommonMethods.NavigateToELA();
                LessonBrowserCommonMethods.ClickAddGrades();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyMessageToSelectOnlyTwoGrades(), "SelectOnlyTwoGrades Message Not Avaialble");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [WorkItem(22150)]
        [Priority(3)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SelectingLessonWillBeginItsDownload()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson);
                //LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson + 1);
                //Assert.IsFalse(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                //LessonBrowserCommonMethods.ClickOnCloseCloseButton();
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
        [WorkItem(19363)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void OnlyLessonsDownloadedShouldOpenLessonPreview()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);
                Color sampleColor = Color.FromArgb(255, 0, 50, 195);
                bool clrbool = LessonBrowserCommonMethods.VerifyStartLessonButtonColor(sampleColor, taskInfo.Lesson);
                LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson + 3);
                Color sampleColor1 = Color.FromArgb(255, 153, 153, 153);
                bool clrbool1 = LessonBrowserCommonMethods.VerifyStartLessonButtonColor(sampleColor, taskInfo.Lesson + 3);
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson + 3);
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
        [WorkItem(18984)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ClassRosterVisibleForTeacherWithOneSection()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage(), "esson Browser Page not present");
                NavigationCommonMethods.ClickOnELATeacherModeIcon();
                TeacherModeCommonMethods.ClickUnitOverview();
                AutomationAgent.Wait(1000);
                Assert.IsTrue(TeacherModeCommonMethods.VerifyClassRoster(), "Class Roster Not  present");
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
        [WorkItem(22151)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StartButtonNotDownloadedLessonPreviewDisabled()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                //Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(2), "LessonsNotDownloaded Is Not Availble");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson+1);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson + 1), "ELA Start Button Active");
                NotebookCommonMethods.TapOnScreen(400, 60);
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
        [WorkItem(22152)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DuringDownloadLessonCarrouselCanAccess()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade+1);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is Not Availble");
                LessonBrowserCommonMethods.WaitForLessonToDownload(taskInfo.Lesson);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is  Availble");
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


        

        ////[TestMethod()]
        ////[TestCategory("LessonBrowserTests")]
        ////[WorkItem(15897), WorkItem(22156), WorkItem(17701), WorkItem(22155)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void WhenUserEntersUnitLessonsAutomaticallyStartToDownloadInSequence()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsStartToDownload(), "Lesson download not started");
        ////        Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonDownloadinSequence(), "Lesson download not in sequence");
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectGrade(2);
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        AutomationAgent.Wait();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyPrepairingUnitsProgressSinner(), "Preparing Units text not present");
        ////        NavigationCommonMethods.NavigateToELA();
        ////        NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
        ////        NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is  Availble");
        ////        NavigationCommonMethods.ClickContentManagerButton();
        ////        ContentManagerCommonMethods.ClickShowDetails();
        ////        Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
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

        /*Lesson Download - Test cases*/

        #region LessonDownload

        [TestMethod()]
        [TestCategory("LessonBrowserTests")]
        [WorkItem(19366),WorkItem(15891), WorkItem(31231), WorkItem(15901)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DisabledStartButtonShouldMatchDesign()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade+2);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is Not Availble");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson), "ProgessBar Not Found");
                LessonBrowserCommonMethods.WaitForLessonToDownload(taskInfo.Lesson);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson), "ELA Start Button Not Active");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonDesignMatch(taskInfo.Lesson), "Start button Design is not found");
                DashboardCommonMethods.SwipeLeft();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyStartButtonDesignMatch(taskInfo.Lesson + 1), "Start button Design is not found");
               // Assert.IsFalse(LessonBrowserCommonMethods.VerifyELAStartButtonActive(taskInfo.Lesson + 1), "ELA Start Button Active");
                NotebookCommonMethods.TapOnScreen(400, 60);
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
        [WorkItem(16303)]
        [Priority(3)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LessonTappedTakesThePriorityAfterItIsDownloadedQueueResumes()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade + 1);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.ClickContentManagerButton();
                ContentManagerCommonMethods.ClickOnCheckUpdate();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(), "Show Details button not present");
                ContentManagerCommonMethods.ClickShowDetails();
                string content = ContentManagerCommonMethods.GetQueueContent();
                Assert.IsTrue(content.Contains("Grade " + taskInfo.Grade + 1));
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade + 2);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                NavigationCommonMethods.ClickContentManagerButton();
                ContentManagerCommonMethods.ClickOnCheckUpdate();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(), "Show Details button not present");
                ContentManagerCommonMethods.ClickShowDetails();
                string newContent = ContentManagerCommonMethods.GetQueueContent();
                Assert.IsTrue(newContent.Contains("Grade " + taskInfo.Grade + 2));
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
        [WorkItem(22153)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenLessonTappedStartDownloadNoPreviewOpened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is Not Availble");
                LessonBrowserCommonMethods.WaitForLessonToDownload(taskInfo.Lesson);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskInfo.Lesson), "LessonsNotDownloaded Is  Availble");
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
        [TestCategory("LessonBrowserTests")]
        [WorkItem(15901)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void UsersShouldBeAbleToViewProgressBarOnLessonPreview()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonProgressBar");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson), "ProgessBar Not Found");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsFalse(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Found");
                LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson + 5);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(taskInfo.Lesson + 5), "ProgessBar Not Found");
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
        [WorkItem(19367)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void LessonPreviewCardIsGrayWhenItHasNotBeenFullyDownloaded()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonProgressBar");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);

                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Not Found");
                LessonBrowserCommonMethods.NavigateLesson(taskInfo.Lesson + 2);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(taskInfo.Lesson + 2), "StartButton Is GrayedOut For NotDownLoaded Lesson");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(taskInfo.Lesson + 2), "ProgressBar On LessonPreviewCard Is Not Avaialble");
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
        [WorkItem(19369)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void LessonThatDownloadInProgressWillDisplayAProgressBarOnTheLessonCarousel()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit + 1);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Unit + 1);
                LessonBrowserCommonMethods.ClickLessonFirstTime(taskInfo.Lesson);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonPreviewCardProgressBar(taskInfo.Lesson));
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson);
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
        [WorkItem(31230)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void LessonDownloadInProgressProgressBarOverThumbnailPreviewDoesntOpen()
        {

            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(10);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(2);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(2);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonBrowserPage());
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(4);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonProgressBarExist(4));
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(4);
                Assert.IsFalse(NavigationCommonMethods.VerifyLessonPreviewCard(4), "Previewcard Found");
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
        [WorkItem(15889)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal")]
        public void LessonNotYetStartedDownloadingDarkerThumbnailPreviewDoesntOpenNotDownloadedIcon()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskinfo = login.GetTaskInfo("ELA", "LessonNotDownloaded");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskinfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskinfo.Unit + 2);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskinfo.Unit + 2);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonsNotDownloaded(taskinfo.Lesson), "LessonsNotDownloaded Is Not Availble");
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskinfo.Lesson);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyStartButtonForLessonPreviewCard(taskinfo.Lesson), "StartButton For LessonPreviewCard Is Avaialable");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyLessonPreviewOpened(taskinfo.Lesson), "LessonPreview Is Opened");
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
        [WorkItem(31603)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonPreviewDownloadInProgressProgressBarVisibleForLessonNotYetDownloaded()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit + 1);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit + 1);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Unit + 1);
                AutomationAgent.Wait(10000);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Unit + 1);
                if (!NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Unit + 1))
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Unit + 1);

                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Unit + 1), "Previewcard Not Found");
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(taskInfo.Unit + 1 + 1));
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(taskInfo.Unit + 1 + 1));
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(taskInfo.Unit + 1));
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Unit + 1);
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
        [WorkItem(31602), WorkItem(19371)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void LessonPreviewDownloadNotStartedStartGreyedOutInactive()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "LessonProgressBar");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit + 2);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.WaitForLessonToDownloadAndClick(taskInfo.Lesson);

                if (NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson))
                {
                    // AutomationAgent.Wait(10000);
                    NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                }

                Assert.IsTrue(NavigationCommonMethods.VerifyLessonPreviewCard(taskInfo.Lesson), "Previewcard Not Found");
                Assert.IsFalse(!LessonBrowserCommonMethods.VerifyStartButtonGrayedOutForNotDownLoadedLesson(taskInfo.Lesson), "StartButton Is GrayedOut For NotDownLoaded Lesson");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyProgressBarOnLessonPreviewCard(taskInfo.Lesson), "ProgressBar On LessonPreviewCard Is Avaialble");
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson);
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

#endregion

        #endregion
    }
}


