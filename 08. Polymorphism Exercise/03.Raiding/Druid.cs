using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name)
        {
            Power = 80;
            Name = name;
        }
        public override string CastAbility()
        {
            return
            $"{GetType().Name} - {Name} healed for {Power}";

        }
    }
}
