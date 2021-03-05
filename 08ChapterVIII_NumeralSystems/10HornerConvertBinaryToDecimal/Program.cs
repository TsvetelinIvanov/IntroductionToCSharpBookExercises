using System;

namespace _10HornerConvertBinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte BaseNumber = 2;
            string binaryNumberString = Console.ReadLine();
            byte currentDigit = byte.Parse(binaryNumberString[0].ToString());

            long decimalNumber = currentDigit;
            for (int i = 1; i < binaryNumberString.Length; i++)
            {
                decimalNumber *= BaseNumber;
                currentDigit = byte.Parse(binaryNumberString[i].ToString());
                decimalNumber += currentDigit;
            }

            Console.WriteLine(decimalNumber);
        }
    }
}