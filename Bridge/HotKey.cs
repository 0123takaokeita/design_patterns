namespace Bridge;

public class HotKey
{
    // ここで委譲しているから実装と分離できる。
    private KeyBoard kb;

    public HotKey(KeyBoard kb)
    {
        this.kb = kb;
    }

    public void copy(string token)
    {
        kb.copyCmd(token);
    }

    public void past()
    {
      kb.pastCmd();
    }

    public void trim(string token)
    {
        kb.trimCmd(token);
    }

    public void copyAndPast(string token)
    {
      copy(token);
      past();
    }
}
