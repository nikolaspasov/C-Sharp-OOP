using System;

namespace _04.FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1 = 30;
                int num2 = 60;
                byte result;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);

                Console.WriteLine();

            }
            catch (OverflowException OvEx)
            {
                Console.WriteLine(OvEx.Message);
                
            }
           
            
        }
    }
}
