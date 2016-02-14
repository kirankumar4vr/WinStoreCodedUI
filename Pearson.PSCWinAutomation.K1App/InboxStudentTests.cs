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
using Pearson.PSCWinAutomationFramework.__k1App;


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for StudentInboxTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InboxStudentTests
    {
        public InboxStudentTests()
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
        [TestCategory("InboxTests")]
        [Priority(2)]
        [WorkItem(54442), WorkItem(54446), WorkItem(54447), WorkItem(54448), WorkItem(54449), WorkItem(54450)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ATeacherInboxTeacherReviewSharedWork_TeacherFirstTimeRecordAudio_StyleBox()
        {
            try
            {
                //Login loginTchr = Login.GetLogin("TeacherAdbul");
                //Login student = Login.GetLogin("StudentKevin");
                //int UnitNo = 0;
                //NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                //Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                //NavigationCommonMethods.OpenOrCloseSystemTray();
                //NavigationCommonMethods.NavigateInboxKGInSystemTray();

                //InboxCommonMethods.ClickToggleButtonELA();
                //Assert.IsTrue(InboxCommonMethods.VerifyToggleButtonELASelected(), "Math toggle button not selected");

                //InboxCommonMethods.ClickToggleButtonMath();
                //Assert.IsTrue(InboxCommonMethods.VerifyToggleButtonMathSelected(), "Math toggle button not selected");


                ////if (!InboxCommonMethods.VerifySharedItemInboxPresent())
                //{
                //    NavigationCommonMethods.Logout();
                //    InboxCommonMethods.ShareNotebookWithTeacherHavingInterctive(student, loginTchr, UnitNo);
                //    InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(loginTchr);
                //}

                //InboxCommonMethods.ClickOnSharedItemInbox();

                //if (InboxCommonMethods.VerifyTeacherAnnotationGooglyEyesOpen())
                //    InboxCommonMethods.ClickTeacherAnnotationGooglyEyesOpen();
                //NotebookCommonMethods.ClickNotebookHandIcon();
                //Assert.IsTrue(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "interactive thumnail not found in notebook");

                ////TC54084
                //NotebookCommonMethods.ClickImageThumbnailInNotebook();
                //Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
                //UnitSelectionCommonMethods.ClickInteractiveBackButton();




                //Assert.IsTrue(InboxCommonMethods.VerifyMicrophoneIconInboxNotebook(), "Add page not found");
                //InboxCommonMethods.ClickMicrophoneIconInboxNotebook();
                //NotebookCommonMethods.ClickRecordButton();
                //AutomationAgent.Wait(1500);
                //NotebookCommonMethods.ClickRecordStopButton();
                ////TC54115
                //Assert.IsTrue(InboxCommonMethods.VerifyPlayReRecordAndApplyButtonsReviewAudioUI(), "play, re-record and Apply audio button not found");
                ////TC54117
                //InboxCommonMethods.ClickPlayButtonInboxReviewAudioTeacher();
                //Assert.IsTrue(InboxCommonMethods.VerifyProgressBarInboxReviewAudioTeacher(), "progress bar not found review audio teacher");

                ////TC54118
                //InboxCommonMethods.ClickReRecordButtonInboxReviewAudioTeacher();
                //Assert.IsTrue(NotebookCommonMethods.VerifyMicrophoneRecordAndCloseButtons(), "audio record overlay not found");
                //NotebookCommonMethods.ClickRecordButton();
                //AutomationAgent.Wait(1500);
                //NotebookCommonMethods.ClickRecordStopButton();

                ////TC54120

                //NotebookCommonMethods.ClickNotebookHandIcon();
                //Assert.IsTrue(InboxCommonMethods.VerifyPlayReRecordAndApplyButtonsReviewAudioUI(), "play, re-record and Apply audio button not found tapping outside");
                //InboxCommonMethods.ClickXCloseButtonInboxReviewAudioTeacher();
                //Assert.IsFalse(InboxCommonMethods.VerifyPlayReRecordAndApplyButtonsReviewAudioUI(), "play, re-record and Apply audio button still found tapping X button");


                ////TC54119
                //InboxCommonMethods.ClickMicrophoneIconInboxNotebook();
                //NotebookCommonMethods.ClickRecordButton();
                //AutomationAgent.Wait(1500);
                //NotebookCommonMethods.ClickRecordStopButton();
                //InboxCommonMethods.ClickApplyButtonInboxReviewAudioTeacher();
                //Assert.IsTrue(InboxCommonMethods.VerifyYourFeedbackSavedMessage(), "Your audio feedback was saved message not found");
                //InboxCommonMethods.ClickXCloseButtonInboxReviewAudioTeacher();

                ////TC54121
                //Assert.IsTrue(InboxCommonMethods.VerifyMicrophoneCheckedIconInboxNotebook(), "checked microphone icon not found");
                //InboxCommonMethods.ClickMicrophoneCheckedIconInboxNotebook();
                //Assert.IsTrue(InboxCommonMethods.VerifyRemoveReRecordOnButtonReviewAudio(), "remove re-record not found for existing review audio");
                //Assert.IsTrue(InboxCommonMethods.VerifyPlayProgressBarReviewAudioUI(), "play, progress bar button not found existing audio UI");

                ////TC54122
                //InboxCommonMethods.ClickPlayButtonInboxReviewAudioTeacher();
                //Assert.IsTrue(InboxCommonMethods.VerifyProgressBarInboxReviewAudioTeacher(), "progress bar not found review audio teacher");

                ////T54124
                //InboxCommonMethods.ClickReRecordOnButtonInboxReviewAudioTeacher();
                //Assert.IsTrue(NotebookCommonMethods.VerifyMicrophoneRecordAndCloseButtons(), "audio record overlay not found");
                //NotebookCommonMethods.ClickRecordButton();
                //AutomationAgent.Wait(1500);
                //NotebookCommonMethods.ClickRecordStopButton();


                ////TC54123
                //InboxCommonMethods.ClickRemoveButtonReviewAudio();
                //Assert.IsTrue(InboxCommonMethods.VerifyYourFeedbackRemoved(), "Your feedback removed not found");
                //InboxCommonMethods.ClickXCloseButtonInboxReviewAudioTeacher();
                //Assert.IsFalse(InboxCommonMethods.VerifyMicrophoneCheckedIconInboxNotebook(), "checked microphone icon still found");

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
