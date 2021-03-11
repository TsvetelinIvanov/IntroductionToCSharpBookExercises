using System;

namespace _05FindHypotenuse
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double hypotenuse = Math.Sqrt(a * a + b * b);
            Console.WriteLine(hypotenuse);
        }
    }
}