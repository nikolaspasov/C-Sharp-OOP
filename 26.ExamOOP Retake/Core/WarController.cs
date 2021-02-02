using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Item> items;
        private readonly List<Character> characters;
        public WarController()
        {
            items = new List<Item>();
            characters = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            if (characterType == "Warrior")
            {
                var character = new Warrior(name);
                characters.Add(character);
            }
            else if (characterType == "Priest")
            {
                var character = new Priest(name);
                characters.Add(character);
            }
            else
            {
                throw new ArgumentException
($"Invalid character type {characterType}!");
            }
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            if (itemName == "FirePotion")
            {
                var item = new FirePotion();
                items.Add(item);
            }
            else if (itemName == "HealthPotion")
            {
                var item = new HealthPotion();
                items.Add(item);
            }
            else
            {
                throw new ArgumentException
                    ($"Invalid item \"{itemName}\"!");

            }
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var character = characters.FirstOrDefault
                (x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException
                    ($"Character {characterName} not found!");
            }
            else if (items.Count == 0)
            {
                throw new InvalidOperationException
                    ($"No items left in pool!");
            }
            character.Bag.AddItem
                (items[items.Count - 1]);
            string itemName = items[items.Count - 1].GetType().Name;
            string msg = $"{characterName} picked up {itemName}!";
            items.Remove(items[items.Count - 1]);
            return msg;
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException
                    ($"Character {characterName} not found!");
            }
            var item = character.Bag.GetItem(itemName);
                
           
            character.UseItem(item);
            return $"{characterName} used {itemName}.";
        }

        public string GetStats()
        {
            var sortedCharacters = characters.OrderByDescending(x => x.IsAlive)
                 .ThenByDescending(x => x.Health).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var character in sortedCharacters)
            {
                string status = "";
                if (character.IsAlive == true)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine
                    ($"{character.Name} - HP: {character.Health}/{character.BaseHealth}," +
                    $" AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }
            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
           string receiverName = args[1];

            var attacker = characters.FirstOrDefault(x => x.Name == attackerName);
            var receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if(attacker.GetType().Name!="Warrior")
            {
                throw new ArgumentException
                    ($"{attacker.Name} cannot attack!");
            }
            var warrior = attacker as Warrior;
            warrior.Attack(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(
                $"{warrior.Name} attacks {receiverName} for " +
                $"{warrior.AbilityPoints} hit points! {receiverName}" +
                $" has {receiver.Health}/{receiver.BaseHealth} HP and " +
                $"{receiver.Armor}/{receiver.BaseArmor} AP left!");
            if(receiver.IsAlive==false)
            {
                
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            var healer = characters.FirstOrDefault(x => x.Name == healerName);
            var receiver = characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }
          
            if(healer.GetType().Name!="Priest")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            var priest = healer as Priest;
            priest.Heal(receiver);
           
            StringBuilder sb = new StringBuilder();
            sb.Append
                ($"{priest.Name} heals {receiver.Name} for {priest.AbilityPoints}! " +
                $"{receiver.Name} has {receiver.Health} health now!");
            return sb.ToString().Trim();

        }
    }
}
