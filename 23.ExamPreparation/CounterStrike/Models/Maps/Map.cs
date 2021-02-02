using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        List<IPlayer> terrorists;
        List<IPlayer> counterTerrorists;
        public Map()
        {
            terrorists = new List<IPlayer>();
            counterTerrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
           
            foreach (var player in players)
            {
               if(player is CounterTerrorist)
                {
                    counterTerrorists.Add(player);
                }
               else
                {
                    terrorists.Add(player);
                }
            }
            while (terrorists.Any(x => x.IsAlive == true) &&
             counterTerrorists.Any(x => x.IsAlive == true))
            {
                foreach (var terrorist in terrorists)
                {
                   
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            if (counterTerrorist.IsAlive)
                            {

                                counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                            }
                        }
                   
                    
                }


                foreach (var counterTerrorist in counterTerrorists)
                {
                    
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {

                                terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                            }
                        }
                   
                }
            }
            if (terrorists.All(x => x.IsAlive == true))
            {
                return "Terrorist wins!";
            }
            
                return "Counter Terrorist wins!";
            
            
        }
    }
}
