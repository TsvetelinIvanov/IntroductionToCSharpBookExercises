using System;

namespace _08ConvertHexadecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexadecimalNumberString = Console.ReadLine();
            if (hexadecimalNumberString.StartsWith("0") && int.TryParse(hexadecimalNumberString, out int number) && number == 0)
            {
                Console.WriteLine("0000");
                
                return;
            }

            string binaryNumberString = String.Empty;
            for (int i = hexadecimalNumberString.Length - 1; i >= 0; i--)
            {
                char hexadecimalDigit = hexadecimalNumberString[i];
                byte decimalNumber = 0;
                if (char.IsNumber(hexadecimalDigit))
                {
                    decimalNumber = (byte)(hexadecimalDigit - '0');
                }
                else
                {
                    switch (hexadecimalDigit)
                    {
                        case 'A':
                            decimalNumber = 10;
                            break;
                        case 'B':
                            decimalNumber = 11;
                            break;
                        case 'C':
                            decimalNumber = 12;
                            break;
                        case 'D':
                            decimalNumber = 13;
                            break;
                        case 'E':
                            decimalNumber = 14;
                            break;
                        case 'F':
                            decimalNumber = 15;
                            break;
                    }
                }

                while (decimalNumber != 0)
                {
                    byte remainder = (byte)(decimalNumber % 2);
                    binaryNumberString = remainder + binaryNumberString;
                    decimalNumber = (byte)(decimalNumber / 2);
                }

                while (binaryNumberString.Length % 4 != 0)
                {
                    binaryNumberString = '0' + binaryNumberString;
                }
            }

            Console.WriteLine(binaryNumberString);
        }
    }
}
