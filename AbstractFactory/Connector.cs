namespace AbstractFactory;

public class Connector: IConnect
{
    public bool connect()
    {
        Console.WriteLine("success connect!");
        return true;
    }
}