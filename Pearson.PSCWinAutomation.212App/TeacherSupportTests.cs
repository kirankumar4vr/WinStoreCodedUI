using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Pearson.PSCWinAutomation.Framework;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for TeacherSupportTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class TeacherSupportTests
    {
        public TeacherSupportTests()
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


        [TestMethod]
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(15860)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherDashboardTeacherSupportButtonOpensLandingPageInPsocChrome()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportButtonDashboard(), "Teacher Support Button Not found");
                NavigationCommonMethods.ClickTeacherSupportButtonDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page not found");
                NavigationCommonMethods.Logout();
            }

            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(15857)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SystemTrayTeacherSupportButtonOpensLandingPageInPSoCChrome()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportButtonInSystemTray(), "Teacher Support Button Not Found");
                NavigationCommonMethods.ClickTeacherSupportButtonInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page Not Found");
                NavigationCommonMethods.Logout();

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }

        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(3)]
        [WorkItem(19058)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupportPageChromeTitleSaysTeacherSupport()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.ClickTeacherSupportButtonInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page Not Found");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(1)]
        [WorkItem(15906)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenLeftArrowWasTappedThenTeacherModeExtendedDisplayOpens()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("Math", "Notebook"));
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherModeOpen(), "Teacher Mode not opened");
                AutomationAgent.Wait(1000);
                int widthBefore = TeacherModeCommonMethods.GetWidthOfTeacherModePanel();
                TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon();
                AutomationAgent.Wait(1000);
                int widthExpanded = TeacherModeCommonMethods.GetWidthOfTeacherModePanel();
                Assert.AreEqual(widthExpanded, (widthBefore * 2), "Teacher Mode Accordion Width not expanded to twice ");
                TeacherModeCommonMethods.ClickOnTeacherModeArrowIcon();
                AutomationAgent.Wait(1000);
                int widthAfter = TeacherModeCommonMethods.GetWidthOfTeacherModePanel();
                Assert.AreEqual(widthAfter, widthBefore, "Teacher Mode is not back to same position");
                NavigationCommonMethods.ClickOnTeacherModeIcon();
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [WorkItem(19136)]
        [Priority(2)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void TeacherSupportButtonIsNotVisibleTheFirstTime()
        {
            try
            {
                //Sectioned Student
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Is Not Avaialble");
                NavigationCommonMethods.Logout();

                //Sectioned Teacher
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Is Not Avaialble");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToMyDashboard();
                Assert.IsTrue(DashboardCommonMethods.VerifyTeacherSupportButtonPresent(), "TeacherSupportButton Is Not Present");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [WorkItem(15861), WorkItem(46748)]
        [Priority(3)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupportLandingPageStylingAlignedToSpecs()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Page not present");
                TeacherSupportCommonMethods.ClickTeacherSupportButtonInDashboard();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page not present");
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        //Network dependent

        [TestMethod()]
        [TestCategory("TeacherSupportTests")]
        [Priority(2)]
        [WorkItem(15859)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TeacherSupportLinksOnLandingPageDirectUserToExternalResourceSites()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                NavigationCommonMethods.ClickTeacherSupportButtonInSystemTray();
                Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page Not Found");
                TeacherSupportCommonMethods.ClickOnGrowYourSkills();
                AutomationAgent.Wait();
                AutomationAgent.Wait();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Pearson SAS | WELCOME - Google Chrome") || TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Pearson SAS | WELCOME - Internet Explorer"), "App is still in focus");
                AutomationAgent.Wait();
                AutomationAgent.Wait();
                TeacherSupportCommonMethods.ClickOnPrepareYourLesson();
                AutomationAgent.Wait();
                AutomationAgent.Wait();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Pearson SAS | WELCOME - Google Chrome") || TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Pearson SAS | WELCOME - Internet Explorer"), "App is still in focus");
                AutomationAgent.LaunchApp();
                TeacherSupportCommonMethods.ClickOnGetHelp();
                AutomationAgent.Wait();
                AutomationAgent.Wait();
                Assert.IsTrue(TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Pearson SAS | WELCOME - Google Chrome") || TeacherSupportCommonMethods.VerifyBrowserOpenedforTeacherSupport("Pearson SAS | WELCOME - Internet Explorer"), "App is still in focus");
                AutomationAgent.LaunchApp();
                NavigationCommonMethods.Logout();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        ////[TestMethod()]
        ////[TestCategory("TeacherSupportTests")]
        ////[Priority(2)]
        ////[WorkItem(16028)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void WhenYouTapAnyLinkWhileWiFiOffErrorMessageAppears()
        ////{
        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.ClickSystemTrayButton();
        ////        NavigationCommonMethods.ClickTeacherSupportButtonInSystemTray();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyTeacherSupportPage(), "Teacher Support Page Not Found");
        ////        AutomationAgent.DisableNetwork();
        ////        TeacherSupportCommonMethods.ClickOnGrowYourSkills();
        ////        Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAccessMessage(), "No Internet access message not found");
        ////        TeacherSupportCommonMethods.ClickOnMessageCloseButton();
        ////        TeacherSupportCommonMethods.ClickOnPrepareYourLesson();
        ////        Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAccessMessage(), "No Internet access message not found");
        ////        TeacherSupportCommonMethods.ClickOnMessageCloseButton();
        ////        TeacherSupportCommonMethods.ClickOnGetHelp();
        ////        Assert.IsTrue(TeacherSupportCommonMethods.VerifyNoInternetAccessMessage(), "No Internet access message not found");
        ////        TeacherSupportCommonMethods.ClickOnMessageCloseButton();
        ////        AutomationAgent.EnableNetwork();
        ////        NavigationCommonMethods.Logout();
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        Logger.InsertExceptionMessage(Ex.Message);
        ////        AutomationAgent.CreateScreenshot();
        ////        AutomationAgent.CloseApp();
        ////        throw;
        ////    }
        ////}
    }
}

   

