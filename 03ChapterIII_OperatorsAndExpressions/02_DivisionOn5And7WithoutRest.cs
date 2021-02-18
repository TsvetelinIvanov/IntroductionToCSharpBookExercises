using System;

namespace _02_DivisionOn5And7WithoutRest
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((0 == n % 5) && (0 == n % 7));
        }
    }
}
