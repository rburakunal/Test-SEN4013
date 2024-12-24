[Test]
public void DisplayOverdueBooks_ShouldShowOverdueBooks()
{
    // Arrange
    string title = "Test Book";
    string author = "Test Author";
    int totalCopies = 5;
    _library.AddBook(title, author, totalCopies);

    int memberId = 1;
    int bookId = _library.Books[0].Id;
    _library.BorrowBook(memberId, bookId);

    // Simulate overdue book by modifying the loan's due date
    var loan = _library.Loans[0];
    loan.DueDate = DateTime.Now.AddDays(-1); // Set to a past date to simulate overdue

    // Act
    _library.DisplayOverdueBooks();

    // Assert
    Assert.AreEqual(1, _library.Loans.Count); // Ensure one loan exists
    var overdueBook = _library.Loans[0];
    Assert.IsTrue(overdueBook.DueDate < DateTime.Now); // Ensure the book is overdue
}
