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
    /// Summary description for BackupAndRestore
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class BackupAndRestore
    {
        public BackupAndRestore()
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
        [TestCategory("BackupAndRestoreTests"), TestCategory("Sprint24")]
        [Priority(2)]
        [WorkItem(53831)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LessonNotesCreatedShouldbeAbleToBackupOnTheSameDevice()
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
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                //TeacherSupportCommonMethods.ClickMyLessonNotesInTeacherMode();
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                TeacherSupportCommonMethods.ClickMyLessonNotesPaneInTeacherMode();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyUIControlsofAddNotesOverlay(), "Add notes overlay not verified");
                TeacherSupportCommonMethods.AddTextToAddNotesOverlay("test");
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyAddNotesOverlaySaveButtonEnabled(), "save button not enabled");

                TeacherSupportCommonMethods.ClickAddNotesOverlaySaveButton();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoteAddedInLessonNotePane("test"), "newly aded note not found");

                 NavigationCommonMethods.CloseTeacherMode();
                NavigationCommonMethods.Logout();

                AutomationAgent.Wait();
                AutomationAgent.Wait();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.ClickTeacherModeButton();
                NavigationCommonMethods.ClickUnitOverviewMenuItem();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpenUnitOverview(), "Unit overview is not opened in teacher mode");
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyMyLessonNotesPresentInTeacherMode(), "My classroom not found");
                //TeacherSupportCommonMethods.ClickMyLessonNotesInTeacherMode();
                NavigationCommonMethods.ClickUnitHomeScreenTodayBtn();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoteAddedInLessonNotePane("test"), "earlier aded note not backed up");

                NavigationCommonMethods.CloseTeacherMode();
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
