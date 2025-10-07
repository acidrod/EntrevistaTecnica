namespace ConsoleUI.CustomExceptions;

public abstract class BaseBookException(string message, int? bookId = null, string? bookName = null) : Exception(message)
{
    public int? BookId { get; } = bookId;
    public string? BookName { get; } = bookName;
}

public class BookException : BaseBookException
{
    public BookException(string message, int bookId, string? bookName = null)
        : base(message, bookId, bookName) { }

    public override string Message => BookName != null
        ? $"{base.Message}. Book: '{BookName}' (ID: {BookId})"
        : $"{base.Message}. Book ID: {BookId}";
}

public class BookNotFoundException : BaseBookException
{
    public BookNotFoundException(string message, int bookId, string? bookName = null)
        : base(message, bookId, bookName) { }

    public BookNotFoundException(string message)
        : base(message) { }

    public override string Message => BookName != null
        ? $"{base.Message}. Book: '{BookName}' (ID: {BookId})"
        : $"{base.Message}. Book ID: {BookId}";
}

