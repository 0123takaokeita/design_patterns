namespace Decorator;

public class Coffee: Drink
{
    public Coffee()
    {
        Description = "coffee";
    }

    public override double Cost()
    {
        return 300;
    }
}