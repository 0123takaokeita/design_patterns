namespace Decorator;

public abstract class Drink
{
    public string Description { get; set; }
    public abstract double Cost();
}