using _04.RandomList;
using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("gosho");
            list.Add("goshaka");
            list.Add("goshakata");

            Console.WriteLine(  list.Count);
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}
