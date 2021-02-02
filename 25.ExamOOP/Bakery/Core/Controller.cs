using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
       

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink
            (string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                var drink = new Tea(name,portion, 2.50M, brand);
                drinks.Add(drink);
                return
                    $"Added {name} ({brand}) to the drink menu";
            }
            else
            {
                var drink = new Water(name, portion, 1.50M, brand);
                drinks.Add(drink);
                return
                    $"Added {name} ({brand}) to the drink menu";
            }
        }

        public string AddFood
            (string type, string name, decimal price)
        {
            if(type == "Cake")
            {
                var food = new Cake(name,245 ,price);
                bakedFoods.Add(food);
                return
                    $"Added {name} (Cake) to the menu";
            } 
            else
            {
                var food = new Bread(name,200 ,price);
                bakedFoods.Add(food);
                return
                    $"Added {name} (Bread) to the menu";
            }
           
        }

        public string AddTable
            (string type, int tableNumber, int capacity)
        {
            if (type == "OutsideTable")
            {
                var table = new OutsideTable(tableNumber,capacity, 3.50m);
                tables.Add(table);
               
            }
            else
            {
                var table = new InsideTable(tableNumber,capacity, 2.50m);
                tables.Add(table);
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(x=>x.IsReserved==false))
            {
                sb.Append(table.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            decimal totalIncome = 0m;
            foreach (var table in tables)
            {
                totalIncome +=table.Price;
            }
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill=table.GetBill();
            
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            return sb.ToString().Trim();
        }

        public string OrderDrink
            (int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drink = drinks.FirstOrDefault(x => x.Name == drinkBrand);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood
            (int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if(table==null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if(food==null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable
            (int numberOfPeople)
        {
            var emptyTable = tables.FirstOrDefault(x => x.IsReserved == false);

            if(emptyTable.Capacity>=numberOfPeople)
            {
                emptyTable.Reserve(numberOfPeople);
                return $"Table {emptyTable.TableNumber} has been reserved for {numberOfPeople} people";
            }
            return $"No available table for {numberOfPeople} people";
        }
    }
}
