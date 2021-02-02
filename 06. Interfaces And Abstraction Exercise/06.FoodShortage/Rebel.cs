using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public class Rebel:IBuyer
    {
        private string name;
        private int age;
        private string group;
        public int Food { get; set; }

        public Rebel(string name,int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public int BuyFood(string name)
        {
            Food = 5;
            return Food;
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
        public string Group
        {
            get { return group; }
            set
            {
                group = value;
            }
        }

    }
}
