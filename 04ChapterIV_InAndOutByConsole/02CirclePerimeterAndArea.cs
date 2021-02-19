using System;

namespace _02CirclePerimeterAndArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double perimeter = 2 * Math.PI * r;
            double area = Math.PI * r * r;
            Console.WriteLine("Circle perimeter = {0:f3}.", perimeter);//for 0.001 and 0.100, or Console.WriteLine("Circle perimeter = {0}.", Math.Round(perimeter, 3)); for 0.001 and 0.1.
            Console.WriteLine("Circle area = {0:f3}.", area);//for 0.001 and 0.100, or Console.WriteLine("Circle area = {0}.", Math.Round(area, 3)); for 0.001 and 0.1.
        }
    }
}
