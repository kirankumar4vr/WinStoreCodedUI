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
    /// Summary description for ChallengeProblemTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class ChallengeProblemTests
    {
        public ChallengeProblemTests()
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19455)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SystemDisplaysChallengeProblemButtonAndUserIsAllowedToAccessIt()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(taskInfo.TaskNumber), "Challenge problem button not found");
                    NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                    ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19459)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DoneButtonFunctionalityInChallengeProblemSlideDownTransition()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(taskInfo.TaskNumber), "Challenge problem button not found");
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page found");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
                Assert.IsFalse(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(taskInfo.TaskNumber), "Challenge problem button not found");
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19456)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemNotebookIsIndependentFromNotebookInTask()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                AutomationAgent.Click(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("TEST");
                AutomationAgent.Click(500, 500);
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
                NavigationCommonMethods.ClickNextPageIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone();
                Assert.IsFalse(WordsInTextBox.Contains("TEST"), "TEST word present");
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19462)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemCanBeClosedWhileNotebookIsDisplaying()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(taskInfo.TaskNumber), "Challenge problem button not found");
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                AutomationAgent.Click(500, 500);
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
                Assert.IsFalse(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page found");
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemButton(taskInfo.TaskNumber), "Challenge problem button not found");
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19458)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemOpensAsOverlayWithSlideUpTransitionAndDoneAndnotebookIconOnChrome()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyDoneButtonInChallengeProblem(), "Done button not found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyDoneButtonAtTopRight(), "DOne button is not available at top right");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyNotebookIconAtTopLeft(), "DOne button is not available at top right");

                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyNotebookIcon(), "Notebook Icon not found");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19461)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookBehaviorInChallengeProblemPageResizedNotebookClosesAfterTappingOutside()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNotebookSplitsScreen(), "Notebook doesnot splits lesson");
                AutomationAgent.Click(500, 500);
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook opened");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19465)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemOpensFullscreenEvenIfNotebookWasOpenedWhenTappingChallengeProblemButton()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                NavigationCommonMethods.ClickChallengeProblemButtonNotebookOpened(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPageFullScreen(), "Challenge problem not full screen");
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook opened");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(20473)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SystemTrayButtonHiddenWhenChallengeProblemOpened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPageFullScreen(), "Challenge problem not full screen");
                Assert.IsFalse(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System tray button avaialble");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(20475)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemThreeContextIcons()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyThreeContextIconsforChallengeProblem(), "Context icons can't be verified");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(19460)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemTitleShouldSayChallengeProblem()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemTitle(), "Challenge problem title not found");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemTitleAtCenter(), "Title is not at screen center");
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
        [TestCategory("ChallengeProblemTests")]
        [Priority(1)]
        [WorkItem(20476)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChallengeProblemDisplaysProperlyTogetherWithTeacherMode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "ChallengeProblem");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "ChallengeProblem"));
                NavigationCommonMethods.ClickChallengeProblemButton(taskInfo.TaskNumber);
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeIconPresent(), "Teacher mode icon not found");
                string ChallengeProblemPageTextPos = ChallengeProblemCommonMethods.GetChallengeProblemPageTextPos();
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                Assert.IsTrue(ChallengeProblemCommonMethods.VerifyChallengeProblemPage(), "Challenge problem page not found");
                string ChallengeProblemPageTextPosNw = ChallengeProblemCommonMethods.GetChallengeProblemPageTextPos();
                Assert.AreEqual(ChallengeProblemPageTextPos, ChallengeProblemPageTextPosNw, "Challenge problem text position same");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                ChallengeProblemCommonMethods.ClickOnDoneButtonInChallengeProblem();
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
