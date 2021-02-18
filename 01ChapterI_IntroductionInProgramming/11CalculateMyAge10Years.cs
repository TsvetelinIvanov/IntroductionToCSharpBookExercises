using System;

namespace _11CalculateMyAge10Years
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your year of birth!");
            int birthYear = int.Parse(Console.ReadLine());
            int yearsAfter10 = (DateTime.Now.Year + 10) - birthYear;
            Console.WriteLine("After one decade you will be {0} years old!", yearsAfter10);
        }
    }
}
