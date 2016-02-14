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
using Pearson.PSCWinAutomationFramework._K1App;


namespace Pearson.PSCWinAutomationFramework.__k1App
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class BookBuilderTests
    {
        public BookBuilderTests()
        {
        }

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
        [TestCategory("BookBuilderTests")]
        [Priority(3)]
        [WorkItem(22472)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAddBookChooseShapeUI()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                int countBefore = BookBuilderCommonMethods.GetBookCount();
                if (countBefore <= 0) 
                {
                    BookBuilderCommonMethods.CreateBook("", "");
                }
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyChooseShapeForBookBuilder(out assertFailureMessage), assertFailureMessage);
                if (countBefore <= 0)
                {
                    BookBuilderCommonMethods.DeleteBook();
                }
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests"), TestCategory("K1SmokeTests")]
        [Priority(1)]
        [WorkItem(22124)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBookBuilderPageFirstTimeAndCreateBook()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                int countBefore = BookBuilderCommonMethods.GetBookCount();
                string assertFailureMessage;
                if (countBefore > 0)
                {
                    BookBuilderCommonMethods.DeleteBook();
                }
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookBuilderPageFirstTime(out assertFailureMessage), assertFailureMessage);
                BookBuilderCommonMethods.SetBookTitleAndAuthor(login.UserName, login.PersonName);
                int countAfter = BookBuilderCommonMethods.GetBookCount();
                Assert.IsTrue(countBefore == (countAfter-1), "One book is not added");
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22240)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAddPageButtonAfterAddingThreePages()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.CreateBook();

                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(3);
                BookBuilderCommonMethods.OpenBookInEditMode();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyAddIconIsOnRight(), "Add icon is not extreme right");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests"), TestCategory("K1SmokeTests")]
        [Priority(1)]
        [WorkItem(22468)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyElementsOnFirstTimeBookBuilderPage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                string assertFailureMessage;
                BookBuilderCommonMethods.DeleteBook();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyElementsOnFirstTimeBookBuilderPage(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(22469)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyElementsChooseAShapePage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyElementsOnChooseAShapePage(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22475)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyOrderOfBooks()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                string firstBook = "2";
                string secondBook = "1";
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(firstBook, login.PersonName);
                BookBuilderCommonMethods.CreateBook(secondBook, login.PersonName);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookOrder(firstBook, secondBook), "Lastly added book is not on left");
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22479)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAddPageIconInvisibleAfterAdding25Pages()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(24);
                AutomationAgent.Wait();
                Assert.IsFalse(BookBuilderCommonMethods.VerifyAddIconExist(), "Add icon is visible");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(22215)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyCreateBooksOfAllShapes()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                
                BookShape shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, "1"), assertFailureMessage);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Portrait;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, "1"), assertFailureMessage);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Square;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, "1"), assertFailureMessage);
                BookBuilderCommonMethods.DeleteBook();

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22235)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyAdd25PagesInBreak()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(23);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyAddIconExist(), "Add icon isn't visible");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(1);
                Assert.IsFalse(BookBuilderCommonMethods.VerifyAddIconExist(), "Add icon is visible");
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageNumbersWhileSwipingInBook(out assertFailureMessage, 26), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22474)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyPreviouslyAddedBookAtRightHandSide()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                string firstBook = 2.ToString();
                string secondBook = 1.ToString();
                BookShape shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(firstBook, login.PersonName, shape);
                BookBuilderCommonMethods.CreateBook(secondBook, login.PersonName, shape);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookPreviouslyAddedBookIsPartially(out assertFailureMessage, firstBook, secondBook, shape), assertFailureMessage);
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(3)]
        [WorkItem(22227)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBookBuilderScrollFunctionality()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookShape shape = BookShape.Landscape;
                int countOfBooks = 5;
                string[] bookstitles = new string[countOfBooks];
                for (int bookindex = countOfBooks; bookindex > 0; bookindex--)
                {
                    BookBuilderCommonMethods.CreateBook(bookindex.ToString(), login.PersonName, shape);
                    bookstitles[bookindex - 1] = bookindex.ToString();
                }
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookScrolling(out assertFailureMessage, bookstitles), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22476)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDefaultTitleAndAuthor()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookShape shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(shape);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTitleAndAuthor(out assertFailureMessage, "Untitled", "Author Name"), assertFailureMessage);
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(22473)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyNewlyAddedBookIsAtCenter()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookShape shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookIsAtCenterOfScreen(out assertFailureMessage), assertFailureMessage);
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
               // NavigationCommonMethods.Logout();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(22125), WorkItem(45877)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyCreateBookOfDifferentType()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                
                BookShape shape = BookShape.Portrait;
                string title = "1";
                BookBuilderCommonMethods.CreateBook(title, login.PersonName, shape);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, title), assertFailureMessage);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookTitle(title), "Book of given title doesn't exist - " + title);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(title, login.PersonName, shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, title), assertFailureMessage);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookTitle(title), "Book of given title doesn't exist - " + title);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Square;
                BookBuilderCommonMethods.CreateBook(title, login.PersonName, shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, title), assertFailureMessage);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookTitle(title), "Book of given title doesn't exist - " + title);
                BookBuilderCommonMethods.DeleteBook();

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(24309)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBookBuilderPageBrowserSaveAndRestore()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                
                BookShape shape = BookShape.Portrait;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(9);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, "1"), assertFailureMessage);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(5);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(5), "Page 5 doesn't exist");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenPageInEditMode(10);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(10), "Page 10 doesn't exist");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                AutomationAgent.Wait();
                BookBuilderCommonMethods.OpenBookInEditMode();
                AutomationAgent.Wait();
                Assert.IsFalse(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(10), "Page 10 still exists");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Landscape;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(9);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, "1"), assertFailureMessage);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(5);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(5), "Page 5 doesn't exist");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenPageInEditMode(10);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(10), "Page 10 doesn't exist");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                AutomationAgent.Wait();
                BookBuilderCommonMethods.OpenBookInEditMode();
                AutomationAgent.Wait(); 
                Assert.IsFalse(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(10), "Page 10 still exists");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Square;
                BookBuilderCommonMethods.CreateBook(login.UserName, login.PersonName, shape);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.AddPagesToBook(9);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookShape(out assertFailureMessage, shape, "1"), assertFailureMessage);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(5);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(5), "Page 5 doesn't exist");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenPageInEditMode(10);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(10), "Page 10 doesn't exist");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                AutomationAgent.Wait();
                BookBuilderCommonMethods.OpenBookInEditMode();
                AutomationAgent.Wait(); 
                Assert.IsFalse(BookBuilderCommonMethods.VerifyPageOfBookVisibleOnScreen(10), "Page 10 still exists");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(24317)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyElementsOnPageBookBuilderPage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                string assertFailureMessage;
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Portrait.ToString(), "StudentKevin", BookShape.Portrait);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyElementsOfBookBuilderPage(BookShape.Portrait, out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(2);

                BookBuilderCommonMethods.CreateBook(BookShape.Landscape.ToString(), "StudentKevin", BookShape.Landscape);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyElementsOfBookBuilderPage(BookShape.Landscape, out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(2);

                BookBuilderCommonMethods.CreateBook(BookShape.Square.ToString(), "StudentKevin", BookShape.Square);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyElementsOfBookBuilderPage(BookShape.Square, out assertFailureMessage), assertFailureMessage);
                
                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(24321)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyContentOnPageBookBuilderPage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Portrait.ToString(), "StudentKevin", BookShape.Portrait);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();

                BookBuilderCommonMethods.AddTextBoxToBookPage(BookShape.Portrait.ToString());
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                NavigationCommonMethods.Sleep(WaitTime.LargeWaitTime);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();

                AutomationAgent.Wait();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentSophia"));
                NavigationCommonMethods.NavigateToBookBuilder();
                if (BookBuilderCommonMethods.VerifyBookExists())
                {
                    BookBuilderCommonMethods.OpenBookInEditMode();
                    BookBuilderCommonMethods.EditFirstPage();
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is found for other user");
                }
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();

                AutomationAgent.Wait();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();

                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(2);
                
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Landscape.ToString(), "StudentKevin", BookShape.Landscape);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();

                BookBuilderCommonMethods.AddTextBoxToBookPage(BookShape.Landscape.ToString());
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                NavigationCommonMethods.Sleep(WaitTime.LargeWaitTime);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentSophia"));
                NavigationCommonMethods.NavigateToBookBuilder();
                if (BookBuilderCommonMethods.VerifyBookExists())
                {
                    BookBuilderCommonMethods.OpenBookInEditMode();
                    BookBuilderCommonMethods.EditFirstPage();
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is found for other user");
                }
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();

                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(2);

                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Square.ToString(), "StudentKevin", BookShape.Square);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();

                BookBuilderCommonMethods.AddTextBoxToBookPage(BookShape.Square.ToString());
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                NavigationCommonMethods.Sleep(WaitTime.LargeWaitTime);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentSophia"));
                NavigationCommonMethods.NavigateToBookBuilder();
                if (BookBuilderCommonMethods.VerifyBookExists())
                {
                    BookBuilderCommonMethods.OpenBookInEditMode();
                    BookBuilderCommonMethods.EditFirstPage();
                    Assert.IsFalse(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is found for other user");
                }
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();

                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();

                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                Assert.IsTrue(BookBuilderCommonMethods.VerifyTextBoxToBookPage(), "Text box is not found");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(2);

                BookBuilderCommonMethods.DeleteBook();
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(1)]
        [WorkItem(22470)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyComponentsOnBookBuilderCreatePage()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                string assertFailureMessage;

                BookShape shape = BookShape.Portrait;
                BookBuilderCommonMethods.OpenCreateBookPage(shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookBuilderCreateNewBook(shape, out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Landscape;
                BookBuilderCommonMethods.OpenCreateBookPage(shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookBuilderCreateNewBook(shape, out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();

                shape = BookShape.Square;
                BookBuilderCommonMethods.OpenCreateBookPage(shape);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookBuilderCreateNewBook(shape, out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen(1);
                BookBuilderCommonMethods.DeleteBook();
                
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(27206)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyStyledDialogPromptsBookBuilderDelete()
        {
            try
            {
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(Login.GetLogin("StudentKevin"));
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                string assertFailureMessage;
                BookBuilderCommonMethods.CreateBook(BookShape.Square.ToString(), "StudentKevin", BookShape.Square);
                Assert.IsTrue(BookBuilderCommonMethods.VerifyDeletePromptBookBuilder(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(45600)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBookShifts()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                for (int j = 7; j > 0; j--)
                {
                    BookBuilderCommonMethods.CreateBook(j.ToString(), login.PersonName);
                }
                
                string assertFailureMessage;
                BookBuilderCommonMethods.VerifyDeleteBookFunctionalities(out assertFailureMessage);

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(44167), WorkItem(44166)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyPictureSnapshotAndResizableBorders()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Portrait.ToString(), login.PersonName, BookShape.Portrait);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();

                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyPictureSnapshotAndResizableBorders(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(44168)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyLandscapeAndPhotoGalleryFunction()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Portrait.ToString(), login.PersonName, BookShape.Portrait);
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.EditFirstPage();
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyLandscapeAndPhotoGalleryFunction(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(26306)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBookBuilderPortraitUI()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Portrait.ToString(), login.PersonName, BookShape.Portrait);
                BookBuilderCommonMethods.OpenBookInEditMode();
                int totalPagesAdded = 2;
                BookBuilderCommonMethods.AddPagesToBook(totalPagesAdded);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyBookBuilderPortraitUI(out assertFailureMessage, totalPagesAdded + 1), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(45599)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyDeleteBookBuilderBook()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook(BookShape.Portrait.ToString(), login.PersonName, BookShape.Portrait);
                string assertFailureMessage;
                Assert.IsTrue(BookBuilderCommonMethods.VerifyDeleteBookBuilderBook(out assertFailureMessage), assertFailureMessage);
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(53761)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void  Integrate212AssetManagerServicePlusK1Audio()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook();

                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(1);

                Assert.IsTrue(NotebookCommonMethods.VerifyCameraMicrophoneIconInNotebook(), "Add page not found");
                NotebookCommonMethods.ClickCameraMicrophoneIconInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyToolsSubMenuOpened(), "microphone camera sub menu not found");
                NotebookCommonMethods.ClickMicrophoneIcon();
                NotebookCommonMethods.ClickRecordButton();
                AutomationAgent.Wait(1500);
                NotebookCommonMethods.ClickRecordStopButton();
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();


                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(1);
                Assert.IsTrue(NotebookCommonMethods.VerifyMediaInsertedInNotebook(), "media thumbnail not found in notebook");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(53813)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Integrate212AssetManagerServicePlusK1ExistingImageFile()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook();
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(1);
                Assert.IsTrue(NotebookCommonMethods.VerifyCameraMicrophoneIconInNotebook(), "Add page not found");
               
                NotebookCommonMethods.AddImageInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(1);
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
        [TestCategory("BookBuilderTests")]
        [Priority(2)]
        [WorkItem(53779)]
        [Owner("Madhav Purohit(madhav.purohit)")]
        public void Integrate212AssetManagerServicePlusK1NewImageFile()
        {
            try
            {
                Login login = Login.GetLogin("StudentKevin");
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.DeleteBook();
                BookBuilderCommonMethods.CreateBook();
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(1);
                Assert.IsTrue(NotebookCommonMethods.VerifyCameraMicrophoneIconInNotebook(), "Add page not found");
               
                NotebookCommonMethods.AddNewImageInNotebook();
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");

                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
                NavigationCommonMethods.Logout();
                NavigationCommonMethods.LoginUsingTeacherAdminWaitingForSystemTray(login);
                NavigationCommonMethods.NavigateToBookBuilder();
                BookBuilderCommonMethods.OpenBookInEditMode();
                BookBuilderCommonMethods.OpenPageInEditMode(1);
                Assert.IsTrue(NotebookCommonMethods.VerifyPhotoAvailableInNotebook(), "photo not available in notebook");
                NavigationCommonMethods.NavigateToPreviousOrHomeScreen();
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
    }
}
