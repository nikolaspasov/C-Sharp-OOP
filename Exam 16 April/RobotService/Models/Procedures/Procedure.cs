using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : Contracts.Procedure
    {
       
        public Procedure()
        {
            Robots = new List<IRobot>();
        }
        public List<IRobot> Robots { get; set; }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if(robot.ProcedureTime<procedureTime)
            {
                throw new ArgumentException
                    ("Robot doesn't have enough procedure time");
            }
            robot.ProcedureTime -= procedureTime;
        }
        public  string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}");

            foreach (var robot in Robots)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name} " +
                    $"- Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }
            return sb.ToString().Trim();
        }
    }
}
