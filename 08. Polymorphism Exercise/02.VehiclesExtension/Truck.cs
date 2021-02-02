using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _01._Vehicles
{
    public class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity)
           : base(fuelQuantity, fuelConsumption,tankCapacity)
        {

           
        }

        public override double FuelConsumption
        {get=> base.FuelConsumption+1.6; }


        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + amount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                return;
            }
            else
            {
                base.Refuel(amount * 0.95);
            }
        }

    }
}
