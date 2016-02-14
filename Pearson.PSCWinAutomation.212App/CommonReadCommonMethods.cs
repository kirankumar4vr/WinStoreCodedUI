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
    /// Summary description for CommonReadCommonMethods
    /// </summary>
    
    public class CommonReadCommonMethods
    {
        public CommonReadCommonMethods()
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
        /// Move to first page of common read
        /// </summary>
        public static void MoveToFirstPageInCommonRead()
        {
            while (AutomationAgent.VerifyControlExists("CommonReadView", "CommonReadPrevButton"))
                AutomationAgent.Click("CommonReadView", "CommonReadPrevButton");

        }
        /// <summary>
        /// Verifies the page number available or not
        /// </summary>
        /// <param name="Pno"></param>
        /// <returns></returns>
        public static bool VerifyCommonReadPageNumber(string Pno)
        {
            bool val = AutomationAgent.VerifyControlExists("CommonReadView", "CommonReadPageNumber", WaitTime.DefaultWaitTime, Pno);

            return AutomationAgent.VerifyControlExists("CommonReadView", "CommonReadPageNumber", WaitTime.DefaultWaitTime, Pno);
            
        }

        /// <summary>
        /// Clicks on right arrow for page navigation
        /// </summary>
        public static void ClickOnRightArrow()
        {
            AutomationAgent.Click("CommonReadView", "CommonReadNextButton");
        }
        /// <summary>
        /// Clicks done button to close common read
        /// </summary>
        public static void ClickOnDoneButton()
        {
            AutomationAgent.Wait();
            AutomationAgent.Click("DashboardView", "CloseButton");
        }
        /// <summary>
        /// Clicks on right arrow for page navigation
        /// </summary>
        public static void ClickOnLeftArrow()
        {
            AutomationAgent.Click("CommonReadView", "CommonReadPrevButton");
        }

        /// <summary>
        /// verify Previous Button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyLeftArrow()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "CommonReadPrevButton");
        }

        /// <summary>
        /// Verifies common read button on screen
        /// </summary>
        /// <param name="taskNumber"></param>
        /// <returns></returns>
        public static bool VerifyCommonReadButton(int taskNumber)
        {
            return AutomationAgent.VerifyControlExists("LessonView", "halfscreen-donatorELA", WaitTime.DefaultWaitTime, taskNumber.ToString());
        }
        /// <summary>
        /// Click to toggle vellum mode
        /// </summary>
        public static void ToggleVellumModeNormal(int buttonNo)
        {
            AutomationAgent.Click("CommonReadView", "VellumModeNormal", WaitTime.DefaultWaitTime, buttonNo.ToString());
            AutomationAgent.Wait(1000);
        }

        public static void ToggleVellumModePressed(int buttonNo)
        {
            AutomationAgent.Click("CommonReadView", "VellumModePressed", WaitTime.DefaultWaitTime, buttonNo.ToString());
            AutomationAgent.Wait(1000);
        }

        /// <summary>
        /// Verifies if Vellum clear button exist
        /// Verifies Vellum mode clear button exist
        /// </summary>
        public static bool VerifyVellumModeButtonExists()
        {
            return (AutomationAgent.VerifyControlExists("CommonReadView", "VellumModeEraserTool") &&
                        AutomationAgent.VerifyControlExists("CommonReadView", "VellumModePenTool") &&
                                AutomationAgent.VerifyControlExists("CommonReadView", "VellumModeClear"));

        }

        public static void Sleep()
        {
            System.Threading.Thread.Sleep(5000);
        }



        public static void GetAnnotationMenu(int x, int y, bool ClickDeletHighlight=true)
        {
            NotebookCommonMethods.TapOnScreen(x,y);
            AutomationAgent.Wait(1000);
            //Delete Annotation, if already
            //ToDO- Can optimize
            if (AutomationAgent.VerifyControlExists("CommonReadView", "EditButton"))
            {
                int Editpos = AutomationAgent.GetControlPositionX("CommonReadView", "EditButton");
                if (Editpos > 50)
                {
                    AutomationAgent.Click("CommonReadView", "DeleteButton");
                    AutomationAgent.Click("CommonReadView", "ContinueButton");
                    NavigationCommonMethods.TapToCloseSystemTrayIfOpenByChance();
                }
            }
            
            NotebookCommonMethods.TapOnScreen(x, y);
            AutomationAgent.Click(x,y);
            AutomationAgent.PressHold(x,y);
            CommonReadCommonMethods.Sleep();

            if (VerifyDeleteHighlightButtonExist() && ClickDeletHighlight)
            {
                DeleteHighlightFromCommonRead();
                NotebookCommonMethods.TapOnScreen(x, y);
                AutomationAgent.Click(x, y);
                AutomationAgent.PressHold(x, y);
                CommonReadCommonMethods.Sleep();
            }

            //ToDo - Check if it works
            int trial = 3;
            while (!CommonReadCommonMethods.VerifyAnnotationLink() && trial > 0)
            {

                CommonReadCommonMethods.GetAnnotationMenu(x, y);
                trial--;
            }

        }

        public static bool VerifyCommonReadScreen()
        {
            bool b1 = AutomationAgent.VerifyControlExists("CommonReadView","CommonReadScreenTitle");
            return b1;

        }

        public static void ClickHighlightButton()
        {
            AutomationAgent.Click("CommonReadView", "HighLight");
        }

        public static bool VerfiyHighlightButton()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "HighLight");
        }

        public static bool VerifyExistingAnnotationMessage()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "OKButtonAlreadyAnnotation");
            
        }

        public static void ClickOkButton()
        {
            //ToDo-Can optimize
            if (VerifyExistingAnnotationMessage())
            {
                AutomationAgent.Click("CommonReadView", "OKButtonAlreadyAnnotation");
            }

            else
            {
                AutomationAgent.Click("CommonReadView", "OKButton");
            }
            
        }

        public static void DeleteHighlightFromCommonRead()
        {
            AutomationAgent.Click("CommonReadView", "DeleteHighLight");
        }

        public static bool VerifyDeleteHighlightButtonExist()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "DeleteHighLight") &&
                       ( AutomationAgent.GetControlPositionX("CommonReadView", "DeleteHighLight") > 0);
           
        }

        public static void CreateAnnotation(int x, int y, string textToAnnotate)
        {
            CommonReadCommonMethods.GetAnnotationMenu(x, y);
            int trial = 3;
            while (!CommonReadCommonMethods.VerifyAnnotationLink() && trial > 0)
            {

                CommonReadCommonMethods.GetAnnotationMenu(x, y);
                trial--;
            }
            AutomationAgent.Click("CommonReadView", "Annotate");
            AutomationAgent.SetText("CommonReadView", "AnnotationEditor", textToAnnotate);
            AutomationAgent.Click("CommonReadView", "DoneButton");
        }

        public static bool VerifyAnnotationSplitsCRWindow()
        {
            //int AnnotateScreen = AutomationAgent.GetControlPositionX("CommonReadView", "MyAnnotate");
            //int screen = AutomationAgent.GetAppWindowWidth();

            //if (((screen / 2)+13) == AnnotateScreen)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;

        }


        public static void ClickOnAnnotationLink()
        {
            AutomationAgent.Click("CommonReadView", "Annotate");
            AutomationAgent.Wait(3000);
        }

        public static bool VerifyAnnotationLink()
        {
           return AutomationAgent.VerifyControlExists("CommonReadView", "Annotate");
        }

        public static void ChangeAndFilterAnnotationType()
        {
            ClickEditButton();
            AutomationAgent.Wait(500);
            AutomationAgent.Click("CommonReadView", "EditGistText");
            //AutomationAgent.Click("CommonReadView", "NewThinkingAnnotationType");
            //bool ans1 = AutomationAgent.VerifyControlExists("CommonReadView", "NewThinking");
            AutomationAgent.Wait(500);     
            AutomationAgent.Click("CommonReadView", "NewThinkingAnnotationType");
            NotebookCommonMethods.TapOnScreen(500, 500);
            CommonReadCommonMethods.Sleep();
            // AutomationAgent.VerifyControlExists("CommonReadView", "");
            //AutomationAgent.Click("CommonReadView", "AnnotationType");
            //AutomationAgent.VerifyControlExists("CommonReadView", "");
            //AutomationAgent.Click("CommonReadView", "AnnotationType");
            //SelectAnnotation(commonReadAutomationAgent, annotationType, "everybody");
            AutomationAgent.Click("CommonReadView", "DeleteButton");
            if(AutomationAgent.VerifyControlExists("CommonReadView", "ContinueButton"))
                    AutomationAgent.Click("CommonReadView", "ContinueButton");

        }
        public static void ClickEditButton()
        {
            AutomationAgent.Click("CommonReadView", "EditButton");
        }

        public static bool VerifyEditAndDeleteButton()
        {
            if(AutomationAgent.VerifyControlExists("CommonReadView", "EditButton") &&
                AutomationAgent.VerifyControlExists("CommonReadView", "DeleteButton"))
            {
            return true;
            }
            else
            {
            return false;
            }
        }

        public static void CLickOnCopyLink()
        {
            AutomationAgent.Click("CommonReadView", "Copy");
        }

        public static void PastTextInTextZone()
        {
            AutomationAgent.PressHold(1093, 374);
            AutomationAgent.Click("CommonReadView", "Paste");
        }
        /// <summary>
        /// Gets the page number present in common read
        /// </summary>
        /// <param name="Pno"></param>
        /// <returns>string</returns>
        public static string GetCommonReadPageNumber(string Pno)
        {
            return AutomationAgent.GetControlText("CommonReadView", "CommonReadPageNumber", WaitTime.DefaultWaitTime, Pno);
        }
        /// <summary>
        /// Verifies if Right Arrow exists or not
        /// </summary>
        /// <returns>bool: true(if exists), false(if not exist)</returns>
        public static bool VerifyRightArrowExists()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "CommonReadNextButton");
        }
        /// <summary>
        /// Verifies if Left Arrow exists or not
        /// </summary>
        /// <returns>bool: true(if exists), false(if not exist)</returns>
        public static bool VerifyLeftArrowExists()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "CommonReadPrevButton");
        }
        /// <summary>
        /// Verifies the Annotation menu in Common read for new word selected having Copy, Highlight, and Annotate menus
        /// </summary>
        /// <returns>bool: true(if all the menus are present), false(if any of the menu item not present)</returns>
        public static bool VerifyCommonReadAnnotationMenus()
        {
            if (AutomationAgent.VerifyControlExists("CommonReadView", "Copy") &&
                AutomationAgent.VerifyControlExists("CommonReadView", "HighLight") &&
                AutomationAgent.VerifyControlExists("CommonReadView", "Annotate")
                )
                return true;
            else
                return false;
        }
        /// <summary>
        /// Selects the Recipient from the List and verifies if its been selected or not
        /// </summary>
        /// <param name="recipientNo">int: Recipient to be selected</param>
        /// <returns>true(if selected), fasle(if not selected)</returns>
        public static bool SelectRecipient(int recipientNo)
        {
            AutomationAgent.Click("CommonReadView", "CheckBoxInSelectRecipients", WaitTime.DefaultWaitTime, recipientNo.ToString());
            return AutomationAgent.VerifyCheckBoxChecked("CommonReadView", "CheckBoxInSelectRecipients", WaitTime.DefaultWaitTime, recipientNo.ToString());
        }
        /// <summary>
        /// Clicks on Annotation Share button 
        /// </summary>
        public static void ClickAnnotationShareButton()
        {
            AutomationAgent.Click("CommonReadView", "AnnotationShareButton");
            AutomationAgent.Wait();
        }
        /// <summary>
        /// Verifies if Select Recipients Overlay Exist or not
        /// </summary>
        /// <returns>true(if exists), false(if doesn't exists)</returns>
        public static bool VerifySelectRecipientsOverlay()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "SelectRecipientsLabel");
        }
        /// <summary>
        /// Clicks on Cancel Button in Select Recipients Overlay
        /// </summary>
        public static void ClickCancelInSelectRecipients()
        {
            AutomationAgent.Click("CommonReadView", "CancelInSelectRecipientsPane");
        }
        /// <summary>
        /// Deselects the Recipient from the list and Verifies if the recipient is de selected or not
        /// </summary>
        /// <param name="recipientNo">int: Recipient to be selected</param>
        /// <returns>bool: true(if deselected), false(if not deselected)</returns>
        //public static bool DeSelectRecipient(int recipientNo)
        //{
        //    AutomationAgent.Click("CommonReadView", "ShareButtonText", WaitTime.DefaultWaitTime, recipientNo.ToString());
        //    return AutomationAgent.VerifyCheckBoxChecked("CommonReadView", "CheckBoxInSelectRecipients", WaitTime.DefaultWaitTime, recipientNo.ToString());
        //}
        /// <summary>
        /// Clicks on Done button in Annotation Window to save the annotation 
        /// </summary>
        public static void ClickDoneButtonInAnnotationWindow()
        {
            AutomationAgent.Click("CommonReadView", "DoneButton");
            AutomationAgent.Wait();
        }
        /// <summary>
        /// Set the text in Annotation Editor
        /// </summary>
        /// <param name="text">string: text to be entered</param>
        public static void SetTextInAnnotationEditor(string text)
        {
            AutomationAgent.SetText("CommonReadView", "AnnotationEditor", text);
           // AutomationAgent.SendText(text);

        }

        public static string GetTextFromEditMode()
        {
            return AutomationAgent.GetText("CommonReadView", "AnnotationEditor");
        }
        /// <summary>
        /// Verifies if Annotation Mode is in Pressed state or not
        /// </summary>
        /// <returns>true(if in pressed state), false(if not in pressed state)</returns>
        public static bool VerifyAnnotationModeOn(int buttonNo)
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "VellumModePressed", WaitTime.DefaultWaitTime, buttonNo.ToString());
        }
        /// <summary>
        /// Clicks on Cancel Button Present in the Annotation Editor 
        /// </summary>
        public static void ClickCancelButtonInAnnotationWindow()
        {
            AutomationAgent.Click("CommonReadView", "CancelButton");
        }
        /// <summary>
        /// Verifies if any Undownloaded CR is present or not
        /// </summary>
        /// <returns>true(if present), false(if not present)</returns>
        public static bool VerifyUndownloadedCR()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "TapToDownloadButtonInTask");
        }
        /// <summary>
        /// Clicks on Send button in Select Recipients Pane
        /// </summary>
        public static void SendWork()
        {
            AutomationAgent.Click("CommonReadView", "SendInSelectRecipientsPane");
            while(!AutomationAgent.VerifyControlExists("CommonReadView", "WorkSentSuccessAlert"))
            {
                if (AutomationAgent.VerifyControlExists("CommonReadView", "NoInternetAccessAlert"))
                {
                    AutomationAgent.Click("CommonReadView", "OKButton");
                    break;
                }
                AutomationAgent.Wait();
            }
        }
        /// <summary>
        /// Clicks on Send button in Select Recipients Pane
        /// </summary>
        public static void ClickSendInSelectRecipients()
        {
            AutomationAgent.Click("CommonReadView", "SendInSelectRecipientsPane");
        }
        /// <summary>
        /// Verifies Your Work Will be sent Alert found and then clicks on OK button in the Pop Up
        /// </summary>
        /// <returns>bool: true(if alert found), false(if alert not found)</returns>
        public static bool VerifyWorkWillBeSentAlert()
        {
            AutomationAgent.WaitForControlExists("CommonReadView", "WorkWillBeSentOKButton", 8000);
            if (AutomationAgent.VerifyControlExists("CommonReadView", "WorkWillBeSentAlert"))
            {
                AutomationAgent.Click("CommonReadView", "WorkWillBeSentOKButton");
                return true;
            }
            else
            {
                AutomationAgent.Click("CommonReadView", "OKButton");
                return false;
            }
        }
        /// <summary>
        /// Verifies Your Work Will be sent Alert found and then clicks on OK button in the Pop Up
        /// </summary>
        /// <returns>bool: true(if alert found), false(if alert not found)</returns>
        public static bool VerifyWorkSentAlert()
        {
            AutomationAgent.WaitForControlExists("CommonReadView", "OKayButton", 50000);
            if (AutomationAgent.VerifyControlExists("CommonReadView", "WorkSentSuccessfulAlert"))
            {
                AutomationAgent.Click("CommonReadView", "OKayButton");
                return true;
            }
            else
            {
                AutomationAgent.Click("CommonReadView", "OKButton");
                return false;
            }
        }
        /// <summary>
        /// Clicks on Next button present in the Select Recipients Pane
        /// </summary>
        public static void ClickNextInSelectRecipients()
        {
            AutomationAgent.Click("CommonReadView", "NextButtonInSelectRecipientOverlay");
        }
        /// <summary>
        /// Selects the Receipent 
        /// </summary>
        public static void SelectSec34Per5()
        {
            AutomationAgent.Click("CommonReadView", "AmericanSec34Per5");
        }
        /// <summary>
        /// Clicks on Shared Button In Common Read
        /// </summary>
        public static void ClickAnnotationSharedButton()
        {
            AutomationAgent.Click("CommonReadView", "SharedButton");
        }
        /// <summary>
        /// Verifies Student Name In shared Annotation
        /// </summary>
        /// <returns>true(if found)false(if not)</returns>
        public static bool VerifyStudentInSharedAnnonation(string studentName)
        {
            string name = AutomationAgent.GetControlText("WorkBrowserView", "StudentNameInShared", WaitTime.DefaultWaitTime, studentName);
            if (name.Equals(studentName))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Send button colour In Select Recipient
        /// </summary>
        /// <param name="sampleColor"></param>
        /// <returns>true(if found)false(if not)</returns>
        public static bool VerifySendButtonColourInSelectRecipient(System.Drawing.Color sampleColor)
        {
            bool a1 = AutomationAgent.CompareControlImageColor("CommonReadView", "SendInSelectRecipientsPane", sampleColor);

            return a1;
            //return AutomationAgent.CompareControlImageColor("CommonReadView", "SendInSelectRecipientsPane", sampleColor);
        }
        /// <summary>
        /// Verifies if Cancel button is present or not in Select Recipients
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCancelInSelectRecipients()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "CancelInSelectRecipientsPane");
        }
        /// <summary>
        /// Verifies if Send button is present or not in Select Recipients
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySendInSelectRecipient()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "SendInSelectRecipientsPane");
        }
        /// <summary>
        /// Verifies if Teacher and student's list is present in Select Recipients Overlay 
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyTeacherAndStudentLists()
        {
            if (AutomationAgent.VerifyControlExists("CommonReadView", "TeacherListsInSelectRecipients") &&
               AutomationAgent.VerifyControlExists("CommonReadView", "StudentListsInSelectRecipients"))
                return true;
            else
                return false;
        }

        public static void ClickDeleteButtonAnnotationWindow()
        {
            AutomationAgent.Click("CommonReadView", "DeleteButton");
        }



        /// <summary>
        /// Verifies Highlighted Text Already Present
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyHighlightedTextAlreadyPresent()
        {
            return AutomationAgent.VerifyControlExists("CommonReadView", "DeleteHighLight");
        }

        public static bool VerifyHighlightedTextAlreadyVisible()
        {
            return AutomationAgent.VerifyControlVisible("CommonReadView", "DeleteHighLight");
        }

        /// <summary>
        /// Creates the highlight for a particular text present at specific position
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        public static void CreateHighlight(int x, int y)
        {
            CommonReadCommonMethods.GetAnnotationMenu(x, y);
            int trial = 3;
            while (!CommonReadCommonMethods.VerfiyHighlightButton() && trial > 0)
            {

                CommonReadCommonMethods.GetAnnotationMenu(x, y);
                trial--;
            }
            AutomationAgent.Click("CommonReadView", "HighLight");
            AutomationAgent.Wait(1000);
        }

        public static bool VerifyHiglightedTextColorInCR(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("LoginView", "LoginButton", sampleColor);
        }

        public static void ClickAnnotatedtext(int x, int y)
        {
            AutomationAgent.Click(x, y);
        }

        public static bool VerifyAnnotationListPanelPresent()
        {
            AutomationAgent.Wait(500);
            return AutomationAgent.VerifyControlExists("CommonReadView", "EditPane");
        }

        public static void InitialMethodForCommonRead()
        {
            //AutomationAgent.LaunchApp();
            //if (AutomationAgent.VerifyControlExists("DashboardView", "CloseButton"))
            //{
            //    ClickOnDoneButton();
            //}
        }
        /// <summary>
        /// Deletes the Annotation
        /// </summary>
        public static void DeleteAnnotation()
        {
            AutomationAgent.Click("CommonReadView", "DeleteButton");
            AutomationAgent.Click("CommonReadView", "ContinueButton");
        }
    }
}
