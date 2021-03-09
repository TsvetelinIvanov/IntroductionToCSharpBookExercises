using System;

namespace _01Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Greet(name);
        }

        private static void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}