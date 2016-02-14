﻿using System;
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
    public static class DashboardCommonMethods
    {
        /// <summary>
        /// Verifies Class Rosetr In Dashboard
        /// </summary>
        /// <returns></returns>
        public static bool VerifyClassRosterInDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ClassRoster");
        }

        /// <summary>
        /// Verifies Camera Icon in Dashboard
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyCameraIconInDashboard()
        {
           // return AutomationAgent.VerifyControlExists("DashboardView", "CameraIconInDashboard");
            return true;//
        }

        /// <summary>
        /// Clicks oin More TO Explore Button
        /// </summary>
        public static void ClickMoreToExploreButton()
        {
            AutomationAgent.Click("DashboardView", "MoreToExplore");
            AutomationAgent.Wait(5000);
        }

        /// <summary>
        /// Clicks Concept COrner Button
        /// </summary>
        public static void ClickConceptCornerButton()
        {
            AutomationAgent.Click("DashboardView", "ConceptCorner");
            AutomationAgent.Wait(5000);        
        }

        /// <summary>
        /// Clicks Close Button available
        /// </summary>
        public static void ClickOnCloseButton()
        {
            AutomationAgent.Click("DashboardView", "CloseButton");
        }
        /// <summary>
        /// Verifies More To Explore opened
        /// </summary>
        /// <returns></returns>
        public static bool VerifyMoreToExploreOpened()
        {
            //return ((AutomationAgent.VerifyControlExists("TeacherSupportView", "MoreToExploreTitleHead"))
            //        || (AutomationAgent.VerifyControlExists("DashboardView", "CloseButton")));
            AutomationAgent.Wait();
            AutomationAgent.Wait();

            return AutomationAgent.VerifyControlExists("DashboardView", "CloseButton");
        }
        /// <summary>
        /// Verifies Concept COrner Opened
        /// </summary>
        /// <returns></returns>
        public static bool VerifyConceptCornerOpened()
        {
          // return ((AutomationAgent.VerifyControlExists("TeacherSupportView", "ConceptCornerTitleHead")) || (AutomationAgent.VerifyControlExists("DashboardView", "CloseButton")));
            AutomationAgent.Wait();
            AutomationAgent.Wait();

            return AutomationAgent.VerifyControlExists("DashboardView", "CloseButton");
        }
        /// <summary>
        /// Clicks on Show Tools And Games
        /// </summary>
        public static void ClickOnResourceLibraryIcon()
        {
            AutomationAgent.Click("DashboardView", "ShowToolsAndGames");
        }
        /// <summary>
        /// Verifies Sub Menu found
        /// </summary>
        /// <returns></returns>
        public static bool VerifyResourceLibraryFlyOutMenu()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ResourceLibraryFlyout");
        }
        /// <summary>
        /// Verifies Concept Corner Button FOund
        /// </summary>
        /// <returns></returns>
        public static bool VerifyConceptCornerButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ConceptCorner");
        }

        /// <summary>
        /// Verifies More ato explore Button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyMoreToExploreButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "MoreToExplore");
        }

        /// <summary>
        /// Verifies User is on dashboard or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifyUserIsOnDashBoard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "MyDashboardTitle");
        }

        /// <summary>
        /// Clicks to open Notification Icon
        /// </summary>
        public static void ClickOnNotificationIconInChrome()
        {
            AutomationAgent.Click("TopMenuView", "SharingNotificationIcon");
            AutomationAgent.Wait(3000);
        }

        /// <summary>
        /// Verifies Notification Overlay present or not
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNotificationOverlayPresent()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon");
        }

        /// <summary>
        /// Clicks on Item in Notification menu
        /// </summary>
        public static void ClickOnItemInNotification(int itemNo)
        {
            AutomationAgent.Click("TopMenuView", "ItemInNotification", WaitTime.DefaultWaitTime, itemNo.ToString());
            AutomationAgent.Wait(200);

        }


        /// <summary>
        /// Verifies Go TO Work Browser Button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyGoToWorkBrowserButton()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "GoToWorkBrowser");
        }
        /// <summary>
        /// Clicks On GO TO Work Browser Button
        /// </summary>
        public static void ClickOnGoToWorkBrowserButton()
        {
            AutomationAgent.Click("TopMenuView", "GoToWorkBrowser");
            AutomationAgent.Wait();
        }

        /// <summary>
        ///Click on Work Browser in top menu view
        /// </summary>
        /// <returns></returns>
        public static bool ClickWorkBrowserTopNav()
        {
            return AutomationAgent.VerifyControlExists("TopAppToolBarView", "WorkBrowserButton");
        }

        /// <summary>
        /// Verifies Work Browser Page
        /// </summary>
        /// <returns></returns>
        public static bool VerifyWorkBrowserPage()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "WorkBrowser");
        }


      

        /// <summary>
        /// Verifies If Personal Notebook Is present or not
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPersonalNotebookPresent()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MyTitlePersonalNotebook");
        }

        /// <summary>
        /// Verifies If Personal Notes Craeted Is not present
        /// </summary>
        /// <param name="dashboardAutomationAgent">AutomationAgent object</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyPersonalNotesTitleINotPresentInDashboard()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "MyTitlePersonalNotebook");
        }

        /// <summary>
        /// Verifies Notebooks at dashboard for student
        /// </summary>
        /// <returns></returns>
        public static bool VerifyNotebooksAtBottomOfDashboard()
        {
            AutomationAgent.WaitForControlExists("DashboardView", "StudentMyRecentWorkInDashboard", WaitTime.DefaultWaitTime, "1");
            int yPos = AutomationAgent.GetControlPositionY("DashboardView", "StudentMyRecentWorkInDashboard", WaitTime.DefaultWaitTime, "1");
            int xPos = AutomationAgent.GetControlPositionX("DashboardView", "StudentMyRecentWorkInDashboard", WaitTime.DefaultWaitTime, "1");
            if (yPos<600 && xPos<200)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets Notebook count on Dashboard
        /// </summary>
        /// <returns></returns>
        public static int GetCountOfNotebooksInDashboard()
        {
            //int count = 0;
            //for (int i = 4; i <= 8; i++)
            //{
            //    if (AutomationAgent.VerifyControlExists("DashboardView", "NotebooksInDashboard", WaitTime.DefaultWaitTime, i.ToString()))
            //        count++;
            //    else
            //        break;
            //}
            //return count;



            int noOfNotebooks = 0;

            for (int i = 6; i > 0; i--)
            {

                DashboardCommonMethods.ClickNotebookInDashboard(i);
                if (NotebookCommonMethods.VerifyHandIconPresent())
                {
                    noOfNotebooks = i;
                    NotebookCommonMethods.ClickOnDoneCloseButton();
                    break;
                }

                NavigationCommonMethods.TapToCloseSystemTrayIfOpenByChance();
            }
            return noOfNotebooks;

        }

        public static void ClickNotebookInDashboard(int Notebookinstance)
        {
            if (Notebookinstance == 1)
                AutomationAgent.Click(170, 650);

            if (Notebookinstance == 2)
                AutomationAgent.Click(370, 650);


            if (Notebookinstance == 3)
                AutomationAgent.Click(570, 650);

            if (Notebookinstance == 4)
                AutomationAgent.Click(750, 650);

            if (Notebookinstance == 5)
                AutomationAgent.Click(950, 650);

            if (Notebookinstance == 6)
                AutomationAgent.Click(1040, 650);


            //AutomationAgent.Click("DashboardView", "NotebooksInDashboard", WaitTime.DefaultWaitTime, Notebookinstance.ToString());

            if (AutomationAgent.VerifyControlExists("LessonView", "InteractiveAvailableOnCloud", 5000))
            {
                AutomationAgent.Click("LessonView", "InteractiveAvailableOnCloud");
                AutomationAgent.Click("NoteBookMathView", "CONTINUEBtn");
            }

        }
        /// <summary>
        /// To ensure that PersonalNotebook is available in Dashboard
        /// </summary>
        /// <returns></returns>
        public static bool VerifyPersonalNotebookNotPresent(string title)
        {
            string s = AutomationAgent.GetControlText("DashboardView", "FirstNotebookTextsInDashboard", WaitTime.DefaultWaitTime, "2");
            if(s.Contains(title))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Verifies Shared Work Notifications icon
        /// </summary>
        /// <returns></returns>
        public static bool VerifySharedWorkNotifications()
        {
            AutomationAgent.Wait(200);
            return AutomationAgent.VerifyControlExists("TopMenuView", "SharingNotificationIcon");
        }

        /// <summary>
        /// Get User Name from Dashboard
        /// </summary>
        /// <returns>USer Name text</returns>
        public static string GetHelloCurrentUserName()
        {
            return AutomationAgent.GetControlText("DashboardView", "HelloUserName");
        }

        public static string ElAUnitLabel(int Unit)
        {
            string s1 = null;
            s1 = AutomationAgent.GetControlText("DashboardView", "UserLastVisitedUnitDashboard", WaitTime.DefaultWaitTime, Unit.ToString());



            return s1;
        }
        ///// <summary>
        ///// clicks on DashboardStartUnit
        ///// </summary>
        //public static void ClickOnDashBoardStartUnit()
        //{
        //    AutomationAgent.Click("DashboardView", "StartUnit");
        //}

        ///// <summary>
        ///// clicks on DashboardContinueLessons
        ///// </summary>
        //public static void ClickOnDashBoardContinueLesson()
        //{
            
        //    AutomationAgent.Click("DashboardView", "ContinueLesson");
        //    AutomationAgent.Wait(2000);
        //}
        /// <summary>
        /// verfies LessonBrowserPageTitle
        /// </summary>
        /// <returns></returns>

        public static string GetLessonBrowserPageTitle()
        {
            if(!AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonBrowserPageTitle"))
            {
                NavigationCommonMethods.ClickLessonBrowserBackButton();
            }

            return AutomationAgent.GetControlText("LessonBrowserView", "LessonBrowserPageTitle");
        }
        /// <summary>
        /// verfies LessonBrowserTaskTitle
        /// </summary>
        /// <param name="TaskTitle"></param>
        /// <returns></returns>

        public static string GetLessonBrowserTaskTitle(int TaskTitle)
        {
          if(!AutomationAgent.VerifyControlExists("LessonBrowserView", "LessonBrowserTaskTitle"))
              NavigationCommonMethods.OpenELALessonFromLessonBrowser(TaskTitle);
            
            AutomationAgent.Wait(200);
            return AutomationAgent.GetControlText("LessonBrowserView", "LessonBrowserTaskTitle");
        }
        /// <summary>
        /// verfies DashboardContinueLessons
        /// </summary>
        /// <returns></returns>
        public static bool VerifyDashboardContinueLessons(string sectionName)
        {
            if (!AutomationAgent.VerifyControlExists("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
            
            return AutomationAgent.VerifyControlExists("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);

        }



        /// <summary>
        /// Verfies Day and Date on Dashboard
        /// </summary>
        /// <returns></returns>


        public static bool VerifyDayAndDateOnDashBoard()
        {
            String DtString = AutomationAgent.GetControlText("DashboardView", "DayAndDate");

            if (AutomationAgent.VerifyControlExists("DashboardView", "DayAndDate"))
                
                return true;
            else
                return false;
           
        }
        /// <summary>
        /// Get the current date displayed on student dashboard
        /// </summary>
        /// <returns></returns>
        public static string GetDateDisplayed()
        {
            String s = AutomationAgent.GetControlText("DashboardView", "DayAndDate");
            string[] s1 = s.Split(',');
            string[] s2 = s1[1].Split(' ');
            string date = s2[2] + " " + s2[1] + s1[2];
            return date;
        }
        /// <summary>
        /// verfies Hello with Student Name
        /// </summary>
        /// <returns></returns>

        public static bool VerifyHelloWithStudentName()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "HelloStudentName");

        }
        /// <summary>
        /// Get Hello with Student Name
        /// </summary>
        /// <returns></returns>

        public static string GetHelloStudentName()
        {
            return AutomationAgent.GetControlText("DashboardView", "HelloStudentName");
        }

        public static bool VerifyProfilePhoto()
        {
           // AutomationAgent.Click("DashboardView", "UserImageDashboard");
            ClickCameraIconInDashboard();
           
            
            if (AutomationAgent.VerifyControlExists("DashboardView", "DeletePhoto"))
            {
                NavigationCommonMethods.TapToCloseSystemTrayIfOpenByChance();
                // AutomationAgent.Click("DashboardView", "UserImageDashboard");
                return true;

            }
            else
            {
                NavigationCommonMethods.TapToCloseSystemTrayIfOpenByChance();
                // AutomationAgent.Click("DashboardView", "UserImageDashboard");
                return false;
            }


        }

        public static bool VerifyProfilePhotoStudent()
        {
            // AutomationAgent.Click("DashboardView", "UserImageDashboard");
            ClickCameraIconInDashboardStudent();


            if (AutomationAgent.VerifyControlExists("DashboardView", "DeletePhoto"))
            {
                NavigationCommonMethods.TapToCloseSystemTrayIfOpenByChance();
                // AutomationAgent.Click("DashboardView", "UserImageDashboard");
                return true;

            }
            else
            {
                NavigationCommonMethods.TapToCloseSystemTrayIfOpenByChance();
                // AutomationAgent.Click("DashboardView", "UserImageDashboard");
                return false;
            }


        }


        public static bool VerifyProfilePhotoCameraIcon()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "UserImageDashboardProfileCamera");

        }

        public static void ClickOnProfilePhoto()
        {
            ClickCameraIconInDashboard();
            // AutomationAgent.Click("DashboardView", "UserImageDashboard");
        }

        public static void ClickDeletePhoto()
        {
            AutomationAgent.Click("DashboardView", "DeletePhoto");
        }

        /// <summary>
        /// Clicks CameraIcon on Dashboard
        /// </summary>

        public static void ClickCameraIconInDashboard()
        {
           // AutomationAgent.Click("DashboardView", "CameraIconInDashboard");
            LessonBrowserCommonMethods.SwipeLessonPreviewRight();
            AutomationAgent.Wait(1000);
            AutomationAgent.Click(305,495);
        }

        /// <summary>
        /// clicks camera image from cameraIcon
        /// </summary>

        public static void ClickCameraImageFromCameraIcon()
        {
            AutomationAgent.Click("NotebookView", "SelectMedia");

        }
        /// <summary>
        /// Clicks Select an Image
        /// </summary>
        public static void ClickSelectAnImage()
        {
            AutomationAgent.Click("NotebookView", "OpenAddPhoto");
        }
        /// <summary>
        /// Clicks CameraOKButton
        /// </summary>
        public static void ClickCameraOKButton()
        {
            AutomationAgent.Click("DashboardView", "CameraCropOKButton");
        }
        /// <summary>
        /// clicks CameraDeleteButton
        /// </summary>

        public static void ClickCameraDeleteButton()
        {
            AutomationAgent.Click("DashboardView", "CameraDeleteButton");
        }
        /// <summary>
        /// clicks camera RollButton
        /// </summary>
        public static void ClickCameraRollButton()
        {
            AutomationAgent.Click("DashboardView", "CameraRollButton");
        }
        /// <summary>
        /// Clicks CameraCancleButton
        /// </summary>
        public static void ClickCameraCancelButton()
        {
            AutomationAgent.Click("DashboardView", "CameraCancelButton");
        }

        public static bool verfiyReminder()
        {
            bool b1 = AutomationAgent.VerifyControlExists("DashboardView", "ReminderGridViewItem");
            return b1;
        }

        public static void ClickOnReminder()
        {
            AutomationAgent.Click("DashboardView", "ReminderGridViewItem");
        }

        public static int Getcharactercount()
        {
            int count = 0;
            string s1 = AutomationAgent.GetControlText("DashboardView", "ReminderChar");
            string[] s2 = s1.Split('/');
            count = Convert.ToInt32(s2[0]);
            return count;
        }

        public static bool InsertTextInReminder(int n)
        {
            string s1 = null;
            if(n > 500)
            {
                 for (int i = 0; i < n; i++)
                {
                    s1 += "f";
                }
            
                try
                {
                    AutomationAgent.SetText("DashboardView", "RemindereditBox", s1);
                }

                catch(Exception ex)
                {
                    return true;
                    //Assert.Fail("More Than 500 character not Allowed");
                }
            }
            else
            { 
                for (int i = 0; i < n; i++)
                {
                    s1 += "f";
                }

                AutomationAgent.SetText("DashboardView", "RemindereditBox", s1);
            }

            return false;
        }

        public static void SendText(string text)
        {
            AutomationAgent.SetText("DashboardView", "RemindereditBox", text);
        }

        public static bool verifyReminderOnDashBoard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ReminderGridViewItem");
        }

        /// <summary>
        /// Screen is Tapped
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>

        public static void TapOnScreen(int x1, int y1)
        {
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Click(x1, y1);
        }
        /// <summary>
        /// Verfies camera roll button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyCameraRollButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "CameraRollButton");

        }
        /// <summary>
        /// verfies delete photo button
        /// </summary>
        /// <returns></returns>
        public static bool VerifyDeletePhotoButton()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "DeletePhoto");
        }


        public static void ClickConceptCornerIcon()
        {
            AutomationAgent.Click("TopMenuView", "ConceptCornerIcon");
            AutomationAgent.Wait();

        }

        public static bool VerifyFooterAttributes()
        {
            if (
             AutomationAgent.VerifyControlExists("WorkBrowserView", "SenderName") &&
             AutomationAgent.VerifyControlExists("WorkBrowserView", "LastMdfdDate"))
                return true;
            else
                return false;

        }


        /// <summary>
        /// clicks User Image Second On Dashboard
        /// </summary>
        public static void ClickCameraImageSecondOnDashboard()
        {
            AutomationAgent.Click("TopMenuView", "UserImageSecondOnDashboard");
        }

        public static void ClickOncreateReminderButton()
        {
            AutomationAgent.Click("DashboardView", "ReminderCreateButton");
        }

        public static bool VerifyNewReminder(int RemNO)
        {

            return AutomationAgent.VerifyControlExists("DashboardView", "TeacherDashboardReminderView", WaitTime.DefaultWaitTime, RemNO.ToString());

        }

        public static bool VerfiyReminderAtBottom()
        {

            int ScreenWidth = AutomationAgent.GetAppWindowWidth();
            int ScreenHeight = AutomationAgent.GetAppWindowHeight();
            int YpositionofReminder = AutomationAgent.GetControlPositionY("DashboardView", "ReminderGridViewItemForNewReminder", WaitTime.DefaultWaitTime, "1");

            int Bottom = ScreenWidth - YpositionofReminder;

            if (Bottom < ScreenHeight)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static void ClickOnNewReminder(int RemiNO)
        {
            AutomationAgent.Click("DashboardView", "NewReminder", WaitTime.DefaultWaitTime, RemiNO.ToString());
        }

        public static void DeleteReminder()
        {
            while (AutomationAgent.VerifyControlExists("DashboardView", "TeacherDashboardReminderView", WaitTime.DefaultWaitTime, "1"))
            {
                AutomationAgent.Click("DashboardView", "TeacherDashboardReminderView", WaitTime.DefaultWaitTime, "1");
                AutomationAgent.Click("DashboardView", "DeleteReminder");
            }
        }


        /// <summary>
        /// To open Sent Items in Notebook from Work Browser
        /// </summary>
        /// 
        public static void ClickOnSentItems(int SentItemsinstance)
        {
            AutomationAgent.Click("WorkBrowserView", "SentButtonInCommonRead", WaitTime.DefaultWaitTime, SentItemsinstance.ToString());

            //int i = 0;
            //while (i < 5)
            //{
            //    if (AutomationAgent.VerifyControlExists("WorkBrowserView", "SentItems", WaitTime.DefaultWaitTime, i.ToString()))
            //    {
            //        AutomationAgent.Click("WorkBrowserView", "SentItems", WaitTime.DefaultWaitTime, i.ToString());
            //        break;
            //    }
            //    i++;
            //}
        }

        /// <summary>
        /// To verify SentItems Is In Center of Bottom Tile
        /// </summary>
        /// <returns></returns>
        public static bool VerifySentItemsIsCenteredAcrossBottomTile()
        {
            int ScreenSize = AutomationAgent.GetAppWindowWidth();
            int SentWorkX = AutomationAgent.GetControlPositionX("WorkBrowserView", "SentWork");
            int SentWorkWidth = AutomationAgent.GetControlWidth("WorkBrowserView", "SentWork");

            int diff = (ScreenSize / 2) - (SentWorkX + (SentWorkWidth / 2));
            if (diff == 0)
                return true;

            else
                return false;
        }

        /// <summary>
        /// To verify Close Button in SentWork 
        /// </summary>
        /// <returns></returns>
        public static bool VerifyCloseButtonInSentWork()
        {
            return AutomationAgent.VerifyControlExists("WorkBrowserView", "CloseButton");
        }

        public static void ClickOnSentWorkCommonRead()
        {
            AutomationAgent.Click("WorkBrowserView", "CloseButton");
        }


         /// <summary>
        /// Verifies TeacherSuoortButton Presence
        /// </summary>
        /// <returns>true:if present;false:absent</returns>
        public static bool VerifyTeacherSupportButtonPresent()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "TeacherSupportButton");
                            
        }


        /// <summary>
        /// Clicks on second CameraIcon on Dashboard
        /// </summary>

        public static void ClickSecondCameraIconInDashboard(string sectionName)
        {
           // AutomationAgent.Click("DashboardView", "UserImageDashboardNext");
            AutomationAgent.Click("DashboardView", "UserImageProfilePhoto", WaitTime.DefaultWaitTime, sectionName);
        }
           
        /// <summary>
        ///To verify presence of PhotoMenu
        /// </summary>
        public static bool VerifyPhotoMenu()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "UserImageDashboard")
                ||AutomationAgent.VerifyControlExists("NotebookView", "OpenAddPhoto")
                || AutomationAgent.VerifyControlExists("DashboardView", "CameraDeleteButton"))

                return true;
            else
                return false;
           
        }
      
        /// <summary>
        /// Gets the text from the reminder Edit box
        /// </summary>
        /// <returns>string: text present in the edit box</returns>
        public static string GetTextFromReminderEditBox()
        {
            return AutomationAgent.GetText("DashboardView", "RemindereditBox");
        }

        /// <summary>
        /// Clicks on Reminder Cancel Button 
        /// </summary>
        public static void ClickOnReminderCancelButton()
        {
            AutomationAgent.Click("DashboardView", "ReminderCancelButton");
        }
        /// <summary>
        /// Clicks on the existing reminder present in the dashboard
        /// </summary>
        /// <param name="RemNO"></param>
        public static void ClickExistingReminder(int RemNO)
        {
            AutomationAgent.Click("DashboardView", "TeacherDashboardReminderView", WaitTime.DefaultWaitTime, RemNO.ToString());
        }
        /// <summary>
        /// Gets the Count of Reminders created in Dashboard
        /// </summary>
        /// <returns>int: count of reminders</returns>
        public static int GetCountOfRemindersInDashboard()
        {
            int count = AutomationAgent.GetChildrenControlCount("DashboardView", "ReminderListGrid");
            return count - 1;
        }

        public static int GetPositionOfScrollbar()
        {

            bool b = AutomationAgent.VerifyControlExists("DashboardView", "HubScrollbar");
            bool b1 = AutomationAgent.VerifyControlExists("DashboardView", "HorizontalScrollbar");
            bool b2 = AutomationAgent.VerifyControlExists("DashboardView", "HorizontalThumbInScrollbar"); 
            
            
            
            
            
            
            
            return AutomationAgent.GetControlPositionX("DashboardView", "HorizontalThumbInScrollbar");
        }
        /// <summary>
        /// Verifies Student Dashboard Layout having one course
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyOneCourseLayOut()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ELAThumbnailInDashboard");
        }
        /// <summary>
        /// Verifies Student Dashboard Layout having double course
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDoubleCourseLayOut()
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ELAThumbnailInDashboard") &&
                AutomationAgent.VerifyControlExists("DashboardView", "MathThumbnailInDashboard"))
                return true;
            else
                return false;
        }

        public static bool GetReminderModificationTime(int remno,string Createdate)
        {
           return AutomationAgent.VerifyChildrenControlByName("DashboardView", "TeacherDashboardReminderView", WaitTime.DefaultWaitTime, remno.ToString(), Createdate);
        }

        public static int GetPaginationIndicatorReminderPos(int remno)
        {
            return AutomationAgent.GetControlPositionX("DashboardView", "TeacherDashboardReminderView", WaitTime.DefaultWaitTime, remno.ToString());
        }

        public static void AddPhotoInDashboardWithesizeAndReposition()
        {
            AutomationAgent.Swipe("NoteBookMathView", "PARTImage", UITestGestureDirection.Right);
        }
        /// <summary>
        /// Verifies the List of shared items present in the shared work Notification Pop Up 
        /// </summary>
        /// <param name="itemNo">int</param>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyListOfSharedItems(int itemNo)
        {
            int itemCount = 1;
            for (int i = itemNo; i <= 4; i++)
            {
                if (AutomationAgent.VerifyControlExists("TopMenuView", "ItemInNotification", WaitTime.DefaultWaitTime, itemNo.ToString()))
                    itemCount++;
                else
                    break;
            }
            if (itemCount == 5)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Verifies the Format of items shared present in Notification Fly out
        /// </summary>
        /// <param name="name">string: person name shared the item</param>
        /// <returns>bool: true(if format is right), false(if format is wrong)</returns>
        public static bool VerifyItemsFormatInNotificationOverlay(string name)
        {
            AutomationAgent.Wait(400);
            string[] s = AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, "4").Split(',');
            string[] date = AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, "5").Split(',');
            string[] s1 = s[0].Split('"');
            if (s[0].Contains("ELA") && s1[1].Contains("Unit") && s[1].Contains("Lesson") && s[2].Contains("Task") || s1[0].Contains(name + " shared") || s[2].Contains(name))
            {
                DateTime date1 = DateTime.Parse(date[0]);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Clicks on the Math's Continue lesson Button present in the Dashboard
        /// </summary>
        public static void ClickMathContinueLessonInDashboard()
        {
            AutomationAgent.Click("DashboardView", "StudentContinueLesson", WaitTime.DefaultWaitTime, "4");
        }
        /// <summary>
        /// Clicks on the Math's Start Unit Button present in the Dashboard
        /// </summary>
        public static void ClickMathStartUnitInDashboard()
        {
            AutomationAgent.Click("DashboardView", "StudentMathStartUnit", WaitTime.DefaultWaitTime, "4");
        }
        /// <summary>
        /// Clciks Class Roster in Dashboard
        /// </summary>
        public static void ClickClassRosterInDashboard()
        {
            AutomationAgent.Click("DashboardView", "ClassRoster");
        }
        /// <summary>
        /// Gets the Lesson Browser Back Button Title
        /// </summary>
        /// <returns>string</returns>
        public static string GetLessonBrowserBackButtonTitle()
        {
            return AutomationAgent.GetControlText("UnitPreviewView", "BackButton");
        }
        /// <summary>
        /// Gets the Character count present at the Top right corner of the Edit Reminder Box
        /// </summary>
        /// <param name="instance">int: instance of textblock</param>
        /// <returns>string: character count</returns>
        public static string GetCharacterCountAtTopRight(int instance)
        {
            return AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, instance.ToString());
        }
        /// <summary>
        /// Clicks on Delete button present in the Edit Reminder Box
        /// </summary>
        public static void ClickOnReminderDeleteButton()
        {
            AutomationAgent.Click("DashboardView", "DeleteReminder");
        }
        /// <summary>
        /// Verifies Section First In Dashboard
        /// </summary>
        /// <returns>true</returns>
        public static bool VerifySectionFirstInDashboard()
        {

            int children = AutomationAgent.GetChildrenControlCount("DashboardView", "DashboardHub");
            return children > 1;
            
            //return AutomationAgent.VerifyControlExists("DashboardView", "SectionFirst");
        }
        /// <summary>
        /// Verifies Section Second In Dashboard
        /// </summary>
        /// <returns>True</returns>
        public static bool VerifySectionSecondInDashboard()
        {
            //return AutomationAgent.VerifyControlExists("DashboardView", "SectionSecond");
            int children = AutomationAgent.GetChildrenControlCount("DashboardView", "DashboardHub");
            return children > 2;
        }
        /// <summary>
        /// Verifies Third Second In Dashboard
        /// </summary>
        /// <returns>true</returns>
        public static bool VerifySectionThirdInDashboard()
        {
           // return AutomationAgent.VerifyControlExists("DashboardView", "ThirdSection");
            int children = AutomationAgent.GetChildrenControlCount("DashboardView", "DashboardHub");
            return children > 3;
        }
        /// <summary>
        ///  Verifies Section  Grade In Dashboard
        /// </summary>
        /// <returns>true</returns>
        public static bool VerifySectionGradeInDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ELAThumbnailInDashboardTeacher");
        }
        /// <summary>
        /// Verifies Section In Dashboard
        /// </summary>
        /// <returns>true</returns>
        public static bool VerifySectionInDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "Section");
        }
        /// <summary>
        /// Verifies Section Grade Second In Dashboard
        /// </summary>
        /// <returns>true</returns>
        public static bool VerifySectionGradeSecondInDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "SectionGradeSecond");
        }
        /// <summary>
        /// Clicks First Section Camera Icon
        /// </summary>
        public static void ClickFirstSectionCameraIcon()
        {
            //AutomationAgent.Click("DashboardView", "FirstSectionCameraIcon");
            ClickCameraIconInDashboard();
        }
        /// <summary>
        /// Clicks Second Section Camera Icon
        /// </summary>
        public static void ClickSecondSectionCameraIconOnDashboard()
        {
             AutomationAgent.Click("DashboardView", "SecondSectionCameraIcon");
        }
        /// <summary>
        /// Clicks Third Section Camera Icon 
        /// </summary>
        public static void ClickThirdSectionCameraIconOnDashboard()
        {
            AutomationAgent.Click("DashboardView", "ThirdSectionCameraIcon");
        }
        /// Verifies Notification Overlay Opened or not
        /// </summary>
        /// <returns>bool: true(if open), false(if closed)</returns>
        public static bool VerifyNotificationOverlayOpen()
        {
            return AutomationAgent.VerifyControlExists("TopMenuView", "SharedWorkNotificationPopUp");
        }
        public static bool VerifyClassRosterPageHeader(string secinfo)
        {
            if (AutomationAgent.VerifyControlExists("DashboardView", "ClassRosterPageHeaderGrade9", 0, secinfo) || AutomationAgent.VerifyControlExists("DashboardView", "ClassRosterPageHeaderGrade12"))
            {
                return true;
            }
            else
            {
                return false;
            }
            }

        public static bool VerifyClassRosterStudentNameAndAvatar(int StudentTile)
        {

            Login login = Login.GetLogin("StudentBruceSec9Apatton");
            if (AutomationAgent.VerifyChildrensChildControlByName("TeacherModeView", "StudentTileInClassRoster", WaitTime.DefaultWaitTime, StudentTile.ToString(), login.PersonName) ||
                AutomationAgent.VerifyChildrensChildControlByName("TeacherModeView", "StudentTileInClassRoster", WaitTime.DefaultWaitTime, StudentTile.ToString(), login.PersonName) &&
                 AutomationAgent.VerifyControlExists("TeacherModeView", "StudentTileInClassRoster", WaitTime.DefaultWaitTime, StudentTile.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies Concept Corner Button Student
        /// </summary>
        /// <returns>true</returns>
        public static bool VerifyConceptCornerButtonStudent()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "StudentConceptCorner");
        }
        /// <summary>
        /// Verifies More To Explore Button Student
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyMoreToExploreButtonStudent()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "StudentMOreToEXplore");
        }
        /// <summary>
        /// Clicks More To Explore Button Student
        /// </summary>
        public static void ClickMoreToExploreButtonStudent()
        {
            AutomationAgent.Click("DashboardView", "StudentMOreToEXplore");
            AutomationAgent.Wait(20000);
        }
        /// <summary>
        /// Clicks Concept Corner Button Student
        /// </summary>
        public static void ClickConceptCornerButtonStudent()
        {
            AutomationAgent.Click("DashboardView", "StudentConceptCorner");
            AutomationAgent.Wait(20000);
        }
        /// <summary>
        /// Verifies Done Button In More To EXplore Native View
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDoneButtonInMTENativeView()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "CloseButton");
        }
        /// <summary>
        /// Verifies Done Button In Concept Corner Native View
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyDoneButtonInCCNativeView()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "CloseButton");
        }
        /// <summary>
        /// Verifies One Course Layout Teacher
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyOneCourseLayOutTeacher()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ELAThumbnailInDashboardTeacher");
        }
        /// <summary>
        /// Verifies Second Course Layout Teacher
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySecondCourseLayOutTeacher(string SectionName)
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "ELAThumbnailInDashboardTeacher") &&
                VerifyStartUnitInDashboard(SectionName);
                
            
            //if (AutomationAgent.VerifyControlExists("DashboardView", "StartUnit") &&
            //    AutomationAgent.VerifyControlExists("DashboardView", "StudentMathStartUnit"))
            //    return true;
            //else
            //    return false;
        }
       
        /// <summary>
        /// Get the Text of Parent Button
        /// </summary>
        /// <returns>string</returns>
        public static string GetTextOfBackToParentButton()
        {
            return AutomationAgent.GetControlText("UnitPreviewView", "BackButton");
        }
        /// <summary>
        /// Gets the ELA Thumbnail Title From Dashboard
        /// </summary>
        /// <param name="section">string: section</param>
        /// <returns>string: Title</returns>
        public static string GetELAThumbnailTitle(string section)
        {
            string s = AutomationAgent.GetControlText("DashboardView", "ELAThumbnailTitle", WaitTime.DefaultWaitTime, section);
            return s;
        }
        /// <summary>
        /// Clicks on Notebook In Shared Work Item 
        /// </summary>
        public static void ClickNotebookInSharedWorkItem()
        {
            AutomationAgent.Click("TopMenuView", "NotebookButtonInNotification");
        }

        /// <summary>
        /// Get The Text Of Sectioned Grade
        /// </summary>
        /// <returns>Int</returns>
        public static int GetTextOfSectionedGrade(int instance)
        {
            string s = AutomationAgent.GetControlText("TopMenuView", "TextInItemsNotification", WaitTime.DefaultWaitTime, instance.ToString());
            string[] s1 = s.Split(' ');
            return Int32.Parse(s1[2]);

        }
        /// <summary>
        /// Get Text Of First Section
        /// </summary>
        /// <returns>Int</returns>
        public static int GetTextOfSectionFirst()
        {
            string s = AutomationAgent.GetControlText("DashboardView", "SectionFirst");
            string[] s1 = s.Split('-');
            return Int32.Parse(s1[2]);
        }
        /// <summary>
        /// Get Text of Second Section
        /// </summary>
        /// <returns>Int</returns>
        public static int GetTextOfSectionSecond()
        {
            string s = AutomationAgent.GetControlText("DashboardView", "SectionSecond");
            string[] s1 = s.Split('-');
            return Int32.Parse(s1[2]);
        }
        /// <summary>
        /// Gets Text Of Second SectionedGrade
        /// </summary>
        /// <returns>Int</returns>
        public static int GetTextOfSecondSectionedGrade()
        {
            string s = AutomationAgent.GetControlText("DashboardView", "SectionGradeSecond");
            string[] s1 = s.Split(' ');
            return Int32.Parse(s1[2]);
        }

        //to-check controls
        public static string GetMoreToExploreUnitTitle()
        {
            return AutomationAgent.GetControlText("DashboardView", " ");
        }

        //to-check controls
        public static string GetConceptCornerUnitTitle()
        {
            return AutomationAgent.GetControlText("DashboardView", " ");
        }
        /// <summary>
        /// Get the grade number
        /// </summary>
        /// <returns>string: grade number</returns>
        public static string GetGradeNumber(string unit)
        {
            string s = AutomationAgent.GetControlText("UnitPreviewView", "BackButton");
            string s1 = s.Replace(" "+unit, "");
            return s1;
        }
        /// <summary>
        /// Verifies Start Unit Button Present in Dashboard of Specific Grade or not
        /// </summary>
        /// <param name="sectionName">string:- specific section name</param>
        /// <returns>bool: true(if start unit button present), false(if start unit button not present)</returns>
        public static bool VerifyStartUnitInDashboard(string sectionName)
        {
            return VerifyDashboardContinueLessons(sectionName);
            //return AutomationAgent.VerifyControlExists("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);
        }
        /// <summary>
        /// Verifies Class Roster Button Present in Dashboard of Specific Grade or not 
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns>bool: true(if Class Roster Button present), false(if Class Roster Button not present)</returns>
        public static bool VerifyClassRosterInDashboard(string sectionName)
        {
            if (!AutomationAgent.VerifyControlExists("DashboardView", "ClassRosterButton", WaitTime.DefaultWaitTime, sectionName))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
            
            return AutomationAgent.VerifyControlExists("DashboardView", "ClassRosterButton", WaitTime.DefaultWaitTime, sectionName);
        }
        /// <summary>
        /// Verifies Class Work Button Present in Dashboard of Specific Grade or not
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns>bool: true(if class work button present), false(if class work button not present)</returns>
        public static bool VerifyClassWorkInDashboard(string sectionName)
        {
            if (!AutomationAgent.VerifyControlExists("DashboardView", "ClassWorkButton", WaitTime.DefaultWaitTime, sectionName))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
            
            return AutomationAgent.VerifyControlExists("DashboardView", "ClassWorkButton", WaitTime.DefaultWaitTime, sectionName);
        }
        /// <summary>
        /// Swipes Screen to Left
        /// </summary>
        public static void SwipeLeft()
        {
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(1027, 393, 318, 429);
        }
        /// <summary>
        /// Swipes to Right
        /// </summary>
        public static void SwipeRight()
        {
            CommonReadCommonMethods.Sleep();
            AutomationAgent.Slide(318, 429, 1027, 393);
        }
        /// <summary>
        /// Clicks on Dashboard Specific Section's start unit
        /// </summary>
        /// <param name="sectionName">string: specific grade section</param>
        public static void ClickOnDashBoardStartUnit(string sectionName)
        {
            if(!AutomationAgent.VerifyControlExists("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName))
            {
                sectionName = "Lesson 1";
                if (!AutomationAgent.VerifyControlExists("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName))
                    sectionName = "Lesson 2";
            }
            int PosX = AutomationAgent.GetControlPositionX("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);
            if (PosX < 50 )
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
                AutomationAgent.Click("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);
        }
        /// <summary>
        /// Verifies User Image present in the Student's Dashboard
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyStudentDashboardProfilePhoto()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "StudentUserImage");
        }
        /// <summary>
        /// Clicks on Dashboard Specific Section's Continue Lesson
        /// </summary>
        /// <param name="sectionName">string: specific grade section</param>
        public static void ClickOnDashBoardContinueLesson(string sectionName)
        {
            int PosX = AutomationAgent.GetControlPositionX("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);
            if (PosX < 50)
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
            AutomationAgent.Click("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);
        }

        public static bool VerifyStartUnitInDashboardVisible(string sectioName)
        {
            int xPos = AutomationAgent.GetControlPositionX("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectioName);
            if (xPos > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Clicks on Class Roster Button present in Dashboard
        /// </summary>
        /// <param name="sectionName">string: specific section</param>
        public static void ClickClassRosterInDashboard(string sectionName)
        {
            int PosX = AutomationAgent.GetControlPositionX("DashboardView", "ClassRosterButton", WaitTime.DefaultWaitTime, sectionName);
            if (PosX < 50)
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
            
            AutomationAgent.Click("DashboardView", "ClassRosterButton", WaitTime.DefaultWaitTime, sectionName);
        }
        /// <summary>
        /// Verifies See All button present in the dashboard or not
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifySeeAllButtonInDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "StudentSeeAllButtonInDashboard");
        }

        /// <summary>
        /// Verifies Recent Notebook In Dashboard
        /// </summary>
        /// <returns>bool: true(if present), false(if not present)</returns>
        public static bool VerifyRecentNoteBookInDashboard()
        {
            return AutomationAgent.VerifyControlExists("DashboardView", "NotebooksInDashboard", WaitTime.DefaultWaitTime, "1");
        }

        public static void ClickCameraIconInDashboardStudent()
        {
            LessonBrowserCommonMethods.SwipeLessonPreviewRight();
            AutomationAgent.Click(345, 375);
        }

        public static bool VerifySectionTilesInOrderDescending(string Sectionname)
        {
                     
            int first = AutomationAgent.GetControlPositionX("DashboardView", "ELAThumbnailInDashboardTeacher");
            int second=0;
            if (AutomationAgent.VerifyControlExists("DashboardView", "ELA12ThumbnailInDashboardTeacher"))
                second = AutomationAgent.GetControlPositionX("DashboardView", "ELA12ThumbnailInDashboardTeacher");

            return first > 0 && second <= 0;
        }

        public static void ClickOnDashBoardStartUnitStudent(string p)
        {
            AutomationAgent.Click(500, 330);
        }

        public static string GetTextDashboardStartContinueLessons(string sectionName)
        {
             if (!AutomationAgent.VerifyControlExists("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName))
            {
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
                LessonBrowserCommonMethods.SwipeLessonPreviewLeft();
            }
             string[] StartOrContText= AutomationAgent.GetChildrenControlNames("DashboardView", "StartOrContinuebutton", WaitTime.DefaultWaitTime, sectionName);
             return StartOrContText[0];
        }
    }
}

  
