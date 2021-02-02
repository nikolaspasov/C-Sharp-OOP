using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
       
        public Person
          (string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if(value.Length<3)
                {
                    throw new ArgumentException
                        ("First name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public string LastName 
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException
                        ("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
           private set
            {
                if(value<=0)
                {
                    throw new ArgumentException
                        ("Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary 
        {
            get
            {
                return salary;
            }
            private set
            {
                if (value <460m)
                {
                    throw new ArgumentException
                        ("Salary cannot be less than 460 leva!");
                }
            }
        }

        
      
        public override string ToString()
        {
            return $"{FirstName} {LastName} gets " +
                $"{Salary:f2} leva.";
        }
    }
}
