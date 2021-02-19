using System;

namespace _09PointOutOfRectangleAndInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if ((x * x + y * y <= 25) && ((x < -1 || x > 5) || (y < 1 || y > 5)))
            {
                Console.WriteLine("The point is in the ciricle and out of the rectangle.");
            }
            else if ((x * x + y * y <= 25) && ((x >= -1 && x <= 5) && (y >= 1 && y <= 5)))
            {
                Console.WriteLine("The point is in the ciricle and in the rectangle.");
            }
            else if ((x * x + y * y > 25) && ((x >= -1 && x <= 5) && (y >= 1 && y <= 5)))
            {
                Console.WriteLine("The point is out of the ciricle and in the rectangle.");
            }
            else
            {
                Console.WriteLine("The point is out of the ciricle and out of the rectangle.");
            }
        }
    }
}
