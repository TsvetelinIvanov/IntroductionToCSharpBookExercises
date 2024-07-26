using System;

namespace _04ConvertDecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            long decimalNumber = long.Parse(Console.ReadLine());
            if (decimalNumber == 0)
            {
                Console.WriteLine(decimalNumber);
                
                return;
            }

            if (decimalNumber < 0)
            {
                decimalNumber ^= long.MinValue;
            }

            string binaryNumberString = string.Empty;
            while (decimalNumber != 0)
            {
                byte remainder = (byte)(decimalNumber % 2);
                binaryNumberString = remainder + binaryNumberString;
                decimalNumber /= 2;
            }

            Console.WriteLine(binaryNumberString);
        }
    }
}
