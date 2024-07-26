using System;

namespace _06ConvertDecimalToHexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            if (decimalNumber == 0)
            {
                Console.WriteLine(decimalNumber);
                
                return;
            }

            bool isNegative = false;
            if (decimalNumber < 0)
            {
                decimalNumber = Math.Abs(decimalNumber);
                isNegative = true;
            }

            string hexadecimalNumberString = string.Empty;
            while (decimalNumber > 0)
            {
                char character = ' ';
                byte remainder = (byte)(decimalNumber % 16);
                if ((remainder >= 0) && (remainder <= 9))
                {
                    character = (char)(remainder + '0');
                }
                else
                {
                    switch (remainder)
                    {
                        case 10:
                            character = 'A';
                            break;
                        case 11:
                            character = 'B';
                            break;
                        case 12:
                            character = 'C';
                            break;
                        case 13:
                            character = 'D';
                            break;
                        case 14:
                            character = 'E';
                            break;
                        case 15:
                            character = 'F';
                            break;
                        default:
                            break;
                    }
                }

                hexadecimalNumberString = character + hexadecimalNumberString;
                decimalNumber /= 16;
            }

            if (isNegative)
            {
                hexadecimalNumberString = "-" + hexadecimalNumberString;
            }

            Console.WriteLine(hexadecimalNumberString);
        }
    }
}
