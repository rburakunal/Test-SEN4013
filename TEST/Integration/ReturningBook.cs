[Test]
public void ReturnBook_ShouldUpdateInventoryAndRemoveLoan()
{
    // Arrange
    string title = "Test Book";
    string author = "Test Author";
    int totalCopies = 5;
    _library.AddBook(title, author, totalCopies);

    int memberId = 1;
    int bookId = _library.Books[0].Id;
    _library.BorrowBook(memberId, bookId);

    // Act
    _library.ReturnBook(memberId, bookId);

    // Assert
    Assert.AreEqual(5, _library.Books[0].AvailableCopies); // Ensure available copies increase
    Assert.AreEqual(0, _library.Loans.Count); // Ensure the loan is removed
}
