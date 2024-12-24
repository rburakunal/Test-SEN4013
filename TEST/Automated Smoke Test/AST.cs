using Xunit;

public class SmokeTests
{
    [Fact]
    public void AddBookSmokeTest()
    {
        var library = new Library();
        library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", 10);
        // Verifying the result by checking if the book appears in the list
        Assert.Contains(library.Books, b => b.Title == "The Great Gatsby");
    }

    [Fact]
    public void ListBooksSmokeTest()
    {
        var library = new Library();
        library.AddBook("1984", "George Orwell", 5);
        // Verifying if "1984" is listed
        Assert.Contains(library.Books, b => b.Title == "1984");
    }

    [Fact]
    public void SearchBooksSmokeTest()
    {
        var library = new Library();
        library.AddBook("To Kill a Mockingbird", "Harper Lee", 5);
        // Verifying if search returns the correct book
        var result = library.SearchBooks("Harper Lee");
        Assert.Contains(result, b => b.Title == "To Kill a Mockingbird");
    }

    [Fact]
    public void BorrowBookSmokeTest()
    {
        var library = new Library();
        library.AddBook("The Hobbit", "J.R.R. Tolkien", 5);
        library.BorrowBook(1, 1); // Borrow the first book
        var book = library.Books.Find(b => b.Title == "The Hobbit");
        Assert.Equal(4, book.AvailableCopies);
    }

    [Fact]
    public void ReturnBookSmokeTest()
    {
        var library = new Library();
        library.AddBook("Moby Dick", "Herman Melville", 3);
        library.BorrowBook(1, 1);
        library.ReturnBook(1, 1);
        var book = library.Books.Find(b => b.Title == "Moby Dick");
        Assert.Equal(3, book.AvailableCopies);
    }
}
