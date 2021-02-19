using System;

namespace _14PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int divider = 2;
            int maxDivider = (int)Math.Sqrt(n);
            bool prime = true;
            while (prime && (divider <= maxDivider))
            {
                if (n % divider == 0)
                {
                    prime = false;
                }
                divider++;
            }
            
            Console.WriteLine("Prime? " + prime);
        }
    }
}
