using System;
using System.Collections.Generic;
using System.Linq;

namespace _02IEnumerableExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Console.ReadLine().Split().Select(int.Parse);            
            if (numbers.Length() == 0)
            {
                Console.WriteLine("You must enter at least one number!");
                
                return;
            }

            int min = numbers.Min();
            int max = numbers.Max();
            decimal sum = numbers.Sum();            
            decimal product = numbers.Product();
            decimal average = numbers.Average();
            
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Product = {product}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
