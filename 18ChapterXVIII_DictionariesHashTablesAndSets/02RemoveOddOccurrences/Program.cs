using System;
using System.Collections.Generic;
using System.Linq;

namespace _02RemoveOddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            Dictionary<decimal, int> numbersCounts = new Dictionary<decimal, int>();
            foreach (decimal number in numbers)
            {
                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts.Add(number, 0);
                }

                numbersCounts[number]++;
            }

            Console.WriteLine("{" + string.Join(", ", numbers.Where(n => numbersCounts[n] % 2 == 0)) + "}");
        }
    }
}