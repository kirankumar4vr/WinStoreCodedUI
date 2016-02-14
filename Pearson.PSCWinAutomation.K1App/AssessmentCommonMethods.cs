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


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for AssessmentCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class AssessmentCommonMethods
    {
        public AssessmentCommonMethods()
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

        public static bool VerifyColdWriteOverlay()
        {
            return AutomationAgent.VerifyControlExists("AssessmentViewColdWrite", "AssessmentColdWritePopup");
        }

        public static bool VerifyColdWriteNotebookIconEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("AssessmentViewColdWrite", "AssessmentColdWriteGoToNotebookButton");
        }

        public static void ClickColdWriteNotebookIcon()
        {
            AutomationAgent.Click("AssessmentViewColdWrite", "AssessmentColdWriteGoToNotebookButton");
        }

        public static bool VerifyColdWritePromptButtonOnTopLeft()
        {
            if (!AutomationAgent.VerifyControlEnabled("AssessmentViewColdWrite", "AssessmentOpenColdWriteNotebook"))
                return false;

            int ControlPosx = AutomationAgent.GetControlPositionX("AssessmentViewColdWrite", "AssessmentOpenColdWriteNotebook");
            int controlposy = AutomationAgent.GetControlPositionY("AssessmentViewColdWrite", "AssessmentOpenColdWriteNotebook");
            return (ControlPosx < 50) && (controlposy<200);
        }

        public static void ClickColdWritePromptButtonOnTopLeft()
        {
            AutomationAgent.Click("AssessmentViewColdWrite", "AssessmentOpenColdWriteNotebook");
        }

        public static void ClickAssessmentColdWriteOverlayBackButton()
        {
            AutomationAgent.Click("AssessmentViewColdWrite", "AssessmentColdWriteGoBackButton");
        }

        public static void ClickELATabUnderAssessmentTab()
        {
            if (AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentManagerSectionButton"))
            {
                AutomationAgent.Click("AssessmentView", "AssessmentManagerSectionButton");
                AutomationAgent.Wait(5000);
            }
            else
            {
                AutomationAgent.Click("SystemTrayView", "AssessmentsManagerButton");
                AutomationAgent.Click("AssessmentView", "AssessmentManagerSectionButton");
                AutomationAgent.Wait(5000);
            }
                
            
        }
        public static bool VerifyAssessmentManagerScreen()
        {
            // WaitForPageToLoad();
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentManagerScreen");
        }
        public static void OpenUnitSelectionDropDown()
        {
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
        }
        /// <summary>
        /// Fixed assessment tab not found
        /// </summary>
        /// <returns></returns>
        public static bool VerifyFixedAssessmentTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FixedAssessmentLink");
        }
        /// <summary>
        /// Verify Ongoing Assessments Tab
        /// </summary>
        /// <returns></returns>
        public static bool VerifyOnGoingAssessmentsTab()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "OnGoingLink");
        }

        public static bool VerifyUnitLabelVisible()
        {
           return AutomationAgent.VerifyControlExists("AssessmentView", "UnitTitleDropDownButton");
        }

        public static bool VerifyLastUpdatedSection()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "LastUpdatedText");
        }
        public static bool VerifyRefreshIcon()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "RefreshButton");
        }

        public static string GetLastUpdatedDate()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "LastUpdatedDateAndTime");
            string[] s1 = s.Split(' ');
            string dateDisplayed = s1[0];
            return dateDisplayed;
        }
        public static string GetLastUpdatedTime()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "LastUpdatedDateAndTime");
            string[] s1 = s.Split(' ');
            string timeDisplayed = s1[2];
            return timeDisplayed;
        }
        public static bool VerifyDateTimeStamp()
        {
            string s = AutomationAgent.GetControlText("AssessmentView", "LastUpdatedDateAndTime").Replace("at", "");
            try
            {
                DateTime date1 = DateTime.Parse(s);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public static bool VerifyListOfAllTheItemsAvailableinUnitTitleDropDown()
        {
            //WaitForPageToLoad();
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            int count = 1;
            for (count = 1; count <= 10; count++)
            {
                try
                {
                    if (!AutomationAgent.VerifyChildrensChildControlByName("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, count.ToString(), "Unit"))
                        break;
                }
                catch
                {
                    return true;
                }
            }
            if (count < 3)
                return false;

            else
                return true;
            //return (AutomationAgent.VerifyChildrensChildControlByName("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, "Unit G-N") &&
            // AutomationAgent.VerifyChildrensChildControlByName("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, "Unit G-1") &&
            // AutomationAgent.VerifyChildrensChildControlByName("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, "Unit 3"));
        }

        public static string[] GetAssessmentManagerSubMenuItemNames()
        {
           // return AutomationAgent.GetChildrenControlNames("SystemTrayView", "AssessmentsManagerSubMenuKindergartenButton");
            return AutomationAgent.GetChildrenControlNames("AssessmentView", "AssessmentManagerSectionButton");
        }

        public static string[] GetAssessmentReportSubMenuItemNames()
        {
            //return AutomationAgent.GetChildrenControlNames("SystemTrayView", "AssessmentsReportSubMenuKindergartenButton");
            return AutomationAgent.GetChildrenControlNames("AssessmentView", "AssessmentReportSectionButton");
        }

        public static int GetChildrenCountToValidateDesignForAssmtManager()
        {
            return AutomationAgent.GetChildrenControlCount("SystemTrayView", "AssessmentsManagerButton");
        }

        public static int GetChildrenCountToValidateDesignForAssmtReport()
        {
            return AutomationAgent.GetChildrenControlCount("SystemTrayView", "AssessmentsReportButton");
        }

        public static void AssessmentUnitSelection(string unitNumber)
        {
            AutomationAgent.Wait(2000);
            
            AutomationAgent.Click("AssessmentView", "UnitTitleDropDownButton");
            AutomationAgent.Click("AssessmentView", "DropdownUnitSelect", WaitTime.DefaultWaitTime, unitNumber);

        }

        public static bool AssessmentsInPendingStatus()
        {
            bool found = false;
            
            for(int i =1; i<=5;i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "ListViewItem", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    if (AutomationAgent.VerifyControlExists("AssessmentView", "Pending", WaitTime.DefaultWaitTime, i.ToString()))
                    {
                        found = true;
                        continue;
                    }
                    else
                        break;
                  
                }
                else
                    break;
            }
            return found;
        }

        public static bool VerifySubstatusInFixedAssessments()
        {
            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, "1");
            int countofchildren = AutomationAgent.GetChildrenControlCount("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, "1");
            Assert.IsTrue(names[1].Contains("Pending"));
            Assert.IsTrue(names[2].Contains("Started:  0 / 5"));
            return  (names[1].Contains("Pending") && (names[2].Contains("Started:  0 / 5")) && (countofchildren == 3));
        }

        public static bool VerifyUnitNameAndCourse()
        {
          return  AutomationAgent.VerifyControlExists("AssessmentView", "UnitTitleDropDownButton", WaitTime.DefaultWaitTime, "");
        }

        public static bool VerifyAssessmentsFromUnitOpened()
        {
            string[] names = AutomationAgent.GetChildrenControlNames("AssessmentView", "FixedAssessmentButton", WaitTime.DefaultWaitTime, "1");
            string[] assessmentnames = names[0].Split(' ');
            return assessmentnames[1].Contains("3");

        }

        public static bool VerifyScreenScrolledVertically(int FixedAssessmentNumber)
        {
            AssessmentCommonMethods.SwipeUp();
            return AssessmentCommonMethods.VerifyFixedAssessmentNavigationArrow(FixedAssessmentNumber);
        }
        public static void SwipeUp()
        {
            AutomationAgent.Wait();
            AutomationAgent.Slide(567, 983, 620, 250);
        }

        public static bool VerifyFixedAssessmentNavigationArrow(int FixedAssessmentNumber)
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, FixedAssessmentNumber.ToString());
        }
        public static void ClickRefreshIcon()
        {
            AutomationAgent.Click("AssessmentView", "RefreshButton");
        }
        /// <summary>
        /// Verifies Assessment overview title
        /// </summary>
        /// <returns>bool: true(if found)</returns>
        public static bool VerifyAssessmentOverviewTitle()
        {
            return AutomationAgent.VerifyControlExists("AssessmentView", "AssessmentOverviewTitle");
        }
        /// <summary>
        /// Clicks fixed assessment 
        /// </summary>
        /// <param name="FixedAssessmentNumber">Fixed ssessment number</param>
        public static void ClickFixedAssessmentNavigationArrow(int FixedAssessmentNumber)
        {
            WaitForPageToLoad();
            AutomationAgent.VerifyControlExists("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, FixedAssessmentNumber.ToString());
            AutomationAgent.Click("AssessmentView", "FixedAssessmentsItem", WaitTime.DefaultWaitTime, FixedAssessmentNumber.ToString());
            WaitForPageToLoad();
        }

        public static void WaitForPageToLoad()
        {
            AutomationAgent.Wait();
            for (int i = 0; i < 5; i++)
            {
                if (AutomationAgent.VerifyControlExists("AssessmentView", "PageLoadImage"))
                {
                    AutomationAgent.Wait(10000);
                }
                else
                {
                    break;
                }
            }
        }

    }
}
