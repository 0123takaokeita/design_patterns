namespace Bridge;

public class CustomHotKey : HotKey
{
    public CustomHotKey(KeyBoard kb) : base(kb) { }

    public void clearCopyHistory()
    {
        copy("");
    }

}
