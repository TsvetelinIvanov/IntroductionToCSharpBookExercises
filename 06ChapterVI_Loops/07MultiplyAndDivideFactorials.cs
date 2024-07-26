using System;
using System.Numerics;

namespace _07MultiplyAndDivideFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());
            if (K >= N || K <= 1 || N <= 1)
            {
                Console.WriteLine("Invalid input!");
                
                return;
            }

            BigInteger firstFactorial = 1;
            for (int i = N; i > (N - K); i--)
            {
                firstFactorial *= i;
            }

            BigInteger secondFactorial = 1;
            for (int i = K; i > 1; i--)
            {
                secondFactorial *= i;
            }

            BigInteger result = firstFactorial * secondFactorial;
            Console.WriteLine(result);
        }
    }
}
