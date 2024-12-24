//End-to-End Test: Add a Book, Search, Borrow, and Return a Book

using System;
using NUnit.Framework;
using BookClass;
using LoanClass;

namespace LibraryManagementSystem.Tests
{
    public class EndToEndTests
    {
        private Library _library;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        [Test]
        public void EndToEnd_Scenario_AddSearchBorrowReturn()
        {
            // Step 1: Add a new book to the library
            string title = "The Catcher in the Rye";
            string author = "J.D. Salinger";
            int totalCopies = 3;
            _library.AddBook(title, author, totalCopies);

            // Step 2: Search for the added book by title
            _library.SearchBooks("The Catcher in the Rye");

            // Step 3: Borrow the book
            int memberId = 200;
            int bookId = _library.Books[0].Id;
            _library.BorrowBook(memberId, bookId);

            // Assert that the book's available copies have decreased by 1
            var book = _library.Books[0];
            Assert.AreEqual(2, book.AvailableCopies);

            // Assert that the loan was created correctly
            var loan = _library.Loans[0];
            Assert.AreEqual(memberId, loan.MemberId);
            Assert.AreEqual(bookId, loan.BookId);

            // Step 4: Return the book
            _library.ReturnBook(memberId, bookId);

            // Assert that the book's available copies have increased by 1
            Assert.AreEqual(3, book.AvailableCopies);

            // Assert that the loan was removed from the system
            Assert.AreEqual(0, _library.Loans.Count);
        }
    }
}
