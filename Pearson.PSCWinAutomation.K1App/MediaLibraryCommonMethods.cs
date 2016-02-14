using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using MouseButtons = Microsoft.VisualStudio.TestTools.UITest.Input.MouseButtons;
using Pearson.PSCWinAutomation.Framework;
using System.Linq;

namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for MediaLibraryCommonMethods
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class MediaLibraryCommonMethods
    {
        public MediaLibraryCommonMethods()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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

        public static int GetWidthofMediaLibraryShelf(int shelfRow)
        {
            return AutomationAgent.GetControlWidth("MediaLibraryView", "MediaLibraryGridModel", WaitTime.DefaultWaitTime, shelfRow.ToString());
        }

        public static int GetYPositionofMediaLibraryShelf(int shelfRow)
        {
            return AutomationAgent.GetControlPositionY("MediaLibraryView", "MediaLibraryGridModel", WaitTime.DefaultWaitTime, shelfRow.ToString());
        }

        public static int GetYPositionofMediaLibraryThumbnail(int shelfRow)
        {
            return AutomationAgent.GetControlPositionY("MediaLibraryView", "MediaLibraryThumbnailActivityView", WaitTime.DefaultWaitTime, shelfRow.ToString());
        }

        public static void ClickMediaLibraryThumbnail(int shelfRow)
        {
            AutomationAgent.Click("MediaLibraryView", "MediaLibraryThumbnailActivityView", WaitTime.DefaultWaitTime, shelfRow.ToString());
        }

        public static void ClickMediaLibraryThumbnailShelf2Items(int rowitem)
        {
            AutomationAgent.Click("MediaLibraryView", "MediaLibraryThumbnailActivityViewShelf2Items", WaitTime.DefaultWaitTime, rowitem.ToString());
        }
    }
}
