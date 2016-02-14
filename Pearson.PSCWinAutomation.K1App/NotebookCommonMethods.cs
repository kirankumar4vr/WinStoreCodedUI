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


namespace Pearson.PSCWinAutomationFramework._K1App
{
    /// <summary>
    /// Summary description for NotebookCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class NotebookCommonMethods
    {
        public NotebookCommonMethods()
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

        public static void ClickBackButtonNotebook()
        {
            AutomationAgent.Click("NotebookView", "NotebookBackButton");
            AutomationAgent.Wait();
        }

        public static bool VerifyHandIconEnabled()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookHandIcon");

        }
        public static bool VerifySnapshotisAvailableInNotebook()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail");
        }

        public static void ResizeImageInNoteBook()
        {
            int ImgX = AutomationAgent.GetControlPositionX("NotebookView", "NotebookSnapshotThumbnail");
            int Width = AutomationAgent.GetControlWidth("NotebookView", "NotebookSnapshotThumbnail");
            int X1 = ImgX + Width - 5;
            int Y1 = AutomationAgent.GetControlPositionY("NotebookView", "NotebookSnapshotThumbnail");
            AutomationAgent.Stretch(X1, Y1, X1 - 50, Y1 - 20, 50);
        }

        public static int GetImageThumbnailWidth()
        {
            return AutomationAgent.GetControlWidth("NotebookView", "NotebookSnapshotThumbnail");
        }

        public static void ClickImageThumbnailCloseButton()
        {
            AutomationAgent.Click("NotebookView", "NotebookSnapshotThumbnailClose");
        }

        public static void ClickNotebookTextIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookTextIcon");
        }

        public static void AddTextToNotebookTextBox(string text)
        {
            ClickNotebookTextIcon();
            AutomationAgent.Click(600, 400);
            AutomationAgent.SendText(text);
            eReaderCommonMethods.TapOnEReaderScreen();
        }

        public static void ClickImageThumbnailInNotebook()
        {
            AutomationAgent.Click("NotebookView", "NotebookSnapshotThumbnail");
        }

        public static void ClickCrayonToolIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookCrayonIcon");
        }

        public static void ClickBrushToolIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookToolBrushIcon");
        }

        public static void ClickMarkerToolIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookToolMarkerIcon");
        }

        public static void ClickStampToolIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookToolStampIcon");
        }

        public static void ClickEraserToolIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookToolEraseIcon");
        }

        public static bool VerifyStampIconEnabled()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolStampIcon");
        }

        public static void ClickClearAllButton()
        {
            AutomationAgent.Click("NotebookView", "NotebookClearAllIcon");
        }

        public static void ClickNotebookPopupAccept()
        {
            AutomationAgent.Click("NotebookView", "NotebookPopupAccept");
        }

        public static void ClickNotebookPopupCancel()
        {
            AutomationAgent.Click("NotebookView", "NotebookPopupCancel");
        }

        public static void ClickToOpenNotebookCanvasPage()
        {
            AutomationAgent.Click("NotebookView", "NotebookPageImage");
            AutomationAgent.Wait();
        }

        public static string GetCurrentNotebookPageNumber(int pageNumTextInstance)
        {
            //int pageno;

            //for (pageno = 1;pageno<20;pageno++)
            //{
            //    if (AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageNumber",WaitTime.DefaultWaitTime, pageno.ToString()))
            //        break;
            //}

            return AutomationAgent.GetControlText("NotebookView", "NotebookPageNumber", WaitTime.DefaultWaitTime, pageNumTextInstance.ToString());
        }

        public static void ClickAddPageButtonNotebookCanvas()
        {
            AutomationAgent.Click("NotebookView", "NotebookAddPageIcon");
        }

        public static void ClickNotebookPreviousPageButton()
        {
            AutomationAgent.Click("NotebookView", "NotebookPreviousButton");
        }

        public static bool VerifyTextInNotebook(string text)
        {
            string nbText = AutomationAgent.GetText("NotebookView", "NotebookTextBox");

            return nbText.Contains(text);
        }

        public static void ClickUndoIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookUndoIcon");
        }

        public static bool VerifyNotebookBackgroundIsNotPlain()
        {
            //return AutomationAgent.VerifyControlExists("NotebookView", "NotebookBackgroundImageNotPlainBackgroundInPane");
            int childcellscount = AutomationAgent.GetChildrenControlCount("NotebookView", "NotebookPane");
            if (childcellscount > 10)
                return true;

            else
                return false;

        }

        public static void ChangeNotebookBackgroundGrid()
        {
            ClickNotebookBackgroundSelectionIcon();

            AutomationAgent.Click("NotebookView", "NotebookBackgroundGrid");
        }

        public static void ClickNotebookBackgroundSelectionIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookPageBackgroundSelectionIcon");
        }

        public static bool VerifyTextBoxInNotebook()
        {
            AutomationAgent.Wait(1000);
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookTextBox");
        }

        public static void ClickXCrossIconTextBox()
        {
            ClickImageThumbnailCloseButton();
        }

        public static bool VerifyXCrossIconTextBox()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnailClose");
        }

        public static void EditTextInNotebookTextBox(string text)
        {
            AutomationAgent.Click("NotebookView", "NotebookTextBox");
            AutomationAgent.SendText(text);
            eReaderCommonMethods.TapOnEReaderScreen();
        }

        public static bool VerifyNotebookCanvasOpenedAndBasicToolbars()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolBrushIcon") &&
                AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolMarkerIcon") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolStampIcon") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolEraseIcon") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookClearAllIcon") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookUndoIcon") &&
                 AutomationAgent.VerifyControlExists("NotebookView", "NotebookPageBackgroundSelectionIcon");
        }

        public static bool VerifyAddPageButton()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookAddPageIcon");
        }

        public static bool VerifyAddPageButtonNotebookScreen()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookAddPageIconOnNotebookScreen");
        }

        public static void ClickNotebookNextPageButton()
        {
            AutomationAgent.Click("NotebookView", "NotebookNextButton");
        }

        public static bool VerifyNotebookNextPageButton()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookNextButton");
        }

        public static bool VerifyNotebookPreviousPageButton()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookPreviousButton");
        }

        public static void NavigateToLastNotebookPage()
        {
            while (VerifyNotebookNextPageButton())
            {
                ClickNotebookNextPageButton();
            }
        }

        public static void NavigateToFirstNotebookPage()
        {
            while (VerifyNotebookPreviousPageButton())
            {
                ClickNotebookPreviousPageButton();
            }
        }

        public static void ClickNotebookHandIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookHandIcon");
        }

        public static void ClickNotebookTextBoxPane()
        {
            AutomationAgent.Click("NotebookView", "NotebookTextBox");
        }

        public static void ClickMathTools()
        {
            AutomationAgent.Click("NotebookView", "NotebookMathToolsIcon");
        }

        public static void ClickTableTool()
        {
            // AutomationAgent.Click("NotebookView", "NotebookTableToolIcon");

            int x = AutomationAgent.GetControlPositionX("NotebookView", "NotebookBackgroundChangePane");
            int y = AutomationAgent.GetControlPositionY("NotebookView", "NotebookBackgroundChangePane");
            AutomationAgent.Click(x, y + 235);


        }

        public static bool VerifyTableInNotebook()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookTableExpandEastButton");
        }

        public static void AddTextToNotebookTableHeaderCell(string text)
        {
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "1");
        }

        public static void AddTextToNotebookTableColumnHeaderCell(string text)
        {
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "2");
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "3");
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "4");
        }

        public static void AddTextToNotebookTableCell(string text)
        {
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "7");
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "8");
            AutomationAgent.SetText("NotebookView", "NotebookTableCells", text, WaitTime.DefaultWaitTime, "9");
        }

        public static void ExpandTableInNotebookHorizontal()
        {
            AutomationAgent.Swipe("NotebookView", "NotebookTableExpandEastButton", UITestGestureDirection.Right, WaitTime.DefaultWaitTime, "", 200);
        }

        public static void ExpandTableInNotebookVertical()
        {
            AutomationAgent.Swipe("NotebookView", "NotebookTableExpandSouthButton", UITestGestureDirection.Down, WaitTime.DefaultWaitTime, "", 200);
        }

        public static bool VerifyAdditionalCellsAddedInNotebook()
        {
            int Posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookTableCells", WaitTime.DefaultWaitTime, "5");
            return (Posx > 0);
        }

        public static void MoveTableRightInNotebook()
        {
            // AutomationAgent.Swipe("NotebookView", "NotebookTableExpandSouthButton", UITestGestureDirection.Down, WaitTime.DefaultWaitTime, "", 200);
            // NavigationCommonMethods.SwipeUnitsRight();

            int posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookSnapshotThumbnailClose");
            int posY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookSnapshotThumbnailClose");
            AutomationAgent.Slide(posx + 50, posY + 50, posx + 200, posY + 50);


        }

        public static void MoveTableLeftInNotebook()
        {
            // AutomationAgent.Swipe("NotebookView", "NotebookTableExpandSouthButton", UITestGestureDirection.Down, WaitTime.DefaultWaitTime, "", 200);
            NavigationCommonMethods.SwipeUnitsRight();
        }

        public static int GetTablePositionXInNotebook()
        {
            return AutomationAgent.GetControlPositionX("NotebookView", "NotebookTableExpandSouthButton");
        }

        public static int GetTablePositionYInNotebook()
        {
            return AutomationAgent.GetControlPositionY("NotebookView", "NotebookTableExpandSouthButton");
        }

        public static bool VerifyShareAirplaneIconPresentInNotebookAtTopLeft()
        {
            if (!AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareAirplaneIcon"))
                return false;

            int PosY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookShareAirplaneIcon");
            int Posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookShareAirplaneIcon");

            return PosY < 200 && Posx > 1000;

        }

        public static void ClickShareAirplaneIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookShareAirplaneIcon");
        }

        public static bool VerifyShareNotebookConfirmationPrompt()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareConfirmationTeacherScrollName");
        }

        public static bool VerifyTeacherNameInSharePrompt()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareConfirmationTeacherScrollName");
        }

        public static bool VerifyXCloseIconInSharePrompt()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareConfirmationRedXIcon");
        }

        public static bool ClickXCloseIconInSharePrompt()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareConfirmationRedXIcon");
        }

        public static bool VerifyCheckSendIconInSharePrompt()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareConfirmationGreenAcceptIcon");
        }

        public static void ClickCheckSendIconInSharePrompt()
        {
            AutomationAgent.Click("NotebookView", "NotebookShareConfirmationGreenAcceptIcon");
        }

        public static bool VerifyNotebookSentMessage()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareSentAlertPopupSentMessage", 20000);
        }

        public static void CloseNotebookSentPopup()
        {
            AutomationAgent.Click("NotebookView", "NotebookShareSentAlertPopupClose");
        }

        public static bool VerifyNotebookSentFailureMessage()
        {
            return LoginCommonMethods.VerifyHelpPopup();
        }

        public static void ClickToCloseNotebookSenFailureMessage()
        {
            LoginCommonMethods.ClickToCloseTryAgainPopup();
        }

        public static bool VerifyShareNotebookConfirmationTeacherListScroll()
        {
            if (AutomationAgent.GetChildrenControlCount("NotebookView", "NotebookShareConfirmationTeacherScrollName") < 0)
                return false;

            string[] TeacherName = AutomationAgent.GetChildrenControlNames("NotebookView", "NotebookShareConfirmationTeacherScrollName");
            bool teacherexist = AutomationAgent.VerifyControlExists("NotebookView", "NotebookShareConfirmationTeacherName", WaitTime.DefaultWaitTime, TeacherName[0]);
            int TchrPosx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookShareConfirmationTeacherName", WaitTime.DefaultWaitTime, TeacherName[0]);

            AutomationAgent.Swipe("NotebookView", "NotebookShareConfirmationTeacherScrollName", UITestGestureDirection.Left);
            AutomationAgent.Swipe("NotebookView", "NotebookShareConfirmationTeacherScrollName", UITestGestureDirection.Left);
            int TchrPosxNew = AutomationAgent.GetControlPositionX("NotebookView", "NotebookShareConfirmationTeacherName", WaitTime.DefaultWaitTime, TeacherName[0]);
            if (TchrPosx != TchrPosxNew)
                return true;

            else
                return false;

        }

        public static void ClickAddPageButtonNotebookScreen()
        {
            AutomationAgent.Click("NotebookView", "NotebookAddPageIconOnNotebookScreen");
        }

        public static bool VerifyCameraMicrophoneIconInNotebook()
        {
            return AutomationAgent.VerifyControlExists("BookBuilderView", "PageCameraTool");
        }

        public static void ClickCameraMicrophoneIconInNotebook()
        {
            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
        }

        public static bool VerifyToolsSubMenuOpened()
        {
            //int posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookBackgroundChangePane");
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookBackgroundChangePane");
        }

        public static void ClickMicrophoneIcon()
        {
            AutomationAgent.Wait(500);
            AutomationAgent.Click(190, 245);

            if (AutomationAgent.VerifyControlExists("NotebookView", "Accept"))
                AutomationAgent.Click("NotebookView", "Accept");

        }

        public static bool VerifyMicrophoneRecordAndCloseButtons()
        {
            //throw new NotImplementedException();
            return true;
        }

        public static void ClickNotebookColorPickerIcon()
        {
            AutomationAgent.Click("NotebookView", "NotebookToolColourPickerIcon");
        }

        public static bool VerifyColorPickerSubMenuOpened()
        {
            AutomationAgent.Wait(500);
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookColorPickerSubMenuPopup");
        }

        public static bool VerifyCrayonToolIconSelected()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookCrayonIcon");
        }

        public static bool VerifyBrushToolIconSelected()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookToolBrushIcon");
        }

        public static bool VerifyMarkerToolIconSelected()
        {
            return AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookToolMarkerIcon");
        }

        public static void ClickScaleNumberLineTool()
        {
            // AutomationAgent.Click("NotebookView", "NotebookTableToolIcon");

            int x = AutomationAgent.GetControlPositionX("NotebookView", "NotebookBackgroundChangePane");
            int y = AutomationAgent.GetControlPositionY("NotebookView", "NotebookBackgroundChangePane");
            AutomationAgent.Click(x + 10, 225);
            //200,225

        }

        public static bool VerifyScaleNumberLineInNotebook()
        {
            return VerifyTableInNotebook();
        }

        public static void ClickScaleNumberLineColorCircle(string CirleNo)
        {
            AutomationAgent.Click("NotebookView", "ScaleNumberLineColorCircle", WaitTime.DefaultWaitTime, CirleNo);
        }

        public static bool VerifyColorInScaleHavingColorsCircle(string CirleNo)
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "ScaleNumberLineColorCircle", WaitTime.DefaultWaitTime, CirleNo);
        }

        public static bool VerifyColorSelectionScaleHas11Colors()
        {
            //int children = AutomationAgent.GetChildrenControlCount("NotebookView", "SubMenuScrollViewer");
            return AutomationAgent.VerifyControlExists("NotebookView", "ScalePopupColorButtons", WaitTime.DefaultWaitTime, "11");

        }

        public static void ClickButtonInColorSelectionPopup(int Child)
        {
            //bool exist;
            //AutomationAgent.ClickAndVerifyColorOfChildrenByInstance("NotebookView", "SubMenuScrollViewer", System.Drawing.Color.Beige, out exist, WaitTime.DefaultWaitTime,"", Child);
            AutomationAgent.Click("NotebookView", "ScalePopupColorButtons", WaitTime.DefaultWaitTime, Child.ToString());
        }

        public static bool VerifyColorSelectionPopupOpen()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "SubMenuScrollViewer");
        }

        public static void DeleteNotebookPage()
        {
            AutomationAgent.LongClickControl("NotebookView", "NotebookPageImage");

            AutomationAgent.PressHold(680, 480);



            AutomationAgent.DragAndHold("NotebookView", "NotebookPageImage", 100, 700);
            //  AutomationAgent.DragAndDrop("NotebookView", "NotebookPageImage", "BookBuilderView", "BookGrid", 0, "1");
            //  AutomationAgent.DragAndDrop("NotebookView", "NotebookPageImage", "BookBuilderView", "BookBuilderTrashCan", 0, "1");
            AutomationAgent.Click("LoginView", "LogoutConfirm");
        }

        public static void MinimizeShrinkTableInNotebookVertical()
        {
            AutomationAgent.Swipe("NotebookView", "NotebookTableExpandSouthButton", UITestGestureDirection.Up, WaitTime.DefaultWaitTime, "", 200);
        }

        public static bool VerifySixRowsAreDisplayed(int Cell)
        {
            int Posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookTableCells", WaitTime.DefaultWaitTime, Cell.ToString());
            return (Posx > 0);
        }


        public static bool VerifySecondRowIsDisplayed(int Cell)
        {
            int Posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookTableCells", WaitTime.DefaultWaitTime, Cell.ToString());
            return (Posx > 0);
        }

        public static int GetTableCellHeightInNotebook(int cell)
        {
            return AutomationAgent.GetControlHeight("NotebookView", "NotebookTableCells", WaitTime.DefaultWaitTime, cell.ToString());
        }

        public static void ClickLandscapeIcon()
        {
            AutomationAgent.Click("NotebookView", "LandscapeIcon");
        }

        public static void SelectImageFromImageGallery()
        {
            AutomationAgent.Click("NotebookView", "SelectPhoto");

            AutomationAgent.Click("NotebookView", "OpenAddPhoto");
        }

        public static void ClickRedCancelPhotoInsertButton()
        {
            AutomationAgent.Click("NotebookView", "CameraCaptureCancelButton");
        }

        public static bool VerifyPhotoAvailableInNotebook()
        {
            return VerifySnapshotisAvailableInNotebook();
        }

        public static void ClickAcceptPhotoInsertButton()
        {
            AutomationAgent.Click("NotebookView", "CameraCaptureAcceptButton");
        }

        public static void MinimizeShrinkTableInNotebookHorizontal()
        {
            AutomationAgent.Swipe("NotebookView", "NotebookTableExpandEastButton", UITestGestureDirection.Left, WaitTime.DefaultWaitTime, "", 200);
        }

        public static bool VeifyScaleNumberLineHas10NumbersVisible()
        {
            int posx = AutomationAgent.GetControlPositionX("NotebookView", "ScaleNumberLineNumbers", WaitTime.DefaultWaitTime, "10");
            return posx > 0;
        }

        public static bool VerifyRedCloseXButton()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnailClose");
        }

        public static bool VeifyScaleNumberLineHasMoreThan10NumbersVisible()
        {
            int posx = AutomationAgent.GetControlPositionX("NotebookView", "ScaleNumberLineNumbers", WaitTime.DefaultWaitTime, "15");
            return posx > 0;
        }

        public static bool VerifyTableSelectedAndBorderPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookTableExpandEastButton") &&
                AutomationAgent.VerifyControlExists("NotebookView", "NotebookTableExpandSouthButton");
        }

        public static void TapOnNotebook()
        {
            AutomationAgent.Click("NotebookView", "NotebookPane");
        }

        public static bool VerifyMediaInsertedInNotebook()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookMediaSnapshotThumbnail");
        }

        public static void ClickRecordButton()
        {
            //ToDO-Awaiting AutomationId
            AutomationAgent.Click(650, 500);
        }

        public static void ClickRecordStopButton()
        {
            //ToDO-Awaiting AutomationId
            AutomationAgent.Click(650, 500);
        }

        public static void SelectTeacherinSharePrompt(string TeacherName)
        {
            //string[] TeacherNames = AutomationAgent.GetChildrenControlNames("NotebookView", "NotebookShareConfirmationTeacherScrollName");

            //int i = 0;
            //for (i = 0; i < TeacherNames.Length; i++)
            //{
            //    if (TeacherNames[i] != null)
            //        if (TeacherNames[i].Contains(TeacherName))
            //            break;
            //}

            ////if (i == TeacherNames.Length)
            ////    return false;

            //int posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookShareConfirmationTeacherScrollName");
            //int posY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookShareConfirmationTeacherScrollName");
            //for (int j = 0; j < i*2; j++)
            //{
            //    if (i == 1)
            //        i++;
            //    AutomationAgent.Slide(posx + 100, posY + 20, posx + 20, posY + 20);

            //    int TchrPosxNew = AutomationAgent.GetControlPositionX("NotebookView", "NotebookShareConfirmationTeacherName", WaitTime.DefaultWaitTime, TeacherNames[i]);
            //    if (TchrPosxNew > 0)
            //        break;

            //    //AutomationAgent.Swipe("NotebookView", "NotebookShareConfirmationTeacherScrollName", UITestGestureDirection.Left);
            //   // AutomationAgent.Swipe("NotebookView", "NotebookShareConfirmationTeacherScrollName", UITestGestureDirection.Left);
            //}


            //AutomationAgent.ClickChildrensChildByName("NotebookView", "NotebookShareConfirmationTeacherScrollName", 0, "", TeacherNames[i]);
        }

        public static void ClickOnMediaInsertedInNotebook()
        {
            AutomationAgent.Click("NotebookView", "NotebookMediaAudioNotPlayingThumbnail");
        }

        public static void ClickAudioNotPlayingThumbnail()
        {
            AutomationAgent.Click("NotebookView", "NotebookMediaAudioNotPlayingThumbnail");
        }

        public static bool VerifyAudioPlayingThumbnail()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookMediaAudioPlayingThumbnail");
        }

        public static bool VerifyBasicToolbarsNotEnabled()
        {

            bool b = AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookToolMarkerIcon");

            return
                AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookToolBrushIcon") ||
              AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookToolMarkerIcon") ||
               AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookToolEraseIcon") ||
               AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookClearAllIcon") ||
               AutomationAgent.VerifyControlEnabled("NotebookView", "NotebookUndoIcon");
        }

        public static void AddImageInNotebook()
        {
            NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
            NotebookCommonMethods.ClickLandscapeIcon();
            NotebookCommonMethods.SelectImageFromImageGallery();
            NotebookCommonMethods.ClickAcceptPhotoInsertButton();

        }

        public static void AddNewImageInNotebook()
        {
            NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
            NotebookCommonMethods.ClickCameraIcon();
            AutomationAgent.Wait(1000);
            AutomationAgent.Click(600, 400);
            AutomationAgent.Wait(1000);
            AutomationAgent.Click("NotebookView", "CameraOkBotton");
            AutomationAgent.Click("CameraWindow", "CameraCaptureAcceptButton");
        }

        public static void ClickCameraIcon()
        {
            AutomationAgent.Click("BookBuilderView", "CameraOnlyIcon");
        }

        public static bool VerifyAudioRecordCancelButton()
        {
            //ToDo - Automatio Ids waited
            return true;
        }

        public static bool VerifyMediaInsertedAtTopLeft()
        {
            int posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookMediaSnapshotThumbnail");
            int posy = AutomationAgent.GetControlPositionY("NotebookView", "NotebookMediaSnapshotThumbnail");

            return posx < 500 && posy < 300;
        }

        public static bool VerifyTimerAvailableInAudioRecord()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookAudioRecordTimer");
        }

        public static string GetTimerAudioRecordText()
        {
            return AutomationAgent.GetControlText("NotebookView", "NotebookAudioRecordTimer");
        }

        public static void MoveMediaInNotebook()
        {
            int posx = AutomationAgent.GetControlPositionX("NotebookView", "NotebookMediaSnapshotThumbnail");
            int posY = AutomationAgent.GetControlPositionY("NotebookView", "NotebookMediaSnapshotThumbnail");
            AutomationAgent.Slide(posx + 50, posY + 50, posx, posY + 200);
            //AutomationAgent.Swipe("NotebookView", "NotebookMediaSnapshotThumbnail", UITestGestureDirection.Down);
        }

        public static int GetMediaThumnailPositionY()
        {
            return AutomationAgent.GetControlPositionY("NotebookView", "NotebookMediaSnapshotThumbnail");
        }



        public static bool VerifyTeacherShareAirplaneIconPresentInNotebookAtTopLeft()
        {
            if (!AutomationAgent.VerifyControlExists("NotebookView", "TeacherShareAirplaneIcon"))
                return false;

            int PosY = AutomationAgent.GetControlPositionY("NotebookView", "TeacherShareAirplaneIcon");
            int Posx = AutomationAgent.GetControlPositionX("NotebookView", "TeacherShareAirplaneIcon");

            return PosY < 200 && Posx > 1000;
        }

        public static void ClickTeacherShareAirplaneIconPresentInNotebook()
        {
            AutomationAgent.Click("NotebookView", "TeacherShareAirplaneIcon");
        }


        public static void ClickAudioPlayingThumbnail()
        {
            AutomationAgent.Click("NotebookView", "NotebookMediaAudioPlayingThumbnail");
        }

        public static bool VerifyHandIconPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookHandIcon");
        }

        public static bool VerifyCrayonToolIconPresent()
        {
            return AutomationAgent.VerifyControlExists("NotebookView", "NotebookCrayonIcon");
        }
        public static void SwipeLeft()
        {
            AutomationAgent.Wait();
            AutomationAgent.Slide(991, 436, 444, 428);
        }
    }
}
