using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private int load;
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            
            items = new List<Item>();
        }
        public int Capacity
        {
            get
            { return capacity; }
            set { capacity = value; }
        }

        public int Load 
        {
            get { return load; }
            private set
            {
                load = items.Sum(x => x.Weight);
            }
        }
            

        public IReadOnlyCollection<Item> Items
        { get; }

        

        public void AddItem(Item item)
        {
            if(Load+item.Weight>capacity)
            {
                throw new InvalidOperationException
                    ("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            var item = items.FirstOrDefault(x => x.GetType().Name == name);
           if(items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
           if(item==null)
            {
                throw new ArgumentException
                    ($"No item with name {name} in bag!");
            }
           items.Remove(item);
            return item;
        }
    }
}
