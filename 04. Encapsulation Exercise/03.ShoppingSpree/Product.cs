using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private double price;

        public Product(string name,double price)
        {
            Name = name;
            Price = price;
        }
        public string Name 
        
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value)||value==" ")
                {
                    throw new ArgumentException
                        ("Name cannot be empty");  
                }
                this.name = value;
            }
        }
        public double Price 
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        ("Money cannot be negative");
                }
                this.price = value;
            }
        }
    }
}
