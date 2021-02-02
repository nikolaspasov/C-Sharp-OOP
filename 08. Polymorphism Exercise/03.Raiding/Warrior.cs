using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior:BaseHero
    {
        public Warrior(string name)
        {
            Power = 100;
            Name = name;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
