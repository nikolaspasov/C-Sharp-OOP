using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;
        public Driver(string name)
        {
            Name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value)||value.Length<5)
                {
                    throw new ArgumentException
                        ($"Name {name} cannot be less than 5 symbols.");
                }
            }
        }

        public ICar Car

        {
            get;

            protected set;
        }

        public int NumberOfWins
        {
            get;
            private set;
        }

        public bool CanParticipate
        { 
            get
            {
                return canParticipate;
            }
            protected set
            {
                if(Car!=null)
                {
                    canParticipate = true;
                }
                canParticipate = false;
            }
        }


        public void AddCar(ICar car)
        {
           if(car==null)
            {
                throw new ArgumentNullException(nameof(ICar),"Car cannot be null");
            }
            this.Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
