using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue:BaseHero
    {
        public Rogue(string name)
        {
            Power = 80;
            Name = name;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
