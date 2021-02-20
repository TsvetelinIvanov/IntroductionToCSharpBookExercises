using System;

namespace _12IntegerToBase
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double toBase = double.Parse(Console.ReadLine());
            double numberToBase = DoNumberToBase(number, toBase);
            Console.WriteLine(numberToBase);
        }

        static double DoNumberToBase(double number, double toBase)
        {            
            string numberStringBase = string.Empty;
            int numberReminder = 0;
            while(number > 0)
            {
                numberReminder = (int)number % (int)toBase;
                number = (int)number / toBase;
                numberStringBase = numberReminder + numberStringBase;
            }
            double numberInBase = double.Parse(numberStringBase);

            return numberInBase;
        }
    }
}
