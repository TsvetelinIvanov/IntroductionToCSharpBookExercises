using System;

namespace _01LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            bool isLeapYear = DateTime.IsLeapYear(year);
            Console.WriteLine(isLeapYear);
        }
    }
}