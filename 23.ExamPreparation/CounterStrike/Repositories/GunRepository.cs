using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> modelsList;
        public GunRepository()
        {
            modelsList = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models
        {
            get 
            { 
                return modelsList.AsReadOnly(); 
            }
        }
        public void Add(IGun model)
        {
            if(model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            modelsList.Add(model);
        }

        public IGun FindByName(string name)
        {
            return modelsList.FirstOrDefault(m => m.Name == name);           
        }

        public bool Remove(IGun model)
        {
            if(modelsList.Contains(model))
            {
                modelsList.Remove(model);
                return true;
            }
            return false;
        }
    }
}
