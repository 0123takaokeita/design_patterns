namespace template_method;
using System.Linq;

public abstract class AbstractDisplay
{
    protected abstract void open();
    protected abstract void print();
    protected abstract void close();

    public void display()
    {
        open();
        print();
        close();
    }
}

public class Monitor : AbstractDisplay
{
    private readonly string name = "takao";

    /// <summary>
    /// 
    /// </summary>
    protected override void open()
    {
        Console.WriteLine($"+++ {createLine(10)} +++");
    }
    
    /// <summary>
    /// 
    /// </summary>
    protected override void print()
    {
       Console.WriteLine(string.Concat(Enumerable.Repeat(name, 10).ToArray())); 
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void close()
    {
        Console.WriteLine($"--- {createLine(10)} ---");
    }
    
    private string createLine(int lineLength)
    {
        string newLine = new string('-', lineLength);
        return newLine;
    }
}

public class Monitor2 : AbstractDisplay
{
    private readonly string name = "keita";

    /// <summary>
    /// 
    /// </summary>
    protected override void open()
    {
        Console.WriteLine($"+++ {createLine(10)} +++");
    }
    
    /// <summary>
    /// 
    /// </summary>
    protected override void print()
    {
       Console.WriteLine(string.Concat(Enumerable.Repeat(name, 10).ToArray())); 
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void close()
    {
        Console.WriteLine($"--- {createLine(10)} ---");
    }

    private string createLine(int lineLength)
    {
        string newLine = new string('-', lineLength);
        return newLine;
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        AbstractDisplay monitor = new Monitor();
        AbstractDisplay monitor2 = new Monitor2();
        monitor.display();
        monitor2.display();
    }
}