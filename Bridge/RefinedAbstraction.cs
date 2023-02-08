namespace Bridge;

// Abstraction に対して機能を追加したクラス
// 洗練された抽象化概念
class RefinedAbstraction : Abstraction
{
    // コンストラクタ
    // 基底クラスの拡張を行う
    public RefinedAbstraction(Implementor imp) : base(imp) { }

    // 基底クラスのメソッドを使用して拡張している。
    public void multiDisplay(int times)
    {
        open();
        for (int i = 0; i < times; i++)
        {
            print();
        }
        close();
    }
}
