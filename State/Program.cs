namespace State;

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

// State クラス
// 記事の状態を表現するインターフェース
interface IArticleState
{
    void Show(IContext article);
    void Publish(IContext article);
    void Hide(IContext article);
    void Delete(IContext article);
}

interface IContext
{
    string title { get; set; }
    void ChangeState(IArticleState state);
}

// 公開状態を表現する ConcreteState
class PublishedState : IArticleState
{
    public string stateName = "公開";
    public void Show(IContext article)
    {
        Console.WriteLine($"title: {article.title}は{stateName}されています。");
    }

    public void Publish(IContext article)
    {
        Console.WriteLine($"title: {article.title}はすでに{stateName}済みです。");
    }

    public void Hide(IContext article)
    {
        // NOTE: DraftStateとは密結合になっている。
        DraftState state = new();
        article.ChangeState(state);
        Console.WriteLine($"title: {article.title}を{state.stateName}にしました。");
    }

    public void Delete(IContext article)
    {
        article.ChangeState(new DeletedState());
        Console.WriteLine($"title: {article.title}を削除しました。");
    }
}

// 下書き状態を表現する ConcreteState
class DraftState : IArticleState
{
    public string stateName = "非公開";

    // 状態を表示する。
    public void Show(IContext article)
    {
        Console.WriteLine($"title: {article.title} は {stateName}です");
    }

    // 公開する
    public void Publish(IContext article)
    {
        // NOTE: PublishedStateとは密結合になっている。
        PublishedState state = new();
        article.ChangeState(state);
        Console.WriteLine($"title: {article.title}を{state.stateName}しました。");
    }

    // 状態を表示する。
    public void Hide(IContext article)
    {
        Console.WriteLine($"title: {article.title} はすでに {stateName} です。");
    }

    // 削除済みにする
    public void Delete(IContext article)
    {
        // NOTE: DeletedStateとは密結合になっている。
        DeletedState state = new();
        article.ChangeState(state);
        Console.WriteLine($"title: {article.title}を削除しました。");
    }
}

// 削除済み状態を表現する ConcreteState
class DeletedState : IArticleState
{
    public string stateName = "削除済み";

    public void Show(IContext article)
    {
        Console.WriteLine($"{article.title}は削除されています。");
    }

    // 公開する
    public void Publish(IContext article)
    {
        Console.WriteLine($"{stateName}の記事を公開することはできません。");
    }

    // 非公開にする
    public void Hide(IContext article)
    {
        DraftState state = new();
        article.ChangeState(state);
        Console.WriteLine($"{article.title}を{state.stateName}にしました。");
    }

    public void Delete(IContext article)
    {
        Console.WriteLine($"{article.title}削除されています。");
    }
}


// クライアント
class Client
{
    static void Main(string[] args)
    {
        // 記事を作成しますか？ をYes/Noで聞く
        // Yesの場合は記事のタイトルを入力してもらう
        // Noの場合は終了する
        Console.WriteLine("記事を作成しますか？");
        Console.WriteLine("Yes: y, No: n");
        string input = Console.ReadLine() ?? "";
        if (input != "y") return;
        separator();
        // タイトルを入力してもらい、空の場合はもう一度入力してもらう。
        while (true)
        {
            Console.WriteLine("タイトルを入力してください。");
            input = Console.ReadLine() ?? "";
            if (input != "") break;
        }

        Article article = new(input);
        separator();

        // 記事の状態を確認する。
        decorate("公開のチェック");
        article.Show();
        article.Hide();
        article.Publish();
        separator();

        // 記事の状態を確認する。
        decorate("非公開のチェック");
        article.Hide();
        article.Show();
        article.Delete();
        separator();

        // 記事の状態を確認する。
        decorate("削除済みのチェック");
        article.Delete();
        article.Show();
        article.Publish();
        article.Show();
        article.Hide();
        article.Show();
        separator();
    }

    static void separator()
    {
        Console.WriteLine("====================================\n");
    }

    static void decorate(string input)
    {
        Console.WriteLine($"##### {input} #####");
    }
}
