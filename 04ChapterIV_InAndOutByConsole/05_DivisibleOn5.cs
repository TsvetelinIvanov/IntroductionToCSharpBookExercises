using System;

namespace _05_DivisibleOn5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int divisiblesCount = b / 5 - a / 5;
            if (a % 5 == 0)
            {
                divisiblesCount++;
            }
            Console.WriteLine(divisiblesCount);
        }
    }
}
