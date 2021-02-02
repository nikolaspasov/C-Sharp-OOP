using _05.BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> birthdateList = new List<string>();
            string[] input = Console.ReadLine().Split(" ").ToArray();
            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    Human human = new Human(input[1], int.Parse(input[2]), input[3],input[4]);
                    birthdateList.Add(input[4]);
                }
                else if(input[0]=="Robot")
                {
                    Robot robot = new Robot(input[1], input[2]);
                    
                }
                else
                {
                    Pet pet = new Pet(input[1], input[2]);
                    birthdateList.Add(input[2]);
                }
                input = Console.ReadLine().Split(" ").ToArray();
            }
            string year = Console.ReadLine();

            foreach (var date in birthdateList)
            {
                StringBuilder currYear = new StringBuilder();
                currYear.Append(date.Split("/")[2]);
                if(currYear.ToString()==year)
                {
                    Console.WriteLine(date);
                }
                
            }
        }
    }
}
