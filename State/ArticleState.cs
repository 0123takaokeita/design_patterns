namespace State;

// 削除済み状態を表現する ConcreteState
abstract class ArticleState : IArticleState
{
    protected string StateName  = "状態なし";

    // 現在の状態確認
    public virtual void Show(IContext article)
    {
         Console.WriteLine($"title: {article.title}は{StateName}です");
    }

    // 記事を公開
    public virtual void Publish(IContext article)
    {
        article.ChangeState(new PublishedState());
        Console.WriteLine($"title: {article.title}を公開しました。");
    }

    // 記事を非公開
    public virtual void Hide(IContext article)
    {
        article.ChangeState(new DraftState());
        Console.WriteLine($"title: {article.title}を非公開にしました。");
    }

    // 記事を削除
    public virtual void Delete(IContext article)
    {
        article.ChangeState(new DeletedState());
        Console.WriteLine("title: {0}を削除しました。", article.title); 
    }
}
