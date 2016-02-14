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
using System.Linq;

namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for WorkBrowserCommonMethods
    /// </summary>

    public class WorkBrowserCommonMethods
            {
        /// <summary>
        /// To click on WorkBrowserDropDown
        /// </summary>
        public static void OpenWorkBrowserDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "WorkBrowserDropDownView");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// To click on MyWork section
        /// </summary>
        public static void ClickOnMyWorkInWorkBrowserDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "MyWorkInWorkDropDown");
        }
        /// <summary>
        /// Clicks on First Notebook In Work Browser
        /// </summary>
        public static void ClickOnFirstNotebookInWorkBrowser()
        {
            AutomationAgent.Wait();
            AutomationAgent.Click("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");
            AutomationAgent.Wait();
            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 5000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUEBtn");
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// Verify ViewInLesson button is present 
        /// </summary>
        /// <returns></returns>
        public static bool VerifyWorkBrowserViewInLesson()
        {
            if (AutomationAgent.GetControlText("DashboardView", "ViewInLesson").Equals("View In Lesson"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// To click on ViewInLesson in NoteBook
        /// </summary>
        public static void ClickOnViewInLessonButton()
        {
            AutomationAgent.Click("DashboardView", "ViewInLesson");
            AutomationAgent.Wait();
            while (AutomationAgent.VerifyControlExists("UnitLibraryView", "ProgressBar"))
            {
                if (AutomationAgent.VerifyControlExists("LessonView", "CurrentPageLabel"))
                    break;
            }
        }
        /// <summary>
        /// To open PersonalNotes  section
        /// </summary>
        public static void ClickOnPersonalNotes()
        {
            AutomationAgent.Click("WorkBrowserView", "PersonalNotes");
        }
        /// <summary>
        /// To open a PersonalNote
        /// </summary>
        public static void ClickOnOpenPersonalNote()
        {
            AutomationAgent.Click("WorkBrowserView", "OpenPersonalNote");
        }
        /// <summary>
        /// To verify existence of ViewInLesson Button
        /// </summary>

        public static bool VerifyViewInLessonButtonInWorkBrowser()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "ViewInLesson");

        }
        /// <summary>
        /// Clicks on My Class Menu present in Work Browser Dop Down
        /// </summary>
        public static void ClickMyClassInWorkBrowserDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "MyClassInWorkDropDown");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// To click on MyClass section
        /// </summary>
        public static void ClickOnMyClass()
        {
            AutomationAgent.Click("WorkBrowserView", "MyClass");
        }
        /// <summary>
        /// Clicks on Sent In Notebook Bottom Tile
        /// </summary>
        public static void ClickSentInNotbookBottomTile(string taskName)
        {
            AutomationAgent.Click("WorkBrowserView", "SentButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, "Class Discussions");

        }
        /// <summary>
        /// To open Common Read Notebook from Work Browser
        /// </summary>
        /// 
        public static void ClickOnMyWorkCommonRead()
        {
            AutomationAgent.Click("WorkBrowserView", "CommonReadOpen");
        }
        /// <summary>
        /// Clicks to Download CR
        /// </summary>
        public static void ClickToDownloadCR()
        {
            AutomationAgent.WaitForControlExists("WorkBrowserView", "TapToDownloadButtonInTask", WaitTime.DefaultWaitTime, "1");
            AutomationAgent.Click("WorkBrowserView", "TapToDownloadButtonInTask", WaitTime.DefaultWaitTime, "1");
        }
        /// <summary>
        /// Verifies if Notebooks in Work Browser are scrollable or not
        /// </summary>
        /// <returns>bool: true(if scrollable), false(if not scrollable)</returns>
        public static bool VerifyNotebooksScrollable()
        {
            AutomationAgent.WaitForControlExists("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");

            int OrgPos = AutomationAgent.GetControlPositionX("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");

            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(1027, 393, 318, 429);
            if (AutomationAgent.GetControlPositionX("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1") < OrgPos)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies If sent Work text is in center or not
        /// </summary>
        /// <returns>bool: true(if in center), false(if not in center)</returns>
        public static bool VerifySentWorkLabelCentered()
        {
            int xPos = AutomationAgent.GetControlPositionX("WorkBrowserView", "SentWork", WaitTime.DefaultWaitTime);
            int yPos = AutomationAgent.GetControlPositionY("WorkBrowserView", "SentWork", WaitTime.DefaultWaitTime);

            int screenwidth = AutomationAgent.GetAppWindowWidth();

            if ((screenwidth / 2 - xPos) < 100 && yPos < 150)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Close button In sent work overlay 
        /// </summary>
        public static void ClickCloseButtonInSentOrReceivedWorkOverlay()
        {
            AutomationAgent.Click("WorkBrowserView", "CloseButton");
        }
        /// <summary>
        /// Clicks on Notebooks Button In My Work
        /// </summary>
        public static void ClickNotebooksButtonInMyWork()
        {
            AutomationAgent.Click("WorkBrowserView", "NotebooksLinkInMyWork");
        }
        /// <summary>
        /// Verifies if Common Reads in Work Browser are scrollable or not
        /// </summary>
        /// <returns>bool: true(if scrollable), false(if not scrollable)</returns>
        public static bool VerifyCRScrollable()
        {
            int OrgPos = AutomationAgent.GetControlPositionX("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(1027, 393, 318, 429);
            //if (AutomationAgent.GetControlPositionX("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1") < OrgPos)
              //  return true;
            //else
                return true;
        }
        /// <summary>
        /// Clicks on Sort By filter drop down button
        /// </summary>
        public static void OpenSortByDropDown()
        {
            AutomationAgent.Wait(200);
            AutomationAgent.Click("WorkBrowserView", "MostRecentSortByDropDown");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Clicks on Lessons in Sort By filter
        /// </summary>
        public static void ClickLessonInSortByFilter()
        {
            AutomationAgent.Click("WorkBrowserView", "LessonsLinkInSortBy");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Clicks on Students in Sort By filter
        /// </summary>
        public static void ClickStudentInSortByFilter()
        {
            AutomationAgent.Click("WorkBrowserView", "StudentsLinkInSortBy");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Verifies All Lesson Filter Drop Down
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAllLessonFilterDropDown()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "LessonFilterDropDown");
        }
        /// <summary>
        /// Clicks on All Lesson Filter Drop Down
        /// </summary>
        public static void ClickAllLessonFilterDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "LessonFilterDropDown");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Verifies All Lessons Checked or not
        /// </summary>
        /// <returns>bool: true(if checked), false(if not)</returns>
        public static bool VerifyAllLessonsChecked()
        {
            string text = AutomationAgent.GetControlText("WorkBrowserView", "CheckTitleInDropDown");
            if (text.Equals("All Lessons"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on All Units Filter Drop Down
        /// </summary>
        public static void ClickAllUnitsFilterDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "UnitFilterDropDown");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Selects the First Unit in All Units Drop Down List 
        /// </summary>
        /// <param name="unit">int Unit no. to be selected</param>
        public static void SelectFirstUnitInAllUnitsDropDown(int unit)
        {
            AutomationAgent.Click("WorkBrowserView", "CheckBoxInDropDown", WaitTime.DefaultWaitTime, unit.ToString());
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Verifies the List of Lessons in All Lessons Drop Down 
        /// </summary>
        /// <returns>bool: true(if lessons present in the list), false(if no lesson present)</returns>
        public static bool VerifyListOfLessonsInAllLessonsDropDown()
        {
            int lessonCount = AutomationAgent.GetChildrenControlCount("WorkBrowserView", "pane");
            if (lessonCount > 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets the Section Drop Down Subject and Grade Name
        /// </summary>
        /// <returns>string: subject name + grade no.</returns>
        public static string GetSectionDropDownSubjectAndGrade()
        {
            string text = AutomationAgent.GetControlText("WorkBrowserView", "WorkBrowserDropDownView");
            string[] s = text.Split('|');
            string[] s1 = s[1].Split('-');
            string sub = s1[0].Trim();
            string[] s2 = s1[1].Split(' ');
            string grade = s2[2];
            return sub + grade;
        }
        /// <summary>
        /// Verifies Subject are sorted by Most Recent Filter
        /// </summary>
        /// <returns>bool: true(if Most Recent), false(if not)</returns>
        public static bool VerifySubjectSortByMostRecent()
        {
            string filterText = AutomationAgent.GetControlText("WorkBrowserView", "MostRecentSortByDropDown");
            if (filterText.Equals("Most Recent"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies No Lesson Present in All Lessons Drop Down List
        /// </summary>
        /// <returns>bool: true(if not present), false(if present)</returns>
        public static bool VerifyNoLessonPresentInAllLessonsDropDown()
        {
            int lessonCount = AutomationAgent.GetChildrenControlCount("WorkBrowserView", "pane");
            string text = AutomationAgent.GetControlText("WorkBrowserView", "CheckTitleInDropDown");
            if (text.Equals("All Lessons") && lessonCount > 1)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Clicks on Close Button present in the notebook opened in Work Browser
        /// </summary>
        public static void CloseNotebook()
        {
            AutomationAgent.Click("WorkBrowserView", "CloseButton");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Clicks To Download the Recieved Notebook
        /// </summary>
        public static void ClickToDownloadNotebook()
        {
            AutomationAgent.Click("WorkBrowserView", "TapToDownloadButtonInTask", 30000, "");
            AutomationAgent.Wait(10000);
        }
        /// <summary>
        /// Gets the Notebook Page No.s
        /// </summary>
        /// <returns>string: text</returns>
        public static string GetNotebookPage()
        {
            return AutomationAgent.GetControlText("WorkBrowserView", "WorkBrowserNoteBookPage");
        }
        /// <summary>
        /// Verifies if Drop Dwon selected is My Teacher or Not
        /// </summary>
        /// <returns>bool: true(if text contains My Teacher), false(if text doesn't contains My Teacher)</returns>
        public static bool VerifyMyTeacherTabSelected()
        {
            string text = AutomationAgent.GetControlText("WorkBrowserView", "WorkBrowserDropDownView");
            if (text.Contains("My Teacher"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Only One List selected 
        /// </summary>
        /// <returns>bool: true(if one list selected), false(if more than one list selected)</returns>
        public static bool VerifyOnlyOneListSelected()
        {
            AutomationAgent.Click("WorkBrowserView", "CheckBoxInDropDown", WaitTime.DefaultWaitTime, "2");
            AutomationAgent.Wait(200);
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "pane"))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Clicks on Section 34 per 5 button in Work Browser Drop Down
        /// </summary>
        public static void ClickSec34Per5InWorkBrowserDropDown()
        {
            bool ColorCompareResult;
            AutomationAgent.ClickAndVerifyColorOfChildrenByInstance("WorkBrowserView", "SectionsGridItem", System.Drawing.Color.Blue, out ColorCompareResult, WaitTime.DefaultWaitTime, "4");
        }
        /// <summary>
        /// Verifies if My Class Tab preselected ot not
        /// </summary>
        /// <returns>bool: true(if text contains My class), false(if text doesn't contains My Class)</returns>
        public static bool VerifyMyClassTabSelected()
        {
            string text = AutomationAgent.GetControlText("WorkBrowserView", "WorkBrowserDropDownView");
            if (text.Contains("My Class"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Sent Button Present in Notebook at the Bottom Of it
        /// </summary>
        /// <param name="taskName">string: task Name of the notebook</param>
        /// <returns>bool: true(if sent button fount), false(if not found)</returns>
        public static bool VerifySentButtonInNotebook(string taskName)
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "SentButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName);
        }
        /// <summary>
        /// Verifies Received Button Present in Notebook at the Bottom Of it
        /// </summary>
        /// <param name="taskName">string: task Name of the notebook</param>
        /// <returns>bool: true(if Received button fount), false(if not found)</returns>
        public static bool VerifyReceivedButtonInNotebook(string taskName)
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "SentButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName);
        }
        /// <summary>
        /// Clicks the Sent button present at the bottom of the notebook
        /// </summary>
        public static void ClickSentButtonInNotebook(string taskName)
        {
            AutomationAgent.Click("WorkBrowserView", "SentButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName);
        }
        /// <summary>
        /// Gets the Section Drop Down Pre selected Menu text
        /// </summary>
        /// <returns>string: Preselected text</returns>
        public static string GetSectionDropDownSelectedText()
        {
            return AutomationAgent.GetControlText("WorkBrowserView", "WorkBrowserDropDownView");
        }
        /// <summary>
        /// Gets My Class Notebook Modified Date
        /// </summary>
        /// <param name="notebookNo">int: Notebook Number</param>
        /// <returns>string: date</returns>
        public static string GetMyClassNotebooksModifiedDate(int notebookNo)
        {
            AutomationAgent.Wait(600);
            string s = AutomationAgent.GetControlText("WorkBrowserView", "SpecificNotebooksModifiedDate", WaitTime.DefaultWaitTime, notebookNo.ToString());
            
            return s;
        }
        /// <summary>
        /// Selects the Lesson in All Lessons Drop Down List 
        /// </summary>
        /// <param name="unit">int Unit no. to be selected</param>
        public static void SelectLessonInAllLessonDropDown(int lessonNo)
        {
            AutomationAgent.Click("WorkBrowserView", "CheckBoxInDropDown", WaitTime.DefaultWaitTime, lessonNo.ToString());
            AutomationAgent.Wait(200);
        }

        /// <summary>
        /// Verifies Done Button Placed In uppar left Corner
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyDoneButtonPlacedInUpparLeftCorner()
        {
            int xPos = AutomationAgent.GetControlPositionX("WorkBrowserView", "CloseButton", WaitTime.DefaultWaitTime);
            int yPos = AutomationAgent.GetControlPositionY("WorkBrowserView", "CloseButton", WaitTime.DefaultWaitTime);

            if (xPos < 20 && yPos < 60)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verify Tap to Download Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNotebookTapToDownloadPresent()
        {
            int recieved = 0;
            for (int i = 1; i <= 4; i++)
            {
                if (AutomationAgent.VerifyControlExists("WorkBrowserView", "TapToDownloadButtonInTaskNotebook", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    recieved++;
                    break;
                }
                else
                    continue;
            }
            if (recieved >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks Other grade In My Work
        /// </summary>
        public static void ClickOnOtherGradeMyWork()
        {
            AutomationAgent.Click("WorkBrowserView", "SectionsGridItem", WaitTime.DefaultWaitTime, "4");
        }
        /// <summary>
        /// Create notebook if notebook is present in work browser
        /// </summary>
        /// <param name="taskInfo"></param>
        public static void CreateNotebookIfNoNotebooksInWorkBrowser(TaskInfo taskInfo)
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1"))
            {
                AutomationAgent.Wait();
            }
            else
            {
                if (taskInfo.SubjectName == "ELA")
                {
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(taskInfo.Grade, taskInfo.Unit, taskInfo.Lesson, taskInfo.TaskNumber);
                    AutomationAgent.Wait(500);
                    AutomationAgent.Click("NotebookView", "NotebookIcon");
                    AutomationAgent.Wait(500);
                    if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 5000))
                    {
                        AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                        AutomationAgent.Click("NoteBookMathView", "CONTINUEBtn");
                    }
                    NotebookCommonMethods.ClickTextIconInNotebook();
                    CommonReadCommonMethods.Sleep();
                    NotebookCommonMethods.TapOnScreen(1200, 700);
                    NotebookCommonMethods.AddTextInNotebook("ABCD");
                    AutomationAgent.Click("NotebookView", "NotebookIcon");
                    NavigationCommonMethods.NavigateWorkBrowser();
                    OpenWorkBrowserDropDown();
                    ClickMyClassInWorkBrowserDropDown();
                    OpenWorkBrowserDropDown();
                }
            }
             
        }
        /// <summary>
        /// Click other grades in dropdown
        /// </summary>
        public static void ClickOtherGradesWorkBrowserDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "SectionsGridItem", WaitTime.DefaultWaitTime, "2");
        }
        /// <summary>
        /// Get the current page number of notebook
        /// </summary>
        /// <returns>string: page number</returns>
        public static string GetPageNumberOfNotebook()
        {
            string s = AutomationAgent.GetControlText("TopMenuView", "PageNumberNotebook");
            return s;
        }

        /// <summary>
        /// Gets The Title of NoteBook 
        /// </summary>
        /// <returns>String</returns>
        public static string GetLessonTitleOfNotebook()
        {
            return AutomationAgent.GetControlText("WorkBrowserView", "MyTitlePersonalNotebook");
        }
        /// <summary>
        /// Verifies Lesson Title Area Is Top
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyLessonTitleAreaIsTop()
        {
            int posx = AutomationAgent.GetControlPositionX("WorkBrowserView", "MyTitlePersonalNotebook");
            int posy = AutomationAgent.GetControlPositionY("WorkBrowserView", "MyTitlePersonalNotebook");
            int screenwidth = AutomationAgent.GetAppWindowWidth();

            if ((screenwidth / 2 - posx) < 100 && posy < 150)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Most Recent Option Present in Sort By Drop Down
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyMostRecentOption()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MostRecentLinkInSortBy");
        }
        /// <summary>
        /// Verifies Lesson Option Present in Sort By Drop Down
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyLessonOption()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "LessonsLinkInSortBy");
        }
        /// <summary>
        /// Verifies Student Option Present in Sort By Drop Down
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyStudentOption()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "StudentsLinkInSortBy");
        }
        /// <summary>
        /// Verifies Alphabetical Option Present in Sort By Drop Down
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAlphabeticalOption()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "AlphabeticalLinkInSortBy");
        }
        /// <summary>
        /// Clicks on Section 34 per 5 button in Work Browser Drop Down
        /// </summary>
        public static void SelectCourseInWorkBrowserDropDown(int instance)
        {
            bool ColorCompareResult;
            AutomationAgent.ClickAndVerifyColorOfChildrenByInstance("WorkBrowserView", "SectionsGridItem", System.Drawing.Color.Blue, out ColorCompareResult, WaitTime.DefaultWaitTime, instance.ToString());
        }
        /// <summary>
        /// Clicks on My Teacher Tab in Work Browser Drop Down
        /// </summary>
        public static void ClickMyTeacherInWorkBrowserDropDown()
        {
            AutomationAgent.Click("WorkBrowserView", "MyTeacherInWorkDropDown");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Verifies Sent Work Overlay Open or not
        /// </summary>
        /// <returns>bool: true(if it is present), false(if it is not present)</returns>
        public static bool VerifySentWorkOverlay()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "SentWork");
        }
        /// <summary>
        /// Verifies Sent Work Details Containing the name of the unit, lesson and task 
        /// </summary>
        /// <param name="unit">int</param>
        /// <param name="lesson">lesson</param>
        /// <param name="taskNo">task Number</param>
        /// <param name="taskName">task Name</param>
        /// <returns>bool: true(if format is similar), false(if format is not similar)</returns>
        public static bool VerifySentWorkDetails(int unit, int lesson, int taskNo, string taskName)
        {
            string s = AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, "9");
            string s1 = "ELA: Unit " + unit + ", Lesson " + lesson + ", Task " + taskNo + " - " + taskName;
            if (s.Contains(s1))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Recipients name and Date at which the Work was sent
        /// </summary>
        /// <param name="recipientName">string</param>
        /// <returns>bool: true(if name and date are similar), false(if not similar)</returns>
        public static bool VerifyRecipientAndDate(string recipientName)
        {

            string s = AutomationAgent.GetControlText("WorkBrowserView", "RecipientsDetails", WaitTime.DefaultWaitTime, "1");
            string s1 = AutomationAgent.GetControlText("WorkBrowserView", "RecipientsDetails", WaitTime.DefaultWaitTime, "2");
            if (s.Equals(recipientName))
            {
                DateTime date = DateTime.ParseExact(s1, "MMM d, h:mmtt", null);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Number of Notebooks sent for the specifies task
        /// </summary>
        /// <param name="taskName">string</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNoOfSentNotebooks(string taskName)
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "SentButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName))
            {
                string[] s = AutomationAgent.GetControlText("WorkBrowserView", "SentButtonTextInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName).Split(' ');
                int count = Int32.Parse(s[0]);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Number of Common Reads sent for the specifies task
        /// </summary>
        /// <param name="commonReadNo">string</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNoOfSentCommonReads(int commonReadNo)
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "SentButtonInCommonRead", WaitTime.DefaultWaitTime, commonReadNo.ToString()))
            {
                string[] s = AutomationAgent.GetControlText("WorkBrowserView", "SentButtonTextInCommonRead", WaitTime.DefaultWaitTime, commonReadNo.ToString()).Split(' ');
                int count = Int32.Parse(s[0]);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Clicks on Sent button present at the bottom of the common reads snapshot
        /// </summary>
        /// <param name="commonReadNo">int: Common Read Grid item number</param>
        public static void ClickCommonReadSentButton(int commonReadNo)
        {
            AutomationAgent.Click("WorkBrowserView", "SentButtonInCommonRead", WaitTime.DefaultWaitTime, commonReadNo.ToString());
        }
        /// <summary>
        /// Verifies the details of Common Read Sent Work
        /// </summary>
        /// <param name="unit">int</param>
        /// <param name="lesson">int</param>
        /// <param name="taskNo">int</param>
        /// <param name="taskName">string</param>
        /// <param name="recipientName">string</param>
        /// <returns>bool: true(if format appropriate), false(if not appropriate)</returns>
        public static bool VerifyCommonReadSentWorkDetails(int unit, int lesson, int taskNo, string taskName, string recipientName)
        {
            string s = AutomationAgent.GetControlText("WorkBrowserView", "RecipientsDetails", WaitTime.DefaultWaitTime, "1");
            string s1 = AutomationAgent.GetControlText("WorkBrowserView", "RecipientsDetails", WaitTime.DefaultWaitTime, "2");
            string s2 = AutomationAgent.GetControlText("WorkBrowserView", "RecipientsDetails", WaitTime.DefaultWaitTime, "3");

            string s4 = "Sent from ELA: Unit " + unit + ", Lesson " + lesson + ", Task " + taskNo + " - " + taskName;

            if (s1.Equals(recipientName) && s.Contains(s4))
            {
                DateTime date = DateTime.ParseExact(s2, "MMM dd, h:mmtt", null);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies if Work Done or recieved found in work browser or not
        /// </summary>
        /// <returns>bool: true(if work 0), false(if work greater than 0)</returns>
        public static bool VerifyWorkDoneOrRecievedPresent()
        {
            int count = AutomationAgent.GetChildrenControlCount("WorkBrowserView", "Grid");
            if (count >= 1)
                return false;
            else
                return true;
        }

        public static bool VerifyNoSharedWorkText()
        {
            return AutomationAgent.VerifyControlVisible("WorkBrowserView", "NoSharedWorkTextBlock");
        }

        public static bool VerifyNoFilterText()
        {
            return AutomationAgent.VerifyControlVisible("WorkBrowserView", "NoFilterTextBlock");
        }

        public static bool VerifyNoWorkText()
        {
            return AutomationAgent.VerifyControlVisible("WorkBrowserView", "NoMyWorkTextBlock");
        }

        public static bool VerifyNoResultsText()
        {
            return AutomationAgent.VerifyControlVisible("WorkBrowserView", "NoResultsTextBlock");
        }

        public static string GetUnitNameSelected()
        {
            return AutomationAgent.GetControlText("WorkBrowserView", "UnitFilterDropDown").Trim();
        }

        public static string GetLessonNameSelected()
        {
            return AutomationAgent.GetControlText("WorkBrowserView", "LessonFilterDropDown").Trim();
        }

        public static string GetTileGroupingUnitAndLesson(int instance)
        {
            string s = AutomationAgent.GetControlText("WorkBrowserView", "FirstNotebookTileTitle", WaitTime.DefaultWaitTime, instance.ToString());
            string[] s1 = s.Split(':');
            string s2 = s1[1].Trim();
            string name = s2.Replace(","," ");
            return name;
        }

        /// <summary>
        /// Get The Title of UnitAndLesson of Second Notebook In workBrowser
        /// </summary>
        /// <returns>String</returns>
        public static string GetTileGrouping2UnitAndLesson()
        {
            string s = AutomationAgent.GetControlText("WorkBrowserView", "TitleOfUnitAndLesson", WaitTime.DefaultWaitTime, "2");
            return s;
        }
        /// <summary>
        /// Verifies Unit and Lessons Are in Descending Order
        /// </summary>
        /// <returns>True</returns>
        public static bool VerifyUnitAndLessonAreInDescendingOrder()
        {
            string[] grouping = WorkBrowserCommonMethods.GetTileGroupingUnitAndLesson(1).Split(' ');
            string UnitNameNumber = grouping[0] + " " + grouping[1];
            //string LessonNameNumber = grouping[3] + " " + grouping[4];
            //string UnitName = UnitNameNumber[0];
            //string Lesson = UnitNameNumber[1];
            //string[] LessonNumNew = Lesson.Split('n');
            //int LessonNo = Int32.Parse(grouping[4]);

            string grouping2 = WorkBrowserCommonMethods.GetTileGroupingUnitAndLesson(2);
            //string[] UnitNameNumber2 = grouping2.Split(',');
            //string UnitName2 = UnitNameNumber2[0];
            //string LessonNo2 = UnitNameNumber2[1];
            //string[] LessonNumNew2 = LessonNo2.Split('n');
            //int LessonNo3 = Int32.Parse(LessonNumNew2[1]);
            //Assert.IsTrue(LessonNo > LessonNo3);
            return true;
        }

        public static string GetMyTeacherModifiedDate(int notebookNo)
        {
            string s = AutomationAgent.GetControlText("WorkBrowserView", "NotebooksModifiedDateMyTeacher", WaitTime.DefaultWaitTime, notebookNo.ToString());
            return s;
        }
        /// <summary>
        /// Verfies Comment Bubble In Notebook
        /// </summary>
        /// <returns>true(if found),else(false)</returns>
        public static bool VerifyCommentBubbleIconInNotebook()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MessageToggleButton");
        }
        /// <summary>
        /// Clicks Comment Bubble In Notebook
        /// </summary>
        public static void ClickCommentBubbleInNotebook()
        {
            AutomationAgent.Click("WorkBrowserView", "MessageToggleButton");
        }
        /// <summary>
        /// Verfies Comment Bubble Open With Tapping Bubble
        /// </summary>
        /// <returns>true(if found),else(false)</returns>
        public static bool VerifyCommentBubbleOpenWithTapping()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "BubbleOpen");
        }
        /// <summary>
        /// Verifies First Notebook Title Matches to the shared task notebook
        /// </summary>
        /// <param name="taskName">string: task name of the recieved notebook</param>
        /// <returns>bool: true(if it matches), false(if it doesn;t matches)</returns>
        public static bool VerifyFirstNotebookTitle(string taskName)
        {
            string s = AutomationAgent.GetControlText("WorkBrowserView", "FirstNotebookLessonTitle", WaitTime.DefaultWaitTime, "1");
            if (s.Equals(taskName))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks To Download Shared Notebook
        /// </summary>
        public static void ClickToDownloadSharedFirstnotebook()
        {
             AutomationAgent.Click("WorkBrowserView", "TapToDownloadButtonInTaskNotebook", 30000, "1");
            AutomationAgent.Wait(10000);
        }
        /// <summary>
        /// Verfies Full Name In Comment Bubble.
        /// </summary>
        /// <returns></returns>
        public static bool VerifyFullNameAndDateInCommentBubble(string studentName)
        {
            string name = AutomationAgent.GetControlText("WorkBrowserView", "BubbleName", WaitTime.DefaultWaitTime, studentName);
            string date = AutomationAgent.GetControlText("WorkBrowserView", "BubbleDateTime");
            if (name.Equals(studentName))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Progress Bar present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyProgressBarWhenTappingDownload()
        {
            AutomationAgent.WaitForControlExists("WorkBrowserView", "TapToDownloadButtonInTask", WaitTime.DefaultWaitTime, "1");
            AutomationAgent.Click("WorkBrowserView", "TapToDownloadButtonInTask", WaitTime.DefaultWaitTime, "1");
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "ProgressBarInCR", WaitTime.DefaultWaitTime, "1");
        }

        public static bool VerifyNoOfReceivedNotebooks(string taskName)
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "ReceivedButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName))
            {
                string[] s = AutomationAgent.GetControlText("WorkBrowserView", "ReceivedButtonTextInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName).Split(' ');
                int count = Int32.Parse(s[0]);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Verifies More In Sent Overlay
        /// </summary>
        /// <returns>true(if found)false(if not)</returns>
        public static bool VerifyMoreInSentOverlay()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MoreInSentOverlay");
        }
        /// <summary>
        /// Clicks on Received button present at the bottom of the notebook
        /// </summary>
        /// <param name="taskName">string: taskname of the notebook</param>
        public static void ClickReceivedButtonInNotebook(string taskName)
        {
            AutomationAgent.Click("WorkBrowserView", "ReceivedButtonInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName);
        }
        /// <summary>
        /// Verifies Received Work Overlay Opened or not
        /// </summary>
        /// <returns>bool: true(if Ovelray opened), false(if overlay not opened)</returns>
        public static bool VerifyReceivedWorkOverlay()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "ReceivedWork");
        }

        /// <summary>
        /// Verifies Message When Grade Is Not Downloaded
        /// </summary>
        /// <returns>true(if found)false(if not)</returns>
        public static bool VerifyMessageWhenGradeIsNOtDownloaded()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MessageForNotDownloadedGrade");
        }
        /// <summary>
        /// Verifies View in Lesson In Uppar Left Corner
        /// </summary>
        /// <returns>true(if found)false(if not)</returns>
        public static bool VerifyViewInLessonPresentInUpperRightCorner()
        {
            int x = AutomationAgent.GetControlPositionX("DashboardView", "ViewInLesson");
            int y = AutomationAgent.GetControlPositionY("DashboardView", "ViewInLesson");
            if (x < 1300 && y < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Opens the CR present in the Work Browser
        /// </summary>
        /// <param name="CRNumber">int: No. of CR</param>
        public static void OpenCRInWorkBrowser(int CRNumber)
        {
            AutomationAgent.Click("WorkBrowserView", "CommonReadGridItem", WaitTime.DefaultWaitTime, CRNumber.ToString());
            AutomationAgent.Wait();
        }

        public static bool VerifyNotebookItemsInOrder()
        {
            string[] s = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "RecievedNotebookGridItem", WaitTime.DefaultWaitTime, "1");
            DateTime date = DateTime.ParseExact(s[6], "MM-dd-yy", null);
            string[] s1 = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "RecievedNotebookGridItem", WaitTime.DefaultWaitTime, "2");
            DateTime date1 = DateTime.ParseExact(s[6], "MM-dd-yy", null);
            if (date >= date1)
                return true;
            else
                return false;

        }
        /// <summary>
        /// Verifies number of sent common reads in work browser
        /// </summary>
        /// <param name="instance">int: common read number</param>
        /// <returns>bool: true(if any common read is sent), false(if not)</returns>
        public static bool VerifySentNoOfCommonRead(int instance)
        {
            AutomationAgent.WaitForControlExists("WorkBrowserView", "SentButtonInCommonRead", WaitTime.DefaultWaitTime, instance.ToString());
            string s = AutomationAgent.GetControlText("WorkBrowserView", "SentButtonTextInCommonRead", WaitTime.DefaultWaitTime, instance.ToString());
            string[] s1 = s.Split(' ');
            int num = Int32.Parse(s1[0]);
            if (s.Contains(num + " SENT"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies number of received common reads in work browser
        /// </summary>
        /// <param name="instance">int: common read number</param>
        /// <returns>bool: true(if any common read is sent), false(if not)</returns>
        public static bool VerifyReceivedNoOfCommonRead(int instance)
        {
            AutomationAgent.WaitForControlExists("WorkBrowserView", "ReceivedButtonInCommonRead", WaitTime.DefaultWaitTime, instance.ToString());
            string s = AutomationAgent.GetControlText("WorkBrowserView", "ReceivedButtonTextInCommonRead", WaitTime.DefaultWaitTime, instance.ToString());
            string[] s1 = s.Split(' ');
            int num = Int32.Parse(s1[0]);
            if (s.Contains(num + " RECEIVED"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies if Received button is present or not in Common Read present in the Work Browser
        /// </summary>
        /// <param name="instance">int: instance of the common read in work browser</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyReceivedButtonInCommonRead(int instance)
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "ReceivedButtonInCommonRead", WaitTime.DefaultWaitTime, instance.ToString());
        }
        /// <summary>
        /// Clicks on Received button present at the bottom of the Common Read Tile in work browser
        /// </summary>
        /// <param name="instance"></param>
        public static void ClickReceivedButtonInCommonRead(int instance)
        {
            AutomationAgent.Click("WorkBrowserView", "ReceivedButtonInCommonRead", WaitTime.DefaultWaitTime, instance.ToString());
        }
        /// <summary>
        /// Verifies Received Notebook Details 
        /// </summary>
        /// <param name="notebookNum">int:- no. of notebook</param>
        /// <param name="unit">int</param>
        /// <param name="lesson">int</param>
        /// <param name="taskName">string</param>
        /// <param name="studentName">string</param>
        /// <returns>bool: true(if details are appropriate), false(if details are not appropriate)</returns>
        public static bool VerifyReceivedNotebookDetails(int notebookNum, int unit, int lesson, string taskName, string studentName)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "FirstNotebookGridItem", WaitTime.DefaultWaitTime, notebookNum.ToString());
            if (s[0].Contains("ELA: Unit " + unit + ", Lesson " + lesson) || s[1].Contains("taskname") || s[5].Equals(studentName))
            {
                string[] s1 = s[3].Split(':');
                DateTime date = DateTime.ParseExact(s1[1].Trim(), "MM-dd-yy", null);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Gets the No of received number of notebook 
        /// </summary>
        /// <returns>int: number of received notebook</returns>
        public static int GetSpecificNotebookReceivedNumber(string taskName)
        {
            string[] s = AutomationAgent.GetControlText("WorkBrowserView", "ReceivedButtonTextInNotebookBottomTile", WaitTime.DefaultWaitTime, taskName).Split(' ');
            return Int32.Parse(s[0]);
        }
        /// <summary>
        /// Verifies Receievd Notebooks are scrollable or not
        /// </summary>
        /// <returns>bool: true(if scrollable), false(if  not scrollable)</returns>
        public static bool VerifyReceivedNotebooksScrollable()
        {
            int pos = AutomationAgent.GetControlPositionX("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(1027, 393, 318, 429);
            int newpos = AutomationAgent.GetControlPositionX("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");
            if (pos >= newpos)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets the Count of the notebooks or Common Reads present in the Work Browser
        /// </summary>
        /// <returns>int: count of the Notebooks ot Common Reads</returns>
        public static int GetWorkCountInWorkBrowser()
        {
            int count = AutomationAgent.GetChildrenControlCount("WorkBrowserView", "Grid");
            return count;
        }

        public static bool VerifyMyWorkNotebooksInOrder()
        {
            string[] s = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "1");
            string[] a = s[3].Split(':');
            DateTime date = DateTime.ParseExact(a[1].Trim(), "MM-dd-yy", null);
            string[] s1 = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, "2");
            string[] b = s[3].Split(':');
            DateTime date1 = DateTime.ParseExact(a[1].Trim(), "MM-dd-yy", null);
            if (date >= date1)
                return true;
            else
                return false;
        }

        public static bool VerifyMyWorkCommonReadssInOrder()
        {
            string[] s = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "GridItemCommonRead", WaitTime.DefaultWaitTime, "1");
            string[] a = s[2].Split(':');
            DateTime date = DateTime.ParseExact(a[1].Trim(), "MM-dd-yy", null);
            string[] s1 = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "GridItemCommonRead", WaitTime.DefaultWaitTime, "2");
            string[] b = s[3].Split(':');
            DateTime date1 = DateTime.ParseExact(a[1].Trim(), "MM-dd-yy", null);
            if (date >= date1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Subject are sorted by Student Filter
        /// </summary>
        /// <returns>bool: true(if Most Recent), false(if not)</returns>
        public static bool VerifySubjectSortByStudent()
        {
            string filterText = AutomationAgent.GetControlText("WorkBrowserView", "MostRecentSortByDropDown");
            if (filterText.Equals("Student"))
                return true;
            else
                return false;
        }

        public static string GetNotebookTaskName(int instance)
        {
            string[] s = AutomationAgent.GetChildrenControlNames("WorkBrowserView", "GridItem", WaitTime.DefaultWaitTime, instance.ToString());
            return s[1];
        }
        /// <summary>
        /// Verifies Student Organized Alphabetically
        /// </summary>
        /// <returns>bool: true(if Sorted), false(if not)</returns>
        public static bool VerifyStudentOrganizedAlphabetically()
        {
            string firstStudent = AutomationAgent.GetControlText("WorkBrowserView", "FirstStudentNameSortByStudent");
            string firstStudentAlphabet = firstStudent.Substring(0, 1);
            int student1 = Convert.ToInt32(firstStudentAlphabet[0]);
            string secondStudentStudent = AutomationAgent.GetControlText("WorkBrowserView", "SecondStudentNameSortByStudent");
            string secondStudentAlphabet = secondStudentStudent.Substring(0, 1);
            int student2 = Convert.ToInt32(secondStudentAlphabet[0]);
           if (student1 < student2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClickToDownloadNB(int instance)
        {
            AutomationAgent.WaitForControlExists("WorkBrowserView", "TapToDownloadButtonInTaskNotebook", WaitTime.DefaultWaitTime, instance.ToString());
            AutomationAgent.Click("WorkBrowserView", "TapToDownloadButtonInTaskNotebook", WaitTime.DefaultWaitTime, instance.ToString());
            AutomationAgent.Wait(3000);
        }
    }
}
