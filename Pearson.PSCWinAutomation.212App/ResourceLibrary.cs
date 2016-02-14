using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Configuration;
using Pearson.PSCWinAutomation.Framework;
using System.Drawing;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for ResourceLibrary
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class ResourceLibrary
    {
        public ResourceLibrary()
        {
        }



        #region Additional test attributes

        [TestInitialize]
        public void TestInitialize()
        {
            Logger.InsertTestHeaderLine(testContextInstance.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Logger.InsertTestEndLine(testContextInstance.TestName + " , Test Result: " + testContextInstance.CurrentTestOutcome.ToString());
        }

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
        [TestCategory("ResourceLibraryTests")]
        [Priority(1)]
        [WorkItem(53058)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void FullMenuViewofResourceLibrary()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryMenuItems(), "Resource library menu items not verified at dashboard");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryMenuItems(), "Resource library menu items not verified at unit");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryMenuItems(), "Resource library menu items not verified at unit at lesson");
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.Logout();

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
        [TestCategory("ResourceLibraryTests")]
        [Priority(1)]
        [WorkItem(53059)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void FullMenuViewofResourceLibraryforStudent()
        {
            try
            {
                Login login = Login.GetLogin("StudentBruceSec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryMenuItems(), "Resource library menu items not verified at dashboard");
                ResourceLibraryCommonMethods.CloseResourceLibraryMenu();

                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryMenuItems(), "Resource library menu items not verified at unit");
                ResourceLibraryCommonMethods.CloseResourceLibraryMenu();
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(taskInfo);
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryMenuItems(), "Resource library menu items not verified at unit at lesson");
                ResourceLibraryCommonMethods.CloseResourceLibraryMenu();
                NavigationCommonMethods.Logout();

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
        [TestCategory("ResourceLibraryTests")]
        [Priority(1)]
        [WorkItem(52447)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyResourceLibraryIconAvailableAtChromeMenu()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryIcon(), "Resource Library icon not available");
                ResourceLibraryCommonMethods.CloseResourceLibraryMenu();
                NavigationCommonMethods.Logout();

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
        [TestCategory("ResourceLibraryTests")]
        [Priority(2)]
        [WorkItem(52450)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyResourceLibraryflyOutMenuHeadingIsResourceLibrary()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.StartELAUnitFromUnitLibrary(taskInfo.Unit);
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyResourceLibraryIcon(), "Resource Library icon not available");
                NavigationCommonMethods.ClickOnShowToolsAndGames();
                Assert.IsTrue(ResourceLibraryCommonMethods.VerifyFlyOutMenuHeadingIsResourceLibrary(), "Resource Library flyOut Menu Heading Is not Resource Library");
                ResourceLibraryCommonMethods.CloseResourceLibraryMenu();
                NavigationCommonMethods.Logout();

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
