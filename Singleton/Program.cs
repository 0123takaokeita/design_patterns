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
        Console.WriteLine(obj == obj2 ? "objを同じインスタンを参照しています。" : "objは異なるインスタンスを参照しています。 設計を見直しましょう");
        Console.WriteLine("### END ###");
    }
}