namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Robot rob = new Robot("12345Robby", 10);
            rob.Recharge();
            rob.Work(3);
            Employee ben = new Employee("1234BENNY");
            ben.Sleep();
            ben.Work(3);
        }
    }
}
