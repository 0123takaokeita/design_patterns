namespace Decorator;

public class Milk : Decorator
{
    public Milk(Drink drink) : base(drink)
    {
        Description = drink.Description + "milk";
    }

    public override double Cost()
    {
        return drink.Cost() + 100;
    }
}