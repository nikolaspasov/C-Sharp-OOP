using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();

            while (raidGroup.Count != n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                //var classType = Type.GetType(type);
                //var hero = Activator.CreateInstance(classType);

                switch (type)
                {
                    case "Paladin":
                        BaseHero hero = new Paladin(name);
                        raidGroup.Add(hero); break;
                    case "Druid":
                        hero = new Druid(name);
                        raidGroup.Add(hero); break;
                    case "Rogue":
                        hero = new Rogue(name);
                        raidGroup.Add(hero); break;
                    case "Warrior":
                        hero = new Warrior(name);
                        raidGroup.Add(hero); break;
                    default: Console.WriteLine("Invalid hero!"); break;
                }
            }
            
           
            int bossPower = int.Parse(Console.ReadLine());
            int heroPower = 0;
            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
               heroPower+=hero.Power;
            }
            if(heroPower>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

    }
}
