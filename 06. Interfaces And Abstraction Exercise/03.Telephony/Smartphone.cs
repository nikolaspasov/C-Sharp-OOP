using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        private string number;
        private string site;

        public string Calling(string number)
        {
            Number = number;
            return $"Calling... {number}";
        }
        public string Browsing(string site)
        {
            Site = site;
            return $"Browsing: {site}!";
        }
        public string Number
        {
            get
            { return number; }
            set
            {
                if (!value.All(char.IsNumber))
                {
                    throw new ArgumentException("Invalid number!");
                }
                number = value;
            }
        }
        public string Site
        {
            get
            {
                return site;
            }
            set
            {
                if(value.Any(char.IsNumber))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                site = value;
            }
        }
    }
}
