using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
           : base(fuelQuantity, fuelConsumption+1.6)
        {
            
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount*0.95);
        }

    }
}
