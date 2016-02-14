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
using System.Configuration;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for ContentManagerTests
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class ContentManagerTests
    {
        public ContentManagerTests()
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
        [TestCategory("ContentManagerTests")]
        [Priority(1)]
        [WorkItem(21840)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContentManagerUserSeesAppVersionInSettingsScreenContent()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager Page not found");
                Assert.IsTrue(ContentManagerCommonMethods.VerifyAppVersionLabelPresent(), "App version label not found in Content manager");
                Assert.AreEqual(ContentManagerCommonMethods.GetAppVersionFromContentManager(), "App Version:  " + ConfigurationManager.AppSettings["AppVersion"].ToString());
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

        [TestMethod]
        [TestCategory("ContentManagerTests")]
        [Priority(1)]
        [WorkItem(21841)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContentManagerUserSeesConfigurationCodeInSettingsScreenContent()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager Page not found");
                Assert.IsTrue(ContentManagerCommonMethods.VerifyConfigCodeLabelPresent(), "Config code label not found in Content manager");
                Assert.AreEqual(ContentManagerCommonMethods.GetConfigInfoFromContentManager(), "Conﬁguration Code:  " + ConfigurationManager.AppSettings["ConfigCode"].ToString());
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

        [TestMethod]
        [TestCategory("ContentManagerTests")]
        [Priority(1)]
        [WorkItem(21843)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContentManagerUserSeesCachingServerStatusInSettingsScreenContent()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager Page not found");
                Assert.IsTrue(ContentManagerCommonMethods.VerifyCachingServerStatusLabelPresent(), "Caching Server label not found in Content manager");
                Assert.AreEqual(ContentManagerCommonMethods.GetCachingServerFromContentManager(), "Caching Server:  " + ConfigurationManager.AppSettings["CachingServer"].ToString());
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

        [TestMethod]
        [TestCategory("ContentManagerTests")]
        [Priority(1)]
        [WorkItem(21878)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ContentManagerUserSeesGlobalNavIcons()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager Page not found");
                Assert.IsTrue(ContentManagerCommonMethods.VerifyGlobalNavIconsForContentManager(), "App version label not found in Content manager");
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



        //Network Dependent

        [TestMethod]
        [TestCategory("ContentManagerTests")]
        [Priority(1)]
        [WorkItem(21837)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Nonewupdatesavailableappearsiftherearenoupdatestodownload()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(NavigationCommonMethods.VerifyContentManagerPage(), "Content Manager Page not found");
                ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyCheckUpdateButton(), "No Update Button");
                ContentManagerCommonMethods.ClickOnCheckUpdate();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewupdateMsg(), "No Msg");
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
        [TestCategory("ContentManagerTests")]
        [WorkItem(21839), WorkItem(16124), WorkItem(22145)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyStatusMessagesInContentManager()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "NewUnitToDownload");
                NavigationCommonMethods.ClickContentManagerButton();
                ContentManagerCommonMethods.ClickOnCheckUpdate();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewupdateMsg(), "No new updates available message is not found");
                NavigationCommonMethods.NavigateToELA();
                NavigationCommonMethods.NavigateToELAGrade(taskInfo.Grade);
                NavigationCommonMethods.ClickELAUnitFromUnitLibrary(taskInfo.Unit);
                NavigationCommonMethods.ClickStartInELAUnitLibrary(taskInfo.Unit+1);
                NavigationCommonMethods.ClickELALessonFromLessonBrowser(taskInfo.Lesson);
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.ClickLessonPreviewCloseButton(taskInfo.Lesson+1);
                AutomationAgent.Wait();
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingItemsMessage(), "Downloading items message is not found");
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
        ////[TestCategory("ContentManagerTests")]
        ////[WorkItem(22409)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void DownloadingItemsCompletedListofDownloadQueueIsBlank()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.ClickContentManagerButton();

        ////        if (!ContentManagerCommonMethods.VerifyShowDetailsButtonPresent())
        ////        {
        ////            NavigationCommonMethods.NavigateToELA();
        ////            LessonBrowserCommonMethods.ClickAddGrades();
        ////            int gradeNo = LessonBrowserCommonMethods.SelectGrade();
        ////            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////            AutomationAgent.Wait(20000);
        ////            NavigationCommonMethods.ClickContentManagerButton();
        ////        }

        ////        ContentManagerCommonMethods.ClickShowDetails();
        ////        Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
        ////        ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear();
        ////        Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingItemsMessage(), "downloading content no appears");
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



        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(21845)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserSeeDateAndTimeInUpperLeftCorner()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickContentManagerButton();
                AutomationAgent.Wait();
                string date = ContentManagerCommonMethods.GetUpdatedDateFromContentManager().Replace("Updated on  ", "");
                if (date != "N/A")
                {
                    DateTime date1 = DateTime.Parse(date);
                }
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
        [TestCategory("ContentManagerTests")]
        [WorkItem(22408)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenThereAreNoDownloadsOrNoItemInQueueListofDownloadQueueBlank()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.ClickContentManagerButton();
                ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear();
                Assert.IsFalse(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
                Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingItemsMessage(), "downloading content no appears");
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
        ////[TestCategory("ContentManagerTests")]
        ////[WorkItem(22410)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void QueueisUpdatedAndTotalNumberDownloadItemsinDownloadQueueisDecremented()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.ClickContentManagerButton();

        ////        if (!ContentManagerCommonMethods.VerifyShowDetailsButtonPresent())
        ////        {
        ////            NavigationCommonMethods.NavigateToELA();
        ////            LessonBrowserCommonMethods.ClickAddGrades();
        ////            int gradeNo = LessonBrowserCommonMethods.SelectGrade();
        ////            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////            AutomationAgent.Wait(20000);
        ////            NavigationCommonMethods.ClickContentManagerButton();
        ////        }

        ////        ContentManagerCommonMethods.ClickShowDetails();
        ////        Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
        ////        int DownloadingItems = ContentManagerCommonMethods.GetDownloadingItemsNumber();
        ////        AutomationAgent.Wait();
        ////        int DownloadingItemsdecremented = ContentManagerCommonMethods.GetDownloadingItemsNumber();
        ////        if (DownloadingItemsdecremented == DownloadingItems)
        ////        {
        ////            AutomationAgent.Wait();
        ////            DownloadingItemsdecremented = ContentManagerCommonMethods.GetDownloadingItemsNumber();
        ////        }

        ////        Assert.IsTrue(DownloadingItemsdecremented <= DownloadingItems, "no. of downloading items not getting decremented");
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

        ////[TestMethod()]
        ////[TestCategory("ContentManagerTests")]
        ////[WorkItem(21797)]
        ////[Priority(2)]
        ////[Owner("Akanksha Gautam(akanksha.gautam)")]
        ////public void ContentManagerContentUpdateLogShowsUpdatesByDate()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.ClickContentManagerButton();
        ////        AutomationAgent.Wait();
        ////        if (!ContentManagerCommonMethods.VerifyUpdatesAvaialble())
        ////        {
        ////            NavigationCommonMethods.NavigateToELA();
        ////            LessonBrowserCommonMethods.ClickAddGrades();
        ////            LessonBrowserCommonMethods.SelectGrade();
        ////            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////            NavigationCommonMethods.ClickContentManagerButton();
        ////        }

        ////        string date = ContentManagerCommonMethods.GetDateFromUpdateGroup(1);
        ////        DateTime date1 = DateTime.Parse(date);
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

        ////[TestMethod()]
        ////[TestCategory("ContentManagerTests")]
        ////[WorkItem(22406)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void DownloadItemsAreInQueueDownloadQueueiNotVisible()
        ////{
        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        AutomationAgent.Wait();
        ////        NavigationCommonMethods.ClickContentManagerButton();
        ////        Assert.IsTrue(ContentManagerCommonMethods.VerifyShowDetailsButtonPresent(), "Show details no found");
        ////        ContentManagerCommonMethods.WaitForCheckToUpdatesToAppear();
        ////        AutomationAgent.Wait();
        ////        ContentManagerCommonMethods.ClickOnCheckUpdate();
        ////        AutomationAgent.Wait();
        ////        Assert.IsTrue(ContentManagerCommonMethods.VerifyNoNewupdateMsg(), "no new updates label not found");
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

        ////[TestMethod()]
        ////[TestCategory("ContentManagerTests")]
        ////[WorkItem(22407)]
        ////[Priority(2)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void DownloadItemsAreIncrementedIfAdded()
        ////{

        ////    try
        ////    {
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        NavigationCommonMethods.LoginApp(login);
        ////        NavigationCommonMethods.ClickContentManagerButton();
        ////        int DownloadingItems = ContentManagerCommonMethods.GetDownloadingItemsNumber();
        ////        AutomationAgent.Wait();
        ////        NavigationCommonMethods.NavigateToELA();
        ////        LessonBrowserCommonMethods.ClickAddGrades();
        ////        LessonBrowserCommonMethods.SelectGrade();
        ////        LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        ////        AutomationAgent.Wait();
        ////        NavigationCommonMethods.ClickContentManagerButton();
        ////        Assert.IsTrue(ContentManagerCommonMethods.VerifyQueueContent(), "queue content not found");
        ////        int DownloadingItemsIncrement = ContentManagerCommonMethods.GetDownloadingItemsNumber();
        ////        AutomationAgent.Wait();
        ////        Assert.IsTrue(DownloadingItemsIncrement > DownloadingItems, "no. of downloading items not getting increment");
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

        [TestMethod()]
        [TestCategory("ContentManagerTests")]
        [WorkItem(21793), WorkItem(21804)]
        [Priority(2)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void HistoryLogOnlyChangesForExistingCourses()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                TaskInfo taskInfo = login.GetTaskInfo("ELA", "Notebook");
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsTrue(ContentManagerCommonMethods.VerifyCheckToUpdatesOrDownloadingItemsAppear(), "check for updates or downloading does not appears in Content Manager");
                Assert.IsTrue(ContentManagerCommonMethods.VerifyDownloadingQueueItem("ELA", taskInfo.Grade), "Downloading history for non-sectioned content is not found");
                NavigationCommonMethods.NavigateMyDashboard();
                NavigationCommonMethods.ClickContentManagerButton();
                Assert.IsFalse(ContentManagerCommonMethods.VerifyDownloadingQueueItem("ELA", 5), "Downloading history for non-sectioned content is found");
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
    }
}
   

