namespace State;

// 削除済み状態を表現する ConcreteState
class DeletedState : ArticleState
{
    private const string StateName = "削除済み";

    // 公開する
    public override void Publish(IContext article)
    {
        Console.WriteLine($"{StateName}の記事を公開することはできません。");
    }

    public override void Delete(IContext article)
    {
        Console.WriteLine($"{article.title}削除されています。");
    }
}
