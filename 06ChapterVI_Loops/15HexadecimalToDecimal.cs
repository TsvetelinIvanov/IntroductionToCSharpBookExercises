using System;

namespace _15HexadecimalToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Base = 16;
            string hexadecimalNumberString = Console.ReadLine();

            char[] hexadecimalNumberCharArray = hexadecimalNumberString.ToCharArray();
            Array.Reverse(hexadecimalNumberCharArray);

            int decimalNumber = 0;
            for (int i = 0; i < hexadecimalNumberCharArray.Length; i++)
            {
                int digit;
                switch (hexadecimalNumberCharArray[i])
                {
                    case 'A':
                        digit = 10;
                        break;
                    case 'B':
                        digit = 11;
                        break;
                    case 'C':
                        digit = 12;
                        break;
                    case 'D':
                        digit = 13;
                        break;
                    case 'E':
                        digit = 14;
                        break;
                    case 'F':
                        digit = 15;
                        break;
                    default:
                        digit = int.Parse(hexadecimalNumberCharArray[i].ToString());
                        break;
                }

                decimalNumber += digit * (int)Math.Pow(Base, i);
            }

            Console.WriteLine(decimalNumber);
        }
    }
}
