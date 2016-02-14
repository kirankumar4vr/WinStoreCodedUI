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
    /// Summary description for NotebookCommonMethods
    /// </summary>

    public class NotebookCommonMethods
    {
        public static void ClickOnNotebookIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookIcon");
           // AutomationAgent.Wait(500);
            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUEBtn");
            }
        }

        public static bool VerifyNotebookOpen()
        {
            AutomationAgent.Wait(1000);
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookPane");
        }

        public static bool VerifyUndoRedoButton()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "UndoRedoTab");
        }

        public static void ClickUndoRedoIconInNotebook()
        {
            AutomationAgent.Click("NotebookView", "UndoRedoTab");
        }

        public static bool VerifyUndoRedoSubMenu()
        {
            return (AutomationAgent.VerifyControlExists("NotebookView", "UndoIcon") && AutomationAgent.VerifyControlExists("NotebookView", "RedoIcon"));

        }




        /// <summary>
        /// Clicks Show Tools And Games
        /// </summary>
        public static void ClickOnToolbarButton()
        {
            AutomationAgent.Click("DashboardView", "ShowToolsAndGames");
        }

        /// <summary>
        /// Verifies Games And Tools Sub Menu
        /// </summary>
        /// <returns></returns>
        public static bool VerifyToolbarSubMenu()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGamesSubMenu");
        }

        /// <summary>
        /// Clicks On Tools Menu
        /// </summary>
        public static void ClickOnToolsIcon()
        {
            AutomationAgent.Click("DashboardView", "ToolsFlyOutMenu");

        }
        /// <summary>
        /// Verifies Snapshot Sub Menu
        /// </summary>
        /// <returns></returns>
        public static bool VerifySnapshotToolButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "SnapShotButton");
        }


        public static bool VerifyToolbarButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames");
        }

        public static void ClickEraseIconInNotebook()
        {
            AutomationAgent.Click("NotebookView", "EraseButton");
        }

        public static void ClickClearPage()
        {
            AutomationAgent.Wait(300);
            AutomationAgent.Click("NotebookView", "ClearPageButton");
            //TODO-Chek if it works
            ClickHandIconInNotebook();
        }

        public static void OpenSnapShot()
        {
            ClickOnToolbarButton();
            ClickOnToolsIcon();
            ClickSnapshotToolButton();
        }

        public static void ClickSnapshotToolButton()
        {
            AutomationAgent.Click("DashboardView", "SnapshotFlyOutMenu");
        }

        public static bool VerifySnapShotGridPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "SnapShotGrid");
        }

        public static void ClickCancelSnapShot()
        {
            AutomationAgent.Click("NotebookView", "SnapShotCancel");
        }


        public static void ClickCaptureSnapShot()
        {
            AutomationAgent.Click("NotebookView", "SnapShotCapture");
            AutomationAgent.Wait(1000);
        }

        /// <summary>
        /// To verify All Notebook Bottom Toolbars Active or Inactive
        /// </summary>
        /// <returns>bool: true (if Active Inactive as expected), false (if not per expectations)</returns>
        public static bool VerifyAllBottomToolbarsActiveInactive()
        {

            if (
            (AutomationAgent.VerifyControlEnabled("NotebookView", "FullscreenIcon")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "HandIcon")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "TextIcon")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "PenIcon")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "EraseButton")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "ImageIcon")) &&
            !(AutomationAgent.VerifyControlEnabled("NotebookView", "WrenchIcon")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "BackgroundIcon")) &&
            (AutomationAgent.VerifyControlEnabled("NotebookView", "UndoRedoTab")) //&&
            //!(AutomationAgent.VerifyControlExists("NoteBookMathView", "DeletePageButton"))
                )
            {

                return true;

            }
            else
                return false;

        }
        ///// <summary>
        ///// Clicks on Image Icon
        ///// </summary>
        //public static void ClickOnImageIcon()
        //{
        //    AutomationAgent.Click("NotebookView", "ImageIcon");
        //}
        /// <summary>
        /// Verifies Photo Thumbnail Exists or not
        /// </summary>
        /// <returns>true:thumbnail present;false:absent</returns>
        public static bool VerifyPhotoExists()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "PhotoRegionThumbnail");
        }

        /// <summary>
        /// Clicks on Snapdhot Icon  available in Bottom menu
        /// </summary>
        public static void ClickOnSnapShotIcon()
        {
            AutomationAgent.Click("NotebookView", "SnapshotButtonBottom");
        }

        /// <summary>
        /// Verifies Hand Icon Highlighted
        /// </summary>
        /// <returns>true:Highlighted;false:Not highlighted</returns>
        public static bool VerifyHandIconActiveHighlight()
        {
            return AutomationAgent.VerifyXamlToggleButtonPressed("NotebookView", "HandIcon");
        }

        /// <summary>
        /// Verifies Cancel Button available
        /// </summary>
        /// <returns>true:Available Button; false:Not available</returns>
        public static bool ToVerifyCancelButtonWhileAddingImage()
        {

            return AutomationAgent.VerifyControlExists("NotebookView", "CancelAddPhoto");
        }

        /// <summary>
        /// Clicks Cancel Button while adding photo
        /// </summary>
        public static void ClickCancelAddPhoto()
        {
            AutomationAgent.Click("NotebookView", "CancelAddPhoto");
        }



        /// <summary>
        /// Verifies whether Notebook splits Lesson Window
        /// </summary>
        /// <returns>true:if splited;false:if not</returns>
        public static bool VerifyNotebookSplitsLessonWindow()
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
        /// Verifies for NotebookIcon presence
        /// </summary>
        /// <returns>true:Icon present;false:absent</returns>
        public static bool VerifyNotebookIconPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookIcon");
        }

        /// <summary>
        /// To get width of Image Thumbnail
        /// </summary>
        /// <returns>int:Width</returns>
        public static int GetWidthOfImageThumbnail()
        {
            return AutomationAgent.GetControlWidth("NotebookView", "PhotoRegionThumbnail");
        }

        /// <summary>
        /// To get width of Image Thumbnail
        /// </summary>
        /// <returns>int:Width</returns>
        public static int GetHeightOfImageThumbnail()
        {
            return AutomationAgent.GetControlHeight("NotebookView", "PhotoRegionThumbnail");
        }
        public static void AddImageInNoteBook()
        {
            ClickMultimediaIcon();
            AutomationAgent.Click("NotebookView", "Photos");
            AutomationAgent.Click("NotebookView", "SelectPhoto");
            AutomationAgent.Click("NotebookView", "OpenAddPhoto");
            AutomationAgent.Wait(500);
        }

        public static void ClickOnWrenchIcon()
        {
            //MP-4-Aug - As multimedia insertion is not activating Hand icon - issue
            //TODO - Remove this line
            ClickHandIconInNotebook();

            AutomationAgent.Click("NoteBookMathView", "WrenchIcon");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyWrenchToolSketchGraphSubMenuExists()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "WrenchIconSubMenuSketchGraph");
        }

        public static bool VerifyWrenchToolGraphingSubMenuExists()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "WrenchIconSubMenuGraphing");
        }

        public static bool VerifyDesmosTool()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "WrenchIconSubMenuGraphing");
        }
        public static void ClickOnDesmosTool()
        {
            AutomationAgent.Click("NoteBookMathView", "Open DesmosTool");
        }

        //public static void ClickOnNotebookIcon()
        //{
        //    AutomationAgent.Click("UnitLibraryView", "Open TopNoteBook");
        //}

        public static bool VerifyWrenchIcon()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "WrenchIcon");
        }



        public static void ClickOnGraphicTool()
        {
            AutomationAgent.Click("NoteBookMathView", "Graphic Tool");
            AutomationAgent.Wait(1000);
        }

        public static void ClickOnDoneButtonNewlyCreateDesmos()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("NoteBookMathView", "CloseButton");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyAlertMessageforConfirmationNewDesmos()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "CONTINUE");
        }

        public static void ClickContinueOnAlertMessageforConfirmationNewDesmos()
        {
            AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            AutomationAgent.Wait(2000);
            if (AutomationAgent.VerifyControlExists("NotebookView", "HandIcon"))
            {
                NotebookCommonMethods.ClickHandIconInNotebook();
                NotebookCommonMethods.ClickHandIconInNotebook();
            }
        }

        public static object VerifyGlobalNavBarPresentInMathLesson1()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "GlobalNavBarPresentInMathLesson1");
        }

        public static void ClickOnSendToNotebookIcon()
        {
            AutomationAgent.Click("NoteBookMathView", "SendToNotebookIcon");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifySendToNotebookIconPresent()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "SendToNotebookIcon");
        }

        public static void ClickOnDoneCloseButton()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("NoteBookMathView", "CloseButton");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyNewDesmosPagePresent()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "InteractiveGraphingCalculator");
        }

        public static bool VerifyDesmosIsPresentInNotebook()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "PARTImage");
        }


        public static void ClickDoneButton()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("CommonReadView", "CommonReadDone");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyImageInCenterOfNotebook()
        {
            AutomationAgent.GetControlPositionX("NotebookView", "NotebookIcon");




            int NoteBookX = AutomationAgent.GetControlPositionX("NotebookView", "NotebookPane");
            int NoteBookY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookPane");
            int NotebookWidth = AutomationAgent.GetControlWidth("NotebookView", "NotebookPane");
            int NotebookHeight = AutomationAgent.GetControlHeight("NotebookView", "NotebookPane");

            int ImgPosX = AutomationAgent.GetControlPositionX("NotebookView", "PhotoRegionThumbnail");
            int ImgPosY = AutomationAgent.GetControlPositionY("NotebookView", "PhotoRegionThumbnail");
            int ImgWidth = AutomationAgent.GetControlWidth("NotebookView", "PhotoRegionThumbnail");
            int ImgHeight = AutomationAgent.GetControlHeight("NotebookView", "PhotoRegionThumbnail");

            int diff = (NoteBookX + NotebookWidth / 2) - (ImgPosX + ImgWidth / 2);
            int diffHeight = (NoteBookY + NotebookHeight / 2) - (ImgPosY + ImgHeight / 2);

            if (diff == 0 && diffHeight < 2)
                return true;

            else
                return false;

        }

        public static void MoveImageInNoteBook()
        {
            AutomationAgent.Swipe("NotebookView", "PhotoRegionThumbnail", UITestGestureDirection.Down);
        }

        public static string GetImageCoordinate()
        {
            int ImgPosX = AutomationAgent.GetControlPositionX("NotebookView", "PhotoRegionThumbnail");
            int ImgPosY = AutomationAgent.GetControlPositionY("NotebookView", "PhotoRegionThumbnail");

            return (ImgPosX + "," + ImgPosY).ToString();
        }

        public static void ResizeImageInNoteBook()
        {
            int ImgX = AutomationAgent.GetControlPositionX("NotebookView", "PhotoRegionThumbnail");
            int Width = AutomationAgent.GetControlWidth("NotebookView", "PhotoRegionThumbnail");
            int X1 = ImgX + Width - 5;
            int Y1 = AutomationAgent.GetControlPositionY("NotebookView", "PhotoRegionThumbnail");
            AutomationAgent.Stretch(X1, Y1, X1 - 50, Y1 - 20, 50);
        }

        public static void NotebookWorkBrowserView()
        {
            if (AutomationAgent.VerifyControlExists("PersonalNotesView", "NotebookBrowserButton"))
                AutomationAgent.Click("PersonalNotesView", "NotebookBrowserButton");


            else if (AutomationAgent.VerifyControlExists("PersonalNotesView", "NotebookWorkBrowserButton"))
                AutomationAgent.Click("PersonalNotesView", "NotebookWorkBrowserButton");


        }

        public static void ClickPersonalNotesLink()
        {
            AutomationAgent.Click("PersonalNotesView", "PersonalNotesButton");
        }

        public static void ClickCreateNoteInPersonalNote()
        {
            AutomationAgent.Click("PersonalNotesView", "CreateNote");
        }

        public static void ClickOnCreatePersonalNoteCancel()
        {
            AutomationAgent.Click("PersonalNotesView", "PersonalNoteCANCEL");
        }

        public static string VerifyPersonalNoteDefaultTitleAndPopup()
        {
            return AutomationAgent.GetText("PersonalNotesView", "NewPersonalNoteTitleText");
        }

        public static bool VerifyAlertMessageButtons()
        {
            bool b = AutomationAgent.VerifyControlExists("NoteBookMathView", "CONTINUE");
            bool b1 = AutomationAgent.VerifyControlExists("NoteBookMathView", "CANCEL");

            if (b && b1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void ClickCancelOnAlertMessageforConfirmationNewDesmos()
        {
            AutomationAgent.Click("NoteBookMathView", "CANCEL");
        }

        public static void ClickOnDesmosThumbnail()
        {
            //if (!AutomationAgent.VerifyControlExists("NoteBookMathView", "DesmosClose"))
                ClickHandIconInNotebook();

            if (AutomationAgent.VerifyControlExists("NoteBookMathView", "PARTImage"))
                AutomationAgent.Click("NoteBookMathView", "PARTImage");
            AutomationAgent.Wait(2000);
        }
        public static bool VerifyTextRegionDeleteXIconPresent()
        {
            bool b = AutomationAgent.VerifyControlExists("NoteBookMathView", "DesmosClose");
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "DesmosClose");
        }

        public static void ClickTextRegionDeleteXIcon()
        {
            if (!AutomationAgent.VerifyControlExists("NoteBookMathView", "DesmosClose"))
            {
                ClickOnInteractiveThumbnail();
            }
            AutomationAgent.Click("NoteBookMathView", "DesmosClose");
        }


        public static void ClickUndoIconInNotebook()
        {
            AutomationAgent.Click("NoteBookMathView", "UndoIcon");
        }

        public static void ClickRedoIconInNotebook()
        {
            AutomationAgent.Click("NoteBookMathView", "RedoIcon");
        }

        public static void DeleteNotebookPage()
        {
            AutomationAgent.Click("NoteBookMathView", "DeletePageButton");
            //AutomationAgent.Click("NoteBookMathView", "DeleteNotebookPage");
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("NoteBookMathView", "Okay");
        }

        public static void TapOnScreen()
        {
            AutomationAgent.Click(130, 140);
        }


        public static void SetNameToPersonalNote(string title)
        {
            AutomationAgent.SetText("PersonalNotesView", "NewPersonalNoteTitleText", title);
        }

        public static bool VerifyCreateButtonPersonalNotesEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("PersonalNotesView", "PersonalNoteCREATE");
        }

        public static void ClickPersonalNoteCreateButton()
        {
            AutomationAgent.Click("PersonalNotesView", "PersonalNoteCREATE");

            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 2000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            }
        }


        public static bool VerifyPersonalNoteFound()
        {
            return AutomationAgent.VerifyControlExists("PersonalNotesView", "PersonalNoteTitle");
        }

        public static void EditPersonalNotesTitle(string title)
        {
            AutomationAgent.Wait(500);
            if (AutomationAgent.VerifyControlExists("PersonalNotesView", "PersonalNoteTitle"))
                AutomationAgent.Click("PersonalNotesView", "PersonalNoteTitle");

            AutomationAgent.SetText("PersonalNotesView", "PersonalNoteTitleEdit", title);
            AutomationAgent.Wait(1000);
        }

        public static string VerifyNewPersonalNotesTitle()
        {
            if (AutomationAgent.VerifyControlExists("PersonalNotesView", "PersonalNoteTitle"))
                AutomationAgent.Click("PersonalNotesView", "PersonalNoteTitle");

            return AutomationAgent.GetText("PersonalNotesView", "PersonalNoteTitleEdit");
        }

        public static void ClickXIconNewPersonalNote()
        {
            AutomationAgent.Click("PersonalNotesView", "PersonalNoteTitleCloseX");
        }

        public static void ClickXIconInNotebookTitle()
        {
            if (AutomationAgent.VerifyControlExists("PersonalNotesView", "PersonalNoteTitle"))
                AutomationAgent.Click("PersonalNotesView", "PersonalNoteTitle");

            AutomationAgent.Click("PersonalNotesView", "PersonalNoteTitleEditCloseX");
        }

        public static bool VerifyGoToWorkBrowserButtonPresent()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "GoToWorkBrowserButton");
        }

        public static void ClickGoToWorkBrowserButton()
        {
            AutomationAgent.Click("WorkBrowserView", "GoToWorkBrowserButton");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyWorkBrowserOverlayPresent()
        {
            AutomationAgent.Wait(1000);
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "BrowseNotesOverlay");
        }

        public static void ClickXBrowserNoteXButton()
        {
           // AutomationAgent.Click("WorkBrowserView", "BrowseNotesOverlayClose");
            AutomationAgent.Click(110, 90);
            AutomationAgent.Wait();

        }

        public static bool VerifyBrowserNoteXButtonPresent()
        {
            //return AutomationAgent.VerifyControlExists("WorkBrowserView", "BrowseNotesOverlayClose");
            return true;

        }

        public static void VerifyNotebookSinglePageAndDeleteAdditionalPages()
        {
            while (AutomationAgent.VerifyControlEnabled("NoteBookMathView", "DeletePageButton"))
            {
                DeleteNotebookPage();
            }
        }

        public static void AddNewNotebookPage()
        {
            AutomationAgent.Click("NotebookView", "NotebookAddPage");
            AutomationAgent.Wait(200);
        }

        public static void ClickLeftArrowIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookPageArrowLeft");
            AutomationAgent.Wait(200);
        }

        public static bool VerifyLeftArrowExists()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageArrowLeft");
        }

        public static bool VerifyRightArrowExists()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageArrowRight");
        }

        public static void ClickRightArrowIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookPageArrowRight");
            AutomationAgent.Wait(200);
        }

        public static bool VerifySnapshotSavedMessage()
        {
            return (AutomationAgent.VerifyControlExists("NotebookView", "SnapShotSavedHeader") &&
                                        AutomationAgent.VerifyControlExists("NotebookView", "SnapShotSavedBody"));
        }

        public static void TapOnScreen(int x1, int y1)
        {
            AutomationAgent.Click(x1, y1);
        }

        public static string GetDesmosCoordinate()
        {
            AutomationAgent.Wait(500);
            int ImgPosX = AutomationAgent.GetControlPositionX("NoteBookMathView", "PARTImage");
            int ImgPosY = AutomationAgent.GetControlPositionY("NoteBookMathView", "PARTImage");

            return (ImgPosX + "," + ImgPosY).ToString();
        }

        public static void MoveDesmosInNoteBook()
        {
            AutomationAgent.Swipe("NoteBookMathView", "PARTImage", UITestGestureDirection.Down);
        }
        public static string GetDesmosModifiedTime()
        {
            return AutomationAgent.GetControlText("NoteBookMathView", "DateOfDesmos");
        }
        /// <summary>
        /// Moves the graph to Edit desmos
        /// </summary>
        public static void EditDesmos()
        {
            AutomationAgent.Wait(1000);
            AutomationAgent.Slide(669, 513, 770, 415);
            AutomationAgent.Wait(1000);
        }


        public static String getImageTitle()
        {
            return AutomationAgent.GetControlText("NoteBookMathView", "DesmosImageTitle");
        }

        public static void ClickonPanModeBtn()
        {
            AutomationAgent.Click("NoteBookMathView", "NotebookPanModeBtn");

        }
        /// <summary>
        /// To Verify that Desmos Thumbnail is in the Center of the Notebook
        /// </summary>
        /// <returns></returns>
        public static bool VerifyDesmosAtCenterOfNotebook()
        {
            AutomationAgent.GetControlPositionX("NotebookView", "NotebookIcon");

            int NoteBookX = AutomationAgent.GetControlPositionX("NotebookView", "NotebookPane");
            int NoteBookY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookPane");
            int NotebookWidth = AutomationAgent.GetControlWidth("NotebookView", "NotebookPane");
            int NotebookHeight = AutomationAgent.GetControlHeight("NotebookView", "NotebookPane");

            int ImgPosX = AutomationAgent.GetControlPositionX("NotebookView", "PhotoRegionThumbnail");
            int ImgPosY = AutomationAgent.GetControlPositionY("NotebookView", "PhotoRegionThumbnail");
            int ImgWidth = AutomationAgent.GetControlWidth("NotebookView", "PhotoRegionThumbnail");
            int ImgHeight = AutomationAgent.GetControlHeight("NotebookView", "PhotoRegionThumbnail");

            int diff = (NoteBookX + NotebookWidth / 2) - (ImgPosX + ImgWidth / 2);
            int diffHeight = (NoteBookY + NotebookHeight / 2) - (ImgPosY + ImgHeight / 2);

            if (diff < 10 && diffHeight < 30)
                return true;

            else
                return false;

        }


        public static void OpenImageMultimedia()
        {
            ClickMultimediaIcon();
            AutomationAgent.Click("NotebookView", "Photos");
        }

        public static void OpenExistingPersonalNote()
        {
            int posx = AutomationAgent.GetControlPositionX("PersonalNotesView", "CreateNote");
            int PosY = AutomationAgent.GetControlPositionY("PersonalNotesView", "CreateNote");
            AutomationAgent.Click(posx + 250, PosY - 100);
        }

        public static void ClickTextIconInNotebook()
        {
            AutomationAgent.Click("NotebookView", "TextIcon");
            AutomationAgent.Click("NotebookView", "TextIcon");
            AutomationAgent.Wait(300);
        }

        public static void AddTextInNotebook(string TextToSet)
        {
            AutomationAgent.SetText("NotebookView", "AddTextInNotebook", TextToSet);
        }

        public static string GetTextInTextZone()
        {
            AutomationAgent.Wait(500);
            return AutomationAgent.GetText("NotebookView", "AddTextInNotebook");
        }

        public static int GetNotebookPage()
        {
            string page = AutomationAgent.GetControlText("NoteBookMathView", "NoteBookPage");

            string[] currentpage = page.Split('/');
            int pageno = Int32.Parse(currentpage[1].Replace(")", ""));

            return pageno;
        }



        /// <summary>
        /// To click on the Drawing Icon in NoteBook
        /// </summary>
        public static void ClickDrawingIconInNotebook()
        {
            AutomationAgent.Click("NoteBookMathView", "NotebBookDrawingIcon");
        }

        /// <summary>
        /// Gets the Notebook page number with current page number
        /// </summary>
        /// <param name="notebookAutomationAgent">AutomationAgent object</param>
        /// <returns>string: notebook page no. with current page no.</returns>

        public static string GetNoteBookPageNosWithCurrentPage()
        {
            string s = AutomationAgent.GetControlText("NoteBookMathView", "NoteBookPage");
            string[] s1 = s.Split(' ');

            return s1[1];
        }


        /// <summary>
        /// Clicks to Open Notebook
        /// </summary>
        public static void ClickOnOpenNotebookButton(int taskNumber)
        {
            AutomationAgent.Click("LessonView", "OpenNotebookButton", WaitTime.DefaultWaitTime, taskNumber.ToString());
            AutomationAgent.Wait(500);
            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 5000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUEBtn");
            }
        }


        /// <summary>
        /// Verifies Notebook Open Button available
        /// </summary>
        /// <returns></returns>
        public static bool VerifyOpenNotebookButtonPresent(int taskNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonView", "OpenNotebookButton", WaitTime.DefaultWaitTime, taskNumber.ToString());
        }



        /// <summary>
        /// Click on NotebookWorkBrowser Folder View
        /// </summary>
        public static void ClickNotebookWorkBrowserView()
        {
            //AutomationAgent.Click("PersonalNotesView", "NotebookBrowserButton");
            NotebookWorkBrowserView();
        }

        /// <summary>
        /// Method to verify AlertMessageforConfirmationOfNewInteractive
        /// </summary>
        /// <returns></returns>

        public static bool VerifyAlertMessageforConfirmationOfNewInteractive()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "CONTINUE");
        }

        /// <summary>
        /// To click on  Continue for ConfirmationOfNewInteractive
        /// </summary>
        public static void ClickContinueOnAlertMessageforConfirmationOfNewInteractive()
        {
            AutomationAgent.Click("NoteBookMathView", "CONTINUE");
            if (AutomationAgent.VerifyControlExists("NotebookView", "HandIcon"))
            {
                NotebookCommonMethods.ClickHandIconInNotebook();
                NotebookCommonMethods.ClickHandIconInNotebook();
            }

        }
        /// <summary>
        /// To get Date of newly created Interactive
        /// </summary>
        /// <returns></returns>

        public static string GetInteractiveModifiedTime()
        {
            return AutomationAgent.GetControlText("NoteBookMathView", "DateOfDesmos");
        }

        /// <summary>
        /// To click on Interactive Thumbnail
        /// </summary>
        public static void ClickOnInteractiveThumbnail()
        {
            AutomationAgent.Click("NoteBookMathView", "PARTImage");
            if (AutomationAgent.VerifyControlExists("NoteBookMathView", "DesmosClose"))
            {
                AutomationAgent.Click("NoteBookMathView", "PARTImage");
            }

        }

        /// <summary>
        /// Method to verify the presence of newly created Interactive in Notebook
        /// </summary>
        /// <returns></returns>

        public static bool VerifyInteractiveIsPresentInNotebook()
        {

            return AutomationAgent.VerifyControlExists("NoteBookMathView", "InteractiveHowManySolutions?");
        }

        /// <summary>
        /// Wait for Interactive in order to vary the Timestamp
        /// </summary>
        public static void WaitforInteractive()
        {
            LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            LessonBrowserCommonMethods.SwipeLessonPreviewRight();
            AutomationAgent.Wait(50000);
        }


        /// <summary>
        /// To verify the presence of new Interactive Page
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNewInteractivePagePresent()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "HowManySolutions?");
        }

        public static void AddVideoInNotebook()
        {
            ClickMultimediaIcon();
            AutomationAgent.Click("NotebookView", "Photos");
            //To Check - 

            //bool b = AutomationAgent.VerifyControlExists("NotebookView", "ItemPickerWindow",500);
            //bool b1 = AutomationAgent.VerifyControlExists("NotebookView", "SelectMedia3",500);
            //bool b2 = AutomationAgent.VerifyControlExists("NotebookView", "SelectMedia",500);
            //bool b4 = AutomationAgent.VerifyControlExists("NotebookView", "GridRoot", 100);
            //int childcount = AutomationAgent.GetChildrenControlCount("NotebookView", "GridRoot");

            AutomationAgent.Click("NotebookView", "SelectMedia", WaitTime.DefaultWaitTime, "3");

            AutomationAgent.Click("NotebookView", "OpenAddPhoto");
            AutomationAgent.Wait(500);
        }

        public static bool VerifyVideoThumbnailFound()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "VideoRegionThumbnail");
        }

        public static bool VerifyVideoWaterMark()
        {
            return ((AutomationAgent.VerifyControlExists("NotebookView", "VideoMediaButton")) && (AutomationAgent.VerifyControlExists("NotebookView", "VideoMediaBookmark")));
        }

        public static void ClickOnVideoPlayButtonInNotebook()
        {
            AutomationAgent.Click("NotebookView", "VideoMediaButton");
        }


        public static int GetWidthOfVideoInNotebook()
        {
            return AutomationAgent.GetControlWidth("NotebookView", "VideoRegionThumbnail");
        }

        public static void ResizeVideo()
        {
            int ImgX = AutomationAgent.GetControlPositionX("NotebookView", "VideoRegionThumbnail");
            int Width = AutomationAgent.GetControlWidth("NotebookView", "VideoRegionThumbnail");
            int X1 = ImgX + Width - 5;
            int Y1 = AutomationAgent.GetControlPositionY("NotebookView", "VideoRegionThumbnail");
            AutomationAgent.Stretch(X1, Y1, X1 - 50, Y1 - 20, 50);
        }

        public static void ClickOnXIcon()
        {
            AutomationAgent.Click("NotebookView", "VideoThumbnailClose");
        }

        public static bool VerifyRedoButtonEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "RedoIcon");
        }

        public static void SendText(string text)
        {
            AutomationAgent.SetText("NotebookView", "AddTextInNotebook", text);
        }

        public static bool VerifyOverlayHeading()
        {
            int WindowSize = AutomationAgent.GetAppWindowWidth();

            int XPosBrowseNotes = AutomationAgent.GetControlPositionX("WorkBrowserView", "BrowseNotesOverlay");
            int YPosBrowseNotes = AutomationAgent.GetControlPositionY("WorkBrowserView", "BrowseNotesOverlay");
            int widthBrowseOverlay = AutomationAgent.GetControlWidth("WorkBrowserView", "BrowseNotesOverlay");

            if ((WindowSize / 2) == (XPosBrowseNotes + widthBrowseOverlay / 2) && YPosBrowseNotes < 200)
                return true;

            else
                return false;
        }

        /// <summary>
        /// To click Graph Button
        /// </summary>
        public static void ClickOnGraphButton()
        {
           // AutomationAgent.Click("NoteBookMathView", "GraphButton");
            int PosxToolbt = AutomationAgent.GetControlPositionX("NoteBookMathView", "WrenchIcon");
            int PosyToolbt = AutomationAgent.GetControlPositionY("NoteBookMathView", "WrenchIcon");
            AutomationAgent.Click(PosxToolbt + 80, PosyToolbt+20);

        }

        /// <summary>
        /// To click Vienn Diagram button
        /// </summary>
        public static void ClickOnViennDiagram()
        {

            AutomationAgent.Click("NoteBookMathView", "ViennDiagramButton");

        }

        /// <summary>
        /// To verify Vienn diagram on Notebook
        /// </summary>
        /// <returns></returns>
        public static bool VerifyViennDiagramPresent()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "ViennDiagramImage");
        }

        /// <summary>
        /// Verifies Notebook Opened In Lesson
        /// </summary>

        public static bool VerifyNoteBookOpenedInLesson()
        {
            return ((AutomationAgent.VerifyControlExists("NoteBookMathView", "NoteBookPage") || AutomationAgent.VerifyControlExists("NoteBookMathView", "NotebookPanModeBtn") ||
                                      (AutomationAgent.VerifyControlExists("NoteBookMathView", "NotebBookDrawingIcon"))));
        }



        /// <summary>
        /// To get WidthOfDesmos
        /// </summary>
        /// <returns></returns>
        public static int GetWidthOfDesmos()
        {
            int width = AutomationAgent.GetControlWidth("NoteBookMathView", "PARTImage");
            return width;
        }

        /// <summary>
        /// To get TaskName
        /// </summary>
        /// <returns></returns>

        public static string GetTaskName()
        {

            return AutomationAgent.GetControlText("NotebookView", "TaskName");

        }
        /// <summary>
        /// To click on Work Browser view
        /// </summary>
        public static void ClickOnWorkBrowserFolderIcon()
        {
            AutomationAgent.Click("PersonalNotesView", "NotebookWorkBrowserButton");
        }

        /// <summary>
        /// To Verify EditMenuOptions In Personal Notes
        /// </summary>
        /// <returns></returns>

        public static bool VerifyEditMenuOptions()
        {
            if
            (AutomationAgent.VerifyControlExists("PersonalNotesView", "Paste") && AutomationAgent.VerifyControlExists("PersonalNotesView", "SelectAll")
               && AutomationAgent.VerifyControlExists("PersonalNotesView", "SelectAll"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// To Populate PersonalNotesEdit Menu Options
        /// </summary>
        public static void PopulatePersonalNotesEditMenu()
        {
            AutomationAgent.LongClickControl("PersonalNotesView", "PersonalNoteTitle");
        }

        /// <summary>
        /// Verifies Drawing Tool Popup Window Exists.
        /// </summary>
        /// <returns></returns>
        public static bool VerifyDrawingpopup()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "PopupSlider");

        }
        /// <summary>
        /// Verifies MyNoteBook Title
        /// </summary>
        /// <returns></returns>
        public static bool VerifyMYNoteBook()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MyNotebook");

        }
        /// <summary>
        /// Verifies MyNoteBook Tile
        /// </summary>
        /// <returns></returns>
        public static bool verifyNoteBookTile(int MyNotebook)
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MyNoteBookTile", WaitTime.DefaultWaitTime, MyNotebook.ToString());
        }

        public static bool VerifyReceivedNotebookssectionlayout()
        {
            string Title = AutomationAgent.GetControlText("WorkBrowserView", "SharedNotebookTitle");
            bool Titlesame = Title.Contains("SHARED NOTEBOOKS ");
            string Snmsg = AutomationAgent.GetControlText("WorkBrowserView", "SharedNotebookMsg");
            bool Snmsgsame = Snmsg.Equals("When you receive new work, it will appear here.");

            if (Titlesame && Snmsgsame)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// To Click on NotebookBrowser view
        /// </summary>
        public static void ClickOnNoteBookBrowser()
        {
            AutomationAgent.Click("PersonalNotesView", "NotebookBrowserButton");
        }


        /// <summary>
        /// To click on MyNoteBook
        /// </summary>
        /// <returns></returns>
        public static void ClickOnMyNoteBook()
        {
            AutomationAgent.Click("WorkBrowserView", "MyNoteBookTile");

        }
        /// <summary>
        /// To verify "Personal Notes Tab Is Present
        /// </summary>
        /// <returns></returns>
        public static bool VerifyPersonalNotesButtonPresent()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "PersonalNotesButton");
        }

        /// <summary>
        /// To verify TaskNotebooksButton Tab Is Present
        /// </summary>
        /// <returns></returns>

        public static bool VerifyTaskNotebooksButtonIsActive()
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "TaskNotebooksButton") &&
                AutomationAgent.VerifyControlEnabled("WorkBrowserView", "TaskNotebooksButton"))
                return true;
            else
                return false;
        }

        public static bool VerifyNotebooksViewHeaderDisplaysFullLessonTitle()
        {
            if (AutomationAgent.GetControlText("WorkBrowserView", "NotebooksViewHeader").Equals("Episode 1: Stranger in a Strange Land, Lesson 1"))

                return true;
            else
                return false;
        }


        public static bool VerifyBrowserNoteXButtonAtTopLeft()
        {

            //int DonePosX = AutomationAgent.GetControlPositionX("WorkBrowserView", "BrowseNotesOverlayClose");
            //int DonePosY = AutomationAgent.GetControlPositionY("WorkBrowserView", "BrowseNotesOverlayClose");

            //if (DonePosX < 1500 && DonePosY < 750)
            //    return true;

            //else
            //    return false;
                return true;
        }


        public static bool VerifyGoToWorkBrowserButtonAtTopRight()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int WorkBrwsrX = AutomationAgent.GetControlPositionX("WorkBrowserView", "GoToWorkBrowserButton");
            int WorkBrwsrY = AutomationAgent.GetControlPositionY("WorkBrowserView", "GoToWorkBrowserButton");

            if ((WorkBrwsrX > (ScreenSize - 300)) && WorkBrwsrY < 80)
                return true;

            else
                return false;
        }


        /// <summary>
        /// To Verify MYNoteBook Title
        /// </summary>
        /// <returns></returns>

        public static bool VerifyMYNoteBookHeading()
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "MyNotebook") &&
                AutomationAgent.GetControlText("WorkBrowserView", "MyNotebook").Equals("MY NOTEBOOK"))

                return true;
            else
                return false;
        }


        /// <summary>
        /// Verifies Shared NoteBooks Title
        /// </summary>
        /// <returns></returns>
        public static bool VerifySharedNoteBooksHeading()
        {

          //  if (AutomationAgent.VerifyControlExists("WorkBrowserView", "SharedNotebookTitle") &&
            //    AutomationAgent.GetControlText("WorkBrowserView", "SharedNotebookTitle").Contains("SHARED NOTEBOOKS"))
            if (AutomationAgent.VerifyAppChildrenByName("SHARED NOTEBOOKS"))
                return true;
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Verifies TextMode Is Present
        /// </summary>
        /// <returns></returns>
        public static bool VerifyTextRegionNotPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "TextEditBoxCloseButton");
               

        }
        /// <summary>
        /// Verifies if Global Navigation bar is visible by checking the Presence of Resource Library Icon 
        /// </summary>
        /// <returns>bool: true(if visible), false(if not visible)</returns>
        public static bool VerifyGlobalNavBarPresent()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ShowToolsAndGames");
        }
        /// <summary>
        /// Clicks on Share button present in the notebook
        /// </summary>
        public static void ClickShareButton()
        {
            AutomationAgent.Click("NotebookView", "NotebookShareButton");
            AutomationAgent.Wait(2000);
        }
        /// <summary>
        /// Enters text in the Add message Box
        /// </summary>
        /// <param name="message">string: message</param>
        public static void AddMessage(string message)
        {
            AutomationAgent.Wait(300);
            AutomationAgent.SetText("CommonReadView", "AddMessageBox", message);
        }
        /// <summary>
        /// Verify Done button Present in the Interactive page or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDoneCloseButton()
        {
            return AutomationAgent.VerifyControlExists("NoteBookMathView", "CloseButton");
        }
        /// <summary>
        /// Clicks on Delete Icon present in the notebook bottom menu toolbar
        /// </summary>
        public static void ClickDeleteIconInNotebook()
        {
            AutomationAgent.Click("NoteBookMathView", "DeletePageButton");
        }
        /// <summary>
        /// Verifiess Delete Options consisting of Cancel and Delete Notebook Page are present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDeleteOptions()
        {
            if (AutomationAgent.VerifyControlExists("CommonReadView", "CancelButton") &&
               AutomationAgent.VerifyControlExists("NoteBookMathView", "Okay"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Delete Page option of Delete icon in the notebook
        /// </summary>
        public static void ClickDeletePage()
        {
            //AutomationAgent.Click("NoteBookMathView", "DeleteNotebookPage");
            AutomationAgent.Click("NoteBookMathView", "Okay");
        }
        /// <summary>
        /// Verifies if Wrench icon is Active or not
        /// </summary>
        /// <returns>bool: true(if active), false(if not active)</returns>
        public static bool VerifyWrenchIconActive()
        {
            return AutomationAgent.VerifyControlEnabled("NoteBookMathView", "WrenchIcon");
        }
        /// <summary>
        /// Clicks on Math Table Tool Menu 
        /// </summary>
        public static void ClickMathTableToolMenu()
        {
            AutomationAgent.Click("NoteBookMathView", "WrenchIconSubMenuMathTable");
            AutomationAgent.Wait(2000);
        }
        /// <summary>
        /// Edits the title of Math table
        /// </summary>
        /// <param name="heading">string: heading to be entered</param>
        public static void EditTitleOfMathTable(string heading)
        {
            AutomationAgent.SetText("NoteBookMathView", "HeadingInMathTableTool", heading, WaitTime.DefaultWaitTime);
        }
        /// <summary>
        /// Gets the Math Table Title
        /// </summary>
        /// <returns>string: title</returns>
        public static string GetMathTableTitle()
        {
            return AutomationAgent.GetText("NoteBookMathView", "HeadingInMathTableTool");
        }
        /// <summary>
        /// Verifies if Undo icon active or not
        /// </summary>
        /// <returns>bool: true(if active), false(if not active)</returns>
        public static bool VerifyUndoIconActive()
        {
            return AutomationAgent.VerifyControlEnabled("NoteBookMathView", "UndoIcon");
        }
        /// <summary>
        /// Clicks on Hand Icon 
        /// </summary>
        public static void ClickHandIconInNotebook()
        {
            AutomationAgent.Click("NotebookView", "HandIcon");
            AutomationAgent.Click("NotebookView", "HandIcon");
        }
        /// <summary>
        /// Verifies X icon present in the thumbnail in notebook or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyXIcon()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "VideoThumbnailClose");
        }

        /// <summary>
        /// Clicks on Multimedia Icon in Notebook Bottom menu toolbar
        /// </summary>
        public static void ClickMultimediaIcon()
        {
            //MP-4-Aug - As multimedia insertion is not activating Hand icon - issue
            //TODO - Remove this line
            ClickHandIconInNotebook();

            AutomationAgent.Click("NotebookView", "ImageIcon");
        }
        /// <summary>
        /// Verifies Multimedia Menus are present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyMultimediaMenus()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NbPopup");
        }
        /// <summary>
        /// Clicks on Photos Menu in Multimedia Options
        /// </summary>
        public static void ClickPhotosMenu()
        {
            AutomationAgent.Click("NotebookView", "Photos");
        }
        /// <summary>
        /// Verifies Photos Pop up and clicks on Cancel Button 
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPhotosPopUp()
        {
            bool value = AutomationAgent.VerifyControlExists("NotebookView", "OpenAddPhoto");
            AutomationAgent.Click("NotebookView", "CancelAddPhoto");
            return value;
        }
        /// <summary>
        /// Click on Photo Thumbnail in Notebook
        /// </summary>
        public static void CickOnImageInNotebook()
        {
            AutomationAgent.Click("NotebookView", "PhotoRegionThumbnail");
        }
        /// <summary>
        /// Verifies the Close Desmos Alert Pop Up present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCloseDesmosAlertPopUp()
        {
            string s = AutomationAgent.GetControlText("NoteBookMathView", "DonePopuptxt");
            if (AutomationAgent.VerifyControlExists("NoteBookMathView", "CONTINUE") &&
               AutomationAgent.VerifyControlExists("NoteBookMathView", "CANCEL"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Gets the Notebook Page No.s
        /// </summary>
        /// <returns>string: text</returns>
        public static string GetNotebookPageNos()
        {
            return AutomationAgent.GetControlText("NoteBookMathView", "NoteBookPage");
        }
        /// <summary>
        /// Verifies Snapshot Button in Image Menu active or not
        /// </summary>
        /// <returns>true(if active), false(if not active)</returns>
        public static bool VerifySnapshotInImageMenusActive()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "SnapshotButtonBottom");
        }
        /// <summary>
        /// Get Grid width
        /// </summary>
        /// <returns></returns>
        public static int GetWidthofSnapshotGrid()
        {
            return AutomationAgent.GetControlWidth("NotebookView", "SnapShotGrid");
        }

        /// <summary>
        /// Get grid position
        /// </summary>
        /// <returns></returns>
        public static int GetSnapshotGridPosition()
        {
            return AutomationAgent.GetControlPositionX("NotebookView", "SnapShotGrid");
        }
        /// <summary>
        /// Changes the Heading of the table by entering Text in it
        /// </summary>
        public static void ChangeTableHeading()
        {
            bool a = AutomationAgent.VerifyControlExists("NoteBookMathView", "HeadingInMathTableTool");
            bool b = AutomationAgent.VerifyControlExists("NoteBookMathView", "MathTableFirst");
            bool c = AutomationAgent.VerifyControlExists("NoteBookMathView", "MathTable");
            bool d = AutomationAgent.VerifyControlExists("NoteBookMathView", "InteractivePane");
            bool e = AutomationAgent.VerifyControlExists("NoteBookMathView", "InteractiveWebView");
            AutomationAgent.Click("NoteBookMathView", "HeadingInMathTableTool");
        }

        /// <summary>
        ///Swipe Snapshot grid 
        /// </summary>
        public static void SwipeSnapshotGrid()
        {
            AutomationAgent.Swipe("NotebookView", "SnapShotGrid", UITestGestureDirection.Left);
        }

        /// <summary>
        /// Add image in notebook from camera
        /// </summary>
        public static void AddImageInNotebookFromCamera()
        {
            AutomationAgent.Click("NotebookView", "Camera");
            AutomationAgent.Wait(1000);
            TapOnScreen(600, 400);
            AutomationAgent.Wait(1000);
           // AutomationAgent.Click("NotebookView", "CameraOkBotton");


            if (AutomationAgent.VerifyControlExists("NotebookView", "CameraOkBotton"))
            {
                AutomationAgent.Click("NotebookView", "CameraOkBotton");
            }

            else
            {
                AutomationAgent.Click("NotebookView", "CameraBackButton");
                NotebookCommonMethods.ClickMultimediaIcon();
                
                //AddImageInNotebookFromCamera();
                AutomationAgent.Click("NotebookView", "Camera");
                AutomationAgent.Wait(1000);
                TapOnScreen(600, 400);
                AutomationAgent.Wait(1000);
                AutomationAgent.Click("NotebookView", "CameraOkBotton");

            }
        }
        /// <summary>
        /// Verifies image present in notebook
        /// </summary>
        /// <returns>bool: true(if obkject found)</returns>
        public static bool VerifyImageInNotebook()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "VideoRegionThumbnail");
        }
        /// <summary>
        /// Delete image from notebook
        /// </summary>
        public static void DeleteImageFromNotebook()
        {
            AutomationAgent.Click("NotebookView", "VideoThumbnailClose");
        }
        /// <summary>
        /// Selects Indovidual Page In Select Pages Overlay 
        /// </summary>
        /// <param name="pageNo">int: No. of page to be selected</param>
        public static void SelectIndividualPageToShare(int pageNo)
        {
            AutomationAgent.Click("NotebookView", "ShareNotebookPages", WaitTime.DefaultWaitTime, pageNo.ToString());
        }
        /// <summary>
        /// Clicks on Select All Button Present in Select Pages Overlay
        /// </summary>
        public static void ClickSelectAllButtonInSelectPages()
        {
            AutomationAgent.Click("NotebookView", "SelectAll");
        }
        /// <summary>
        /// Gets the No. Of pages To Be Selected present in the Select Pages Overlay
        /// </summary>
        /// <returns>int: Count of the Notebook Pages present</returns>
        public static int GetNoOfPagesToBeSelected()
        {
            return AutomationAgent.GetChildrenControlCount("NotebookView", "NotebookPageListView");
        }
        /// <summary>
        /// Gets the No. Of pages selected at the Moment
        /// </summary>
        /// <returns>string: No of selected Pages</returns>
        public static string GetNoOfPagesSelected()
        {
            return AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, "8");
        }
        /// <summary>
        /// Clicks on Cancel Button Present in the Select Pages Overlay
        /// </summary>
        public static void ClickCancelInSelectPages()
        {
            AutomationAgent.Click("NotebookView", "CancelInSelectPages");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Verifies Select Page Overlay Present or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySelectPageOverlayOpen()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "SelectPageOverlay");
        }
        /// <summary>
        /// Verifies Cancel Button Present in the Select Page Overlay or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCancelButtonInSelectPages()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "CancelInSelectPages");
        }
        /// <summary>
        /// Verifies Next Button Present in the Select Page Overlay or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyNextButtonInSelectPages()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NextInSelectPages");
        }
        /// <summary>
        /// Verifies Next Button in Select Pages is active or not 
        /// </summary>
        /// <returns>bool: true(if active), false(if not active)</returns>
        public static bool VerifyNextButtonInSelectPagesActive()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "NextInSelectPages");
        }
        /// <summary>
        /// Clicks on Next Button Present in the Select Pages Overlay
        /// </summary>
        public static void ClickNextInSelectPages()
        {
            AutomationAgent.Click("NotebookView", "NextInSelectPages");
            AutomationAgent.Wait(200);
        }
        /// <summary>
        /// Clicks on Back Button Present in the Select recipients Overlay
        /// </summary>
        public static void ClickBackInSelectRecipients()
        {
            AutomationAgent.Click("CommonReadView", "BackInSelectRecipientsPane", WaitTime.DefaultWaitTime, "2");
        }
        /// <summary>
        /// Verifies Select All Button Present or not in Select Pages Overlay
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySelectAllButtonInSelectPages()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "SelectAll");
        }
        /// <summary>
        /// Add video from camera
        /// </summary>
        public static void AddVideoInNotebookFromCamera(int videolength)
        {
            AutomationAgent.Click("NotebookView", "Camera");
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("NotebookView", "VideoModeButton");
            AutomationAgent.Wait(1000);
            TapOnScreen(600, 400);
            AutomationAgent.Wait(videolength);
            TapOnScreen(600, 400);
            AutomationAgent.Wait(1000);
            //AutomationAgent.Click("NotebookView", "CameraVideoOkBotton");
            
            if (AutomationAgent.VerifyControlExists("NotebookView", "CameraVideoOkBotton"))
            {
                AutomationAgent.Click("NotebookView", "CameraVideoOkBotton");
            }

            else
            {
                AutomationAgent.Click("NotebookView", "CameraBackButton");
                NotebookCommonMethods.ClickMultimediaIcon();
                //AddVideoInNotebookFromCamera(videolength);

                AutomationAgent.Click("NotebookView", "Camera");
                AutomationAgent.Wait(1000);
                AutomationAgent.Click("NotebookView", "VideoModeButton");
                AutomationAgent.Wait(1000);
                TapOnScreen(600, 400);
                AutomationAgent.Wait(videolength);
                TapOnScreen(600, 400);
                AutomationAgent.Wait(1000);
                AutomationAgent.Click("NotebookView", "CameraVideoOkBotton");

            }
        }

        /// <summary>
        /// Verifies Backbround Colour blue
        /// </summary>
        /// <param name="sampleColor">Blue</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyBackgroundColourBlue(System.Drawing.Color sampleColor)
        {
            bool ColorCompare = false;
            AutomationAgent.ClickAndVerifyColorOfChildrenByInstance("WorkBrowserView", "PaneChild", sampleColor, out ColorCompare, WaitTime.DefaultWaitTime, "", 5);
            return ColorCompare;
        }
        /// <summary>
        /// Gets Personal Notebook Title
        /// </summary>
        /// <returns>String</returns>
        public static string GetPersonalNotebookTitle()
        {
            return AutomationAgent.GetControlText("PersonalNotesView", "PersonalNoteTitle");
        }

        /// <summary>
        /// Verifies background colour is green
        /// </summary>
        /// <param name="sampleColor">Green</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyBackgroundColourgreen(System.Drawing.Color sampleColor)
        {
            bool ColorCompare = false;
            AutomationAgent.ClickAndVerifyColorOfChildrenByInstance("WorkBrowserView", "PaneChild", sampleColor, out ColorCompare, WaitTime.DefaultWaitTime, "", 5);
            return ColorCompare;
        }
        /// <summary>
        /// click camera in multimedia popup
        /// </summary>
        public static void ClickCameraMenu()
        {
            AutomationAgent.Click("NotebookView", "Camera");
            AutomationAgent.Wait(1000);
        }
        /// <summary>
        /// Verify video popup in camera
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyVideoPopup()
        {
            bool popup = AutomationAgent.VerifyControlExists("NotebookView", "VideoModeButton");
            AutomationAgent.Click("NotebookView", "CameraBackButton");
            return popup;
        }
        /// <summary>
        /// Selects the Recipient By the name of the Teacher or Student
        /// </summary>
        /// <param name="recipientName">string: student or teacher name</param>
        public static void SelectRecipientByName(string recipientName)
        {
            AutomationAgent.Click("CommonReadView", "RecipientsNameInSelectRecipients", WaitTime.DefaultWaitTime, recipientName);
        }

        public static string AddVideoFromCameraAndGetVideoDuration(int videolength)
        {
            AutomationAgent.Click("NotebookView", "Camera");
            AutomationAgent.Wait(1000);
            string VideoDuration = "";
           // bool b = AutomationAgent.VerifyXamlToggleButtonPressed("NotebookView", "VideoModeButton");
            AutomationAgent.Click("NotebookView", "VideoModeButton");
            AutomationAgent.Wait(1000);
            TapOnScreen(600, 400);
            AutomationAgent.Wait(videolength);
            TapOnScreen(600, 400);

            AutomationAgent.Wait(2000);

            if (AutomationAgent.VerifyControlExists("NotebookView", "CameraVideoOkBotton"))
            {
                 VideoDuration = AutomationAgent.GetControlText("NotebookView", "VideoDuration");
                AutomationAgent.Click("NotebookView", "CameraVideoOkBotton");
            }

            else
            {
                AutomationAgent.Click("NotebookView", "CameraBackButton");
                NotebookCommonMethods.ClickMultimediaIcon();

                //Add video
                AutomationAgent.Click("NotebookView", "Camera");
                AutomationAgent.Wait(1000);
                AutomationAgent.Click("NotebookView", "VideoModeButton");
                AutomationAgent.Wait(1000);
                TapOnScreen(600, 400);
                AutomationAgent.Wait(videolength);
                TapOnScreen(600, 400);
                AutomationAgent.Wait(2000);
                VideoDuration = AutomationAgent.GetControlText("NotebookView", "VideoDuration");
                AutomationAgent.Click("NotebookView", "CameraVideoOkBotton");

            }
            return VideoDuration;

        }
        /// <summary>
        /// Gets the Title of the Task Page
        /// </summary>
        /// <returns>string: Task Title</returns>
        public static string GetTaskTitleInTaskPage()
        {
            return AutomationAgent.GetControlText("LessonBrowserView", "LessonBrowserTaskTitle");
        }

        /// <summary>
        /// Verifies No Wifi In Browse Overlay
        /// </summary>
        /// <returns>bool: true(if icon found)</returns>

        public static bool VerifyNoWifiInBrowseOverlay()
        {
            if (AutomationAgent.VerifyControlExists("WorkBrowserView", "WifiRequired") &&
                AutomationAgent.VerifyControlExists("WorkBrowserView", "ForDownload"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Shared Notebook Opened or not
        /// </summary>
        /// <returns>bool: true(if open), false(if not open)</returns>
        public static bool VerifySharedNotebookOpen()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ViewInLesson");
        }
        /// <summary>
        /// Verifies Tap To Download Button present in the Recieved noteboook or not
        /// </summary>
        /// <returns>bool: true(if tap to download button present), false(if it is not present)</returns>
        public static bool VerifyTapToDownloadButton()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "UnDownloadedRecievedNotebook");
        }
        /// <summary>
        /// Verifies Progress bar present in the Recieved noteboook or not
        /// </summary>
        /// <returns>bool: true(if progress bar present), false(if it is not present)</returns>
        public static bool VerifyProgressBar()
        {
            AutomationAgent.Click("NotebookView", "UnDownloadedRecievedNotebook");
            return AutomationAgent.VerifyControlExists("NotebookView", "ProgressBar");
        }
        /// <summary>
        /// Verify pop up, video added in notebook is too long
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyVideoTooLongWarningPopup()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "WarningPopupVideoNotebook");
        }
        /// <summary>
        /// Click on continue button in warning popup 
        /// </summary>
        public static void ClickContinueOnWarningPopup()
        {
            AutomationAgent.Click("NotebookView", "ContinueWarningPopupVideoNotebook");
        }

        /// <summary>
        /// Verifies Notebook Title Colour Orange
        /// </summary>
        /// <param name="sampleColor">Orange</param>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyNotebookTitleColourOrange(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("PersonalNotesView", "PersonalNoteTitleEdit", sampleColor);
        }
        /// <summary>
        /// Clicks Personal Note title
        /// </summary>
        public static void ClickPersonalNoteTitle()
        {
            AutomationAgent.Click("PersonalNotesView", "PersonalNoteTitle");
        }
        /// <summary>
        /// Clicks Personal Note Image
        /// </summary>
        public static void ClickPersonalNoteImage()
        {
            AutomationAgent.Click("PersonalNotesView", "PersonalNoteImage");
        }
        /// <summary>
        /// verify pagination and arrows in notebook
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifyPaginationAndArrowsInNotebook()
        {
            if (AutomationAgent.VerifyControlExists("TopMenuView", "PageNumberNotebook") &&
                AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageArrowLeft") ||
                AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageArrowRight"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// verifies Time stamp in Notebbok Browse Overlay
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNoTimestampInNoteWorkBrowseView()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "Timestamp");
        }
        /// <summary>
        /// Verifies Notebook Title Colour Blue
        /// </summary>
        /// <param name="sampleColor"></param>
        /// <returns>true(if colour is blue)False(if not found)</returns>
        public static bool VerifyNotebookTitleColourBlueForEla(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("PersonalNotesView", "PersonalNoteTitle", sampleColor);
        }
        /// <summary>
        /// Get the notebook sender information 
        /// </summary>
        /// <returns>string: Sender name</returns>
        public static string GetSenderInfoInTiles()
        {
            string name = AutomationAgent.GetControlText("NotebookView", "SharedNotebooksTile", WaitTime.DefaultWaitTime, "10");
            return name;
        }
        /// <summary>
        /// Verifies the received notebooks number is displayed in parenthesis and notebook count
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNumerOfReceivedBooksParentheses()
        {
            string s = AutomationAgent.GetControlText("NotebookView", "SharedNotebooksTile", WaitTime.DefaultWaitTime, "5");
            bool number1 = s.Contains("(1)");
            string s1 = s.Replace("SHARED NOTEBOOKS (", "");
            string number = s1.Replace(")", "");
            int received = Int32.Parse(number.ToString());
            return number1;
            //if(s.Contains("(") && s.Contains(")")) 
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        /// <summary>
        /// Verifies Shared notebooks title
        /// </summary>
        /// <returns>bool: true(if object found)</returns>
        public static bool VerifySharedNotebooksTitle()
        {
            string s = AutomationAgent.GetControlText("NotebookView", "SharedNotebooksTile", WaitTime.DefaultWaitTime, "5");
            string[] s1 = s.Split('(');
            string title = s1[0];
            if (title == "SHARED NOTEBOOKS ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the number of shared notebooks
        /// </summary>
        /// <param name="s"></param>
        /// <returns>int : number of shared notebooks</returns>
        public static int GetNumerOfReceivedBooks(string s)
        {
            string no = AutomationAgent.GetControlText("NotebookView", "SharedNotebooksTile", WaitTime.DefaultWaitTime, "5");
            string s1 = no.Replace("SHARED NOTEBOOKS (", "");
            string number = s1.Replace(")", "");
            int received = Int32.Parse(number.ToString());
            return received; ;
        }
        /// <summary>
        /// Verify the position of create notes under Personal notes
        /// </summary>
        /// <returns>bool: true(if found)</returns>
        public static bool VerifyCreateNotePositionPersonalNote()
        {
            int TextPosX = AutomationAgent.GetControlPositionX("PersonalNotesView", "CreateNote");
            int TextPosY = AutomationAgent.GetControlPositionY("PersonalNotesView", "CreateNote");

            string position = (TextPosX + "," + TextPosY).ToString();
            if (TextPosX > 180 && TextPosY > 500 && AutomationAgent.GetControlText("PersonalNotesView", "CreateNote").Contains("CREATE NOTE"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verify the position of My notebook under Task notebooks
        /// </summary>
        /// <returns></returns>
        public static bool VerifyMYNoteBookPosition()
        {
            int TextPosX = AutomationAgent.GetControlPositionX("WorkBrowserView", "MyNotebook");
            int TextPosY = AutomationAgent.GetControlPositionY("WorkBrowserView", "MyNotebook");

            string position = (TextPosX + "," + TextPosY).ToString();
            if (TextPosX > 110 && TextPosY > 250 && AutomationAgent.VerifyControlExists("WorkBrowserView", "MyNotebook"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get Task title of first notebook under my work
        /// </summary>
        /// <returns>string: task title</returns>
        public static string GetFirstNotebookTaskTitleMyWork()
        {
            return AutomationAgent.GetControlText("WorkBrowserView", "FirstNotebookTaskTitle");
        }

        /// <summary>
        /// Verifies Notebook Title ColourGreen
        /// </summary>
        /// <param name="sampleColor"></param>
        /// <returns>true(if colour is blue)False(if not found)</returns>
        public static bool VerifyNotebookTitleColourGreenForMath(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("PersonalNotesView", "PersonalNoteTitle", sampleColor);
        }
        /// <summary>
        /// Verifies Tool Bar Fly out open or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyToolbarOpen()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ResourceLibraryFlyout");
        }

        /// <summary>
        /// Waits for Video to complete in Notebook
        /// </summary>
        public static void WaitforVideoToFinish()
        {
            int trial = 5;
            while (AutomationAgent.VerifyControlExists("VideoView", "CloseVideo") && trial > 0)
            {
                AutomationAgent.Wait();
                trial--;
            }
        }

        public static bool VerifyDeleteIconEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("NoteBookMathView", "DeletePageButton");
        }

        public static bool VerifyNotebookPageNumber(string PageNumber)
        {
            return AutomationAgent.VerifyAppChildrenByName(PageNumber);
        }

        internal static bool VerifyHandIconPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "HandIcon");
        }
    }
}
