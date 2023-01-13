namespace prototype;

public static class Program
{
    public static void Main(string[] args)
    {
        var manager = new Manager();
        var underlinePen = new UnderlinePen();
        var messageBox= new MessageBox('*');
        var slashBox = new MessageBox('/');
        manager.register("strong message", underlinePen);
        manager.register("warning box", messageBox);
        manager.register("slash box",slashBox);

        // create では createClone をおこなっているので実際の名前は知らなくても良い。
        // 今回は文字列がkeyになっているがこれは一意になっていれば設計上は変更しても良さそう。
        var p1 = manager.create("strong message");
        p1.use("Hello world");
        var p2 = manager.create("warning box");
        p2.use("Hello world");
        var p3 = manager.create("slash box");
        p3.use("Hello world");
    } 
}