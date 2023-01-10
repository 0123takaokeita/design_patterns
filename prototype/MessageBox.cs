namespace prototype;

public class MessageBox
{
    private char decochar;

    public MessageBox(char decochar)
    {
        this.decochar = decochar;
    }

    public void use(stirng s)
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

    public Product createClone()
    {
        Product p = null;
        try
        {
            p = (Product)createClone();
        }
        catch (CloneNotSupportedException e)
        {
            e.printStackTrace();
        }
    }
}