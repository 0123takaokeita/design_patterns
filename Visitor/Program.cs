// オンライン商品の管理システム

// 訪問者が実装すべき関数を定義する。
public abstract class Visitor
{
  public abstract void Visit(Product product);
  public abstract void Visit(Fukubukuro products);
}

// 訪問者が何をするのか？をこのクラスで実装する。
public class ProductInfoVisitor : Visitor
{
  public override void Visit(Product book)
  {
      Console.WriteLine($"Book information {book.Title},{book.Author}, {book.Pages} {book.Price}");
  }

  public override void Visit(CD cd)
  {
    Console.WriteLine($"CD information {cd.Title},{cd.Artist}, {cd.Tracks} {cd.Price}");
  }
}

public class CalcTotalVisitor : Visitor
{
  private decimal _amount { get; set; } = 0;

  public override void Visit(Book book)
  {
      Console.WriteLine($"{book.Title} は {book.Price} 円です");
      _amount += book.Price;
  }

  public override void Visit(CD cd)
  {
      Console.WriteLine($"{cd.Title} は {cd.Price} 円です");
    _amount += cd.Price;
  }

  public void Amount()
  {
    Console.WriteLine($"合計は {_amount} 円だよ！！");
  }
}

public abstract class Product
{
  public abstract void Accept(Visitor visitor);
}

public class Fukubukuro : Product
{
  private List<Product> products = new List<Product>();
  public void Add(Product product)
  {
    products.Add(product);
  }
  public override void Accept(Visitor visitor)
  {
    visitor.Visit(this);
    /*foreach (Product product in products)
    {
      product.Accept(visitor);
    }*/
  }
}

    public class Book : Product
{
  public readonly string Title;
  public readonly string Author;
  public readonly decimal Price;
  public readonly int Pages;
  
  public Book(string title, string author, decimal price, int pages)
  {
    Title = title;
    Author= author;
    Price = price;
    Pages = pages;
  }

  public override void Accept(Visitor visitor)
  {
    visitor.Visit(this);
  }
}
public class CD: Product
{
  public readonly string Title;
  public readonly string Artist;
  public readonly decimal Price;
  public readonly int Tracks;

  public CD(string title, string artist, decimal price, int tracks)
  {
    Title = title;
    Artist = artist;
    Price = price;
    Tracks = tracks;
  }

  public override void Accept(Visitor visitor)
  {
    visitor.Visit(this);
  }
}

class Program
{
  static void Main()
  {
    Fukubukuro items = new Fukubukuro();
    items.Add(new Book("visitor", "takao",200, 200));
    items.Add(new CD("single", "keita", 1000, 3));
    items.Accept(new ProductInfoVisitor());
    
    Fukubukuro items2 = new Fukubukuro();
    CalcTotalVisitor total = new CalcTotalVisitor();
    items2.Add(new Book("visitor", "takao",200, 200));
    items2.Add(new CD("single", "keita", 1000, 3));
    items2.Accept(total);
    total.Amount();
  }
}
