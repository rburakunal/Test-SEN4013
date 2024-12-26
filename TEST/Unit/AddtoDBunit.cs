[Test]
public void AddToDBunit()
{
    // Arrange
    var mockDatabase = new Mock<IDatabase>();
    mockDatabase.Setup(db => db.Add(It.IsAny<Book>())); 
    var library = new Library(mockDatabase.Object);

    // Act
    library.AddBook("Unit Test Book", "Author Test", 5);

    // Assert
    var books = library.GetAllBooks();
    Assert.AreEqual(0, books.Count);
}