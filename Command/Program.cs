// undo/redo を機能実装したテキスエディタ


// Command 役
interface ICommand
{
    void Execute();
    void Undo();
}

// ConcreateCommand 役
class TextEditCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;
    private string _previousText;

    // コンストラクタ
    public TextEditCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
        _previousText = "";
    }

    // 実行
    public void Execute() { }

    // 元に戻す
    public void Undo() { }
}

// macro command
class SnippetCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;

    // コンストラクタ
    public SnippetCommand(TextEditor editor, string text) { }

    // 実行
    public void Execute() { }

    // 元に戻す
    public void Undo() { }
}

// Receiver 役
// 命令を受け取る役
// singletonにしないとだめ？
class TextEditor
{
    // Undo Redo は１つの配列でできるのでは？
    // undo methodは逆操作を実行する考え方もある。
    // private index
    private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
    private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();
    private bool _isInsertMode = true;

    public string Text { get; set; } = "";

    public void HandleKey(char key)
    {
    }

    public void ExecuteCommand(ICommand command)
    {
    }

    public void Undo()
    {
    }

    public void Redo()
    {
    }
}

// Client 役
// Invoker 役
class Program
{
    static void Main(string[] args)
    {
    }
}
