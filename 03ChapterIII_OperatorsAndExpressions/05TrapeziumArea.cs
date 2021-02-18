using System;

namespace _05TrapeziumArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = ((a + b) / 2) * h;
            Console.WriteLine("{0:f2}", area); // for 0.10 or 0.01, or Math.Round(area, 2); for 0.01 or 0.1.
        }
    }
}
