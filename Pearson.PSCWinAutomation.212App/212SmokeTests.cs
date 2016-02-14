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
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Configuration;
using System.Linq;

namespace Pearson.PSCWinAutomationFramework._212App
{
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class SmokeTests
    {
        public SmokeTests()
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
        [TestCategory("212SmokeTests")]
        [Priority(1)]
        [Owner("Kiran Anantapalli(Kiran.Anantapalli)")]
        public void DownloadAndInstallLatest212AppBundle()
        {
            try
            {
                string zipLocalPath, zipWebPath;
                zipWebPath = ConfigurationManager.AppSettings["WebZipFilePath"].ToString();
                zipLocalPath = ConfigurationManager.AppSettings["LocalZipFilePath"].ToString();
                WebClient wc = new WebClient();
                wc.DownloadFile(zipWebPath, zipLocalPath);
                if (Directory.Exists(ConfigurationManager.AppSettings["LocalBuildFolderPath"].ToString()))
                {
                    Directory.Delete(ConfigurationManager.AppSettings["LocalBuildFolderPath"].ToString(), true);
                }
                ZipFile.ExtractToDirectory(ConfigurationManager.AppSettings["LocalZipFilePath"].ToString(), ConfigurationManager.AppSettings["LocalBuildFolderPath"].ToString());
                var appBundleFile = Directory.EnumerateFiles(ConfigurationManager.AppSettings["LocalBuildFolderPath"].ToString(), "*.appxbundle", SearchOption.AllDirectories).FirstOrDefault<string>();
                AutomationAgent.InstallAppBundle(appBundleFile);
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                throw;
            }
        }
    }
}
