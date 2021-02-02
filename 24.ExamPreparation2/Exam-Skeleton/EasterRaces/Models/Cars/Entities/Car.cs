﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private double calculateRacePoints;
        private int minHorsePower;
        private int maxHorsePower;
        protected Car
            (string model, int horsePower, 
            double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            
        }
        public string Model
        {
            get
            {
                return model;
            }
           private set
            {
                if(string.IsNullOrWhiteSpace(value)||value.Length<4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }

        public  int HorsePower
        {
            get
            {
                return horsePower;
            }
            private set
            {
                if(value<this.minHorsePower||value>this.maxHorsePower)
                {
                    throw new ArgumentException
                        ($"Invalid horse power: {value}");
                }
                horsePower = value;
            }
        }
        public double CubicCentimeters
        {
            get;
         }
        public double CalculateRacePoints(int laps)
        {
            return cubicCentimeters / horsePower * laps;
        }
    }
}
