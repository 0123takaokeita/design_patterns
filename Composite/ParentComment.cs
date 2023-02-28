using static System.Console;

namespace Composite;

public class ParentComment : Comment
{
    // 親になるコメントは子供の配列を持っている。
    private List<Comment> children = new List<Comment>();

    public ParentComment(string content) : base(content) { }

    public override void GetContent(int depth=1)
    {
        WriteLine("{0}{1}", new string('-', depth), _content);
    }

    public void ReplyComment(Comment comment)
    {
        children.Add(comment);
    }

    // 再帰的にディレクトリを一覧表示したい
    public override void Display(int depth)
    {
        this.GetContent(depth)
        foreach(Comment comment in children)
        {
            comment.Display((depth + 1));
        }
    }
}
