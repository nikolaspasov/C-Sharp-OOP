using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;
        private IMap map;


        public Controller()
        {
            gunRepository = new GunRepository();
            playerRepository = new PlayerRepository();
            map = new Map();
        }
        public string AddGun
            (string type, string name, int bulletsCount)
        {
           if(type=="Pistol")
            {
                IGun newGun = new Pistol(name, bulletsCount);
                gunRepository.Add(newGun);
            }
           else if(type=="Rifle")
            {
                IGun newGun = new Rifle(name, bulletsCount);
                gunRepository.Add(newGun);
            }
           else
            {
                throw new ArgumentException("Invalid gun type!");
            }
            return $"Successfully added gun {name}.";
        }

        public string AddPlayer
            (string type, string username, int health, int armor, string gunName)
        {
            IGun gun = gunRepository.FindByName(gunName);
            if(gun==null)
            {
                throw new ArgumentException("Gun cannot be found!");
            }
            
           if(type=="Terrorist")
            {
                Player newPlayer = new Terrorist(username, health, armor, gun);
                playerRepository.Add(newPlayer);
            }
           else if(type=="CounterTerrorist")
            {
                Player newPlayer = new CounterTerrorist(username, health, armor, gun);
                playerRepository.Add(newPlayer);
            }
           else
            {
                throw new ArgumentException("Invalid player type!");
            }
            return $"Successfully added player {username}.";
        }

        public string Report()
        {
            List<IPlayer> sortedPlayers = playerRepository.Models
                 .OrderBy(p => p.GetType().Name)
                 .ThenByDescending(p => p.Health)
                 .ThenBy(p => p.Username)
                 .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var player in sortedPlayers)
            {
                result.AppendLine(player.ToString());
            }
            return result.ToString().TrimEnd();
        }

        public string StartGame()
        {
           return map.Start(playerRepository.Models.ToList());
        }
    }
}
