using System;

namespace _06SquareEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double x1 = 0.0;
            double x2 = 0.0;
            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("The equation has two real roots.");
                Console.WriteLine("x1 = " + x1 + ".");
                Console.WriteLine("x2 = " + x2 + ".");
            }
            else if (D == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine("The equation has one real root.");
                Console.WriteLine("x = " + x1 + ".");
            }
            else
            {
                Console.WriteLine("The equation has no real roots.");
            }
        }
    }
}
