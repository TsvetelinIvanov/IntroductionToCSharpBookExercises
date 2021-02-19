using System;

namespace _12Fibonacci100
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            decimal f0 = 0;
            decimal f1 = 1;
            decimal fNext = 0;
            Console.WriteLine(f0);
            Console.WriteLine(f1);
            for (int i = 0; i < n - 1; i++)
            {
                fNext = f0 + f1;
                f0 = f1;
                f1 = fNext;
                Console.WriteLine(f1);
            }
        }
    }
}
