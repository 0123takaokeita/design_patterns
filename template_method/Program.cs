namespace template_method;
public static class Program
{
    public static void Main(string[] args)
    {
        AbstractWork programmer = new Programmer();
        programmer.display();
        AbstractWork manager = new Manager();
        manager.display();
    }
}