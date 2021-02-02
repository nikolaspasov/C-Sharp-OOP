using _06.FoodShortage;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Human:IHuman,IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public int Food { get; set; }

        public Human(string name,int age,string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public int BuyFood(string name)
        {
            Food = 10;

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
         public string Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }  
        public string Birthdate
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

    }
}
