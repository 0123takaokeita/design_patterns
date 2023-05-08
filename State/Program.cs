namespace State;


// クライアント
class Clent
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

        var article = new Article(input);
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

    // 削除 -> 非公開 -> 削除
    // 非公開 -> 公開 -> 削除

    static void separator()
    {
        Console.WriteLine("====================================\n");
    }

    static void decorate(string input)
    {
        Console.WriteLine($"##### {input} #####");
    }
}
