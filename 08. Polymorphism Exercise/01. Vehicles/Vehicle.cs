using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }


        public string Drive(double amount)
        {
            if (amount * FuelConsumption > FuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }
            this.FuelQuantity -= amount * FuelConsumption;
            return $"{GetType().Name} travelled {amount} km";
        }
        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }
       
    }
}
