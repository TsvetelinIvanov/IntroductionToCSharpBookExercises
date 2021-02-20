using System;

namespace _05Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int f0 = 0;
            int f1 = 1;
            for (int i = 3; i <= n; i++)
            {
                int fNext = f1;
                f1 = f0 + f1;
                f0 = fNext;
            }

            Console.WriteLine(f1);
        }
    }
}
