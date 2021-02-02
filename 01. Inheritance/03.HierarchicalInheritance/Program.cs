using Farm;
using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog sharo = new Dog();

            sharo.Eat();
            sharo.Bark();

            Cat pisana = new Cat();

            pisana.Eat();
            pisana.Meow();
        }
    }
}
