﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public interface IBuyer
    {
       int BuyFood(string name);
        int Food { get; }
    }
}
