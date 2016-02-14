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


namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class UnitSelectionTests
    {
        public UnitSelectionTests()
        {
        }

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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(22831)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyELAAndMathGradeLabel()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                string assertFailureMessage;
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyELAAndMathGradeLabel(out assertFailureMessage), assertFailureMessage);
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(20769)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyUnitSelectionScreenAndClosedSystemTray()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                int xCoordinateForSystemTrayBefore = UnitSelectionCommonMethods.GetSystemTrayXCoordinate();
                NavigationCommonMethods.NavigateToUnitLibrary();
                int xCoordinateForSystemTrayAfter = UnitSelectionCommonMethods.GetSystemTrayXCoordinate();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA Unit 1 doesn't appear");
                Assert.IsTrue(xCoordinateForSystemTrayAfter == xCoordinateForSystemTrayBefore, "System tray x coordinate is not same before and after navigating to Unit Selection");
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
        [TestCategory("UnitSelectionTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(22832), WorkItem(22835)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitSelectionDynamicColumnHeaders()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                string Elagradelabel = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(Elagradelabel, "KINDERGARTEN", "Ela grade label incorrect");
                UnitSelectionCommonMethods.SwipeElaGradeToGrade1();
                string ElagradelabelGrade1 = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(ElagradelabelGrade1, "GRADE 1", "Ela grade label not changed to Grade1");

                string Mathgradelabel = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(Mathgradelabel, "KINDERGARTEN", "Math grade label incorrect");
                UnitSelectionCommonMethods.SwipeMathGradeToGrade1();
                string MathgradelabelGrade1 = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(MathgradelabelGrade1, "GRADE 1", "Math grade label not changed to Grade1");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(3)]
        [WorkItem(22833)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitSelectionDynamicColumnHeadersDisplayofKindergartenUponScrollingDownFurther()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                string Elagradelabel = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(Elagradelabel, "KINDERGARTEN", "Ela grade label incorrect");
                UnitSelectionCommonMethods.SwipeElaGradeToGrade1(10);
                Elagradelabel = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(Elagradelabel, "KINDERGARTEN", "Ela grade label incorrect");

                UnitSelectionCommonMethods.SwipeElaGradeToGrade1(4);
                Elagradelabel = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(Elagradelabel, "KINDERGARTEN", "Ela grade label incorrect");

                UnitSelectionCommonMethods.SwipeElaGradeToGrade1(4);
                string ElagradelabelGrade1 = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(ElagradelabelGrade1, "GRADE 1", "Ela grade label not changed to Grade1");

                UnitSelectionCommonMethods.SwipeElaGradeToGrade1(5);
                ElagradelabelGrade1 = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(ElagradelabelGrade1, "GRADE 1", "Ela grade label not changed to Grade1");
                
                string Mathgradelabel = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(Mathgradelabel, "KINDERGARTEN", "Math grade label incorrect");
                UnitSelectionCommonMethods.SwipeMathGradeToGrade1(10);
                Mathgradelabel = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(Mathgradelabel, "KINDERGARTEN", "Math grade label incorrect");

                UnitSelectionCommonMethods.SwipeMathGradeToGrade1(10);
                Mathgradelabel = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(Mathgradelabel, "KINDERGARTEN", "Math grade label incorrect");

                UnitSelectionCommonMethods.SwipeMathGradeToGrade1(5);
                string MathgradelabelGrade1 = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(MathgradelabelGrade1, "GRADE 1", "Math grade label not changed to Grade1");

                UnitSelectionCommonMethods.SwipeMathGradeToGrade1(5);
                MathgradelabelGrade1 = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(MathgradelabelGrade1, "GRADE 1", "Math grade label not changed to Grade1");

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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(22842)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitSelectionDynamicColumnHeadersGrade1AboveGrade1()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                string Elagradelabel = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(Elagradelabel, "KINDERGARTEN", "Ela grade label incorrect");
                UnitSelectionCommonMethods.SwipeElaGradeToGrade1();
                string ElagradelabelGrade1 = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(ElagradelabelGrade1, "GRADE 1", "Ela grade label not changed to Grade1");

                string Mathgradelabel = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(Mathgradelabel, "KINDERGARTEN", "Math grade label incorrect");
                UnitSelectionCommonMethods.SwipeMathGradeToGrade1();
                string MathgradelabelGrade1 = UnitSelectionCommonMethods.GetMathGradeLabelText();
                Assert.AreEqual(MathgradelabelGrade1, "GRADE 1", "Math grade label not changed to Grade1");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(22834)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitSelectionDynamicColumnHeaderChangeofHeaderToGrade1WhenKindergartenNotvisible()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                string Elagradelabel = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(Elagradelabel, "KINDERGARTEN", "Ela grade label incorrect");
                UnitSelectionCommonMethods.SwipeElaGradeTillGrade1Visible();
                string ElagradelabelGrade1 = UnitSelectionCommonMethods.GetElaGradeLabelText();
                Assert.AreEqual(ElagradelabelGrade1, "GRADE 1", "Ela grade label not changed to Grade1");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(1)]
        [WorkItem(20745)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VideoOpenUnitIntroductionvideo_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");

                UnitSelectionCommonMethods.ClickToPlayIntroVideoEla();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyVideoOpenedFullScreen(), "Video is not full screened");
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyVideoHasBackButton(), "Back button not available in video player");
                UnitSelectionCommonMethods.ClickVideoBackButton();
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
        [TestCategory("UnitSelectionTests"), TestCategory("K1SmokeTests")]
        [Priority(1)]
        [WorkItem(20746)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VideoOpenUnitIntroductionvideo_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");

                UnitSelectionCommonMethods.ClickToPlayIntroVideoEla();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyVideoOpenedFullScreen(), "Video is not full screened");
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyVideoHasBackButton(), "Back button not available in video player");
                UnitSelectionCommonMethods.ClickVideoBackButton();
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
        [TestCategory("UnitSelectionTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(27149), WorkItem(20245)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyBookLogIconAtEndOfEveryLessonTodayShelfELA()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5;i++ )
                    NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyBookLogIcon(), "Book Log icon not found for ela");

                int BookLogPosXbefore = NavigationCommonMethods.GetXPosOfBookLogThumbnail();
                NavigationCommonMethods.SwipeUnitsLeft();
                int BookLogPosXAfter = NavigationCommonMethods.GetXPosOfBookLogThumbnail();
                Assert.IsTrue(BookLogPosXAfter == BookLogPosXbefore, "Book log is not at last place");

                NavigationCommonMethods.NavigateToUnitLibrary();

                NavigationCommonMethods.NavigateToMathUnit(0);
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsFalse(NavigationCommonMethods.VerifyBookLogIcon(), "Book Log icon found for math");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(20655)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DisplayofUnitsAndLessonsShelfBehaviorWhileTappingonTodayButton()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "todays lesson shelf not found ela");
                NavigationCommonMethods.NavigateToUnitLibrary();
                NavigationCommonMethods.NavigateToMathUnit(0);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyTodaysLessonShelf(), "todays lesson shelf not found math");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(20667)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DisplayofUnitsandLessonTodayViewELAUnits()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayLessonVideo(), "lesson video not available");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(27150), WorkItem(45883)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ViewAndPopupBookLogView()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                for (int i = 0; i < 5; i++)
                    NavigationCommonMethods.SwipeUnitsLeft();
                Assert.IsTrue(NavigationCommonMethods.VerifyBookLogIcon(), "Book Log icon not found for ela");
                NavigationCommonMethods.ClickBookLogIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyDesignLayoutOfBookLog(), "deign of book layout can't verified");
                UnitSelectionCommonMethods.ClickAddButtonBookLog();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyFlyoutAddButtonBookLog(), "Book log add button flyout not found");
                UnitSelectionCommonMethods.ClickAddButtonBookLog();
                LoginCommonMethods.ClickBackButton();
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(20668)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DisplayofUnitsandLessonTodayViewMathUnits()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodayLessonVideo(), "lesson video available for Math");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(20656)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DisplayofUnitsAndLessonShelfELAUnitsVerificationofNavigationArrowButton()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodaysLessonButtonPrevious(), "Lesson Previous button not found");
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyTodaysLessonButtonNext(), "Lesson Next button not found");
                int PosPreviousBtn = UnitSelectionCommonMethods.GetXPositionofPreviousButton();
                int PosNextBtn = UnitSelectionCommonMethods.GetXPositionofNextButton();
                Assert.IsTrue(PosNextBtn > PosPreviousBtn, "Buttons are not aligned correct");
                UnitSelectionCommonMethods.ClickTodaysLessonButtonNext();
                Assert.IsTrue(UnitSelectionCommonMethods.VerfiyLessonNumberDisplayed(2), "Lesson not navigated");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(1)]
        [WorkItem(20747)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VideoOpenFromTodayShelf_Student()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
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
        [TestCategory("UnitSelectionTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(22838)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UnitSelection_DisplayofCancelButtonAtTheBottom()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                Assert.IsFalse(NavigationCommonMethods.VerifyCancelContentDownloadingButton(), "Cancel button found");
                //NavigationCommonMethods.NavigateToELAUnit(4);

                NavigationCommonMethods.AddDownloadNewELAUnit(4);
                
                
                AutomationAgent.Wait(4000);
                Assert.IsTrue(NavigationCommonMethods.VerifyCancelContentDownloadingButton(), "Cancel button not found");
                NavigationCommonMethods.ClickCancelContentDownloadingButton();
                AutomationAgent.Wait(4000);
                AutomationAgent.Wait();
                if(NavigationCommonMethods.VerifyCancelContentDownloadingButton())
                {
                    NavigationCommonMethods.ClickCancelContentDownloadingButton();
                    AutomationAgent.Wait();
                }
                Assert.IsFalse(NavigationCommonMethods.VerifyCancelContentDownloadingButton(), "Cancel button found");
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(20647)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InteractiveOpenfromTodayShelf_Teacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(NavigationCommonMethods.VerifyInteractiveThumbnailinELA(), "interactive thumbnail not found");
                NavigationCommonMethods.ClickInteractiveThumbnailinELA();
                Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                UnitSelectionCommonMethods.ClickInteractiveBackButton();
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
        [TestCategory("UnitSelectionTests")]
        [Priority(2)]
        [WorkItem(22703)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherMode_TodayShelfIsNotVisibleEnableeacherMode()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsFalse(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.CloseTeacherMode();
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
