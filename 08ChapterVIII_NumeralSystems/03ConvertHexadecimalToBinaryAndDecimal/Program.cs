using System;
using System.Text;

namespace _03ConvertHexadecimalToBinaryAndDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexadecimalString = Console.ReadLine();

            //Hexadecimal to Decimal
            int decimalNumber = 0;
            int grade = 0;
            for (int i = hexadecimalString.Length - 1; i >= 0; i--)
            {
                char symbol = hexadecimalString[i];
                int symbolValue = 0;
                if (char.IsNumber(symbol))
                {
                    symbolValue = symbol - '0';
                }
                else
                {
                    switch (symbol)
                    {
                        case 'A':
                            symbolValue = 10;
                            break;
                        case 'B':
                            symbolValue = 11;
                            break;
                        case 'C':
                            symbolValue = 12;
                            break;
                        case 'D':
                            symbolValue = 13;
                            break;
                        case 'E':
                            symbolValue = 14;
                            break;
                        case 'F':
                            symbolValue = 15;
                            break;
                        default:
                            Console.WriteLine("{0} is invalid hex symbol", symbol);
                            break;
                    }
                }

                double currentGrade = Math.Pow(16, grade);
                decimalNumber += (int)currentGrade * symbolValue;
                grade++;
            }

            Console.WriteLine(decimalNumber);

            //Decimal to Binary
            StringBuilder binaryBuilder = new StringBuilder();
            do
            {
                int remainder = decimalNumber % 2;
                decimalNumber /= 2;
                binaryBuilder.Append(remainder);
            } while (decimalNumber > 0);

            StringBuilder binaryBuilderReversed = new StringBuilder();
            for (int i = binaryBuilder.Length - 1; i >= 0; i--)
            {
                binaryBuilderReversed.Append(binaryBuilder[i]);
            }

            Console.WriteLine(binaryBuilderReversed);
        }
    }
}