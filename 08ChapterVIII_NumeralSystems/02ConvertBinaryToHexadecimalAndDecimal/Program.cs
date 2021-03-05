using System;

namespace _02ConvertBinaryToHexadecimalAndDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Convert from binary to decimal:
            string binaryNumberString = Console.ReadLine();
            int[] binaryNumberArray = new int[binaryNumberString.Length];
            for (int i = 0; i < binaryNumberString.Length; i++)
            {
                if (binaryNumberString[i] == '1')
                {
                    binaryNumberArray[i] = 1;
                }
                else
                {
                    binaryNumberArray[i] = 0;
                }
            }

            long decimalNumber = 0;
            for (int i = 0; i < binaryNumberArray.Length; i++)
            {
                decimalNumber += (long)(binaryNumberArray[i] * Math.Pow(2, binaryNumberArray.Length - i - 1));
            }

            Console.WriteLine(decimalNumber);

            // Convert from decimal to hexadecimal:
            string hexadecimalNumberString = string.Empty;
            do
            {
                int decimalDigit = (int)(decimalNumber % 16);

                if (decimalDigit > 9)
                {
                    char hexadecimalDigit = ' ';
                    switch (decimalDigit)
                    {
                        case 10:
                            hexadecimalDigit = 'A';
                            break;
                        case 11:
                            hexadecimalDigit = 'B';
                            break;
                        case 12:
                            hexadecimalDigit = 'C';
                            break;
                        case 13:
                            hexadecimalDigit = 'D';
                            break;
                        case 14:
                            hexadecimalDigit = 'E';
                            break;
                        case 15:
                            hexadecimalDigit = 'F';
                            break;
                        default:
                            break;
                    }

                    hexadecimalNumberString = hexadecimalDigit + hexadecimalNumberString;
                }
                else
                {
                    hexadecimalNumberString = decimalDigit + hexadecimalNumberString;
                }

                decimalNumber /= 16;
            } while (decimalNumber != 0);

            Console.WriteLine(hexadecimalNumberString);
        }
    }
}