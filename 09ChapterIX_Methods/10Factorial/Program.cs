using System;

namespace _10Factorial
{
    class Program
    {
        const int MaxArrayLength = 158;//The count of digits in 100!

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] digits = Factorial(number);

            bool hasValueTillNow = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 0 || hasValueTillNow)
                {
                    hasValueTillNow = true;
                    Console.Write(digits[i]);
                }
            }

            Console.WriteLine();
        }

        static int[] Factorial(int number)
        {
            int[] digits = new int[MaxArrayLength];            
            digits[0] = 1;//  1!=1
            for (int i = 2; i <= number; i++)
            {
                int rest = 0;
                for (int j = 0; j < MaxArrayLength; j++)
                {
                    int currentResult = digits[j] * i;
                    currentResult += rest;

                    int currentDigit = currentResult % 10;
                    digits[j] = currentDigit;

                    currentResult /= 10;
                    rest = currentResult;
                }
            }

            return digits;
        }
    }
}