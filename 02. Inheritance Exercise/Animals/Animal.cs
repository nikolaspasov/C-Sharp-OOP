using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name,int age,string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
            ProduceSound();
        }
        public string Name 
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Cannot be null or empty");
                }
                name = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public string Gender 
        {
            get { return gender; }
            set
            {
                if(String.IsNullOrEmpty(value)||!(value=="Male"||value=="Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }
        public virtual string ProduceSound()
        {
            return "Default Sound";
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(this.GetType().Name)
                .AppendLine($"{this.name} {this.age} {this.gender.ToString()}")
                .Append($"{this.ProduceSound()}");

            return builder.ToString();
        }
    }
}
