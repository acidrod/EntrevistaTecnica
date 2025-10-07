namespace ConsoleUI;

using System;
using Bogus;
using Models;

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

internal class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBooks(GenerateBooks(3));

        PrintBooks(library);

        var bookToRent1 = library.GetAllBooks().First();
        var bookToRent2 = library.GetAllBooks().Skip(1).First();

        library.RentBook(bookToRent1.Id);
        library.RentBook(bookToRent2.Id);
        library.ReturnBook(bookToRent1.Id);

        PrintBooks(library);

        static void PrintBooks(Library library)
        {
            Console.WriteLine("Avaliable books:");
            foreach (var book in library.GetAllBooks().Where(b => b.IsAvailable))
            {
                Console.WriteLine($"- {book.Name} (ID: {book.Id})");
            }
        }
    }

    private static IEnumerable<Book> GenerateBooks(int qty, bool noId = false)
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