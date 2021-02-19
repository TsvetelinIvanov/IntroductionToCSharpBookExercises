using System;

namespace _07MoonGravitation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of Earth weight:");
            int weightEarth = Convert.ToInt32(Console.ReadLine());
            double weightMoon = weightEarth * 0.17;
            Console.WriteLine("The number of Moon weight is: {0:f2}.", weightMoon); // for 0.10 or 0.01, or Math.Round(area, 2); for 0.01 or 0.1.
        }
    }
}
