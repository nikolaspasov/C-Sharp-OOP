using _02.VehiclesExtension;
using System;

namespace _01._Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string carInfo = Console.ReadLine();
            string truckInfo = Console.ReadLine();
            string busInfo = Console.ReadLine();

            Vehicle car = new Car
                (double.Parse
                (carInfo.Split(" ")[1]), double.Parse(carInfo.Split(" ")[2]),
                double.Parse(carInfo.Split(" ")[3]));
            Vehicle truck = new Truck
             (double.Parse
             (truckInfo.Split(" ")[1]), double.Parse(truckInfo.Split(" ")[2]),
             double.Parse(truckInfo.Split(" ")[3]));
            Vehicle bus = new Bus
             (double.Parse
             (busInfo.Split(" ")[1]), double.Parse(busInfo.Split(" ")[2]),
             double.Parse(busInfo.Split(" ")[3]),false);

            int commandNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandNum; i++)
            {
                string action = Console.ReadLine();
                string vehicleType = action.Split(" ")[1];
                string actionType = action.Split(" ")[0];

                if (vehicleType == "Car")
                {
                    switch (actionType)
                    {
                        case "Drive": Console.WriteLine(car.Drive(double.Parse(action.Split(" ")[2]))); break;
                        case "Refuel": car.Refuel(double.Parse(action.Split(" ")[2])); break;
                    }
                }
                else if( vehicleType=="Truck")
                {
                    switch (actionType)
                    {
                        case "Drive": Console.WriteLine(truck.Drive(double.Parse(action.Split(" ")[2]))); break;
                        case "Refuel": truck.Refuel(double.Parse(action.Split(" ")[2])); break;
                    }
                }
                else
                {
                    switch (actionType)
                    {
                        case "DriveEmpty": 
                            Console.WriteLine(bus.Drive(double.Parse(action.Split(" ")[2]))); break;
                        case "Refuel": bus.Refuel(double.Parse(action.Split(" ")[2])); break;
                        case "Drive": 
                            bus.DriveFull(double.Parse(action.Split(" ")[2])); break;
                    }
                }

            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
