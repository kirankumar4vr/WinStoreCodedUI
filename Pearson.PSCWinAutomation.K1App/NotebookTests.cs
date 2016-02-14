using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using System.Configuration;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Pearson.PSCWinAutomation.Framework;
using Pearson.PSCWinAutomationFramework.__k1App;

namespace Pearson.PSCWinAutomationFramework._K1App
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(22551), WorkItem(22553), WorkItem(22583)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookBrowser_CanvasNotebookView()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");

                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");

                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                NotebookCommonMethods.ClickCrayonToolIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyCrayonToolIconSelected(),"crayon tool icon not selected");
                NavigationCommonMethods.SwipeScreenDown();

                NotebookCommonMethods.ClickBrushToolIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyBrushToolIconSelected(),"crayon tool icon not selected");
                NavigationCommonMethods.SwipeScreenDown();

                NotebookCommonMethods.ClickMarkerToolIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyMarkerToolIconSelected(), "crayon tool icon not selected");
                NavigationCommonMethods.SwipeScreenDown();

                Assert.IsTrue(NotebookCommonMethods.VerifyStampIconEnabled(), "stamp icon not enabled");

                NotebookCommonMethods.ClickEraserToolIcon();
                NavigationCommonMethods.SwipeScreenDown();

                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(27096)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookPageManagement_AddNewPagefromNotebookBrowser_CANCEL()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                string Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(3);
                NotebookCommonMethods.ClickAddPageButtonNotebookCanvas();
                NotebookCommonMethods.ClickNotebookPopupCancel();
                string NbpagenoNew = NotebookCommonMethods.GetCurrentNotebookPageNumber(3);
                Assert.AreEqual(Nbpageno, NbpagenoNew, "Page added to notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(27115), WorkItem(27100), WorkItem(45881)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookBrowser_PageSnapshotSwipeThroughNotebookPages()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                string Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                string[] splitnbpage = Nbpageno.Split(' ');
                int curentpageno = Int32.Parse(splitnbpage[0]);


                if (curentpageno < 3)
                {
                    NotebookCommonMethods.ClickAddPageButtonNotebookScreen();
                    NotebookCommonMethods.ClickNotebookPopupAccept();
                    AutomationAgent.Wait(1000);
                    NotebookCommonMethods.ClickBackButtonNotebook();

                    NotebookCommonMethods.ClickAddPageButtonNotebookScreen();
                    NotebookCommonMethods.ClickNotebookPopupAccept();
                    AutomationAgent.Wait(1000);
                    NotebookCommonMethods.ClickBackButtonNotebook();
                }

                 Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                 splitnbpage = Nbpageno.Split(' ');
                 curentpageno = Int32.Parse(splitnbpage[0]);


                NotebookCommonMethods.ClickNotebookPreviousPageButton();
                Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                splitnbpage = Nbpageno.Split(' ');
                int curentpagenoprev = Int32.Parse(splitnbpage[0]);
                Assert.IsTrue(curentpagenoprev < curentpageno, "page not moved to prev");

                NotebookCommonMethods.ClickNotebookNextPageButton();
                Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                splitnbpage = Nbpageno.Split(' ');
                int curentpagenonext = Int32.Parse(splitnbpage[0]);
                Assert.IsTrue(curentpagenoprev < curentpagenonext, "page not moved to prev");

                NotebookCommonMethods.NavigateToLastNotebookPage();
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookNextPageButton(), "next page button still found");

                NotebookCommonMethods.NavigateToFirstNotebookPage();
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookPreviousPageButton(), "next page button still found");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                int nbCanvasPage = Int32.Parse(NotebookCommonMethods.GetCurrentNotebookPageNumber(3));
                Assert.AreEqual(nbCanvasPage, 1, "same page not getting displayed");
                NotebookCommonMethods.ClickBackButtonNotebook();

                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(29877)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookCanvasCleanup_Undo()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("test"), "text not found in notebook");

                NotebookCommonMethods.ClickUndoIcon();
                eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");

                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                string Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(3);
                NotebookCommonMethods.ClickBackButtonNotebook();
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                AutomationAgent.Wait();
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("test"), "text not found in notebook");
                //NotebookCommonMethods.ClickUndoIcon();
                //Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");
                string NbpagenoNow = NotebookCommonMethods.GetCurrentNotebookPageNumber(3);
                Assert.AreEqual(Nbpageno, NbpagenoNow, "page number changed");

                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookBackgroundIsNotPlain(), "notebook background is not plain");

                NotebookCommonMethods.ChangeNotebookBackgroundGrid();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookBackgroundIsNotPlain(), "notebook background is plain");

                NotebookCommonMethods.ClickUndoIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookBackgroundIsNotPlain(), "notebook background is not plain");

                NotebookCommonMethods.ClickBackButtonNotebook();

                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(22652), WorkItem(22657)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookTextRegionFlow()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                
                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");
                NotebookCommonMethods.ClickNotebookHandIcon();
                NotebookCommonMethods.ClickNotebookTextBoxPane();
                Assert.IsTrue(NotebookCommonMethods.VerifyXCrossIconTextBox(), "X cross icon not found");
                NotebookCommonMethods.ClickXCrossIconTextBox();
                Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text box found in notebook");

                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("test"), "text not found in notebook");

                NotebookCommonMethods.EditTextInNotebookTextBox("tested");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("tested"), "text not found in notebook");

                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(22810)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitNotebook_LoadSave()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();

                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();


                NavigationCommonMethods.NavigateToUnitLibrary();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");

                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();

                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();

                //                NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(23140), WorkItem(23143)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookBrowser_DisplayofButtonsOntheActiveNotebookAndBleedingNotebook()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");

                Assert.IsTrue(NotebookCommonMethods.VerifyAddPageButtonNotebookScreen(), "Add page not found");
                //Assert.IsFalse(NotebookCommonMethods.VerifyShareIconPresent(), "share icon present on notebook");
                //Assert.IsFalse(NotebookCommonMethods.VerifyNeighboringButtonsPresent(), "share icon present on notebook");

                //                NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(23145)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookBrowser_WrapAroundDisplayofUnitsNotebookWhileContinueSwipingTapping()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");

                string Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                string[] splitnbpage = Nbpageno.Split(' ');
                int curentpageno = Int32.Parse(splitnbpage[0]);

                if (curentpageno == 1)
                {
                    NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                    NotebookCommonMethods.ClickAddPageButtonNotebookCanvas();
                    NotebookCommonMethods.ClickNotebookPopupAccept();
                    AutomationAgent.Wait(1000);
                    NotebookCommonMethods.ClickBackButtonNotebook();
                }

                NotebookCommonMethods.ClickNotebookPreviousPageButton();

                Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                splitnbpage = Nbpageno.Split(' ');
                int curentpagenoprev = Int32.Parse(splitnbpage[0]);
                Assert.IsTrue(curentpagenoprev < curentpageno, "page not moved to prev");

                //To test - Need to execute
                AutomationAgent.Wait(3000);
                NotebookCommonMethods.SwipeLeft();
                //NavigationCommonMethods.SwipeUnitsLeft();
                Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                splitnbpage = Nbpageno.Split(' ');
                int curentpagenonext = Int32.Parse(splitnbpage[0]);
                Assert.IsTrue(curentpagenoprev < curentpagenonext, "page not moved to prev");

                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(22654)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_HandToolFlow()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                
                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text not found in notebook");

                NotebookCommonMethods.ClickNotebookHandIcon();
                NotebookCommonMethods.ClickNotebookTextBoxPane();

                Assert.IsTrue(NotebookCommonMethods.VerifyXCrossIconTextBox(), "X cross icon not found");
                NotebookCommonMethods.ClickXCrossIconTextBox();
                Assert.IsFalse(NotebookCommonMethods.VerifyTextBoxInNotebook(), "text box found in notebook");


                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(22811),WorkItem(22808)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitNotebook_LoadSaveLoginLogoutBetweenUsers()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                NotebookCommonMethods.AddTextToNotebookTextBox("teacher");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("teacher"), "text not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();

                //Teacher Loggin In again
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("teacher"), "text not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();
                AutomationAgent.CloseApp();


                //Student Login
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

               
                if(NotebookCommonMethods.VerifyTextBoxInNotebook())
                     Assert.IsFalse(NotebookCommonMethods.VerifyTextInNotebook("teacher"), "text teacher found in notebook for student");

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                NotebookCommonMethods.AddTextToNotebookTextBox("student");
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("student"), "text student not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();
                AutomationAgent.CloseApp();
                //Student again

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyTextInNotebook("student"), "text student not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();

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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(45448), WorkItem(45445), WorkItem(45446), WorkItem(45447), WorkItem(45449), WorkItem(45450), WorkItem(44138)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_TableTool()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                //TC45448
                NotebookCommonMethods.ClickMathTools();
                NotebookCommonMethods.ClickTableTool();
                Assert.IsTrue(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");
                //TC45447
                NotebookCommonMethods.AddTextToNotebookTableHeaderCell("Header");
                NotebookCommonMethods.AddTextToNotebookTableColumnHeaderCell("Column");
                NotebookCommonMethods.AddTextToNotebookTableCell("Cell");
                Assert.IsFalse(NotebookCommonMethods.VerifyAdditionalCellsAddedInNotebook(), "Additional cells not found");
                NotebookCommonMethods.ExpandTableInNotebookHorizontal();
                NotebookCommonMethods.ExpandTableInNotebookVertical();
                Assert.IsTrue(NotebookCommonMethods.VerifyAdditionalCellsAddedInNotebook(), "Additional cells not found");

                //TC45446
                int initialPos = NotebookCommonMethods.GetTablePositionXInNotebook();
                NotebookCommonMethods.MoveTableRightInNotebook();
                int FinalPos = NotebookCommonMethods.GetTablePositionXInNotebook();
                Assert.AreEqual(initialPos, FinalPos, "Table pos same");

                //TC45445
                NotebookCommonMethods.ClickNotebookHandIcon();
                NotebookCommonMethods.MoveTableRightInNotebook();
                int FinalPos2 = NotebookCommonMethods.GetTablePositionXInNotebook();
                Assert.AreNotEqual(FinalPos, FinalPos2, "Table pos same");

                int Posy = NotebookCommonMethods.GetTablePositionYInNotebook();
                NotebookCommonMethods.ClickBackButtonNotebook();
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                //TC44141
                Assert.IsFalse(NotebookCommonMethods.VerifyTableSelectedAndBorderPresent(), "table not selected and border found");


                NotebookCommonMethods.ClickNotebookHandIcon();
                AutomationAgent.Wait(500);
                AutomationAgent.Click(FinalPos2, Posy);
                Assert.IsTrue(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");

                //TC45449
                NotebookCommonMethods.ClickImageThumbnailCloseButton();
                Assert.IsFalse(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();

                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickNotebookHandIcon();
                AutomationAgent.Wait(500);
                AutomationAgent.Click(FinalPos2, Posy);
                Assert.IsFalse(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(53608), WorkItem(53610), WorkItem(53611), WorkItem(53612)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_AirplaneIconAvailableToShareNotebookWithTeacher_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                //TC53608
                Assert.IsTrue(NotebookCommonMethods.VerifyAddPageButton(), "Add page not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon present on notebook");
                NotebookCommonMethods.ClickShareAirplaneIcon();
                //TC53610
                Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "share noteboo confirm prompt not found");
                //TC53611
                Assert.IsTrue(NotebookCommonMethods.VerifyTeacherNameInSharePrompt(), "teacher name not found in share prompt UI");
                Assert.IsTrue(NotebookCommonMethods.VerifyXCloseIconInSharePrompt(), "X close icon not found in share prompt UI");
                Assert.IsTrue(NotebookCommonMethods.VerifyCheckSendIconInSharePrompt(), "Check send icon not found in share prompt UI");
                Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationTeacherListScroll(), "teacher list no scrolling");
                //TC53612
                NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
                NotebookCommonMethods.CloseNotebookSentPopup();
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(53613), WorkItem(53614), WorkItem(53615)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ZNotebook_SharingFailure_HelpMessageShouldGetAppear_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon present on notebook");
                NotebookCommonMethods.ClickShareAirplaneIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "share noteboo confirm prompt not found");
                AutomationAgent.DisableNetwork();
                NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentFailureMessage(), "notebook sent failure message not found");
                NotebookCommonMethods.ClickToCloseNotebookSenFailureMessage();

                AutomationAgent.EnableNetwork();
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(53609)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_AirplaneIconNotAvailableToShareNotebookWithTeacher_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                //TC53609
                Assert.IsTrue(NotebookCommonMethods.VerifyAddPageButton(), "Add page notebook canvas not found but of notebook found");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(22591)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookCanvas_BehaviorOfColorPickerWhileTappingOnItWithoutSelectingAnyColor()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickNotebookColorPickerIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyColorPickerSubMenuOpened(), "microphone camera sub menu not found");
                NotebookCommonMethods.ClickMicrophoneIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyColorPickerSubMenuOpened(), "microphone camera sub menu not found");
                
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(22664)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_BackgroundImages()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                Assert.IsFalse(NotebookCommonMethods.VerifyNotebookBackgroundIsNotPlain(), "notebook background is not plain");
                NotebookCommonMethods.ChangeNotebookBackgroundGrid();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookBackgroundIsNotPlain(), "notebook background is plain");
                //Assert.IsFalse(NotebookCommonMethods.VerifyToolsSubMenuOpened(), "notebook background sub menu found");

                NotebookCommonMethods.ClickCrayonToolIcon();
                NavigationCommonMethods.SwipeScreenDown();

                NotebookCommonMethods.ClickBrushToolIcon();
                NavigationCommonMethods.SwipeScreenDown();
                
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(24452)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_Tool_NumberLineReplicateUI_ColorSelectionMenu()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                NotebookCommonMethods.ClickMathTools();
                NotebookCommonMethods.ClickScaleNumberLineTool();
                //TC24452
                Assert.IsTrue(NotebookCommonMethods.VerifyScaleNumberLineInNotebook(), "table not found in notebook");
                NotebookCommonMethods.ClickScaleNumberLineColorCircle("1");
                Assert.IsTrue(NotebookCommonMethods.VerifyColorSelectionScaleHas11Colors(), "11 colors circle not found");
                NotebookCommonMethods.ClickButtonInColorSelectionPopup(1);//X button
             //   Assert.IsFalse(NotebookCommonMethods.VerifyColorSelectionPopupOpen(), "color selection popup still open");
                NotebookCommonMethods.ClickScaleNumberLineColorCircle("1");
                Assert.IsTrue(NotebookCommonMethods.VerifyColorSelectionPopupOpen(), "color selection popup not open");
                NotebookCommonMethods.ClickBrushToolIcon();
               // Assert.IsFalse(NotebookCommonMethods.VerifyColorSelectionPopupOpen(), "color selection popup still open");

                //TC24451
                NotebookCommonMethods.ClickNotebookHandIcon();
                NotebookCommonMethods.ClickScaleNumberLineColorCircle("1");//Selectes table

                Assert.IsTrue(NotebookCommonMethods.VeifyScaleNumberLineHas10NumbersVisible(), "scale doesnt have 10 numbers visible");
                Assert.IsTrue(NotebookCommonMethods.VerifyRedCloseXButton(), "cloe button in no. line not found");
                NotebookCommonMethods.ExpandTableInNotebookHorizontal();
                Assert.IsTrue(NotebookCommonMethods.VeifyScaleNumberLineHasMoreThan10NumbersVisible(), "scale doesnt have 10 numbers visible");
                NotebookCommonMethods.MinimizeShrinkTableInNotebookHorizontal();
                Assert.IsFalse(NotebookCommonMethods.VeifyScaleNumberLineHasMoreThan10NumbersVisible(), "scale doesnt have 10 numbers visible");
                Assert.IsTrue(NotebookCommonMethods.VeifyScaleNumberLineHas10NumbersVisible(), "scale doesnt have 10 numbers visible");

                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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



      //  [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(34200)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void  Notebook_RemovePages_ActivePageOnScreenIfNBHasMultiplePages()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
            
                string Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                string[] splitnbpage = Nbpageno.Split(' ');
                int curentpageno = Int32.Parse(splitnbpage[0]);

                if (curentpageno < 2)
                {
                    NotebookCommonMethods.ClickAddPageButtonNotebookScreen();
                    NotebookCommonMethods.ClickNotebookPopupAccept();
                    AutomationAgent.Wait(1000);
                    NotebookCommonMethods.ClickBackButtonNotebook();
                }

                Nbpageno = NotebookCommonMethods.GetCurrentNotebookPageNumber(1);
                splitnbpage = Nbpageno.Split(' ');
                curentpageno = Int32.Parse(splitnbpage[0]);

                NotebookCommonMethods.DeleteNotebookPage();


                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(44139)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_TableTool_TOCIndexGlossaryRESIZE()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                
                NotebookCommonMethods.ClickMathTools();
                NotebookCommonMethods.ClickTableTool();
                Assert.IsTrue(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");
                
                int initialPosCell = NotebookCommonMethods.GetTableCellHeightInNotebook(7);
                NotebookCommonMethods.AddTextToNotebookTableCell("CellRowExpands");

                int initialPosRowExpandCell = NotebookCommonMethods.GetTableCellHeightInNotebook(7);
                Assert.IsTrue(initialPosRowExpandCell > initialPosCell, "text entered teable not resized");

                NotebookCommonMethods.ExpandTableInNotebookVertical();
                Assert.IsTrue(NotebookCommonMethods.VerifySixRowsAreDisplayed(27), "6 rows not displayed");
                NotebookCommonMethods.MinimizeShrinkTableInNotebookVertical();
                Assert.IsFalse(NotebookCommonMethods.VerifySecondRowIsDisplayed(12), "2 rows displayed");
                
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(44165)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NotebookCanvas_AddPhoto_VerifyLandscapeAllowsUserToSelectPhotoFromPhotoLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
                NotebookCommonMethods.ClickLandscapeIcon();
                NotebookCommonMethods.SelectImageFromImageGallery();
                NotebookCommonMethods.ClickRedCancelPhotoInsertButton();
                Assert.IsFalse(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo available in notebook");

                NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
                NotebookCommonMethods.ClickLandscapeIcon();
                NotebookCommonMethods.SelectImageFromImageGallery();
                NotebookCommonMethods.ClickAcceptPhotoInsertButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(44141), WorkItem(44138), WorkItem(44144)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_TableToolInsertingATableAndInitialState()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();

                NotebookCommonMethods.ClickMathTools();
                NotebookCommonMethods.ClickTableTool();
                Assert.IsTrue(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");
                
                Assert.IsFalse(NotebookCommonMethods.VerifyAdditionalCellsAddedInNotebook(), "Additional cells not found");
                NotebookCommonMethods.ExpandTableInNotebookHorizontal();
                NotebookCommonMethods.ExpandTableInNotebookVertical();
                Assert.IsTrue(NotebookCommonMethods.VerifyAdditionalCellsAddedInNotebook(), "Additional cells not found");

               
                int FinalPos2 = NotebookCommonMethods.GetTablePositionXInNotebook();
                int Posy = NotebookCommonMethods.GetTablePositionYInNotebook();
                //NotebookCommonMethods.TapOnNotebook();
                AutomationAgent.Click(650, 700);
                //TC44141
                Assert.IsFalse(NotebookCommonMethods.VerifyTableSelectedAndBorderPresent(), "table selected and border found");

                NotebookCommonMethods.ClickNotebookHandIcon();
                AutomationAgent.Wait(500);
                AutomationAgent.Click(FinalPos2, Posy);
                Assert.IsTrue(NotebookCommonMethods.VerifyTableInNotebook(), "table not found in notebook");
                Assert.IsTrue(NotebookCommonMethods.VerifyTableSelectedAndBorderPresent(), "table not selected and border not found");

                //tc44144
                NotebookCommonMethods.ClickBrushToolIcon();
                Assert.IsFalse(NotebookCommonMethods.VerifyTableSelectedAndBorderPresent(), "table selected and border found");
                
             //   NotebookCommonMethods.ClickImageThumbnailCloseButton();
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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

       // [TestMethod()]
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(53952)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Integrate212AssetManagerServicePlusK1ExistingImageFileSameAssetsAddedByDifferentUser()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                NotebookCommonMethods.AddImageInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();

                login = Login.GetLogin("TeacherAdbul");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                NotebookCommonMethods.AddImageInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();

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
        [TestCategory("NotebookTests")]
        [Priority(1)]
        [WorkItem(53753), WorkItem(45026)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Integrate212AssetManagerServicePlusK1AudioBackedUpOnSameDevice()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                Assert.IsTrue(NotebookCommonMethods.VerifyCameraMicrophoneIconInNotebook(), "Add page not found");
                NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyToolsSubMenuOpened(), "microphone camera sub menu not found");
                NotebookCommonMethods.ClickMicrophoneIcon();
                NotebookCommonMethods.ClickRecordButton();
                AutomationAgent.Wait(1500);
               //TC45026
                NotebookCommonMethods.ClickRecordStopButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();

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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(53769), WorkItem(53805), WorkItem(53829)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Integrate212AssetManagerServicePlusK1ImageBackedUpOnSameDevice()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                NotebookCommonMethods.AddImageInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();

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
        [TestCategory("NotebookTests")]
        [Priority(2)]
        [WorkItem(45023), WorkItem(45027), WorkItem(45024), WorkItem(45025), WorkItem(45028)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Notebook_InsertAudioMicrophoneUIElementsVerify()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();
                Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
                NotebookCommonMethods.ClickToOpenNotebookCanvasPage();

                NotebookCommonMethods.ClickClearAllButton();
                NotebookCommonMethods.ClickNotebookPopupAccept();
                Assert.IsTrue(NotebookCommonMethods.VerifyCameraMicrophoneIconInNotebook(), "Add page not found");
                NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyToolsSubMenuOpened(), "microphone camera sub menu not found");
                NotebookCommonMethods.ClickMicrophoneIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyAudioRecordCancelButton(), "audio record cancel button not found");
                NotebookCommonMethods.ClickRecordButton();
                //TC45024
                Assert.IsTrue(NotebookCommonMethods.VerifyTimerAvailableInAudioRecord(), "timer not found in recording");
                AutomationAgent.Wait(200);
                //TC45025
                int timertext = Int32.Parse(NotebookCommonMethods.GetTimerAudioRecordText());
                Assert.IsTrue(timertext > 0 && timertext<60, "timer not in between 0 and 60");

                AutomationAgent.Wait(65000);
              //  NotebookCommonMethods.ClickRecordStopButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");

                //TC45027
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedAtTopLeft(),"Media audio not inserted at left top");
                NotebookCommonMethods.ClickOnMediaInsertedInNotebook();
                //NotebookCommonMethods.ClickAudioNotPlayingThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyAudioPlayingThumbnail(), "audio not played");
                
               //TC45028 
                AutomationAgent.Wait(1000);
                NotebookCommonMethods.ClickNotebookHandIcon();
                //NotebookCommonMethods.ClickOnMediaInsertedInNotebook();
                NotebookCommonMethods.ClickAudioPlayingThumbnail();
                int PosY = NotebookCommonMethods.GetMediaThumnailPositionY();
                NotebookCommonMethods.MoveMediaInNotebook();
                int PosYNew = NotebookCommonMethods.GetMediaThumnailPositionY();
                Assert.IsTrue(PosY != PosYNew, "media audio thumbnail not moved");
                NotebookCommonMethods.ClickImageThumbnailCloseButton();
                Assert.IsFalse(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail still found in notebook");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //NavigationCommonMethods.Logout();
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
