namespace FactoryMethod;

public abstract class Product
{
    public abstract void use();
}

public abstract class Factory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    protected abstract Product createProduct(string owner);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    protected abstract void registerProduct(Product product);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public Product create(string owner)
    {
        var product = createProduct(owner);
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
}