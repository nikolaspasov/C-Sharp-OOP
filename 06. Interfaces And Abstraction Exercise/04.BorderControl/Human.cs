using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Human:IHuman
    {
        private string name;
        private int age;
        private string id;

        public Human(string name,int age,string id)
        {
            Name = name;
            Age = age;
            Id = id;

        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
         public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
         public string Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

    }
}
