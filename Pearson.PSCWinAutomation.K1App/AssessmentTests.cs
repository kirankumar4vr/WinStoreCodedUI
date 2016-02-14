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
    /// Summary description for AssessmentTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class AssessmentTests
    {
        public AssessmentTests()
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
        [TestCategory("AssessmentTests"), TestCategory("US10215")]
        [Priority(2)]
        [WorkItem(53973), WorkItem(53974), WorkItem(53976)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void TeacherAssessmentManagerScreen()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                AssessmentCommonMethods.ClickELATabUnderAssessmentTab();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "manager screen not found");
                AssessmentCommonMethods.OpenUnitSelectionDropDown();
                Assert.IsTrue(AssessmentCommonMethods.VerifyUnitLabelVisible(), "Unit label not visible");
                AutomationAgent.Click(100, 100);
                //53973


                Assert.IsTrue(AssessmentCommonMethods.VerifyFixedAssessmentTab(), "Fixed assessment tab not found");
                Assert.IsTrue(AssessmentCommonMethods.VerifyOnGoingAssessmentsTab(), "Ongoing assessment tab not found");
                //53974

                Assert.IsTrue(AssessmentCommonMethods.VerifyLastUpdatedSection(), "Last Updated Section is not displayed");
                Assert.IsTrue(AssessmentCommonMethods.VerifyRefreshIcon(), "Refresh icon is not visible");

                Assert.IsTrue(AssessmentCommonMethods.VerifyDateTimeStamp(), "Date Time Stamp Not found");
                //53976


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
        [TestCategory("AssessmentTests"), TestCategory("US10219")]
        [Priority(2)]
        [WorkItem(53977),WorkItem(54027),WorkItem(54029), WorkItem(54042), WorkItem(54034)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void TeacherAssessmentManagerUnitDropdownMenu()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                AssessmentCommonMethods.ClickELATabUnderAssessmentTab();
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "manager screen not found");
                AssessmentCommonMethods.OpenUnitSelectionDropDown();
                AutomationAgent.Click(100, 100);
                NavigationCommonMethods.OpenOrCloseSystemTray();
                string assertFailureMessage;
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayMenu(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.OpenOrCloseSystemTray();
                //54042

                Assert.IsTrue(AssessmentCommonMethods.VerifyListOfAllTheItemsAvailableinUnitTitleDropDown(),"items not available");
                AutomationAgent.Click(100, 100);
                //54029

                AssessmentCommonMethods.OpenUnitSelectionDropDown();
                AssessmentCommonMethods.AssessmentUnitSelection("1");
                Assert.IsTrue(AssessmentCommonMethods.AssessmentsInPendingStatus(),"Pending assessment not found");
                //54034,54027,53977

               Assert.IsTrue(AssessmentCommonMethods.VerifySubstatusInFixedAssessments(),"Substatus didnt get match");
                //53955

               Assert.IsTrue(AssessmentCommonMethods.VerifyUnitNameAndCourse(),"Unit Name And Course Not found");
               Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentsFromUnitOpened(), "Assessments are notf rom that unit");
                //54034

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
        [TestCategory("AssessmentTests"), TestCategory("US10217")]
        [Priority(2)]
        [WorkItem(53955)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifySubstatusInFixedAssessments()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                AssessmentCommonMethods.ClickELATabUnderAssessmentTab();
                AssessmentCommonMethods.OpenUnitSelectionDropDown();
                AssessmentCommonMethods.AssessmentUnitSelection("1");
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "manager screen not found");
                AutomationAgent.Wait(10000);
                Assert.IsTrue(AssessmentCommonMethods.VerifySubstatusInFixedAssessments(), "Substatus didnt get match");
                //53955
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
        [TestCategory("AssessmentTests"), TestCategory("US10318")]
        [Priority(2)]
        [WorkItem(53975)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyAssessmentManagerScreenDetails()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                AssessmentCommonMethods.ClickELATabUnderAssessmentTab();

                Assert.IsTrue(AssessmentCommonMethods.VerifyScreenScrolledVertically(1), "Screen ddint get scrolled vertically");
                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentManagerScreen(), "manager screen not found");
               
                //53955
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
        [TestCategory("AssessmentTests"), TestCategory("US10441")]
        [Priority(1)]
        [WorkItem(54148)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyRefreshButtonDatetimeStamp()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                AssessmentCommonMethods.ClickELATabUnderAssessmentTab();

                Assert.IsTrue(AssessmentCommonMethods.VerifyLastUpdatedSection(), "Last Updated Section is not displayed");
                string OldTime1 = AssessmentCommonMethods.GetLastUpdatedTime();
                string lastUpdatedDate1 = AssessmentCommonMethods.GetLastUpdatedDate();
                AutomationAgent.Wait(60000);
                AssessmentCommonMethods.ClickRefreshIcon();
                DateTime today = DateTime.Today;
                string todayDate1 = today.ToString("MM-dd-yyyy").Replace("-", "/");
                string lastUpdatedDate2 = AssessmentCommonMethods.GetLastUpdatedDate();
                string NewTime1 = AssessmentCommonMethods.GetLastUpdatedTime();
                Assert.AreEqual(lastUpdatedDate2, lastUpdatedDate1, "Last Updated Date is not updated as per system date");
                Assert.AreEqual(todayDate1, lastUpdatedDate1, "Last Updated Date is not updated as per system date");

                Assert.AreNotEqual(OldTime1, NewTime1, "Time is not updated after clicking refresh icon");
                
                //53955
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


        //Sprint-26
        [TestMethod()]
        [TestCategory("AssessmentTests"), TestCategory("Sprint26"), TestCategory("US10425")]
        [Priority(2)]
        [WorkItem(54060), WorkItem(54062), WorkItem(54063), WorkItem(54064), WorkItem(54066)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void  Assessments_SystemTraySectionSelectorForAssessmentManagerAndReports()
        {
            try 
            {
                Login loginTchr = Login.GetLogin("TeacherAdbul");

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
               
                //TC54060
                Assert.IsTrue(NavigationCommonMethods.VerifyAssessmentManagerMenuInSystemTray(), "assessment manager menu not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyAssessmentReportMenuInSystemTray(), "assessment manager menu not found");

                //TC54062
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyAssessmentManagerSubMenusInSystemTray(), "asseessment manager submenu not verified");
               
                //TC54064
                string[] AssessmentManagerSubMenuName = AssessmentCommonMethods.GetAssessmentManagerSubMenuItemNames();
                Assert.IsTrue(AssessmentManagerSubMenuName[0].Contains(loginTchr.SectionedGrades[0].ToString()), "user associated grade not verified");
                NavigationCommonMethods.ClickAssessmentReportsInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyAssessmentReportsSubMenusInSystemTray(), "asseessment reports submenu not verified");
                string[] AssessmentReportSubMenuName = AssessmentCommonMethods.GetAssessmentReportSubMenuItemNames();
                Assert.IsTrue(AssessmentReportSubMenuName[0].Contains(loginTchr.SectionedGrades[0].ToString()), "user associated grade not verified");

                //TC54066
                int childcountAssessmentManagerToVerifyUIDesign = AssessmentCommonMethods.GetChildrenCountToValidateDesignForAssmtManager();
                int childcountAssessmentReportToVerifyUIDesign = AssessmentCommonMethods.GetChildrenCountToValidateDesignForAssmtReport();
                Assert.IsTrue(childcountAssessmentManagerToVerifyUIDesign == childcountAssessmentReportToVerifyUIDesign, "Assessment manager & report design not similar");
                NavigationCommonMethods.OpenOrCloseSystemTray();
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
        [TestCategory("AssessmentTests"), TestCategory("Sprint26"), TestCategory("US10425")]
        [Priority(2)]
        [WorkItem(54068)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Assessments_SystemTraySectionSelectorForAssessmentManagerAndReportsNotAvailableNonSectionedTeacher()
        {
            try
            {
                //Need to verify - Non sectioned teacher credentials
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherChandler"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsFalse(NavigationCommonMethods.VerifyAssessmentManagerMenuInSystemTray(), "assessment manager menu not found");
                Assert.IsFalse(NavigationCommonMethods.VerifyAssessmentReportMenuInSystemTray(), "assessment manager menu not found");
                NavigationCommonMethods.OpenOrCloseSystemTray();
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
        [TestCategory("AssessmentTests"), TestCategory("US10221")]
        [Priority(2)]
        [WorkItem(54340)]
        [Owner("Varun Bhardwaj(varun.bhardwaj)")]
        public void VerifyAssessmentOverviewScreen()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.OpenOrCloseSystemTray();
                NavigationCommonMethods.ClickAssessmentManagerSystemTray();
                AssessmentCommonMethods.ClickELATabUnderAssessmentTab();
                AssessmentCommonMethods.OpenUnitSelectionDropDown();
                AssessmentCommonMethods.AssessmentUnitSelection("2");
                AssessmentCommonMethods.ClickFixedAssessmentNavigationArrow(1);

                Assert.IsTrue(AssessmentCommonMethods.VerifyAssessmentOverviewTitle(), "Title not found");


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
