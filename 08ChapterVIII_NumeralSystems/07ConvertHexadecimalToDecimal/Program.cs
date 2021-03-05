using System;

namespace _07ConvertHexadecimalToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexadecimalNumberString = Console.ReadLine();
            int decimalNumber = 0;
            int grade = 0;

            for (int i = hexadecimalNumberString.Length - 1; i >= 0; i--)
            {
                char symbol = hexadecimalNumberString[i];
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
                            break;
                    }
                }

                double currentGrade = Math.Pow(16, grade);
                decimalNumber += (int)currentGrade * symbolValue;
                grade++;
            }

            Console.WriteLine(decimalNumber);
        }
    }
}