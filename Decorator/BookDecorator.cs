namespace Decorator;

public abstract class BookDecorator : Book
{
    protected Book book;

    public BookDecorator(Book book)
    {
        this.book = book;
    }

    public override void Display()
    {
        book.Display();
    }
}
