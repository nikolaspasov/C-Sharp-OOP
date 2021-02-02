using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace _07.CustomException
{
    public class Student
    {
        private string name;
        private string email;

        public Student
            (string name,string email)
        {
            Name = name;
            Email = email;
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if(value.Any(char.IsDigit)||
                    value.Any(char.IsSymbol))
                {
                    throw new InvalidPersonNameException( "Name cannot contain digits or symbols." );
                }
                name = value; 
            }
        } 
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
