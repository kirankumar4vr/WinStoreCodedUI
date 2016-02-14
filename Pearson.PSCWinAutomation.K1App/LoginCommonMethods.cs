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

namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for LoginCommonMethods
    /// </summary>

    public static class LoginCommonMethods
    {
        /// <summary>
        /// Logs into the app using Teacher / Admin screen
        /// </summary>
        /// <param name="login">Login object</param>
        public static void LoginUsingTeacherAdminWithoutWaitingForSystemTray(Login login)
        {
            AutomationAgent.LaunchApp();
            NavigationCommonMethods.NavigateToTeacherAdminLogin();
            AutomationAgent.SetText("LoginView", "UserNameTextboxOnTeacherAdminScreen", login.UserName);
            AutomationAgent.SetText("LoginView", "PasswordTextboxOnTeacherAdminScreen", login.Password);
            AutomationAgent.Click("LoginView", "LoginButtonOnTeacherAdminScreen");
        }



        ///// <summary>
        ///// Clicks Begin setup with valid user credentials. Waits for either ResetPassword or Picture Password startup
        ///// </summary>
        ///// <param name="login">Login object</param>
        //public static void ClickBeginSetupButton(Login login)
        //{
        //    AutomationAgent.SetText("LoginView", "UserNameTextboxOnStudentSetupScreen", login.UserName);
        //    AutomationAgent.SetText("LoginView", "PasswordTextboxOnStudentSetupScreen", login.Password);
        //    AutomationAgent.Click("LoginView", "BeginSetupButton");
        //    System.Threading.Thread.Sleep(60000);
        //    if (AutomationAgent.VerifyControlExists("LoginView", "StudentLoginPasswordResetPassword"))
        //    {
        //        AutomationAgent.Click("LoginView", "StudentLoginPasswordResetPassword");
        //    }
        //    else
        //    {
        //        while (!AutomationAgent.VerifyControlExists("LoginView", "StudentLoginStartupButton"))
        //        {
        //            AutomationAgent.WaitForControlExists("LoginView", "StudentLoginStartupButton");
        //        }
        //        AutomationAgent.Click("LoginView", "StudentLoginStartupButton");
        //    }
        //}

        /// <summary>
        /// Enters one cycle picture password based on index
        /// </summary>
        /// <param name="itemIndex">index of color/captain/fruit</param>
        public static void EnterPicturePassword(string itemIndex)
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, itemIndex);
            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }

            AutomationAgent.Click("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, itemIndex);
            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }

            AutomationAgent.Click("LoginView", "PasswordSelectionFruitButton", WaitTime.DefaultWaitTime, itemIndex);
            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }
        }

        /// <summary>
        /// Verifies Set Up button and navigates to Set Up screen
        /// </summary>
        /// <returns></returns>
        public static bool VerifySetupButtonAndNavigateToSetupScreen()
        {

            bool exists = AutomationAgent.VerifyControlExists("LoginView", "StudentSetupButton");
            if (exists)
            {
                AutomationAgent.Click("LoginView", "StudentSetupButton");
            }
            return exists;
        }

        /// <summary>
        /// Verifies if Begin Setup button exists
        /// </summary>
        /// <returns>bool object: true if begin setup control exists</returns>
        public static bool VerifyBeginSetupScreen()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "BeginSetupButton");
        }

        /// <summary>
        /// Verifies Student Login startup button exists
        /// </summary>
        /// <returns>bool object: true if start up control exists</returns>
        public static bool VerifyStudentLoginStartupButton()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "StudentLoginStartupButton");
        }

        /// <summary>
        /// Cancels picture password selection
        /// </summary>
        public static void CancelPasswordSelection()
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionCancelButton");
        }

        /// <summary>
        /// Continues picture password selection for second practice
        /// </summary>
        public static void OkPasswordSelection()
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionOkButton");
        }

        /// <summary>
        /// Continues picture password selection for final practice
        /// </summary>
        public static void NextPasswordSelection()
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionNextSetButton");
        }

        /// <summary>
        /// Verifies congratulations button after final picture password practice
        /// </summary>
        /// <returns>bool: true if Congratulation control exists</returns>
        public static bool VerifyPasswordSelectionCongratulationsButton()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionCongratulationsButton");
        }

        /// <summary>
        /// Verifies if the Try Again message appears
        /// </summary>
        /// <returns>bool: true if Try Again control exists</returns>
        public static bool VerifyTryAgain()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "IncorrectLoginTryAgain");
        }

        /// <summary>
        /// Verifies if the Help message appears
        /// </summary>
        /// <returns>bool: true if Help control exists</returns>
        public static bool VerifyHelp()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "IncorrectLoginHelp");
        }

        /// <summary>
        /// Verifies if Pick a Color cloud exists
        /// </summary>
        /// <returns>bool: true if Pick a Color control exists</returns>
        public static bool VerifyPickAColorScreen()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "PickAColorCaptainImage");
        }

        /// <summary>
        /// Verifies if ELA Grade label appears
        /// </summary>
        /// <returns>bool: true if ELA Grade Label control exists</returns>
        public static bool VerifyELAGradeAppears()
        {
            return AutomationAgent.VerifyControlExists("UnitSelectionView", "ELAGradeLabel");
        }



        /// <summary>
        /// Closes popup which appears on incorrect picture password
        /// </summary>
        public static void CloseIncorrectPicturePasswordErrorPopup()
        {
            AutomationAgent.Click("LoginView", "IncorrectPicturePasswordErrorPopupCancel");
        }

        /// <summary>
        /// Selects a color in Color selection page by clicking on a color by index
        /// </summary>
        /// <param name="colorIndex">Color index number</param>
        public static void SelectAColorInColorSelectionPage(int colorIndex)
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, colorIndex.ToString());
        }

        /// <summary>
        /// Selects a captain in captain selection page by clicking on a color by index
        /// </summary>
        /// <param name="colorIndex">Color index number</param>
        public static void SelectACaptainInColorSelectionPage(int colorIndex)
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, colorIndex.ToString());
        }

        /// <summary>
        /// Selects a fruit in fruit selection page by clicking on a color by index
        /// </summary>
        /// <param name="colorIndex">Color index number</param>
        public static void SelectAFruitInColorSelectionPage(int colorIndex)
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionFruitButton", WaitTime.DefaultWaitTime, colorIndex.ToString());
        }

        /// <summary>
        /// Clicks on Next button in Password Selection pages
        /// </summary>
        public static void ClickNextButtonInPasswordSelection()
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
        }

        /// <summary>
        /// Selects a color and clicks on Next button
        /// </summary>
        /// <param name="colorIndex">Color index number</param>
        public static void SelectAColorAndClickNext(int colorIndex)
        {
            SelectAColorInColorSelectionPage(colorIndex);
            ClickNextButtonInPasswordSelection();
        }

        /// <summary>
        /// Selects a color and clicks on Next button
        /// </summary>
        /// <param name="colorIndex">Color index number</param>
        public static void SelectACaptainAndClickNext(int captain)
        {
            SelectACaptainInColorSelectionPage(captain);
            ClickNextButtonInPasswordSelection();
        }
        /// <summary>
        /// Verifies various controls on Pick a Captain
        /// </summary>
        /// <param name="itemIndex">index of color/captain/fruit</param>
        /// <param name="username">Person name</param>
        /// <returns>bool: true if all required elements exist on Pick a Captain page</returns>
        public static bool VerifyPickACaptainScreenElements(string itemIndex, string username)
        {
            bool elementsExist = false;
            AutomationAgent.Click("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, itemIndex);
            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }

            elementsExist = AutomationAgent.VerifyControlExists("LoginView", "PickAColorCaptainImage");
            if (elementsExist)
            {
                elementsExist = AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton");
            }
            if (elementsExist)
            {
                //elementsExist = AutomationAgent.VerifyControlExists("LoginView", "StudentName", WaitTime.DefaultWaitTime, username);
            string[] usernamearr = username.Split(' ');
            elementsExist = AutomationAgent.VerifyAppChildrenByName(usernamearr[0]);
            }
            if (elementsExist)
            {
                elementsExist = AutomationAgent.VerifyControlExists("LoginView", "SetUpMode");
            }
            if (elementsExist)
            {
                for (int index = 1; index < 10; index++)
                {
                    if (elementsExist)
                    {
                        elementsExist = AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, index.ToString());
                    }
                }
            }
            if (elementsExist)
            {
                elementsExist = AutomationAgent.VerifyControlExists("LoginView", "BoatImage");
            }
            if (elementsExist)
            {
                elementsExist = !AutomationAgent.VerifyControlVisible("LoginView", "PasswordSelectionNextButton");
            }
            return elementsExist;
        }

        /// <summary>
        /// Vrifies Captain pick screen - whether all expected elements there or not
        /// </summary>
        /// <param name="assertFailureMessage">Failure message if any particular control is missing</param>
        /// <param name="username"></param>
        /// <returns>bool:true:if elements found;false:controls missing</returns>
        public static bool VerifyPickACaptianScreenElements(out string assertFailureMessage, string username)
        {
            assertFailureMessage = string.Empty;
            bool elementsExist = true;
            if (!AutomationAgent.VerifyControlExists("LoginView", "PickAColorCaptainImage"))
            {
                assertFailureMessage += "Captain Image is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                assertFailureMessage += " Go Back button is not available.";
                elementsExist = false;
            }


            string[] usernamearr = username.Split(' ');
            AutomationAgent.VerifyAppChildrenByName(usernamearr[0]);
           // if (!AutomationAgent.VerifyControlExists("LoginView", "StudentName", WaitTime.DefaultWaitTime, username))
            if(!AutomationAgent.VerifyAppChildrenByName(usernamearr[0]))
            {
                assertFailureMessage += " Student Name: " + username + " is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "SetUpMode"))
            {
                assertFailureMessage += " Setup Mode text is not available.";
                elementsExist = false;
            }
            for (int index = 1; index < 10; index++)
            {
                if (!AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, index.ToString()))
                {
                    assertFailureMessage += " Password selection Animal with index " + index.ToString() + " is not available.";
                    elementsExist = false;
                }
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "BoatImage"))
            {
                assertFailureMessage += " Boat Image is not available.";
                elementsExist = false;
            }
            if (AutomationAgent.VerifyControlVisible("LoginView", "PasswordSelectionNextButton"))
            {
                assertFailureMessage += " Password Selection Next button is available.";
                elementsExist = false;
            }
            return elementsExist;
        }

        /// <summary>
        /// Click to login for Begin setup of picture password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="ClickStudentLoginStartupButton"></param>
        public static void ClickBeginSetupLoginButton(Login login, bool ClickStudentLoginStartupButton = true)
        {
            AutomationAgent.SetText("LoginView", "UserNameTextboxOnStudentSetupScreen", login.UserName);
            AutomationAgent.SetText("LoginView", "PasswordTextboxOnStudentSetupScreen", login.Password);
            AutomationAgent.Click("LoginView", "BeginSetupLoginButton");

            int i = 10;
            while(!(AutomationAgent.VerifyControlExists("LoginView", "StudentLoginPasswordResetPassword")) && i>0)
            {
                AutomationAgent.Wait();
                i--;
            }

            if (AutomationAgent.VerifyControlExists("LoginView", "StudentLoginPasswordResetPassword"))
            {
                AutomationAgent.Click("LoginView", "StudentLoginPasswordResetPassword");
            }
            else
            {
                if (ClickStudentLoginStartupButton)
                {
                    int j = 0;
                    while (!AutomationAgent.VerifyControlExists("LoginView", "StudentLoginStartupButton") & j<=5)
                    {
                       // AutomationAgent.WaitForControlExists("LoginView", "StudentLoginStartupButton");
                        AutomationAgent.Wait();
                    }
                    AutomationAgent.Click("LoginView", "StudentLoginStartupButton");
                }
            }
        }

        /// <summary>
        /// Clicks on STudent ligin button of home screen
        /// </summary>
        public static void ClickStudentLoginButtonOnHomeScreen()
        {
            
            AutomationAgent.Click("LoginView", "StudentLoginHomePage");
        }

        /// <summary>
        /// Clicks hyperlink I am not student name
        /// </summary>
        public static void ClickStudentIAmNot()
        {
            AutomationAgent.Click("LoginView", "StudentIAmNot");
        }

        /// <summary>
        /// Verifies interent connectivity failure popup
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNoInternetAlertPopup()
        {
            return ((AutomationAgent.VerifyControlExists("LoginView", "PopupBox")) || (AutomationAgent.VerifyControlExists("LoginView", "NoInternetConnectionPopupMessage")));
        }

        /// <summary>
        /// Closes interenet connectivity popup
        /// </summary>
        public static void ClickToCloseNoInternetAlertPopup()
        {
            AutomationAgent.Click("LoginView", "NoInternetConnectionPopupClose");
        }

        /// <summary>
        /// Verifies correct school name of student
        /// </summary>
        /// <returns></returns>
        public static bool VerifyCorrectSchoolName(string SchoolUser)
        {

            string SchoolName = AutomationAgent.GetControlText("LoginView", "SchoolNameLoginPage");

            if (SchoolUser == "StudentKevin")
            {
                if (SchoolName != ConfigurationManager.AppSettings["SchoolName"].ToString())
                    return false;
            }

            else if (SchoolUser == "TeacherAdbul")
            {
                if (SchoolName != ConfigurationManager.AppSettings["SchoolName2"].ToString())
                    return false;
            }
            return (AutomationAgent.VerifyControlExists("LoginView", "SchoolNameLoginPage") && !string.IsNullOrEmpty(SchoolName));
        }

        /// <summary>
        /// Verifies whether school name is right justified or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifySchoolNameRightJustified()
        {
            int AppWindowWidth = AutomationAgent.GetAppWindowWidth();
            int SchoolNamePosX = AutomationAgent.GetControlPositionX("LoginView", "SchoolNameLoginPage");
            if ((AppWindowWidth - SchoolNamePosX) < 200)
                return true;

            else
                return false;
        }

        /// <summary>
        /// Verifies try again popup while entering incorrect pwd
        /// </summary>
        /// <returns></returns>
        public static bool VerifyTryAgainPopup()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "TryAgainPopupMessage");
        }

        /// <summary>
        /// Click to close try again popup
        /// </summary>
        public static void ClickToCloseTryAgainPopup()
        {
            AutomationAgent.Click("LoginView", "TryAgainPopupClose");
        }

        public static bool VerifyRedXCloseTryAgainPopup()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "TryAgainPopupClose");
        }

        public static bool VerifyHelpPopup()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "HelpPopupMessage");
        }

        public static void ClickBeginSetupLoginButton()
        {
            AutomationAgent.Click("LoginView", "StudentLoginStartupButton");
        }

        public static void ClickToSelectTeacherName(string teacherno)
        {
            AutomationAgent.Wait();
            while (!AutomationAgent.VerifyControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno))
            {
                AutomationAgent.WaitForControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno);
            }

            AutomationAgent.Click("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno);
        }

        public static void ClickOnButtonAccept()
        {
            AutomationAgent.Click("LoginView", "TeacherStudentSelectionButtonAccept");
        }

        public static void ClickToSelectStudentName(string studentno)
        {

            AutomationAgent.Wait(20000);
            while (!AutomationAgent.VerifyControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, studentno))
            {
                AutomationAgent.WaitForControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, studentno);
            }

            AutomationAgent.Click("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, studentno);
        }

        public static bool VerifyYouNeedToBeSetupOnDevicePopup()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "YouNeedToBeSetupOnDevicePopupMessage");
        }

        /// <summary>
        /// Clicks on Next button in Password Selection pages
        /// </summary>
        public static bool VerifyNextButtonInPasswordSelection()
        {

            return AutomationAgent.VerifyControlVisible("LoginView", "PasswordSelectionNextButton");
        }

        /// <summary>
        /// Verifies congratulations button after final picture password practice
        /// </summary>
        public static void ClickPasswordSelectionCongratulationsButton()
        {
            AutomationAgent.Click("LoginView", "PasswordSelectionCongratulationsButton");
        }



        public static bool VerifyPickAFruitScreenElements(out string assertFailureMessage, string username)
        {
            assertFailureMessage = string.Empty;
            bool elementsExist = true;
            if (!AutomationAgent.VerifyControlExists("LoginView", "PickAColorFruitImage"))
            {
                assertFailureMessage += "Captain Image is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                assertFailureMessage += " Go Back button is not available.";
                elementsExist = false;
            }
            //if (!AutomationAgent.VerifyControlExists("LoginView", "StudentName", WaitTime.DefaultWaitTime, username))
            string[] usernamearr = username.Split(' ');
            if(!AutomationAgent.VerifyAppChildrenByName(usernamearr[0]))
            {
                assertFailureMessage += " Student Name: " + username + " is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "SetUpMode"))
            {
                assertFailureMessage += " Setup Mode text is not available.";
                elementsExist = false;
            }
            for (int index = 1; index < 10; index++)
            {
                if (!AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionFruitButton", WaitTime.DefaultWaitTime, index.ToString()))
                {
                    assertFailureMessage += " Password selection Animal with index " + index.ToString() + " is not available.";
                    elementsExist = false;
                }
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "BoatImage"))
            {
                assertFailureMessage += " Boat Image is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "CaptainImage"))
            {
                assertFailureMessage += " Boat Image is not available.";
                elementsExist = false;
            }

            if (AutomationAgent.VerifyControlVisible("LoginView", "PasswordSelectionNextButton"))
            {
                assertFailureMessage += " Password Selection Next button is available.";
                elementsExist = false;
            }
            return elementsExist;
        }

        public static bool VerifyPickAColorScreenElements(out string assertFailureMessage, string username)
        {
            assertFailureMessage = string.Empty;
            bool elementsExist = true;
            if (!AutomationAgent.VerifyControlExists("LoginView", "PickAColorImage"))
            {
                assertFailureMessage += "Color Image is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                assertFailureMessage += " Go Back button is not available.";
                elementsExist = false;
            }

            if (!VerifyNavigationBarBackAtTopLeft())
            {
                assertFailureMessage += " Navigation bar back button is not available At top left.";
                elementsExist = false;
            }

            string[] usernamearr = username.Split(' ');
            if(!AutomationAgent.VerifyAppChildrenByName(usernamearr[0]))
            //if (!AutomationAgent.VerifyControlExists("LoginView", "StudentName", WaitTime.DefaultWaitTime, username))
            {
                assertFailureMessage += " Student Name: " + username + " is not available.";
                elementsExist = false;
            }


            if (!VerifyStudentNameAtTopLeft(username))
            {
                assertFailureMessage += " Student Name is not available At top left.";
                elementsExist = false;
            }


            if (!AutomationAgent.VerifyControlExists("LoginView", "SetUpMode"))
            {
                assertFailureMessage += " Setup Mode text is not available.";
                elementsExist = false;
            }
            for (int index = 1; index < 10; index++)
            {
                if (!AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, index.ToString()))
                {
                    assertFailureMessage += " Password selection color with index " + index.ToString() + " is not available.";
                    elementsExist = false;
                }
            }

            return elementsExist;
        }




        public static bool EnterPicturePasswordAndVerifyNoPopup(string itemIndex)
        {
            bool PopupNotAvailable = true;

            AutomationAgent.Click("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, itemIndex);

            if (VerifyPopupAppears())
                PopupNotAvailable = false;

            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }

            AutomationAgent.Click("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, itemIndex);


            if (VerifyPopupAppears())
                PopupNotAvailable = false;

            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }

            AutomationAgent.Click("LoginView", "PasswordSelectionFruitButton", WaitTime.DefaultWaitTime, itemIndex);

            if (VerifyPopupAppears())
                PopupNotAvailable = false;

            if (AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionNextButton"))
            {
                AutomationAgent.Click("LoginView", "PasswordSelectionNextButton");
            }

            return PopupNotAvailable;
        }

        public static bool VerifyPopupAppears()
        {
            return ((AutomationAgent.VerifyControlExists("LoginView", "PopupBox", 1000)) || (AutomationAgent.VerifyControlExists("LoginView", "TryAgainTextDuplicate", 1000)));
        }

        public static bool VerifyBeginSetupLoginScreen()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "StudentLoginStartupButton");
        }

        public static bool VerifyWelcomeMessage(string StudentName)
        {
            string[] stdname = StudentName.Split(' ');

            return AutomationAgent.VerifyControlExists("LoginView", "WelcomeMessage", WaitTime.SmallWaitTime, stdname[0]);
        }

        public static bool VerifyTeacherSelectedAndHighlighted(string teacherno)
        {
            return AutomationAgent.VerifyXamlListItemSelected("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno);
        }


        public static bool VerifyTeacherStudentAcceptButton()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "TeacherStudentSelectionButtonAccept");
        }

        public static bool VerifyTermsOfUsePresent()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "TermsOfUse");
        }

        public static bool VerifyPrivacyStatementPresent()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "PrivacyStatement");
        }

        public static void ClickTermsOfUseLink()
        {
            AutomationAgent.Click("LoginView", "TermsOfUse");
        }

        public static bool VerifyTermsOfUsePopupPresent()
        {
            if (!AutomationAgent.VerifyControlExists("LoginView", "TermsOfUsePopup"))
                return false;


            string outPutDirectory = System.IO.Directory.GetCurrentDirectory();
            string filename = Path.Combine(outPutDirectory, "K1WinTermsOfUse.txt");
            string expectedtext = AutomationAgent.GetControlText("LoginView", "TermsOfUsePopup");

            byte[] bytes = System.IO.File.ReadAllBytes(filename);
            string actualtext = System.Text.Encoding.UTF8.GetString(bytes);

//            System.IO.File.WriteAllText(filename, expectedtext);

            if (expectedtext.Equals(actualtext))
                return true;

            else
            {
                return false;
            }

        }

        public static void ClickToCloseTermsOfUsePopup()
        {
            AutomationAgent.Click("LoginView", "TermsOfUsePopupClose");
        }

        public static bool VerifyLogInScreenForAlreadySetupStudent()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "HelloBanner") &&
                    AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton") &&
                     AutomationAgent.VerifyControlExists("LoginView", "StudentNameBanner") &&
                    AutomationAgent.VerifyControlExists("LoginView", "StudentLoginStartupButton") &&
                     AutomationAgent.VerifyControlExists("LoginView", "AiroplaneImageHelloPage") &&
                    AutomationAgent.VerifyControlExists("LoginView", "StudentIAmNot"));


        }

        public static bool VerifyLogInScreenForNewBeginSetupStudent()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "HelloBanner") &&
                    AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton") &&
                     AutomationAgent.VerifyControlExists("LoginView", "StudentNameBanner") &&
                    AutomationAgent.VerifyControlExists("LoginView", "StudentLoginStartupButton") &&
                     AutomationAgent.VerifyControlExists("LoginView", "AiroplaneImageHelloPage"));
        }

        public static bool VerifyPasswordSetupConfirmationLetsPractice(out string assertFailureMessage, string username)
        {
            assertFailureMessage = string.Empty;
            bool elementsExist = true;

            if (!AutomationAgent.VerifyControlExists("LoginView", "BoatImage"))
            {
                assertFailureMessage += " Boat Image is not available.";
                elementsExist = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "CaptainImage"))
            {
                assertFailureMessage += " Boat Image is not available.";
                elementsExist = false;
            }

            if (!AutomationAgent.VerifyControlExists("LoginView", "FruitImage"))
            {
                assertFailureMessage += " Fruit Image is not available.";
                elementsExist = false;
            }


            //if (!AutomationAgent.VerifyControlExists("LoginView", "StudentName", WaitTime.DefaultWaitTime, username.TrimEnd(' ')))
            string[] usernamearr = username.Split(' ');
            if (!AutomationAgent.VerifyAppChildrenByName(usernamearr[0]))
            {
                assertFailureMessage += " Student Name: " + username + " is not available.";
                elementsExist = false;
            }

            if (!VerifyStudentNameAtTopLeft(username.TrimEnd(' ')))
            {
                assertFailureMessage += " Student Name is not available At top left.";
                elementsExist = false;

            }


            if (!AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionOkButton"))
            {
                assertFailureMessage += " Password Selection OK button is not available.";
                elementsExist = false;
            }

            if (!VerifyPasswordSelectionOKAtRight())
            {
                assertFailureMessage += " Password Selection OK is not available At right";
                elementsExist = false;

            }

            if (!AutomationAgent.VerifyControlExists("LoginView", "PasswordSelectionCancelButton"))
            {
                assertFailureMessage += " Password Selection Cancel button is not available.";
                elementsExist = false;
            }

            if (!VerifyPasswordSelectionCancelAtLeft())
            {
                assertFailureMessage += " Password Selection cancel is not available At right";
                elementsExist = false;

            }

            if (!AutomationAgent.VerifyControlExists("LoginView", "LetsPractice2MoreTimes"))
            {
                assertFailureMessage += " Lets Practice 2 More Times label is not available.";
                elementsExist = false;
            }

            if (!VerifyLetsPractice2MoreTimesAtCenter())
            {
                assertFailureMessage += " Lets Practice 2 More Times is not available At center";
                elementsExist = false;
            }

            if (!AutomationAgent.VerifyControlExists("LoginView", "YourPasswordLabel"))
            {
                assertFailureMessage += " Your Password Label is not available.";
                elementsExist = false;
            }

            return elementsExist;
        }

        public static bool VerifyLetsPractice2MoreTimesAtCenter()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int LestPracticeX = AutomationAgent.GetControlPositionX("LoginView", "LetsPractice2MoreTimes");
            int LestPracticeWidth = AutomationAgent.GetControlWidth("LoginView", "LetsPractice2MoreTimes");

            int diff = (ScreenSize / 2) - (LestPracticeX + (LestPracticeWidth / 2));
            if (diff == 0)
                return true;

            else
                return false;
        }

        public static bool VerifyPasswordSelectionCancelAtLeft()
        {

            int CancelButtonX = AutomationAgent.GetControlPositionX("LoginView", "PasswordSelectionCancelButton");

            if (CancelButtonX < 125)
                return true;

            else
                return false;
        }

        public static bool VerifyPasswordSelectionOKAtRight()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int OKButtonX = AutomationAgent.GetControlPositionX("LoginView", "PasswordSelectionOkButton");

            if ((OKButtonX > (ScreenSize - 220)))
                return true;

            else
                return false;
        }

        public static bool VerifyStudentNameAtTopLeft(string username)
        {
            int StudentNameX = AutomationAgent.GetControlPositionX("LoginView", "StudentName", WaitTime.DefaultWaitTime, username);
            int StudentNameY = AutomationAgent.GetControlPositionY("LoginView", "StudentName", WaitTime.DefaultWaitTime, username);

            if ((StudentNameX < 150) && StudentNameY < 100)
                return true;

            else
                return false;
        }

        public static bool VerifyNavigationBarBackAtTopLeft()
        {
            int BackButtonX = AutomationAgent.GetControlPositionX("LoginView", "NavigationBarGoBackButton");
            int BackButtonY = AutomationAgent.GetControlPositionY("LoginView", "NavigationBarGoBackButton");

            if ((BackButtonX < 5) && BackButtonY < 50)
                return true;

            else
                return false;
        }

        public static bool VerifyHintArrowAppearsToPointCorrectPassword(string PasswordSelectionPage, string colorIndex = "1")
        {
            if (!AutomationAgent.VerifyControlExists("LoginView", "HintArrowMark"))
                     return false;

            int CorrectColorX = 0;
            int CorrectColorY = 0;
           
            switch(PasswordSelectionPage)
            {
           

                case("Color"):
                             CorrectColorX = AutomationAgent.GetControlPositionX("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, colorIndex.ToString());
                             CorrectColorY = AutomationAgent.GetControlPositionY("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, colorIndex.ToString()); 
                                break;

                case("Captain"):
                             CorrectColorX = AutomationAgent.GetControlPositionX("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, colorIndex.ToString());
                             CorrectColorY = AutomationAgent.GetControlPositionY("LoginView", "PasswordSelectionAnimalButton", WaitTime.DefaultWaitTime, colorIndex.ToString()); 
                            break;

            case("Fruit"):
                            CorrectColorX = AutomationAgent.GetControlPositionX("LoginView", "PasswordSelectionFruitButton", WaitTime.DefaultWaitTime, colorIndex.ToString());
                             CorrectColorY = AutomationAgent.GetControlPositionY("LoginView", "PasswordSelectionFruitButton", WaitTime.DefaultWaitTime, colorIndex.ToString()); 
                            break;
            
            }
            
            int HintArrowX =  AutomationAgent.GetControlPositionX("LoginView", "HintArrowMark");
            int HintArrowY =  AutomationAgent.GetControlPositionY("LoginView", "HintArrowMark");

            if ((CorrectColorX - HintArrowX) < 70 && (CorrectColorY - HintArrowY) < 50)
                return true;

            else
                return false;

        }

        public static void ClickPrivacyStatement()
        {
            AutomationAgent.Click("LoginView", "PrivacyStatement");
        }

        public static bool VerifyPrivacyStatementPopupPresent()
        {
            if (!AutomationAgent.VerifyControlExists("LoginView", "PrivacyPolicyPopup",2000))
                return false;

            string outPutDirectory = System.IO.Directory.GetCurrentDirectory();
            string filename = Path.Combine(outPutDirectory, "K1WinPrivacyPolicy.txt");
            string expectedtext = AutomationAgent.GetControlText("LoginView", "PrivacyPolicyPopup");

            byte[] bytes = System.IO.File.ReadAllBytes(filename);
            string actualtext = System.Text.Encoding.UTF8.GetString(bytes);


            if (expectedtext.Equals(actualtext))
                return true;

            else
            {
                return false;
            }
        }

        public static void ClickToClosePrivacyStatementPopup()
        {
            AutomationAgent.Click("LoginView", "PrivacyPolicyPopupClose");
        }

        public static void ClickBeginSetupLoginButtonWithoutPasswordReset(Login login)
        {
            AutomationAgent.SetText("LoginView", "UserNameTextboxOnStudentSetupScreen", login.UserName);
            AutomationAgent.SetText("LoginView", "PasswordTextboxOnStudentSetupScreen", login.Password);
            AutomationAgent.Click("LoginView", "BeginSetupLoginButton");
            int i = 10;
            while (!(AutomationAgent.VerifyControlExists("LoginView", "StudentLoginPasswordResetPassword")) && i > 0)
            {
                AutomationAgent.Wait();
                i--;
            }
            
           
        }

        public static bool VerifyResetPasswordAndCancelAVailable()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "StudentLoginPasswordResetPassword") && AutomationAgent.VerifyControlExists("LoginView", "StudentLoginPasswordCancelReturnToLogin")); 
        }

        public static void ClickCancelAndReturnToLogin()
        {
            AutomationAgent.Click("LoginView", "StudentLoginPasswordCancelReturnToLogin"); 
        }

        public static bool VerifyHomeScreen()
        {
           return( VerifyTermsOfUsePresent()  &&
                    VerifyPrivacyStatementPresent() &&
                    AutomationAgent.VerifyControlExists("LoginView", "TeacherAdminLoginButton") &&
                    AutomationAgent.VerifyControlExists("LoginView", "StudentLoginHomePage"));

        }

        public static void ClickResetPasswordToLogin()
        {
            AutomationAgent.Click("LoginView", "StudentLoginPasswordResetPassword");
        }

        /// <summary>
        /// Logs out of the application
        /// </summary>
        public static void TapOnLogout()
        {
            AutomationAgent.Click("LoginView", "SystemTray");
            AutomationAgent.Click("LoginView", "LogoutButton");
            NavigationCommonMethods.Sleep();
            //AutomationAgent.Click("LoginView", "LogoutConfirm");
        }

        public static bool VerifyLogoutConfirmGreenAndRedIconAppears()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm") &&
                AutomationAgent.VerifyControlExists("LoginView", "LogoutCancel")
                && AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirmPopup"));
        }

        public static void ClickOnLogoutCancelButton()
        {
            AutomationAgent.Click("LoginView", "LogoutCancel");
        }

        public static bool VerifyStudentSetupScreen()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "UserNameTextboxOnStudentSetupScreen") &&
             AutomationAgent.VerifyControlExists("LoginView", "PasswordTextboxOnStudentSetupScreen") &&
             AutomationAgent.VerifyControlExists("LoginView", "BeginSetupLoginButton"));
        }

        public static bool VerifyBackButtonExists()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton",500);
        }



        public static bool VerifySelectTeacherName(string teacherno)
        {
            AutomationAgent.Wait();
            while (!AutomationAgent.VerifyControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno))
            {
                AutomationAgent.WaitForControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno);
            }

            return AutomationAgent.VerifyControlExists("LoginView", "SelectTeacherName", WaitTime.DefaultWaitTime, teacherno);
        }

        public static bool VerifyPasswordColorItemColor(System.Drawing.Color sampleColor, string itemIndex)
        {
            return AutomationAgent.CompareControlImageColor("LoginView", "PasswordSelectionColorButton", sampleColor, WaitTime.DefaultWaitTime, itemIndex);
        }

        public static System.Drawing.Bitmap GetPasswordColorItemImage(string itemIndex)
        {
            return AutomationAgent.GetControlBitmap("LoginView", "PasswordSelectionColorButton", WaitTime.DefaultWaitTime, itemIndex);
        }

        public static void ClickBackButton()
        {
            AutomationAgent.Click("LoginView", "NavigationBarGoBackButton", 500);
        }

        public static string SelectUserAndGetName(string usertype, string usernum = "1")
        {
            while (usertype.Equals("Teacher") && AutomationAgent.VerifyControlExists("LoginView", "StudentIAmNot"))
            {
                AutomationAgent.Wait();
            }
            while (usertype.Equals("Student") && AutomationAgent.VerifyControlExists("LoginView", "TeacherStudentSelectionButtonAccept"))
            {
                AutomationAgent.Wait();
            }
            string[] user1 = AutomationAgent.GetChildrenControlNames("LoginView", "ListViewItem", 0, "1");
            string[] user2 = AutomationAgent.GetChildrenControlNames("LoginView", "ListViewItem", 0, "2");
            string[] user3 = AutomationAgent.GetChildrenControlNames("LoginView", "ListViewItem", 0, "3");
            string[] names = { user1[1], user2[1], user3[1]};
            Array.Sort<string>(names);
            if (!(names[0].Equals(user1[1]) && names[1].Equals(user2[1]) && names[2].Equals(user3[1])))
            {
                Assert.Fail("Names are not sorted");
            }
            string nameOfFirstUser = names[0];
            if (!nameOfFirstUser.Contains(" "))
            {
                Assert.Fail("Name doesn't have Miss / Mr LN and LN");
            }
            if (usertype.Equals("Teacher") && !(nameOfFirstUser.StartsWith("Mr") || nameOfFirstUser.Equals("Mrs") || nameOfFirstUser.Equals("Ms") || nameOfFirstUser.Equals("Miss")))
            {
                Assert.Fail("Names doesn't start with Mr / Miss");
            }
            AutomationAgent.Click("LoginView", "ListViewItem", 0, usernum);
            return user1[1];
        }

        public static bool VerifyMessageOfNotSetupUser(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("AppView", "ChildImage"))
            {
                exists = false;
                assertFailureMessage += "Child Image is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("AppView", "HelpMenu"))
            {
                exists = false;
                assertFailureMessage += "Help Menu is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("AppView", "SetupHelpMessage"))
            {
                exists = false;
                assertFailureMessage += "Setup Help Message is not available. ";
            }
            NavigationCommonMethods.TapOnScreen(200, 200);
            return exists;
        }

        public static bool VerifyStudentIAmNotLink()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "StudentIAmNot");
        }

        public static bool VerifyMessagePopup(out string assertFailureMessage) 
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("AppView", "HelpMessage"))
            {
                exists = false;
                assertFailureMessage += "Help message is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("AppView", "ChildImage"))
            {
                exists = false;
                assertFailureMessage += "Child Image is not available. ";
            }
            if (!AutomationAgent.VerifyControlExists("AppView", "HelpMenu"))
            {
                exists = false;
                assertFailureMessage += "Help Menu is not available. ";
            }
            return exists;
        }
    }
}
