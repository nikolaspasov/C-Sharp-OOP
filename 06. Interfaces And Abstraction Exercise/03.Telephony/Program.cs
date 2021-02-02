using System;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ").ToArray();
            string[] websites = Console.ReadLine().Split(" ").ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    if (numbers[i].Length == 7)
                    {
                        StationaryPhone phone = new StationaryPhone();
                        Console.WriteLine(phone.Calling(numbers[i]));
                    }
                    else
                    {
                        Smartphone smartphone = new Smartphone();
                        Console.WriteLine(smartphone.Calling(numbers[i]));
                    }
                    
                }
                catch(ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                }
               
            }
            for (int i = 0; i < websites.Length; i++)
            {
                try
                {
                    Smartphone smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Browsing(websites[i]));
                }
                catch(ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                }

            }
        }
    }
}
