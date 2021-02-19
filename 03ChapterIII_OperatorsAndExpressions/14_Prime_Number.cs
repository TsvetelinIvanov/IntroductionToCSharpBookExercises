using System;

namespace _14_Prime_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine(isPrime);
        }
    }
}
