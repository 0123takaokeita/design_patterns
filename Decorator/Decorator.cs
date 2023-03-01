namespace Decorator;

public abstract class Decorator : Drink
{
    protected Drink drink;

    public Decorator(Drink drink)
    {
        this.drink = drink;
    }

    public override double Cost()
    {
        return drink.Cost();
    }

}