namespace template_method;

public class Manager : AbstractWork
{
    private string hello { get; } = "Hello Everyone";
    private string goodBye { get; } = "GoodBye Everyone";
    private string[] workList { get; } = new[] { "task check", "team MTG", "teaching", "coaching" };
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