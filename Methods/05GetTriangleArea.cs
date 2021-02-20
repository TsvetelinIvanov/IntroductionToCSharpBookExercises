using System;

namespace _05GetTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = GetTriangleArea(a, h);
            Console.WriteLine(area);
        }

        static double GetTriangleArea(double length, double height)
        {
            return (length * height) / 2;
        }
    }
}
