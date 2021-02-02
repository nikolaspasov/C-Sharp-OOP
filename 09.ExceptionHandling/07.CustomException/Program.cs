using System;

namespace _07.CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Student studentOne = new Student("Koko", "KokoMoko@");
                Student studentTwo = new Student("Gon4o", "KokoMoko@");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
           


        }
    }
}
