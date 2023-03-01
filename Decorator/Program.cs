using System.Net;

namespace Decorator
{
    public static class Program 
    {
        public static void Main(string[] args)
        {
            // Drink coffee = new Coffee();
            // Drink milkCoffee= new Milk(coffee);
            // Console.WriteLine($"{coffee.Description} は {coffee.Cost()}");
            // Console.WriteLine($"{milkCoffee.Description} は {milkCoffee.Cost()}");

            var normal = new TextBook { Title = "takao book", Author = "takao", Price = 1000 };
            normal.Display();

            // var old = new OldBook(normal) {Rate = 0.3};
            var old = new OldBook(normal, 0.3);
            old.Display();

            // var rental = new RentalBook(normal) { Period = 7 };
            var rental = new RentalBook(normal, 7);
            rental.Display();
        }
    }
}
