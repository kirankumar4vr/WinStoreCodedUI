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
using System.IO;
using System.Text;
using System.Configuration;


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for TeacherSupportCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class TeacherSupportCommonMethods
    {
        public TeacherSupportCommonMethods()
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
        /// <summary>
        /// Verifies teacher Suppport Page
        /// </summary>
        /// <returns></returns>
        public static bool VerifyTeacherSupportPage()
        {
            if (AutomationAgent.VerifyControlExists("TeacherSupportView", "GrowYourSkillsBtn") &&
             AutomationAgent.VerifyControlExists("TeacherSupportView", "PrepareYourLessonBtn") &&
             AutomationAgent.VerifyControlExists("TeacherSupportView", "GetHelpBtn"))
                return true;

            else
                return false;
        }

        public static void ClickTeacherModeExpandButton()
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeExpandButton");
        }

        public static bool VerifyTeacherModeIsFullScreen()
        {
            AutomationAgent.Wait();
            int screen = AutomationAgent.GetAppWindowWidth();
            int widthTeachermode = AutomationAgent.GetControlWidth("TeacherModeView", "TeacherModePane");

            return (screen == widthTeachermode);
        }

        public static bool VerifyTeacherGuideFlyoutLessonOverviewEnabled()
        {
            bool b = AutomationAgent.VerifyControlEnabled("TeacherModeView", "LessonOverviewMenuItem");
            return b;
        }

        public static bool VerifyTeacherGuideFlyoutLessonGuideEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("TeacherModeView", "LessonGuideMenuItem");
        }

        public static bool VerifyUnitOverviewTitleisAtScreenCenter()
        {
            int screen = AutomationAgent.GetAppWindowWidth();
            int TitlePosX =  AutomationAgent.GetControlPositionX("TeacherModeView", "UnitOverviewTeacherMode");
            int widthTeachermode = AutomationAgent.GetControlWidth("TeacherModeView", "UnitOverviewTeacherMode");

            if (TitlePosX + 60 > screen / 2 && TitlePosX + 20 < screen / 2)
                return true;

            else
                return false;

        }

        public static bool VerifyTeacherGuideFlyoutMenuItems()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "LessonGuideMenuItem") &&
                AutomationAgent.VerifyControlExists("TeacherModeView", "LessonOverviewMenuItem") &&
                AutomationAgent.VerifyControlExists("TeacherModeView", "UnitOverviewMenuItem");

        }

        public static bool VerifyBrowserOpenedforTeacherSupport(string BrowserControl)
        {
            return AutomationAgent.VerifyDesktopChildByName(BrowserControl);
        }

        public static bool VerifyMyClassRosterPresentInTeacherMode()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeMyClassRoster");
        }

        public static void ClickMyClassRosterInTeacherMode()
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeMyClassRoster");
        }

        public static bool VerifyTeacherCanSeeStudentsInClassRoster(int studentTile=1)
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeMyClassRosterStudentListTile", WaitTime.DefaultWaitTime, studentTile.ToString())
                || AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeClassRosterNoStudents");
        }

        public static bool VerifyStudentNameAlphabeticInClassRoster()
        {
            string[] studentnames = new string[10];

            for (int i=1;i<4;i++)
            {
                studentnames[i-1] = AutomationAgent.GetControlText("TeacherModeView", "TeacherModeMyClassRosterStudentListTileName", WaitTime.DefaultWaitTime, i.ToString());
            }

            if (studentnames[0].CompareTo(studentnames[1]) < 0 && studentnames[1].CompareTo(studentnames[2]) < 0)
                return true;

            else
                return false;

        }

        public static bool VerifyClassRosterOfflineMessage(string offlinemessage)
        {
            return AutomationAgent.VerifyAppChildrenByName(offlinemessage);
        }

        public static void ClickStudentTileInClassRoster(int studentTile)
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeMyClassRosterStudentListTile", WaitTime.DefaultWaitTime, studentTile.ToString());
        }

        public static bool VerifyShowPasswordButtonInStudentTile(int studentTile)
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeMyClassRosterStudentListTileShowPwd", WaitTime.DefaultWaitTime, studentTile.ToString());
        }

        public static bool VerifyNoInternetAlertPopupTeacherSupport()
        {
            return (AutomationAgent.VerifyControlExists("TeacherSupportView", "NoInternetConnectionPopupMessageHeader", 500) &&
                AutomationAgent.VerifyControlExists("TeacherSupportView", "NoInternetConnectionPopupMessageBodyClassRoster", 500));
        
        }

        public static void ClickShowPasswordButtonInStudentTile(int studentTile)
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeMyClassRosterStudentListTileShowPwd", WaitTime.DefaultWaitTime, studentTile.ToString());
        }

        public static bool VerifyNoPicturePasswordSetupPopupforStudent()
        {
            return AutomationAgent.VerifyControlExists("TeacherSupportView", "NoPicturePasswordSetupPopupforStudent", 500);
        }

        public static bool VerifyMyLessonNotesPresentInTeacherMode()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeMyClassRoster");
        }

        public static bool VerifyTeacherCanSeeMyLessonNotesPaneInClassRoster()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeMyLessonNotesPane");
        }

        public static void ClickMyLessonNotesInTeacherMode()
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeMyClassRoster");
        }

        public static void ClickMyLessonNotesPaneInTeacherMode()
        {
            AutomationAgent.Click("TeacherModeView", "TeacherModeMyLessonNotesPane");
        }

        public static bool VerifyUIControlsofAddNotesOverlay()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "AddLessonNotesOverlayClose") &&
                 AutomationAgent.VerifyControlExists("TeacherModeView", "AddLessonNotesOverlayHeader") &&
                 AutomationAgent.VerifyControlExists("TeacherModeView", "AddLessonNotesOverlayTextBox") &&
                 AutomationAgent.VerifyControlExists("TeacherModeView", "AddLessonNotesOverlayCancel") &&
                 AutomationAgent.VerifyControlExists("TeacherModeView", "AddLessonNotesOverlaySave");
        }

        public static bool VerifyAddNotesOverlaySaveButtonEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("TeacherModeView", "AddLessonNotesOverlaySave");
        }

        public static void AddTextToAddNotesOverlay(string text)
        {
            AutomationAgent.SetText("TeacherModeView", "AddLessonNotesOverlayTextBox", text);
        }

        public static void CloseAddNotesOverlayXButton()
        {
            AutomationAgent.Click("TeacherModeView", "AddLessonNotesOverlayClose") ;
        }

        public static void ClickAddNotesOverlaySaveButton()
        {
            AutomationAgent.Click("TeacherModeView", "AddLessonNotesOverlaySave");
        }

        public static bool VerifyNoteAddedInLessonNotePane(string notetext)
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeMyLessonNotesPaneNoteText", WaitTime.DefaultWaitTime, notetext);
        }



        public static bool VerifyTapToAddNotesMesage()
        {
            return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeTapHereToAddNotes");
        }

        public static void ClickMyLessonNotesEditInTeacherMode()
        {
            int posx = AutomationAgent.GetControlPositionX("TeacherModeView", "TeacherModeNotesEditButton");
            int posy = AutomationAgent.GetControlPositionY("TeacherModeView", "TeacherModeNotesEditButton");

            AutomationAgent.Click(posx + 80, posy + 25);
            
            
            
           // AutomationAgent.Click("TeacherModeView", "TeacherModeNotesEditButton");
        }

        public static void ClickAddNotesOverlayDeleteButton()
        {
            AutomationAgent.Click("TeacherModeView", "AddLessonNotesOverlayDelete");
        }

        public static bool VerifyNoStudentsForTheTeacher()
        {
           return AutomationAgent.VerifyControlExists("TeacherModeView", "TeacherModeClassRosterNoStudents");
        }

        public static int GetWidthOfTeacherModePane()
        {
            int widthTeachermode = AutomationAgent.GetControlWidth("TeacherModeView", "TeacherModePane");
            return widthTeachermode;
        }

        public static void ZoomInTeacherModePane()
        {
            int x1 = AutomationAgent.GetControlPositionX("TeacherModeView", "TeacherModePane");
            int y1 = AutomationAgent.GetControlPositionY("TeacherModeView", "TeacherModePane");

            //AutomationAgent.StrechControl("TeacherModeView", "TeacherModePane", x1 + 100, y1 + 100, x1 + 200, y1 + 200, 100);

            AutomationAgent.Stretch(x1 + 100, y1 + 100, x1 + 200, y1 + 200, 100);

        }

        internal static void ClickAddNotesOverlayDoneButton()
        {
            AutomationAgent.Click("TeacherModeView", "AddLessonNotesOverlayDone");
        }
    }
}
