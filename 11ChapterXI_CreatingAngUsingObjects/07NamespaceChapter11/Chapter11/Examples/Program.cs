using System;

namespace Chapter11.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat someCat = new Cat();
            someCat.SayMiau();
            Console.WriteLine("The color of cat {0} is {1}.", someCat.Name, someCat.Color);
        }
    }
}