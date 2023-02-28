using static System.Console;

namespace Composite;

public class ChildComment : Comment
{
    public ChildComment(string content) : base(content) { }

    public override void GetContent(int depth)
    {
        WriteLine("{0}{1}", new string('-', depth), _content);
    }
}
