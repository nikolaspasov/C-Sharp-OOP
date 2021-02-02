using _02.MultipleInheritance;
using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy gosheto = new Puppy();

            gosheto.Eat();
            gosheto.Bark();
            gosheto.Weep();
        }
    }
}
