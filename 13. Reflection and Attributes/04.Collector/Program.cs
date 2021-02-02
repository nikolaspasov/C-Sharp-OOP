using _01.Stealer;
using System;

namespace _04.Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
