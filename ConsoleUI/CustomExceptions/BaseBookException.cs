namespace ConsoleUI.CustomExceptions;

public abstract class BaseBookException : Exception
{
    protected BaseBookException(string message) : base(message)
    {
    }
}

public class BookNotFoundException : BaseBookException
{
    public BookNotFoundException(int id) : base($"Book with id {id} not found.")
    {
    }
}