namespace State;

// 公開状態を表現する ConcreteState
class PublishedState : ArticleState
{
    private const string StateName = "公開";
    
    public override void Publish(IContext article)
    {
        Console.WriteLine($"title: {article.title}はすでに{StateName}済みです。");
    }
}



