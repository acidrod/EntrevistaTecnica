namespace ConsoleUI.Models;

using ConsoleUI.CustomExceptions;
using System.Collections.Generic;
using System.Linq;

public class Library : ILibrary
{
    private readonly List<Book> _books = [];

    public void AddBook(Book book)
    {
        if (GetBookById(book.Id) is not null)
            throw new BookException($"The id for the book is repeated", book.Id);

        if (book.Id == 0)
            book.Id = _books.Count + 1;

        _books.Add(book);
    }

    public void RentBook(int id)
    {
        var book = GetBookById(id) ?? throw new BookNotFoundException($"The book with the provided id does not exist", id);
        book.IsAvailable = false;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public void AddBooks(IEnumerable<Book> books)
    {
        if (books is null || !books.Any())
            return;

        try
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }
        catch (BookException)
        {
            throw;
        }
    }

    public void ReturnBook(int id)
    {
        var book = GetBookById(id) ?? throw new BookNotFoundException($"The book with the provided id does not exist", id);

        book.IsAvailable = true;
    }
}
