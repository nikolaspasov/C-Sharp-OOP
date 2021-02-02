using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Hen : Bird,ISoundable
    {
        public Hen
            (string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void AskFood()
        {


            Console.WriteLine("Cluck");
        }
        
    }
}
