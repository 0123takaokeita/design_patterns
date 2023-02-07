namespace Bridge;

// 機能クラス階層の最上位クラス
// 抽象概念という意味
public class Abstraction
{
    private Implementor imp;

    // コンストラクタ
    public Abstraction(Implementor imp)
    {
        this.imp = imp;
    }

    // imp に委譲
    public void open()
    {
        imp.rawOpen();
    }

    // imp に委譲
    public void print()
    {
        imp.rawPrint();
    }

    // imp に委譲
    public void close()
    {
        imp.rawClose();
    }

    // テンプレート
    public void display()
    {
        open();
        print();
        close();
    }
}

