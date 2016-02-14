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

namespace Pearson.PSCWinAutomationFramework._212App
{
    /// <summary>
    /// Summary description for LoginCommonMethods
    /// </summary>
    
    public static class LoginCommonMethods
    {

        /// <summary>
        /// Verifies Login Screen - By validating existing controls
        /// </summary>
        public static bool VerifyLoginScreen()
        {
            if (AutomationAgent.VerifyControlExists("LoginView", "UserNameTextbox") &&
                               AutomationAgent.VerifyControlExists("LoginView", "passwordTextbox") &&
                                                  AutomationAgent.VerifyControlExists("LoginView", "LoginButton"))
                return true;

            else
                return false;
        }

        /// <summary>
        /// Gets User Name text from User Name Text box
        /// </summary>
        /// <returns>User Name text </returns>
        public static string GetTextFromUsername()
        {
            return AutomationAgent.GetText("LoginView", "UserNameTextbox");
        }

        
        /// <summary>
        /// Verifies Popup Message appears for User Name password incorrect
        /// </summary>
        /// <returns>true:if message appears; false:if no message</returns>
        public static bool VerifyLoginFailed()
        {
            AutomationAgent.WaitForControlExists("LoginView", "UserNamePwdIncorrectBody", WaitTime.DefaultWaitTime, "");
           return AutomationAgent.VerifyControlExists("LoginView", "UserNamePwdIncorrectBody");
        }

        /// <summary>
        /// Clicks on close button of popup
        /// </summary>
        public static void ClickOnCloseButton()
        {
            AutomationAgent.Click("LoginView", "CloseButton");
        }

        /// <summary>
        /// Set text in Username text box
        /// </summary>
        /// <param name="UserName"></param>
        public static void SetTextInUsername(string UserName)
        {
            AutomationAgent.SetText("LoginView", "UserNameTextbox", UserName);
           
        }

        /// <summary>
        /// Set Text in password Text Box
        /// </summary>
        /// <param name="password"></param>
        public static void SetTextInPassword(string password)
        {
            AutomationAgent.SetText("LoginView", "passwordTextbox", password);
        }

        /// <summary>
        /// Verifies default User Name text in User Name text box
        /// </summary>
        /// <returns>true:if text available; false:if no text</returns>
        public static bool VerifyUserNameTextAvailable()
        {
           return AutomationAgent.VerifyControlExists("LoginView", "UserNameText");
        }


