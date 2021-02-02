using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string technique;
        private double weight;
        private double flourModifier;
        private double techniqueModifier;
        private const double baseCalories = 2;

        public Dough(string type, string technique, double weight)
        {
            FlourType = type;
            Technique = technique;
            Weight = weight;
            switch (flourType.ToLower())
            {
                case "white": flourModifier = 1.5; break;
                case "wholegrain": flourModifier = 1.0; break;
            }
            switch (technique.ToLower())
            {
                case "crispy": techniqueModifier = 0.9; break;
                case "chewy": techniqueModifier = 1.1; break;
                case "homemade": techniqueModifier = 1.0; break;
            }
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if(value.ToLower()=="white"||value.ToLower()=="wholegrain")
                {

                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string Technique
        {
            get
            {
                return technique;
            }
            set
            {
                technique = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if(value<=0||value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
                weight = value;
            }
        }

        public double Calories => (baseCalories*weight)*flourModifier*techniqueModifier;






    }
}
