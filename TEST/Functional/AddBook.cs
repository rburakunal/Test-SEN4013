using System;
using NUnit.Framework;
using BookClass;

namespace LibraryManagementSystem.Tests
{
    public class FunctionalTests
    {
        private Library _library;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        [Test]
        public void AddBook_ShouldAddBookSuccessfully()
        {
            // Arrange
            string title = "The Great Gatsby";
            string author = "F. Scott Fitzgerald";
            int totalCopies = 10;

            // Act
            _library.AddBook(title, author, totalCopies);

            // Assert
            var book = _library.Books[0];
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(totalCopies, book.TotalCopies);
            Assert.AreEqual(totalCopies, book.AvailableCopies);
        }
    }
}
