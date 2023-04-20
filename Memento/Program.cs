using System;
using System.Collections.Generic;

public interface Memento
{
    string GetUrl();
    string GetTitle();
}


// Originatorクラス
// 保存したいときにMementoを作成する役割
public class BrowserHistory
{
    // TODO:  url titleだけで良い。
    private string url;
    private string title;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BrowserHistory()
    {
        url = "";
        title = "";
    }

    /// <summary>
    /// ページを追加
    /// </summary>
    public void AddPage(string url, string title)
    {
        this.url = url;
        this.title = title;
    }

    /// <summary>
    /// 現在の状態を保存する
    /// </summary>
    public Memento SnapShot()
    {
        return new BrowserHistoryMemento(url, title);
    }

    /// <summary>
    /// SnapShotの状態に復元する
    /// </summary>
    public void RestoreMemento(Memento memento)
    {
        url = memento.GetUrl();
        title = memento.GetTitle();
    }

    /// <summary>
    /// 履歴を表示
    /// </summary>
    public void PrintHistory()
    {
        Console.WriteLine("Browsing history:");
        // for (int i = 0; i < urls.Count; i++)
        // {
        //     Console.WriteLine($"{i + 1}. {titles[i]} - {urls[i]}");
        // }
    }

    // Mementoクラス
    // Originatorをもとに戻す役割
    class BrowserHistoryMemento : Memento
    {
        private string url;
        private string title;

        // wide
        public BrowserHistoryMemento(string url, string title)
        {
            this.url = url;
            this.title = title;
        }

        // narrow
        public string GetUrl()
        {
            return url;
        }

        // narrow
        public string GetTitle()
        {
            return title;
        }
    }
}

// Caretakerクラス
// Originatorクラスの状態を保存する
public class Browser
{
    private BrowserHistory history;

    private List<Memento> historyList;
    private int historyIndex;

    public Browser()
    {
        history = new BrowserHistory();
        historyList = new List<Memento>();
        historyIndex = 0;
    }

    /// <summary>
    /// ページを開く
    /// </summary>
    /// <param name="url">URL</param>
    /// <param name="title">タイトル</param>
    public void GoToPage(string url, string title)
    {
        history.AddPage(url, title);
        // 現在の状態をundoスタックに追加
        historyList.Add(history.SnapShot());
        historyIndex = historyList.Count - 1;

        Console.WriteLine($"Navigated to {title}: {url}");
    }

    // 履歴を戻る
    public void Undo()
    {
        if (historyIndex.Equals(0)) Console.WriteLine("### ERROR ### Nothing to redo");

        Console.WriteLine("### Execute Undo ###");
        history.RestoreMemento(historyList[historyIndex]);
        historyIndex--;
    }

    public void Redo()
    {
        if (historyIndex.Equals(historyList.Count - 1)) Console.WriteLine("### ERROR ### Nothing to redo");

        Console.WriteLine("### Execute Redo ###");
        history.RestoreMemento(historyList[historyIndex]);
        historyIndex++;
    }

    /// <summary>
    /// 履歴を表示
    /// </summary>
    public void PrintHistory()
    {
        foreach (var memento in historyList)
        {
          Console.WriteLine(memento.GetUrl());      
          Console.WriteLine(memento.GetTitle());      
        }

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
