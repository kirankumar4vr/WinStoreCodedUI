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
    /// Summary description for NotebookTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class NotebookTests
    {
        public NotebookTests()
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22423)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ClosingNotebookByTappingOnLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook Not opened");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook opened");
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22465)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ClosingNotebookByTappingLesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook Not opened");
                AutomationAgent.Click(100, 100);
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook opened");
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

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(19307)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosUndoRedoButtonAvailableInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyUndoRedoButton(), "UndoRedoButton Not exists");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19309)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosSubMenuOpensWhenTappingUndoRedoIconInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyUndoRedoButton(), "UndoRedoButton Not exists");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyUndoRedoSubMenu(), "No sub menu found");
                NotebookCommonMethods.ClickOnNotebookIcon();

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
        [TestCategory("NotebookTests")]
        [WorkItem(19310)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosUndoRedoMenuClosesWhenTappingOutsideCanvas()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyUndoRedoSubMenu(), "No sub menu found");
                AutomationAgent.Click(1150, 400);
                Assert.IsFalse(NotebookCommonMethods.VerifyUndoRedoSubMenu(), "No sub menu found");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(20422)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ToolBarButtonCanBeAccessed()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyToolbarButton(), "Tool bar icon not found");
                NotebookCommonMethods.ClickOnToolbarButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyToolbarOpen(), "Tool bar submenu not found");
                AutomationAgent.Click(700, 30);
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
        [TestCategory("NotebookTests")]
        [WorkItem(16210)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LaunchingSnapshotTool()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.OpenSnapShot();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(), "SnapShot Grid Not present");
                NotebookCommonMethods.ClickCancelSnapShot();
                AutomationAgent.Wait();
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
        [TestCategory("NotebookTests")]
        [WorkItem(19304)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosSubMenuOpensWhenTappingWrenchIconInNotebook()
        {
            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    Assert.IsTrue(NotebookCommonMethods.VerifyWrenchIcon(), "WrenchIcon Not Found");
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    Assert.IsTrue(NotebookCommonMethods.VerifyWrenchToolSketchGraphSubMenuExists(), "WrenchToolSketchGraphSubMenu Not Found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "WrenchToolGraphingSubMenu Not Found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19306)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosGraphingSubMenuOpensWhenTappingWrenchIconInNotebook()
        {

            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    Assert.IsTrue(NotebookCommonMethods.VerifyWrenchIcon(), "WrenchIcon Not Found");
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosTool(), "DesmosTool Not Found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19303)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosToolBarButtonIsAvailableInTheNotebook()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyWrenchIcon(), "WrenchIcon Not Found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20806)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosSendToNotebbokIconDisplayed()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyGlobalNavBarPresent(), "GlobalNavBar is not Present In MathLesson1");
                NotebookCommonMethods.ClickOnWrenchIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosTool(), "DesmosTool Not Found");
                NotebookCommonMethods.ClickOnGraphicTool();
                Assert.AreEqual(false, NotebookCommonMethods.VerifyGlobalNavBarPresent(), "GlobalNavBar is Present In MathLesson1");
                Assert.AreEqual(true, NotebookCommonMethods.VerifySendToNotebookIconPresent(), "SendToNotebook icon is not present");
                NotebookCommonMethods.ClickOnDoneCloseButton();

                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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

        [TestCategory("NotebookTests")]
        [WorkItem(20808)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosDoneButtonTriggersAlertMessage()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyCloseDesmosAlertPopUp(), "Close Alert Pop up not present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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
        [TestCategory("NotebookTests")]
        [WorkItem(20811)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void AlertsDoneButtonTriggersAlertMessageInNewlyCreatedDesmos()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyCloseDesmosAlertPopUp(), "AlertMessage For New Desmos is not present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();

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
        [TestCategory("NotebookTests")]
        [WorkItem(20809)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosAlertMessageCancelButtonBringsBackToDesmos()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                Assert.IsFalse(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "desmos page found");
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Desmos page not found");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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
        [TestCategory("NotebookTests")]
        [WorkItem(20810)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosAlertMessageContinueButtonClosesDesmosWithoutSavingChanges()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Desmos page found");
                Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos thumbnail present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20807)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosSendToNotebookIconNotDisplayedWhenOpeningDesmosFromThumbnailNotebook()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                Assert.AreEqual(true, NotebookCommonMethods.VerifySendToNotebookIconPresent(), "SendToNotebook Icon is not present");
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not present in Notebook");
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyNewDesmosPagePresent(), "New Desmos page is not present ");
                Assert.AreEqual(false, NotebookCommonMethods.VerifySendToNotebookIconPresent(), "SendToNotebook icon is present while opening desmos through Thumbnail");
                NotebookCommonMethods.ClickOnDoneCloseButton();

                //NotebookCommonMethods.ClickEraseIconInNotebook();
                //NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23170)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesUndoRedoDeleteInteractiveRegion()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not Present in notebook");
                NotebookCommonMethods.ClickTextRegionDeleteXIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is Present in notebook");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickUndoIconInNotebook();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
               // NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not Present in notebook");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickRedoIconInNotebook();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is Present in notebook");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(15964)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenNotebookFromELALesson()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                Assert.IsTrue(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(taskInfo.TaskNumber), "Open Notebook Button Present");
                NotebookCommonMethods.ClickOnOpenNotebookButton(taskInfo.TaskNumber);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(), "Notebook does not split Lesson Window");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookIconPresent(), "Notebook icon not found");
                // Assert.IsFalse(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(taskInfo.TaskNumber), "Open Notebook still present");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16216)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void PastingSnapshotIntoNotebook()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.OpenSnapShot();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(), "SnapShot Grid Not present");
                NotebookCommonMethods.ClickCaptureSnapShot();
                AutomationAgent.Wait();
                NotebookCommonMethods.ClickMultimediaIcon();
                NotebookCommonMethods.ClickOnSnapShotIcon();
                AutomationAgent.Click(1300, 660);
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Thumbnail doesn't exists");
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand Icon incative");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16023)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookToolbarActiveInactive()
        {
            try
            {

                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyAllBottomToolbarsActiveInactive(), "Bottom icons are not active as expected");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(20378)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ToVerifyCancelWhileAddingImageFromPhotos()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.OpenImageMultimedia();
                Assert.IsTrue(NotebookCommonMethods.ToVerifyCancelButtonWhileAddingImage(), "Cancel button not found");
                NotebookCommonMethods.ClickCancelAddPhoto();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(), "Photo not available");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20449)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ImagesShouldBeInsertedInCenterOfNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand Icon not highlighted");
                Assert.IsTrue(NotebookCommonMethods.VerifyImageInCenterOfNotebook(), "Image Not in Centre of Notebook");
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(20448)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ImagesShouldBeAddedInDefaultSize()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand icon not highlighted");
                int ImageWidth = NotebookCommonMethods.GetWidthOfImageThumbnail();
                int ImageHeight = NotebookCommonMethods.GetHeightOfImageThumbnail();
                Assert.AreEqual(248, ImageWidth, "Default size incorrect");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20450)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void HandModeShouldBeActiveAfterImageIsInserted()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand Icon Not Active");
                string PosBefore = NotebookCommonMethods.GetImageCoordinate();
                NotebookCommonMethods.MoveImageInNoteBook();
                string PosAfter = NotebookCommonMethods.GetImageCoordinate();
                Assert.AreNotEqual(PosAfter, PosBefore, "Image thumbnail positions are same");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22249)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyNotebookIconInTopTaskMenuHighlightedWhenUserClicksOpenNotebookButton()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyNotebookSplitsLessonWindow());
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookIconPresent(), "Notebook Icon not found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20390)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyTheImageResizeRepositionAfterImageAddedThruPhotos()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand Icon Not Active");
                int widthBefore = NotebookCommonMethods.GetWidthOfImageThumbnail();
                NotebookCommonMethods.ResizeImageInNoteBook();
                int widthAfter = NotebookCommonMethods.GetWidthOfImageThumbnail();
                Assert.AreNotEqual(widthBefore, widthAfter, "Width of Image thumbnail is same");
                string PosBefore = NotebookCommonMethods.GetImageCoordinate();
                NotebookCommonMethods.MoveImageInNoteBook();
                string PosAfter = NotebookCommonMethods.GetImageCoordinate();
                Assert.AreNotEqual(PosAfter, PosBefore, "Positions of Image thumbnail are same");
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Image thumbnail not found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19311)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosSelectionDefaultsToHandModeWhenUndoRedoMenuClosesWhenTappingOutsideCanvas()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickDrawingIconInNotebook();
                AutomationAgent.Click(1150, 400);
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyUndoRedoSubMenu(), "No sub menu found");
                NotebookCommonMethods.ClickUndoIconInNotebook();
                AutomationAgent.Click(1150, 400);
                Assert.IsFalse(NotebookCommonMethods.VerifyUndoRedoSubMenu(), "No sub menu found");
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand Icon Not Highlighted");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(19315)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosMoveDesmosInNotebook()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not present in Notebook");
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(937, 166);
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(), "Text Region DeleteX Icon is not present in Notebook");
                string DesmosPosBefore = NotebookCommonMethods.GetDesmosCoordinate();
                NotebookCommonMethods.MoveDesmosInNoteBook();
                string DesmosPosAfter = NotebookCommonMethods.GetDesmosCoordinate();
                Assert.AreNotEqual<string>(DesmosPosBefore, DesmosPosAfter, "Desmos Pos Before And Desmos Pos After Are Same");
               // NotebookCommonMethods.TapOnScreen(837, 166);
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
        [TestCategory("NotebookTests")]
        [WorkItem(19316)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosDeleteDesmosInNotebook()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Not PresentIn The Notebook");
                Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(), "TextRegion DeleteXIcon Is Not Present");
                NotebookCommonMethods.ClickTextRegionDeleteXIcon();
                Assert.AreEqual(false, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Present In Notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19318)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void UndoMoveImageInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Not Present In The Notebook");
                Assert.AreEqual(true, NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(), "TextRegion DeleteXIcon Is Not Present");
                string DesmosPosBeforeUndo = NotebookCommonMethods.GetDesmosCoordinate();
                NotebookCommonMethods.MoveDesmosInNoteBook();
                string DesmosPosBeforeRedo = NotebookCommonMethods.GetDesmosCoordinate();
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickUndoIconInNotebook();
                string DesmosPosAfterUndo = NotebookCommonMethods.GetDesmosCoordinate();
                Assert.AreEqual<string>(DesmosPosBeforeUndo, DesmosPosAfterUndo, "Desmos positions not same");
                NotebookCommonMethods.ClickRedoIconInNotebook();
                string DesmosPosAfterRedo = NotebookCommonMethods.GetDesmosCoordinate();
                Assert.AreEqual<string>(DesmosPosBeforeRedo, DesmosPosAfterRedo, "Desmos Pos Before And Desmos Pos After Are Not Same");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19319)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosUndoRedoDeleteDesmosInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionDeleteXIconPresent(), "Text region delete X icon not found");
                NotebookCommonMethods.ClickTextRegionDeleteXIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos present in notebook");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickUndoIconInNotebook();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
              //  NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos not found");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickRedoIconInNotebook();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos present in notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19320)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosUndoRedoSaveDesmosInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Not Present In The Notebook");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickUndoIconInNotebook();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Present In The Notebook");
                NotebookCommonMethods.ClickRedoIconInNotebook();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
               // NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Not Present In The Notebook");
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(18616)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookDefaultTitle()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("M/d/yyyy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.ClickOnCreatePersonalNoteCancel();
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18617)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookUserCanChangeDefaultTitle()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("M/dd/yy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.SetNameToPersonalNote("MyTitle");
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup().Contains("MyTitle"), "Title not modified");
                NotebookCommonMethods.ClickOnCreatePersonalNoteCancel();
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18620)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookCreateButtonDisabledAndEnabledWhenTextEntered()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("M/dd/yy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.SetNameToPersonalNote(" ");
                Assert.IsFalse(NotebookCommonMethods.VerifyCreateButtonPersonalNotesEnabled(), "Create Button Enabled");
                NotebookCommonMethods.SetNameToPersonalNote("MyTitle ");
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup().Contains("MyTitle"), "Title not modified");
                Assert.IsTrue(NotebookCommonMethods.VerifyCreateButtonPersonalNotesEnabled(), "Create Button disabled");
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(), "New Personal Note not created");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18622)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookEnterCreationDialogAndConfirm()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("M/dd/yy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(), "Personal Note is not found");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18623)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreatePersonalNotebookEnterCreationDialogAndCancel()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("M/dd/yy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.ClickOnCreatePersonalNoteCancel();
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(), "Personal Note is not found");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18632)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenExistingPersonalNotebookChangeTitleAndConfirm()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("M/dd/yy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(), "Personal Note not found");

                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.OpenExistingPersonalNote();

                NotebookCommonMethods.EditPersonalNotesTitle("MyTitle");
                Assert.IsTrue(NotebookCommonMethods.VerifyNewPersonalNotesTitle().Contains("MyTitle"), "Title doesnot got modified");
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
        [TestCategory("NotebookTests")]
        [WorkItem(18633)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void EditExistingPersonalNotebookTitleChangeTitleAndConfirmByTappingOutsideTitleBar()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.OpenExistingPersonalNote();
                NotebookCommonMethods.EditPersonalNotesTitle("MyTitle");
                AutomationAgent.Click(1300, 400);
                Assert.IsTrue(NotebookCommonMethods.VerifyNewPersonalNotesTitle().Contains("MyTitle"), "Title doesnot got modified");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20151)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreateNewPersonalNotebookUserIsAbleToClearTitleUsingXIcon()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string CurrentDateTime = DateTime.Now.ToString("dd/M/yyyy h:mm:ss");
                CurrentDateTime = CurrentDateTime.Remove(CurrentDateTime.Length - 2, 2);
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(NotesDefaultTitle.Contains("My Personal Note " + CurrentDateTime), "Title incorrect");
                NotebookCommonMethods.ClickXIconNewPersonalNote();
                string NotesTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                Assert.IsTrue(string.IsNullOrEmpty(NotesTitle), "Title not empty");
                NotebookCommonMethods.ClickOnCreatePersonalNoteCancel();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18634)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void EditExistingPersonalNotebookTitleClearTitleAndAttemptToSaveIt()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                AutomationAgent.Wait();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.OpenExistingPersonalNote();
                string NotesTitleOld = NotebookCommonMethods.VerifyNewPersonalNotesTitle();
                NotebookCommonMethods.ClickXIconInNotebookTitle();
                string NotesTitle = NotebookCommonMethods.VerifyNewPersonalNotesTitle();
                Assert.IsTrue(string.IsNullOrEmpty(NotesTitle), "Title is not cleared");
                AutomationAgent.Click(1300, 400);
                Assert.IsTrue(NotebookCommonMethods.VerifyNewPersonalNotesTitle().Contains(NotesTitleOld), "Title does not contain default text");
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22625)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BrowseNotesOverlayOverlayHeaderGoToWorkBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyGoToWorkBrowserButtonPresent(), "Go to Work Browser Button Not present");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "Work Browser Not opened");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20517)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyNotebookPagination()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                //NotebookCommonMethods.ClickEraseIconInNotebook();
                //NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddNewNotebookPage();

                AutomationAgent.Wait(1000);
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickLeftArrowIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(), "Left Arrow not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(), "Right Arrow not found");
                AutomationAgent.Wait(500);
                NotebookCommonMethods.ClickLeftArrowIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(), "Left Arrow found");
                Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(), "Right arrow not found");
                NotebookCommonMethods.ClickRightArrowIcon();
                AutomationAgent.Wait(1000);
                NotebookCommonMethods.ClickRightArrowIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(), "Left arrow not found");
                Assert.IsFalse(NotebookCommonMethods.VerifyRightArrowExists(), "Right Arrow found");
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16218)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NativeNotebookVerifyMessageContentAfterTakingSnapshot()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.OpenSnapShot();
                NotebookCommonMethods.VerifySnapShotGridPresent();
                NotebookCommonMethods.ClickCaptureSnapShot();
                //Assert.IsTrue(NotebookCommonMethods.VerifySnapshotSavedMessage(), "Saving message not found");
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.ClickMultimediaIcon();
                NotebookCommonMethods.ClickOnSnapShotIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Thumbnail doesn't exists");
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

       
        [WorkItem(23269)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesEditNotebookInteractiveNewStateReplacesTheOldOne()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.Lesson);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyAlertMessageforConfirmationOfNewInteractive(), "AlertMessageforConfirmationOfNewInteractive Is Not Present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationOfNewInteractive();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");

                string TextBefore = NotebookCommonMethods.GetInteractiveModifiedTime();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                NotebookCommonMethods.WaitforInteractive();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook());
                string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime();
                Assert.AreNotEqual(TextBefore, TextAfter);
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
        [TestCategory("NotebookTests")]
        [WorkItem(23270)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesTimeStampIsUpdatedWhenEditsAreMade()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyAlertMessageforConfirmationOfNewInteractive(), "AlertMessageforConfirmationOfNewInteractive Is Not Present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationOfNewInteractive();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                string TextBefore = NotebookCommonMethods.GetInteractiveModifiedTime();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                //Assert.AreEqual(false, NotebookCommonMethods.VerifyNotebookOpen(), "Notebook Is opened");
                NotebookCommonMethods.WaitforInteractive();
                //Assert.AreEqual(true, NotebookCommonMethods.VerifyNewInteractivePagePresent(), "NewInteractive Is Not Present");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                //NotebookCommonMethods.ClickOnInteractiveThumbnail();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                string TextAfter = NotebookCommonMethods.GetInteractiveModifiedTime();
                Assert.AreNotEqual(TextBefore, TextAfter);
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
        [TestCategory("NotebookTests")]
        [WorkItem(19317)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosEditDesmosInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos(), "Alert message not found");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos not found");
                string TextBefore = NotebookCommonMethods.GetDesmosModifiedTime();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                // Assert.IsFalse(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook opened");
                NotebookCommonMethods.EditDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Desmos page not found");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Desmos page not found");
                Assert.IsFalse(NotebookCommonMethods.VerifySendToNotebookIconPresent(), "Sen to notebook icon found");
                NotebookCommonMethods.EditDesmos();
                AutomationAgent.Wait(60000);
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos not found");
                string TextAfter = NotebookCommonMethods.GetDesmosModifiedTime();
                Assert.AreNotEqual(TextBefore, TextAfter, "Modified date time is same");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23262)]
        [Priority(2)]
        [Owner("Anshul Mudgal(asnhul.mudgal)")]
        public void SavingInteractiveToNotebookDoesntAffectLessonInteractiveState()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyAlertMessageforConfirmationOfNewInteractive(), "AlertMessageforConfirmationOfNewInteractive Is Not Present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationOfNewInteractive();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                string TextBefore = NotebookCommonMethods.GetInteractiveModifiedTime();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                //Assert.AreEqual(false, NotebookCommonMethods.VerifyNotebookOpen(), "Notebook Is Open");
                NotebookCommonMethods.WaitforInteractive();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyNewInteractivePagePresent(), "NewInteractivePage Is Not Present");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                string TextAfter = NotebookCommonMethods.GetInteractiveModifiedTime();
                Assert.AreNotEqual(TextBefore, TextAfter);
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(6);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyAlertMessageforConfirmationOfNewInteractive(), "AlertMessageforConfirmationOfNewInteractive Is Not Present");                      
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationOfNewInteractive();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                NotebookCommonMethods.WaitforInteractive();
                string DtCurrent = DateTime.Now.ToString("h:mmtt").ToLower();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                string TextInteractive = NotebookCommonMethods.getImageTitle();
                string TimeInteractive = NotebookCommonMethods.GetInteractiveModifiedTime();
                Assert.AreEqual(true, TextInteractive.Contains("Interactive: How Many Solutions?"), "Interactive Text is not correct");
                Assert.AreEqual(true, TimeInteractive.Contains(DtCurrent), "Interactive Date is not correct");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23263)]
        [Priority(2)]
        [Owner("Anshul Mudgal(asnhul.mudgal)")]
        public void SavingInteractivesCloseInteractiveOpenedFromNotebookInHalfScreenMode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyAlertMessageforConfirmationOfNewInteractive(), "AlertMessageforConfirmationOfNewInteractive Is Not Present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationOfNewInteractive();
                Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                NotebookCommonMethods.ClickOnInteractiveThumbnail();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(), "Notebook Doesn't Split LessonWindow");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23268)]
        [Priority(2)]
        [Owner("Anshul Mudgal(asnhul.mudgal)")]
        public void SavingInteractivesInteractiveStateIsRestoredOnDifferentDevice()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not present");
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.EditDesmos();
                string DtCurrent = DateTime.Now.ToString("h:mmtt").ToLower();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickonPanModeBtn();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not present");
                string TextDesmo = NotebookCommonMethods.getImageTitle();
                string TimeDesmo = NotebookCommonMethods.GetDesmosModifiedTime();
                Assert.AreEqual(true, TextDesmo.Contains("Desmos: Interactive: Graphing Calculator"), "text is incorrect");
                Assert.AreEqual(true, TimeDesmo.Contains(DtCurrent), "Time stamp is incorrect");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23258)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivesInteractiveRegionIsNOTResizable()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.TapOnScreen(1256, 178);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present InNotebook");
                int widthBefore = NotebookCommonMethods.GetWidthOfImageThumbnail();
                NotebookCommonMethods.ResizeImageInNoteBook();
                int widthAfter = NotebookCommonMethods.GetWidthOfImageThumbnail();
                Assert.AreEqual<int>(widthBefore, widthAfter, "Width of thumbnail not equal");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23272)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesVerify3dInteractiveSnapshotIsGenericImage()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.EditDesmos();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos(), "AlertMessage For New Desmos is not present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(false, NotebookCommonMethods.VerifyNewDesmosPagePresent(), "New Desmos Page Is Present");
                Assert.AreEqual(true, NotebookCommonMethods.VerifyNotebookOpen(), " Notebook Is Not Opened");
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Desmos Is Not At The Center Of Notebook");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(23168)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesUndoRedoMoveInteractiveRegion()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Not Present In Notebook");
                string DesmosPosBeforeUndo = NotebookCommonMethods.GetDesmosCoordinate();
                NotebookCommonMethods.MoveDesmosInNoteBook();
                string DesmosPosBeforeRedo = NotebookCommonMethods.GetDesmosCoordinate();
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                NotebookCommonMethods.ClickUndoIconInNotebook();
                string DesmosPosAfterUndo = NotebookCommonMethods.GetDesmosCoordinate();
                Assert.AreEqual(DesmosPosBeforeUndo, DesmosPosAfterUndo, "Desmos position not same");
                NotebookCommonMethods.ClickRedoIconInNotebook();
                NotebookCommonMethods.ClickHandIconInNotebook();
                AutomationAgent.Wait(1000);
                string DesmosPosAfterRedo = NotebookCommonMethods.GetDesmosCoordinate();
                Assert.AreEqual(DesmosPosBeforeRedo, DesmosPosAfterRedo, "Desmos position not same");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23273)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesSaveMultipleLessonInteractivesToSameNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));

                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                int firstPage = NotebookCommonMethods.GetNotebookPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.EditDesmos();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsFalse(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "New desmos page not found");
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.EditDesmos();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                int newPage = NotebookCommonMethods.GetNotebookPage();
                Assert.AreEqual(newPage, (firstPage + 1), "Page no not same");
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Desmos not at center");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickHandIconInNotebook();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(23274)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void SavingInteractivesSavedInteractivePlacedInNewlyAddedPageAfterLastActiveOne()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                int CurrentPageNo = NotebookCommonMethods.GetNotebookPage();
                int i = CurrentPageNo;
                for (; i <= 3; i++)
                {
                    if (i != CurrentPageNo)
                    {
                        NotebookCommonMethods.AddNewNotebookPage();
                    }
                    NotebookCommonMethods.ClickDrawingIconInNotebook();
                    NotebookCommonMethods.TapOnScreen(1250, 650);
                }
                NotebookCommonMethods.ClickLeftArrowIcon();
                //NotebookCommonMethods.ClickOnNotebookIcon();
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                InteractiveCommonMethods.ClickSendToNotebookIcon();
                InteractiveCommonMethods.ClickContinueInSaveInteractiveAlert();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Interactive not at center of the notebook");
                string PageNoWithCurrentPage = NotebookCommonMethods.GetNoteBookPageNosWithCurrentPage();
                Assert.IsFalse(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "New Desmos Page Is Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook is not opened");
                //Assert.AreEqual(PageNoWithCurrentPage, (i - 2).ToString());
                Assert.AreEqual(PageNoWithCurrentPage, (i - 1).ToString());
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Desmos Is Not At The Center Of Notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(15965)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenNotebookFromMathLesson()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                Assert.IsTrue(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(taskInfo.TaskNumber), "Open notebook button not found");
                    NotebookCommonMethods.ClickOnOpenNotebookButton(taskInfo.TaskNumber);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSplitsLessonWindow(), "Notebook does not splits Lesson window");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookIconPresent(), "Notebook Icon not found");
                //Assert.IsFalse(NotebookCommonMethods.VerifyOpenNotebookButtonPresent(taskInfo.TaskNumber), "Open notebook button found");
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16002)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InsertExistingVideoFromCameraRollShorterIntoBlankNotebook()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                    NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                    AutomationAgent.Wait();
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                    AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoWaterMark(), "Video Water Mark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16010)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NativeNotebookVideoThumbnailDisplayedInNotebookAfterUserAddsVideo()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                   NavigationCommonMethods.LoginApp(login);
                   NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                   NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                    AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16013)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NativeNotebookHandModeActiveAfterVideoHasBeenInserted()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand icon not active");
                    NotebookCommonMethods.AddVideoInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand icon not active");
                    AutomationAgent.Click(1150, 400);
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16014)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NativeNotebookVideoShouldPlayAfterTapPlayButton()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                    AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail Not found");
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(), "Video functionalities not found");
                    LessonBrowserCommonMethods.ClickToCloseVideo();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16007)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VideoShouldStopPlayingWhenFinishesNotebook()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                    NotebookCommonMethods.ClickOnVideoPlayButtonInNotebook();
                    Assert.IsTrue(LessonBrowserCommonMethods.VerifyVideoFunctionalities(), "Video functionalities not found");
                    NotebookCommonMethods.WaitforVideoToFinish();
                    Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook not opened");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16012)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NativeNotebookInsertedVideoCantBeResize()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                    AutomationAgent.Wait();
                    int VideoWidthBefore = NotebookCommonMethods.GetWidthOfVideoInNotebook();
                    NotebookCommonMethods.ResizeVideo();
                AutomationAgent.Wait(500);
                    int VideoWidthAfter = NotebookCommonMethods.GetWidthOfVideoInNotebook();
                Assert.AreEqual(VideoWidthBefore, VideoWidthAfter, "Video width different");
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
        [TestCategory("NotebookTests")]
        [WorkItem(16004)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InsertExistingVideoLongerThan1minIntoBlankNotebook()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
               if( NotebookCommonMethods.VerifyVideoTooLongWarningPopup())
                    NotebookCommonMethods.ClickContinueOnWarningPopup();
 
                    AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoWaterMark(), "Video Watermark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16009)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void PressingHOMEButtonDuringInsertingTakenVideo()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                   //TO DO - Put app in Background
                    //notebookAutomationAgent.SendText("{HOME}");
                    AutomationAgent.Wait();
                    AutomationAgent.LaunchApp();
                    AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoWaterMark(), "Video Watermark not found");
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        //[TestCategory("NotebookTests")]
        //[WorkItem(16011)]
        //[Priority(1)]
        //[Owner("Madhav Purohit(madhav.purohit)")]
        //public void OverlappingVideo()
        //{
        //        try
        //        {
        //            NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        //            NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(9, 1, 2, 4);
        //            NotebookCommonMethods.ClickOnNotebookIcon();
        //            NotebookCommonMethods.ClickEraseIconInNotebook();
        //            NotebookCommonMethods.ClickClearPage();
        //            NotebookCommonMethods.AddVideoInNotebook();
        //            notebookAutomationAgent.Sleep();
        //            Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent, "0"));
        //            Assert.AreEqual<bool>(true, CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent));
        //            string VideoPos1 = NotebookCommonMethods.GetPositionOfVideo(notebookAutomationAgent);
        //            Assert.AreEqual(true, NotebookCommonMethods.VerifyVideoAtCenterOfNotebook(notebookAutomationAgent));
        //            NotebookCommonMethods.AddVideoInNotebook(notebookAutomationAgent, false);
        //            notebookAutomationAgent.Sleep();
        //            Assert.AreEqual<bool>(true, NotebookCommonMethods.VerifyVideoThumbnailFound(notebookAutomationAgent, "1"));
        //            Assert.AreEqual<bool>(true, CommonReadCommonMethods.VerifyVideoWaterMark(notebookAutomationAgent));
        //            string VideoPos2 = NotebookCommonMethods.GetPositionOfVideo(notebookAutomationAgent);
        //            Assert.AreEqual(true, NotebookCommonMethods.VerifyVideoAtCenterOfNotebook(notebookAutomationAgent));

        //            Assert.AreEqual(VideoPos1, VideoPos2);
        //            NotebookCommonMethods.ClickEraseIconInNotebook(notebookAutomationAgent);
        //            NotebookCommonMethods.ClickClearPage(notebookAutomationAgent);
        //            NotebookCommonMethods.ClickOnNotebookIcon(notebookAutomationAgent);
        //            if (bool.Parse(ConfigurationManager.AppSettings["UnitTestExecution"].ToString()) ||
        //                        NavigationCommonMethods.GetTaskPageNumberInLesson(notebookAutomationAgent) != 4)
        //            {
        //                NavigationCommonMethods.Logout(notebookAutomationAgent);
        //            }
        //        }
        //        catch (AssertFailedException Ex)
        //        {
        //            string msg = Ex.Message;
        //            Logger.InsertExceptionMessage(msg);
        //            throw;
        //        }
        //        catch (Exception Ex)
        //        {
        //            string msg = Ex.Message;
        //            Logger.InsertExceptionMessage(msg);
        //            throw;
        //        }
        //}



        [TestMethod()]
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16019)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void RedoDeletedVideo()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.AddVideoInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail not found");
                    AutomationAgent.Wait(500);
                  //  NotebookCommonMethods.TapOnScreen(1206, 652);
                    NotebookCommonMethods.ClickOnXIcon();
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail found");
                    NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                    NotebookCommonMethods.ClickUndoIconInNotebook();
                    Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail not found");
                    Assert.IsTrue(NotebookCommonMethods.VerifyRedoButtonEnabled(), "Redo button enabled");
                    NotebookCommonMethods.ClickRedoIconInNotebook();
                    Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail found");
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
        //[TestCategory("NotebookTests")]
        //[WorkItem(16001)]
        //[Priority(1)]
        //[Owner("Madhav Purohit(madhav.purohit)")]
        //public void VerifyVideoPopupInNotebook()
        //{
        //    try
        //    {
        //        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        //        NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(9, 1, 1, 2);
        //        NotebookCommonMethods.ClickOnOpenNotebookButton();
        //        NotebookCommonMethods.ClickEraseIconInNotebook();
        //        NotebookCommonMethods.ClickClearPage();
        //        NotebookCommonMethods.ClickOnImageIcon();
        //        NotebookCommonMethods.VerifyCameraAndPhotosMenu();
        //        NotebookCommonMethods.ClickEraseIconInNotebook();
        //        NotebookCommonMethods.ClickClearPage();
        //        NotebookCommonMethods.AddVideoInNotebook();
        //        notebookAutomationAgent.Sleep();
        //        Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound());
        //        NotebookCommonMethods.ClickEraseIconInNotebook();
        //        NotebookCommonMethods.ClickClearPage();
        //        NotebookCommonMethods.AddImageInNoteBook();
        //        NotebookCommonMethods.ClickOnImageInNotebook();
        //        Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists());
        //        NotebookCommonMethods.ClickEraseIconInNotebook();
        //        NotebookCommonMethods.ClickClearPage();
        //        NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22626)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BrowseNotesOverlayHeaderHeadingIsBrowseNotes()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowserOverlay is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyOverlayHeading(), "OverlayHeading is Not on center");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(23166)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifytheTitlethumbnailandTimestampoftheinteractiveregioninthenotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present In Notebook");
                Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Desmos Is Not At The Center Of Notebook");
                string DtCurrent = DateTime.Now.ToString("h:mmtt").ToLower();
                string TextDesmo = NotebookCommonMethods.getImageTitle();
                string TimeDesmo = NotebookCommonMethods.GetDesmosModifiedTime();
                Assert.AreEqual(true, TextDesmo.Contains("Interactive: How Many Solutions?"));
                Assert.AreEqual(true, TimeDesmo.Contains(DtCurrent));
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
        [TestCategory("NotebookTests")]
        [WorkItem(23257)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifySavingInteractiveshandmodeisdefaultaftersavinginteractivetoNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present In Notebook");
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Desmos Is Not At The Center Of Notebook");
                Assert.IsFalse(NotebookCommonMethods.VerifyNewInteractivePagePresent(), "NewInteractivePagePresent is Present");
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosAtCenterOfNotebook(), "Desmos Is Not At The Center Of Notebook");
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "HandIconActiveHighlight is Not Active");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23264)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SavingInteractivescloseinteractiveopenedfromNotebookinfullscreenmode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Interactive");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Interactive"));
                NavigationCommonMethods.ClickOnInteractiveThumbnailMathTask(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.AreEqual(true, NotebookCommonMethods.VerifyInteractiveIsPresentInNotebook(), "Interactive Is Not Present In Notebook");
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.EditDesmos();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                Assert.IsFalse(NotebookCommonMethods.VerifyNewInteractivePagePresent(), "NewInteractivePagePresent is Present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(16027)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void NativeNotebookSavingChangesAfterCloseReopen()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos Is Not Present In The Notebook");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Notebook Is Not In Closed State");
                NotebookCommonMethods.ClickOnNotebookIcon();
               // NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Saved Changes Are Not Present In Notebook");
                NotebookCommonMethods.ClickOnGraphButton();
                NotebookCommonMethods.ClickOnViennDiagram();
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Notebook Is Not In Closed State");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyViennDiagramPresent(), "Saved Changes Are Not Present");
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Saved Changes Are Not Present In Notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20800)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GlobalNavVerifyViewInLessonButtonFunctionality()
        {
            try
            {

                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(), "Work Browser Page Is Not Opened");
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyWorkBrowserViewInLesson(), "ViewInLesson Is Not Present In Notebook WorkBrowser");
                WorkBrowserCommonMethods.ClickOnViewInLessonButton();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonOpenedToRead(), "Lesson Is Not Opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyNoteBookOpenedInLesson(), "NoteBook Is Not Opened In Lesson");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20522)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void VerifyViewInLessonButtonIsNotPresentForPersonalNotebook()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                NotebookCommonMethods.EditPersonalNotesTitle("MyPersonalNote");
                AutomationAgent.Click(1300, 400);
                NavigationCommonMethods.NavigateWorkBrowser();
                AutomationAgent.Wait();
                Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(), "WorkBrowser Page Is Not Available");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnPersonalNotes();
                NotebookCommonMethods.TapOnScreen(422, 733);
                WorkBrowserCommonMethods.ClickOnOpenPersonalNote();
                Assert.AreEqual(false, WorkBrowserCommonMethods.VerifyViewInLessonButtonInWorkBrowser(), "ViewInLesson Is  Present In Notebook WorkBrowser");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19321)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void DesmosSaveMultipleDesmosInNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                string PosDesmos1 = null;
                int widthDesmos1 = 0;
                for (int i = 1; i < 4; i++)
                {
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    NotebookCommonMethods.ClickOnGraphicTool();
                    NotebookCommonMethods.ClickOnSendToNotebookIcon();
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                    //NotebookCommonMethods.ClickOnDesmosThumbnail();
                    Assert.AreEqual(true, NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Demos Is Not Present In Notebook");
                    if (i == 1)
                    {
                        PosDesmos1 = NotebookCommonMethods.GetDesmosCoordinate();
                        widthDesmos1 = NotebookCommonMethods.GetWidthOfDesmos();
                    }
                    //string taskName = NotebookCommonMethods.GetTaskName();
                    //int indexOfBracket = taskName.IndexOf("(");
                    //string pageNumber = taskName.Substring(indexOfBracket).TrimEnd().Replace(" ", "");
                   // Assert.AreEqual<string>(pageNumber, "(" + i + "/" + i + ")");
                    if (i != 1)
                    {
                        string PosDesmos = NotebookCommonMethods.GetDesmosCoordinate();
                        int widthDesmos = NotebookCommonMethods.GetWidthOfDesmos();
                        Assert.AreEqual(PosDesmos, PosDesmos1);
                        Assert.AreEqual(widthDesmos, widthDesmos1);
                        Assert.IsTrue(NotebookCommonMethods.VerifyDeleteIconEnabled(), "delete icon not enabled");
                    }
                }
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22627)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void BrowseNotesOverlayOverlayHeaderCloseOverlay()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(), "Browser Note close button not found");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
                //Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22549)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void GeneralVerifylayout()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyBrowserNoteXButtonAtTopLeft(), "Browser Note Close Button Is Not At The Top Left");
                Assert.IsTrue(NotebookCommonMethods.VerifyGoToWorkBrowserButtonAtTopRight(), "GoTo WorkBrowser Button Is Not At The Top Right");
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNotesButtonPresent(), "Personal Notes Tab Is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyTaskNotebooksButtonIsActive(), "TaskNotebooks Button Is Not Active");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebooksViewHeaderDisplaysFullLessonTitle(), "FullLesson Title Is Not Displayed");
                Assert.IsTrue(NotebookCommonMethods.VerifyMYNoteBookHeading(), "MYNoteBook Tile Is Not Available");
                Assert.IsTrue(NotebookCommonMethods.VerifySharedNoteBooksHeading(), "Shared Notebooks Title Is Not Available");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();               
                Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(28346)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void EditingVocabularyNotebookTitle()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                string title = "MyPersonalNoteTitle";
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                NotebookCommonMethods.PopulatePersonalNotesEditMenu();
                Assert.IsTrue(NotebookCommonMethods.VerifyEditMenuOptions(), "EditMenu Options Not Avaialable");
                NotebookCommonMethods.TapOnScreen(1000, 500);
                NotebookCommonMethods.EditPersonalNotesTitle(title);
                NotebookCommonMethods.TapOnScreen(1000, 500);
                string NotebookTitle = NotebookCommonMethods.GetPersonalNotebookTitle();
                Assert.AreEqual(title, NotebookTitle, "Title entered is not displayed");
                NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22552)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void MyNotebookOpenMyNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
               // NotebookCommonMethods.ClickOnNoteBookBrowser();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Not Present");                
                Assert.IsTrue(NotebookCommonMethods.VerifyMYNoteBook(), "MyNoteBook Is Not Available");                
                NotebookCommonMethods.TapOnScreen(244, 478);
                AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook Is Opened");
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyLessonOpenedToRead(), "Lesson Task Is Not Opened");
                Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22461)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ELAMATHforStudent()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "Overlay is Not Present");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(), "WorkBrowser Page is Not Present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22463)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ELAMATHforTeacher()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay is Not present");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
                Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(), "WorkBrowser Page is Not Open");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20399)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void verifymultipleimagesaddedonmultiplepages()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "No Photo Exists");
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "No Photo Exists");
                NotebookCommonMethods.ClickLeftArrowIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "No Photo Exists");
                NotebookCommonMethods.ClickRightArrowIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "No Photo Exists");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22550)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void OnlyoneMyNotebookExistspertask()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(), "Browser Note close button not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyMYNoteBook(), "No MyNoteBook");
                Assert.IsTrue(NotebookCommonMethods.verifyNoteBookTile(1), "No My NoteBook Tile");
                Assert.IsFalse(NotebookCommonMethods.verifyNoteBookTile(2), "Second My NoteBook Tile found");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22603)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenoverlaywhentherearenoreceivedNotebooks()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyBrowserNoteXButtonPresent(), "Browser Note close button not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyReceivedNotebookssectionlayout(), "No Received NoteBook section");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22171)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SingleButtonSentOrReceivedCenteredAcrossBottomTile()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.ClickSentInNotbookBottomTile("Unsuccessful Steps for Outsiders");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentWorkLabelCentered(), "SentWork Label not in center");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43553)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenUserTapsContinueThenToolClosesAndSnapshotSaves()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Wrench Tool graphing submenu not present");
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos thumbnail not present");
                Assert.IsFalse(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Wrench Tool graphing submenu still present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43545)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenUserTapsSaveToNotebookIconThenAlertMessageAppears()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.IsTrue(InteractiveCommonMethods.VerifySaveInteractiveAlert(), "Save Interactive Alert Box not present");
                NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationOfNewInteractive();
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
        [TestCategory("NotebookTests")]
        [WorkItem(43554)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenUserTapsCancelInAlertThenAlertGetsClosed()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                Assert.IsTrue(InteractiveCommonMethods.VerifySaveInteractiveAlert(), "Save Interactive Alert Box not present");
                NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos();
                Assert.IsFalse(InteractiveCommonMethods.VerifySaveInteractiveAlert(), "Save Interactive Alert Box still present");
                NotebookCommonMethods.EditDesmos();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos thumbnailnot present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43544)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TwoIconAppearsOnChromeBar()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                Assert.IsTrue(NotebookCommonMethods.VerifyDoneCloseButton(), "Done Close Button not present");
                Assert.IsTrue(NotebookCommonMethods.VerifySendToNotebookIconPresent(), "Send To notebook icon not present");
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22054)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void VerifyAlertMessageCancelOrContinue()
        {
            try
            {
                string string1 = "First Page";
                string string2 = "Second Page";
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string1);
                string words = NotebookCommonMethods.GetTextInTextZone();
                Assert.IsTrue(words.Contains(string1), "First Page Text is not present");
                NotebookCommonMethods.TapOnScreen(1200, 300);
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string2);
                string words1 = NotebookCommonMethods.GetTextInTextZone();
                Assert.IsTrue(words1.Contains(string2), "Second Page Text is not present");
                NotebookCommonMethods.TapOnScreen(1200, 300);
                NotebookCommonMethods.ClickDeleteIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDeleteOptions(), "Delete Options Cancel and Delete Page are not present");
                NotebookCommonMethods.ClickDeletePage();
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
        [TestCategory("NotebookTests")]
        [WorkItem(43588)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ToolsSavedToNotebookHaveDoneButton()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.EditDesmos();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyDoneCloseButton(), "Done Close Button is not present");
                Assert.IsFalse(TeacherModeCommonMethods.VerifyTeacherGuideIcon(), "Teacher Guide is still present");
                NotebookCommonMethods.ClickOnDoneCloseButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(43541)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void MathToolsMenuDisabledInELA()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyWrenchIconActive(), "Wrench icon is still active");
                NotebookCommonMethods.ClickOnWrenchIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Graphing Submenu of wrench Icon still present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43555)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ToolNameAndTimeStampAppearBelowToolSnapshot()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                string DtCurrent = DateTime.Now.ToString("h:mmtt").ToLower();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos snapshot not present in the notebook");
                string TextInteractive = NotebookCommonMethods.getImageTitle();
                string TimeInteractive = NotebookCommonMethods.GetInteractiveModifiedTime();
                Assert.IsTrue(TextInteractive.Contains("Desmos: Interactive: Graphing Calculator"), "Interactive Text is not correct");
                string DtCurrent1 = DateTime.Now.ToString("h:mmtt").ToLower();
                if (! (TimeInteractive.Contains(DtCurrent) || TimeInteractive.Contains(DtCurrent1)))
                   Assert.Fail("Interactive Date is not correct");
               
                
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

        //[TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(43589)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void DoneSavesStateOfTool()
        {
            try
            {
                string title = "Table";
                string title1 = "Table1";
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickMathTableToolMenu();
                NotebookCommonMethods.EditTitleOfMathTable(title);
                NotebookCommonMethods.ClickOnSendToNotebookIcon();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                string tableTitle = NotebookCommonMethods.GetMathTableTitle();
                Assert.AreEqual(title, tableTitle, "Titles are not same");
                NotebookCommonMethods.EditTitleOfMathTable(title1);
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                NotebookCommonMethods.ClickOnDesmosThumbnail();
                string tableTitle1 = NotebookCommonMethods.GetMathTableTitle();
                Assert.AreEqual(title1, tableTitle1, "Titles are not same");
                NotebookCommonMethods.ClickOnDoneCloseButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16018)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void NativeNotebookUndoDeletedVideo()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddVideoInNotebook();
                AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail not found");
                NotebookCommonMethods.ClickOnXIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail still present");
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyUndoIconActive(), "Undo Icon not active");
                NotebookCommonMethods.ClickUndoIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video thumbnail not found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(19312)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void GraphicCalculatorOpensWhenTappingGraphingCalculator()
        {

            {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    Assert.IsTrue(NotebookCommonMethods.VerifyWrenchIcon(), "WrenchIcon Not Found");
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    Assert.IsTrue(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Graphing Tool menu not present");
                    NotebookCommonMethods.ClickOnGraphicTool();
                    Assert.IsTrue(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Interactive Graphing Calculator Page not opened");
                    NotebookCommonMethods.ClickOnDoneCloseButton();
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                    Assert.IsFalse(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Interactive Graphing Calculator Page still open");
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
        [TestCategory("NotebookTests")]
        [WorkItem(16017)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void NativeNotebookDeletingVideoInHandMode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddVideoInNotebook();
                AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail is not present");
                NotebookCommonMethods.ClickHandIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                Assert.IsFalse(NotebookCommonMethods.VerifyXIcon(), "X icon still present in the Thumbnail");
                NotebookCommonMethods.TapOnScreen(1031, 351);
                Assert.IsTrue(NotebookCommonMethods.VerifyXIcon(), "X icon is not present in the Thumbnail");
                NotebookCommonMethods.ClickOnXIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video Thumbnail is still present");
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickUndoRedoIconInNotebook();
                Assert.IsFalse(NotebookCommonMethods.VerifyUndoIconActive(), "Undo icon is still active");
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(22242)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void NotebookScrolling()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyNotebooksScrollable(), "Only 1 CR present so, its not scrollable");
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
        [TestCategory("NotebookTests")]
        [WorkItem(16001)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void NativeNotebookVideoPopupShouldBeAvailable()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickMultimediaIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyMultimediaMenus(), "Multimedia menus not present");
                NotebookCommonMethods.ClickCameraMenu();
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoPopup(), "Video Popup not present");
                NotebookCommonMethods.ClickMultimediaIcon();
                NotebookCommonMethods.ClickPhotosMenu();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotosPopUp(), "Photos Pop Up not present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20398)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ToVerifyMultipleImagesAddedInSinglePage()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Photo not available");
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Photo not available");
                NotebookCommonMethods.ClickOnXIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Photo not available");
                NotebookCommonMethods.CickOnImageInNotebook();
                NotebookCommonMethods.ClickOnXIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(), "Photo not available");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43540)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenUserTapsContinueOnAlertMessageThenUserQuitsToolWithoutSaving()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnDoneCloseButton();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                Assert.IsFalse(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos thumbnail not present in the notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43539)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void MathToolsMenuGetsClosed()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Wrench Icon sub menu not open");
                //NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickHandIconInNotebook();
                Assert.IsFalse(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Wrench Icon sub menu still open");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20376)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ToVerifyAddingImageFromPhotos()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.AddImageInNoteBook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Photo not available");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43543)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenUserTapsDoneThenAlertMessageAppearsWithTwoOptions()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickOnGraphicTool();
                NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyCloseDesmosAlertPopUp(), "Close Alert Pop Up message not present");
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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
        [TestCategory("NotebookTests")]
        [WorkItem(43542)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void WhenUserTapsCancelOnAlertMessageThenItCloses()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnWrenchIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyWrenchToolGraphingSubMenuExists(), "Wrench Icon submenu doesn't exists");
                NotebookCommonMethods.ClickOnGraphicTool();
                Assert.IsTrue(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Desmos Page not present");
                NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos();
                NotebookCommonMethods.ClickCancelOnAlertMessageforConfirmationNewDesmos();
                Assert.IsTrue(NotebookCommonMethods.VerifyNewDesmosPagePresent(), "Desmos Page not present");
                NotebookCommonMethods.ClickOnDoneButtonNewlyCreateDesmos();
                NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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
        [TestCategory("NotebookTests")]
        [WorkItem(29946)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ResourceLibraryContentPppShouldShowSnapshotToolNoUnusualBehaviors()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.OpenSnapShot();
                    Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent(), "Snapshot grid not present");
                    NotebookCommonMethods.ClickCaptureSnapShot();
                    AutomationAgent.Wait();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnNotebookIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(19314)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosSaveDesmosNotebook()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    NotebookCommonMethods.ClickOnGraphicTool();
                    NotebookCommonMethods.ClickOnSendToNotebookIcon();
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                    Assert.IsTrue(NotebookCommonMethods.VerifyDesmosIsPresentInNotebook(), "Desmos is not present in the notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20465)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ConfirmTheSnapshotToolInTheNavigationBar()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickMultimediaIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifySnapshotInImageMenusActive(), "Snapshot menu still active");
                NotebookCommonMethods.OpenSnapShot();
                NotebookCommonMethods.ClickCaptureSnapShot();
                NotebookCommonMethods.ClickMultimediaIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapshotInImageMenusActive(), "Snapshot menu not active");
                NotebookCommonMethods.ClickOnSnapShotIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Photo doesn't exists");
                //NotebookCommonMethods.ClickEraseIconInNotebook();
                //NotebookCommonMethods.ClickClearPage();
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
        [TestCategory("NotebookTests")]
        [WorkItem(19313)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DesmosCreateNewDesmosPressDone()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickEraseIconInNotebook();
                    NotebookCommonMethods.ClickClearPage();
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    NotebookCommonMethods.ClickOnGraphicTool();
                    NotebookCommonMethods.ClickOnDoneCloseButton();
                    NotebookCommonMethods.VerifyAlertMessageforConfirmationNewDesmos();
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(43587)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserCanDeletePreviouslySavedInteractive()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                    NotebookCommonMethods.ClickOnWrenchIcon();
                    NotebookCommonMethods.ClickOnGraphicTool();
                    NotebookCommonMethods.ClickOnSendToNotebookIcon();
                    NotebookCommonMethods.ClickContinueOnAlertMessageforConfirmationNewDesmos();
                    Assert.IsTrue(NotebookCommonMethods.VerifyHandIconActiveHighlight(), "Hand Icon Is Not Picked");
                    NotebookCommonMethods.TapOnScreen(1200, 700);
                    NotebookCommonMethods.ClickOnDesmosThumbnail();
                    NotebookCommonMethods.ClickOnXIcon();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22606)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyScrollingOverlayWithReceivedNotebooks()
        {
                try
                {
                    Login login = Login.GetLogin("Sec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    NotebookCommonMethods.ClickOnNotebookIcon();
                //NotebookCommonMethods.ClickOnWorkBrowserFolderIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                    LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                    LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                    NotebookCommonMethods.ClickXBrowserNoteXButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16214)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void CancelTheSnapshotToolInTheNavigationBar()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickMultimediaIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifySnapshotInImageMenusActive(), "Snapshot menu still active");
                NotebookCommonMethods.OpenSnapShot();
                NotebookCommonMethods.ClickCancelSnapShot();
                NotebookCommonMethods.ClickMultimediaIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifySnapshotInImageMenusActive(), "Snapshot menu still active");
                NotebookCommonMethods.ClickOnSnapShotIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(), "Photo doesn't exists");
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
        [TestCategory("NotebookTests")]
        [WorkItem(43586)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void UserCanResumeWorkingWithPreviouslySavedInteractive()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickOnWrenchIcon();
                NotebookCommonMethods.ClickMathTableToolMenu();
                NotebookCommonMethods.ChangeTableHeading();
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
        [TestCategory("NotebookTests")]
        [WorkItem(16212)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ResizingMovingTheSnapshotWindow()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.OpenSnapShot();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapShotGridPresent());
               // NotebookCommonMethods.ResizeImageInNoteBook();
                NotebookCommonMethods.SwipeSnapshotGrid();
                // Try to Swipe beyond screen
                NotebookCommonMethods.SwipeSnapshotGrid();
                int gridposnewSwipeBeyondScreen = NotebookCommonMethods.GetSnapshotGridPosition();
                NotebookCommonMethods.SwipeSnapshotGrid();
                int gridposnewSwipeBeyondScreenAgain = NotebookCommonMethods.GetSnapshotGridPosition();
                Assert.AreEqual(gridposnewSwipeBeyondScreenAgain, gridposnewSwipeBeyondScreen, "snapshot grid repositioned above screen size");
                NotebookCommonMethods.ClickCancelSnapShot();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22556)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookTileHeaderContainsTaskTitleAndGreenColourForMath()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                string NotebookTitle = NotebookCommonMethods.GetPersonalNotebookTitle();
                NotebookCommonMethods.NotebookWorkBrowserView();
                string elaTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual(NotebookTitle, elaTaskTitle, "NoteTitle and Ela TaskTitle are not equal");
                Color sampleColor = Color.FromArgb(255, 30, 120, 40);
                Assert.IsTrue(NotebookCommonMethods.VerifyBackgroundColourgreen(sampleColor));
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
        [TestCategory("NotebookTests")]
        [WorkItem(22555)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookTileHeaderContainsTaskTitleAndDarkBlueColourForEla()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                string NotebookTitle = NotebookCommonMethods.GetPersonalNotebookTitle();
               // NotebookCommonMethods.NotebookWorkBrowserView();
                string elaTaskTitle = DashboardCommonMethods.GetLessonBrowserTaskTitle(taskInfo.Lesson);
                Assert.AreEqual(NotebookTitle, elaTaskTitle, "NoteTitle and Ela TaskTitle are not equal");
                Color sampleColor = Color.FromArgb(255, 45, 84, 201);
                //Assert.IsTrue(NotebookCommonMethods.VerifyBackgroundColourBlue(sampleColor));
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
        [TestCategory("NotebookTests"), TestCategory("212SmokeTests")]
        [WorkItem(16003)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InsertVideoTakenDirectlyFromNotebookIntoNotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickMultimediaIcon();
                NotebookCommonMethods.AddVideoInNotebookFromCamera(10000);
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video is not present in notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20388)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyImageResizeAndRepositionAfterTakenThroughCamera()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickMultimediaIcon();
                NotebookCommonMethods.AddImageInNotebookFromCamera();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Image is not present in notebook");
                int widthBefore = NotebookCommonMethods.GetWidthOfImageThumbnail();
                NotebookCommonMethods.ResizeImageInNoteBook();
                int widthAfter = NotebookCommonMethods.GetWidthOfImageThumbnail();
                Assert.AreNotEqual(widthBefore, widthAfter, "Width of Image is same");
                string PosBefore = NotebookCommonMethods.GetImageCoordinate();
                NotebookCommonMethods.MoveImageInNoteBook();
                string PosAfter = NotebookCommonMethods.GetImageCoordinate();
                Assert.AreNotEqual(PosAfter, PosBefore, "Positions of Image is are same");
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Image not found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20387)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyImageDeletionAfterUploadingThroughCamera()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickMultimediaIcon();
                NotebookCommonMethods.AddImageInNotebookFromCamera();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoExists(), "Image is not present in notebook");
                NotebookCommonMethods.DeleteImageFromNotebook();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyPhotoExists(), "Image still present in notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(16005)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InsertVideoTakenFromNotebook60SecondsLimit()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickMultimediaIcon();
                string duration = NotebookCommonMethods.AddVideoFromCameraAndGetVideoDuration(80000);
                Assert.AreEqual(duration, "1:00", "Duration is more than 60 seconds");
                Assert.IsTrue(NotebookCommonMethods.VerifyVideoThumbnailFound(), "Video is not present in notebook");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20191)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void GalleryOneNotebookForAGalleryProblemEvenForMultiTasks()
        {
            try
            {
                string a = "abcd";
                string b = "efgh";
                string c = "efghijkl";
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("Math", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToMath();
                NavigationCommonMethods.NavigateToMathGrade(taskInfo.Grade);
                NavigationCommonMethods.StartMathUnitFromUnitLibrary(taskInfo.Unit + 1);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                NavigationCommonMethods.OpenMathLessonFromLessonBrowser(taskInfo.Lesson + 11);
                NavigationCommonMethods.OpenSingleTaskGalleryProblem();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(a);
                LessonBrowserCommonMethods.ClickGalleryProblemDoneButton();
                NavigationCommonMethods.OpenMultiTaskGalleryProblem();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(b);
                NotebookCommonMethods.TapOnScreen(500, 500);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                NotebookCommonMethods.ClickOnNotebookIcon();
                string words = NotebookCommonMethods.GetTextInTextZone();
                Assert.IsTrue(words.Contains(b));
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(c);
                NotebookCommonMethods.TapOnScreen(500, 500);
                LessonBrowserCommonMethods.SwipeLessonPreviewRight();
                NotebookCommonMethods.ClickOnNotebookIcon();
                string words1 = NotebookCommonMethods.GetTextInTextZone();
                Assert.IsTrue(words1.Contains(c));
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
        [TestCategory("NotebookTests")]
        [WorkItem(20516)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void PageNumberingWorksCorrectlyInNotebookPreviewHeader()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(5);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.CreateNotebookIfNoNotebooksInWorkBrowser(login.GetTaskInfo("ELA", "Notebook"));
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                string pageNo = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual<string>("( 1 / 1 )", pageNo, "Notebook has more than one page");
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddNewNotebookPage();
                AutomationAgent.Wait(200);
                string pageNos = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreNotEqual(pageNo, pageNos, "New Pages are not added in notebook");
                NotebookCommonMethods.ClickLeftArrowIcon();
                NotebookCommonMethods.ClickLeftArrowIcon();
                AutomationAgent.Wait(200);
                string NewpageNo = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual("( 1 / 3 )", NewpageNo, "Page header numbers are not updated");
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
        [TestCategory("NotebookTests")]
        [WorkItem(20518)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyPaginationNumberingInNotebookPreviewFullScreenView()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on dashboard");
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(5);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.CreateNotebookIfNoNotebooksInWorkBrowser(login.GetTaskInfo("ELA", "Notebook"));
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                string pageNo = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual<string>("( 1 / 1 )", pageNo, "Notebook has more than one page");
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddNewNotebookPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyLeftArrowExists(), "Left arrow does not exist");
                NotebookCommonMethods.ClickLeftArrowIcon();
                string pageNo1 = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual<string>("( 2 / 3 )", pageNo1, "Pagination is not in order");
                Assert.IsTrue(NotebookCommonMethods.VerifyRightArrowExists(), "Right arrow does not exist");
                NotebookCommonMethods.ClickRightArrowIcon();
                string pageNo2 = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual<string>("( 3 / 3 )", pageNo2, "Pagination is not in order");
                NotebookCommonMethods.ClickLeftArrowIcon();
                NotebookCommonMethods.ClickLeftArrowIcon();
                AutomationAgent.Wait(200);
                string NewpageNo = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual("( 1 / 3 )", NewpageNo, "Page header numbers are not updated");
                Assert.IsFalse(NotebookCommonMethods.VerifyLeftArrowExists(), "Left Arrow exist");
                NotebookCommonMethods.ClickRightArrowIcon();
                string pageNo3 = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual<string>("( 2 / 3 )", pageNo3, "Pagination is not in order");
                NotebookCommonMethods.ClickRightArrowIcon();
                string pageNo4 = WorkBrowserCommonMethods.GetPageNumberOfNotebook();
                Assert.AreEqual<string>("( 3 / 3 )", pageNo4, "Pagination is not in order");
                NotebookCommonMethods.VerifyPaginationAndArrowsInNotebook();
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
        [TestCategory("NotebookTests")]
        [WorkItem(18625)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CreateNewPersonalNotebookVerifyChromeIconColorOrange()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyPersonalNoteFound(), "Personal Note not found");
                NotebookCommonMethods.ClickPersonalNoteTitle();
                AutomationAgent.Wait(500);
                Color sampleColor = Color.FromArgb(255, 255, 147, 0);
                AutomationAgent.Wait(500);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourOrange(sampleColor), "Notebook Button is not orange");
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
        [TestCategory("NotebookTests")]
        [WorkItem(18627)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenExistingPersonalNotebookColourOrange()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNotesLink();
                NotebookCommonMethods.ClickCreateNoteInPersonalNote();
                string NotesDefaultTitle = NotebookCommonMethods.VerifyPersonalNoteDefaultTitleAndPopup();
                NotebookCommonMethods.ClickPersonalNoteCreateButton();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.ClickPersonalNoteImage();
                AutomationAgent.Wait(500);
                NotebookCommonMethods.ClickPersonalNoteTitle();
                Color sampleColor = Color.FromArgb(255, 255, 147, 0);
                AutomationAgent.Wait(500);
                //Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourOrange(sampleColor), "Notebook Button is not orange");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22557)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MyNotebookTileNoTimeStampDisplayed()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Interactive"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyMYNoteBookHeading(), "MYNoteBook Tile Is Not Available");
                Assert.IsFalse(NotebookCommonMethods.VerifyNoTimestampInNoteWorkBrowseView(), "Time Stamp is found");
                NotebookCommonMethods.ClickGoToWorkBrowserButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22628)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BrowseNotesOverlaySwitchBetweenTaskAndPersonalNotebooks()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "WorkBrowser Overlay Is Not Present");
                Assert.IsTrue(NotebookCommonMethods.VerifyMYNoteBookPosition(), "My NoteBook Tile is not displayed under Task Notebooks");
                Assert.IsFalse(NotebookCommonMethods.VerifyCreateNotePositionPersonalNote(), "Create Note Tile is found under Task Notebooks");
                NotebookCommonMethods.ClickPersonalNotesLink();
                AutomationAgent.Wait(1000);
                Assert.IsTrue(NotebookCommonMethods.VerifyCreateNotePositionPersonalNote(), "Create Note Tile is not found under Personal notes");
                Assert.IsFalse(NotebookCommonMethods.VerifyMYNoteBookPosition(), "My NoteBook Tile is displayed under Personal notes");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22639)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookPreviewInWorkBrowser()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                string NotebookTaskTitle = NotebookCommonMethods.GetPersonalNotebookTitle();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                NotebookCommonMethods.TapOnScreen(157, 74);
                string TaskTileMyWork = NotebookCommonMethods.GetFirstNotebookTaskTitleMyWork();
                bool.Equals(true, TaskTileMyWork.Contains(NotebookTaskTitle));
                Assert.AreEqual(NotebookTaskTitle, TaskTileMyWork, "Created notebook is not showing in my work");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22133)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CommonReadNotebookTitleColourBlue()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                Color sampleColor = Color.FromArgb(255, 0, 50, 195);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourBlueForEla(sampleColor), "Notebook Title Color is not Blue");
                NotebookCommonMethods.ClickOnNotebookIcon();
                CommonReadCommonMethods.ClickOnDoneButton();
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


        /*Network dependent*/
        #region NetworkDependent

        [TestMethod()]
        [TestCategory("NotebookTests")]
        [WorkItem(34177)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ShowSharedHistoryIconInEveryScreenChromeBar()
        {

            {
                try
                {
                    Login login = Login.GetLogin("StudentBruceSec9Apatton");
                    NavigationCommonMethods.LoginApp(login);
                    NavigationCommonMethods.NavigateMyDashboard();
                    Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Page not present");
                    Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Shared Work Notification icon not present");
                    DashboardCommonMethods.ClickOnNotificationIconInChrome();
                    int itemNos = NavigationCommonMethods.GetSharedItemsNumber();
                    for (int i = 1; i <= itemNos; i++)
                    {
                        Assert.IsTrue(NavigationCommonMethods.VerifySharedItems(i), "Shared Items not present");
                    }
                    DashboardCommonMethods.ClickOnNotificationIconInChrome();
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                    Assert.IsTrue(DashboardCommonMethods.VerifySharedWorkNotifications(), "Shared Work Notification icon not present");
                    DashboardCommonMethods.ClickOnNotificationIconInChrome();
                    for (int i = 1; i <= itemNos; i++)
                    {
                        Assert.IsTrue(NavigationCommonMethods.VerifySharedItems(i), "Shared Items not present");
                    }
                    DashboardCommonMethods.ClickOnNotificationIconInChrome();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23360)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void NotebookSharingStudentVerifyYourWorkWasSentAlert()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
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
        [TestCategory("NotebookTests")]
        [WorkItem(23359)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void LogInAsRecipientAndConfirmReceiptOfNotebook()
        {
            try
            {
                string text = "ABCD";
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(text);
                NotebookCommonMethods.ClickShareButton();
                CommonReadCommonMethods.SelectSec34Per5();
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                NotebookCommonMethods.TapOnScreen(157, 74);
                WorkBrowserCommonMethods.ClickToDownloadNotebook();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                string text1 = NotebookCommonMethods.GetTextInTextZone();
                Assert.AreEqual(text1, text);
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
        [TestCategory("NotebookTests")]
        [WorkItem(23161)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SelectingPages()
        {
            try
            {
                int pageNo = 1;
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Page sharing");
                NotebookCommonMethods.ClickShareButton();
                int noOfPages = NotebookCommonMethods.GetNoOfPagesToBeSelected();
                string text = NotebookCommonMethods.GetNoOfPagesSelected();
                NotebookCommonMethods.SelectIndividualPageToShare(pageNo);
                text = NotebookCommonMethods.GetNoOfPagesSelected();
                Assert.AreEqual(text, pageNo + " Page Selected");
                NotebookCommonMethods.ClickSelectAllButtonInSelectPages();
                text = NotebookCommonMethods.GetNoOfPagesSelected();
                Assert.AreEqual(text, noOfPages + " Pages Selected");
                NotebookCommonMethods.ClickSelectAllButtonInSelectPages();
                text = NotebookCommonMethods.GetNoOfPagesSelected();
                Assert.AreEqual(text, 0 + " Pages Selected");
                NotebookCommonMethods.ClickCancelInSelectPages();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23160)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void OverlayHeadingActions()
        {
            try
            {
                int pageNo = 1;
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(NotebookCommonMethods.VerifySelectPageOverlayOpen(), "Select Page overlay not opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyCancelButtonInSelectPages(), "Select Page overlay not opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyNextButtonInSelectPages(), "Select Page overlay not opened");
                Assert.IsFalse(NotebookCommonMethods.VerifyNextButtonInSelectPagesActive(), "Select Page overlay not opened");
                NotebookCommonMethods.SelectIndividualPageToShare(pageNo);
                Assert.IsTrue(NotebookCommonMethods.VerifyNextButtonInSelectPagesActive(), "Select Page overlay not opened");
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.VerifySelectRecipientsOverlay(), "Select Recipients Overlay not present");
                NotebookCommonMethods.ClickBackInSelectRecipients();
                Assert.IsTrue(NotebookCommonMethods.VerifySelectAllButtonInSelectPages(), "Select all Button Not present");
                string text = NotebookCommonMethods.GetNoOfPagesSelected();
                Assert.AreEqual(text, pageNo + " Page Selected");
                NotebookCommonMethods.ClickCancelInSelectPages();
                Assert.IsFalse(NotebookCommonMethods.VerifySelectPageOverlayOpen(), "Select Page overlay not opened");
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23159)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void OverlayHeading()
        {
            try
            {
                int pageNo = 1;
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(NotebookCommonMethods.VerifySelectPageOverlayOpen(), "Select Page overlay not opened");
                NotebookCommonMethods.SelectIndividualPageToShare(pageNo);
                Assert.IsTrue(NotebookCommonMethods.VerifyCancelButtonInSelectPages(), "Select Page overlay not opened");
                Assert.IsTrue(NotebookCommonMethods.VerifyNextButtonInSelectPages(), "Select Page overlay not opened");
                Assert.IsTrue(NotebookCommonMethods.VerifySelectAllButtonInSelectPages(), "Select all Button Not present");
                string text = NotebookCommonMethods.GetNoOfPagesSelected();
                Assert.AreEqual(text, pageNo + " Page Selected");
                NotebookCommonMethods.ClickCancelInSelectPages();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23158)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TappingShareIconTriggersSelectPagesOverlay()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(NotebookCommonMethods.VerifySelectPageOverlayOpen(), "Select Page overlay not opened");
                NotebookCommonMethods.ClickCancelInSelectPages();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(23157)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SelectPagesOverlayDisplaysOnlyWithNotebooksWithMultiplePages()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsFalse(NotebookCommonMethods.VerifySelectPageOverlayOpen(), "Select Page overlay not opened");
                Assert.IsTrue(CommonReadCommonMethods.VerifySelectRecipientsOverlay(), "Select Recipients Overlay not present");
                CommonReadCommonMethods.ClickCancelInSelectRecipients();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(NotebookCommonMethods.VerifySelectPageOverlayOpen(), "Select Page overlay not opened");
                NotebookCommonMethods.ClickCancelInSelectPages();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22768)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void StudentCanShareNotebooksWithOtherStudents()
        {
            try
            {
                Login login = Login.GetLogin("StudentLois");
                Login login1 = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = login.PersonName;
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.AddNewNotebookPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.ClickSelectAllButtonInSelectPages();
                NotebookCommonMethods.ClickNextInSelectPages();
                NotebookCommonMethods.SelectRecipientByName(studentName);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22770)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void StudentsTeacherShouldAbleToViewReceivedAndSentNotebooksInWorkBrowser()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = login.PersonName;
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                string taskName = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.SendText("Sharing");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentButtonInNotebook(taskName), "Sent button associated with the task notebook not present");
                NavigationCommonMethods.Logout();
                Login login1 = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login1.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
                string taskName1 = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectRecipientByName(taskInfo.AdditionalInfo);
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
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentButtonInNotebook(taskName1), "Sent button associated with the task notebook not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedButtonInNotebook(taskName1), "Sent button associated with the task notebook not present");
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
        ////[TestCategory("NotebookTests")]
        ////[WorkItem(22608)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void ReceivedNotebooksNotDownloadedNoWiFi()
        ////{
        ////    try
        ////    {

        ////        Login login = Login.GetLogin("StudentBruceSec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
        ////        NotebookCommonMethods.ClickOnNotebookIcon();
        ////        NotebookCommonMethods.ClickTextIconInNotebook();
        ////        NotebookCommonMethods.TapOnScreen(1200, 700);
        ////        NotebookCommonMethods.SendText("Sharing");
        ////        NotebookCommonMethods.ClickShareButton();
        ////        Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
        ////        CommonReadCommonMethods.ClickNextInSelectRecipients();
        ////        NotebookCommonMethods.AddMessage("Test Sharing");
        ////        CommonReadCommonMethods.ClickSendInSelectRecipients();
        ////        Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
        ////        Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
        ////        NavigationCommonMethods.Logout();

        ////        Login login1 = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login1);
        ////        NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
        ////        NotebookCommonMethods.ClickOnNotebookIcon();
        ////        NotebookCommonMethods.NotebookWorkBrowserView();
        ////        AutomationAgent.DisableNetwork();
        ////        AutomationAgent.LaunchApp();
        ////        Assert.IsTrue(NotebookCommonMethods.VerifyNoWifiInBrowseOverlay(), "Wifi Icon is not found");
        ////        NotebookCommonMethods.ClickXBrowserNoteXButton();
        ////        AutomationAgent.EnableNetwork();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22429)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void OpenNotebookPreviewFromSharedWorkDropDown()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                Login login1 = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
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
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                DashboardCommonMethods.ClickOnItemInNotification(1);
                WorkBrowserCommonMethods.ClickToDownloadNotebook();
                DashboardCommonMethods.ClickOnGoToWorkBrowserButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyWorkBrowserPageOpened(), "WorkBrowser Page not opened");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22611)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void BrowseNotesOverlayReceivedNotebooksOpenDownloadeReceivedNotebook()
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
                NavigationCommonMethods.NavigateMyDashboard();
                DashboardCommonMethods.ClickOnNotificationIconInChrome();
                DashboardCommonMethods.ClickOnItemInNotification(1);
                WorkBrowserCommonMethods.ClickToDownloadNotebook();
                NotebookCommonMethods.TapOnScreen(1000, 35);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login1.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "Browse Notes Overlay not present");
                DashboardCommonMethods.ClickNotebookInDashboard(22);
                Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "Browse Notes Overlay not present");
                Assert.IsTrue(NotebookCommonMethods.VerifySharedNotebookOpen(), "Shared notebook not opened");
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookIconPresent(), "Notebook Icon Still Present");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22609)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void BrowseNotesOverlayReceivedNotebooksNotDownloadedWiFiAvailable()
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
                Assert.IsTrue(NotebookCommonMethods.VerifyTapToDownloadButton(), "Tap To Download Button Not present");
                Assert.IsTrue(NotebookCommonMethods.VerifyProgressBar(), "Tap To Download Button Not present");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(20513)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyHeaderColorsCorrectMathElaSharedPersonalNotebooks()
        {
            try
            {
                int pageNo = 1;
                string string1 = "First Page";
                string string2 = "Second Page";
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
                NotebookCommonMethods.SelectIndividualPageToShare(pageNo);
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Verify ELA Colour");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");

                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook(string2);
                NotebookCommonMethods.ClickShareButton();
                NotebookCommonMethods.SelectIndividualPageToShare(pageNo);
                NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Verify Math Colour");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(4);
                NotebookCommonMethods.TapOnScreen(519, 63);
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                NotebookCommonMethods.ClickPersonalNoteTitle();
                AutomationAgent.Wait(500);
                Color sampleColor = Color.FromArgb(255, 0, 50, 195);
                AutomationAgent.Wait(500);
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookTitleColourBlueForEla(sampleColor), "Notebook Button is not orange");
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
        [TestCategory("NotebookTests")]
        [WorkItem(22604)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void OpenOverlayWhenThereAreReceivedNotebooks()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = login.PersonName;
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                string taskName = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentButtonInNotebook(taskName), "Sent button associated with the task notebook not present");
                NavigationCommonMethods.Logout();
                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                //NotebookCommonMethods.ClickOnWorkBrowserFolderIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifySharedNotebooksTitle(), "Heading above tile is not Shared Notebooks");
                Assert.IsTrue(NotebookCommonMethods.VerifyNumerOfReceivedBooksParentheses(), "Number of received notebooks is not displayed");
                string studentInfo = NotebookCommonMethods.GetSenderInfoInTiles();
                Assert.AreEqual(studentName, studentInfo, "Sharing person information is displayed");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
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
        [TestCategory("NotebookTests")]
        [WorkItem(22605)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyOverlayReceivedNotebooksCounter()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName = login.PersonName;
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                string taskName = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("EFGH");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentButtonInNotebook(taskName), "Sent button associated with the task notebook not present");
                NavigationCommonMethods.Logout();

                Login login1 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login1);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                //NotebookCommonMethods.ClickOnWorkBrowserFolderIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.VerifySharedNotebooksTitle();
                int received = NotebookCommonMethods.GetNumerOfReceivedBooks("old");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
                NavigationCommonMethods.Logout();

                Login login3 = Login.GetLogin("StudentBruceSec9Apatton");
                string studentName1 = login.PersonName;
                NavigationCommonMethods.LoginApp(login3);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login3.GetTaskInfo("ELA", "Notebook"));
                string taskName1 = NotebookCommonMethods.GetTaskTitleInTaskPage();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("ABCD");
                NotebookCommonMethods.ClickShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.AddMessage("Test Sharing");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();

                Login login2 = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login2);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login2.GetTaskInfo("ELA", "Notebook"));
                NotebookCommonMethods.ClickOnNotebookIcon();
                //NotebookCommonMethods.ClickOnWorkBrowserFolderIcon();
                NotebookCommonMethods.NotebookWorkBrowserView();
                NotebookCommonMethods.VerifySharedNotebooksTitle();
                int receivedNew = NotebookCommonMethods.GetNumerOfReceivedBooks("new");
                string studentInfo = NotebookCommonMethods.GetSenderInfoInTiles();
                Assert.AreEqual(studentName, studentInfo, "Sharing person information is not displayed");
                Assert.AreNotEqual<int>(receivedNew, received, "Received noteboks counter does not change");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
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
    }
}
