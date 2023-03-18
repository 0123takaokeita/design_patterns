namespace ChainOfResponsibility;

// ログをデータベースに出力するクラス
public class DatabaseLogger : Logger
{
    /// <summary>
    /// DBへのログ書き込み
    /// </summary>
    /// <param name="message"></param>
    /// <param name="level"></param>
    public  override void Handle(string message, LogLevel level)
    {
        if (level == LogLevel.Error)
        {
            Console.WriteLine($"[{level}] : {message} (written to database)");
        }
        
        if(next == null) return;
        next.Handle(message, level);
    }
}