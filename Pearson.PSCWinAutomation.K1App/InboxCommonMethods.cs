using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = Microsoft.VisualStudio.TestTools.UITest.Input.MouseButtons;
using Pearson.PSCWinAutomation.Framework;
using Pearson.PSCWinAutomationFramework.__k1App;
using Pearson.PSCWinAutomationFramework._K1App;


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for InboxCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InboxCommonMethods
    {
        public InboxCommonMethods()
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

        public static bool VerifyNoItemsInInboxMessage()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxNoItemMessage");
        }

        public static bool VerifyNoItemsInInboxMessageAtCenter()
        {
            int posx = AutomationAgent.GetControlPositionX("InboxView", "InboxNoItemMessage");
            int screenwidth = AutomationAgent.GetAppWindowWidth();

            return (screenwidth / 2 - posx < 250);
        }

        public static void ClickToggleButtonMath()
        {
            AutomationAgent.Click("InboxView", "InboxToggleButtonMath");
        }

        public static bool VerifySharedItemInboxPresent()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxSharedWorkTileItem");
        }

        public static void ClickOnSharedItemInbox()
        {
            AutomationAgent.Click("InboxView", "InboxSharedWorkTileItem");
        }

        public static bool VerifyTeacherAnnotationGooglyEyesOpen()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "TeacherAnnotationGooglyEyesOpen");
        }

        public static void ClickTeacherAnnotationGooglyEyesOpen()
        {
            AutomationAgent.Click("InboxView", "TeacherAnnotationGooglyEyesOpen");
        }

        public static void ClickTeacherAnnotationGooglyEyesClose()
        {
            AutomationAgent.Click("InboxView", "TeacherAnnotationGooglyEyesClose");
        }

        public static bool VerifyToggleButtonMathSelected()
        {
            return AutomationAgent.VerifyXamlToggleButtonPressed("InboxView", "InboxToggleButtonMath");
        }

        public static void ClickToggleButtonELA()
        {
            AutomationAgent.Click("InboxView", "InboxToggleButtonELA");
        }

        public static bool VerifyToggleButtonELASelected()
        {
            return AutomationAgent.VerifyXamlToggleButtonPressed("InboxView", "InboxToggleButtonELA");
        }

        public static string VerifyStudentNameSharedItemInboxPresent(int tile = 1)
        {
            int childcount = AutomationAgent.GetChildrenControlCount("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            string[] childnames = AutomationAgent.GetChildrenControlNames("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            if (tile == 1)
            {
                if (childcount == 4)
                {
                    return childnames[1];
                }
                if (childcount == 5)
                {
                    return childnames[2];
                }

                else
                    return childnames[2];
            }


            if (childcount == 9 && tile == 2)
            {
                return childnames[6];
            }
            if (childcount == 8 && tile == 2)
            {
                return childnames[5];
            }

            else
                return childnames[7];

           
        }

        public static DateTime VerifyDateTimeStampSharedItemInboxPresent(int tile = 1)
        {
            int childcount = AutomationAgent.GetChildrenControlCount("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            string[] childnames = AutomationAgent.GetChildrenControlNames("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            if (tile == 1)
            {
                if (childcount == 4)
                {
                    return DateTime.Parse(childnames[2]);
                }
                if (childcount == 5)
                {
                    return DateTime.Parse(childnames[3]);
                }
                
                else
                    return DateTime.Parse(childnames[3]);
            }


            if (childcount == 9 && tile == 2)
            {
                return DateTime.Parse(childnames[7]);
            }
            if (childcount == 8 && tile == 2)
            {
                return DateTime.Parse(childnames[6]);
            }

            else
                return DateTime.Parse(childnames[8]);

        }
        public static DateTime VerifyDateTimeStampSharedUnstackedItemInboxPresent(int tile = 1)
        {
            int childcount = AutomationAgent.GetChildrenControlCount("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            string[] childnames = AutomationAgent.GetChildrenControlNames("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            if (tile == 1)
            {
                    return DateTime.Parse(childnames[2]);
            }

            else if (tile==2)
            {
                return DateTime.Parse(childnames[6]);
            }

            else
                return DateTime.Parse(childnames[10]);

        }

        public static bool VerifyUnitNameSharedItemInboxPresent(int tile=1)
        {
            int childcount = AutomationAgent.GetChildrenControlCount("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");

            string[] childnames = AutomationAgent.GetChildrenControlNames("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");


            //if (tile == 1)
            //{
                if (childcount == 4)
                {
                    return childnames[3].Contains("Unit");
                }
                if (childcount == 5)
                {
                    return childnames[4].Contains("Unit");
                }

                else
                    return childnames[4].Contains("Unit");
            //}
            
            
            
            
        }

        public static bool VerifySortingOptionStudentAvailableInbox()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxSortingCalenderMode");
        }

        public static bool VerifySortingOptionCalenderAvailableInbox()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxSortingStudentMode");
        }

        public static bool VerifyMorethan1SharedItemsPresent(int tile=2)
        {
            int childcount = AutomationAgent.GetChildrenControlCount("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");
            return childcount > 5;
        }

        public static void ClickSortingOptionCalenderAvailableInbox()
        {
            AutomationAgent.Click("InboxView", "InboxSortingCalenderMode");
        }

        public static void ClickSortingOptionStudentAvailableInbox()
        {
            AutomationAgent.Click("InboxView", "InboxSortingStudentMode");
        }

        public static bool VerifyNewBannerLabelForSharedItemInbox()
        {
           int childcount =  AutomationAgent.GetChildrenControlCount("InboxView", "InboxSharedWorkTileItem");
           return childcount > 1;
        }

        public static bool VerifyCheckBoxPresentForSharedItemInbox()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxSharedWorkTileItemCheckBox");
        }

        public static void ClickCheckBoxPresentForSharedItemInbox()
        {
            AutomationAgent.Click("InboxView", "InboxSharedWorkTileItemCheckBox");
        }

        public static bool VerifyDeleteButtonAppearedInbox()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxDeleteButton"); 
        }

        public static void ClickDeleteButtonInbox()
        {
            AutomationAgent.Click("InboxView", "InboxDeleteButton");
        }

        public static bool VerifyDeleteTrashCanAppeared()
        {
          return AutomationAgent.VerifyControlExists("LoginView", "LogoutCancel") &&
                                     AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"); 
                
        }

        public static int GetChildCountOfSharedItemsPresent()
        {
            return AutomationAgent.GetChildrenControlCount("InboxView", "InboxScrollViewer", WaitTime.DefaultWaitTime, "1");
        }

        public static bool VerifyStackedItemInboxScreen()
        {
            return AutomationAgent.VerifyAppChildrenByName("Show All Students");
        }

        public static bool VerifyStudentNameStackedItemsUnstackedScreen(string studentname)
        {
            return AutomationAgent.VerifyAppChildrenByName(studentname);
        }

        public static void ClickShowAllStudentsInUnstackedView()
        {
            AutomationAgent.ClickAppChildrenByName("Show All Students");
        }

        internal static bool VerifyInboxScreenSharedWorkLabel()
        {
            return AutomationAgent.VerifyAppChildrenByName("Shared Work");
        }

        public static void ShareNotebookWithTeacherHavingAudio(Login student, Login loginTchr, int UnitNo)
        {
            NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
            Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
            NavigationCommonMethods.NavigateToMathUnit(UnitNo);
            Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
            NavigationCommonMethods.NavigateToNotebook();
            Assert.IsTrue(NavigationCommonMethods.VerifyNotebookScreen(), "notebook not opened");
            NotebookCommonMethods.ClickToOpenNotebookCanvasPage();
            Assert.IsTrue(NotebookCommonMethods.VerifyCameraMicrophoneIconInNotebook(), "Add page not found");
            NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
            Assert.IsTrue(NotebookCommonMethods.VerifyToolsSubMenuOpened(), "microphone camera sub menu not found");
            NotebookCommonMethods.ClickMicrophoneIcon();
            NotebookCommonMethods.ClickRecordButton();
            AutomationAgent.Wait(1500);
            NotebookCommonMethods.ClickRecordStopButton();
            Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");
            Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon present on notebook");
            NotebookCommonMethods.ClickShareAirplaneIcon();
            Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "share noteboo confirm prompt not found");

            NotebookCommonMethods.SelectTeacherinSharePrompt(loginTchr.PersonName);
            NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
            Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
            NotebookCommonMethods.CloseNotebookSentPopup();
            NotebookCommonMethods.ClickBackButtonNotebook();
            NavigationCommonMethods.Logout();

        }

        public static void LoginTeacherAndVerifySharedItemInboxPresent(Login loginTchr)
        {
            NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
            Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
            NavigationCommonMethods.OpenOrCloseSystemTray();
            NavigationCommonMethods.NavigateInboxKGInSystemTray();
            InboxCommonMethods.ClickToggleButtonMath();
            Assert.IsTrue(InboxCommonMethods.VerifySharedItemInboxPresent(), "shared item not found");
        }

        public static void ShareNotebookWithTeacherHavingInterctive(Login student, Login loginTchr, int UnitNo)
        {
            NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
            Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
            NavigationCommonMethods.NavigateToMathUnit(UnitNo);
            Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
            NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
            Assert.IsTrue(NavigationCommonMethods.VerifyInteractiveThumbnailinELA(), "interactive thumbnail not found");
            NavigationCommonMethods.ClickInteractiveThumbnailinELA();
            //Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
            InteractiveCommonMethods.ClickSendToNotebookInteractive();
            //Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
            InteractiveCommonMethods.ClickSendToNotebookPopupCancel();
            //Assert.IsTrue(UnitSelectionCommonMethods.VerifyInteractiveDesignHavingBackNotebookButtonAndHeader(), "interactive thumbnail design not verified");
            InteractiveCommonMethods.ClickSendToNotebookInteractive();
            //Assert.IsTrue(InteractiveCommonMethods.VerifySendToNotebookConfirmationPopup(), "send to notebook confirmation popup not found");
            InteractiveCommonMethods.ClickSendToNotebookPopupAccept();
            AutomationAgent.Wait();
            Assert.IsTrue(NotebookCommonMethods.VerifySnapshotisAvailableInNotebook(), "interactive thumnail not found in notebook");
            

            Assert.IsTrue(NotebookCommonMethods.VerifyShareAirplaneIconPresentInNotebookAtTopLeft(), "share icon present on notebook");
            NotebookCommonMethods.ClickShareAirplaneIcon();
            Assert.IsTrue(NotebookCommonMethods.VerifyShareNotebookConfirmationPrompt(), "share noteboo confirm prompt not found");


            NotebookCommonMethods.SelectTeacherinSharePrompt(loginTchr.PersonName);
            NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
            Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
            NotebookCommonMethods.CloseNotebookSentPopup();
            NotebookCommonMethods.ClickBackButtonNotebook();
            UnitSelectionCommonMethods.ClickInteractiveBackButton();
            NavigationCommonMethods.Logout();
        }

        public static void ClickPlayButtonInboxReviewAudioTeacher()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherReviewAudioPlayNotPlaying");
        }

        public static bool VerifyProgressBarInboxReviewAudioTeacher()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioProgressBar");
        }

        public static void ClickReRecordButtonInboxReviewAudioTeacher()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherReviewAudioReRecord");
        }

        public static void ClickXCloseButtonInboxReviewAudioTeacher()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherReviewAudioClose");
        }

        public static void ClickApplyButtonInboxReviewAudioTeacher()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherReviewAudioApply");
        }

        public static bool VerifyYourFeedbackSavedMessage()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioFeedbackSave");
        }

        public static bool VerifyRemoveReRecordOnButtonReviewAudio()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioReRecordOn") &&
                             AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioRemove");


        }

        public static bool VerifyPlayReRecordAndApplyButtonsReviewAudioUI()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioProgressBar") &&
                        AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioOverlay") &&
                        AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioReRecord") &&
                        AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioApply");
        }

        public static void ClickMicrophoneIconInboxNotebook()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherAudioCommentsMicrophone");
        }

        public static bool VerifyMicrophoneIconInboxNotebook()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherAudioCommentsMicrophone");
        }

        public static void ClickMicrophoneCheckedIconInboxNotebook()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherAudioCommentsMicrophoneChecked");
        }

        public static bool VerifyPlayProgressBarReviewAudioUI()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioProgressBar") &&
                AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioPlayNotPlaying");
        }

        public static void ClickRemoveButtonReviewAudio()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherReviewAudioRemove");
        }

        public static bool VerifyYourFeedbackRemoved()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherReviewAudioFeedbackRemoved");
        }

        internal static bool VerifyMicrophoneCheckedIconInboxNotebook()
        {
            return AutomationAgent.VerifyControlExists("InboxView", "InboxTeacherAudioCommentsMicrophoneChecked");
        }

        public static void ClickReRecordOnButtonInboxReviewAudioTeacher()
        {
            AutomationAgent.Click("InboxView", "InboxTeacherReviewAudioReRecordOn");
        }
    }
}
