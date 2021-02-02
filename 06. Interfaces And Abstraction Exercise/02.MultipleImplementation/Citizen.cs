﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen:IIdentifiable,IBirthable,IPerson
    {
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizen
            (string name, int age,string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        
    }
}
