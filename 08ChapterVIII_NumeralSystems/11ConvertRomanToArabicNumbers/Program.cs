using System;

namespace _11ConvertRomanToArabicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string romanNumber = Console.ReadLine();
            int arabicNumber = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                switch (romanNumber[i])
                {
                    case 'M':
                        arabicNumber += 1000;
                        break;
                    case 'D':
                        arabicNumber += 500;
                        break;
                    case 'C':
                        if (((i + 1) < romanNumber.Length) &&
                            ((romanNumber[i + 1] == 'D') ||
                            (romanNumber[i + 1] == 'M')))
                        {
                            arabicNumber -= 100;
                        }
                        else
                        {
                            arabicNumber += 100;
                        }

                        break;
                    case 'L':
                        arabicNumber += 50;
                        break;
                    case 'X':
                        if (((i + 1) < romanNumber.Length) &&
                            ((romanNumber[i + 1] == 'L') ||
                            (romanNumber[i + 1] == 'C')))
                        {
                            arabicNumber -= 10;
                        }
                        else
                        {
                            arabicNumber += 10;
                        }

                        break;
                    case 'V':
                        arabicNumber += 5;
                        break;
                    case 'I':
                        if (((i + 1) < romanNumber.Length) &&
                            ((romanNumber[i + 1] == 'V') ||
                            (romanNumber[i + 1] == 'X')))
                        {
                            arabicNumber -= 1;
                        }
                        else
                        {
                            arabicNumber += 1;
                        }

                        break;
                    default:
                        Console.WriteLine("{0} is wrong roman symbol", romanNumber[i]);
                        break;
                }
            }

            Console.WriteLine("{0} -> {1}", romanNumber, arabicNumber);
        }
    }
}