using System;

namespace _03NameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string lastDigitName = GetLastDigitName(number);
            Console.WriteLine(lastDigitName);
        }

        private static string GetLastDigitName(int number)
        {
            int lastDigit = number % 10;
            string[] digitNames = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            return digitNames[lastDigit];
        }
    }
}