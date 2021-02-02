using System;

namespace _06.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person personOne = new Person("Nik", "George", 32);

               Person personTwo = new Person("", "George", 32);
              //  Person personThree = new Person("John", "", 32);
               // Person personFour = new Person("John", "Tyler", 121);

                Console.WriteLine(personOne.FirstName);
                Console.WriteLine(personOne.LastName);
                Console.WriteLine(personOne.Age);
            }
            catch (ArgumentNullException argNull)
            {
                Console.WriteLine(argNull.Message);
            }
            catch(ArgumentOutOfRangeException argRange)
            {
                Console.WriteLine(argRange.Message);
            }
            
        }
    }
}
