using System;

namespace _11BitPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int mask = 1 << p;//or Console.WriteLine(0 == (n & (1 << p) ? 0 : 1);
            Console.WriteLine((n & mask) != 0 ? 1 : 0);
        }
    }
}
