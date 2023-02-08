namespace Bridge;
public static class Program
{
    public static void Main(string[] args)
    {
        // Abstraction a1 = new Abstraction(new ConcreteImplementor("Takao"));
        // Abstraction a2 = new RefinedAbstraction(new ConcreteImplementor("Neo Takao"));
        // RefinedAbstraction a3 = new RefinedAbstraction(new ConcreteImplementor("Refine Takao"));
        // 
        // a1.display();
        // a2.display();
        // a3.display();
        // a3.multiDisplay(5);

        HotKey hk1 = new HotKey(new KeyBoard());
        HotKey hk2 = new CustomHotKey(new KeyBoard());
        CustomHotKey hk3 = new CustomHotKey(new KeyBoard());

        // hk1.copyAndPast("hk1 takao");
        hk1.copy("hk1 takao");
        hk1.past();
        // hk2.copyAndPast("hk2 takao");
        hk2.copy("hk2 takao");
        hk2.past();
        // hk3.copyAndPast("hk3 takao");
        hk3.copy("hk3 takao");
        hk3.past();

        hk3.clearCopyHistory();
        hk3.past(); // 空文字になる
    }
}

