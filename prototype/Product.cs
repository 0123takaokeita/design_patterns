namespace prototype;

public interface Product : ICloneable
{
    public abstract void use(string s);
    public abstract Product createClone();

    public object Clone()
    {
        // return MemberwiseClone();
    } 
    
    // 仮に createClone が全く同じ実装なのだとしたら interface に書いておくかな。
    // private Product createClone()
    // {
    //     Product p = null;
    //     try
    //     {
    //         return p = (Product)Clone();
    //     }
    //     catch (CloneNotSupportedException e)
    //     {
    //         e.printStackTrace();
    //     }
    // }
}