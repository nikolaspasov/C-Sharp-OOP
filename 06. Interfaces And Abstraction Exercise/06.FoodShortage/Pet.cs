using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public class Pet
    {
        private string name;
        private string birthdate;

        public Pet(string name,string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        } 
        public string Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
            }
        }
    }
}
