using System;
using System.ComponentModel;

namespace _01.ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box newBox = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {newBox.GetSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {newBox.GetLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {newBox.GetVolume():f2}");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
            }
            
        }
    }
}
