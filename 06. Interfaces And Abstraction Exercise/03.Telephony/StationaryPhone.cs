using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone:ICallable
    {
        private string number;
        public string Calling(string number)
        {
            Number = number;
            return $"Dialing... {number}";
        }
         public string Number
        {
            get { return number; }
            set
            {
                if (!value.All(char.IsNumber))
                {
                    throw new ArgumentException("Invalid number!");
                }
                number = value;
            }
        }
    }
}
