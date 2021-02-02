using _04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animalList = new List<Animal>();
            while (input != "End")
            {
                string type = input.Split(" ")[0];
                string name = input.Split(" ")[1];
                double weight = double.Parse(input.Split(" ")[2]);

                string foodInput = Console.ReadLine();
                string foodType = foodInput.Split(" ")[0];
                int quantity = int.Parse(foodInput.Split(" ")[1]);

                switch (foodType)
                {
                    case "Vegetable": Food vegetable = new Vegetable(quantity); break;
                    case "Fruit": Food fruit = new Fruit(quantity); break;
                    case "Meat": Food meat = new Meat(quantity); break;
                    case "Seeds": Food seeds = new Seeds(quantity); break;
                }

                int foodEaten = 0;
                switch (type)
                {

                    case "Owl":
                        double wingSize = double.Parse(input.Split(" ")[3]);
                        Animal owl = new Owl(name, weight, foodEaten, wingSize);
                        animalList.Add(owl);
                        owl.AskFood();

                        if (foodType == "Meat")
                        {
                            owl.Weight += 0.25 * quantity;
                            owl.FoodEaten= quantity;
                        }                      
                        else
                        {
                            Console.WriteLine
                                ($"{type} does not eat {foodType}!");
                        }

                        break;
                    //
                    //
                    case "Hen":
                        wingSize = double.Parse(input.Split(" ")[3]);
                        Animal hen = new Hen(name, weight, foodEaten, wingSize);
                        hen.AskFood();
                        animalList.Add(hen);
                        hen.Weight += 0.35 * quantity;
                       hen.FoodEaten = quantity;
                       
                        break;
                    //
                    //
                    case "Dog":
                        string livingRegion = input.Split(" ")[3];
                        Animal dog = new Dog(name, weight, foodEaten, livingRegion);
                        animalList.Add(dog);
                        dog.AskFood();
                        if (foodType == "Meat")
                        {
                            dog.Weight += 0.40 * quantity;
                            dog.FoodEaten = quantity;
                        }
                        else
                        {
                            Console.WriteLine
                                ($"{type} does not eat {foodType}!");
                        }
                        
                        break;
                    //
                    //
                    case "Mouse":
                        livingRegion = input.Split(" ")[3];
                        Animal mouse = new Mouse(name, weight, foodEaten, livingRegion);
                        animalList.Add(mouse);
                        mouse.AskFood();
                        if (foodType == "Vegetable" || foodType == "Fruit")
                        {
                           mouse.Weight += 0.10 * quantity;
                            mouse.FoodEaten = quantity;
                        }
                        else
                        {
                            Console.WriteLine
                                ($"{type} does not eat {foodType}!");
                        }
                       
                        break;
                    //
                    //
                    case "Cat":
                        string breed = input.Split(" ")[4];
                        livingRegion = input.Split(" ")[3];
                        Animal cat = new Cat(name, weight, foodEaten, livingRegion, breed);
                        animalList.Add(cat);
                        cat.AskFood();
                        if (foodType == "Vegetable" || foodType == "Meat")
                        {
                            cat.Weight += 0.30 * quantity;
                            cat.FoodEaten = quantity;
                        }
                        else
                        {
                            Console.WriteLine
                                ($"{type} does not eat {foodType}!");
                        }
                       
                        break;
                    //
                    //
                    case "Tiger":
                        breed = input.Split(" ")[4];
                        livingRegion = input.Split(" ")[3];
                        Animal tiger = new Tiger(name, weight, foodEaten, livingRegion, breed);
                        animalList.Add(tiger);
                        tiger.AskFood();
                        if (foodType == "Meat")
                        {
                            tiger.Weight += 1.00 * quantity;
                            tiger.FoodEaten = quantity;
                        }
                        else
                        {
                            Console.WriteLine
                                ($"{type} does not eat {foodType}!");
                        }
                       
                        break;

                }
                input = Console.ReadLine();
            }
                foreach (var animal in animalList)
                {
                Console.WriteLine(animal.ToString());
                }
            

        }
    }
}
