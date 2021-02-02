using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        public Player(string username,int health,int armor,IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        private bool isAlive=true;

        public string Username
        {
            get { return username; }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                username = value;
            }
        }

        public int Health
        {
            get { return health; }
           private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                health = value;
            }
        }

        public int Armor
        {
            get { return armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return gun;
            }
            private set
            {
                if(value==null)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidGun);
                }
                gun = value;
            }
        }

        public bool IsAlive
        {
            get { return isAlive; }
           protected set
            {
                
                    this.isAlive = true;
                
            }
        }

        public void TakeDamage(int points)
        {
            if (armor <= points)
            {
                points -= armor;
                armor = 0;
                if (health <= points)
                {
                    points -= health;
                    health = 0;
                    isAlive = false;
                }
                else
                {
                    health -= points;
                    points = 0;
                }
            }
            else
            {
                armor -= points;
                points = 0;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {username}");
            sb.AppendLine($"--Health: {health}");
            sb.AppendLine($"--Armor: {armor}");
            sb.AppendLine($"--Gun: {gun.Name}");
            return sb.ToString().TrimEnd();
        }
    }
    
}
