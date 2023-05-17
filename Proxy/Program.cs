// Subject役
public interface ICacheable
{
    string GetData(string key, bool force);
}

// RealSubject役
public class Real : ICacheable
{
    // ハッシュでデータを保持する。
    private Dictionary<string, string> data = new Dictionary<string, string>();

    public Real()
    {
        // データを設定
        this.data["yahoo"] = "https://yahoo.co.jp";
        this.data["neo"] = "https://neogenia.co.jp";
        this.data["google"] = "https://google.com";
    }

    public string GetData(string key, bool force)
    {
        Console.Write("RealSubject: ");
        return data[key];
    }

    public void SetData(string key, string data)
    {
        this.data[key] = data;
    }
}

public class Proxy : ICacheable
{
    // ハッシュでデータを保持する。
    private Dictionary<string, string> cache = new Dictionary<string, string>();
    private Real real = null!;
    private object _lock = new object();

    // データを取得する。
    // forceがtrueの場合は、強制的にRealSubjectからデータを取得する。
    public string GetData(string key, bool force)
    {
        realize();

        if (force || !cache.ContainsKey(key))
        {
            cache[key] = real.GetData(key, force);
        }
        return cache[key] ?? "データがありません";
    }

    // RealSubjectを生成する。
    public void realize()
    {
        lock (_lock)
        {
            this.real ??= new Real();
        }
    }

    // Test用メソッド
    // realへのアクセ方法が思いつかなかった。
    public void SetData(string key, string data)
    {
        realize();
        this.real.SetData(key, data);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var proxy = new Proxy();
        Console.WriteLine("1度目の取得");
        Console.WriteLine(proxy.GetData("yahoo", false));
        Console.WriteLine(proxy.GetData("neo", false));
        Console.WriteLine(proxy.GetData("google", false));
        separator();

        Console.WriteLine("2度目の取得");
        Console.WriteLine(proxy.GetData("yahoo", false));
        Console.WriteLine(proxy.GetData("neo", false));
        Console.WriteLine(proxy.GetData("google", false));
        separator();

        Console.WriteLine("Realのneoをtakaoに変更");
        proxy.SetData("neo", "https://takao.co.jp");
        Console.WriteLine(proxy.GetData("yahoo", false));
        Console.WriteLine(proxy.GetData("neo", false));
        Console.WriteLine(proxy.GetData("google", false));
        separator();

        Console.WriteLine("forceで取得");
        Console.WriteLine(proxy.GetData("yahoo", true));
        Console.WriteLine(proxy.GetData("neo", true));
        Console.WriteLine(proxy.GetData("google", true));
        separator();
    }

    static void separator()
    {
        Console.WriteLine("-------------------------------");
    }
}
