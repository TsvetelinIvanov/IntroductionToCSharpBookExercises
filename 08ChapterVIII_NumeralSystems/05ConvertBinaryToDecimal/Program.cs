using System;

namespace _05ConvertBinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryNumberString = Console.ReadLine();

            long decimalNumber = 0;
            long multiplier = 1;
            for (int i = binaryNumberString.Length - 1; i >= 0; i--)
            {
                if (binaryNumberString[i] == '1')
                {
                    decimalNumber += multiplier;
                }

                multiplier *= 2;
            }

            Console.WriteLine(decimalNumber);
        }
    }
}