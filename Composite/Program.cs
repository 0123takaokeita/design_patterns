namespace Composite;

public class Program 
{
    static void Main()
    {
        Console.WriteLine("####################");
        ParentComment root = new ParentComment("root content");
        ParentComment child = new ParentComment("child content");
        ParentComment child2 = new ParentComment("child2 content");
        ChildComment child_1 = new ChildComment("child-1 content");
        ChildComment child_2 = new ChildComment("child-2 content");
        root.ReplyComment(child);
        root.ReplyComment(child2);
        child.ReplyComment(child_1);
        child.ReplyComment(child_2);
        root.DisplayChildren(1);

    }
}
