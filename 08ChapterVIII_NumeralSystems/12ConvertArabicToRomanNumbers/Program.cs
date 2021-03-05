using System;

namespace _12ConvertArabicToRomanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort[] arabicDigits = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] romanDigits = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            int arabicNumber = int.Parse(Console.ReadLine());
            if (arabicNumber <= 0 || arabicNumber > 3999)
            {
                Console.WriteLine("The used roman numbers are in range 1-3999!");
                return;
            }

            string romanNumber = String.Empty;
            int currentPosition = arabicDigits.Length;
            while ((arabicNumber > 0) && (currentPosition > 0))
            {
                while (arabicNumber >= arabicDigits[currentPosition - 1])
                {
                    string romanDigit = romanDigits[currentPosition - 1];
                    romanNumber += romanDigit;

                    ushort arabicDigit = arabicDigits[currentPosition - 1];
                    arabicNumber -= arabicDigit;
                }

                currentPosition--;
            }

            Console.WriteLine(romanNumber);
        }
    }
}