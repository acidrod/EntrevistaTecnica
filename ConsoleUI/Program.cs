namespace ConsoleUI;
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
    public int Id { get; set; }
    public string Name { get; set; }
}

class Library
{
    private List<Book> books = new List<Book>();
    
    public void AddBook(Book book)
    {
        
    }

    public void RentBook(int id)
    {

    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book { Id = 1, Name = "Book 1" });

        Console.WriteLine("Avaliable books:");
    }
}
