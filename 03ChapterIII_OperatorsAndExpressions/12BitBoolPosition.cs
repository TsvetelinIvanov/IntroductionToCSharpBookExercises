using System;

namespace _12BitBoolPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int mask = 1 << p;//or Console.WriteLine(0 != (n & (1 << p)));
            int mask1 = n & mask;//or Console.WriteLine(0 != mask1);
            if (mask1 != 0)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
