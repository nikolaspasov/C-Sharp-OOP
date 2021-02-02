using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Animal:ISoundable
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }
     
        public string Name { get; private set; }
        public double Weight { get;  set; }
        public int FoodEaten { get;  set; }

        public virtual void AskFood()
        {
            Console.WriteLine("Sound");
        }
    }
}
