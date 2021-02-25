using System;
using System.Numerics;

namespace _11TrailingZerosInAFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger factorial = GetFactorial(number);
            string numberString = factorial.ToString();
            int tralingZerosCount = 0;
            for (int i = numberString.Length - 1; i >= 0; i--)
            {
                if (numberString[i] == '0')
                {
                    tralingZerosCount++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(tralingZerosCount);
        }

        private static BigInteger GetFactorial(int number)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
