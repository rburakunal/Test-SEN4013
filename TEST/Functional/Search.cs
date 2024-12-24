[Test]
public void SearchBooks_ShouldReturnCorrectResults()
{
    // Arrange
    string title1 = "To Kill a Mockingbird";
    string author1 = "Harper Lee";
    int totalCopies1 = 3;
    _library.AddBook(title1, author1, totalCopies1);

    string title2 = "Pride and Prejudice";
    string author2 = "Jane Austen";
    int totalCopies2 = 5;
    _library.AddBook(title2, author2, totalCopies2);

    // Act
    string searchTerm = "Harper Lee";
    _library.SearchBooks(searchTerm);

    // Assert
    Assert.AreEqual(1, _library.Books.Count); // Only one result should be returned
    var book = _library.Books[0];
    Assert.AreEqual(title1, book.Title);
    Assert.AreEqual(author1, book.Author);
}
