namespace prototype;

public interface Product : ICloneable
{
    public abstract void use(string s);
    public abstract Product createClone();
}