namespace ConsoleUI.Models;

using ConsoleUI.CustomExceptions;
using System.Collections.Generic;
using System.Linq;

public class Library
{
    private readonly List<Book> books = [];

    public void AddBook(Book book)
    {
        if(GetBookById(book.Id) is not null)
            throw new BookException($"The id for the book is repeated", book.Id);

        if (book.Id == 0)
            book.Id = books.Count + 1;

        books.Add(book);
    }

    public void RentBook(int id)
    {
        var book = GetBookById(id);
        if (book is null)
            throw new BookNotFoundException($"The book with the provided id does not exist", id);

        // change the status for the book we are renting
        book.IsAvailable = false;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return books;
    }
    
    public Book? GetBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }
}
