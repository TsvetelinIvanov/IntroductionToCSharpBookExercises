using System;

namespace _08PointInCircle
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if ((x * x + y * y) <= 25)//or int r = 5; if ((x * x + y * y) <= r * r)
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }
        }
    }
}
