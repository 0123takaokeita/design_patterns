namespace Decorator;

public class OldBook : BookDecorator
{
    // コンストラクタで渡したほうが 変更されることが少ない？
    // 変えられにくい = バグが発生しにくい。
    // propertyを使いまわずことが無いのであればコンストラクタのほうがいいのでは？
    protected double Rate;

    public OldBook(Book book, double rate) : base(book)
    {
        this.Rate = rate;
    }
    

    public override void Display()
    {
        base.Display();
        Console.WriteLine("値引き後の値段{0}", (book.Price * (1 - Rate)).ToString());
    }
}
