namespace FactoryMethod;

public class TVFactory : Factory
{
    private List<Product> tvs { get;} = new List<Product>();

    protected override  Product createProduct(string tv)
    {
        return new TV(tv);
    }

    protected override void registerProduct(Product product)
    {
        tvs.Add(product);
    }
}

public class TV: Product
{
    private string tv{ get; }

    public TV(string name)
    {
        tv = name;
        Console.WriteLine($"{tv} を作成します。");
    }

    public override void use()
    {
        Console.WriteLine($"{tv}を使用します。");
    }
}
