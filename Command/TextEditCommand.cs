namespace Command;

// undo/redo を機能実装したテキストエディタ
// Command 役
interface ICommand
{
    void Execute();
}

// ConcreateCommand 役
class TextEditCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;

    // コンストラクタ
    public TextEditCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    // 実行
    public void Execute()
    {
        _editor.Text += _text;
    }
}

// macro command
class SnippetCommand : ICommand
{
    private readonly List<ICommand> _commands;

    // コンストラクタ
    public SnippetCommand(List<ICommand> commands)
    {
        _commands = commands;
    }

    // 実行
    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}

