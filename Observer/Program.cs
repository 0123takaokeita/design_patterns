using System.Linq;

/// <summary>
///  Observer
/// </summary>
interface IObserver<T>
{
    void Update(T subject);
}

/// <summary>
/// ConcreteObserver
/// </summary>
class CartObserver : IObserver<Subject>
{
    /// <summary>
    /// Updateの実装
    /// 更新通知がきたときの処理を実装する
    /// </summary>
    /// <param name="shoppingCart"></param>
    public void Update(Subject subject)
    {
        Console.WriteLine("商品かごに変更がありました。");
        Console.WriteLine($"合計金額 {subject.CalculateTotal()}");

    }
}

/// <summary>
/// Subject役で通知部分を実装する。
/// </summary>
class Subject
{
    // observerのリスト
    private List<T> observers = new List<T>();

    /// <summary>
    /// Observerの登録
    /// </summary>
    /// <param name="observer"></param>
    public void RegisterObserver(T observer)
    {
        observers.Add(observer);
    }

    /// <summary>
    /// Observerの解除
    /// </summary>
    /// <param name="observer"></param>
    public void RemoveObserver(T observer)
    {
        observers.Remove(observer);
    }

    /// <summary>
    /// 登録しているObserverに通知する機能
    /// </summary>
    private void NotifyObservers()
    {
        observers.ForEach(ob => ob.Update(this));
    }

}

/// <summary>
/// Subject 役
/// </summary>
class ShoppingCart : Subject
{
    // 商品のリスト
    private List<Item> items = new List<Item>();

    /// <summary>
    /// Itemの追加
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        items.Add(item);
        // 削除したので通知する
        NotifyObservers();
    }

    /// <summary>
    /// Itemの削除
    /// </summary>
    /// <param name="item"></param>

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        // 削除したので通知する
        NotifyObservers();
    }

    /// <summary>
    /// 買い物かごの合計を実施
    /// </summary>
    /// <returns></returns>
    public decimal CalculateTotal()
    {
        return items.Sum(item => item.Price);
    }


    /// <summary>
    /// 現在の買い物かごの状態を確認する。
    /// </summary>
    public void Display()
    {
        foreach (Item item in items)
        {
            Console.WriteLine($"名前： {item.Name}  値段：{item.Price}");
        }
        Console.WriteLine($"現在の合計金額： {CalculateTotal()}");
    }
}


/// <summary>
/// Product
/// 商品のクラス
/// </summary>
class Item
{
    public string Name { get; }
    public decimal Price { get; }

    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

/// <summary>
/// Client 役
/// </summary>
internal static class Program
{
    static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        var observer = new CartObserver();
        // var observer2 = new CartObserver();
        cart.RegisterObserver(observer);
        // cart.RegisterObserver(observer2);

        while (true)
        {
            Console.WriteLine("登録： a,  削除: r,  終了: c, 表示: d");
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'c')
            {
                break;
            };

            switch (key.KeyChar)
            {
                case 'a':
                    Console.WriteLine("商品名を入力してください。 ");
                    var name = Console.ReadLine();
                    Console.WriteLine("金額を入力してください。 ");
                    var price = int.Parse(Console.ReadLine());
                    cart.AddItem(new Item(name, price));
                    break;
                case 'r': break;
                case 'd':
                    cart.Display();
                    break;
            }
        }

        // var apple = new Item("apple", 5000);
        // var banana = new Item("banana", 1000);
        // var berry = new Item("berry", 4000);

        // cart.AddItem(apple);
        // cart.AddItem(banana);
        // cart.AddItem(berry);
    }
}
