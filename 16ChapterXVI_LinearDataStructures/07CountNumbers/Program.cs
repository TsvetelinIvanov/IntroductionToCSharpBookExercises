using System;
using System.Collections.Generic;
using System.Linq;

namespace _07CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            Dictionary<int, int> numbersCounts = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts.Add(number, 0);
                }

                numbersCounts[number]++;
            }

            foreach (KeyValuePair<int, int> numberCount in numbersCounts.OrderBy(nc => nc.Key))
            {
                Console.WriteLine($"{numberCount.Key} -> {numberCount.Value} times");
            }
        }
    }
}