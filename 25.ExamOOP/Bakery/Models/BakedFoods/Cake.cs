﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Cake : Food
    {
        public Cake
            (string name, int portion, decimal price) 
            : base(name, 245, price)
        {
        }
    }
}
