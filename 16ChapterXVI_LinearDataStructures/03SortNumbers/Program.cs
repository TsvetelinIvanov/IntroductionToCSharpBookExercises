using System;
using System.Collections.Generic;

namespace _03SortNumbers
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

            numbers.Sort();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}