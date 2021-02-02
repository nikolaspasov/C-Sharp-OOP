using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    class PlayerRepository
    {
        private List<IPlayer> modelsList;
        public PlayerRepository()
        {
            modelsList = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models
        {
            get
            {
                return modelsList.AsReadOnly();
            }
        }
        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository) ;
            }
            modelsList.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return modelsList.FirstOrDefault(m => m.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            if (modelsList.Contains(model))
            {
                modelsList.Remove(model);
                return true;
            }
            return false;
        }
    }
}
