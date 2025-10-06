namespace ConsoleUI.CustomExceptions.BooksExceptions;

public class BookNotRentedException : BookException
{
    public BookNotRentedException(string message, int bookId, string? bookName = null)
        : base(message, bookId, bookName) { }

    public BookNotRentedException(string message)
        : base(message) { }

    public override string Message => BookName != null
        ? $"{base.Message}. Book: '{BookName}' (ID: {BookId})"
        : $"{base.Message}. Book ID: {BookId}";
}
