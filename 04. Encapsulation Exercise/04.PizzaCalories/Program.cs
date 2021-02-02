using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaInput = Console.ReadLine();
                string doughInput = Console.ReadLine();
                Dough dough = new Dough
                    (doughInput.Split(" ")[1], doughInput.Split(" ")[2],
                    double.Parse(doughInput.Split(" ")[3]));
                Pizza pizza = new Pizza(pizzaInput.Split(" ")[1],dough);

                
                
                string toppingInput = Console.ReadLine();
                while (toppingInput != "END")
                {
                    Topping topping = new Topping
                        (toppingInput.Split
                        (" ")[1], double.Parse(toppingInput.Split(" ")[2]));
                    toppingInput = Console.ReadLine();
                    pizza.AddTopping(topping);
                }
                // Console.WriteLine($"{dough.Calories:f2}");
                // Console.WriteLine($"{topping.Calories:f2}");
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch(ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
