namespace RobotService.Models.Procedures.Contracts
{
    using RobotService.Models.Robots.Contracts;

    public interface Procedure
    {
        string History();

        void DoService(IRobot robot, int procedureTime);
    }
}
