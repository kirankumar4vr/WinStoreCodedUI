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
    /// Summary description for BackPackCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class BackPackCommonMethods
    {
        public BackPackCommonMethods()
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

        public static void AddItemsToBackPack(int shelfrow = 2)
        {
            //"MediaLibraryView", "MediaLibraryThumbnailActivityView"
            int x =AutomationAgent.GetControlPositionX("MediaLibraryView", "MediaLibraryThumbnailActivityView", 0, shelfrow.ToString());
            int y = AutomationAgent.GetControlPositionY("MediaLibraryView", "MediaLibraryThumbnailActivityView", 0, shelfrow.ToString());
            
            int x1 = AutomationAgent.GetControlPositionX("BackPackView", "BackPackIcon");
            int y1 = AutomationAgent.GetControlPositionY("BackPackView", "BackPackIcon");
            
            AutomationAgent.PressHold(x+50, y+70);
            //AutomationAgent.MouseMoveToAPosition(x1+50,y1+20);
            //AutomationAgent.StrechControl("MediaLibraryView", "MediaLibraryThumbnailActivityView", x, y, x1, y1,50,0,shelfrow.ToString());

            
            AutomationAgent.LongClickControl("MediaLibraryView", "MediaLibraryThumbnailActivityViewImage", 0, shelfrow.ToString());
            AutomationAgent.DragAndHold("MediaLibraryView", "MediaLibraryThumbnailActivityViewImage", 1360, 100, 0, shelfrow.ToString());
            AutomationAgent.Wait();
            AutomationAgent.DragAndDrop("MediaLibraryView", "MediaLibraryThumbnailActivityViewImage", "BackPackView", "BackPackIcon", 0, shelfrow.ToString());
        }
    }
}
