namespace UnitTests;

using ConsoleUI.Models;
using Bogus;
using FluentAssertions;
using ConsoleUI.CustomExceptions;

public class LibraryTests
{
    private readonly Library _library;

    public LibraryTests()
    {
        _library = new Library();
    }

    [Fact]
    public void AddBook_ShouldAddBookToLibrary()
    {
        // Arrange
        var qtyBooks = 5;
        var books = GenerateBooks(qtyBooks);

        // Act
        foreach (var book in books)
        {
            _library.AddBook(book);
        }

        // Assert
        _library.GetAllBooks().Should().HaveCount(qtyBooks);
    }

    [Fact]
    public void AddBook_ShouldAddBookToLibraryWhenIdIsNotProvided()
    {
        // Arrange
        var books = GenerateBooks(2, noId: true);

        // Act
        foreach (var book in books)
        {
            _library.AddBook(book);
        }

        // Assert
        _library.GetAllBooks()
            .Should()
            .HaveCount(2);
        _library.GetBookById(1)
            .Should()
            .BeEquivalentTo(books.First());
        _library.GetBookById(1)?.Id
            .Should()
            .Be(1);
        _library.GetBookById(2)?.Id
            .Should()
            .Be(2);
    }

    [Fact]
    public void AddBook_ShouldNotAllowToAddABookWithTheSameId()
    {
        // Arrange
        var book = GenerateBooks(1, noId: false).First();
        _library.AddBook(book);

        // Act
        Action act = () => _library.AddBook(book);

        // Assert
        act.Should()
            .Throw<BookException>()
            .WithMessage($"The id for the book is repeated. Book ID: {book.Id}");
    }

    [Fact]
    public void RentBook_ShouldChangeTheStatusForAnExistingBook()
    {
        // Arrange
        var books = GenerateBooks(3, noId: false);

        foreach (var book in books)
        {
            _library.AddBook(book);
        }

        // Act
        _library.RentBook(books.First().Id);

        // Assert
        _library.GetBookById(books.First().Id)?.IsAvailable
            .Should()
            .BeFalse();
    }

    [Fact]
    public void RentBook_ShouldThrowBookNotFoundExceptionWhenAnIdIsNotAvailable()
    {
        // Arrange
        var books = GenerateBooks(3, noId: false);
        foreach (var book in books)
        {
            _library.AddBook(book);
        }

        // Act
        var bookId = 999;
        Action act = () => _library.RentBook(bookId);

        // Assert
        act.Should()
            .Throw<BookNotFoundException>()
            .WithMessage($"The book with the provided id does not exist. Book ID: {bookId}");
    }

    private IEnumerable<Book> GenerateBooks(int qty, bool noId = false)
    {
        var faker = new Faker();
        var books = faker.Make(qty, () => new Book
        {
            Id = noId ? 0 : faker.Random.Int(1, 1000),
            Name = faker.Lorem.Sentence(3),
            IsAvailable = true
        });

        return books;
    }
}
