namespace ChainOfResponsibility;

/// <summary>
/// ログレベルの列挙
/// </summary>
public enum LogLevel
{
    Info,
    Warning,
    Error
}

public class Program
{
    static void Main(string[] args)
    {
        string filename = "/Users/takaokeita/practice/design_patterns/ChainOfResponsibility/log.txt";
        // ログレベルに応じてログ出力先を設定する
        Logger logger = new ConsoleLogger();
        Logger WFile = new FileLogger(filename, LogLevel.Warning);
        Logger WFile = new FileLogger(filename, env);
        Logger database = new DatabaseLogger();

        // 循環の作成
        logger.SetNext(WFile).SetNext(database);


        // ログ出力の確認
        using (StreamWriter writer = new StreamWriter(filename, true))
        {
            writer.WriteLine("----------------1回目-------------------");
        }
        logger.Handle("コンソールのメッセージ", LogLevel.Info);
        logger.Handle("ファイルへのメッセージ", LogLevel.Warning);
        logger.Handle("DBへのメッセージ", LogLevel.Error);

        Logger EFile = new FileLogger(filename, LogLevel.Error);
        logger.SetNext(EFile).SetNext(database);
        
        // ログ出力の確認
        using (StreamWriter writer = new StreamWriter(filename, true))
        {
            writer.WriteLine("----------------２回目-------------------");
        }
        logger.Handle("コンソールのメッセージ", LogLevel.Info);
        logger.Handle("ファイルへのメッセージ", LogLevel.Warning);
        logger.Handle("DBへのメッセージ", LogLevel.Error);
    }
}