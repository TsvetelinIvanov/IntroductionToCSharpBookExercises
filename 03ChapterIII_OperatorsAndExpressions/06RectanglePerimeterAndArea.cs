using System;

namespace _06RectanglePerimeterAndArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int perimeter = 2 * a + 2 * b;
            int area = a * b;
            Console.WriteLine("Perimeter = " + perimeter);
            Console.WriteLine("Area = " + area);
        }
    }
}
