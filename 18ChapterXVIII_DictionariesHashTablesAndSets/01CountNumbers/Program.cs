using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            SortedDictionary<decimal, int> numbersCounts = new SortedDictionary<decimal, int>();
            foreach (decimal number in numbers)
            {
                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts.Add(number, 0);
                }

                numbersCounts[number]++;
            }

            foreach (KeyValuePair<decimal, int> numberCount in numbersCounts)
            {
                Console.WriteLine($"{numberCount.Key} -> {numberCount.Value} times");
            }
        }
    }
}