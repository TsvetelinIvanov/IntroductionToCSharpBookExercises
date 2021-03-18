using System;

namespace _07StringFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            if (str.Length > 20)
            {
                Console.WriteLine("The length of the string should be less or equal to 20!");
            }
            else
            {
                Console.WriteLine($"{str.PadRight(20, '*')}");
            }
        }
    }
}