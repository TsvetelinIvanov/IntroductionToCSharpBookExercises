using System;

namespace _09SquareEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double discriminantD = Math.Pow(b, 2) - (4 * a * c);
            double rootx1 = 0;
            double rootx2 = 0;
            if (discriminantD > 0)
            {
                rootx1 = (-b + Math.Sqrt(discriminantD)) / (2 * a);
                rootx2 = (-b - Math.Sqrt(discriminantD)) / (2 * a);
                Console.WriteLine("Two real roots:");
                Console.WriteLine("x1 = " + rootx1);
                Console.WriteLine("x2 = " + rootx2);
            }
            else if (discriminantD == 0)
            {
                rootx1 = -b / 2 * a;
                Console.WriteLine("One real root:");
                Console.WriteLine("x = " + rootx1);
            }
            else
            {
                Console.WriteLine("No real roots.");
            }
        }
    }
}
