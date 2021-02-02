using Cars;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Cars
{
   public class Tesla:ICar,IElectricCar
    {
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public Tesla(string model,string color,int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }
        public string Start()
        {
            return "Engine start".ToString();
        }
        public string Stop()
        {
            return "Breaaak!".ToString() ;
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} batteries\n{Start()}\n{Stop()}";
        }
    }
}
