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
using System.Linq;

namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for NavigationCommonMethods
    /// </summary>
    public static class BookBuilderCommonMethods
    {
        /// <summary>
        /// Verify Book builder page controls
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all elements are found</returns>
        public static bool VerifyChooseShapeForBookBuilder(out string assertFailureMessage) 
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup"))
            {
                AutomationAgent.Click("BookBuilderView", "NewBookIcon");
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "NewBookLandscapeIcon"))
            {
                assertFailureMessage += "Landscape shape is not available. ";
                exists = false;
            }
            if(!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup")) {
                AutomationAgent.Click("BookBuilderView", "NewBookIcon");
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "NewBookPortraitIcon"))
            {
                assertFailureMessage += "Portrait shape is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup"))
            {
                AutomationAgent.Click("BookBuilderView", "NewBookIcon");
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "NewBookSquareIcon"))
            {
                assertFailureMessage += "Square shape is not available. ";
                exists = false;
            }
            NavigationCommonMethods.TapOnScreen(200, 200);
            return exists;
        }

        /// <summary>
        /// Verify Book builder page controls for first time
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all elements are found</returns>
        public static bool VerifyBookBuilderPageFirstTime(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderNewBookOnFirstTime"))
            {
                assertFailureMessage += "New Book icon is not available. ";
                exists = false;
            }
            else
            {
                AutomationAgent.Click("BookBuilderView", "BookBuilderNewBookOnFirstTime");
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderLandscapeOnFirstTime"))
            {
                assertFailureMessage += "Landscape icon is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderSquareOnFirstTime"))
            {
                assertFailureMessage += "Square icon is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderPortraitOnFirstTime"))
            {
                assertFailureMessage += "Portrait icon is not available. ";
                exists = false;
            } else {
                AutomationAgent.Click("BookBuilderView", "BookBuilderPortraitOnFirstTime");
            }
            return exists;
        }

        /// <summary>
        /// Sets Book with given title and author
        /// </summary>
        /// <param name="title">string title of book</param>
        /// <param name="author">string author of book</param>
        public static void SetBookTitleAndAuthor(string title, string author)
        {
            AutomationAgent.SetText("BookBuilderView", "BookBuilderTitleText", title);
            AutomationAgent.SetText("BookBuilderView", "BookBuilderAuthorText", GetAuthorName(author));
            AutomationAgent.Click("LoginView", "NavigationBarGoBackButton");
        }

        /// <summary>
        /// Get children count of book grid
        /// </summary>
        /// <returns>number of books available in grid</returns>
        public static int GetBookCount()
        {
            if (AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderBookGrid"))
            {
                return AutomationAgent.GetChildrenControlCount("BookBuilderView", "BookBuilderBookGrid");
            }
            return 0;
        }

        /// <summary>
        /// Add pages to a book
        /// </summary>
        /// <param name="pageCount">Number of pages to be added</param>
        public static void AddPagesToBook(int pageCount = 5)
        {
            int existingPages = AutomationAgent.GetChildrenControlCount("BookBuilderView", "BookBuilderAddPageGrid");
            for (int i = 0; i < pageCount; i++)
            {
                while (AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderAddPageView", 0, existingPages + "") < 0)
                {
                    AutomationAgent.Swipe("BookBuilderView", "BookBuilderAddPageGrid", UITestGestureDirection.Left,WaitTime.DefaultWaitTime,"",100);
                }
                AutomationAgent.Wait(2000);
                AutomationAgent.Click("BookBuilderView", "BookBuilderAddPageView", WaitTime.DefaultWaitTime, existingPages+"");
                existingPages++;
            }
            AutomationAgent.Click("LoginView", "NavigationBarGoBackButton");
        }

        /// <summary>
        /// Verifies Add icon is on right which appears after swiping left
        /// </summary>
        /// <returns>bool: true when we reach extreme right by swiping left and coordinate i greater than 0</returns>
        public static bool VerifyAddIconIsOnRight()
        {
            int existingPages = AutomationAgent.GetChildrenControlCount("BookBuilderView", "BookBuilderAddPageGrid");
            while (AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderAddPageView", 0, existingPages + "") < 0)
            {
                AutomationAgent.Swipe("BookBuilderView", "BookBuilderAddPageGrid", UITestGestureDirection.Left);
            }
            AutomationAgent.Swipe("BookBuilderView", "BookBuilderAddPageGrid", UITestGestureDirection.Left);
            return AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderAddPageView", 0, existingPages + "") > 0;
        }

        /// <summary>
        /// Verify Book builder page controls for first time
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all elements are found</returns>
        public static bool VerifyElementsOnFirstTimeBookBuilderPage(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderFirstNewBookTitle"))
            {
                assertFailureMessage += "Book Builder title is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderFirstNewBookHelp"))
            {
                assertFailureMessage += "Book Builder Help message is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                assertFailureMessage += "Navigation back button is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderNewBookOnFirstTimeImage"))
            {
                assertFailureMessage += "New Book icon is not available. ";
                exists = false;
            }
            int xOfGoBack = AutomationAgent.GetControlPositionX("LoginView", "NavigationBarGoBackButton");
            int widthOfGoBack = AutomationAgent.GetControlWidth("LoginView", "NavigationBarGoBackButton");
            if(xOfGoBack+ widthOfGoBack > 150) {
                assertFailureMessage += "Go Back is not on left top corner. ";
                exists = false;
            }

            int xOfBBTitle = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderFirstNewBookTitle");
            int widthOfBBTitle = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderFirstNewBookTitle");
            int yOfBBTitle = AutomationAgent.GetControlPositionY("BookBuilderView", "BookBuilderFirstNewBookTitle");
            int appWinMidPointX = AutomationAgent.GetAppWindowWidth() / 2;
            int bbTitleMidPointX = xOfBBTitle + widthOfBBTitle / 2;
            if (yOfBBTitle < 50 && (bbTitleMidPointX == appWinMidPointX || bbTitleMidPointX - appWinMidPointX < 5 || appWinMidPointX - bbTitleMidPointX < 5))
            {
                exists = true;
            }
            else
            {
                assertFailureMessage = "Book title is not in the top center. ";
            }

            int xOfNewBook = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderNewBookOnFirstTimeImage");
            if (xOfNewBook < appWinMidPointX)
            {
                assertFailureMessage += "New book is not in right side. ";
                exists = false;
            }

            int xOfHelp = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderFirstNewBookHelp");
            if (xOfHelp < xOfNewBook && xOfHelp > 0)
            {
                exists = true;
            }
            else
            {
                assertFailureMessage += "Help is not right and adjacent to New Book icon. ";
                exists = false;
            }
            return exists;
        }

        /// <summary>
        /// Verify elements on Book Builder Choose a shape page
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all elements are found</returns>
        public static bool VerifyElementsOnChooseAShapePage(out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            AutomationAgent.Click("BookBuilderView", "BookBuilderNewBookOnFirstTime");
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderFirstNewBookTitle"))
            {
                assertFailureMessage += "Book Builder title is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "ChooseBookShapeHeader"))
            {
                assertFailureMessage += "Choose a Book Shape message is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                assertFailureMessage += "Navigation back button is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderPortraitOnFirstTime"))
            {
                assertFailureMessage += "Portrait icon is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderLandscapeOnFirstTime"))
            {
                assertFailureMessage += "Landscape icon is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderSquareOnFirstTime"))
            {
                assertFailureMessage += "Square icon is not available. ";
                exists = false;
            }

            int xOfGoBack = AutomationAgent.GetControlPositionX("LoginView", "NavigationBarGoBackButton");
            int widthOfGoBack = AutomationAgent.GetControlWidth("LoginView", "NavigationBarGoBackButton");
            if (xOfGoBack + widthOfGoBack > 150)
            {
                assertFailureMessage += "Go Back is not on left top corner. ";
                exists = false;
            }

            int xOfBBTitle = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderFirstNewBookTitle");
            int widthOfBBTitle = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderFirstNewBookTitle");
            int yOfBBTitle = AutomationAgent.GetControlPositionY("BookBuilderView", "BookBuilderFirstNewBookTitle");
            int appWinMidPointX = AutomationAgent.GetAppWindowWidth() / 2;
            int bbTitleMidPointX = xOfBBTitle + widthOfBBTitle / 2;
            if (yOfBBTitle < 50 && (bbTitleMidPointX == appWinMidPointX || bbTitleMidPointX - appWinMidPointX < 5 || appWinMidPointX - bbTitleMidPointX < 5))
            {
                exists = true;
            }
            else
            {
                assertFailureMessage = "Book title is not in the top center. ";
            }

            int chooseMsgMidPointX = AutomationAgent.GetControlWidth("BookBuilderView", "ChooseBookShapeHeader") / 2 + AutomationAgent.GetControlPositionX("BookBuilderView", "ChooseBookShapeHeader");
            if (chooseMsgMidPointX == appWinMidPointX || chooseMsgMidPointX - appWinMidPointX < 5 || appWinMidPointX - chooseMsgMidPointX < 5)
            {
                exists = true;
            }
            else
            {
                assertFailureMessage = "Choose message is not in the center. ";
            }

            int xOfPortrait = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderPortraitOnFirstTime");
            int xOfLandscape = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderLandscapeOnFirstTime");
            int xOfSquare = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderSquareOnFirstTime");
            int midOfLandscape = xOfLandscape + AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderLandscapeOnFirstTime") /2;
            if (xOfPortrait < xOfLandscape && xOfLandscape < xOfSquare && (midOfLandscape == appWinMidPointX || midOfLandscape - appWinMidPointX < 5 || appWinMidPointX - midOfLandscape < 5))
            {
                exists = true;
            }
            else
            {
                assertFailureMessage = "Shapes aren't in the center. ";
            }
            
            return exists;
        }

        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="bookshape">bookshape</param>
        public static void CreateBook(string title, string author, BookShape bookshape = BookShape.Portrait)
        {
            if (AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderNewBookOnFirstTime", 100))
            {
                AutomationAgent.Click("BookBuilderView", "BookBuilderNewBookOnFirstTime");
                if (bookshape.Equals(BookShape.Portrait))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderPortraitOnFirstTime");
                }
                else if (bookshape.Equals(BookShape.Landscape))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderLandscapeOnFirstTime");
                }
                else if (bookshape.Equals(BookShape.Square))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderSquareOnFirstTime");
                }
            }
            else
            {
                if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup", 100))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookIcon");
                }
                if (bookshape.Equals(BookShape.Portrait))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookPortraitIcon");
                }
                else if (bookshape.Equals(BookShape.Landscape))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookLandscapeIcon");
                }
                else if (bookshape.Equals(BookShape.Square))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookSquareIcon");
                }             
            }
            SetBookTitleAndAuthor(title, author);
        }

        /// <summary>
        /// Opens create book page
        /// </summary>
        /// <param name="bookshape">bookshape</param>
        public static void OpenCreateBookPage(BookShape bookshape = BookShape.Portrait)
        {
            if (AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderNewBookOnFirstTime", 100))
            {
                AutomationAgent.Click("BookBuilderView", "BookBuilderNewBookOnFirstTime");
                if (bookshape.Equals(BookShape.Portrait))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderPortraitOnFirstTime");
                }
                else if (bookshape.Equals(BookShape.Landscape))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderLandscapeOnFirstTime");
                }
                else if (bookshape.Equals(BookShape.Square))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderSquareOnFirstTime");
                }
            }
            else
            {
                if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup", 100))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookIcon");
                }
                if (bookshape.Equals(BookShape.Portrait))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookPortraitIcon");
                }
                else if (bookshape.Equals(BookShape.Landscape))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookLandscapeIcon");
                }
                else if (bookshape.Equals(BookShape.Square))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookSquareIcon");
                }
            }
        }

        /// <summary>
        /// Verifies that the last added book should be at left
        /// </summary>
        /// <param name="firstBook">book name which is added first</param>
        /// <param name="secondBook">book name which is added second</param>
        /// <returns>true of newly added exists at left</returns>
        public static bool VerifyBookOrder(string firstBook, string secondBook)
        {
            int xOfFirstBook  = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookTitle", 0, firstBook);
            int xOfSecondBook = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookTitle", 0, secondBook);
            return xOfFirstBook > xOfSecondBook;
        }

        /// <summary>
        /// Verifies that Add icon exists
        /// </summary>
        /// <returns>true if Add icon is visible</returns>
        public static bool VerifyAddIconExist()
        {
            OpenBookInEditMode();
            int existingPages = AutomationAgent.GetChildrenControlCount("BookBuilderView", "BookBuilderAddPageGrid");
            return AutomationAgent.VerifyControlExists("BookBuilderView", "AddPageIcon", 0, existingPages + "");
        }

        /// <summary>
        /// Verifies Book shape by their width
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <param name="bookshape">bookshape</param>
        /// <param name="bookindex">book index</param>
        /// <returns>true if all elements are found</returns>
        public static bool VerifyBookShape(out string assertFailureMessage, BookShape bookshape = BookShape.Portrait, string bookindex = "1")
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            int widthOfShape = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderCover", 0, bookindex);
            int heightOfShape = AutomationAgent.GetControlHeight("BookBuilderView", "BookBuilderCover", 0, bookindex);
            if (bookshape.Equals(BookShape.Landscape))
            {
                exists = widthOfShape > heightOfShape;
            }
            else if (bookshape.Equals(BookShape.Portrait))
            {
                exists = widthOfShape < heightOfShape;
            }
            else if (bookshape.Equals(BookShape.Square))
            {
                exists = widthOfShape == heightOfShape;
            }
            if(!exists) {
                assertFailureMessage += "Book " + bookshape + " doesn't exist";
            }
            return exists;
        }

        /// <summary>
        /// Verifies the Page Number while swiping
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all element exist</returns>
        public static bool VerifyPageNumbersWhileSwipingInBook(out string assertFailureMessage, int pages)
        {
            int pageNumber = 1;
            bool pageExists = false;
            assertFailureMessage = string.Empty;
            while (pageNumber < pages)
            {
                pageExists = AutomationAgent.VerifyChildByName("BookBuilderView", "BookBuilderAddPageView", pageNumber.ToString(), 0, (pageNumber + 1).ToString());
                if (!pageExists)
                {
                    assertFailureMessage += pageNumber + "doesn't exist. ";
                }
                AutomationAgent.Swipe("BookBuilderView", "BookBuilderAddPageGrid", UITestGestureDirection.Left);
                pageNumber++;
            }
            return pageExists;
        }

        /// <summary>
        /// Verifies the previously added books partially visible
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <param name="firstBook">book name which is added first</param>
        /// <param name="secondBook">book name which is added second</param>
        /// <param name="bookshape">bookshape</param>
        /// <param name="bookindex">book index</param>
        /// <returns>true if all element exist</returns>
        public static bool VerifyBookPreviouslyAddedBookIsPartially(out string assertFailureMessage, string firstBook, string secondBook, BookShape bookshape = BookShape.Portrait, string bookindex = "1")
        {
            assertFailureMessage = string.Empty;
            bool exists = false;
            if (!VerifyBookOrder(firstBook, secondBook))
            {
                assertFailureMessage += "Lastly added book is not on left. ";
            }
            int widthOfShape = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderCover", 0, "2");
            if (bookshape.Equals(BookShape.Landscape))
            {
                exists = widthOfShape < 475;
            }
            else if (bookshape.Equals(BookShape.Portrait))
            {
                exists = widthOfShape < 278;
            }
            else if (bookshape.Equals(BookShape.Square))
            {
                exists = widthOfShape < 363;
            }
            if (!exists)
            {
                assertFailureMessage += "Book " + bookshape + " partially doesn't exist";
            }
            return exists;
        }

        /// <summary>
        /// Verifies scrolling on book builder page
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <param name="booktitles">string array of book title</param>
        /// <returns>true if all elements exist</returns>
        public static bool VerifyBookScrolling(out string assertFailureMessage, string[] booktitles)
        {
            int xOfBook = 0;
            assertFailureMessage = string.Empty;
            bool scroll = false;
            for (int index = 0; index < booktitles.Length; index++ )
            {
                int xOfThisBook = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookTitle", 0, booktitles[index]);
                if (xOfBook > xOfThisBook)
                {
                    assertFailureMessage += "Order of book is not correct";
                }
                else
                {
                    xOfBook = xOfThisBook;
                    scroll = true;
                }
                AutomationAgent.Swipe("BookBuilderView", "BookBuilderBookPanel", UITestGestureDirection.Left, 0, booktitles[index]);
            }
            return scroll;
        }

        /// <summary>
        /// Verifies author and title of a book
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <param name="title">title to be verified</param>
        /// <param name="author">author to be verified</param>
        /// <param name="bookindex">boonindex</param>
        /// <returns>true if all elements exists</returns>
        public static bool VerifyTitleAndAuthor(out string assertFailureMessage, string title, string author, int bookindex = 1)
        {
            assertFailureMessage = string.Empty;
            bool titleAndAuthorExists = AutomationAgent.VerifyChildByName("BookBuilderView", "BookBuilderBookPanel", title, 0, bookindex.ToString());
            if (!titleAndAuthorExists)
            {
                assertFailureMessage += "Book with title ["+title+"] doesn't exist. ";
            }
            
            titleAndAuthorExists = AutomationAgent.VerifyChildByName("BookBuilderView", "BookBuilderBookPanel", author, 0, bookindex.ToString());
            if (!titleAndAuthorExists)
            {
                assertFailureMessage += "Book with author [" + author + "] doesn't exist. ";
            }
            return titleAndAuthorExists;
        }

        /// <summary>
        /// Verifies the center of app and new books
        /// </summary>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <param name="bookindex">bookindex</param>
        /// <returns>true if newly created book is in the middle</returns>
        public static bool VerifyBookIsAtCenterOfScreen(out string assertFailureMessage, int bookindex = 1)
        {
            assertFailureMessage = string.Empty;
            bool bookIsAtCenter = false;

            int appWinWidth = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderBookGrid", 0, bookindex.ToString());
            int appWinMidPointX = appWinWidth / 2;

            int bookX = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, bookindex.ToString());
            int bookWidth = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderBookPanel", 0, bookindex.ToString());
            int bookMidPointX = bookX + (bookWidth / 2);

            if (bookMidPointX == appWinMidPointX || bookMidPointX - appWinMidPointX < 5 || appWinMidPointX- bookMidPointX < 5)
            {
                bookIsAtCenter = true;
            }
            else
            {
                assertFailureMessage = "Newly created book is not in the center. ";
            }

            return bookIsAtCenter;
        }

        /// <summary>
        /// Create a book of default and name title
        /// </summary>
        /// <param name="bookshape">book shape</param>
        public static void CreateBook(BookShape bookshape = BookShape.Portrait)
        {
            if (AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderNewBookOnFirstTime", 1000))
            {
                AutomationAgent.Click("BookBuilderView", "BookBuilderNewBookOnFirstTime");
                if (bookshape.Equals(BookShape.Portrait))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderPortraitOnFirstTime");
                }
                else if (bookshape.Equals(BookShape.Landscape))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderLandscapeOnFirstTime");
                }
                else if (bookshape.Equals(BookShape.Square))
                {
                    AutomationAgent.Click("BookBuilderView", "BookBuilderSquareOnFirstTime");
                }
            }
            else
            {
                if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup", 1000))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookIcon");
                }
                if (bookshape.Equals(BookShape.Portrait))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookPortraitIcon");
                }
                else if (bookshape.Equals(BookShape.Landscape))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookLandscapeIcon");
                }
                else if (bookshape.Equals(BookShape.Square))
                {
                    AutomationAgent.Click("BookBuilderView", "NewBookSquareIcon");
                }
            }
            AutomationAgent.Click("LoginView", "NavigationBarGoBackButton");
        }

        /// <summary>
        /// Verifies if the book of the given title exists
        /// </summary>
        /// <param name="expectedTitle">title of the book</param>
        /// <returns>true if book exists</returns>
        public static bool VerifyBookTitle(string expectedTitle)
        {
            return AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderBookTitle", 0, expectedTitle);
        }

        /// <summary>
        /// Opens a book in edit mode
        /// </summary>
        public static void OpenBookInEditMode()
        {
            AutomationAgent.Click("BookBuilderView", "BookBuilderEditButton");
        }

        /// <summary>
        /// Opens book and a page in Edit mode
        /// </summary>
        /// <param name="pageNumber">pegnumber</param>
        public static void OpenPageInEditMode(int pageNumber)
        {
            while (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageOfBook", 0, (pageNumber + 1).ToString()))
            {
                AutomationAgent.Swipe("BookBuilderView", "BookBuilderAddPageView", UITestGestureDirection.Left);
            }
            AutomationAgent.Click("BookBuilderView", "PageOfBook", 0, (pageNumber + 1).ToString());
        }

        /// <summary>
        /// Verifies if page is visible on screen
        /// </summary>
        /// <param name="pageOfBook">pageOfbook</param>
        /// <returns>true if page is visble</returns>
        public static bool VerifyPageOfBookVisibleOnScreen(int pageOfBook)
        {
            int xCoordinate = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderAddPageView", 0, (pageOfBook + 1).ToString());
            if (xCoordinate > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifies various controls on Book Builder page
        /// </summary>
        /// <param name="shape">shape of book</param>
        /// <param name="assertFailureMessage">message</param>
        /// <returns>true if all controls are found</returns>
        public static bool VerifyElementsOfBookBuilderPage(BookShape shape, out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageMoveTool"))
            {
                assertFailureMessage += "Book Builder PageMoveTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageEraserTool"))
            {
                assertFailureMessage += "Book Builder PageEraserTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageColourTool"))
            {
                assertFailureMessage += "Book Builder PageColourTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageStampTool"))
            {
                assertFailureMessage += "Book Builder PageStampTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageTypeTool"))
            {
                assertFailureMessage += "Book Builder PageTypeTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageBrushTool"))
            {
                assertFailureMessage += "Book Builder PageBrushTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageMarkerTool"))
            {
                assertFailureMessage += "Book Builder PageMarkerTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageCrayonTool"))
            {
                assertFailureMessage += "Book Builder PageCrayonTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageTableTool"))
            {
                assertFailureMessage += "Book Builder PageTableTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageBackgroundTool"))
            {
                assertFailureMessage += "Book Builder PageBackgroundTool is not available. ";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageCameraTool"))
            {
                assertFailureMessage += "Book Builder PageCameraTool is not available. ";
                exists = false;
            }

            int widthOfShape = AutomationAgent.GetControlWidth("BookBuilderView", "Page", 0);
            int heightOfShape = AutomationAgent.GetControlHeight("BookBuilderView", "Page", 0);
            if (shape.Equals(BookShape.Landscape))
            {
                exists = widthOfShape > heightOfShape;
            }
            else if (shape.Equals(BookShape.Portrait))
            {
                exists = widthOfShape < heightOfShape;
            }
            else if (shape.Equals(BookShape.Square))
            {
                exists = widthOfShape == heightOfShape;
            }
            if (!exists)
            {
                assertFailureMessage += "Book " + shape + " doesn't exist";
            }
            return exists;
        }

        /// <summary>
        /// Opens first page in Edit mode
        /// </summary>
        public static void EditFirstPage() 
        {
            AutomationAgent.Click("BookBuilderView", "BookBuilderAddPageView", 0, "2");
        }

        /// <summary>
        /// Delete books from book builder
        /// </summary>
        public static void DeleteBook()
        {
            while(AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderBookPanel", 0, "1")) 
            {
                AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "1");
                if (AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"))
                {
                    AutomationAgent.Click("LoginView", "LogoutConfirm");
                }
                else
                {
                    AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "1");
                    AutomationAgent.Click("LoginView", "LogoutConfirm");
                }
            }
        }

        public static void AddTextBoxToBookPage(string content)
        {
            AutomationAgent.Click("BookBuilderView", "PageTypeTool");
            AutomationAgent.Wait();
            AutomationAgent.SendText(content);
            NavigationCommonMethods.TapOnScreen(600, 300);
            NavigationCommonMethods.Sleep(WaitTime.LargeWaitTime);
        }

        /// <summary>
        /// Verifies textbox on Book builder page
        /// </summary>
        /// <returns></returns>
        public static bool VerifyTextBoxToBookPage()
        {
            return AutomationAgent.VerifyControlExists("BookBuilderView", "TextBox");
        }

        /// <summary>
        /// Verifies if book exists
        /// </summary>
        /// <returns>return true if exists</returns>
        public static bool VerifyBookExists()
        {
            return AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderBookPanel", 0, "1");
        }

        /// <summary>
        /// Verifies elements and sends error if any failure happens
        /// </summary>
        /// <param name="shape">Shape of book</param>
        /// <param name="assertFailureMessage">Failure message</param>
        /// <returns>true if all components are found</returns>
        public static bool VerifyBookBuilderCreateNewBook(BookShape shape, out string assertFailureMessage)
        {
            assertFailureMessage = string.Empty;
            bool exists = true;
            if (AutomationAgent.VerifyControlExists("LoginView", "NavigationBarGoBackButton"))
            {
                int xOfGoBack = AutomationAgent.GetControlPositionX("LoginView", "NavigationBarGoBackButton");
                int widthOfGoBack = AutomationAgent.GetControlWidth("LoginView", "NavigationBarGoBackButton");
                if (xOfGoBack + widthOfGoBack > 150)
                {
                    assertFailureMessage += "Go Back is not on left top corner. ";
                    exists = false;
                }
            }
            else
            {
                assertFailureMessage += "Back button is not available. ";
                exists = false;
            }

            int xOfBBTitle = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderTitle");
            int widthOfBBTitle = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderTitle");
            int yOfBBTitle = AutomationAgent.GetControlPositionY("BookBuilderView", "BookBuilderTitle");
            int appWinMidPointX = AutomationAgent.GetAppWindowWidth() / 2;
            int bbTitleMidPointX = xOfBBTitle + widthOfBBTitle / 2;
            if (yOfBBTitle < 50 && (bbTitleMidPointX == appWinMidPointX || bbTitleMidPointX - appWinMidPointX < 5 || appWinMidPointX - bbTitleMidPointX < 5))
            {
                ;
            }
            else
            {
                assertFailureMessage = "Book title is not in the top center. ";
            }

            xOfBBTitle = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderTitleText");
            widthOfBBTitle = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderTitleText");
            yOfBBTitle = AutomationAgent.GetControlPositionY("BookBuilderView", "BookBuilderTitleText");
            appWinMidPointX = AutomationAgent.GetAppWindowWidth() / 2;
            bbTitleMidPointX = xOfBBTitle + widthOfBBTitle / 2;
            if (bbTitleMidPointX == appWinMidPointX || bbTitleMidPointX - appWinMidPointX < 5 || appWinMidPointX - bbTitleMidPointX < 5)
            {
                ;
            }
            else
            {
                assertFailureMessage = "Title is not in the center. ";
            }

            xOfBBTitle = AutomationAgent.GetControlPositionX("BookBuilderView", "BY");
            widthOfBBTitle = AutomationAgent.GetControlWidth("BookBuilderView", "BY");
            int yOfBYTitle = AutomationAgent.GetControlPositionY("BookBuilderView", "BY");
            appWinMidPointX = AutomationAgent.GetAppWindowWidth() / 2;
            bbTitleMidPointX = xOfBBTitle + widthOfBBTitle / 2;
            if (yOfBBTitle < yOfBYTitle && (bbTitleMidPointX == appWinMidPointX || bbTitleMidPointX - appWinMidPointX < 5 || appWinMidPointX - bbTitleMidPointX < 5))
            {
                ;
            }
            else
            {
                assertFailureMessage = "BY is not in the center. ";
            }

            xOfBBTitle = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderAuthorText");
            widthOfBBTitle = AutomationAgent.GetControlWidth("BookBuilderView", "BookBuilderAuthorText");
            int yOfAuthorName = AutomationAgent.GetControlPositionY("BookBuilderView", "BookBuilderAuthorText");
            appWinMidPointX = AutomationAgent.GetAppWindowWidth() / 2;
            bbTitleMidPointX = xOfBBTitle + widthOfBBTitle / 2;
            if (yOfAuthorName > yOfBYTitle && (bbTitleMidPointX == appWinMidPointX || bbTitleMidPointX - appWinMidPointX < 5 || appWinMidPointX - bbTitleMidPointX < 5))
            {
                ;
            }
            else
            {
                assertFailureMessage = "Author Name is not in the center. ";
            }

            int widthOfShape = AutomationAgent.GetControlWidth("BookBuilderView", "CoverPage", 0, "1");
            int heightOfShape = AutomationAgent.GetControlHeight("BookBuilderView", "CoverPage", 0, "1");
            if (shape.Equals(BookShape.Landscape))
            {
                exists = widthOfShape > heightOfShape;
            }
            else if (shape.Equals(BookShape.Portrait))
            {
                exists = widthOfShape < heightOfShape;
            }
            else if (shape.Equals(BookShape.Square))
            {
                exists = widthOfShape == heightOfShape;
            }
            if (!exists)
            {
                assertFailureMessage += "Cover " + shape + " doesn't exist";
            }

            widthOfShape = AutomationAgent.GetControlWidth("BookBuilderView", "FirstPage", 0, "2");
            heightOfShape = AutomationAgent.GetControlHeight("BookBuilderView", "FirstPage", 0, "2");
            if (shape.Equals(BookShape.Landscape))
            {
                exists = widthOfShape > heightOfShape;
            }
            else if (shape.Equals(BookShape.Portrait))
            {
                exists = widthOfShape < heightOfShape;
            }
            else if (shape.Equals(BookShape.Square))
            {
                exists = widthOfShape == heightOfShape;
            }
            if (!exists)
            {
                assertFailureMessage += "Page 1 " + shape + " doesn't exist";
            }

            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageOfBook"))
            {
                assertFailureMessage = "1 number is not present";
                exists = false;
            }

            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "AddPageIcon", 0, "3"))
            {
                assertFailureMessage = "Add Page Icon is not present";
                exists = false;
            }

            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "DeletePage"))
            {
                assertFailureMessage = "Delete Page Icon is not present";
                exists = false;
            }

            return exists;
        }

        public static bool VerifyDeletePromptBookBuilder(out string assertFailureMessage)
        {
            bool exists = true;
            assertFailureMessage = string.Empty;
            AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "1");
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup"))
            {
                assertFailureMessage = "Delete Page popup is not present";
                exists = false;
            }
            NavigationCommonMethods.TapOnScreen(200, 200);
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "Popup"))
            {
                assertFailureMessage = "Delete Page popup is not present after tapping";
                exists = false;
            }
            if (!AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"))
            {
                assertFailureMessage = "Delete confirm is not present";
                exists = false;
            }
            AutomationAgent.Click("LoginView", "LogoutConfirm");
            return exists;
        }

        internal static bool VerifyShareIconIsAtRightSideOfEditButton()
        {
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderShareButton"))
                return false;

            int SharePosx = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderShareButton");
            int EditPosx = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderEditButton");

            return SharePosx>EditPosx;
        }

        internal static void ClickShareIconInBookBuilder()
        {
            AutomationAgent.Click("BookBuilderView", "BookBuilderShareButton");
        }

        public static bool VerifyDeleteBookFunctionalities(out string assertFailureMessage)
        {
            bool exists = true;
            assertFailureMessage = string.Empty;
            AutomationAgent.Swipe("BookBuilderView", "BookBuilderBookPanel", UITestGestureDirection.Left, 0, "3");
            int xOfRightBookBeforeDelete = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, "3");
            AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "2");
            AutomationAgent.Click("LoginView", "LogoutConfirm");
            int xOfRightBookAfterDelete = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, "3");
            if (xOfRightBookBeforeDelete < xOfRightBookAfterDelete)
            {
                assertFailureMessage = "Right most book doesn't shift to left after deleting a book";
                exists = false;
            }
            AutomationAgent.Swipe("BookBuilderView", "BookBuilderBookPanel", UITestGestureDirection.Left, 0, "4");
            int xOfLeftBookBeforeDelete = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, "2");
            AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "3");
            AutomationAgent.Click("LoginView", "LogoutConfirm");
            int xOfLeftBookAfterDelete = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, "2");
            if (xOfLeftBookBeforeDelete > xOfLeftBookAfterDelete)
            {
                assertFailureMessage = "Left most book doesn't shift to right after deleting a book";
                exists = false;
            }

            xOfRightBookBeforeDelete = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, "3");
            AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "2");
            AutomationAgent.Click("LoginView", "LogoutConfirm");
            xOfRightBookAfterDelete = AutomationAgent.GetControlPositionX("BookBuilderView", "BookBuilderBookPanel", 0, "2");
            if (xOfRightBookBeforeDelete < xOfRightBookAfterDelete)
            {
                assertFailureMessage = "Left book doesn't shift in the center";
                exists = false;
            }
            DeleteBook();
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderNewBookOnFirstTime", 100))
            {
                assertFailureMessage = "User is not navigated to Let's Make A Book page";
                exists = false;
            }
            return exists;
        }

        public static bool VerifyPictureSnapshotAndResizableBorders(out string assertFailureMessage)
        {
            bool exists = true;
            assertFailureMessage = string.Empty;
            
            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
            AutomationAgent.Click("BookBuilderView", "CameraOnlyIcon");
            AutomationAgent.Wait(2000);
            NavigationCommonMethods.TapOnScreen(400, 400);
            AutomationAgent.Wait(4000);
            AutomationAgent.Click("CameraWindow", "AcceptCameraPic");
            if (!AutomationAgent.VerifyControlExists("EReaderView", "EReaderAnnotationCropMode"))
            {
                exists = false;
                assertFailureMessage = "Crop view is not present. ";
            }
            if (!AutomationAgent.VerifyControlExists("CameraWindow", "CameraCaptureAcceptButton"))
            {
                exists = false;
                assertFailureMessage = "Check icon is not present. ";
            }
            if (!AutomationAgent.VerifyControlExists("CameraWindow", "CameraCaptureCancelButton"))
            {
                exists = false;
                assertFailureMessage = "X icon is not present. ";
            }
            AutomationAgent.Click("CameraWindow", "CameraCaptureCancelButton");
            if(AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnailClose")) {
                exists = false;
                assertFailureMessage = "Snapshot is added incorrectly after clicking cancel button. ";
            }
            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
            AutomationAgent.Click("BookBuilderView", "CameraOnlyIcon");
            AutomationAgent.Wait(2000);
            NavigationCommonMethods.TapOnScreen(400, 400);
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("CameraWindow", "AcceptCameraPic");
            ResizeImageInBookBuilder();
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("CameraWindow", "CameraCaptureAcceptButton");
            if (!AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail"))
            {
                exists = false;
                assertFailureMessage = "Snapshot isn't added after clicking check button. ";
            }
            if (!AutomationAgent.VerifyControlEnabled("BookBuilderView", "PageMoveTool"))
            {
                exists = false;
                assertFailureMessage = "Hand icon isn't active. ";
            }
            AutomationAgent.Click("NotebookView", "NotebookSnapshotThumbnailClose");
            if (AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail"))
            {
                exists = false;
                assertFailureMessage = "Image exists even after deleting. ";
            }
            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
            AutomationAgent.Click("BookBuilderView", "CameraOnlyIcon");
            AutomationAgent.Wait(2000);
            NavigationCommonMethods.TapOnScreen(400, 400);
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("CameraWindow", "AcceptCameraPic");
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("CameraWindow", "CameraCaptureAcceptButton");
            NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
            EditFirstPage();
            if (!AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail"))
            {
                exists = false;
                assertFailureMessage = "Image didn't save. ";
            }
            int xOfImage = AutomationAgent.GetControlPositionX("NotebookView", "NotebookSnapshotThumbnail");
            int xOfBackground = AutomationAgent.GetControlPositionX("NotebookView", "SnapshotBackground");
            int yOfImage = AutomationAgent.GetControlPositionY("NotebookView", "NotebookSnapshotThumbnail");
            int yOfBackground = AutomationAgent.GetControlPositionY("NotebookView", "SnapshotBackground");
            if (!((xOfImage - xOfBackground) < 100 && (yOfImage - yOfBackground) < 100))
            {
                exists = false;
                assertFailureMessage = "Image is not at left top. ";
            }
            return exists;
        }

        public static bool VerifyLandscapeAndPhotoGalleryFunction(out string assertFailureMessage)
        {
            bool exists = true;
            assertFailureMessage = string.Empty;

            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
            AutomationAgent.Click("BookBuilderView", "Landscape");
            SelectPhotoFromGallery();
            if (!AutomationAgent.VerifyControlExists("EReaderView", "EReaderAnnotationCropMode"))
            {
                exists = false;
                assertFailureMessage = "Crop view is not present. ";
            }
            if (!AutomationAgent.VerifyControlExists("CameraWindow", "CameraCaptureAcceptButton"))
            {
                exists = false;
                assertFailureMessage = "Check icon is not present. ";
            }
            if (!AutomationAgent.VerifyControlExists("CameraWindow", "CameraCaptureCancelButton"))
            {
                exists = false;
                assertFailureMessage = "X icon is not present. ";
            }
            AutomationAgent.Click("CameraWindow", "CameraCaptureCancelButton");
            if (AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnailClose"))
            {
                exists = false;
                assertFailureMessage = "Snapshot is added incorrectly after clicking cancel button. ";
            }
            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
            AutomationAgent.Click("BookBuilderView", "Landscape");
            SelectPhotoFromGallery();
            ResizeImageInBookBuilder();
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("CameraWindow", "CameraCaptureAcceptButton");
            if (!AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail"))
            {
                exists = false;
                assertFailureMessage = "Snapshot isn't added after clicking check button. ";
            }
            if (!AutomationAgent.VerifyControlEnabled("BookBuilderView", "PageMoveTool"))
            {
                exists = false;
                assertFailureMessage = "Hand icon isn't active. ";
            }
            AutomationAgent.Click("NotebookView", "NotebookSnapshotThumbnailClose");
            if (AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail"))
            {
                exists = false;
                assertFailureMessage = "Image exists even after deleting. ";
            }
            AutomationAgent.Click("BookBuilderView", "PageCameraTool");
            AutomationAgent.Click("BookBuilderView", "Landscape");
            SelectPhotoFromGallery();
            AutomationAgent.Wait(2000);
            AutomationAgent.Click("CameraWindow", "CameraCaptureAcceptButton");
            NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
            EditFirstPage();
            if (!AutomationAgent.VerifyControlExists("NotebookView", "NotebookSnapshotThumbnail"))
            {
                exists = false;
                assertFailureMessage = "Image didn't save. ";
            }
            int xOfImage = AutomationAgent.GetControlPositionX("NotebookView", "NotebookSnapshotThumbnail");
            int xOfBackground = AutomationAgent.GetControlPositionX("NotebookView", "SnapshotBackground");
            int yOfImage = AutomationAgent.GetControlPositionY("NotebookView", "NotebookSnapshotThumbnail");
            int yOfBackground = AutomationAgent.GetControlPositionY("NotebookView", "SnapshotBackground");
            if (!((xOfImage - xOfBackground) < 100 && (yOfImage - yOfBackground) < 100))
            {
                exists = false;
                assertFailureMessage = "Image is not at left top. ";
            }
            return exists;
        }

        public static void ResizeImageInBookBuilder()
        {
            int ImgX = AutomationAgent.GetControlPositionX("EReaderView", "EReaderAnnotationCropMode");
            int ImgY = AutomationAgent.GetControlPositionX("EReaderView", "EReaderAnnotationCropMode");
            AutomationAgent.Stretch(ImgX + 50, ImgY + 50, ImgX + 100, ImgY + 100, 50);
        }

        public static void SelectPhotoFromGallery()
        {
            AutomationAgent.ClickChildrensChildByNameAtFirstLevel("CameraWindow", "GridGroup", 0, "", "JPG");
            AutomationAgent.Click("CameraWindow", "OpenAddPhoto");
        }

        public static string GetAuthorName(string name="Dummy")
        {
            if (name.Contains(" "))
            {
                name = name.Substring(0, name.IndexOf(" "));
                if (name.Length > 16)
                {
                    name = name.Substring(0, 15);
                }
            }
            return name;
        }

        public static bool VerifyBookBuilderPortraitUI(out string assertFailureMessage, int totalPagesAdded)
        {
            bool exists = true;
            assertFailureMessage = String.Empty;
            AutomationAgent.Click("BookBuilderView", "BookBuilderBookPanel", 0, "1");
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PortraitCoverImage"))
            {
                exists = false;
                assertFailureMessage = "Cover image doesn't exist. ";
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageLabel", 0, "Cover"))
            {
                exists = false;
                assertFailureMessage = "Incorrect Cover page number on portrait page. ";
            }
            AutomationAgent.Click("BookBuilderView", "NextButton", 0, "4");
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PageLabel", 0, "1 of " + totalPagesAdded))
            {
                exists = false;
                assertFailureMessage = "Incorrect 1 of X on portrait page. ";
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PortraitFlipViewItemFirstPage", 0, "1"))
            {
                exists = false;
                assertFailureMessage = "First page doesn't exist on first portrait page. ";
            }
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PortraitFlipViewItemFirstPage", 0, "2"))
            {
                exists = false;
                assertFailureMessage = "Second page doesn't exist on first portrait page. ";
            }
            AutomationAgent.Click("BookBuilderView", "NextButton", 0, "5");
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "PortraitFlipViewItemLastPage", 0, "1"))
            {
                exists = false;
                assertFailureMessage = "First page doesn't exist on last portrait page. ";
            }
            if (AutomationAgent.VerifyControlVisible("BookBuilderView", "PortraitFlipViewItemLastPage", 0, "2"))
            {
                exists = false;
                assertFailureMessage = "First page doesn't exist on last portrait page. ";
            }
            NavigationCommonMethods.TapOnScreen(250, 250);
            AutomationAgent.Click("BookBuilderView", "BackButton");
            return exists;
        }

        public static bool VerifyDeleteBookBuilderBook(out string assertFailureMessage)
        {
            bool exists = true;
            assertFailureMessage = String.Empty;
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderTrashCan"))
            {
                exists = false;
                assertFailureMessage = "Trash icon doesn't exist. ";
            }
            AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "1"); 
            if (!AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"))
            {
                exists = false;
                assertFailureMessage = "Confirmation popup is not appearing. ";
            }
            AutomationAgent.Click("LoginView", "LogoutCancel");
            if (!AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderBookPanel", 0, "1"))
            {
                exists = false;
                assertFailureMessage = "Book is not present. ";
            }
            if (AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"))
            {
                exists = false;
                assertFailureMessage = "Confirmation popup is still appearing. ";
            }
            AutomationAgent.DragAndDrop("BookBuilderView", "BookBuilderBookPanel", "BookBuilderView", "BookBuilderTrashCan", 0, "1");
            NavigationCommonMethods.TapOnScreen(200, 200);
            if (!AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"))
            {
                exists = false;
                assertFailureMessage = "Confirmation popup is not appearing. ";
            }
            AutomationAgent.Click("LoginView", "LogoutConfirm");
            if (AutomationAgent.VerifyControlExists("BookBuilderView", "BookBuilderBookPanel", 0, "1"))
            {
                exists = false;
                assertFailureMessage = "Book is not deleted. ";
            }
            if (AutomationAgent.VerifyControlExists("LoginView", "LogoutConfirm"))
            {
                exists = false;
                assertFailureMessage = "Confirmation popup is still appearing. ";
            }
            return exists;
        }

      

        public static bool VerifyBookShapeInbox(BookShape bookshape)
        {
            int widthOfShape = AutomationAgent.GetControlWidth("InboxView", "InboxSharedWorkTileItem");
            int heightOfShape = AutomationAgent.GetControlHeight("InboxView", "InboxSharedWorkTileItem");

           if (bookshape.Equals(BookShape.Landscape))
           {
               return widthOfShape > heightOfShape;
           }
           else if (bookshape.Equals(BookShape.Portrait))
           {
               return widthOfShape < heightOfShape;
           }
           else if (bookshape.Equals(BookShape.Square))
           {
               return widthOfShape == heightOfShape;
           }

           return false;
        }
    }

    public enum BookShape
    {
        Portrait,
        Landscape,
        Square
    };
}   