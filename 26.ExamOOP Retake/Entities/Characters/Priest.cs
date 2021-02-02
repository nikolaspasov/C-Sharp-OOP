﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities
{
    public class Priest : Character, IHealer
    {
        public Priest
            (string name)
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (this.IsAlive == true && character.IsAlive == true)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
