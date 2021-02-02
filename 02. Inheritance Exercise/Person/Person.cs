using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        public string Name;
        public int Age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Name: {Name}, Age: {Age}");
                return sb.ToString();
        }

    }
}
