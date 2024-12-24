[Test]
public void ListBooks_ShouldListAllBooks()
{
    // Arrange
    string title1 = "Moby Dick";
    string author1 = "Herman Melville";
    int totalCopies1 = 2;
    _library.AddBook(title1, author1, totalCopies1);

    string title2 = "The Odyssey";
    string author2 = "Homer";
    int totalCopies2 = 3;
    _library.AddBook(title2, author2, totalCopies2);

    // Act
    _library.ListBooks();

    // Assert
    Assert.AreEqual(2, _library.Books.Count); // Ensure that both books are listed
}
