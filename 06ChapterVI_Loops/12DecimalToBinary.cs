using System;

namespace _12DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Base = 2;
            int number = int.Parse(Console.ReadLine());
            
            if (number == 0)
            {
                Console.WriteLine(0);
                
                return;
            }

            string numberToBaseString = string.Empty;
            while (number > 0)
            {
                numberToBaseString = number % Base + numberToBaseString;
                number /= Base;
            }
            
            Console.WriteLine(numberToBaseString);
        }
    }
}
