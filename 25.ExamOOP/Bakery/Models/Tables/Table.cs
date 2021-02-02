using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        protected Table
            (int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }
        public int TableNumber
        {
            get;private set;
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
           private set
            {
                if(value<0)
                {
                    throw new ArgumentException
                        ("Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException
                        ("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get;private set;
        }
        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }
        public decimal Price
        {
            get;
            private set;
            
        }
        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            isReserved = false;
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal foodBill = 0m;
            decimal drinkBill = 0m;

            foreach (var food in foodOrders)
            {
                foodBill+=food.Price;
            }
              foreach (var drink in drinkOrders)
            {
                drinkBill+=drink.Price;
            }
            Price = foodBill + drinkBill + NumberOfPeople * PricePerPerson;
            return foodBill + drinkBill+NumberOfPeople*PricePerPerson;

        }

        //public abstract string GetFreeTableInfo()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"Table: {tableNumber}");
        //    sb.AppendLine($"Type: Table");
        //    sb.AppendLine($"Table: {tableNumber}");
        //    return sb.ToString().Trim();
        //}
       public abstract string GetFreeTableInfo();

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
    }
}
