using System;

namespace _03DecimalVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Math.Round(a, 6)); // for 0.000001 && 0.1.
            //or Console.WriteLine("{0:f6}", a); for 0.000001 && 0.100000.
        }
    }
}
