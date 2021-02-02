using _05.BirthdayCelebrations;
using _06.FoodShortage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Human> humans = new List<Human>();
            List<Rebel> rebels = new List<Rebel>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();

                if (input.Length == 4)
                {
                    Human human = new Human(input[0], int.Parse(input[1]), input[2], input[3]);
                    humans.Add(human);
                }
                else if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0],int.Parse(input[1]),input[2]);
                    rebels.Add(rebel);
                }
               
                
            }
            int totalFood = 0;

            string command = Console.ReadLine();
            while(command!="End")
            {
                foreach (var person in humans)
                {
                    if(person.Name==command)
                    {
                        totalFood += person.BuyFood(command);
                    }
                } 
                foreach (var person in rebels)
                {
                    if(person.Name==command)
                    {
                        totalFood += person.BuyFood(command);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(totalFood);
        }
    }
}
