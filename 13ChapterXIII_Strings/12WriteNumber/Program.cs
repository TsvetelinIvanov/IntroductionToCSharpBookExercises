using System;
using System.Threading;

namespace _12WriteNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg-BG");
            int number = int.Parse(Console.ReadLine());
            // decimal
            Console.WriteLine("{0,15:D}", number);
            // hexadecimal
            Console.WriteLine("{0,15:X}", number);
            // percent
            Console.WriteLine("{0,15:P}", number);
            // currency
            Console.WriteLine("{0,15:C}", number);
            // scientific notation
            Console.WriteLine("{0,15:E}", number);
        }
    }
}