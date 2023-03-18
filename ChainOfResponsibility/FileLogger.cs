namespace ChainOfResponsibility;
using System;
using DotNetEnv;

/// <summary>
/// Warningのログをファイルに出力するクラス
/// </summary>
class FileLogger : Logger
{
    private string filename;
    private LogLevel level;
    
    /// <summary>
    ///  コンストラクタ
    /// </summary>
    /// <param name="filename"></param>
    public FileLogger(string filename)
    {
        this.filename = filename;
        string envLogLevel = Environment.GetEnvironmentVariable("LOG_LEVEL");
        LogLevel loglevel = (LogLevel)Enum.Parse(typeof(LogLevel), envLogLevel);
        this.level = loglevel;
    }
    
    public FileLogger(string filename, LogLevel level)
    {
        this.filename = filename;
        this.level = level;
    }

    /// TODO: LEVEL をコンストラクター で受け取って出力するログを変更したい。
    /// <summary>
    ///  ログ書き込み処理
    /// </summary>
    /// <param name="message"></param>
    /// <param name="level"></param>
    public override void Handle(string message, LogLevel level)
    {

        if(next==null) return;
        // if (level <= this.level)
        if (loglevel <= level)
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine($"{ DateTime.Now.ToString() } :[ {level} ] { message }");
            }
            Console.WriteLine($"[ {level} ] Fileに書き込みました。 (written to file)");
        }
        next.Handle(message, level);
    }
}