using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
        {
            Power = 100;
            Name = name;
        }
        public override string CastAbility()
        {
            return 
                $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
