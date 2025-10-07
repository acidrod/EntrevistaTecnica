namespace ConsoleUI.Models;

public class Book
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
}
