using System;
using System.Collections.Generic;

// Mementoクラス
// Originatorをもとに戻す役割
public class BrowserHistoryMemento
{
    private List<string> urls;
    private List<string> titles;

    public BrowserHistoryMemento(List<string> urls, List<string> titles)
    {
        this.urls = new List<string>(urls);
        this.titles = new List<string>(titles);
    }

    public List<string> GetUrls()
    {
        return urls;
    }

    public List<string> GetTitles()
    {
        return titles;
    }
}

// Originatorクラス
// 保存したいときにMementoを作成する役割
public class BrowserHistory
{
    private List<string> urls;
    private List<string> titles;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BrowserHistory()
    {
        urls = new List<string>();
        titles = new List<string>();
    }

    /// <summary>
    /// ページを追加
    /// </summary>
    public void AddPage(string url, string title)
    {
        urls.Add(url);
        titles.Add(title);
    }

    /// <summary>
    /// 現在の状態を保存する
    /// </summary>
    public BrowserHistoryMemento SnapShot()
    {
        return new BrowserHistoryMemento(urls, titles);
    }

    /// <summary>
    /// SnapShotの状態に復元する
    /// </summary>
    public void RestoreMemento(BrowserHistoryMemento memento)
    {
        urls = memento.GetUrls();
        titles = memento.GetTitles();
    }

    /// <summary>
    /// 履歴を表示
    /// </summary>
    public void PrintHistory()
    {
        Console.WriteLine("Browsing history:");
        for (int i = 0; i < urls.Count; i++)
        {
            Console.WriteLine("{0}. {1} - {2}", i + 1, titles[i], urls[i]);
        }
    }
}

// Caretakerクラス
// Originatorクラスの状態を保存する
public class Browser
{
    private BrowserHistory history;
    private Stack<BrowserHistoryMemento> undoStack;
    private Stack<BrowserHistoryMemento> redoStack;

    public Browser()
    {
        history = new BrowserHistory();
        undoStack = new Stack<BrowserHistoryMemento>();
        redoStack = new Stack<BrowserHistoryMemento>();
    }

    /// <summary>
    /// ページを開く
    /// </summary>
    /// <param name="url">URL</param>
    /// <param name="title">タイトル</param>
    public void GoToPage(string url, string title)
    {
        // 現在の状態をundoスタックに追加
        undoStack.Push(history.SnapShot());

        // snap shot を撮ってからページに移動
        history.AddPage(url, title);

        // 移動したのでredoは削除
        redoStack.Clear();
        Console.WriteLine($"Navigated to {title}: {url}");
    }

    // 履歴を戻る
    public void Undo()
    {
        if (undoStack.Count == 0)
        {
            Console.WriteLine("### ERROR ### Nothing to redo");
            return;
        }

        // 現在の状態をredoスタックに追加
        redoStack.Push(history.SnapShot());

        // 直前の状態に復元
        BrowserHistoryMemento memento = undoStack.Pop();
        history.RestoreMemento(memento);

        Console.WriteLine("### Execute Undo ###");
    }

    public void Redo()
    {
        if (redoStack.Count == 0)
        {
            Console.WriteLine("### ERROR ### Nothing to redo");
            return;
        }

        // 現在の状態をundoスタックに追加
        undoStack.Push(history.SnapShot());

        // 直前の状態に復元
        BrowserHistoryMemento memento = redoStack.Pop();
        history.RestoreMemento(memento);

        Console.WriteLine("### Execute Redo ###");
    }

    /// <summary>
    /// 履歴を表示
    /// </summary>
    public void PrintHistory()
    {
        history.PrintHistory();
        PrintSeparator();
    }

    // セパレーターを表示
    public void PrintSeparator()
    {
        Console.WriteLine("--------------------------------------------------\n");
    }
}

class Program
{
    // テスト用
    static void Main(string[] args)
    {
        Browser browser = new Browser();

        browser.GoToPage("http://www.google.com", "Google");
        browser.GoToPage("http://www.yahoo.com", "Yahoo");
        browser.GoToPage("http://www.bing.com", "Bing");
        browser.PrintSeparator();

        // 履歴を表示
        browser.PrintHistory();

        // 一つ戻る
        browser.Undo();
        browser.PrintHistory();

        // 一つ戻る
        browser.Undo();
        browser.PrintHistory();

        // 戻ったものを戻る。
        browser.Redo();
        browser.PrintHistory();

        // 戻ったものを戻る。
        browser.Redo();
        browser.PrintHistory();

        // これは失敗するはず
        browser.Redo();
        browser.PrintHistory();
    }
}
