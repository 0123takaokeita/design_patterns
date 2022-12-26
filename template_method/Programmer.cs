namespace template_method;

public class Programmer : AbstractWork
{
    private string hello { get; } = "Hello World";
    private string goodBye { get; } = "GoodBye World";
    private IEnumerable<string> workList { get; } = new [] { "task check", "coding", "test" };
    protected override void startCall()
    {
        Console.WriteLine(hello);
    }
    protected override void printWork()
    {
        foreach (var txt in workList)
        {
            Console.WriteLine(txt);
        }
    }
    protected override void endCall()
    {
        Console.WriteLine(goodBye);
    }
}
