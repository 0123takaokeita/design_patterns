namespace prototype;

public class UnderlinePen : Product
{
    /// <summary>
    /// ICloneableの実装
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public object Clone()
    {
        return MemberwiseClone();
    }
    
    /// <summary>
    /// 実際に何を作るのか？
    /// </summary>
    /// <param name="s"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void use(string s)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// ここでClone出来なければ例外処理
    /// </summary>
    /// <returns></returns>
    public Product createClone()
    
    {
        Product p = null;
        try
        {
            return p = (Product)Clone();
        }
        catch (CloneNotSupportedException e)
        {
            e.printStackTrace();
        }
    }
}