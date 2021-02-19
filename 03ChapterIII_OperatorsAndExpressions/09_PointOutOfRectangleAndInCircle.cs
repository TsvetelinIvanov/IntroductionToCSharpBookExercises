using System;

namespace _09_PointOutOfRectangleAndInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int r = 5;
            bool isInTheCircle = false;
            if (r * r >= x * x + y * y)
            {
                isInTheCircle = true;
            }
            int x1 = -1;
            int y1 = 1;
            int x2 = 5;
            int y2 = 5;
            bool isOutOfTheRectangle = false;
            if ((x1 > x || x2 < x) || (y1 > y || y2 < y))
            {
                isOutOfTheRectangle = true;
            }
            Console.WriteLine(isInTheCircle && isOutOfTheRectangle);
        }
    }
}
