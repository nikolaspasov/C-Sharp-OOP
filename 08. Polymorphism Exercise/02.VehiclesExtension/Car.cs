using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity,double fuelConsumption,double tankCapacity)
            :base( fuelQuantity, fuelConsumption,tankCapacity)
        {
             
        }
        public override double FuelConsumption
        { get => base.FuelConsumption + 0.9; }



    }
}
