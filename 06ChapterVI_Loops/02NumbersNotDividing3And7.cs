using System;

namespace _02NumbersNotDividing3And7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (i % (3 * 7) != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
