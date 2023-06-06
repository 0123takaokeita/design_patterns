namespace Command;

// Receiver 役
// 命令を受け取る役
class TextEditor
{
    // undo/redo 配列
    private readonly List<ICommand> _commands = new List<ICommand>();
    private int _index = -1;
    public string Text = "";

    // key入力で実行コマンドの切り替え
    public void HandleKey()
    {
        while (true)
        {
            // key入力
            var key = Console.ReadKey().KeyChar;
            switch (key)
            {
                case 'a':
                    // index以降のcommandsを削除
                    _commands.RemoveRange(_index + 1, _commands.Count - _index - 1);

                    Console.WriteLine();
                    Console.Write(Text);
                    string text = Console.ReadLine() ?? " ";
                    var command = new TextEditCommand(this, text);
                    _commands.Add(command);
                    _index++;
                    break;
                case 'u':
                    Console.WriteLine();
                    if (_index < 0)
                    {
                        Console.WriteLine("これ以上戻れません。");
                        break;
                    }
                    _index--;
                    break;
                case 'r':
                    Console.WriteLine();
                    if (_index >= _commands.Count - 1)
                    {
                        Console.WriteLine("これ以上戻れません。");
                        break;
                    }
                    _index++;
                    break;
                case 'q':
                    return;
                default:
                    Console.WriteLine("対応しているkeyを入力してください");
                    Console.WriteLine("a:Add u:Undo r:Redo q:Quit");
                    break;
            }
            Execute();
            Display();
        }
    }

    // commandのExecuteを実行する
    public void Execute()
    {
        Text = "";
        for (var i = 0; i <= _index; i++)
        {
            _commands[i].Execute();
        }
    }

    public void Display()
    {
        Console.WriteLine($"現在のText: {Text}");
    }
}

// Client 役
// Invoker 役
class Program
{
    static void Main(string[] args)
    {
        var editor = new TextEditor();

        Console.WriteLine("key を入力してね");
        Console.WriteLine("a:Add u:Undo r:Redo q:Quit");
        editor.HandleKey();
    }
}
