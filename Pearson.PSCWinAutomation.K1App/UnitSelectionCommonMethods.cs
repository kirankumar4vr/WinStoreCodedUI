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

namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for NavigationCommonMethods
    /// </summary>
    public static class UnitSelectionCommonMethods
    {
       

        public static int GetSystemTrayXCoordinate()
        {
            return AutomationAgent.GetControlPositionX("LoginView", "SystemTray");
        }

        public static bool VerifyELAAndMathGradeLabel(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool valid = true;
            string elaLabel = AutomationAgent.GetControlText("UnitSelectionView", "ELAGradeLabel");
            string mathLabel = AutomationAgent.GetControlText("UnitSelectionView", "MathGradeLabel");
            if (!elaLabel.Equals("KINDERGARTEN"))
            {
                assertFailureMessage += "ELA Grade Label is not correct. ";
                valid = false;
            }
            if (!mathLabel.Equals("KINDERGARTEN"))
            {
                assertFailureMessage += "MATH Grade Label is not correct. ";
                valid = false;
            }
            return valid;
        }

        public static string GetElaGradeLabelText()
        {
            return AutomationAgent.GetControlText("UnitSelectionView", "ELAGradeLabel");
        }

        public static void SwipeElaGradeToGrade1(int trial = 17)
        {
            
            while(trial>0)
            {
            AutomationAgent.Swipe("UnitSelectionView", "GradeSelectionELAGrid", UITestGestureDirection.Up);
                trial--;
            }
            
        }

        public static string GetMathGradeLabelText()
        {
            return AutomationAgent.GetControlText("UnitSelectionView", "MathGradeLabel");
        }

        public static void SwipeMathGradeToGrade1(int trial = 30)
        {
            
            //while (trial > 0)
            while (GetMathGradeLabelText() != "GRADE 1" && trial>0)
            {
                AutomationAgent.Swipe("GradeSelectionView", "GradeSelectionMathGridViewParent", UITestGestureDirection.Up);
                trial--;
            }
        }

        public static void SwipeElaGradeTillGrade1Visible()
        {
            int trial = 30;
            while (GetElaGradeLabelText()!= "GRADE 1" && trial>0)
            {
                AutomationAgent.Swipe("UnitSelectionView", "GradeSelectionELAGrid", UITestGestureDirection.Up);
                trial--;
            }
        }

        public static void ClickToPlayIntroVideoEla()
        {
            AutomationAgent.Click("GradeSelectionView", "UnitHomeScreenIntroVdo");
        }

        public static bool VerifyVideoOpenedFullScreen()
        {
           int AppWindowWidth = AutomationAgent.GetAppWindowWidth();
            int AppWindowHeight = AutomationAgent.GetAppWindowHeight();
            int VideoPlayerWidth = AutomationAgent.GetControlWidth("VideoView", "VideoPlayer");
            int VideoPlayerHeight = AutomationAgent.GetControlHeight("VideoView", "VideoPlayer");

            if ((AppWindowWidth == VideoPlayerWidth) && (AppWindowHeight == VideoPlayerHeight))
                return true;

            else
                return false;
        }

        public static bool VerifyVideoHasBackButton()
        {
            if (!AutomationAgent.VerifyControlExists("VideoView", "VideoPlayerBackButton"))
                return false;
            
            int BackButtonX = AutomationAgent.GetControlPositionX("VideoView", "VideoPlayerBackButton");
            int BackButtonY = AutomationAgent.GetControlPositionY("VideoView", "VideoPlayerBackButton");

            if (BackButtonX < 100 && BackButtonY < 100)
                return true;

            else
                return false;
             
        }

        public static void ClickVideoBackButton()
        {
            AutomationAgent.Click("VideoView", "VideoPlayerBackButton");
        }


        public static bool VerifyImageHasBackButton()
        {
            if (!AutomationAgent.VerifyControlExists("ImagePlayerView", "ImagePlayerGoBackButton"))
                return false;

            int BackButtonX = AutomationAgent.GetControlPositionX("ImagePlayerView", "ImagePlayerGoBackButton");
            int BackButtonY = AutomationAgent.GetControlPositionY("ImagePlayerView", "ImagePlayerGoBackButton");

            if (BackButtonX < 100 && BackButtonY < 100)
                return true;

            else
                return false;
        }

        public static void ClickImageBackButton()
        {
            AutomationAgent.Click("ImagePlayerView", "ImagePlayerGoBackButton");
        }

        public static bool VerifyTodayLessonVideo()
        {
          return  AutomationAgent.VerifyControlExists("GradeSelectionView", "UnitHomeScreenIntroVdo");
        }

        public static void ClickAddButtonBookLog()
        {
            AutomationAgent.Click("BookLogView", "BookLogAddButton");
        }

        public static bool VerifyFlyoutAddButtonBookLog()
        {
            return AutomationAgent.VerifyControlExists("BookLogView", "AddButtonFlyout");
        }
        public static bool VerifyTodaysLessonButtonPrevious()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodayButtonLessonPrevious");
        }

        public static bool VerifyTodaysLessonButtonNext()
        {
            return AutomationAgent.VerifyControlExists("LessonsViewInEla", "TodayButtonLessonNext");
        }

        public static int GetXPositionofPreviousButton()
        {
            return AutomationAgent.GetControlPositionX("LessonsViewInEla", "TodayButtonLessonPrevious");
        }

        public static int GetXPositionofNextButton()
        {
            return AutomationAgent.GetControlPositionX("LessonsViewInEla", "TodayButtonLessonNext");
        }

        public static void ClickTodaysLessonButtonNext()
        {
             AutomationAgent.Click("LessonsViewInEla", "TodayButtonLessonNext");
        }
        public static void ClickTodaysLessonButtonPrevious()
        {
            AutomationAgent.Click("LessonsViewInEla", "TodayButtonLessonPrevious");
        }

        public static bool VerfiyLessonNumberDisplayed(int LessonNumber)
        {
            return AutomationAgent.VerifyAppChildrenByName("Lesson " + LessonNumber);
        }

        public static bool VerifyInteractiveDesignHavingBackNotebookButtonAndHeader()
        {
            return AutomationAgent.VerifyControlExists("InteractiveView", "InteractiveGoBackButton") &&
                AutomationAgent.VerifyControlExists("InteractiveView", "InteractiveHeader");
//                AutomationAgent.VerifyControlExists("InteractiveView","InteractiveSendToNotebookButton");
        }

        internal static void ClickInteractiveBackButton()
        {
            AutomationAgent.Click("InteractiveView", "InteractiveGoBackButton");
        }
    }
}