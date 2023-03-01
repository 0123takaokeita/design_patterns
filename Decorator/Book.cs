namespace Decorator;

public abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public abstract void Display();
}