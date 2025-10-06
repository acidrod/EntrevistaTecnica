namespace ConsoleUI.CustomExceptions.BooksExceptions;
using System;

/// <summary>
/// Base exception for book-related errors in the library system.
/// This class enables unified exception handling for various book operations errors (e.g., not found, already exists, not available, etc.)
/// All custom book-related exceptions should inherit from this class to provide a consistent exception hierarchy.
/// </summary>
public abstract class BookException(string message, int? bookId = null, string? bookName = null) : Exception(message)
{
    public int? BookId { get; } = bookId;
    public string? BookName { get; } = bookName;
}
