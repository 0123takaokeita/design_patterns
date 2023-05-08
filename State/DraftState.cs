namespace State;

// 下書き状態を表現する ConcreteState
class DraftState : ArticleState
{
    public DraftState() : base()
    {
        StateName = "非公開";
    }
    
    // 状態を表示する。
    public override void Hide(IContext article)
    {
        Console.WriteLine($"title: {article.title} はすでに {StateName} です。");
    }
}
