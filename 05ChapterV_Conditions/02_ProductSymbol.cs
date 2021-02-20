using System;

namespace _02_ProductSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine("The symbol is neutral \"0\".");

            }
            else if ((a < 0 && b < 0 && c < 0) || (a < 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c > 0) || (a > 0 && b > 0 && c < 0))
            {
                Console.WriteLine("The symbol is negative \"-\".");
            }
            else
            {
                Console.WriteLine("The symbol is positive \"+\".");
            }
        }
    }
}
