namespace singleton;

public class Singleton
{
    // private でインスタンスを作っているのがポイント
    private static Singleton instance = new Singleton();

    // このコンストラクターは外から呼び出せないため インスタンスを１つに統一する事ができる。
    private Singleton()
    {
        Console.WriteLine("インスタンス生成に成功しました");
    }

    public static Singleton GetInstance()
    {
        return instance;
    }
}
public static class Program
{
    public static void Main(string[] args)
    {
        var obj = Singleton.GetInstance();
        var obj2 = Singleton.GetInstance();

        Console.WriteLine("### START ###");
        Console.WriteLine(ReferenceEquals(obj, obj2));
        Console.WriteLine("### END ###");

        var obj3= ThreadSafe.getInstance();
        var obj4= ThreadSafe.getInstance();
        Console.WriteLine(ReferenceEquals(obj3, obj4));
    }
}