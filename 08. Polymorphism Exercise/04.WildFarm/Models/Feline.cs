using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Feline:Mammal
    {
        protected Feline
            (string name, double weight,
            int foodEaten, string livingRegion,string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }
        public override string ToString()
        {
            return
                $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
        public string Breed { get; set; }
    }
}
