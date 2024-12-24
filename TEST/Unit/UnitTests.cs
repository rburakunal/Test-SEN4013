using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LibraryManagementSystem.Tests
{
    public class LibraryTests
    {
        private Library _library;

        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        [Test]
        public void AddBook_ShouldAddBookToInventory()
        {
            var book = new Book("123", "Test Book", "Author", 5);
            _library.AddBook(book);
            Assert.AreEqual(1, _library.Inventory.Count);
            Assert.AreEqual(book, _library.Inventory["123"]);
        }

        [Test]
        public void BorrowBook_ShouldReduceAvailableCopies()
        {
            var book = new Book("123", "Test Book", "Author", 5);
            _library.AddBook(book);
            bool result = _library.BorrowBook("123");

            Assert.IsTrue(result);
            Assert.AreEqual(4, _library.Inventory["123"].AvailableCopies);
        }

        [Test]
        public void ReturnBook_ShouldIncreaseAvailableCopies()
        {
            var book = new Book("123", "Test Book", "Author", 5);
            _library.AddBook(book);
            _library.BorrowBook("123");
            bool result = _library.ReturnBook("123");

            Assert.IsTrue(result);
            Assert.AreEqual(5, _library.Inventory["123"].AvailableCopies);
        }

        [Test]
        public void SearchBooks_ShouldReturnMatchingBooks()
        {
            var book1 = new Book("123", "Test Book", "Author A", 5);
            var book2 = new Book("124", "Another Test", "Author B", 3);
            _library.AddBook(book1);
            _library.AddBook(book2);

            var result = _library.SearchBooks("Test");

            Assert.AreEqual(2, result.Count);
            Assert.Contains(book1, result);
            Assert.Contains(book2, result);
        }

        [Test]
        public void DisplayOverdueBooks_ShouldReturnOverdueBooks()
        {
            var book = new Book("123", "Test Book", "Author", 5);
            _library.AddBook(book);
            _library.BorrowBook("123");

            var loan = _library.LoanList.Find(l => l.BookId == "123");
            loan.DueDate = DateTime.Now.AddDays(-1); // Simulate overdue

            var overdueBooks = _library.DisplayOverdueBooks();

            Assert.AreEqual(1, overdueBooks.Count);
            Assert.AreEqual("123", overdueBooks[0].BookId);
        }
    }

    public class Library
    {
        public Dictionary<string, Book> Inventory { get; private set; } = new();
        public List<Loan> LoanList { get; private set; } = new();

        public void AddBook(Book book)
        {
            if (!Inventory.ContainsKey(book.Id))
                Inventory[book.Id] = book;
        }

        public bool BorrowBook(string bookId)
        {
            if (Inventory.ContainsKey(bookId) && Inventory[bookId].AvailableCopies > 0)
            {
                Inventory[bookId].AvailableCopies--;
                LoanList.Add(new Loan { BookId = bookId, DueDate = DateTime.Now.AddDays(14) });
                return true;
            }
            return false;
        }

        public bool ReturnBook(string bookId)
        {
            var loan = LoanList.Find(l => l.BookId == bookId);
            if (loan != null)
            {
                LoanList.Remove(loan);
                Inventory[bookId].AvailableCopies++;
                return true;
            }
            return false;
        }

        public List<Book> SearchBooks(string query)
        {
            var results = new List<Book>();
            foreach (var book in Inventory.Values)
            {
                if (book.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(book);
                }
            }
            return results;
        }

        public List<Loan> DisplayOverdueBooks()
        {
            return LoanList.FindAll(l => l.DueDate < DateTime.Now);
        }
    }

    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AvailableCopies { get; set; }

        public Book(string id, string title, string author, int availableCopies)
        {
            Id = id;
            Title = title;
            Author = author;
            AvailableCopies = availableCopies;
        }
    }

    public class Loan
    {
        public string BookId { get; set; }
        public DateTime DueDate { get; set; }
    }
}