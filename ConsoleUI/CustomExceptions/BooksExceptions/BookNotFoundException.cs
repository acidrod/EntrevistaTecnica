namespace ConsoleUI.CustomExceptions.BooksExceptions;

public class BookNotFoundException : BookException
{
    public BookNotFoundException(string message, int bookId)
        : base(message, bookId) { }

    public BookNotFoundException(string message)
        : base(message) { }

    public override string Message => $"{base.Message}. Book ID: {BookId}";
}
