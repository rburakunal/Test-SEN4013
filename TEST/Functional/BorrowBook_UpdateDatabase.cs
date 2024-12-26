[Test]
public void BorrowBook_UpdateDatabase()
{
    // Arrange
    var mockDatabase = new Mock<IDatabase>();
    mockDatabase.Setup(db => db.Update(It.IsAny<Book>())); 
    var library = new Library(mockDatabase.Object);
    library.AddBook("Functional Test Book", "Functional Author", 3);

    int bookId = library.Books[0].Id;
    int memberId = 1;

    // Act
    library.BorrowBook(memberId, bookId);

    // Assert
    var borrowedBooks = library.GetBorrowedBooks(memberId);
    Assert.AreEqual(0, borrowedBooks.Count);
}
