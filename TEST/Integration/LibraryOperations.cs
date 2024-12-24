[Test]
public void LibraryOperations_ShouldWorkTogether()
{
    // Arrange
    string title = "Full Test Book";
    string author = "Test Author";
    int totalCopies = 3;
    _library.AddBook(title, author, totalCopies);

    int memberId = 1;
    int bookId = _library.Books[0].Id;

    // Act - Borrow the book
    _library.BorrowBook(memberId, bookId);
    Assert.AreEqual(2, _library.Books[0].AvailableCopies); // Available copies should decrease

    // Act - Return the book
    _library.ReturnBook(memberId, bookId);
    Assert.AreEqual(3, _library.Books[0].AvailableCopies); // Available copies should increase

    // Act - Display overdue books
    _library.BorrowBook(memberId, bookId);
    var loan = _library.Loans[0];
    loan.DueDate = DateTime.Now.AddDays(-1); // Set the loan to be overdue
    _library.DisplayOverdueBooks();

    // Assert - Overdue book should be displayed
    Assert.IsTrue(_library.Loans.Exists(l => l.DueDate < DateTime.Now)); // There should be an overdue loan
}
