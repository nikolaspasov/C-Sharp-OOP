using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Cat : Feline,ISoundable
    {
        public Cat
            (string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void AskFood()
        {
        
            Console.WriteLine("Meow");
        }
    }
}
