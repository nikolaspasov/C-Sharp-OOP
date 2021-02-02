using System;

namespace _09.ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				int num = int.Parse(Console.ReadLine());
				
				Console.WriteLine(Sqrt(num));
				
			}
			catch (ArgumentOutOfRangeException argRangeEx)
			{
				Console.WriteLine("Invalid number");
				throw;
			}
			finally
			{
				Console.WriteLine("Good bye");
			}
        }
		public static double Sqrt(double value)
		{
			if (value < 0)
			{
				throw new
					System.ArgumentOutOfRangeException
					("value","Invalid number");
			}
				return Math.Sqrt(value);
			
		}
    }
}
