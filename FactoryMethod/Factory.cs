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

