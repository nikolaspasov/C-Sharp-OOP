using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Procedure = RobotService.Models.Procedures.Contracts.Procedure;

namespace RobotService.Core
{
    public class Controller : IController
    {
        
        private readonly Garage garage;
        private readonly List<Procedure> procedures;

        Models.Procedures.Contracts.Procedure chip = new Chip();
        Models.Procedures.Contracts.Procedure charge = new Charge();
        Models.Procedures.Contracts.Procedure polish = new Polish();
        Models.Procedures.Contracts.Procedure rest = new Rest();
        Models.Procedures.Contracts.Procedure work = new Work();
        Models.Procedures.Contracts.Procedure techCheck = new TechCheck();
        public Controller()
        {
            garage = new Garage();

            procedures = new List<Procedure>();
            procedures.Add(chip);
            procedures.Add(charge);
            procedures.Add(polish);
            procedures.Add(rest);
            procedures.Add(work);
            procedures.Add(techCheck);
            
        }
        public string Charge(string robotName, int procedureTime)
        {
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            Models.Procedures.Contracts.Procedure procedure = this.charge;
            procedure.DoService(robot, procedureTime);
            procedures.Add(procedure);
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if(robot==null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            Models.Procedures.Contracts.Procedure procedure = this.chip;
            procedure.DoService(robot, procedureTime);
            procedures.Add(procedure);
            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
           Procedure procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == procedureType);

            return procedure.History();
        }

        public string Manufacture
  (string robotType, string name, int energy, int happiness, int procedureTime)
        {
           
            Robot robot = null;
            if(robotType=="HouseholdRobot")
            {
                 robot = new HouseholdRobot
                    (name, energy, happiness, procedureTime);
            }
            else if(robotType=="PetRobot")
            {
                 robot = new PetRobot
                    (name, energy, happiness, procedureTime);
            }
            else if(robotType=="WalkerRobot")
            {
                 robot = new WalkerRobot
                    (name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }
            garage.Manufacture(robot);
            return $"Robot {name} registered successfully";

        }

        public string Polish(string robotName, int procedureTime)
        {
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            Models.Procedures.Contracts.Procedure procedure = this.polish;
            procedure.DoService(robot, procedureTime);
            procedures.Add(procedure);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            Models.Procedures.Contracts.Procedure procedure = this.rest;
            procedure.DoService(robot, procedureTime);
            procedures.Add(procedure);
            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            garage.Sell(robotName,ownerName);

            if(robot.IsChipped==true)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot withput chip";
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            Models.Procedures.Contracts.Procedure procedure = this.techCheck;
            procedure.DoService(robot, procedureTime);
            procedures.Add(procedure);
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            
            var robot = garage.Robots.GetValueOrDefault(robotName);
            if (robot == null)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            Models.Procedures.Contracts.Procedure procedure = this.work;
            procedure.DoService(robot, procedureTime);
            procedures.Add(procedure);
            return $"{robotName} was working for {procedureTime} hours.";
        }
    }
}
