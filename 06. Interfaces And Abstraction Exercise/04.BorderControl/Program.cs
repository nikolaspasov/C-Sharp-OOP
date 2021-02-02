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
            List<string> idList = new List<string>();
            string[] input = Console.ReadLine().Split(" ").ToArray();
            while(input[0]!="End")
            {
                if(input.Length==3)
                {
                    Human human = new Human(input[0], int.Parse(input[1]), input[2]);
                    idList.Add(input[2]);
                }
                else
                {
                    Robot robot = new Robot(input[0], input[1]);
                    idList.Add(input[1]);
                } 
                input = Console.ReadLine().Split(" ").ToArray();
            }
            string fakeId = Console.ReadLine();

            foreach (var id in idList)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = id.Length - fakeId.Length; i <=id.Length-1; i++)
                {
                    sb.Append(id[i]);
                }
                if(sb.ToString()==fakeId)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
