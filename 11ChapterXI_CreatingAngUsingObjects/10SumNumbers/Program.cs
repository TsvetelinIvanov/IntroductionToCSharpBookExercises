using System;
using System.Linq;

namespace _10SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum());
        }
    }
}