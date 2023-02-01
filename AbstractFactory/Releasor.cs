namespace AbstractFactory;

public class Releasor: IRelease
{
    public bool release()
    {
        Console.WriteLine("close connect!");
        return true;
    }
}