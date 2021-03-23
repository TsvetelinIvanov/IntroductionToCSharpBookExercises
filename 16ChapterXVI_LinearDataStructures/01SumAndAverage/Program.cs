using System;
using System.Linq;
using System.Collections.Generic;

namespace _01SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string input;
            while ((input = Console.ReadLine()) != string.Empty)
            {
                numbers.Add(int.Parse(input));
            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Sum());
                Console.WriteLine(numbers.Average());
            }
            else
            {
                Console.WriteLine("The sequence contains no elements!");
            }
        }
    }
}