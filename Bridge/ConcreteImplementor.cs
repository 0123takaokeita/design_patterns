namespace Bridge;

// Implementor を実装するクラス
// 作成者の実装
public class ConcreteImplementor : Implementor
{
    private string token;
    private int width;
    public ConcreteImplementor(string token)
    {
        this.token = token;
        this.width = token.Length;
    }

    public override void rawOpen()
    {
        PrintLine();
    }

    public override void rawPrint()
    {
        Console.WriteLine($"|{token}|");
    }

    public override void rawClose()
    {
        PrintLine();
    }

    private void PrintLine()
    {
        Console.Write("+");
        for (int i = 0; i < width; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("+");
    }
}
