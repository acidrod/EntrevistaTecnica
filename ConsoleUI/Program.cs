namespace ConsoleUI;

using ConsoleUI.CustomExceptions.BooksExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Instrucciones:
/// 1. Completa la clase Library para que permita agregar libros y rentarlos.
/// 2. Un libro no puede ser rentado si ya está rentado.
/// 3. Cree un metodo para devolver un libro ya rentado.
/// 4. Agrega en el metodo principal un ejemplo de uso de la clase Library donde:
///     a. Se agreguen 3 libros.
///     b. Se rente un libro.
///     c. Se rente otro libro.
///     d. Devuelva el primer libro.
///     d. Que liste los libros disponibles.
/// </summary>

class Book
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
}

class Library
{
    private readonly List<Book> _books = [];

    public void AddBook(Book book)
    {
        if (GetBookById(book.Id) is not null)
            throw new BookAlreadyExistsException("Book with the same id already exists", book.Id, book.Name);

        _books.Add(book);
    }

    public void RentBook(int id)
    {
        var lookupBook = GetBookById(id) ?? throw new BookNotFoundException("Book not found", id);

        if (!lookupBook.IsAvailable)
            throw new BookNotAvailableException("Book is already rented", id, lookupBook.Name);

        lookupBook.IsAvailable = false;
    }

    public void ReturnBook(int id)
    {
        var lookupBook = GetBookById(id) ?? throw new BookNotFoundException("Book not found", id);

        if (lookupBook.IsAvailable)
            throw new BookNotRentedException("Book is not currently rented", id, lookupBook.Name);

        lookupBook.IsAvailable = true;
    }

    public List<Book> GetAvailableBooks()
    {
        return _books.Where(b => b.IsAvailable).ToList();
    }

    private Book? GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }
}

internal class Program
{
    static void Main()
    {
        var library = new Library();

        try
        {
            library.AddBook(new Book { Id = 1, Name = "Book 1" });
            library.AddBook(new Book { Id = 2, Name = "Book 2" });
            library.AddBook(new Book { Id = 3, Name = "Book 3" });

            library.RentBook(1);
            library.RentBook(1);

            library.ReturnBook(1);
        }
        catch (BookAlreadyExistsException ex)
        {
            Console.WriteLine($"Duplicate book error: {ex.Message}");
        }
        catch (BookNotFoundException ex)
        {
            Console.WriteLine($"Book not found: {ex.Message}");
        }
        catch (BookNotAvailableException ex)
        {
            Console.WriteLine($"Book unavailable: {ex.Message}");
        }
        catch (BookNotRentedException ex)
        {
            Console.WriteLine($"Book return error: {ex.Message}");
        }
        catch (BookException ex)
        {
            Console.WriteLine($"General book error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        Console.WriteLine("\nAvailable books:");
        var availableBooks = library.GetAvailableBooks();

        if (availableBooks.Count == 0)
        {
            Console.WriteLine("No books available");
        }
        else
        {
            foreach (var book in availableBooks)
                Console.WriteLine($"  • {book.Name} (ID: {book.Id})");
        }
    }
}