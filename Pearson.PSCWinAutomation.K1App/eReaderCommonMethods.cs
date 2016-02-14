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
    /// Summary description for eReaderCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class eReaderCommonMethods
    {
        public eReaderCommonMethods()
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




        public static void ZoomInEReader()
        {
            AutomationAgent.Wait(4000);
            AutomationAgent.Stretch(700, 400, 650, 370, 50);
        }

        public static void ZoomOutEReader()
        {
            AutomationAgent.Wait(4000);
            AutomationAgent.Stretch(700, 400, 750, 430, 50);
        }

        public static void TapOnEReaderScreen()
        {
            AutomationAgent.Wait(4000);
            AutomationAgent.Click(700, 400);
        }

        public static bool VerifyEReaderHeader()
        {
           // if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait();
                TapOnEReaderScreen();


            return (AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader") &&
                AutomationAgent.VerifyControlExists("EReaderView", "EReaderOpenAnnotation") &&
                //AutomationAgent.VerifyControlExists("EReaderView", "EReaderGooglyEyesClose") &&
                AutomationAgent.VerifyControlExists("EReaderView", "EReaderSendToNotebook"));


        }

        public static bool VerifyEReaderFooter()
        {
           // if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            return (AutomationAgent.VerifyControlExists("EReaderView", "EReaderPageNumber", WaitTime.DefaultWaitTime, "1") ||
                AutomationAgent.VerifyControlExists("EReaderView", "EReaderNextButtonBottom"));
        }

        public static void ClickEReaderNextButton()
        {
            //if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            AutomationAgent.Click("EReaderView", "EReaderNextButtonBottom");
        }

        public static bool VerifyEReaderPageNumber(int pno)
        {
          //  if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            return AutomationAgent.VerifyControlExists("EReaderView", "EReaderPageNumber", WaitTime.DefaultWaitTime, pno.ToString());
        }

        public static bool VerifyEReaderPageNumberAtCenter(int pno)
        {
            //if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            int PageNoX = AutomationAgent.GetControlPositionX("EReaderView", "EReaderPageNumber", WaitTime.DefaultWaitTime, pno.ToString());
            int screenpos = AutomationAgent.GetAppWindowWidth();
            int pagenowidth = AutomationAgent.GetControlWidth("EReaderView", "EReaderPageNumber", WaitTime.DefaultWaitTime, pno.ToString());

            return (PageNoX == (screenpos / 2) - 10);


        }

        public static void ClickEReaderPreviousButton()
        {
           // if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            AutomationAgent.Click("EReaderView", "EReaderPrevButtonBottom");
        }

        public static void ClickEReaderOpenAnnotation()
        {
            TapOnEReaderScreen();
            AutomationAgent.Click("EReaderView", "EReaderOpenAnnotation");

        }

        public static void ClickEReaderNextButtonAnnotation()
        {
            AutomationAgent.Click("EReaderView", "EReaderNextButtonAnnotation");
        }

        public static void ClickEReaderPreviousButtonAnnotation()
        {
            AutomationAgent.Click("EReaderView", "EReaderPrevButtonAnnotation");
        }

        public static void ClickBackButtoneReaderAnnotation()
        {
            AutomationAgent.Click("EReaderView", "GoBackButtonEReaderAnnotation");
        }

        public static bool VerifyEReaderAnnotationModeOpened()
        {
            return AutomationAgent.VerifyControlExists("EReaderView", "EReaderAnnotationMode");
        }

        public static void ClickEReaderSendToNotebookButtonAnnotation()
        {
            AutomationAgent.Click("EReaderView", "EReaderSendToNotebookAnnotation");
        }

        public static bool VerifyCropViewEnabled()
        {
            return AutomationAgent.VerifyControlExists("EReaderView", "EReaderAnnotationCropMode");
        }

        public static void ClickRedCrossCropViewButton()
        {
            AutomationAgent.Click("EReaderView", "EReaderAnnotationCropRedCross");
        }

        public static void ClickGreenAcceptCropViewButton()
        {
            AutomationAgent.Click("EReaderView", "EReaderAnnotationCropGreenAccept");
        }

        public static void ChangeCropViewEReader()
        {
            NavigationCommonMethods.SwipeScreenDown();
        }



        public static void ClickEReaderGooglyEyesClose()
        {
           // if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            AutomationAgent.Click("EReaderView", "EReaderGooglyEyesClose");
        }

        public static void ClickEReaderSendToNotebookButton()
        {
            AutomationAgent.Wait(4000);
            TapOnEReaderScreen();

            AutomationAgent.Click("EReaderView", "EReaderSendToNotebook");
        }

        public static bool VerifyEReaderGooglyEyesClose()
        {
            AutomationAgent.Wait(4000);
            TapOnEReaderScreen();
            return AutomationAgent.VerifyControlExists("EReaderView", "EReaderGooglyEyesClose");
        }

        public static bool VerifyEReaderHeaderFooterNotDisplayedByDefault()
        {
            return (AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader") &&
               AutomationAgent.VerifyControlExists("EReaderView", "EReaderOpenAnnotation") &&
               AutomationAgent.VerifyControlExists("EReaderView", "EReaderSendToNotebook") &&

            AutomationAgent.VerifyControlExists("EReaderView", "EReaderPageNumber", WaitTime.DefaultWaitTime, "1") &&
               AutomationAgent.VerifyControlExists("EReaderView", "EReaderNextButtonBottom"));
        }

        public static void NavigateToFirstPageAnnotation()
        {
            while (AutomationAgent.VerifyControlExists("EReaderView", "EReaderPrevButtonAnnotation"))
                AutomationAgent.Click("EReaderView", "EReaderPrevButtonAnnotation");
        }

        public static bool VerifyEReaderGooglyEyesOpen()
        {
           return AutomationAgent.VerifyControlExists("EReaderView", "EReaderGooglyEyesOpen");
        }

        public static void NavigateToFirstPageEReader()
        {
           // if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();
            
            while (AutomationAgent.VerifyControlExists("EReaderView", "EReaderPrevButtonBottom"))
                AutomationAgent.Click("EReaderView", "EReaderPrevButtonBottom");
        }

        public static bool VerifySendToNotebookButtonAtTopRight()
        {
            //-if (!AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReader"))
            AutomationAgent.Wait(4000);
                TapOnEReaderScreen();

            
            int screenwidth = AutomationAgent.GetAppWindowWidth();
            int xPosSendNbButton = AutomationAgent.GetControlPositionX("EReaderView", "EReaderSendToNotebook");
            int yPosSendNbButton = AutomationAgent.GetControlPositionY("EReaderView", "EReaderSendToNotebook");

            if (screenwidth - 200 < xPosSendNbButton && yPosSendNbButton < 50)
                return true;

            else
                return false;
        }

        public static bool VerifyEReaderAnnotationPageUI()
        {
            return (AutomationAgent.VerifyControlExists("EReaderView", "GoBackButtonEReaderAnnotation") &&
                    AutomationAgent.VerifyControlExists("EReaderView", "EReaderSendToNotebookAnnotation") &&
                    AutomationAgent.VerifyControlExists("EReaderView", "EReaderCloseAnnotation") &&
                    AutomationAgent.VerifyControlExists("NotebookView", "NotebookCrayonIcon") &&
                    AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolBrushIcon") &&
                    AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolMarkerIcon") &&
                    AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolStampIcon") &&
                    AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolColourPickerIcon") &&
                    AutomationAgent.VerifyControlExists("NotebookView", "NotebookToolEraseIcon"));

        }
    }
}
