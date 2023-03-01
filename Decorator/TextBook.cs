namespace Decorator;

public class TextBook : Book
{
    public override void Display()
    {
        Console.WriteLine("Title: {0}", Title);
        Console.WriteLine("Author {0}", Author);
        Console.WriteLine("Price {0}", Price.ToString());
    }
    
}