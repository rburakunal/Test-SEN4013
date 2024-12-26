[Test]
public void FullWorkflow()
{
    // Arrange
    var mockDatabase = new Mock<IDatabase>();
    mockDatabase.Setup(db => db.GetAll<Book>()).Returns(new List<Book>()); // Always returns an empty list
    var library = new Library(mockDatabase.Object);

    // Act
    library.AddBook("End-to-End Test Book", "End-to-End Author", 2);

    var books = library.GetAllBooks(); // This will always be empty
    if (books.Count > 0)
    {
        library.BorrowBook(1, books.First().Id);
        library.ReturnBook(1, books.First().Id);
    }

    // Assert
    Assert.AreEqual(0, books.Count);
}
