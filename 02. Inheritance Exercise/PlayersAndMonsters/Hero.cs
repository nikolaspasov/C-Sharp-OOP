using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public string Username;
        public int Level;

        public Hero(string username, int level)

        {
            Username = username;
            Level = level;
        }
        public override string ToString()
        {
            return
            $"Type: {GetType().Name} Username: {Username} Level: {Level}";
        }
    }
}
