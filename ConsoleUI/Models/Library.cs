namespace ConsoleUI.Models;

using System.Collections.Generic;
using System.Linq;

public class Library
{
    private readonly List<Book> books = [];

    public void AddBook(Book book)
    {
        if (book.Id == 0)
            book.Id = books.Count + 1;

        books.Add(book);
    }

    public void RentBook(int id)
    {
        throw new NotImplementedException();
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
