using System;

namespace _07ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintReverseNumber(number);
        }

        private static void PrintReverseNumber(int number)
        {            
            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else if (number < 0)
            {
                number = Math.Abs(number);
                Console.Write("-");
            }

            while (number > 0)
            {                
                Console.Write(number % 10);
                number /= 10;
            }

            Console.WriteLine();
        }
    }
}