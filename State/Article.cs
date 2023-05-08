namespace  State;

interface IContext
{
    string title { get; set; }
    void ChangeState(IArticleState state);
}

// State クラス
// 記事の状態を表現するインターフェース
interface IArticleState
{
    void Show(IContext article);
    void Publish(IContext article);
    void Hide(IContext article);
    void Delete(IContext article);
}

// Context クラス
// 記事を表現するクラス
class Article : IContext
{
    private IArticleState state;
    public string title { get; set; }

    public Article(string title)
    {
        state = new DraftState();
        this.title = title;
    }

    public void Show()
    {
        state.Show(this);
    }

    public void Hide()
    {
        state.Hide(this);
    }

    public void Delete()
    {
        state.Delete(this);
    }

    public void Publish()
    {
        state.Publish(this);
    }

    // 状態を変更する
    // このメソッドがないと、状態を変更することができない。
    // NOTE: 状態の変更についてはこのクラスは関与しなくても良くなっている。
    public void ChangeState(IArticleState state)
    {
        this.state = state;
    }
}
