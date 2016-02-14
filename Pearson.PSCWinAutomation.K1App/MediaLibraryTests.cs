using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using System.Configuration;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Pearson.PSCWinAutomation.Framework;
using Pearson.PSCWinAutomationFramework.__k1App;


namespace Pearson.PSCWinAutomationFramework.K1App
{
    /// <summary>
    /// Summary description for MediaLibraryTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class MediaLibraryTests
    {
        public MediaLibraryTests()
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

        [TestMethod()]
        [TestCategory("MediaLibraryTests")]
        [Priority(2)]
        [WorkItem(20380)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MediaLibFirstShelfofEachActivityTypeShouldbeLongerLikeoniOS()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
                int widthshelffirstActivityOne = MediaLibraryCommonMethods.GetWidthofMediaLibraryShelf(2);
                int widthshelffirstActivitytwo = MediaLibraryCommonMethods.GetWidthofMediaLibraryShelf(4);
                Assert.IsTrue(widthshelffirstActivityOne == widthshelffirstActivitytwo, "first shelf width not same");
                //NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTests")]
        [Priority(2)]
        [WorkItem(20654)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MediaLibrarySwipedUporDowntoScrollThroughActivityTypes()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");
                int GetPosShelfInitialY = MediaLibraryCommonMethods.GetYPositionofMediaLibraryShelf(1);
                NavigationCommonMethods.SwipeScreenDown();
                int GetPosShelfInitialSwipeDown = MediaLibraryCommonMethods.GetYPositionofMediaLibraryShelf(1);
                Assert.IsTrue(GetPosShelfInitialSwipeDown < GetPosShelfInitialY,"screen not swiped down");
                NavigationCommonMethods.SwipeScreenUp();
                int GetPosShelfInitialSwipeUp = MediaLibraryCommonMethods.GetYPositionofMediaLibraryShelf(1);
                Assert.IsTrue(GetPosShelfInitialSwipeDown < GetPosShelfInitialSwipeUp, "screen not swiped up");

                //NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("MediaLibraryTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(23227)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void MediaLibraryBackButtonSaveRestoreState()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToELAUnit(2);
                Assert.IsTrue(NavigationCommonMethods.VerifyUnitHomeScreen(), "Unit home screen not found");
                NavigationCommonMethods.NavigateToMediaLibrary();
                Assert.IsTrue(NavigationCommonMethods.VerifyMediaLibraryScreen(), "Media Library  screen not found");

                NavigationCommonMethods.SwipeScreenDown();
                int GetPosThumbnailInitialY = MediaLibraryCommonMethods.GetYPositionofMediaLibraryThumbnail(3);
                MediaLibraryCommonMethods.ClickMediaLibraryThumbnail(3);
                NavigationCommonMethods.ClickBackButtoneReader();
                int GetPosThumbnailAfterY = MediaLibraryCommonMethods.GetYPositionofMediaLibraryThumbnail(3);
                Assert.IsTrue(GetPosThumbnailAfterY == GetPosThumbnailInitialY, "screen not swiped down");
                //NavigationCommonMethods.Logout();
            }
            catch (AssertFailedException Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
                Logger.InsertExceptionMessage(msg);
                throw;
            }
        }
    }
}
