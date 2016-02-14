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
using System.Drawing;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for LessonBrowserCommonMethods
    /// </summary>
    
    public class LessonBrowserCommonMethods
    {
        public LessonBrowserCommonMethods()
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
        /// Verifies Lesson Browser Chrome Icons when Sectioned Teachers Logged In
        /// </summary>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForSectionedTeachers()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton") &&
                AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton") &&
                AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewGridViewList") &&
                AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButton") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA")) &&
                AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }
            else
                return false;
        }



        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Non Sectioned Students Logged In
        /// </summary>
        /// <returns>bool: true(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForNonSectionedStudents()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton") &&
               AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton") &&
               AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewGridViewList") &&
               AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames"))
                return true;
            else
                return false;
          
        }


        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Sectioned Students Logged In
        /// </summary>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForSectionedStudents()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton") &&
               AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton") &&
               AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewGridViewList") &&
               AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
               AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Lesson Browser Chrome Icons when Non Sectioned Teachers Logged In
        /// </summary>
        /// <returns>bool: treu(if all elements are found), false(if any element is not found)</returns>
        public static bool VerifyLessonBrowserChromeItemsForNonSectionedTeachers()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton") &&
              AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton") &&
              AutomationAgent.VerifyControlExists("UnitPreviewView", "UnitPreviewGridViewList") &&
              AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
              AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Verifies ELA Start Button active
        /// </summary>
        /// <param name="lessonNumber"></param>
        /// <returns>true:button enabled; false:button disabled</returns>
        public static bool VerifyELAStartButtonActive(int lessonNumber)
        {  
             return AutomationAgent.VerifyControlEnabled("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies whether Task is opened or not
        /// </summary>
        /// 
        /// <returns></returns>
        public static bool VerifyELATaskOpen()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "TaskHeader");
        }

        /// <summary>
        /// Clicks on Video Play Button
        /// </summary>
        /// <param name="lessonNumber"></param>
        public static void ClickOnPlayButtonInVideo(int lessonNumber)
        {
            AutomationAgent.Click("VideoView", "PlayVideo", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies video functionalities available
        /// </summary>
        /// <returns>true:if available;false:if not found</returns>
        public static bool VerifyVideoFunctionalities()
        {
            if (AutomationAgent.VerifyControlExists("VideoView", "CloseVideo") &&
                 AutomationAgent.VerifyControlExists("VideoView", "VdoVolumeBtn") &&
                 AutomationAgent.VerifyControlExists("VideoView", "VdoPlayProgressBar"))
            {
                return true;
            }

            else
                return false;
        }

        /// <summary>
        /// Click to close video
        /// </summary>
        public static void ClickToCloseVideo()
        {
            AutomationAgent.Click("VideoView", "CloseVideo");
        }

        /// <summary>
        /// Verifies lesson browser cell
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonBrowserEpisodeCell()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "UnitTaskHeader");
        }

      /// <summary>
      /// Verifies whether video got completed or not
      /// </summary>
      /// <returns></returns>
        public static bool VerifyVideoComplete()
        {
            int trial = 10;
            while (AutomationAgent.VerifyControlExists("VideoView", "CloseVideo") && trial>0)
            {
                AutomationAgent.Wait();
                trial--;
            }
            return (trial > 0);
        }

        /// <summary>
        /// Verifies ELA grade button available
        /// </summary>
        /// <param name="gradeNumber"></param>
        /// <returns></returns>
        public static bool VerifyELAGradeButton(int gradeNumber)
        {
           return AutomationAgent.VerifyControlExists("UnitLibraryView", "GradeListViewItem", WaitTime.DefaultWaitTime, gradeNumber.ToString());
           
        }

        /// <summary>
        /// Clicks Add grade button
        /// </summary>
        public static void ClickAddGrades()
        {
            AutomationAgent.Wait();
            int grade = 7;

            while (grade > 1)
            {
                if (!VerifyELAGradeButton(grade))
                {
                    break;
                }
                grade--;
            }

            if (grade <= 2)
            {
                if (VerifyELAGradeButton(2))
                {
                    NavigationCommonMethods.NavigateToELAGrade(2);
                    AutomationAgent.Wait();

                    if (VerifyRemoveGradeButtonPresent())
                    {
                        RemoveGrade();
                        AutomationAgent.Wait();
                    }
                }

                else
                {
                    NavigationCommonMethods.NavigateToELAGrade(3);
                    AutomationAgent.Wait();

                    if (VerifyRemoveGradeButtonPresent())
                    {
                        RemoveGrade();
                        AutomationAgent.Wait();
                    }
                }
            }


            AutomationAgent.Click("AddGradesScreenView", "AddGrades");
            AutomationAgent.Wait();
        }

        public static bool VerifyRemoveGradeButtonActive()
        {
            return AutomationAgent.VerifyControlEnabled("AddGradesScreenView", "RemoveGrade");

        }

        public static void ClickRemoveGradeButton()
        {
            AutomationAgent.Click("AddGradesScreenView", "RemoveGrade");
        }

        /// <summary>
        /// Clicks Cancel button available in AddGrade popup
        /// </summary>
        public static void ClickCancelButton()
        {
            AutomationAgent.Click("AddGradesScreenView", "CancelButton");
            AutomationAgent.Wait(2000);
        }
        /// <summary>
        ///Verifies continue button available in AddGrade popup 
        /// </summary>
        /// <returns></returns>
        public static bool VerifyAddGradeContinueButtonEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("AddGradesScreenView", "ContinueButton");

        }




        /// <summary>
        /// Select a grade from available options
        /// </summary>
        public static int SelectGrade()
        {
            


            bool notAddedGrade = false;
            int i = 2;
            while (!notAddedGrade)
            {
                if (AutomationAgent.VerifyControlEnabled("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString());
                    notAddedGrade = true;
                }
                i++;
            }
            return (i - 1);
        }


        /// <summary>
        /// Select a grade from available options
        /// </summary>
        public static void SelectGrade(int grade)
        {
                if (AutomationAgent.VerifyControlEnabled("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, grade.ToString()))
                {
                    AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, grade.ToString());
                    
                }
        }

        /// <summary>
        /// Verifies checking and unchecking of grades
        /// </summary>
        /// <returns></returns>
        public static bool VerifyCheckAndUncheckGrades()
        {
            bool notAddedGrade = false;
            int i = 2;
            while (!notAddedGrade)
            {
                if (AutomationAgent.VerifyControlEnabled("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString());
                    notAddedGrade = true;
                    break;
                }
                i++;
            }

            if (AutomationAgent.VerifyXamlToggleButtonPressed("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()))
            {
                AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString());
                return !(AutomationAgent.VerifyXamlToggleButtonPressed("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()));
            }

            else
                return false;

        }

        /// <summary>
        /// Verifies already downloaded grade cannot be selected
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public static bool VerifyAlreadyDownloadedGradeGrayedAndCannotBeSelected(string grade)
        {

                if (AutomationAgent.VerifyControlEnabled("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, grade.ToString()))
                {
                    AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, grade.ToString());
                }
                return (AutomationAgent.VerifyXamlToggleButtonPressed("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, grade.ToString()));

        }
        /// <summary>
        /// Clicks on the lesson which is yet not downloaded
        /// </summary>
        /// <param name="lessonNumber"></param>
        public static void WaitForLessonToDownloadAndClick(int lessonNumber)
        {

            if (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString()))
            {
                AutomationAgent.Click("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
                AutomationAgent.Wait();
                int trial = 5;
                while (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString()) && trial>0)
                {
                    AutomationAgent.Wait(2000);
                    trial--;
                }
                
            }
            AutomationAgent.Click("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());

        }

        /// <summary>
        /// Verifies Lesson Browser Tile
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonBrowserPage()
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, "1");
        }

        /// <summary>
        /// Verifies Lesson Browser App chrome Title contains Unot Number and Name
        /// </summary>
        /// <param name="UnitNumber"></param>
        /// <returns>true:if contains;false:doesn't contains</returns>
        public static bool VerifyLessonBrowserAppChromeTitleContainsUnitNoAndName(int UnitNumber)
        {
            string s1 = AutomationAgent.GetControlText("LessonBrowserView", "LessonBrowserPageTitle");
            return s1.Equals("Unit " + UnitNumber + ": Fitting In/Standing Out");
           
           
        }
        /// <summary>
        /// Verifies Lesson Browser Back Button Text contains Grade Number and Name
        /// </summary>
        /// <param name="GradeNumber"></param>
        /// <returns>true:if contains;false:doesn't contains</returns>
        public static bool VerifyLessonBrowserBackButtonTextContainsGradeNoAndName(int GradeNumber)
        {
           string s1 = AutomationAgent.GetControlText("UnitPreviewView", "BackButton");
            if (s1.Equals("Grade " + GradeNumber + " ELA"))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Clicks on Back button
        /// </summary>
        public static void ClickOnBackButton()
        {
            ClickBackButton();
        }
        /// <summary>
        /// Verify Lesson Prgress Bar Exists or not
        /// </summary>
        /// <param name="lessonNumber">int</param>
        /// <returns>bool: true(if Lesson Progress bar exists), false(if does not exists)</returns>
        public static bool VerifyLessonProgressBarExist(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString()) ||
                            AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonProgressBar", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies Lesson opened
        /// </summary>
        /// <param name="lessonNumber">int</param>
        public static bool VerifyLessonPreviewOpened(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        /// <summary>
        /// Verifies Lesson Opened to read
        /// </summary>
        public static bool VerifyLessonOpenedToRead()
        {
            return (AutomationAgent.VerifyControlExists("LessonView", "CurrentPageLabel") &&    
                                    (AutomationAgent.VerifyControlExists("LessonView", "NextButton")));
        }

        public static string GetEpisodeTitle(int EpisodeNumber)
        {
            bool b = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle");
            //bool b1 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle1");
            //bool b2 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle2");
            //bool b3 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle3");
            //bool b4 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle4");
            bool b5 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle5");
            bool b6 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle6");
            //bool b7 = AutomationAgent.VerifyControlExists("LessonPreviewView", "EpisodeTitle7");

            string s = AutomationAgent.GetControlText("LessonPreviewView", "EpisodeTitle5");
            return s;
        }

        public static void NavigateEpisode()
        {
          //  AutomationAgent.Swipe()
        }

        public static void NavigateLesson(int lessonNumber)
        {
            AutomationAgent.Click("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, (lessonNumber).ToString());
        }

        public static void ClickAddGradeContinueButton()
        {
            AutomationAgent.Click("AddGradesScreenView", "ContinueButton");
        }

        public static bool VerifyAddGradeButtonActive()
        {
            AutomationAgent.Wait();
            return AutomationAgent.VerifyControlEnabled("AddGradesScreenView", "AddGrades");
        }

        public static bool VerifyLessonsNotDownloaded(int lessonNumber)
        {

            bool b = AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            return b;
        }

        public static bool VerifyStartButtonForLessonPreviewCard(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }


        public static void OpenGalleryProblem(int taskNumber)
        {
            AutomationAgent.Click("LessonView", "GalleryProblemResearchLinearEq", WaitTime.DefaultWaitTime, taskNumber.ToString());
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyGalleryProblemLessonTaskPage(int lessonNo)
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "GalleryProblemLessonTaskChrome", WaitTime.DefaultWaitTime, lessonNo.ToString());
        }

        public static bool VerifyGalleryProblemPage()
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonTitleGalleryProblem");
        }

        public static bool VerifyDoneButtonInGalleryProblemPage()
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "DoneButton");
        }

        public static void ClickGalleryProblemDoneButton()
        {
            AutomationAgent.Click("LessonBrowserView", "DoneButton");
            AutomationAgent.Wait(300);
        }

        public static string GetUnitBackButtonText()
        {

            return AutomationAgent.GetControlText("UnitPreviewView", "BackButton");
            
        }

        public static bool VerifyGalleryLessonChromeIconsForTeacher()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                AutomationAgent.VerifyControlExists("NotebookView", "NotebookIcon") &&
                AutomationAgent.VerifyControlExists("TopMenuView", "ConceptCornerIcon") &&
                AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon") &&
                (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeTeacherGuideTitle") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool VerifyMathUnitPreview(int unitNumber)
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "StartButton", WaitTime.DefaultWaitTime, unitNumber.ToString());
        }

        public static bool VerifyMathLessonPreview(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }

        public static string GetLessonTitle()
        {
            return AutomationAgent.GetControlText("LessonBrowserView", "LessonTitle");
        }

        public static bool VerifyGalleryLessonChromeIconsForStudents()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookIcon") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "ConceptCornerIcon") &&
                 AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies Teacher Mode Icon
        /// </summary>
        /// <returns></returns>
        public static bool VerifyTeacherModeIconPresent()
        {
            return (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeTeacherGuideTitle") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA"));
        }

        public static bool VerifyGalleryProblemChromeBarIcons()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookIcon") &&
                 AutomationAgent.VerifyControlExists("LessonBrowserView", "DoneButton"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetLessonTitleGalleryProblem()
        {
            return AutomationAgent.GetControlText("LessonBrowserView", "LessonTitleGalleryProblem");
        }
        /// <summary>
        /// Clicks to open Image
        /// </summary>
        /// <param name="taskNumber"></param>
        public static void OpenImage(int taskNumber)
        {
            AutomationAgent.Click("LessonView", "halfscreen-donatorELA", WaitTime.DefaultWaitTime, taskNumber.ToString());
        }

        /// <summary>
        /// Verifies whether image is there in Lesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        public static bool VerifyImageExistinLesson()
        {
            return AutomationAgent.VerifyControlExists("LessonView", "halfscreen-donator");
        }

        /// <summary>
        /// To tap on the screen
        /// </summary>
        public static void TapOnScreen()
        {
            AutomationAgent.Click(1006, 388);
        }


        /// <summary>
        /// Verifies Image in Full Screen On ImageInLesson
        /// </summary>
        /// <param name="LessonBrowserAutomationAgent">AutomationAgent object</param>
        /// /// <returns>bool:true (if width equals device screen width), false(if width doesn't matches device width)</returns>
        public static bool VerifyImageFullScreen()
        {
            AutomationAgent.Wait(500);
            int SideStripWidth = 445;
            int WindowSize = AutomationAgent.GetAppWindowWidth();
            int ImageSize = AutomationAgent.GetControlWidth("NotebookELAView", "ImageFullScreenOpened") + SideStripWidth;

            if (WindowSize == ImageSize)
                return true;

            else
                return false;

        }
        /// <summary>
        ///  Clicks On Close button
        /// </summary>
        public static void ClickDoneButton()
        {
            AutomationAgent.Click("NotebookELAView", "CloseButton");
        }

        /// <summary>
        /// Verifies Back butotn availability
        /// </summary>
        /// <returns></returns>
        public static bool VerifyBackButtonExists()
        {
            return AutomationAgent.VerifyControlExists("UnitPreviewView", "BackButton");
        }

        /// <summary>
        /// Clicks on Back button
        /// </summary>
        public static void ClickBackButton()
        {
            AutomationAgent.Click("UnitPreviewView", "BackButton");
        }

        /// <summary>
        /// To Verify Games&ToolIcon in Lesson
        /// </summary>
        /// <returns></returns>

        public static bool VerifyGamesToolIconinLesson()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames");
        }
        /// <summary>
        /// To Verify Notebook Icon in Lesson
        /// </summary>
        /// <returns></returns>

        public static bool VerifyNotebookIconinLesson()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "NotebookIcon");
        }

        /// <summary>
        /// To Verify concept corner button in Lesson
        /// </summary>
        /// <returns></returns>

        public static bool VerifyConceptCornerButtoninLesson()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "ConceptCornerIcon");
        }

        /// <summary>
        /// To Verify NotificationIcon button in Lesson
        /// </summary>
        /// <returns></returns>

        public static bool VerifyNotificationButtoninLesson()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon");
        }

        /// <summary>
        /// To Verify NotificationIcon button in Lesson
        /// </summary>
        /// <returns></returns>

        public static bool VerifyTeacherModeIconInLesson()
        {
            return (AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeTeacherGuideTitle") || AutomationAgent.VerifyControlExists("TopMenuView", "TeacherModeButtonELA"));
        }


        /// <summary>
        /// To Verify GalleryProblem is opened in Lesson
        /// </summary>
        /// <returns></returns>
        public static bool VerifyGalleryProblemOpenedInLeson()
        {
            AutomationAgent.Wait(1000);
            return AutomationAgent.VerifyControlExists("TopMenuView", "GalleryProblemTitle");
        }

        /// <summary>
        /// To Verify GalleryPage is opened in Lesson
        /// </summary>
        /// <returns></returns>
        internal static bool VerifyGalleryPageOpened()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "GalleryPage");
        }
        /// <summary>
        /// 
        /// </summary>
        public static void ClickOnCloseCloseButton()
        {
            AutomationAgent.Click("NoteBookMathView", "CloseButton");
        }

        /// <summary>
        /// To click on specific coordinates on the screen
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        public static void TapOnScreen(int x1, int y1)
        {
            AutomationAgent.Wait(500);
            AutomationAgent.Click(x1, y1);
        }

        /// <summary>
        /// click on notebookicon
        /// </summary>

        public static void OpenNoteBook()
        {
            NotebookCommonMethods.ClickOnNotebookIcon();
            // AutomationAgent.Click("NotebookView", "NotebookIcon");
        }
        /// <summary>
        /// Verfies notebookTitle
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNoteBookTiltle()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NoteBookTiltle");

        }
        /// <summary>
        /// Verfies wifipopup
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNoWiFiPopUp()
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "WifiPopup");

        }

        /// <summary>
        /// Verfies Cancel Button
        /// </summary>
        /// <returns></returns>


        public static bool VerifyAddGradeCancelButtonEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("AddGradesScreenView", "CancelButton");
        }

        public static bool VerifyProgressBarOnLessonPreviewCard(int lessonNumber)
        {
            // bool b1=AutomationAgent.VerifyControlExists("UnitLibraryView", "ProgressBar",WaitTime.DefaultWaitTime, lessonNumber.ToString());
            bool b1 = AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());

            return b1;
        }

        public static bool VerifyStartButtonGrayedOutForNotDownLoadedLesson(int lessonNumber)
        {            

         return AutomationAgent.VerifyControlEnabled("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());

                      
        }

        public static bool VerifyNotebookSplitsScreen()
        {

            int ScreenWidth = AutomationAgent.GetAppWindowWidth();
            int LessonWidth = AutomationAgent.GetControlWidth("NotebookView", "LessonPane");
            int NotebookWidth = AutomationAgent.GetControlWidth("NotebookView", "NotebookPane");

            if ((LessonWidth + NotebookWidth - 1) == ScreenWidth)
                return true;

            else
                return false;
        }
        /// <summary>
        /// Verify Gallery lesson page vertically scrollable
        /// </summary>
        /// <returns></returns>
        public static bool VerifyGallerylessonpagerighttoleftscrollable()
        {
           
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(1089, 718, 443, 715);
            if (AutomationAgent.VerifyControlExists("LessonView", "GalleryProblemResearchLinearEq", WaitTime.DefaultWaitTime, "3"))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Verify Lesson Exists in Left of LessonBrowser
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonExistsinLeftofLessonBrowser()
        {
            bool LeftScroll = false;
            AutomationAgent.Slide(1016, 709, 615, 704);
            AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, "7");
            LeftScroll = true;
            return LeftScroll;
        }

        /// <summary>
        /// Swipes Lesson Preview to specified Lesson.
        /// </summary>
        /// <param name="Lsn"></param>
        public static void SwipeLessonPreview(int Lsn)
        {
            AutomationAgent.Click("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, Lsn.ToString());
        }


        /// <summary>
        /// Verifies Lesson are in Order.
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonsAreInOrder()
        {
            int lessonNumber = 1;
            for (; lessonNumber < 4; lessonNumber++)
            {
                if (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString()))//b1 == true)
                {

                }
                else
                {
                    break;
                }
            }
            if (lessonNumber == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Verifies Normal Screen Mode.
        /// </summary>
        /// <returns></returns>
        public static bool verifyNormalScreen()
        {
            int ScreenWidth = AutomationAgent.GetAppWindowWidth();
            int LessonWidth = AutomationAgent.GetControlWidth("NotebookView", "LessonPane");

            if (ScreenWidth == (LessonWidth - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Scrolls Left in Lesson Browser
        /// </summary>
        public static void LessonBrowserScrollLeft()
        {
            AutomationAgent.Slide(1016, 709, 615, 704);
        }

        /// <summary>
        /// Get Gallery NoteBook title
        /// </summary>
        /// <returns></returns>
        public static string GetGalleryNoteBookTitle()
        {
            return AutomationAgent.GetControlText("PersonalNotesView", "PersonalNoteTitle");
        }

        /// <summary>
        ///  verfies Single episode Unit 
        /// </summary>
        /// <returns></returns>
        public static bool VerifySingleEpisodeUnit()
        {
            int LessonHub = AutomationAgent.GetChildrenControlCount("LessonBrowserView", "LessonsHub");
            if (LessonHub == 2)
                return true;

            else
                return false;
        }

        /// <summary>
        /// Click On Specified Grade
        /// </summary>
        /// <param name="i"></param>
        public static void ClickOnGrade(int i)
        {
            if (AutomationAgent.VerifyControlEnabled("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()))
            {
                AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString());
            }
            else
            {
                Assert.Fail("Unit Already Downloaded");
            }
        }

        /// <summary>
        /// Verifies Grade Button is Active.
        /// </summary>
        /// <param name="gradeNumber"></param>
        /// <returns></returns>
        public static bool VerifyGradeButtonActive(int gradeNumber)
        {
            bool b1 = AutomationAgent.VerifyControlEnabled("UnitLibraryView", "GradeButton", WaitTime.DefaultWaitTime, gradeNumber.ToString());
            return b1;
        }

        /// <summary>
        /// Verifies Unit Download Progress Bar
        /// </summary>
        /// <returns></returns>
        public static bool VerifyUnitDownloadProgressBar()
        {
            return AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitProgressBar");

        }
        /// <summary>
        /// Swipes Lesson Preview card Screen to Left
        /// </summary>
        public static void SwipeLessonPreviewLeft()
        {
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(1027, 393, 318, 429);
        }
        /// <summary>
        /// Swipes Lesson Preview card Screen to Right
        /// </summary>
        public static void SwipeLessonPreviewRight()
        {
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(318, 429, 1027, 393);
        }


        /// <summary>
        /// To verify Video opens in FullScreen
        /// </summary>
        /// <returns></returns>
        public static bool VerifyVideoFullScreen()
        {
            int ScreenWidth = AutomationAgent.GetAppWindowWidth();
            int VideoWidth = AutomationAgent.GetControlWidth("VideoView", "VideoWindowWidth");
            
            
            if (VideoWidth == ScreenWidth)
                return true;
            else
                return false;
        }

        
        /// <summary>
        /// To ensure Message to SelectOnlyTwoGrades Is available
        /// </summary>
        /// <returns></returns>
        public static bool VerifyMessageToSelectOnlyTwoGrades()
        {
             if (AutomationAgent.GetControlText("AddGradesScreenView", "AddGradeText") == "Adding more than two grades is not recommended due to available space.")
                return true;

            else

                return false;
        }


        public static bool VerifyLessonPreviewAvailableonScreen(int lessonNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonPreviewView", "StartButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }
        /// <summary>
        /// Verifies if add grades button is present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyAddGradeButtonPresent()
        {
            AutomationAgent.Wait();
            return AutomationAgent.VerifyControlExists("AddGradesScreenView", "AddGrades");
        }
        /// <summary>
        /// Selects All grade present in the Select grades pop up 
        /// </summary>
        public static void SelectAllGradeInELA()
        {
            for (int i = 2; i <= 12; i++)
            {
                if (AutomationAgent.VerifyControlEnabled("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString());
                }
            }
        }
        /// <summary>
        /// Verifies Unit thumbnails 
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyUnitThumbnails()
        {
            while (AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitProgressBar"))
            {
                AutomationAgent.Wait();
            }
            if (AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitContentGrid"))
            {
                int count = AutomationAgent.GetChildrenControlCount("UnitLibraryView", "UnitContentGrid");
                for (int i = 1; i <= count; i++)
                {
                    AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitTileButton", WaitTime.DefaultWaitTime, i.ToString());
                }
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Verifies Remove Grade Button present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyRemoveGradeButtonPresent()
        {
            return AutomationAgent.VerifyControlExists("AddGradesScreenView", "RemoveGrade");
        }

        public static bool VerifyLessonPreviewCardProgressBar(int lessonNo)
        {
            while (!AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNo.ToString()))
            {
                CommonReadCommonMethods.Sleep();
                AutomationAgent.Slide(1027, 393, 318, 429);
                lessonNo++;
            }
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNo.ToString());
        }
        /// <summary>
        /// Removes any selected grade by clicking on Remove grade button and delete button in the pop up 
        /// </summary>
        public static void RemoveGrade()
        {
            AutomationAgent.Click("AddGradesScreenView", "RemoveGrade");
            AutomationAgent.Click("AddGradesScreenView", "RemoveGradeDeleteButton");
        }

        /// <summary>
        /// Clicks on the lesson which is yet not downloaded
        /// </summary>
        /// <param name="lessonNumber"></param>
        public static void ClickLessonFirstTime(int lessonNumber)
        {
            AutomationAgent.Click("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            AutomationAgent.Wait();

            while (AutomationAgent.VerifyControlExists("LessonBrowserView", "ProgressBarInLessonTile", WaitTime.DefaultWaitTime, lessonNumber.ToString()))
            {

            }
            AutomationAgent.Click("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
        }
        /// <summary>
        /// Gets the Count of the Childrens of Lesson Group 
        /// </summary>
        /// <returns>int: No of Childrens</returns>
        public static int GetELALessonsGroupCount()
        {
            AutomationAgent.Wait(2000);
            return AutomationAgent.GetChildrenControlCount("LessonBrowserView", "LessonsHub");
        }
        /// <summary>
        /// Verifies if specific lesson is present or not
        /// </summary>
        /// <param name="lessonNumber"></param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyLessonPresent(int lessonNumber)
        {
            int xPos = AutomationAgent.GetControlPositionX("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            if (xPos >= 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the Text present in ELA Thumbnails
        /// </summary>
        /// <param name="lessonNumber">int: lesson number</param>
        /// <returns>bool: true(if text is similar), false(if not similar)</returns>
        public static bool VerifyELALessonThumbnailText(int lessonNumber)
        {
            AutomationAgent.WaitForControlExists("LessonBrowserView", "OtherGroupLessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            string text = AutomationAgent.GetControlText("LessonBrowserView", "OtherGroupLessonTileButtonTxt", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            string text1 = "LESSON  " + lessonNumber;
            if (text.Equals(text1))
                return true;
            else return false;
        }
        /// <summary>
        /// gets the math Lessons group count
        /// </summary>
        /// <returns>int: count</returns>
        public static int GetMathLessonsGroupCount()
        {
            AutomationAgent.Wait(2000);
            return AutomationAgent.GetChildrenControlCount("LessonBrowserView", "LessonListGrid");
        }
        /// <summary>
        /// Verifies the Text present in Math Thumbnails
        /// </summary>
        /// <param name="lessonNumber">int: lesson Number</param>
        /// <returns>bool: true(if text similar), false(if not similar)</returns>
        public static bool VerifyMathLessonThumbnailText(int lessonNumber)
        {
            AutomationAgent.WaitForControlExists("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            string text = AutomationAgent.GetControlText("LessonBrowserView", "MathLessonNumber", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            string text1 = "LESSON  " + lessonNumber;
            if (AutomationAgent.VerifyControlExists("LessonBrowserView", "MathLessonTitle", WaitTime.DefaultWaitTime, lessonNumber.ToString()) && text.Equals(text1))
                return true;
            else return false;
        }
        /// <summary>
        /// Verifies the Color of Start button of Lesson preview
        /// </summary>
        /// <param name="sampleColor">color</param>
        /// <param name="lessonNo">int</param>
        /// <returns>bool: true(if color is similar), false(if not similar)</returns>
        public static bool VerifyStartLessonButtonColor(Color sampleColor, int lessonNo)
        {
            return AutomationAgent.CompareControlImageColor("LessonPreviewView", "StartButton", sampleColor, WaitTime.DefaultWaitTime, lessonNo.ToString());
        }
        /// <summary>
        /// Verifies the Class Roster
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyClassRoster()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Clicks on the specific grade user wants to Add
        /// </summary>
        /// <param name="gradeNo">int: garde needs to be selected</param>
        public static void SelectSpecificGrade(int gradeNo)
        {
            AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, gradeNo.ToString());
        }
        /// <summary>
        /// Clicks on the Close button present in Lesson Preview
        /// </summary>
        /// <param name="lessonNo">int: Lesson No</param>
        public static void ClickLessonPreviewCloseButton(int lessonNo)
        {
            AutomationAgent.Click("LessonPreviewView", "CloseButton", WaitTime.DefaultWaitTime, lessonNo.ToString());
        }
        /// <summary>
        /// Verifies Gallery Problem consisting of Only Single Task
        /// </summary>
        /// <returns>bool: true(if prev and next control doesn't exists), false(if any of the control exists)</returns>
        public static bool VerifySingleTaskGalleryPage()
        {
            if (AutomationAgent.VerifyControlExists("LessonView", "PreviousButton") &&
                AutomationAgent.VerifyControlExists("LessonView", "NextButton"))
                 return false;
            else
                return true;
        }

        public static void OpenGalleryProblemSecond(int taskNumber)
        {
            int xpos = AutomationAgent.GetControlPositionX("LessonView", "GalleryProblemResearchLinearEq", WaitTime.DefaultWaitTime, taskNumber.ToString());
           int width = AutomationAgent.GetControlWidth("LessonView", "GalleryProblemResearchLinearEq", WaitTime.DefaultWaitTime, taskNumber.ToString());
           int ypos = AutomationAgent.GetControlPositionY("LessonView", "GalleryProblemResearchLinearEq", WaitTime.DefaultWaitTime, taskNumber.ToString());

            AutomationAgent.Click(xpos + width + 200, ypos + 100);
        }

        /// <summary>
        /// Verifies the Lesson Number Associated with the lesson Thumbnail present or not
        /// </summary>
        /// <param name="lessonNumber">int</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyLessonNumbersOfLessonCards(int lessonNumber)
        {
            int count = GetELALessonsGroupCount();
            int lessonCount = 1;
            for (int i = lessonNumber; i < count; i++)
            {
                if (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonTileButton", WaitTime.DefaultWaitTime, i.ToString()))
                {
                    string text = AutomationAgent.GetControlText("LessonBrowserView", "LessonTileText", WaitTime.DefaultWaitTime, i.ToString());
                    string text1 = "LESSON  " + i;
                    lessonCount++;
                }
                else
                    break;
            }
            if (lessonCount == count)
                return true;
            else
                return false;
        }

        public static bool VerifySelectedGradeChecked(int UnitNo)
        {
            return AutomationAgent.VerifyXamlToggleButtonPressed("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, UnitNo.ToString());
        }
        /// <summary>
        /// Adds the Specific Grade User wants to Add
        /// </summary>
        /// <param name="gradeNo">int: grade number user wants to add</param>
        public static void AddSpecificGrade(int gradeNo)
        {
            AutomationAgent.Click("AddGradesScreenView", "AddGrades");
            AutomationAgent.Wait();
            AutomationAgent.Click("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, gradeNo.ToString());
            AutomationAgent.Click("AddGradesScreenView", "ContinueButton");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Waits till Specific grades get downloaded
        /// </summary>
        public static void WaitForGradeToDownload()
        {
            while (AutomationAgent.VerifyControlExists("UnitLibraryView", "PreparingUnits"))
            {
                if (AutomationAgent.VerifyControlExists("UnitLibraryView", "UnitTileButton", WaitTime.DefaultWaitTime, "1"))
                    break;
                else
                    AutomationAgent.Wait(10000);
            }
        }

        public static bool VerifyNoGradeChecked()
        {
            for (int i = 2; i < 12; i++)
            {
                if (AutomationAgent.VerifyXamlToggleButtonPressed("SelectGradeView", "GradeButton", WaitTime.DefaultWaitTime, i.ToString()))
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Click on lesson which is not downloaded and wait until it download
        /// </summary>
        /// <param name="lessonNumber"></param>
        public static void WaitForLessonToDownload(int lessonNumber)
        {
            if (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString()))
            {
                AutomationAgent.Click("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString());
                AutomationAgent.Wait();
                int trial = 5;
                while (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonDownloadButton", WaitTime.DefaultWaitTime, lessonNumber.ToString()) && trial>0)
                {
                    AutomationAgent.Wait(2000);
                    trial--;
                }
            }
        }
        /// <summary>
        /// Removes selected grade by clicking on Remove grade button and delete button in the pop up
        /// </summary>
        /// <param name="grade"></param>
        public static void RemoveGrade(int grade)
        {
            NavigationCommonMethods.NavigateToELAGrade(grade);
            AutomationAgent.Click("AddGradesScreenView", "RemoveGrade");
            AutomationAgent.Click("AddGradesScreenView", "RemoveGradeDeleteButton");
        }
        /// <summary>
        /// Verifies Gallery Problems Thumbnails are in Column
        /// </summary>
        /// <returns>bool: true(if in Column), false(if not in Column)</returns>
        public static bool VerifyGalleryProblemsInColumns()
        {
            int count = AutomationAgent.GetChildrenControlCount("LessonView", "LessonDocument");
            if (count >= 2)
                return true;
            else
                return false;
        }
        /// <summary>
        /// verify lesson progress bar
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonsStartToDownload()
        {
            return AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonProgressBar");
        }
        /// <summary>
        /// verifies lesson dowload in sequence
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLessonDownloadinSequence()
        {
            int j = 0;

            for (int i = 1; i <= 4; i++)
            {
                if (AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonProgressBar"))
                {
                    j++;
                }
                else
                {
                    AutomationAgent.Wait(2000);
                    i--;
                }
            }
            if (j == 4)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        /// <summary>
        /// Verifies Start Button Design Transparent
        /// </summary>
        /// <param name="lessonNumber"></param>
        /// <returns>true(if found)false(if not)</returns>
        public static bool VerifyStartButtonDesignMatch(int lessonNumber)
        {
            int x = AutomationAgent.GetControlPositionX("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            int y = AutomationAgent.GetControlPositionX("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            if(x==y)
            {
                return true;
            }
            int width = AutomationAgent.GetControlWidth("LessonPreviewView", "LessonPreviewGridViewItem", WaitTime.DefaultWaitTime, lessonNumber.ToString());
            if (width < 900)
            {
                return true;
            }
            else
            {
                return false;
            }


    }
        public static void GoToPreviousTaskPage()
        {
            AutomationAgent.Click("LessonView", "PreviousButton");
            System.Threading.Thread.Sleep(500);
        }

        public static void OpenGalleryProblemTeacherModeOpened(int taskNumber)
        {

            AutomationAgent.Wait();
           AutomationAgent.Click(200, 250);
        }
    }
}
