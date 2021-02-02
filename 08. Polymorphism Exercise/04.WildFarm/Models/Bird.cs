﻿using _04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
   public abstract class Bird:Animal
    {
        protected Bird
            (string name,double weight,int foodEaten,double wingSize)
            :base(name,weight,foodEaten)
        {
            WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
        public double WingSize { get; set; }
    }
}
