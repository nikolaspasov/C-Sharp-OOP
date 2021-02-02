using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private int toppingCount;
        private double totalCalories;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            CurrDough = dough;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length >= 15 || value.Length <= 0)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough CurrDough { get; }

        public void AddTopping(Topping topping)
        {
            if (toppingCount+1 > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            totalCalories += topping.Calories;
            toppingCount++;
           
        }
        public double Calories
            => totalCalories + CurrDough.Calories;

    }
}
