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
using Pearson.PSCWinAutomationFramework.K1App;
using Pearson.PSCWinAutomationFramework._K1App;


namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for eReaderTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class eReaderTests
    {
        public eReaderTests()
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
        [TestCategory("eReaderTests")]
        [Priority(2)]
        [WorkItem(20749)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VideoOpenFromTodayShelf_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                {
                    NavigationCommonMethods.SwipeUnitsLeft();
                    if (NavigationCommonMethods.VerifyVideoThumbnailinELA() && i > 1)
                        break;
                }

                NavigationCommonMethods.ClickVideoThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyVideoHasBackButton(), "Back button not available in video player");
                UnitSelectionCommonMethods.ClickVideoBackButton();
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(22024)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TodayShelfImageOpenImageFromTodayShelf_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyImageThumbnailinELA(), "image thumbnail not found");
                NavigationCommonMethods.ClickImageThumbnailinELA();
                Assert.IsTrue(NavigationCommonMethods.VerifyBackButtonInImage(), "back button not available for image player");
                //UnitSelectionCommonMethods.ClickImageBackButton();
                NavigationCommonMethods.ClickBackButtoneReader();


                ////NavigationCommonMethods.Logout();
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
        [TestCategory("eReaderTests")]
        [Priority(2)]
        [WorkItem(20645), WorkItem(20648)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InteractiveOpenfromTodayShelf_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyInteractiveThumbnailinELA(), "interactive thumbnail not found");
                NavigationCommonMethods.ClickInteractiveThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");

                UnitSelectionCommonMethods.ClickInteractiveBackButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "Usr not returned to same screen");
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(23276), WorkItem(23278)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_PinchAndZoom_todayShelf()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                //extra added
                UnitSelectionCommonMethods.ClickTodaysLessonButtonNext();
                UnitSelectionCommonMethods.ClickTodaysLessonButtonNext();
                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("5"), "image thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("5");
                eReaderCommonMethods.ZoomInEReader();
                eReaderCommonMethods.ZoomOutEReader();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(2)]
        [WorkItem(23277)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void EReader_PinchAndZoom_MediaLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
                AutomationAgent.Wait(4000);
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnail(3);
                eReaderCommonMethods.ZoomInEReader();
                eReaderCommonMethods.ZoomOutEReader();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(23184)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void EReader_OpenBookFromTodayShelf()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                //EReader-HandWriting
                for (int i = 0; i < 3; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA(), "ereader thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("7");
                ////eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");


                //EReader-Poem
                NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("10"), "ereader poem thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("10");
                //eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                //eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                //eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");


                //EReader-eBook
                //for (int i = 0; i < 3; i++)
                //    NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("7"), "ereader poem thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("7");
                //eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(23187), WorkItem(45879)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void EReader_OpenBookFromMediaLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
                //EReader-HandWriting
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnail(3);
                //eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();

                //EReader-eBook
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnailShelf2Items(3);
                //eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();

                //EReader-Poem
                NavigationCommonMethods.SwipeScreenDown();
                NavigationCommonMethods.SwipeScreenDown();
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnail(5);
                //eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                eReaderCommonMethods.ClickEReaderNextButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButton();
                NavigationCommonMethods.ClickBackButtoneReader();
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(24391)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_AnnotationsCanvas_LeftAndRightNavigation()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();

                NavigationCommonMethods.SwipeUnitsLeft();
                NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("7"), "image thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("7");
                //eReaderCommonMethods.TapOnEReaderScreen();

                eReaderCommonMethods.ClickEReaderOpenAnnotation();

                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(2), "page not changed");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumberAtCenter(2), "page number is not in center");
                eReaderCommonMethods.ClickEReaderPreviousButtonAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderPageNumber(1), "page not changed to prev");
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(30077), WorkItem(30078), WorkItem(45876)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_SendToNotebookEditMode_CROPVIEW()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA(), "image thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA();
                //eReaderCommonMethods.TapOnEReaderScreen();
                eReaderCommonMethods.ClickEReaderOpenAnnotation();

                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                eReaderCommonMethods.ClickEReaderSendToNotebookButtonAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyCropViewEnabled(), "crop view mode not enabled");
                eReaderCommonMethods.ClickRedCrossCropViewButton();
                Assert.IsFalse(eReaderCommonMethods.VerifyCropViewEnabled(), "crop view mode still enabled");

                eReaderCommonMethods.ClickEReaderSendToNotebookButtonAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyCropViewEnabled(), "crop view mode not enabled");
                eReaderCommonMethods.ChangeCropViewEReader();

                eReaderCommonMethods.ClickGreenAcceptCropViewButton();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "snapshot not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconEnabled(), "hand icon not enabled");

                NotebookCommonMethods.ClickMarkerToolIcon();
                NavigationCommonMethods.SwipeScreenUp();

                NotebookCommonMethods.ClickBackButtonNotebook();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(29859), WorkItem(29858)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_SendSnapshottoNotebook_GOOGLYEYESOpen()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA(), "image thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA();
                //eReaderCommonMethods.TapOnEReaderScreen();
                eReaderCommonMethods.ClickEReaderOpenAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                NavigationCommonMethods.SwipeScreenDown();
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();

                NavigationCommonMethods.ClickEReaderThumbnailinELA();
                //eReaderCommonMethods.TapOnEReaderScreen();

                if (eReaderCommonMethods.VerifyEReaderGooglyEyesClose())
                    eReaderCommonMethods.ClickEReaderGooglyEyesClose();


                Assert.IsTrue(eReaderCommonMethods.VerifySendToNotebookButtonAtTopRight(), "Send to nb button not top right place");
                eReaderCommonMethods.ClickEReaderSendToNotebookButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyCropViewEnabled(), "crop view mode not enabled");
                eReaderCommonMethods.ClickRedCrossCropViewButton();
                Assert.IsFalse(eReaderCommonMethods.VerifyCropViewEnabled(), "crop view mode still enabled");

                eReaderCommonMethods.ClickEReaderSendToNotebookButton();
                Assert.IsTrue(eReaderCommonMethods.VerifyCropViewEnabled(), "crop view mode not enabled");
                eReaderCommonMethods.ChangeCropViewEReader();

                eReaderCommonMethods.ClickGreenAcceptCropViewButton();
                Assert.IsTrue(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "snapshot not found");
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconEnabled(), "hand icon not enabled");

                //Resize image thumbnail
                int widthOrg = NotebookCommonMethods.GetImageThumbnailWidth();
                NotebookCommonMethods.ResizeImageInNoteBook();
                int widthAfterResize = NotebookCommonMethods.GetImageThumbnailWidth();
                Assert.AreNotEqual(widthAfterResize, widthOrg, "image not resized");

                //Add Text Box
                //NotebookCommonMethods.ClickNotebookTextIcon();
                NotebookCommonMethods.AddTextToNotebookTextBox("test");
                ////eReaderCommonMethods.TapOnEReaderScreen();

                //Delete Thumbnail
                NotebookCommonMethods.ClickImageThumbnailInNotebook();
                NotebookCommonMethods.ClickImageThumbnailCloseButton();
                Assert.IsFalse(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "snapshot still found");

                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(2)]
        [WorkItem(27018)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_Annotations_AccessSameEReaderFromTodaysShelfAndMediaLibrary()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                NavigationCommonMethods.SwipeUnitsLeft();
                NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("7"), "ereader poem thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("7");
                //eReaderCommonMethods.TapOnEReaderScreen();
                eReaderCommonMethods.ClickEReaderOpenAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                NavigationCommonMethods.SwipeScreenDown();
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();

                //Media Lib
                NavigationCommonMethods.NavigateToMediaLibrary();
               
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnail(5);

                //eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "not annotated");
                eReaderCommonMethods.ClickEReaderGooglyEyesClose();
                NavigationCommonMethods.ClickBackButtoneReader();

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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(27465)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_AnnotationsToggleinReadOnlyModeNoANNOTATION()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                //EReader-eBook
                for (int i = 0; i < 4; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("10"), "ereader poem thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("10");
                Assert.IsFalse(eReaderCommonMethods.VerifyEReaderHeaderFooterNotDisplayedByDefault(), "Header footer displayed");


                //eReaderCommonMethods.TapOnEReaderScreen();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsFalse(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "not annotated");
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(27467)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_AnnotationsToggleinReadOnlyMode_GooglyEyesON()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                UnitSelectionCommonMethods.ClickTodaysLessonButtonNext();
                //EReader-eBook
                for (int i = 0; i < 4; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("10"), "ereader poem thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("10");
                Assert.IsFalse(eReaderCommonMethods.VerifyEReaderHeaderFooterNotDisplayedByDefault(), "Header footer displayed");


                //eReaderCommonMethods.TapOnEReaderScreen();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                ////Assert.IsFalse(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "not annotated");

                eReaderCommonMethods.ClickEReaderOpenAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                NavigationCommonMethods.SwipeScreenDown();

                //Page 3
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                NavigationCommonMethods.SwipeScreenDown();
                //Page 5
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                NavigationCommonMethods.SwipeScreenDown();
                eReaderCommonMethods.NavigateToFirstPageAnnotation();
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();

                NavigationCommonMethods.ClickEReaderThumbnailinELA("10");
                //Page1
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "not annotated");
                eReaderCommonMethods.ClickEReaderGooglyEyesClose();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesOpen(), "Googly eyes not open");
                //Page2
                eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsFalse(eReaderCommonMethods.VerifyEReaderGooglyEyesOpen(), "Googly eyes open");
                //Page3
                eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesOpen(), "Googly eyes open");

                //Page 5
                eReaderCommonMethods.ClickEReaderNextButton();
                eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesOpen(), "Googly eyes open");

                eReaderCommonMethods.NavigateToFirstPageEReader();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(2)]
        [WorkItem(27465), WorkItem(24389)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_AnnotationsCanvas()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();

                NavigationCommonMethods.ClickEReaderThumbnailinELA("1");
                //eReaderCommonMethods.TapOnEReaderScreen();
                eReaderCommonMethods.ClickEReaderOpenAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationPageUI(), "eraeader annotation ui not verified");

                NotebookCommonMethods.ClickCrayonToolIcon();
                NavigationCommonMethods.SwipeScreenDown();

                NotebookCommonMethods.ClickBrushToolIcon();
                NavigationCommonMethods.SwipeScreenDown();

                NotebookCommonMethods.ClickMarkerToolIcon();
                NavigationCommonMethods.SwipeScreenDown();

                Assert.IsTrue(NotebookCommonMethods.VerifyStampIconEnabled(), "stamp icon not enabled");

                NotebookCommonMethods.ClickEraserToolIcon();
                NavigationCommonMethods.SwipeScreenDown();

                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(2)]
        [WorkItem(27022)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ZEreader_Annotations_Annotations_SaveAnnotationsInOffline()
        {
            try
            {
                //Student
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                AutomationAgent.DisableNetwork();
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                UnitSelectionCommonMethods.ClickTodaysLessonButtonNext();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("5"), "ereader thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("5");
                //eReaderCommonMethods.TapOnEReaderScreen();
                eReaderCommonMethods.ClickEReaderOpenAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                NavigationCommonMethods.SwipeScreenDown();
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();
                AutomationAgent.EnableNetwork();
                NavigationCommonMethods.Logout();

                //Teacher
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                UnitSelectionCommonMethods.ClickTodaysLessonButtonNext();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("5"), "ereader thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("5");
                eReaderCommonMethods.TapOnEReaderScreen();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "Annotation not found");
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
        [TestCategory("eReaderTests")]
        [Priority(1)]
        [WorkItem(27466)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Ereader_AnnotationsToggleinReadOnlyMode_GooglyEyesOFF()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                //EReader-eBook
                for (int i = 0; i < 3; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();

                Assert.IsTrue(NavigationCommonMethods.VerifyEReaderThumbnailinELA("7"), "ereader poem thumbnail not found");
                NavigationCommonMethods.ClickEReaderThumbnailinELA("7");
                Assert.IsFalse(eReaderCommonMethods.VerifyEReaderHeaderFooterNotDisplayedByDefault(), "Header footer displayed");


                //eReaderCommonMethods.TapOnEReaderScreen();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                ////Assert.IsFalse(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "not annotated");

                eReaderCommonMethods.ClickEReaderOpenAnnotation();
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderAnnotationModeOpened(), "eReader annotation mode not opened");
                NavigationCommonMethods.SwipeScreenDown();

                //Page 3
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                NavigationCommonMethods.SwipeScreenDown();
                //Page 5
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                eReaderCommonMethods.ClickEReaderNextButtonAnnotation();
                NavigationCommonMethods.SwipeScreenDown();
                eReaderCommonMethods.NavigateToFirstPageAnnotation();
                eReaderCommonMethods.ClickBackButtoneReaderAnnotation();

                NavigationCommonMethods.ClickEReaderThumbnailinELA("7");
                //Page1
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "not annotated");
                //Page2
                eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsFalse(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "Googly eyes open");
                //Page3
                eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "Googly eyes open");

                //Page 5
                eReaderCommonMethods.ClickEReaderNextButton();
                eReaderCommonMethods.ClickEReaderNextButton();
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderHeader(), "eReader header not verified");
                //Assert.IsTrue(eReaderCommonMethods.VerifyEReaderFooter(), "eReader footer not verified");
                Assert.IsTrue(eReaderCommonMethods.VerifyEReaderGooglyEyesClose(), "Googly eyes open");

                eReaderCommonMethods.NavigateToFirstPageEReader();
                NavigationCommonMethods.ClickBackButtoneReader();
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
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
