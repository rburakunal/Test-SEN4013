[Test]
public void BorrowBook_ShouldUpdateInventoryAndCreateLoan()
{
    // Arrange
    string title = "1984";
    string author = "George Orwell";
    int totalCopies = 5;
    _library.AddBook(title, author, totalCopies);

    int memberId = 101;
    int bookId = _library.Books[0].Id;

    // Act
    _library.BorrowBook(memberId, bookId);

    // Assert
    var book = _library.Books[0];
    Assert.AreEqual(4, book.AvailableCopies); // Available copies should decrease by 1

    var loan = _library.Loans[0];
    Assert.AreEqual(memberId, loan.MemberId); // Loan should match member ID
    Assert.AreEqual(bookId, loan.BookId); // Loan should match book ID
    Assert.AreEqual(DateTime.Now.AddSeconds(10).Date, loan.DueDate.Date); // Due date should be set correctly
}
