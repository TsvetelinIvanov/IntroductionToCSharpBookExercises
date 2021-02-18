using System;

namespace _06_RectanglePerimeterAndArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("P = {0}", (a == 0 || b == 0) ? 0 : (2 * a + 2 * b));
            Console.WriteLine("S = {0}", a * b);
        }
    }
}
