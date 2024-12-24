[Test]
public void BorrowBook_ShouldUpdateInventoryAndAddLoan()
{
    // Arrange
    string title = "Test Book";
    string author = "Test Author";
    int totalCopies = 5;
    _library.AddBook(title, author, totalCopies);

    int memberId = 1;
    int bookId = _library.Books[0].Id;

    // Act
    _library.BorrowBook(memberId, bookId);

    // Assert
    Assert.AreEqual(4, _library.Books[0].AvailableCopies); // Ensure available copies decrease
    Assert.AreEqual(1, _library.Loans.Count); // Ensure one loan is added
    var loan = _library.Loans[0];
    Assert.AreEqual(memberId, loan.MemberId);
    Assert.AreEqual(bookId, loan.BookId);
    Assert.AreEqual(DateTime.Now.AddSeconds(10).Date, loan.DueDate.Date); // Ensure due date is set
}
