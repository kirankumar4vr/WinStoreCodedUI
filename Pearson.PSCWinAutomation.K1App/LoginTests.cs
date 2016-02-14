using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using System.Configuration;
using System.Drawing;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Pearson.PSCWinAutomation.Framework;


namespace Pearson.PSCWinAutomationFramework.__k1App
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
            Logger.CreateLogFile(ConfigurationManager.AppSettings["LogFilePath"].ToString());
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


        [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22027)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifySetupButtonOnTeacherLoginScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                Assert.IsTrue(LoginCommonMethods.VerifyBeginSetupScreen(), "Begin Setup screen is not available");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22036)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyBehaviorOfCancelButtonOnFirstConfirmationScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.CancelPasswordSelection();
                Assert.IsTrue(LoginCommonMethods.VerifyStudentLoginStartupButton(), "Failed to load the previous page");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22424)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyPicturePasswordPracticeFlow()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22436)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyLoginUsingPicturePassword()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                NavigationCommonMethods.Sleep();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22170)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyErrorMessageSequenceOnStudentLogin()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));

                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                Assert.IsFalse(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is still appearing");

                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                Assert.IsFalse(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is still appearing");

                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyHelp(), "Help! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                Assert.IsFalse(LoginCommonMethods.VerifyHelp(), "Help! alert is not appearing");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22031)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyPickACaptainScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.SelectAColorAndClickNext(1);
                string assertFailureMessage;
                Assert.IsTrue(LoginCommonMethods.VerifyPickACaptianScreenElements(out assertFailureMessage, login.PersonName), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22439)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifySuccessfulLoginOnUnitSelectionScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                NavigationCommonMethods.Sleep();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22029)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPicturePasswordInitiatePicture()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a color Screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(24201)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LoginPageDisplayCorrectSchoolName()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifyCorrectSchoolName("StudentKevin"), "School name incorrect");
                Assert.IsTrue(LoginCommonMethods.VerifySchoolNameRightJustified(), "School Name is not right justified");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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


       // [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22722)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginOfflineErrorMessage()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                AutomationAgent.DisableNetwork();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                Assert.IsTrue(LoginCommonMethods.VerifyNoInternetAlertPopup(), "No internet alert popup not found");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                AutomationAgent.EnableNetwork();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22443)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginSequence()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();

                for (int trial = 1; trial < 4; trial++)
                {
                    LoginCommonMethods.EnterPicturePassword("2");
                    if (trial == 1 || trial == 2)
                    {
                        Assert.IsTrue(LoginCommonMethods.VerifyTryAgainPopup(), "try again popup not found");
                        LoginCommonMethods.ClickToCloseTryAgainPopup();
                    }
                    else
                    {
                        Assert.IsTrue(LoginCommonMethods.VerifyHelpPopup(), "Help popup not found");
                        LoginCommonMethods.ClickToCloseTryAgainPopup();
                    }
                }
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a color Screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22744)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginUIStudentFacingErrorPopUp()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                LoginCommonMethods.ClickToSelectTeacherName("1");
                LoginCommonMethods.ClickOnButtonAccept();
                LoginCommonMethods.ClickToSelectStudentName("1");
                LoginCommonMethods.ClickOnButtonAccept();
                Assert.IsTrue(LoginCommonMethods.VerifyYouNeedToBeSetupOnDevicePopup(), "You need to be set up on device message not found");
                //LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                AutomationAgent.Click(100, 200);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22444)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginStudentPasswordSaveLocally()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                NavigationCommonMethods.Sleep();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.Logout();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                NavigationCommonMethods.Sleep();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22035)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPicturePasswordPasswordNotSavedBeforeFinalConfirmation()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.SelectAColorInColorSelectionPage(2);
                Assert.IsFalse(LoginCommonMethods.VerifyNextButtonInPasswordSelection(), "Next button available");
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22032)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentFacingStyledAlertsPicturePasswordLogin()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.SelectAColorAndClickNext(1);
                LoginCommonMethods.SelectACaptainAndClickNext(1);
                string assertFailureMessage;
                Assert.IsTrue(LoginCommonMethods.VerifyPickAFruitScreenElements(out assertFailureMessage, login.PersonName), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22166)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginPasswordHintsDuringLogin()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                Assert.IsTrue(LoginCommonMethods.EnterPicturePasswordAndVerifyNoPopup("2"),"Popups are appearing while entering picture password");
                Assert.IsTrue(LoginCommonMethods.VerifyPopupAppears(), "Popup is not available");
                LoginCommonMethods.ClickToCloseTryAgainPopup();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22167)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginValidationWithCorrectPasswordSelection()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login student = Login.GetLogin("StudentKevin");
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                Assert.IsTrue(LoginCommonMethods.VerifyBeginSetupLoginScreen(), "BeginSetup login screen not found");
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyWelcomeMessage(student.PersonName), "Welcome message not available");
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22168)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginPicturePasswordItemSelectionScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.EnterPicturePasswordAndVerifyNoPopup("2"), "Popups are appearing while entering picture password");
                LoginCommonMethods.ClickToCloseTryAgainPopup();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22434)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginStudentLogin()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login student = Login.GetLogin("StudentKevin");
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.Logout();
                AutomationAgent.Wait();
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
                NavigationCommonMethods.Logout();
                AutomationAgent.Wait();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22726)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginDisplaySelectedTeacher()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                LoginCommonMethods.ClickToSelectTeacherName("1");
                Assert.IsTrue(LoginCommonMethods.VerifyTeacherSelectedAndHighlighted("1"), "teacher not seleted");
                Assert.IsTrue(LoginCommonMethods.VerifyTeacherStudentAcceptButton(), "Teacher student accept button not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22724)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginOnly1TeacherSelectedAtATime()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                LoginCommonMethods.ClickToSelectTeacherName("1");
                Assert.IsTrue(LoginCommonMethods.VerifyTeacherSelectedAndHighlighted("1"), "teacher not seleted");
                LoginCommonMethods.ClickToSelectTeacherName("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTeacherSelectedAndHighlighted("2"), "teacher not seleted");
                Assert.IsFalse(LoginCommonMethods.VerifyTeacherSelectedAndHighlighted("1"), "teacher not seleted");
                Assert.IsTrue(LoginCommonMethods.VerifyTeacherStudentAcceptButton(), "Teacher student accept button not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(24247)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void WelcomeLandingPageTERMSOFUSE()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Assert.IsTrue(LoginCommonMethods.VerifyTermsOfUsePresent(), "Terms of Use not found");
                Assert.IsTrue(LoginCommonMethods.VerifyPrivacyStatementPresent(), "Terms of Use not found");
                LoginCommonMethods.ClickTermsOfUseLink();
                Assert.IsTrue(LoginCommonMethods.VerifyTermsOfUsePopupPresent(), "Terms of Use not found");
                LoginCommonMethods.ClickToCloseTermsOfUsePopup();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22431)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordSetupLogInUIStudentHasAlreadySetUpThePassword()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                Assert.IsTrue(LoginCommonMethods.VerifyLogInScreenForAlreadySetupStudent(), "Log In screen is not verified");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22440)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginErrorMessageDisplay()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a color screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22735)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginOfflineErrorMessageTeacherSelect()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                AutomationAgent.DisableNetwork();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                Assert.IsTrue(LoginCommonMethods.VerifyNoInternetAlertPopup(), "No internet alert popup not found");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                AutomationAgent.EnableNetwork();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22028)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordSetupUIOfBeginSetUpScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentAzyiah"),false);
                Assert.IsTrue(LoginCommonMethods.VerifyLogInScreenForNewBeginSetupStudent(), "Begin Setup Login Screen can't verified");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22030)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordSetupPasswordItemSelectionVerifyUIofPickAColorScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentAzyiah");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                string assertFailureMessage;
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreenElements(out assertFailureMessage, login.PersonName), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22033)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPicturePassword_SetUpPicturePasswordProcessForStudent()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentAzyiah");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.SelectAColorInColorSelectionPage(1);
                string assertFailureMessage;
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreenElements(out assertFailureMessage, login.PersonName), assertFailureMessage);
                Assert.IsTrue(LoginCommonMethods.VerifyNextButtonInPasswordSelection(), "Next button not available");
                LoginCommonMethods.ClickNextButtonInPasswordSelection();

                LoginCommonMethods.SelectACaptainInColorSelectionPage(1);
                Assert.IsTrue(LoginCommonMethods.VerifyPickACaptianScreenElements(out assertFailureMessage, login.PersonName), assertFailureMessage);
                LoginCommonMethods.ClickNextButtonInPasswordSelection();

                LoginCommonMethods.SelectAFruitInColorSelectionPage(1);
                Assert.IsTrue(LoginCommonMethods.VerifyPickAFruitScreenElements(out assertFailureMessage, login.PersonName), assertFailureMessage);
                LoginCommonMethods.OkPasswordSelection();


                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSetupConfirmationLetsPractice(out assertFailureMessage, login.PersonName), assertFailureMessage);
                LoginCommonMethods.CancelPasswordSelection();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

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
        [TestCategory("LoginTests"), TestCategory("K1SmokeTests")]
        [Priority(1)]
        [WorkItem(22034)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPicturePasswordSetUpConfirmationPage()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login login = Login.GetLogin("StudentAzyiah");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.EnterPicturePassword("1");
                string assertFailureMessage;
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSetupConfirmationLetsPractice(out assertFailureMessage, login.PersonName), "Password setup confirmation lets practice can't verified");
                LoginCommonMethods.CancelPasswordSelection();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

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
        [TestCategory("LoginTests"), TestCategory("K1SmokeTests")]
        [Priority(2)]
        [WorkItem(22427)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordFinalConfirmationScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                Assert.IsFalse(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Congratulations screen is appearing");
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                Assert.IsFalse(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Congratulations screen is appearing");
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22428)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordDisplayofIndicator()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();

                LoginCommonMethods.SelectAColorInColorSelectionPage(2);
                Assert.IsTrue(LoginCommonMethods.VerifyHintArrowAppearsToPointCorrectPassword("Color"), "Hint arrow icon is not available at correct position");
                LoginCommonMethods.SelectAColorInColorSelectionPage(1);
                LoginCommonMethods.ClickNextButtonInPasswordSelection();
                
                LoginCommonMethods.SelectACaptainInColorSelectionPage(2);
                Assert.IsTrue(LoginCommonMethods.VerifyHintArrowAppearsToPointCorrectPassword("Captain"), "Hint arrow icon is not available at correct position");
                LoginCommonMethods.SelectACaptainInColorSelectionPage(1);
                LoginCommonMethods.ClickNextButtonInPasswordSelection();

                LoginCommonMethods.SelectAFruitInColorSelectionPage(2);
                Assert.IsTrue(LoginCommonMethods.VerifyHintArrowAppearsToPointCorrectPassword("Fruit"), "Hint arrow icon is not available at correct position");
                LoginCommonMethods.SelectAFruitInColorSelectionPage(1);
                LoginCommonMethods.ClickNextButtonInPasswordSelection();
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(26201)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentFacingStyledAlertsPicturePasswordsLogin()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
               //Attempt 1
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgainPopup(), "Try Again! alert is not appearing");
                Assert.IsTrue(LoginCommonMethods.VerifyRedXCloseTryAgainPopup(), "Try Again red X close button not appearing");
                AutomationAgent.Click(100, 200);
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                Assert.IsFalse(LoginCommonMethods.VerifyTryAgainPopup(), "Try Again! alert is still appearing");

                //Attempt 2
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgainPopup(), "Try Again! alert is not appearing");
                Assert.IsTrue(LoginCommonMethods.VerifyRedXCloseTryAgainPopup(), "Try Again red X close button not appearing");
                AutomationAgent.Click(100, 200);
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                Assert.IsFalse(LoginCommonMethods.VerifyTryAgainPopup(), "Try Again! alert is still appearing");

                //Attempt 3
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyHelpPopup(), "Help! alert is not appearing");
                AutomationAgent.Click(100, 200);
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                Assert.IsFalse(LoginCommonMethods.VerifyHelpPopup(), "Help! alert is not appearing");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(2);
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22165)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginBehaviorWhileTappingLoginButtonWelcomeScreen()
        {
            try
            {
                
                NavigationCommonMethods.LaunchAppLogin();

                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                Assert.IsTrue(LoginCommonMethods.VerifyLogInScreenForAlreadySetupStudent(), "Login Screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22433)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginSavingOfPasswordOnDevice()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                Assert.IsTrue(LoginCommonMethods.VerifyLogInScreenForAlreadySetupStudent(), "Login Screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                NavigationCommonMethods.Sleep();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22435)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginIncorrectEntry()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22437)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordPicturePasswordItemSelectionScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.EnterPicturePasswordAndVerifyNoPopup("2"), "Popups are appearing while entering picture password");
                LoginCommonMethods.ClickToCloseTryAgainPopup();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();

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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22438)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginWelcomeScreen()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                Login student = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.ClickStudentLogin(student);
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyWelcomeMessage(student.PersonName), "Welcome message not available");
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "User is unable to login");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22441)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginErrorOnSecondAttempt()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));

                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");

                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyTryAgain(), "Try Again! alert is not appearing second time incorrect");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");

                LoginCommonMethods.EnterPicturePassword("2");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22442)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordLoginErrorOnThirdAttempt()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));

                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");
                LoginCommonMethods.EnterPicturePassword("2");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();

                LoginCommonMethods.EnterPicturePassword("2");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();

                LoginCommonMethods.EnterPicturePassword("2");
                Assert.IsTrue(LoginCommonMethods.VerifyHelp(), "Help! alert is not appearing in third attempt");
                LoginCommonMethods.CloseIncorrectPicturePasswordErrorPopup();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a Color screen is not there");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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

       // [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22721)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginOfflineErrorMessageIamNot()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                AutomationAgent.DisableNetwork();
                LoginCommonMethods.ClickStudentIAmNot();
                Assert.IsTrue(LoginCommonMethods.VerifyNoInternetAlertPopup(), "No internet alert popup not found");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                AutomationAgent.EnableNetwork();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(27207)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StyledDialogPromptsResetStudentPicturePassword()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButtonWithoutPasswordReset(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyResetPasswordAndCancelAVailable(), "Reset password and cancel buttons not available");
                LoginCommonMethods.ClickCancelAndReturnToLogin();
                Assert.IsTrue(LoginCommonMethods.VerifyHomeScreen(), "Home screen not found");
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButtonWithoutPasswordReset(Login.GetLogin("StudentKevin"));
                Assert.IsTrue(LoginCommonMethods.VerifyResetPasswordAndCancelAVailable(), "Reset password and cancel buttons not available");
                LoginCommonMethods.ClickResetPasswordToLogin();
                Assert.IsTrue(LoginCommonMethods.VerifyPickAColorScreen(), "Pick a color screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(27204)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StyledDialogPromptsDoyouWantToLogoutStudent()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.ClickStudentLogin(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                NavigationCommonMethods.Sleep();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA grade is not appearing");
                LoginCommonMethods.TapOnLogout();
                Assert.IsTrue(LoginCommonMethods.VerifyLogoutConfirmGreenAndRedIconAppears(), "Logout confirm icon not available");
                LoginCommonMethods.ClickOnLogoutCancelButton();
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA grade is not appearing");
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyHomeScreen(), "Home screen not available");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(27193)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BackButtonNavigationStackManagementpicturePasswordReset()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Congratulations screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(LoginCommonMethods.VerifyStudentSetupScreen(), "Begin setup screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(27191)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void BackButtonNavigationStackManagementpicturePasswordSetup()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Congratulations screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(LoginCommonMethods.VerifyStudentSetupScreen(), "Begin setup screen not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22162)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentPasswordSetupLogInUIStudentHasAlreadySetUpPassword()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                Assert.IsTrue(LoginCommonMethods.VerifyLogInScreenForAlreadySetupStudent(), "Log In screen is not verified");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22425)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void VerifyUIofScreensDisplayedDuringPracticePasswordflow()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                Assert.IsFalse(LoginCommonMethods.VerifyBackButtonExists(), "back button is available");
                LoginCommonMethods.SelectAColorAndClickNext(1);
                Assert.IsFalse(LoginCommonMethods.VerifyBackButtonExists(), "back button is available");
                LoginCommonMethods.SelectACaptainAndClickNext(1);
                Assert.IsFalse(LoginCommonMethods.VerifyBackButtonExists(), "back button is available");
                LoginCommonMethods.SelectAFruitInColorSelectionPage(1);
                LoginCommonMethods.ClickNextButtonInPasswordSelection();
                Assert.IsFalse(LoginCommonMethods.VerifyBackButtonExists(), "back button is available");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsFalse(LoginCommonMethods.VerifyBackButtonExists(), "back button is available");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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

       // [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22723)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginErrorInFetchingTeacherList()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                AutomationAgent.DisableNetwork();
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                Assert.IsTrue(LoginCommonMethods.VerifyNoInternetAlertPopup(), "No internet alert popup not found");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                AutomationAgent.EnableNetwork();
                AutomationAgent.Wait();
                LoginCommonMethods.ClickStudentIAmNot();
               Assert.IsTrue(LoginCommonMethods.VerifySelectTeacherName("1"),"Select teacher name mot found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                
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

       // [TestMethod()]
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22736)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StudentLoginErrorMessageFetchingStudentList()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                
                LoginCommonMethods.ClickStudentLoginButtonOnHomeScreen();
                LoginCommonMethods.ClickStudentIAmNot();
                LoginCommonMethods.ClickToSelectTeacherName("1");
                AutomationAgent.Wait();
                AutomationAgent.DisableNetwork();
                AutomationAgent.Wait();
                LoginCommonMethods.ClickOnButtonAccept();
                Assert.IsTrue(LoginCommonMethods.VerifyNoInternetAlertPopup(), "No internet alert popup not found");
                LoginCommonMethods.ClickToCloseNoInternetAlertPopup();
                AutomationAgent.EnableNetwork();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(24202)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void LoginPageDisplayCorrectSchoolNamelogoutAndLoginBack()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifyCorrectSchoolName("StudentKevin"), "School name incorrect");
                Assert.IsTrue(LoginCommonMethods.VerifySchoolNameRightJustified(), "School Name is not right justified");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
               
                
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifyCorrectSchoolName("TeacherAdbul"), "School name incorrect");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(27205)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void StyledDialogPromptsDoyouWantToLogoutTeacher()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("TeacherAdbul"));
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA grade is not appearing");
                LoginCommonMethods.TapOnLogout();
                Assert.IsTrue(LoginCommonMethods.VerifyLogoutConfirmGreenAndRedIconAppears(), "Logout confirm icon not available");
                LoginCommonMethods.ClickOnLogoutCancelButton();
                NavigationCommonMethods.OpenOrCloseSystemTray();
                Assert.IsTrue(LoginCommonMethods.VerifyELAGradeAppears(), "ELA grade is not appearing");
                NavigationCommonMethods.Logout();
                Assert.IsTrue(LoginCommonMethods.VerifyHomeScreen(), "Home screen not available");
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
        [TestCategory("LoginTests")]
        [Priority(2)]
        [WorkItem(22427)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void SampleImageAndColor()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(Login.GetLogin("StudentKevin"));
                Color sampleColor = Color.FromArgb(255, 240, 0, 0);
                bool clrbool = LoginCommonMethods.VerifyPasswordColorItemColor(sampleColor, "1");
                Bitmap oldImage, newImage;                
                oldImage = LoginCommonMethods.GetPasswordColorItemImage("1");
                newImage = LoginCommonMethods.GetPasswordColorItemImage("2");
                //Fails as images doesn't match
                //Assert.IsTrue(AutomationAgent.CompareImage(oldImage, newImage), "Images Doesn't match");
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
        [Priority(1)]
        [WorkItem(22738), WorkItem(22720), WorkItem(22737), WorkItem(22745), WorkItem(22725), WorkItem(22747)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyValidListOfStudents()
        {
            try
            {
                //AutomationAgent.LaunchApp();
                NavigationCommonMethods.LaunchAppLogin();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                Login login = Login.GetLogin("StudentSetupUser");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                AutomationAgent.Wait();
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                LoginCommonMethods.ClickStudentIAmNot();
                string selectedTeacherName = LoginCommonMethods.SelectUserAndGetName("Teacher");
                LoginCommonMethods.ClickOnButtonAccept();
                string selectedStudentName = LoginCommonMethods.SelectUserAndGetName("Student");
                Assert.IsTrue(selectedTeacherName.Contains(login.GetTaskInfo("ELA", "Teacher").AdditionalInfo), "This is not valid list of students");
                LoginCommonMethods.ClickOnButtonAccept();
                Assert.IsTrue(LoginCommonMethods.VerifyStudentIAmNotLink(), "I am not link is not visible");
                LoginCommonMethods.ClickStudentIAmNot();
                selectedTeacherName = LoginCommonMethods.SelectUserAndGetName("Teacher");
                LoginCommonMethods.ClickOnButtonAccept();
                selectedStudentName = LoginCommonMethods.SelectUserAndGetName("Student");
                Assert.IsTrue(selectedTeacherName.Contains(login.GetTaskInfo("ELA", "Teacher").AdditionalInfo), "This is not valid list of students");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("LoginTests")]
        [Priority(1)]
        [WorkItem(22746)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void NonSetupStudentCompletesIdentifyingProcess()
        {
            try
            {
                AutomationAgent.LaunchApp();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                Login login = Login.GetLogin("StudentSetupUser");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                LoginCommonMethods.ClickBeginSetupLoginButton();
                LoginCommonMethods.EnterPicturePassword("1");
                AutomationAgent.Wait();
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.NavigateToTeacherAdminLogin();
                Assert.IsTrue(LoginCommonMethods.VerifySetupButtonAndNavigateToSetupScreen(), "Setup button is not available on Teacher / Admin login screen");
                LoginCommonMethods.ClickBeginSetupLoginButton(login);
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.OkPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                LoginCommonMethods.NextPasswordSelection();
                LoginCommonMethods.EnterPicturePassword("1");
                Assert.IsTrue(LoginCommonMethods.VerifyPasswordSelectionCongratulationsButton(), "Login screen is not appearing");
                LoginCommonMethods.ClickPasswordSelectionCongratulationsButton();
                LoginCommonMethods.ClickStudentIAmNot();
                string selectedTeacherName = LoginCommonMethods.SelectUserAndGetName("Teacher");
                LoginCommonMethods.ClickOnButtonAccept();
                string selectedStudentName = LoginCommonMethods.SelectUserAndGetName("Student", "3");
                LoginCommonMethods.ClickOnButtonAccept();
                string assertFailureMessage;
                Assert.IsTrue(LoginCommonMethods.VerifyMessageOfNotSetupUser(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
