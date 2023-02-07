namespace Bridge;

// Abstraction に対して機能を追加したクラス
// 洗練された抽象化概念
class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(Implementor imp) : base(imp) { }
}
