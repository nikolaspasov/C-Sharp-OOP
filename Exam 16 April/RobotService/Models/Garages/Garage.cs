using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
   public class Garage : IGarage
    {
        private const int capacity=10;
        private readonly Dictionary<string, IRobot> robots;

        public IReadOnlyDictionary<string, IRobot> Robots 
        { 
            get { return robots; }    
        }
        public Garage()
        {
            robots = new Dictionary<string, IRobot>();
        }

        public void Manufacture
            (IRobot robot)
        {
            if (robots.Count == capacity)
            {
                throw new ArgumentException
                    ("Not enough capacity");
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException
                    ($"robot {robot.Name} already exists");
            }
            robots.Add(robot.Name, robot);
        }

        public void Sell
            (string robotName, string ownerName)
        {
            if (!Robots.ContainsKey(robotName))
            {
                throw new ArgumentException
                    ($"Robot {robotName} does not exist");
            }
            var robot = Robots.GetValueOrDefault(robotName);
            robot.Owner = ownerName;
            robot.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
