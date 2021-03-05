using System;
using System.Numerics;

namespace _13ConvertNumberBaseSToBaseDNotations
{
    class Program
    {
        static void Main(string[] args)
        {
            byte baseS = byte.Parse(Console.ReadLine());
            byte baseD = byte.Parse(Console.ReadLine());

            string numberInBaseS = Console.ReadLine().ToUpper();
            string reversedNumberInBaseS = null;
            for (int i = 0; i < numberInBaseS.Length; i++)
            {
                reversedNumberInBaseS = numberInBaseS[i] + reversedNumberInBaseS;
            }

            // Convert from numeral system S to Decimal numeral system:
            BigInteger decimalNumber = 0;
            for (int i = 0; i < reversedNumberInBaseS.Length; i++)
            {
                byte multiplier = 0;
                if (char.IsNumber(reversedNumberInBaseS[i]))
                {
                    multiplier = (byte)(reversedNumberInBaseS[i] - '0');
                }
                else
                {
                    char character = reversedNumberInBaseS[i];
                    switch (character)
                    {
                        case 'A':
                            multiplier = 10;
                            break;
                        case 'B':
                            multiplier = 11;
                            break;
                        case 'C':
                            multiplier = 12;
                            break;
                        case 'D':
                            multiplier = 13;
                            break;
                        case 'E':
                            multiplier = 14;
                            break;
                        case 'F':
                            multiplier = 15;
                            break;
                    }
                }

                decimalNumber += multiplier * (BigInteger)Math.Pow(baseS, i);
            }

            // Convert from Decimal numeral system to numeral system D:
            string numberInBaseD = string.Empty;
            do
            {
                char character = ' ';
                byte remainder = (byte)(decimalNumber % baseD);
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
                    }
                }

                numberInBaseD = character + numberInBaseD;
                decimalNumber /= baseD;
            }
            while (decimalNumber > 0);

            Console.WriteLine(numberInBaseD);
        }
    }
}