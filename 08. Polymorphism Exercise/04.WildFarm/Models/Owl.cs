using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Owl : Bird,ISoundable
    {
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void AskFood()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
