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
    /// Summary description for InboxTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class InboxTests
    {
        public InboxTests()
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
        [Priority(2)]
        [WorkItem(53997)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ATeacherInboxEmptyInboxMessage()
        {
            try
            {
                Login loginTchr = Login.GetLogin("TeacherAdbul");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();
                Assert.IsTrue(InboxCommonMethods.VerifyNoItemsInInboxMessage(), "empty inbox message not found");
                Assert.IsTrue(InboxCommonMethods.VerifyNoItemsInInboxMessageAtCenter(), "empty inbo message text position not at center");
                NavigationCommonMethods.Logout();
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
        [WorkItem(54085), WorkItem(54101), WorkItem(54087), WorkItem(54104), WorkItem(54110), WorkItem(53996), WorkItem(53998), WorkItem(54094), WorkItem(54103), WorkItem(54511), WorkItem(54515), WorkItem(54522), WorkItem(54530), WorkItem(54533), WorkItem(54539), WorkItem(54565), WorkItem(54566), WorkItem(54568)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BTeacherInbox_TeacherReviewofSharedWork_AudioMediaFileShouldPlayedSuccessfullyThroughSharedNotebookPage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(0);
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

                Login loginTchr = Login.GetLogin("TeacherAdbul");
                NotebookCommonMethods.SelectTeacherinSharePrompt(loginTchr.PersonName);
                NotebookCommonMethods.ClickCheckSendIconInSharePrompt();
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
                NotebookCommonMethods.CloseNotebookSentPopup();
                NotebookCommonMethods.ClickBackButtonNotebook();
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();
                InboxCommonMethods.ClickToggleButtonMath();
                //TC54511
                Assert.IsTrue(InboxCommonMethods.VerifySharedItemInboxPresent(), "shared item not found");

                //TC53996
                Assert.IsTrue(InboxCommonMethods.VerifyNewBannerLabelForSharedItemInbox(), "New banner label for inbox item not found");
                //TC53998
                Assert.IsTrue(InboxCommonMethods.VerifyCheckBoxPresentForSharedItemInbox(), "New banner label for inbox item not found");

                //TC54515
                InboxCommonMethods.ClickOnSharedItemInbox();

                if (InboxCommonMethods.VerifyTeacherAnnotationGooglyEyesOpen())
                    InboxCommonMethods.ClickTeacherAnnotationGooglyEyesOpen();
                NotebookCommonMethods.ClickNotebookHandIcon();
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");
                //TC54101 && TC54094
                NotebookCommonMethods.ClickOnMediaInsertedInNotebook();
                NotebookCommonMethods.ClickAudioNotPlayingThumbnail();
                Assert.IsTrue(NotebookCommonMethods.VerifyAudioPlayingThumbnail(), "audio not played");
                Assert.IsFalse(NotebookCommonMethods.VerifyRedCloseXButton(), "red close x button found");

                //TC54087 && TC54103
                   // Assert.IsFalse(NotebookCommonMethods.VerifyBasicToolbarsNotEnabled(), "notebook design toolbar enabled");

                //TC54104 && TC54522
                InboxCommonMethods.ClickTeacherAnnotationGooglyEyesClose();
                Assert.IsTrue(NotebookCommonMethods.VerifyCrayonToolIconSelected(), "crayon tool not selected");
                NavigationCommonMethods.SwipeScreenDown();

                //TC54110
                NotebookCommonMethods.ClickBackButtonNotebook();
                InboxCommonMethods.ClickOnSharedItemInbox();
                Assert.IsTrue(NotebookCommonMethods.VerifyCrayonToolIconSelected(), "crayon tool not selected");


                //TC54530
                Assert.IsTrue(NotebookCommonMethods.VerifyTeacherShareAirplaneIconPresentInNotebookAtTopLeft(), "share airplane icon not found");
                NotebookCommonMethods.ClickTeacherShareAirplaneIconPresentInNotebook();
                AutomationAgent.Wait();
                //TC54533
                Assert.IsTrue(NotebookCommonMethods.VerifyNotebookSentMessage(), "notebook sent message not found");
                NotebookCommonMethods.CloseNotebookSentPopup();
                //TC54568
                Assert.IsTrue(NotebookCommonMethods.VerifyHandIconEnabled(), "hand icon not found");
                NotebookCommonMethods.ClickBackButtonNotebook();
                //TC54566
                Assert.IsTrue(InboxCommonMethods.VerifyInboxScreenSharedWorkLabel(), "Inbox screen not found");
                
                NavigationCommonMethods.Logout();
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
        [WorkItem(53982),WorkItem(53983), WorkItem(53984)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherInboxMathsView()
        {
            try
            {
                Login loginTchr = Login.GetLogin("TeacherAdbul");
                Login student = Login.GetLogin("StudentKevin");
                int UnitNo = 0;
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();
                
                InboxCommonMethods.ClickToggleButtonELA();
                Assert.IsTrue(InboxCommonMethods.VerifyToggleButtonELASelected(), "Math toggle button not selected");

                InboxCommonMethods.ClickToggleButtonMath();
                Assert.IsTrue(InboxCommonMethods.VerifyToggleButtonMathSelected(), "Math toggle button not selected");

                
                if(!InboxCommonMethods.VerifySharedItemInboxPresent())
                {
                    NavigationCommonMethods.Logout();
                    InboxCommonMethods.ShareNotebookWithTeacherHavingAudio(student, loginTchr, UnitNo);
                    InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(loginTchr);
                }

                Assert.IsTrue(InboxCommonMethods.VerifyStudentNameSharedItemInboxPresent().Contains(student.PersonName), "student name not found in inbox shared item");
                //Assert.IsTrue(InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent(), "date time stamp in  Date = MM/DD/YYYY and Timestamp = HH:MM AM or HH:MM PM not found in inbox shared item");
                DateTime dttime = InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent();
                Assert.IsTrue(InboxCommonMethods.VerifyUnitNameSharedItemInboxPresent(), "student name not found in inbox shared item");
                
                NavigationCommonMethods.Logout();
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
        [WorkItem(53991),WorkItem(53992), WorkItem(53993)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherInboxMathsViewSorting()
        {
            try
            {
                Login loginTchr = Login.GetLogin("TeacherAdbul");
                Login student = Login.GetLogin("StudentKevin");
                Login student2 = Login.GetLogin("StudentSophia");
                int UnitNo = 0;
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();

                InboxCommonMethods.ClickToggleButtonELA();
                Assert.IsTrue(InboxCommonMethods.VerifyToggleButtonELASelected(), "Math toggle button not selected");

                InboxCommonMethods.ClickToggleButtonMath();
                Assert.IsTrue(InboxCommonMethods.VerifyToggleButtonMathSelected(), "Math toggle button not selected");


                if (!InboxCommonMethods.VerifySharedItemInboxPresent())
                {
                    NavigationCommonMethods.Logout();
                    NavigationCommonMethods.Logout();
                    InboxCommonMethods.ShareNotebookWithTeacherHavingAudio(student, loginTchr, UnitNo);
                    InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(loginTchr);

                }

                Assert.IsTrue(InboxCommonMethods.VerifyStudentNameSharedItemInboxPresent().Contains(student.PersonName)||
                InboxCommonMethods.VerifyStudentNameSharedItemInboxPresent().Contains(student2.PersonName), "student name not found in inbox shared item");
              //  Assert.IsTrue(InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent(), "date time stamp in  Date = MM/DD/YYYY and Timestamp = HH:MM AM or HH:MM PM not found in inbox shared item");
                DateTime dttime = InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent();
                Assert.IsTrue(InboxCommonMethods.VerifyUnitNameSharedItemInboxPresent(), "student name not found in inbox shared item");
                DateTime dttimeTile2=dttime;
                if (InboxCommonMethods.VerifyMorethan1SharedItemsPresent())
                {
                    dttimeTile2 = InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent(2);
                }

                else
                {
                    NavigationCommonMethods.Logout();
                    InboxCommonMethods.ShareNotebookWithTeacherHavingAudio(student2, loginTchr, UnitNo);
                    InboxCommonMethods.LoginTeacherAndVerifySharedItemInboxPresent(loginTchr);
                    dttimeTile2 = InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent(2);
                }


                Assert.IsTrue(dttimeTile2 < dttime, "date time is not sorted for inbox tiles");


                Assert.IsTrue(InboxCommonMethods.VerifySortingOptionStudentAvailableInbox(), "sorting option student not found");
                Assert.IsTrue(InboxCommonMethods.VerifySortingOptionCalenderAvailableInbox(), "sorting option datetime not found");

                InboxCommonMethods.ClickSortingOptionCalenderAvailableInbox();
                dttime = InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent();
                dttimeTile2 = InboxCommonMethods.VerifyDateTimeStampSharedItemInboxPresent(2);
                Assert.IsTrue(dttimeTile2 <dttime, "date time is not sorted for inbox tiles from calender sorting");

                InboxCommonMethods.ClickSortingOptionStudentAvailableInbox();
                string studentname = InboxCommonMethods.VerifyStudentNameSharedItemInboxPresent();
                string studentname2 = InboxCommonMethods.VerifyStudentNameSharedItemInboxPresent(2);
                Assert.IsTrue(string.Compare(studentname, studentname2) > 0, "student name is not sorted for inbox tiles from student sorting");

                NavigationCommonMethods.Logout();
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
        [WorkItem(54000), WorkItem(54001)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherInboxUserShouldBeAbleToDelete()
        {
            try
            {
                Login loginTchr = Login.GetLogin("TeacherAdbul");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();
                //TC53998
                Assert.IsTrue(InboxCommonMethods.VerifyCheckBoxPresentForSharedItemInbox(), "New banner lable for inbox item not found");
                int tilechild = InboxCommonMethods.GetChildCountOfSharedItemsPresent();
                
                
                InboxCommonMethods.ClickCheckBoxPresentForSharedItemInbox();
                Assert.IsTrue(InboxCommonMethods.VerifyDeleteButtonAppearedInbox(), "delete button not found");
                InboxCommonMethods.ClickDeleteButtonInbox();
                Assert.IsTrue(InboxCommonMethods.VerifyDeleteTrashCanAppeared(), "delete trash can not found");

                //TC54001
                LoginCommonMethods.ClickOnLogoutCancelButton();
                Assert.IsFalse(InboxCommonMethods.VerifyDeleteTrashCanAppeared(), "delete trash still found");
                int tilechildNow = InboxCommonMethods.GetChildCountOfSharedItemsPresent();
                Assert.IsTrue(tilechild == tilechildNow, "Item got deleted even clicking on cancel button");

                NavigationCommonMethods.Logout();
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
        [WorkItem(54275), WorkItem(54300)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UTeacherInboxUnstackingSharedWorkItemsELA_StackedViewInTeacherInbox()
        {
            try
            {

                Login loginTchr = Login.GetLogin("TeacherAdbul");
                Login student = Login.GetLogin("StudentKevin");
                Login student2 = Login.GetLogin("StudentSophia");
                int UnitNo = 0;

                //Share for teacher inbox - create stack
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(UnitNo);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();

                for (int i = 0; i < 2; i++)
                {
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


                    if(i==0)
                    {
                        NotebookCommonMethods.ClickAddPageButtonNotebookScreen();
                    }

                }
                NavigationCommonMethods.Logout();

                //Teacher - Stacked items
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();
                InboxCommonMethods.ClickToggleButtonELA();
                Assert.IsTrue(InboxCommonMethods.VerifySharedItemInboxPresent(), "shared item not found");

                //TC54277
                InboxCommonMethods.ClickOnSharedItemInbox();
                Assert.IsTrue(InboxCommonMethods.VerifyStackedItemInboxScreen(), "stacked items screen not found");
                //TC54300
                Assert.IsTrue(InboxCommonMethods.VerifyStudentNameStackedItemsUnstackedScreen(student.PersonName), "student name not found unstacjed screen");
                Assert.IsTrue(InboxCommonMethods.VerifyMorethan1SharedItemsPresent(), "students items not unstacked");






                NavigationCommonMethods.Logout();
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
        [WorkItem(54277), WorkItem(54306), WorkItem(54314), WorkItem(54315), WorkItem(54316), WorkItem(54317), WorkItem(53994), WorkItem(53995)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UTeacherInboxUnstackingSharedWorkItems_StackedViewInTeacherInbox()
        {
            try
            {

                Login loginTchr = Login.GetLogin("TeacherAdbul");
                Login student = Login.GetLogin("StudentKevin");
                Login student2 = Login.GetLogin("StudentSophia");
                int UnitNo = 0;
 
                //Share for teacher inbox - create stack
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(student);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToMathUnit(UnitNo);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToNotebook();

                for (int i = 0; i < 2; i++)
                {
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
                    if (i == 0)
                    {
                        NotebookCommonMethods.ClickAddPageButtonNotebookScreen();
                    }
                }
                    
                    NavigationCommonMethods.Logout();
                
                //Teacher - Stacked items
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(loginTchr);
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.NavigateInboxKGInSystemTray();
                InboxCommonMethods.ClickToggleButtonMath();
                Assert.IsTrue(InboxCommonMethods.VerifySharedItemInboxPresent(), "shared item not found");

                //TC54277
                InboxCommonMethods.ClickOnSharedItemInbox();
                Assert.IsTrue(InboxCommonMethods.VerifyStackedItemInboxScreen(), "stacked items screen not found");
                //TC54306
                Assert.IsTrue(InboxCommonMethods.VerifyStudentNameStackedItemsUnstackedScreen(student.PersonName), "student name not found unstacjed screen");
                Assert.IsTrue(InboxCommonMethods.VerifyMorethan1SharedItemsPresent(), "students items not unstacked");

                //TC54315
                Assert.IsTrue(InboxCommonMethods.VerifyNewBannerLabelForSharedItemInbox(), "New banner lable for inbox item not found");
                ////TC53998
                //Assert.IsTrue(InboxCommonMethods.VerifyCheckBoxPresentForSharedItemInbox(), "New banner lable for inbox item not found")


                //TC54314
               DateTime dttime = InboxCommonMethods.VerifyDateTimeStampSharedUnstackedItemInboxPresent();
               DateTime dttimeTile2 = InboxCommonMethods.VerifyDateTimeStampSharedUnstackedItemInboxPresent(2);
                Assert.IsTrue(dttimeTile2 < dttime, "date time is not chronological ordered for inbox unstacked tiles");

                //TC54316
                InboxCommonMethods.ClickShowAllStudentsInUnstackedView();
                Assert.IsFalse(InboxCommonMethods.VerifyStackedItemInboxScreen(), "stacked items screen still found");
                //TC54317
                Assert.IsFalse(InboxCommonMethods.VerifyStudentNameStackedItemsUnstackedScreen(student.PersonName), "student name still found unstacjed screen");
                Assert.IsTrue(InboxCommonMethods.VerifySortingOptionStudentAvailableInbox(), "sorting option student not found");
                Assert.IsTrue(InboxCommonMethods.VerifySortingOptionCalenderAvailableInbox(), "sorting option datetime not found");
                Assert.IsTrue(InboxCommonMethods.VerifyInboxScreenSharedWorkLabel(), "beige header not changed to shared items");

                NavigationCommonMethods.Logout();
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
