using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> productInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToList();

            List<Person> people = new List<Person>();
            List<Product> productList = new List<Product>();
            try
            {
                for (int i = 0; i < peopleInput.Count; i++)
                {
                    string name = peopleInput[i].Split("=")[0];
                    double money
                        = double.Parse(peopleInput[i].Split("=")[1]);

                    Person newPerson = new Person(name, money);
                    people.Add(newPerson);
                }
                for (int i = 0; i < productInput.Count; i++)
                {
                    string product = productInput[i].Split("=")[0];
                    double price
                        = double.Parse(productInput[i].Split("=")[1]);
                    Product newProduct = new Product(product, price);
                    productList.Add(newProduct);
                }
                

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string person = command.Split(" ")[0];
                    string product = command.Split(" ")[1];

                    foreach (var currPerson in people)
                    {
                        if (currPerson.Name == person)
                        {
                            foreach (var currProduct in productList)
                            {
                                if (currProduct.Name == product)
                                {
                                    currPerson.AddProduct(currProduct);
                                }
                            }
                        }
                    }
                    command = Console.ReadLine();
                }
            }
            catch (ArgumentException error)
            {

                Console.WriteLine(error.Message);
                return;
            }
          
            foreach (var person in people)
            {
                
                Console.Write(person.Name+" - ");
               if(person.Products.Count==0)
                {
                    Console.Write("Nothing bought");
                }
                    Console.WriteLine(string.Join(", ",person.Products));
                
            }


        }
    }
}
