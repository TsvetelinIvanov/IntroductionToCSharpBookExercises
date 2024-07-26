using System;

namespace _09ConvertBinaryToHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryNumberString = Console.ReadLine();

            string clearAndReversedBinaryNumberString = string.Empty;
            for (int i = 0; i < binaryNumberString.Length; i++)
            {
                if (binaryNumberString[i] == '1')
                {
                    for (int j = i; j < binaryNumberString.Length; j++)
                    {
                        clearAndReversedBinaryNumberString = binaryNumberString[j] + clearAndReversedBinaryNumberString;
                    }

                    break;
                }
            }

            if (clearAndReversedBinaryNumberString == string.Empty)
            {
                Console.WriteLine(0);
                
                return;
            }

            string hexadecimalNumberString = string.Empty;
            int bitsCount = clearAndReversedBinaryNumberString.Length;
            int bitPosition = 0;

            while (bitPosition < bitsCount)
            {
                byte decimalNumber = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (bitPosition >= bitsCount)
                    {
                        break;
                    }

                    if (clearAndReversedBinaryNumberString[bitPosition] == '1')
                    {
                        decimalNumber = (byte)(decimalNumber + Math.Pow(2, i));
                    }

                    bitPosition++;
                }

                char symbol = ' ';
                if ((decimalNumber >= 0) && (decimalNumber <= 9))
                {
                    symbol = (char)(decimalNumber + '0');
                }
                else
                {
                    switch (decimalNumber)
                    {
                        case 10:
                            symbol = 'A';
                            break;
                        case 11:
                            symbol = 'B';
                            break;
                        case 12:
                            symbol = 'C';
                            break;
                        case 13:
                            symbol = 'D';
                            break;
                        case 14:
                            symbol = 'E';
                            break;
                        case 15:
                            symbol = 'F';
                            break;
                    }
                }

                hexadecimalNumberString = symbol + hexadecimalNumberString;
            }

            Console.WriteLine(hexadecimalNumberString);
        }
    }
}
