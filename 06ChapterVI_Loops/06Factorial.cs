using System;

namespace _06Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            int F = 1;
            for (int i = N; i >= K + 1; i--)
            {
                F *= i;
            }

            Console.WriteLine(F);
        }
    }
}
