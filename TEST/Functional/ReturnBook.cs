[Test]
public void ReturnBook_ShouldUpdateInventoryAndRemoveLoan()
{
    // Arrange
    string title = "Brave New World";
    string author = "Aldous Huxley";
    int totalCopies = 7;
    _library.AddBook(title, author, totalCopies);

    int memberId = 102;
    int bookId = _library.Books[0].Id;
    _library.BorrowBook(memberId, bookId); // Borrow the book first

    // Act
    _library.ReturnBook(memberId, bookId);

    // Assert
    var book = _library.Books[0];
    Assert.AreEqual(7, book.AvailableCopies); // Available copies should return to the original count
    Assert.AreEqual(0, _library.Loans.Count); // There should be no loans left
}
