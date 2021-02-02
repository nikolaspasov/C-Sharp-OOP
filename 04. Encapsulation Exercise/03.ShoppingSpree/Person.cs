using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<string> products;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            products = new List<string>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrEmpty(value)||value==" ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name=value;
            }
        }
        public double Money
        {
            get { return money; } 
            set
            {
                if(value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money=value;
            }
        }
        public List<string> Products { get { return products; }
                 set { value=products; } }

        public void AddProduct(Product product)
        {
            if (Money >= product.Price)
            {
                products.Add(product.Name);
                Money -= product.Price;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {   
                Console.WriteLine
                    ($"{Name} can't afford {product.Name}");
            }
        }
    }
}
