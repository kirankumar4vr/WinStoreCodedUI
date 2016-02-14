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
using System.Drawing;


namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class LoginTests
    {
        public LoginTests()
        {
        }

        #region Additional test attributes

        [AssemblyInitialize]
        public static void _212AssemblyInitialize(TestContext testContext)
        {
            Logger.CreateLogFile(Logger.CreateLogsFolder(ConfigurationManager.AppSettings["LogFilePath"].ToString()));
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }
        [TestInitialize]
        public void TestInitialize()
        {
            Logger.InsertTestHeaderLine(testContextInstance.TestName);
        }


        [AssemblyCleanup]
        public static void _212AssemblyCleanup()
        {
            Logger.InsertEndLine();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

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

       // [TestMethod]
        public void LoginLogoutTest()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(12, 1, 2, 2);
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

       // [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(111111)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TaskInfoTest()
        {
            try
            {
                Login login = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(login);
                NavigationCommonMethods.NavigateToTaskfromSytemTrayMenu(login.GetTaskInfo("ELA", "Notebook"));
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }

        //[TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22222)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SampleImageAndColor()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Color sampleColor = Color.FromArgb(255, 5, 38, 124);
                bool clrbool = LoginCommonMethods.VerifyLoginButtonColor(sampleColor);
                Bitmap oldImage, newImage;
                oldImage = LoginCommonMethods.GetLoginButtonColor();
                newImage = LoginCommonMethods.GetLoginButtonColor();
                //Fails as images doesn't match
                Assert.IsTrue(AutomationAgent.CompareImage(oldImage, newImage), "Images Doesn't match");
                oldImage.Dispose();
                newImage.Dispose();
            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                throw;
            }
        }



        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17670)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserIsLoggedOutWhenTappingLogOut()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System Tray not opened");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(19114)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void NoRemainingsOfPreviousScreenAreVisibleAfterLogOutUserIsBroughtBackToLoginScreen()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System Tray not opened");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.Logout();
                Assert.IsFalse(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System tray Button available");
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17675)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LoginWithIncorrectPasswordResultsWithErrorMessage()
        {
            try
            {
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("WrongPwdTeacher"));
                Assert.IsTrue(LoginCommonMethods.VerifyLoginFailed(), "Login Failed message not found");
                LoginCommonMethods.ClickOnCloseButton();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17677)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ErrorMessageOnUnsuccessfulLoginIsNativeIosPopUp()
        {
            try
            {
                AutomationAgent.LaunchApp();
                NavigationCommonMethods.LoginApp(Login.GetLogin("InvalidCredentials"));
                Assert.IsTrue(LoginCommonMethods.VerifyLoginFailed(), "Login failed message not found");
                LoginCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login screen not found");
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
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(17676)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LogInButtonTextChangesWithSpinner()
        {

            try
            {
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("Sec9Apatton"));
                Assert.IsFalse(LoginCommonMethods.VerifyLoginButtonAvailable(), "Login button available");
                NavigationCommonMethods.WaitForSystemTrayToAppear();
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
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(1)]
        [WorkItem(17681)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AppWillRememberLastEnteredUsernameOnLoginScreenSuccessfulLogin()
        {
            try
            {
                Login UserLogin = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(UserLogin);
                NavigationCommonMethods.Logout();
                string UserName = LoginCommonMethods.GetTextFromUsername();
                Assert.AreEqual(UserLogin.UserName, UserName,"User Names not same");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17665)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SupportingTextDisappearsFromUsernamePasswordFields()
        {
            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.SetTextInUsername("");
                Assert.IsTrue(LoginCommonMethods.VerifyUserNameTextAvailable(), "User Name text not found");
                LoginCommonMethods.SetTextInPassword("");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordTextAvailable(), "Password text not found");
                Login UserLogin = Login.GetLogin("Sec9Apatton");
                LoginCommonMethods.SetTextInUsername(UserLogin.UserName);
                string newUserName = LoginCommonMethods.GetTextFromUsername();
                LoginCommonMethods.SetTextInPassword(UserLogin.Password);
                Assert.IsFalse(LoginCommonMethods.VerifyUserNameTextAvailableAfterEditing(), "User Name text found");
                //Assert.IsFalse(LoginCommonMethods.VerifyPasswordTextAvailableAfterEditing(), "Password text found");

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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17669)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LoginScreenFieldsAreAsFollowsUserNamePasswordLogIn()
        {
            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.CloseCrashReportsPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login screen not found");
                LoginCommonMethods.SetTextInUsername("UserName");
                LoginCommonMethods.ClickXbuttonUserName();
                Assert.IsTrue(LoginCommonMethods.VerifyUserNameTextAvailable(), "User Name text not found");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordTextAvailable(), "Password text not found");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17679)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserFirstAndLastNameAppearInSystemTray()
        {
            try
            {
                Login UserLogin = Login.GetLogin("Sec9Apatton");
                NavigationCommonMethods.LoginApp(UserLogin);
                AutomationAgent.Wait();
                NavigationCommonMethods.ClickSystemTrayButton();
                string UserNameFull = LoginCommonMethods.GetCurrentUserName().Replace("\r\n", ",");
                string[] UserName = UserNameFull.Split(',');
                string[] ActualUserName = UserLogin.PersonName.Split(' ');
                Assert.AreEqual(UserName[0], ActualUserName[0]);
                Assert.AreEqual(UserName[1], ActualUserName[1]);
                NavigationCommonMethods.ClickOnSystemTrayClose();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17664)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void ErrorMessageOnUnsuccessfulLogin1()
        {

            try
            {
                AutomationAgent.LaunchApp();
                Login UserLogin = Login.GetLogin("Grade2Sswanson2");
                LoginCommonMethods.SetTextInUsername("");
                LoginCommonMethods.SetTextInPassword(UserLogin.Password);
                LoginCommonMethods.ClickOnLoginButton();
                Assert.IsTrue(LoginCommonMethods.VerifyUserNameRequiredPopup(), "Uer name required popup not found");
                LoginCommonMethods.ClickUsernamePasswordOkButton();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17666)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void RemovalIconXEsists()
        {

            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.CloseCrashReportsPopup();
                LoginCommonMethods.SetTextInUsername("UserName");
                string EnteredUserName = LoginCommonMethods.GetTextFromUsername();
                Assert.IsFalse(string.IsNullOrEmpty(EnteredUserName), "User Name filed not empty");
                Assert.IsTrue(LoginCommonMethods.VerifyXbuttonUserNameExist(), "X button for user name not found");
                LoginCommonMethods.ClickXbuttonUserName();
                string DeletedUserName = LoginCommonMethods.GetTextFromUsername();
                Assert.IsTrue(string.IsNullOrEmpty(DeletedUserName), "User Name filed empty");
                LoginCommonMethods.SetTextInPassword("Password");
                //Assert.IsFalse(LoginCommonMethods.VerifyPasswordTextAvailableAfterEditing(), "Default Password text found");
                Assert.IsTrue(LoginCommonMethods.VerifyXbuttonPasswordExist(), "X button for user name not found");
                LoginCommonMethods.ClickXbuttonPassword();
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordTextAvailable(), "Default Password text not found");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17689)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LoginScreenCopyrightNoticeDisplayedAtBottom()
        {

            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.CloseCrashReportsPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyCopyrightLabel(), "Copyright label not found");
                Assert.IsTrue(LoginCommonMethods.VerifyTermsofUseLabel(), "Terms and conditions not found");
                Assert.IsTrue(LoginCommonMethods.VerifyPrivacyPolicyLabel(), "Terms and conditions not found");
                Assert.IsTrue(LoginCommonMethods.VerifyLabelsAreUnderlined(), "Labels are not underlined");

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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17696)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TappingLogOutUserIsLoggedOutAndMovedToLoginScreen()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.ClickSystemTrayButton();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayOpen(), "System Tray not opened");
                NavigationCommonMethods.ClickOnSystemTrayClose();
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(19374)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void UserThatHadLoggedOutCanLogBackIn()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                AutomationAgent.Wait();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System Tray not found");
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                AutomationAgent.Wait();
                Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System Tray not found");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17690)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void TermsofUsedisplayedwhenusertapsTermsofUselink()
        {

            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.CloseCrashReportsPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyCopyrightLabel(), "Copyright label not found");
                Assert.IsTrue(LoginCommonMethods.VerifyTermsofUseLabel(), "Terms and conditions not found");
                LoginCommonMethods.ClickOnTermsofUseLabel();
                Assert.IsTrue(LoginCommonMethods.verifyTermsOfUseOpen(), "Terms and conditions not Open");
                Assert.IsTrue(LoginCommonMethods.verifyTermsOfUseOpenScrollable(), "Terms and conditions not Scrollable");
                LoginCommonMethods.ClickOnTermsofUseClose();

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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17691)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void PrivacyPolicydisplayedwhenusertapsPrivacyPolicylink()
        {

            try
            {
                AutomationAgent.LaunchApp();
               
                Assert.IsTrue(LoginCommonMethods.VerifyCopyrightLabel(), "Copyright label not found");
                Assert.IsTrue(LoginCommonMethods.VerifyPrivacyPolicyLabel(), "Privacy Policy not found");
                LoginCommonMethods.ClickOnPrivacyPolicy();
                Assert.IsTrue(LoginCommonMethods.verifyPrivacyPolicyOpen(), "Privacy Policy not Open");
                Assert.IsTrue(LoginCommonMethods.verifyPrivacyPolicyScrollable(), "Privacy Policy not Scrollable");
                LoginCommonMethods.ClickOnPrivacyPolicyClose();

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
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(17667)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void PasswordTextIsHidden()
        {
            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.SetTextInPassword("");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordTextAvailable(), "Password text not found");
                LoginCommonMethods.SetTextInPassword("Hidden");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordTextIsHidden(), "Password text is not hidden");
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
        [TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        [Priority(2)]
        [WorkItem(17668)]
        [Owner("Anshul Mudgal(anshul.mudgal)")]
        public void LogingInWithEmptyPasswordGivesErrorMessage()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                LoginCommonMethods.SetTextInUsername("UserName");
                LoginCommonMethods.SetTextInPassword("pwd");
                LoginCommonMethods.ClickXbuttonPassword();
                LoginCommonMethods.ClickOnLoginButton();
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordRequiredPopup(), "Password Required Popup Is Not Found");
                LoginCommonMethods.ClickOnCloseButton();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login screen not found");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17682)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void AppWillNotRememberLastEnteredUsernameOnLoginScreenWhenLoginFailed()
        {
            try
            {
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
                NavigationCommonMethods.NavigateMyDashboard();
                Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard is not present");
                NavigationCommonMethods.Logout();
                string userName = LoginCommonMethods.GetTextFromUsername();
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("InvalidCredentials"));
                Assert.IsTrue(LoginCommonMethods.VerifyLoginFailed(), "login failded message not found");
                LoginCommonMethods.ClickOnCloseButton();
                AutomationAgent.CloseApp();
                AutomationAgent.LaunchApp();
                string userName1 = LoginCommonMethods.GetTextFromUsername();
                Assert.AreEqual(userName, userName1, "New username is not similar to the earlier username");
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
        [TestCategory("LoginTests")]
        [Priority(3)]
        [WorkItem(22044)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void ToVerifyOkAlerMessage()
        {
            try
            {
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("WrongPwdTeacher"));
                Assert.IsTrue(LoginCommonMethods.VerifyLoginFailed(), "login failed message not found");
                LoginCommonMethods.ClickOnCloseButton();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(15932)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void DefaultTextInEditFieldOfLogInScreenIsContrastWithBackground()
        {
            try
            {
                AutomationAgent.LaunchApp();
                LoginCommonMethods.SetTextInUsername("");
                Assert.IsTrue(LoginCommonMethods.VerifyUserNameTextAvailable(), "User Name text not found");
                LoginCommonMethods.SetTextInPassword("");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordTextAvailable(), "Password text not found");
                Assert.IsTrue(LoginCommonMethods.VerifyTextInContrastWithBackground(), "User Name and Password are not in contrast with the background");

            }
            catch (Exception Ex)
            {
                Logger.InsertExceptionMessage(Ex.Message);
                AutomationAgent.CreateScreenshot();
                AutomationAgent.CloseApp();
                throw;
            }
        }



        /*Network dependent*/

        ////[TestMethod()]
        ////[TestCategory("LoginTests")]
        ////[Priority(1)]
        ////[WorkItem(26214)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void AppRememberUserForOfflineUseIfUserLoggedInAtLeastOnce()
        ////{

        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System Tray icon not available");
        ////        NavigationCommonMethods.Logout();
        ////        Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
        ////        AutomationAgent.DisableNetwork();
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        Assert.IsTrue(NavigationCommonMethods.VerifySystemTrayButtonAvailable(), "System Tray icon not available");
        ////        NavigationCommonMethods.Logout();
        ////        AutomationAgent.EnableNetwork();

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
        ////[TestCategory("LoginTests")]
        ////[Priority(1)]
        ////[WorkItem(17683)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void WhenWifiOffAndUserInitiallyLogsInThenNetworkUnavailableMessageAppearsRequiresHardReset()
        ////{

        ////    try
        ////    {
        ////        AutomationAgent.DisableNetwork();
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec6Efoster"));
        ////        Assert.IsTrue(LoginCommonMethods.VerifyNoWifiPopUp(), "No Wifi popup not found");
        ////        LoginCommonMethods.ClickUsernamePasswordOkButton();
        ////        AutomationAgent.EnableNetwork();
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
        ////[TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        ////[Priority(1)]
        ////[WorkItem(17684)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void AppRemembersUserForOfflineUseIfUserLoggedInAtLeastOnce()
        ////{

        ////    try
        ////    {
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.Logout();
        ////        AutomationAgent.DisableNetwork();
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));
        ////        NavigationCommonMethods.NavigateMyDashboard();
        ////        Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard not found");
        ////        NavigationCommonMethods.Logout();
        ////        AutomationAgent.EnableNetwork();
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
        ////[TestCategory("LoginTests")]
        ////[Priority(1)]
        ////[WorkItem(26213)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void WhenWifiOffAndStaffUserInitiallyLogsInThenNetworkUnavailableMessageAppears()
        ////{

        ////    try
        ////    {
        ////        AutomationAgent.DisableNetwork();
        ////        AutomationAgent.LaunchApp();
        ////        Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "LoginScreen Not Found");
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("awhite"));
        ////        Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Not Prompting");
        ////        LoginCommonMethods.ClickUsernamePasswordOkButton();
        ////        AutomationAgent.EnableNetwork();
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
        ////[TestCategory("LoginTests")]
        ////[Priority(1)]
        ////[WorkItem(26212)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void WhenWifiOffAndNonSectionedUserInitiallyLogsInThenNetworkUnavailableMessageAppears()
        ////{

        ////    try
        ////    {
        ////        AutomationAgent.DisableNetwork();
        ////        AutomationAgent.LaunchApp();
        ////        Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "LoginScreen Not Found");
        ////        NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("GustadMody"));
        ////        Assert.IsTrue(LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Not Prompting");
        ////        LoginCommonMethods.ClickUsernamePasswordOkButton();
        ////        AutomationAgent.EnableNetwork();
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
        ////[TestCategory("LoginTests"), TestCategory("212SmokeTests")]
        ////[Priority(1)]
        ////[WorkItem(20515)]
        ////[Owner("Anshul Mudgal(anshul.mudgal)")]
        ////public void UserGetsNoWifiMessageYouMustBeConnectedToTheInternetToLogIn()
        ////{

        ////    try
        ////    {
        ////        AutomationAgent.DisableNetwork();
        ////        AutomationAgent.LaunchApp();
        ////        Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "LoginScreen Not Found");
        ////        NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("Student1"));
        ////        Assert.AreEqual<bool>(true, LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Not Prompting");
        ////        LoginCommonMethods.ClickUsernamePasswordOkButton();
        ////        AutomationAgent.EnableNetwork();
        ////        NavigationCommonMethods.LoginApp(Login.GetLogin("Student1"));
        ////        Assert.AreEqual<bool>(false, LoginCommonMethods.VerifyNoWifiPopUp(), "NoWifiPopUp Is Prompting");
        ////        //Assert.IsTrue(NavigationCommonMethods.VerifyDashboard(), "Dashboard Not Found");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(23124)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedStudentProperBehaviorInitialLogin()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));

                Assert.IsTrue(LoginCommonMethods.VerifyInitialSetupProgressScreen(), "Initial setup prepare screen not found");
                LoginCommonMethods.WaitForDownloadToComplete();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22147)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedTeacherProperBehaviorInitialLogin()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginApp(Login.GetLogin("Sec9Apatton"));

                Assert.IsTrue(LoginCommonMethods.VerifyInitialSetupProgressScreen(), "Initial setup prepare screen not found");
                LoginCommonMethods.WaitForDownloadToComplete();
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
        [TestCategory("LoginTests")]
        [Priority(3)]
        [WorkItem(15921)]
        [Owner("Akanksha Gautam(akanksha.gautam)"), TestCategory("212SmokeTests")]
        public void WhenNonSectionedUserTapsCancelOnGradeSelectionIsBroughtToLogInScreen()
        {
            try
            {
                AutomationAgent.LaunchApp();
                NavigationCommonMethods.LoginApp(Login.GetLogin("GustadMody"));
                Assert.IsTrue(LoginCommonMethods.VerifyGradesSelectionScreenOnFirstLogin(), "Grades Selection screen not present");
                LessonBrowserCommonMethods.ClickCancelButton();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Log in screen not present");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22143)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SectionedStudentBehaviourInitialLogin()
        {
            try
            {

                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginApp(Login.GetLogin("StudentBruceSec9Apatton"));
                Assert.IsTrue(LoginCommonMethods.VerifyInitialSetupProgressScreen(), "Initial setup prepare screen not found");
                LoginCommonMethods.WaitForDownloadToComplete();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(16073), WorkItem(22144)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyAddGradeForNonSectionedTeacherOnFirstLogin()
        {
            try
            {
                Login login = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Add grade continue button enabled");
                int UnitNo = LessonBrowserCommonMethods.SelectGrade();
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(16077)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENInitialoginNonSectionedUserThenUserCanAddOnlyOneGrade()
        {
            try
            {
                Login login = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Add grade continue button enabled");
                int UnitNo = LessonBrowserCommonMethods.SelectGrade();
                Assert.IsTrue(LessonBrowserCommonMethods.VerifySelectedGradeChecked(UnitNo), "selected 1 grade not checked");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(17678)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENInitialoginNonSectionedUserThenNoGradeSelected()
        {
            try
            {
                Login login = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                Assert.IsTrue(LessonBrowserCommonMethods.VerifyNoGradeChecked(), "at least 1 grade is checked");
                Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Add grade continue button enabled");
                LessonBrowserCommonMethods.ClickCancelButton();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(15966)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WHENInitialoginGradeDownloadedUserSeePreparingLessonsOverlay()
        {
            try
            {
                Login login = Login.GetLogin("GustadMody");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                int grade =LoginCommonMethods.ClickAndContinueGradeSelected();
                AutomationAgent.Wait();
                Assert.IsTrue(LoginCommonMethods.VerifyInitialSetupProgressScreen(), "Initial setup prepare screen not found");
                LoginCommonMethods.WaitForDownloadToComplete();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(19361)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WhenUserSelectGradeTwelveDownloadedPreparingLessonsOverlay()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginAppWithoutWaiting(Login.GetLogin("GustadMody"));
                LoginCommonMethods.AddSpecifiedGrade(12);
                Assert.IsTrue(LoginCommonMethods.VerifyInitialSetupProgressScreen(), "Initial setup prepare screen not found");
                LoginCommonMethods.WaitForDownloadToComplete();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(17687)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void InitialLoginDownloadSpinnerTexTInformationPreparingLesson()
        {
            try
            {
                AutomationAgent.LaunchApp();
                Login login = Login.GetLogin("GustadMody");
                Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
                NavigationCommonMethods.LoginAppWithoutWaiting(login);
                int grade = LoginCommonMethods.ClickAndContinueGradeSelected();
                Assert.IsTrue(LoginCommonMethods.VerifyPreparingLessonsStep1(), "prepairing lessons (step 1 of 2) not found");
                Assert.IsTrue(LoginCommonMethods.VerifyPreparingLessonsStep2(), "prepairing lessons (step 2 of 2) not found");
                LoginCommonMethods.WaitForDownloadToComplete();
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
        ////[TestCategory("LoginTests")]
        ////[Priority(1)]
        ////[WorkItem(22157)]
        ////[Owner("Madhav Purohit(madhav.purohit)")]
        ////public void InitialLoginAfterNoWiFiAnotherUserLoggedIn()
        ////{
        ////    try
        ////    {
        ////        AutomationAgent.LaunchApp();
        ////        Login login = Login.GetLogin("Sec9Apatton");
        ////        Assert.IsTrue(LoginCommonMethods.VerifyLoginScreen(), "Login Screen not found");
        ////        NavigationCommonMethods.LoginAppWithoutWaiting(login);
        ////        AutomationAgent.DisableNetwork();
        ////        Assert.IsTrue(LoginCommonMethods.VerifyNoWifiPopUp(), "No Wifi pop up not present");
        ////        LoginCommonMethods.ClickUsernamePasswordOkButton();
        ////        AutomationAgent.CloseApp();
        ////        AutomationAgent.LaunchApp();
        ////        login = Login.GetLogin("GustadMody");
        ////        NavigationCommonMethods.LoginAppWithoutWaiting(login);
        ////        Assert.IsFalse(LessonBrowserCommonMethods.VerifyAddGradeContinueButtonEnabled(), "Continue button is not present");
        ////        int UnitNo1 = LoginCommonMethods.ClickAndContinueGradeSelected();
        ////        AutomationAgent.EnableNetwork();
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
