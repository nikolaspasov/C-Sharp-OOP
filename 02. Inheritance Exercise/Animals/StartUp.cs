using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string type = Console.ReadLine();
          

            while (type != "Beast!")
            {
                List<Animal> animalList = new List<Animal>();
                try
                {
                    string input = Console.ReadLine();
                    string name = input.Split(" ")[0];
                    int age = int.Parse(input.Split(" ")[1]);
                    string gender = input.Split(" ")[2];
                    

                    switch (type)
                    {
                        case "Cat":
                          animalList.Add(new Cat(name, age, gender)); 
                            break;
                        case "Dog":
                            animalList.Add(new Dog(name, age, gender));
                            break;
                        case "Frog":
                            animalList.Add(new Frog(name, age, gender));
                            break;
                        case "Kitten":
                            animalList.Add(new Kitten(name, age, gender));
                            break;
                        case "Tomcat":
                            animalList.Add(new Tomcat(name, age, gender));
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                    foreach (var animal in animalList)
                    {
                        Console.WriteLine(animal);
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
              
                type = Console.ReadLine();
            }
           
                  
        }

    }
}





