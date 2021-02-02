using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        private const double baseCalories = 2;
        private double modifier;
        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
            
        }

        public string Type
        {
            get { return type; }
            set
            {
                switch (value.ToLower())
                {
                    case "meat": modifier = 1.2; break;
                    case "veggies": modifier = 0.8; break;
                    case "cheese": modifier = 1.1; break;
                    case "sauce": modifier = 0.9; break;
                    default:throw new ArgumentException
                            ($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                if(value<1||value>50)
                {
                    throw new ArgumentException
                        ($"{Type} weight should be in range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories => (weight * baseCalories)*modifier;

        
    }
}
