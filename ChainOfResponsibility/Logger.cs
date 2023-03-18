namespace ChainOfResponsibility;

/// <summary>
/// Loggerを同一視するためのクラス
/// </summary>
public abstract class Logger
{
    protected Logger next;
    
    /// <summary>
    /// 次に渡すオブジェクトをセット
    /// </summary>
    /// <param name="logger"></param>
    /// <returns></returns>
    public Logger SetNext(Logger logger)
    {
        next = logger;
        return logger;
    }

    /// <summary>
    /// 次のオブジェクトのHandleに処理を任せる。
    /// </summary>
    /// <param name="message">メッセージ</param>
    /// <param name="level">log level</param>
    public virtual void Handle(string message, LogLevel level)
    {
        if(next == null) return;
        next.Handle(message, level);
    }
}