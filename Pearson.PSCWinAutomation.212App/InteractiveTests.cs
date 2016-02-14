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
    /// Summary description for InteractiveTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InteractiveTests
    {
        public InteractiveTests()
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(22305), WorkItem(44832)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenInteractiveFromLesson()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                Assert.IsTrue(InteractiveCommonMethods.VerifyMathChromeVisible(),"Math Chrome not visible");
                Assert.IsTrue(InteractiveCommonMethods.VerifyTopLeftDoneButton(),"Done button not found");
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookAvailable(), "Save to notebook not found");
                InteractiveCommonMethods.ClickOnInteractiveDoneButton();
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
        [TestCategory("InteractiveTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(22307), WorkItem(44833)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CloseInteractiveOpenedFromWithinLessonUsingDoneButton()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                int LessonTask = taskInfo.Lesson;
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                Assert.IsTrue(InteractiveCommonMethods.VerifyMathChromeVisible(), "Math Chrome not visible");
                InteractiveCommonMethods.ClickOnInteractiveDoneButton();
                Assert.IsTrue(InteractiveCommonMethods.VerifyLessonTaskPage(),"Lesson task page not found");
                Assert.IsTrue(InteractiveCommonMethods.VerifyLessonTaskNumber(LessonTask),"Task number incorrect");
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
        //[TestCategory("InteractiveTests")]
        //[Priority(3)]
        //[WorkItem(23923)]
        //[Owner("Madhav Purohit(madhav.purohit)")]
        //public void TeacherModeOpensWhenTeacherIsOnInteractiveLesson()
        //{

        //    try
        //    {
        //        Login login = Login.GetLogin("Sec9Apatton");
        //        TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
        //        NavigationCommonMethods.LoginApp(login);
        //        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
        //        Assert.IsTrue(InteractiveCommonMethods.VerifyLessonTaskPage(), "Lesson task page not found");
        //        NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
        //        Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive not opened");
        //        NavigationCommonMethods.ClickOnTeacherModeIcon();
        //        Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(),"Teacher mode not opened");
        //        NavigationCommonMethods.ClickOnTeacherModeIcon();
        //        InteractiveCommonMethods.ClickOnInteractiveDoneButton();
        //        NavigationCommonMethods.Logout();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Logger.InsertExceptionMessage(Ex.Message);
        //        AutomationAgent.CreateScreenshot();
        //        AutomationAgent.CloseApp();
        //        throw;
        //    }
        //}


        [TestMethod()]
        [TestCategory("InteractiveTests")]
        [Priority(3)]
        [WorkItem(23924), WorkItem(23923)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherModeIsOpenedWhenIOpenInteractiveInLessonThenTeacherStaysOpened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher mode not opened");
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTaskTeacherModeOpened(taskInfo.TaskNumber);
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher mode not opened");
                Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(),"Interactive not opened");
                InteractiveCommonMethods.ClickOnInteractiveDoneButton();
                NavigationCommonMethods.ClickOnTeacherModeIcon();
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
        [TestCategory("InteractiveTests")]
        [Priority(3)]
        [WorkItem(22524)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SaveToNotebookButtonAvailableInInteractive()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(),"Interactive not opened");
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookAvailable(), "Send to notebook icon not found");
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookAtTopRight(), "Send to notebook is not available at upper left of screen");
                InteractiveCommonMethods.ClickOnInteractiveDoneButton();
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23163)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SavingInteractivesVerifySendToNotebookIconAlert()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookAtTopRight(), "Send to notebook is not available at upper left of screen");
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                Assert.IsTrue(InteractiveCommonMethods.VerifySaveInteractiveAlert(), "Save Interactive Alert not present");
                InteractiveCommonMethods.ClickCancelInSaveInteractiveAlert();
                Assert.IsFalse(InteractiveCommonMethods.VerifySaveInteractiveAlert(), "Save Interactive Alert still present");
                Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is not open");
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is still open");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Interactive not at center of the notebook");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23169)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SavingInteractivesDeleteInteractiveRegion()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Interactive state is not present in notebook");
                NotebookCommonMethods.ClickTextRegionDeleteXIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Interactive state is not present in notebook");
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23165)]
        [Owner("Akanksha Gautam(akanksha.gautam)"), TestCategory("212SmokeTests")]
        public void SaveNewInteractiveAfterEditing()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is not open");
                Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookAtTopRight(), "Send To Notebook icon is not present at the top right corner");
                InteractiveCommonMethods.EditInteractive();
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is still opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Interactive is not at the center of the notebook");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23261)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void OpenSavedInteractiveFromNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                //Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is still opened");
               // NotebookCommonMethods.ClickEraseIconInNotebook();
                //NotebookCommonMethods.ClickClearPage();
                InteractiveCommonMethods.ClickOnInteractiveDoneButton();
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23164)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SaveNewInteractiveWithoutEditing()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                    NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                    InteractiveCommonMethods.ClickSendToNotebookIcon();
                    InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                    Assert.IsFalse(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive is still open");
                    NotebookCommonMethods.VerifyNotebookOpen();
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Interactive not at center of the notebook");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23265)]
        [Owner("Madhav Purohit(madhav.purohit)"), TestCategory("212SmokeTests")]
        public void SendToNotebookButtonIsNotVisibleWhenInteractiveOpenedFromNotebook()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                    NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                    InteractiveCommonMethods.ClickSendToNotebookIcon();
                    InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Interactive thumbnail not present");
                    InteractiveCommonMethods.ClickInteractiveThumbnail();
                    InteractiveCommonMethods.ClickInteractiveThumbnail();
                    Assert.IsTrue(InteractiveCommonMethods.VerifyInteractiveOpen(), "Interactive not open");
                    Assert.IsFalse(InteractiveCommonMethods.VerifySendToNotebookAtTopRight(), "Send To Notebook icon is still present");
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("InteractiveTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(23271)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesTimeStampIsNotUpdatedWhenNoEditsAreMade()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                    NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                    InteractiveCommonMethods.ClickSendToNotebookIcon();
                    InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Interactive thumbnail not present");
                    string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime();
                    InteractiveCommonMethods.ClickInteractiveThumbnail();
                    InteractiveCommonMethods.ClickOnInteractiveDoneButton();
                    string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime();
                    Assert.AreEqual(TextBefore, TextAfter,"desmos modified times not same");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("InteractiveTests")]
        [Priority(2)]
        [WorkItem(23167)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesMoveInteractiveRegion()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                    NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                    InteractiveCommonMethods.ClickSendToNotebookIcon();
                    InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Interactive thumbnail not present");
                    string position = NotebookCommonMethods.GetDesmosCoordinate();
                    NotebookCommonMethods.MoveDesmosInNoteBook();
                    string newPosition = NotebookCommonMethods.GetDesmosCoordinate();
                    Assert.AreNotEqual(position, newPosition, "Desmos didn't move and position is same");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("InteractiveTests")]
        [WorkItem(23261)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesOpenSavedInteractiveFromNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                InteractiveCommonMethods.EditInteractive();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook());
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyNewInteractivePagePresent(), "interactive page not found");
                NotebookCommonMethods.ClickDoneButton();
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
