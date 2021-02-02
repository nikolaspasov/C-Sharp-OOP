using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
        public void Add(ICar model)
        {
            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
           return this.cars.ToList();
        }

        public ICar GetByName(string name)
        {
            return cars.FirstOrDefault
                (x => x.Model == name); 
        }

        public bool Remove(ICar model)
        {
            cars.Remove(model);
            return true;
        }
    }
}
