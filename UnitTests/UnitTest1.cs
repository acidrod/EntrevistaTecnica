namespace UnitTests;

using ConsoleUI.Models;
using Bogus;
using FluentAssertions;

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
        _library.GetAllBooks().Should().HaveCount(2);
        _library.GetBookById(1).Should().BeEquivalentTo(books.First());
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
