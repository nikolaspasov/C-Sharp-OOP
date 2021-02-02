using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepo;
        private readonly IRepository<ICar> carRepo;
        private readonly IRepository<IRace> raceRepo;
        public ChampionshipController()
        {
            this.driverRepo = new DriverRepository();
            this.carRepo = new CarRepository();
            this.raceRepo = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = this.carRepo.GetByName(carModel);
            var driver = this.driverRepo.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException
                    ($"Driver {driverName} could not be found.");
            }
            else if (car == null)
            {
                throw new InvalidOperationException
                    ($"Car {carModel} could not be found.");
            }
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepo.GetByName(raceName);
            var driver = driverRepo.GetByName(driverName);

            if(race==null)
            {
                throw new InvalidOperationException
                    ($"Race {raceName} could not be found.");
            }
            
            else if(driver==null)
            {
                throw new InvalidOperationException
                    ($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            Car newCar;
            if (carRepo.GetByName(model) != null)
            {
                throw new ArgumentException
                    ($"Car {model} is already created.");
            }
            if (type =="Muscle")
            {
                 newCar = new MuscleCar(model, horsePower);
                carRepo.Add(newCar);
                return $"MuscleCar {model} is created.";
            }
            else
            {
                 newCar = new SportsCar(model, horsePower);
                carRepo.Add(newCar);
                return $"SportsCar {model} is created.";
            }
           
        }

        public string CreateDriver(string driverName)
        {
            Driver newDriver = new Driver(driverName);

            if (driverRepo.GetByName(driverName) != null)
            {
                throw new ArgumentException
                    ($"Driver {driverName} is already created.");
            }
            driverRepo.Add(newDriver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if(raceRepo.GetByName(name)!=null)
            {
                throw new InvalidOperationException
                    ($"Race {name} is already created.");
            }
            Race newRace = new Race(name, laps);
            raceRepo.Add(newRace);
            return $"Race {name} is created.";

        }

        public string StartRace(string raceName)
        {
            var race = raceRepo.GetByName(raceName);
            if(race==null)
            {
                throw new InvalidOperationException
                    ($"Race {raceName} could not be found.");
            }
            else if(race.Drivers.Count<3)
            {
                throw new InvalidOperationException
            ($"Race {raceName} cannot start with less than 3 participants.");
            }
            var drivers = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine
                ($"Driver {drivers[0].Name} wins {raceName} race.");
            sb.AppendLine
                ($"Driver {drivers[1].Name} is second in {raceName} race.");
            sb.AppendLine
                ($"Driver {drivers[2].Name} is third in {raceName} race.");
            return sb.ToString().Trim();

        }
    }
}
