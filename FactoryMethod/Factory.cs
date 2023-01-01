namespace FactoryMethod;
using System.Collections.Generic;

public abstract class Product
{
    public abstract void use();
}

public abstract class Factory
{

    protected abstract Product createProduct(string owner);
    protected abstract void registerProduct(Product product);

    public Product create(string owner)
    {
        Product product = createProduct(owner);
        registerProduct(product);
        return product;
    }
}

public class IDCard : Product
{
    private string owner { get; }

    public IDCard(string name)
    {
        owner = name;
        Console.WriteLine($"{owner} のカードを作成します。");
    }

    public override void use()
    {
        Console.WriteLine($"{owner}のカードを使用します。"); 
    }

    public string getOwner()
    {
        return owner;
    }
}

public class IDCardFactory : Factory
{
    private List<IDCard> owners { get;} = new List<IDCard>();
    protected override  Product createProduct(string owner)
    {
        return new IDCard(owner);
    }

    protected override void registerProduct(Product product)
    {
        // 多分ここがポイント
        // IDCardであることをしているのはIDCardFactoryだから
        owners.Add(((IDCard)product).getOwner());
    }

    public List<IDCard> getOwners()
    {
        return owners;
    }
}
