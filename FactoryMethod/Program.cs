namespace FactoryMethod ;

internal static class Program 
{
    static void Main(string[] args)
    {
        Factory factory = new IDCardFactory();
        var card1 = factory.create("たかお");
        var card2 = factory.create("けいた");
        var card3 = factory.create("Neo");
        card1.use();
        card2.use();
        card3.use();
    }
}
