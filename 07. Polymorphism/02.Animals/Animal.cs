using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; set; }
        public string FavouriteFood { get; set; }

        protected Animal(string name,string food)
        {
            Name = name;
            FavouriteFood = food;
        }
        public virtual string ExplainSelf()
        {
            return
                $"I am {Name} and my favourite food is {FavouriteFood}";
        }
        
    }
}