        /// <summary>
        /// Verifies default Password text in User Name text box
        /// </summary>
        /// <returns>true:if text available; false:if no text</returns>
        public static bool VerifyPasswordTextAvailable()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "PasswordText");
        }

        /// <summary>
        /// Clicks on Login Button
        /// </summary>
        public static void ClickOnLoginButton()
        {
            AutomationAgent.Click("LoginView", "LoginButton");
        }


        /// <summary>
        /// Gets text from System Tray for User Name
        /// </summary>
        /// <returns>text name of User</returns>
        public static string GetCurrentUserName()
        {
            return AutomationAgent.GetControlText("DashboardView", "UserNameInAppBar");
        }

        /// <summary>
        /// Verifies Login Button Enabled after clicking
        /// </summary>
        /// <returns>true:if text available; false:if no text</returns>
        public static bool VerifyLoginButtonAvailable()
        {
            if (AutomationAgent.VerifyControlExists("LoginView", "LoginButton"))
            {
            string GetLoginButtonText = AutomationAgent.GetControlText("LoginView", "LoginButton");
            return GetLoginButtonText.Equals("Log In");
        }

            else
                return false;

        }
        

        public static bool VerifyUserNameRequiredPopup()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "UserNameisrequired");
        }

        public static void ClickUsernamePasswordOkButton()
        {
            //AutomationAgent.Click("LoginView", "CloseButton2");
            AutomationAgent.Click("LoginView", "CloseButton");
        }

        public static bool VerifyNoWifiPopUp()
        {
            bool r = AutomationAgent.VerifyControlExists("LoginView", "CloseButton2");
            return r;
        }


        public static bool VerifyXbuttonUserNameExist()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "UserNameTextboxXButton");
        }

        public static void ClickXbuttonUserName()
        {
            AutomationAgent.Click("LoginView", "UserNameTextboxXButton");
        }

        public static string GetTextFromPassword()
        {
            string s = AutomationAgent.GetText("LoginView", "passwordTextbox");
            return s;
        }

        public static bool VerifyXbuttonPasswordExist()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "passwordTextboxXButton");
        }

        public static void ClickXbuttonPassword()
        {
            AutomationAgent.Click("LoginView", "passwordTextboxXButton");
        }

        public static bool VerifyCopyrightLabel()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "CopyrightLabel");
        }

        public static bool VerifyTermsofUseLabel()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "TermsofUsePage");
        }

        public static bool VerifyPrivacyPolicyLabel()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "PrivacyPolicy");
        }

        public static bool VerifyLabelsAreUnderlined()
        {
           string fontname  =   AutomationAgent.GetControlFontName("LoginView", "PrivacyPolicy");
           string fontname1 = AutomationAgent.GetControlFontName("LoginView", "TermsofUsePage");
           string fontname2 = AutomationAgent.GetControlFontName("LoginView", "CopyrightLabel");

           if (fontname == fontname1)
               return true;

           else
               return false;

        }

        public static bool VerifyTermsOfUseandPrivacyLabelExistsAfterCopyrightLabel()
        {
            throw new NotImplementedException();
        }

        public static void ClickOnTermsofUseLabel()
        {
            AutomationAgent.Click("LoginView", "TermsofUsePage");
        }

        public static bool verifyTermsOfUseOpen()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "TermsofUsePage");

        }

        public static bool verifyTermsOfUseOpenScrollable()
        {
            bool scrollable = false;
            for (int i = 0; i < 2; i++)
            {
                AutomationAgent.Swipe("LoginView", "TermOfUseBox", UITestGestureDirection.Up);
                scrollable = true;
            }
            return scrollable;

        }

        public static void ClickOnTermsofUseClose()
        {
            AutomationAgent.Click("LoginView", "TermOfUseBoxCloseButton");
        }

        public static void ClickOnPrivacyPolicy()
        {
            AutomationAgent.Click("LoginView", "PrivacyPolicy");
        }

        public static bool verifyPrivacyPolicyOpen()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "PrivacyPolicyPage");
        }

        public static bool verifyPrivacyPolicyScrollable()
        {
            bool scrollable = false;
            for (int i = 0; i < 2; i++)
            {
                AutomationAgent.Swipe("LoginView", "PrivacyPolicyBox", UITestGestureDirection.Up);
                scrollable = true;
            }
            return scrollable;
        }

        public static void ClickOnPrivacyPolicyClose()
        {
            AutomationAgent.Click("LoginView", "TermOfUseBoxCloseButton");
        }


        public static bool VerifyPasswordTextIsHidden()
        {
            string PwdClassName = AutomationAgent.GetControlClassName("LoginView", "passwordTextbox");
            if (PwdClassName == "PasswordBox")
                return true;

            else
                return false;
        }

        public static void CloseCrashReportsPopup()
        {
            if (AutomationAgent.VerifyControlExists("LoginView", "CrashReportsNoButton", 5000))
            {
                AutomationAgent.Click("LoginView", "CrashReportsNoButton");
            }
        }


        /// <summary>
        /// Verifies  PasswordRequired Popup
        /// </summary>
        /// <returns>true:if text available; false:if no text</returns>
        public static bool VerifyPasswordRequiredPopup()
        {

            string message = AutomationAgent.GetControlText("LoginView", "Passwordisrequired");
            if (message == "Password is required.")
                return true;

            else
                return false;
        }

        public static bool VerifyInitialSetupProgressScreen()
        {
            return (AutomationAgent.VerifyControlExists("LoginView", "InitialLoginPreparingLessonsStep1", 20000) ||
                    (AutomationAgent.VerifyControlExists("LoginView", "InitialLoginPreparingLessonsStep2")));
        }

        public static void WaitForDownloadToComplete()
        {
            int trial = 10;
            while ((!AutomationAgent.VerifyControlExists("TopMenuView", "SystemTrayButton")) && trial > 0)
            {
                AutomationAgent.WaitForControlExists("TopMenuView", "SystemTrayButton", 80000);
                trial--;
            }
        }
        public static bool VerifyLoginButtonColor(System.Drawing.Color sampleColor)
        {
            return AutomationAgent.CompareControlImageColor("LoginView", "LoginButton", sampleColor);
        }

        public static System.Drawing.Bitmap GetLoginButtonColor()
        {
            return AutomationAgent.GetControlBitmap("LoginView", "LoginButton");
        }
        /// <summary>
        /// Verifies Grades Selection Screen is present or not on First Login 
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyGradesSelectionScreenOnFirstLogin()
        {
            AutomationAgent.WaitForControlExists("SelectGradeView", "SelectGradeLabel", 80000);
            return AutomationAgent.VerifyControlExists("SelectGradeView", "SelectGradeLabel");
        }
        /// <summary>
        /// Verifies Prepairing Lessons Step 1  
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPreparingLessonsStep1()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "InitialLoginPreparingLessonsStep1", 20000);
        }
        /// <summary>
        /// Verifies Prepairing Lessons Step 2
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPreparingLessonsStep2()
        {
            return AutomationAgent.VerifyControlExists("LoginView", "InitialLoginPreparingLessonsStep2", 20000);
        }

        public static int ClickAndContinueGradeSelected()
        {
            int grade = LessonBrowserCommonMethods.SelectGrade();
            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
            return grade;
        }

        public static void AddSpecifiedGrade(int grade)
        {
            LessonBrowserCommonMethods.SelectGrade(grade);
            LessonBrowserCommonMethods.ClickAddGradeContinueButton();
        }
        /// <summary>
        /// Verifies color contrast for text and text box of login screen
        /// </summary>
        /// <returns>bool</returns>
        public static bool VerifyTextInContrastWithBackground()
        {
            System.Drawing.Bitmap ColorUserNametxtBox = AutomationAgent.GetControlBitmap("LoginView", "UserNameTextbox");
            System.Drawing.Bitmap ColorPwdTxtBox = AutomationAgent.GetControlBitmap("LoginView", "passwordTextbox");

            System.Drawing.Bitmap ColorUserNametxt = AutomationAgent.GetControlBitmap("LoginView", "UserNameText");
            System.Drawing.Bitmap ColorPwdtxt = AutomationAgent.GetControlBitmap("LoginView", "PasswordText");

            if (ColorUserNametxt == ColorUserNametxtBox || ColorPwdtxt == ColorPwdTxtBox)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Verifies User Name Supporting Text Avaialble or not after entering the user name
        /// </summary>
        /// <returns>bool: true(if avaialble), false(if not available)</returns>
        public static bool VerifyUserNameTextAvailableAfterEditing()
        {
            string s = AutomationAgent.GetControlText("LoginView", "UserNameText");
            string s1 = AutomationAgent.GetText("LoginView", "UserNameTextbox");
            if (s.Equals(s1))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies Password supporting text availableor not after entering the password
        /// </summary>
        /// <returns>bool: true(if available), false(if not available)</returns>
        public static bool VerifyPasswordTextAvailableAfterEditing()
        {
            string s = AutomationAgent.GetControlText("LoginView", "PasswordText");
            string s1 = AutomationAgent.GetText("LoginView", "passwordTextbox");
            if (s.Equals(s1))
                return true;
            else
                return false;
        }
    }
}
