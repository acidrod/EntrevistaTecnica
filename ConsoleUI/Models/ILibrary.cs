
namespace ConsoleUI.Models
{
    public interface ILibrary
    {
        void AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book? GetBookById(int id);
        void RentBook(int id);
        void AddBooks(IEnumerable<Book> books);
        void ReturnBook(int id);
    }
}