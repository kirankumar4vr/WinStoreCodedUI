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
    /// Summary description for CommonReadTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class CommonReadTests
    {
        public CommonReadTests()
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15955)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChangingPagesOnCommonReadAscendingPagesByUsingPaginationArrows()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                //Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadPageNumber("1"), "Page 1 not found");
                Assert.IsFalse(CommonReadCommonMethods.VerifyLeftArrowExists(),"Page 1 Not Found");
                CommonReadCommonMethods.ClickOnRightArrow();
                Assert.IsTrue(CommonReadCommonMethods.VerifyLeftArrowExists(), "Page 2 Not Found");
                //Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadPageNumber("2"), "Page 2 not found");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15954)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ChangingPagesOnCommonReadDescendingPagesByTappingPaginationArrows()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();

                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.ClickOnRightArrow();
                Assert.IsTrue(CommonReadCommonMethods.VerifyLeftArrowExists(), "Page 2 Not Found");
                //Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadPageNumber("2"), "Page 2 not found");
                CommonReadCommonMethods.ClickOnLeftArrow();
                Assert.IsFalse(CommonReadCommonMethods.VerifyLeftArrowExists(), "Page 1 Not Found");
                //Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadPageNumber("1"), "Page 1 not found");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(21759)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TappingDoneButtonClosesCommonRead()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.ClickOnDoneButton();
                //Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadButton(taskInfo.TaskNumber), "Common Read button not found");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(19299)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyToolOnTheRightSideOfCommonRead()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.ToggleVellumModeNormal(2);
                Assert.IsTrue(CommonReadCommonMethods.VerifyVellumModeButtonExists(), "Vellum mode side button not exists");
                CommonReadCommonMethods.ToggleVellumModePressed(2);
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15999)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyCommonReadDisplaysEPub()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadScreen(), "CommonReadScreen Not Found");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(23138)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MessageForOverlappingPreviouslyCreatedItemAnnotation()
        {

            try
            {
                bool ClickDeletHighlight = false;
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                CommonReadCommonMethods.Sleep();
                if(!CommonReadCommonMethods.VerfiyHighlightButton())
                {
                    //CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeletHighlight);
                    CommonReadCommonMethods.Sleep();
                }
              
                //if(CommonReadCommonMethods.VerifyDeleteHighlightButtonExist())
                //{
                //    CommonReadCommonMethods.DeleteHighlightFromCommonRead();
                //    DeleteHighlight = true;

                //}
                //if(DeleteHighlight)
                //{
                //    CommonReadCommonMethods.Sleep();
                //    CommonReadCommonMethods.Sleep();
                //    CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                //    CommonReadCommonMethods.Sleep();
                //}
                CommonReadCommonMethods.ClickHighlightButton();
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.OpenCommonRead(4);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeletHighlight);
                CommonReadCommonMethods.Sleep();
                if (!CommonReadCommonMethods.VerfiyHighlightButton())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeletHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                CommonReadCommonMethods.ClickHighlightButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifyExistingAnnotationMessage(), "AnnotationMessage Doesn't Exist");
                CommonReadCommonMethods.ClickOkButton();
                CommonReadCommonMethods.Sleep();
                //NavigationCommonMethods.TapOnScreen();
                //CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                //CommonReadCommonMethods.DeleteHighlightFromCommonRead();
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(16059)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyDeleteHighlightAppearanceAndExistingHighlightMessage()
        {
            try
            {
                bool ClickDeleteHighlight = false;
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.Sleep();
                if (!CommonReadCommonMethods.VerfiyHighlightButton())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeleteHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                Assert.IsFalse(CommonReadCommonMethods.VerifyDeleteHighlightButtonExist(), "DeleteHighlightButton Exist");
                CommonReadCommonMethods.ClickHighlightButton();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.Sleep();
                if (!CommonReadCommonMethods.VerfiyHighlightButton())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeleteHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                CommonReadCommonMethods.ClickHighlightButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifyExistingAnnotationMessage(), "AnnotationMessage Doesn't Exist");
                CommonReadCommonMethods.ClickOkButton();
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.Sleep();
                if(!CommonReadCommonMethods.VerifyDeleteHighlightButtonExist())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(980, 404, ClickDeleteHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                CommonReadCommonMethods.DeleteHighlightFromCommonRead();
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(16063)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyDeleteHighlightinEreader()
        {
            try
            {
                bool ClickDeleteHighlight = false;
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(1003, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.Sleep();
                if (!CommonReadCommonMethods.VerfiyHighlightButton())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(1003, 404, ClickDeleteHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                CommonReadCommonMethods.ClickHighlightButton();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(883, 346, ClickDeleteHighlight);
                if (!CommonReadCommonMethods.VerfiyHighlightButton())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(883, 346, ClickDeleteHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                CommonReadCommonMethods.ClickHighlightButton();
                CommonReadCommonMethods.GetAnnotationMenu(883, 346, ClickDeleteHighlight);
                if (!CommonReadCommonMethods.VerifyDeleteHighlightButtonExist())
                {
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.Sleep();
                    CommonReadCommonMethods.GetAnnotationMenu(883, 346, ClickDeleteHighlight);
                    CommonReadCommonMethods.Sleep();
                }
                CommonReadCommonMethods.DeleteHighlightFromCommonRead();
                CommonReadCommonMethods.GetAnnotationMenu(1003, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.ClickHighlightButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifyExistingAnnotationMessage(), "AnnotationMessage Doesn't Exist");
                CommonReadCommonMethods.ClickOkButton();
                NotebookCommonMethods.TapOnScreen(500, 500);
                //CommonReadCommonMethods.GetAnnotationMenu(1003, 404);
                //CommonReadCommonMethods.DeleteHighlightFromCommonRead();

                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15958)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyScreenDisplayDividesInHalfBlueInCommonRead()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test10");
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "No AnnotationSplitsCRWindow");
                //Assert.IsTrue(CommonReadCommonMethods.VerifyBlueBackGroundOfAnnotationScreen());
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20427)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void NativeNotebookDrawingoptions()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadScreen(), "CommonReadScreen Not Found");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen());
                NotebookCommonMethods.ClickDrawingIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDrawingpopup(), "Drawing Popup Is Not Found");
                NotebookCommonMethods.TapOnScreen(1030, 308);
                Assert.IsFalse(NotebookCommonMethods.VerifyDrawingpopup(), "Drawing Popup Exists");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20431)]
        [Priority(1)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void Disabletextmodevianativenotebooktoolbarcontrol()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadScreen(), "CommonReadScreen Is Not Avaialable");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "Notebook Is Not Opened");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1091, 491);
                NotebookCommonMethods.AddTextInNotebook("MYTEXT");
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1062, 292);                
                string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone();                
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1193, 151);
                NotebookCommonMethods.TapOnScreen(1062, 292);
                CommonReadCommonMethods.Sleep();
                //Assert.IsFalse(WordsInTextBox.Contains("MYTEXT"), "TextBox contains MYTEXT");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextRegionNotPresent(), "Text Region Is Present");
                
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
        [TestCategory("CommonReadTests")]
        [WorkItem(16062)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyExistingHighlightMessage()
        {

            try
            {
                bool ClickDeleteHighlight = false;
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(1003, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.ClickHighlightButton();
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.OpenCommonRead(4);
                CommonReadCommonMethods.Sleep();

                CommonReadCommonMethods.GetAnnotationMenu(1003, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.ClickOnAnnotationLink();
                Assert.IsTrue(CommonReadCommonMethods.VerifyExistingAnnotationMessage(), "AnnotationMessage Doesn't Exist");
                CommonReadCommonMethods.ClickOkButton();
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.GetAnnotationMenu(1003, 404, ClickDeleteHighlight);
                CommonReadCommonMethods.DeleteHighlightFromCommonRead();
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15948)]
        [Priority(3)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void VerifyChangeAnnotationAndFilter()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test10");
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.Sleep();
                AutomationAgent.Click(1008, 404);
                CommonReadCommonMethods.ChangeAndFilterAnnotationType();

                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20424)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Drawingoptions()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadScreen(), "CommonReadScreen Not Found");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen());
                NotebookCommonMethods.ClickDrawingIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyDrawingpopup(), "No Popup");
                NotebookCommonMethods.TapOnScreen(1126, 402);
                Assert.IsFalse(NotebookCommonMethods.VerifyDrawingpopup(), "Popup Exists");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20430)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Enabletextmodevianativenotebooktoolbarcontrol()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadScreen(), "CommonReadScreen Not Found");
                NotebookCommonMethods.ClickOnNotebookIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookOpen(), "NoteBook Not Opened");
                NotebookCommonMethods.ClickEraseIconInNotebook();
                NotebookCommonMethods.ClickClearPage();
                NotebookCommonMethods.ClickTextIconInNotebook();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1200, 700);
                NotebookCommonMethods.AddTextInNotebook("TEST");
                NotebookCommonMethods.TapOnScreen(1062, 292);
                NotebookCommonMethods.TapOnScreen(1200, 700);
                string WordsInTextBox = NotebookCommonMethods.GetTextInTextZone();
                Assert.IsTrue(WordsInTextBox.Contains("TEST"));
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22013)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void CommonReadTileFooterDisplaysFullNameAndDateShared()
        {

            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateWorkBrowser();
                Assert.IsTrue(DashboardCommonMethods.VerifyWorkBrowserPage(), "WorkBrowser Page Is Not Available");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyClass();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkCommonRead();
                Assert.IsTrue(DashboardCommonMethods.VerifyFooterAttributes(), "Footer Attributes are not found");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }


        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(18604)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Screendisplaydividesinhalfwhentappingannotatecommonread()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                
                CommonReadCommonMethods.ClickOnAnnotationLink();
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow());
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(19139)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void HighlightssupportCopyandpastefuncitionalityoftextfromcommonreadsintonotebook()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                CommonReadCommonMethods.CLickOnCopyLink();
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.ClickTextIconInNotebook();
                NotebookCommonMethods.TapOnScreen(1090, 346);
                CommonReadCommonMethods.PastTextInTextZone();
                string Text = NotebookCommonMethods.GetTextInTextZone();
                Assert.AreEqual("Committee", Text, "Text Are Not Equal");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests"), TestCategory("212SmokeTests")]
        [WorkItem(15943)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void PaginationWithSwipingOrTappingOnLeftAndRightArrow()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                //int pageNoBefore = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber("1"));
                Assert.IsFalse(CommonReadCommonMethods.VerifyLeftArrowExists(),"Left Arrow exsists");
                CommonReadCommonMethods.ClickOnRightArrow();
                Assert.IsTrue(CommonReadCommonMethods.VerifyLeftArrowExists(), "Left Arrow Not exsists");
                //int pageNoAfter = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber("2"));
                //Assert.AreEqual<int>(pageNoBefore + 1, pageNoAfter, "page number not in ascending order");
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.ClickOnRightArrow();
                Assert.IsTrue(CommonReadCommonMethods.VerifyLeftArrowExists(), "Left Arrow Not exsists");
                //int pageNoBefore1 = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber("2"));
                CommonReadCommonMethods.ClickOnLeftArrow();
                Assert.IsFalse(CommonReadCommonMethods.VerifyLeftArrowExists(), "Left Arrow exsists");
                //int pageNoAfter1 = Int32.Parse(CommonReadCommonMethods.GetCommonReadPageNumber("1"));
                //Assert.AreEqual<int>(pageNoBefore1, pageNoAfter1 + 1, "page number not in descending order");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(21737)]
        [Priority(3)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void WhenIOpenCommonReadInALessonThenTeacherStaysOpened()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.ClickOnTeacherModeIcon();
               // TeacherModeCommonMethods.ClickUnitOverview();
                Assert.IsTrue(NavigationCommonMethods.VerifyELATeacherModeOpen(), "Teacher Mode not opened");
                NavigationCommonMethods.OpenCommonReadWhenTeacherModeOpen(taskInfo.TaskNumber);
                Assert.IsTrue(NavigationCommonMethods.VerifyELATeacherModeOpen(), "Teacher Mode not opened");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15958)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void AnnotationScreenDisplaysWhileInCommonRead()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                CommonReadCommonMethods.ClickOnAnnotationLink();
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "Annotation screen is not present");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(18604)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void ScreenDisplayDividesInHalfWhenTappingAnnotate()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsFalse(CommonReadCommonMethods.VerifyLeftArrowExists(), "Left Arrow doesn't exists");
                Assert.IsTrue(CommonReadCommonMethods.VerifyRightArrowExists(), "Right Arrow doesn't exists");
                CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                CommonReadCommonMethods.ClickOnAnnotationLink();
                CommonReadCommonMethods.Sleep();
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "Annotation screen is not present");
                
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20594)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void StudentPickSelectionCommonRead()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Landing page is not Dashboard");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System Tray still closed");
                NavigationCommonMethods.ClickMyDashboardInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard page not present");
                NavigationCommonMethods.ClickELAInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA Page is not present");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.GetAnnotationMenu(1008, 404);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadAnnotationMenus(), "Common Read Contextual menus not present");
                CommonReadCommonMethods.ClickOnAnnotationLink();
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "Annotation not Splits CR Window");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(15960), WorkItem(18601)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void AnnotatingWhileInEditMode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(1008, 404);
                CommonReadCommonMethods.ClickOnAnnotationLink();
                CommonReadCommonMethods.SetTextInAnnotationEditor("Test");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(883, 346);
                CommonReadCommonMethods.ClickOnAnnotationLink();
                string annotationText = CommonReadCommonMethods.GetTextFromEditMode();
                Assert.IsTrue(annotationText.Contains(""));
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(18607)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void DefaultAnnotateModeButtonShouldBeInPressedState()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationModeOn(1), "Annotation Mode not ON");
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(1008, 404);
               
                CommonReadCommonMethods.ClickOnAnnotationLink();
                CommonReadCommonMethods.SetTextInAnnotationEditor("Test");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                NotebookCommonMethods.TapOnScreen(1008, 404);
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "Annotation Does not splits the CR Window");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20776)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TappingOnAnnotationShould()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard page not present");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System Tray still closed");
                NavigationCommonMethods.ClickMyDashboardInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard page not present");
                NavigationCommonMethods.ClickELAInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA Page is not present");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(1008, 404);
               
                CommonReadCommonMethods.ClickOnAnnotationLink();
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "Annotation not Splits CR Window");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22244)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void CommonReadsScrolling()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyCRScrollable(), "Only 1 CR present so, its not scrollable");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22138)]
        [Priority(3)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void VerifyTitleBarFolderArrowsAndPlusIconsFunctionality()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                    CommonReadCommonMethods.InitialMethodForCommonRead();
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                    NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                NotebookCommonMethods.ClickOnNotebookIcon();
                NotebookCommonMethods.VerifyNotebookSinglePageAndDeleteAdditionalPages();
                //string pageNo = NotebookCommonMethods.GetNotebookPageNos();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookPageNumber("1 / 1"), "page  1 / 1 incorrect");

              //Assert.AreEqual(pageNo, "( 1 / 1 )", "Page no.s are not similar");
                NotebookCommonMethods.AddNewNotebookPage();
              //  pageNo = NotebookCommonMethods.GetNotebookPageNos();
              //  Assert.AreEqual(pageNo, "( 2 / 2 )", "Page no.s are not similar");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookPageNumber("2 / 2"), "page 2 / 2  incorrect");
                NotebookCommonMethods.ClickLeftArrowIcon();
              //  pageNo = NotebookCommonMethods.GetNotebookPageNos();
              //  Assert.AreEqual(pageNo, "( 1 / 2 )", "Page no.s are not similar");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookPageNumber("1 / 2"), "page 1 / 2 incorrect");
                NotebookCommonMethods.ClickRightArrowIcon();
                //pageNo = NotebookCommonMethods.GetNotebookPageNos();
                //Assert.AreEqual(pageNo, "( 2 / 2 )", "Page no.s are not similar");
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookPageNumber("2 / 2"), "page 2 / 2 incorrect");
                NotebookCommonMethods.NotebookWorkBrowserView();
                Assert.IsTrue(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "Browse Notes Overlay not present");
                NotebookCommonMethods.ClickXBrowserNoteXButton();
                Assert.IsFalse(NotebookCommonMethods.VerifyWorkBrowserOverlayPresent(), "Browse Notes Overlay still present");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(16066)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void HighlightsSupportHighlightSelectedTextCommonRead()
        {

            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                    CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.MoveToFirstPageInCommonRead();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.GetAnnotationMenu(980, 404);
               // Assert.IsFalse(CommonReadCommonMethods.VerifyHighlightedTextAlreadyPresent(), "Highlighted Text present in common read");
               // Assert.IsFalse(CommonReadCommonMethods.VerifyDeleteHighlightButtonExist(), "Highlighted Text present in common read");
                Assert.IsFalse(CommonReadCommonMethods.VerifyHighlightedTextAlreadyVisible(), "Highlighted Text present in common read");
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.ClickHighlightButton();
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.OpenCommonRead(4);
                AutomationAgent.Wait(2000);
                bool ClickDeletHighlight = false;
                CommonReadCommonMethods.GetAnnotationMenu(980, 404,ClickDeletHighlight);
                Assert.IsTrue(CommonReadCommonMethods.VerifyHighlightedTextAlreadyPresent(), "Highlighted Text not present in common read");
                CommonReadCommonMethods.ClickHighlightButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifyExistingAnnotationMessage(), "AnnotationMessage Doesn't Exist");
                CommonReadCommonMethods.ClickOkButton();
                CommonReadCommonMethods.Sleep();
                NavigationCommonMethods.TapOnScreen();
                //CommonReadCommonMethods.GetAnnotationMenu(980, 404);
                //CommonReadCommonMethods.DeleteHighlightFromCommonRead();
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(18606)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void AnnotationsHighlightsTurnOnWhenTurningOnAnnotationMode()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(980, 404, "Test");
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateHighlight(887, 345);
                CommonReadCommonMethods.ToggleVellumModePressed(1);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.ClickAnnotatedtext(980, 404); ;
                Assert.IsFalse(CommonReadCommonMethods.VerifyAnnotationListPanelPresent(), "Annotation split window  present");
                CommonReadCommonMethods.ToggleVellumModeNormal(1);
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationModeOn(1), "Annotation button not in pressed state");
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.ClickAnnotatedtext(980, 404); 
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationListPanelPresent(), "Annotation split window not present");
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.GetAnnotationMenu(887, 345);
                //Assert.IsTrue(CommonReadCommonMethods.VerifyDeleteHighlightButtonExist(), "Delete highlight button doesn't exist");
                //NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.ClickOnDoneButton();
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


        #region NetworkDependent

        [TestMethod()]
        [TestCategory("CommonReadTests")]
        [WorkItem(20595)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void StudentPickSelectionCommonRead1()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Landing page is not Dashboard");
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System Tray still closed");
                NavigationCommonMethods.ClickMyDashboardInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard page not present");
                NavigationCommonMethods.ClickELAInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA Page is not present");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.GetAnnotationMenu(1008, 404);
                Assert.IsTrue(CommonReadCommonMethods.VerifyCommonReadAnnotationMenus(), "Common Read Contextual menus not present");
                CommonReadCommonMethods.ClickOnAnnotationLink();
                CommonReadCommonMethods.SetTextInAnnotationEditor("Test1");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifySelectRecipientsOverlay(), "Select Recipients Overlay not present");
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                Assert.IsFalse(CommonReadCommonMethods.SelectRecipient(1), "Recipient not selected");
                //Assert.IsFalse(CommonReadCommonMethods.DeSelectRecipient(1), "Recipient still in selected state");
                CommonReadCommonMethods.ClickCancelInSelectRecipients();
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(21998)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TapToDownloadCRIfHasNotBeenDownloaded()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard page not present");
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                if (!CommonReadCommonMethods.VerifyUndownloadedCR())
                {
                    NavigationCommonMethods.Logout();
                    CommonReadCommonMethods.InitialMethodForCommonRead();
                    NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                    NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                    NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                    CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                    CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                    CommonReadCommonMethods.ClickAnnotationShareButton();
                    Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                    CommonReadCommonMethods.SendWork();
                    NavigationCommonMethods.Logout();
                CommonReadCommonMethods.InitialMethodForCommonRead();
                    NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                }
                WorkBrowserCommonMethods.ClickToDownloadCR();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(24356)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void AnnotationsSharingVerifyYourWorkWasSentAlert()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");

                //CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");

                //Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                NavigationCommonMethods.Logout();
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickSec34Per5InWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadCR();
                WorkBrowserCommonMethods.OpenCRInWorkBrowser(1);
                NotebookCommonMethods.TapOnScreen(1008, 404);
                Assert.IsTrue(CommonReadCommonMethods.VerifyAnnotationSplitsCRWindow(), "Annotation Panel not present");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(21951)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void CommonReadBaseballCardsOpenDisplaySharedAnnotations()
        {
            try
            {
                Login login1 = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login1, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();

                TaskInfo taskInfo = login1.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                //CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                //CommonReadCommonMethods.SelectRecipient(1);
                //NotebookCommonMethods.ClickNextInSelectPages();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                CommonReadCommonMethods.SendWork();
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.Logout();
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.SelectCourseInWorkBrowserDropDown(4);
                NotebookCommonMethods.TapOnScreen(519, 63);
                WorkBrowserCommonMethods.ClickToDownloadCR();
                WorkBrowserCommonMethods.ClickOnFirstNotebookInWorkBrowser();
                CommonReadCommonMethods.ClickAnnotationSharedButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifyStudentInSharedAnnonation(login1.PersonName), "Student name is not found in shared annotation");
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22002)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TileFooterDisplaysXNumberSentIfCommonReadsHaveBeenSentShared()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadCR();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifySentNoOfCommonRead(1), "Sent button not present");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22037)]
        [Priority(1)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TappingOneOrMoreRecipientsActivatesSendButtonColourChange()
        {
            try
            {
                Login login1 = Login.GetLogin("StudentBruceSec9Apatton");
                NavigationCommonMethods.LoginApp(login1, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                TaskInfo taskInfo = login1.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                CommonReadCommonMethods.SelectRecipient(1);
                // NotebookCommonMethods.ClickNextInSelectPages();
                Color initialSendColor = Color.FromArgb(255, 226, 223, 223);
                Assert.IsTrue(CommonReadCommonMethods.VerifySendButtonColourInSelectRecipient(initialSendColor), "Send Button colour is not grey");
                CommonReadCommonMethods.SelectRecipient(1);
                Color finalSendColor = Color.FromArgb(255, 66, 66, 66);
                Assert.IsTrue(CommonReadCommonMethods.VerifySendButtonColourInSelectRecipient(finalSendColor), "Send Button colour is not grey");
                Assert.AreNotEqual(initialSendColor, finalSendColor, "Send button color not changes on selecting recipient");
                CommonReadCommonMethods.SendWork();
                CommonReadCommonMethods.ClickOnDoneButton();
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22001)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void TileFooterDisplaysXNumberSentIfCommonReadsHaveBeenReceived()
        {
            try
            {
                Login teacher = Login.GetLogin("Sec9Apatton");
                Login student = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = teacher.GetTaskInfo("ELA", "CommonRead");
                TaskInfo secInfo = teacher.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(teacher, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacher.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.Sleep();
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                //CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                NotebookCommonMethods.SelectRecipientByName(secInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(student.PersonName);
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginApp(student);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadCR();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedNoOfCommonRead(1), "Received button not present");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(22245)]
        [Priority(1)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void ReceivedCommonRead()
        {
            try
            {
                Login teacher = Login.GetLogin("Sec9Apatton");
                Login student = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = teacher.GetTaskInfo("ELA", "CommonRead");
                TaskInfo secInfo = teacher.GetTaskInfo("ELA", "Grade9");
                NavigationCommonMethods.LoginApp(teacher, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(teacher.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                //CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.ClickAnnotationShareButton();
                NotebookCommonMethods.SelectRecipientByName(secInfo.AdditionalInfo);
                CommonReadCommonMethods.ClickNextInSelectRecipients();
                NotebookCommonMethods.SelectRecipientByName(student.PersonName);
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Your Work Will be sent alert not found");
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkSentAlert(), "Your Work was sent alert not found");
                CommonReadCommonMethods.ClickOnDoneButton();
                NavigationCommonMethods.Logout();
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.LoginApp(student);
                NavigationCommonMethods.NavigateWorkBrowser();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickToDownloadCR();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedButtonInCommonRead(1), "Received button not present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyClassInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedButtonInCommonRead(1), "Received button still present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickMyTeacherInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsFalse(WorkBrowserCommonMethods.VerifyReceivedButtonInCommonRead(1), "Received button still present");
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickOnMyWorkInWorkBrowserDropDown();
                WorkBrowserCommonMethods.ClickNotebooksButtonInMyWork();
                WorkBrowserCommonMethods.OpenWorkBrowserDropDown();
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedButtonInCommonRead(1), "Received button not present");
                Assert.IsTrue(WorkBrowserCommonMethods.VerifyReceivedNoOfCommonRead(1), "Received button not present");
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
        [TestCategory("CommonReadTests")]
        [WorkItem(20596)]
        [Priority(2)]
        [Owner("Akanksha Gautam(akanksha.gautam)")]
        public void SharingAnnotation()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "CommonRead");
                NavigationCommonMethods.LoginApp(login, 20000);
                CommonReadCommonMethods.InitialMethodForCommonRead();
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyUserIsOnDashBoard(), "User not on Dashboard Page");
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyELAPage(), "ELA Page not present");
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "CommonRead"));
                NavigationCommonMethods.OpenCommonRead(taskInfo.TaskNumber);
                CommonReadCommonMethods.CreateAnnotation(1008, 404, "Test");
                // CommonReadCommonMethods.ClickDoneButtonInAnnotationWindow();
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(500, 500);
                CommonReadCommonMethods.Sleep();
                NotebookCommonMethods.TapOnScreen(1008, 404);
                CommonReadCommonMethods.ClickAnnotationShareButton();
                Assert.IsTrue(CommonReadCommonMethods.VerifySelectRecipientsOverlay(), "Select Recipient overlay not present");
                Assert.IsTrue(CommonReadCommonMethods.VerifyCancelInSelectRecipients(), "Cancel button not present in Select Recipients");
                Assert.IsTrue(CommonReadCommonMethods.VerifySendInSelectRecipient(), "Send button not present in Select recipients");
                Assert.IsTrue(CommonReadCommonMethods.VerifyTeacherAndStudentLists(), "Teacher and student list not present");
                CommonReadCommonMethods.ClickCancelInSelectRecipients();
                Assert.IsFalse(CommonReadCommonMethods.VerifySelectRecipientsOverlay(), "Select Recipient overlay not present");
                CommonReadCommonMethods.ClickAnnotationShareButton();
                Color initialSendColor = Color.FromArgb(255, 226, 223, 223);
                Assert.IsTrue(CommonReadCommonMethods.VerifySendButtonColourInSelectRecipient(initialSendColor), "Send Button colour is not grey");
                Assert.IsTrue(CommonReadCommonMethods.SelectRecipient(1), "Recipient selected");
                Color finalSendColor = Color.FromArgb(255, 66, 66, 66);
                Assert.IsTrue(CommonReadCommonMethods.VerifySendButtonColourInSelectRecipient(finalSendColor), "Send Button colour is not grey");
                Assert.AreNotEqual(initialSendColor, finalSendColor, "Send button color not changes on selecting recipient");
                CommonReadCommonMethods.ClickSendInSelectRecipients();
                Assert.IsTrue(CommonReadCommonMethods.VerifyWorkWillBeSentAlert(), "Work Will be sent alert not present");
                CommonReadCommonMethods.ClickOnDoneButton();
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
