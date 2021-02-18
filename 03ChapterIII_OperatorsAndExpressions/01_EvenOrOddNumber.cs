using System;

namespace _01_EvenOrOddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((0 == n % 2) ? "Even" : "Odd");
        }
    }
}
