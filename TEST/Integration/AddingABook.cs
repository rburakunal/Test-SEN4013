using System;
using NUnit.Framework;
using BookClass;
using LoanClass;

namespace LibraryManagementSystem.Tests
{
    public class LibraryIntegrationTests
    {
        private Library _library;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        [Test]
        public void AddBook_ShouldUpdateInventory()
        {
            // Arrange
            string title = "Test Book";
            string author = "Test Author";
            int totalCopies = 5;

            // Act
            _library.AddBook(title, author, totalCopies);
            
            // Assert
            Assert.AreEqual(1, _library.Books.Count); // Ensure one book is added
            var addedBook = _library.Books[0];
            Assert.AreEqual(title, addedBook.Title);
            Assert.AreEqual(author, addedBook.Author);
            Assert.AreEqual(totalCopies, addedBook.TotalCopies);
            Assert.AreEqual(totalCopies, addedBook.AvailableCopies); // Ensure available copies match total copies
        }
    }
}
