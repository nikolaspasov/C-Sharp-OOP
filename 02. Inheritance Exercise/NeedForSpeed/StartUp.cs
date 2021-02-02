namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar newCar = new FamilyCar(100,100);
            newCar.Drive(25);

            SportCar sportCar = new SportCar(100,100);
            sportCar.Drive(10);
        }
    }
}
