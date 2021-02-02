using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isBought;
        private bool isChecked;
        protected Robot
            (string name,int energy,int happiness,int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Service";
        }
        public string Name { get; }
        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }
        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {Name}" +
                $" - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
