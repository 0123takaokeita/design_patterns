namespace ChainOfResponsibility;

/// <summary>
/// INFOのログをコンソールに出力するクラス
/// </summary>
public class ConsoleLogger : Logger
{
    /// <summary>
    /// 処理できる場合はログを出力する。
    /// </summary>
    /// <param name="message"></param>
    /// <param name="level"></param>
    public override void Handle(string message, LogLevel level)
    {
        if(next == null) return;
        if (level == LogLevel.Info)
        {
            Console.WriteLine($"[{level}] : {message} (written to console)");
        }
        next.Handle(message, level);
    }
}