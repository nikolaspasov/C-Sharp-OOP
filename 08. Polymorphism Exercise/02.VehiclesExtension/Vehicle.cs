using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            if (fuelQuantity > tankCapacity)
            {
                FuelQuantity = 0;
            }
        }
        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; private set; }
        public double TankCapacity { get; set; }

        public virtual string Drive(double amount)
        {
            if (amount * FuelConsumption > FuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }
            this.FuelQuantity -= amount * FuelConsumption;
            return $"{GetType().Name} travelled {amount} km";
        }
        public virtual void DriveFull(double amount)
        {
            FuelConsumption += 1.4;
            if (amount * FuelConsumption > FuelQuantity)
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= amount * FuelConsumption;
                
                Console.WriteLine($"{GetType().Name} travelled {amount} km");
            }
            FuelConsumption -= 1.4;
        }
        public virtual void Refuel(double amount)
        {
            if(amount<=0)
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
                FuelQuantity += amount;
            }
        }
       
    }
}
