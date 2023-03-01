namespace Decorator;

public class RentalBook : BookDecorator
{
    public int Period;
    public RentalBook(Book book, int period) : base(book)
    {
        if(period < 1 ) throw new Exception();
        this.Period = period;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("返却期限は{0}日後です。", Period.ToString());
    }
}
