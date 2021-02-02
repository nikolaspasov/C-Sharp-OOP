namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake("peshaka");

            Gorilla gorrila = new Gorilla("Gogata");
            System.Console.WriteLine(gorrila.Name);
            
        }
    }
}