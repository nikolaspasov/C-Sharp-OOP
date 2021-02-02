using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private bool isAlive;
        public Character
            (string name,double health,double armor,
            double abilityPoints,Bag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException
                        ("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public double BaseHealth { get { return baseHealth; }
            set { baseHealth = value; } }
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= baseHealth || value>0)
                {
                    health = value;
                }

            }
        }
        public double BaseArmor { get { return baseArmor; } set { baseArmor = value; } }
        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if ( value > 0)
                {
                    armor = value;
                }

            }
        }
        public Bag Bag { get; set; }
        public double AbilityPoints { get; set; }
        public bool IsAlive { get; set; } = true;

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            if(this.IsAlive==true)
            {
                if(this.Armor>=hitPoints)
                {
                    this.Armor -= hitPoints;
                }
                else
                {
                    hitPoints -= Armor;
                    armor = 0;
                   
                    if(Health-hitPoints<=0)
                    {
                        health = 0;
                        this.IsAlive = false;
                    }
                    else
                    {
                        Health -= hitPoints;
                    }
                }
            }
        }
        public void UseItem(Item item)
        {
            if(this.IsAlive==true)
            {
                item.AffectCharacter(this);
            }
        }
    }
}