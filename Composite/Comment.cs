namespace Composite;

public abstract class Comment
{
    protected string _content;

    public Comment(string content)
    {
        _content = content;
    }

    public abstract void GetContent(int depth);

    // Display だけで良かったのでは？
    public virtual void Display(int depth){
        new NotImplementedException();
    }
}
