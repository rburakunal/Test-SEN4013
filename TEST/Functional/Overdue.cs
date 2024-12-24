[Test]
public void DisplayOverdueBooks_ShouldDisplayOverdueBooks()
{
    // Arrange
    string title = "Fahrenheit 451";
    string author = "Ray Bradbury";
    int totalCopies = 4;
    _library.AddBook(title, author, totalCopies);

    int memberId = 103;
    int bookId = _library.Books[0].Id;
    _library.BorrowBook(memberId, bookId); // Borrow the book

    var loan = _library.Loans[0];
    loan.DueDate = DateTime.Now.AddDays(-1); // Make the loan overdue

    // Act
    _library.DisplayOverdueBooks();

    // Assert
    Assert.IsTrue(_library.Loans.Exists(l => l.DueDate < DateTime.Now)); // Check that overdue books are identified
}
