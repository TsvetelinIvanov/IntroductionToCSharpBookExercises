using System;

namespace _02ProductSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double product = a * b * c;
            if (product > 0)
            {
                Console.WriteLine("The symbol is positive \"+\".");
            }
            else if (product < 0)
            {
                Console.WriteLine("The symbol is negative \"-\".");
            }
            else
            {
                Console.WriteLine("The symbol is neutral \"0\".");
            }
        }
    }
}
