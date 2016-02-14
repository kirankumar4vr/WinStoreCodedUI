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


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for TeacherModeCommonMethods
    /// </summary>
    
    public class TeacherModeCommonMethods
    {
        /// <summary>
        /// Verifies the Teacher Mode Fly Out Header displaying Teacher Guide
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if Teacher Guide Fly Out Header found), false(if Fly Out header not found)</returns>
        public static bool VerifyTeacherGuideFlyOutHeader()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeTeacherGuideTitle");
        }

        /// <summary>
        /// Verifies the TeacherGuideIcon
        /// </summary>
        /// <param name="teachermodeAutomationAgent">AutomationAgent object</param>
        /// <returns>bool:true(if TeacherGuideIcon found),false(if TeacherGuideIcon not Found)</returns>
        public static bool VerifyTeacherGuideIcon()
        {
            return (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA"));
        }
        /// <summary>
        /// Get Width of Teacher Mode in Opened state
        /// </summary>
        /// <returns>width of Accordion</returns>
        public static int GetWidthOfTeacherModePanel()
        {
            return AutomationAgent.GetControlWidth("TeacherModeView", "TeacherModeAccordion");
        }
        /// <summary>
        /// Clicks on the Teacher Mode Arrow Icon 
        /// </summary>
        public static void ClickOnTeacherModeArrowIcon()
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeAccordionExpand");
        }

        public static bool VerifyClassRosterOpened()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "StudentTileInClassRoster", WaitTime.DefaultWaitTime, "1") &&
                                  AutomationAgent.VerifyControlExists("LessonView", "BackButtonInLessonPage");
        }

        public static void ClickStudentTileInClassRoster(int StudentTile)
        {
            AutomationAgent.Click("TeacherModeView", "StudentTileInClassRoster", WaitTime.DefaultWaitTime, StudentTile.ToString());
        }

        public static bool VerifyStudentInformationRosterOpened()
        {
            string controltext = AutomationAgent.GetControlText("UnitPreviewView", "BackButton");
            return controltext.Contains("Roster");
        }

        public static bool VerifyStudentInformationControls()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "StudentInformationLabel") &&
                     AutomationAgent.VerifyControlExists("TeacherModeView", "StudentFullName") &&
                     AutomationAgent.VerifyControlExists("TeacherModeView", "StudentInformationSchoolName") &&
                    AutomationAgent.VerifyControlExists("TeacherModeView", "StudentInformationGrade") &&
                    AutomationAgent.VerifyControlExists("TeacherModeView", "StudentInformationGender") &&
                      AutomationAgent.VerifyControlExists("TeacherModeView", "StudentInformationDOB");
        }
        /// <summary>
        /// Clicks on Unit Overview
        /// </summary>
        public static void ClickUnitOverview()
        {
            AutomationAgent.Click("TeacherModeView", "UnitOverviewButton");
        }
        /// <summary>
        /// Verifies Content Unavailable
        /// </summary>
        /// <returns>bool:true(if ContentUnavailable found),false(if ContentUnavailable not Found)</returns>
        public static bool VerifyContentUnavailable()
        {
             return AutomationAgent.VerifyControlExists("TeacherModeView", "ContentUnavailable");
        }
        /// <summary>
        /// Verifies if Teacher Guide Fly Out Open or not
        /// </summary>
        /// <returns>bool: true(if fly out opened), false(if not opened)</returns>
        public static bool VerifyTeacherModeFlyoutOpen()
        {
            AutomationAgent.WaitForControlExists("TopAppToolBarView", "PopUpWindow");
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "TeacherGuideTextInFlyOut");
        }

        public static bool VerifyTeacherModeFlyOutMenus()
        {
            if (AutomationAgent.VerifyControlExists("TopAppToolBarView", "UnitOverviewButton") &&
               AutomationAgent.VerifyControlExists("TopAppToolBarView", "LessonOverviewButton") &&
               AutomationAgent.VerifyControlExists("TopAppToolBarView", "TaskOverviewButton"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the Class Roster
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyClassRoster()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "MyClassInTeacherMode");
        }
    }

}
