using System;
using System.Numerics;

namespace _08CatalanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            if (N < 0)
            {
                Console.WriteLine("Invalid input!");
                
                return;
            }

            if (N == 0 || N == 1)
            {
                Console.WriteLine("1");
                
                return;
            }

            BigInteger numerator = 1;
            for (int i = 2 * N; i > N + 1; i--)
            {
                numerator *= i;
            }

            BigInteger denominator = 1;
            for (int i = N; i > 1; i--)
            {
                denominator *= i;
            }

            BigInteger result = numerator / denominator;
            Console.WriteLine(result);
        }
    }
}
