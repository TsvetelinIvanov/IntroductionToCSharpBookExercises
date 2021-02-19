using System;

namespace _06MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine()); // or decimal a = decimal.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine()); // or decimal b = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(a, b));//or Console.WriteLine((a + b + Math.Abs(a - b)) / 2); or Console.WriteLine(a - ((a - b) & ((a - b) >> 31)));
            //Console.WriteLine(Math.Min(a, b)); or Console.WriteLine((a + b - Math.Abs(a - b)) / 2);
        }
    }
}
