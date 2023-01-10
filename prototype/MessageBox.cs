namespace prototype;

public class MessageBox : Product
{
    private char decochar;
    
    /// <summary>
    /// ICloneableの実装
    /// </summary>
    /// <returns></returns>
    public object Clone()
    {
        return MemberwiseClone();
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="decochar"></param>
    public MessageBox(char decochar)
    {
        this.decochar = decochar;
    }

    /// <summary>
    /// なにをするか
    /// </summary>
    /// <param name="s"></param>
    public void use(string s)
    {
        int length = s.getBytes().length;
        for (int i = 0; i < length + 4; i++)
        {
            Console.WriteLine(this.decochar);
        }
        Console.WriteLine("");
        Console.WriteLine(this.decochar + " " + s + " " + decochar);
        for (int i = 0; i < length + 4; i++)
        {
            Console.WriteLine(this.decochar);
        }
        Console.WriteLine("");
    }

    /// <summary>
    /// ここれ例外
    /// </summary>
    /// <returns></returns>
    public Product createClone()
    {
        Product p = null;
        try
        {
            return p = (Product)Clone();
        }
        catch (CloneNotSupportedException e)
        {
            e.printStackTrace();
        }
    }
}