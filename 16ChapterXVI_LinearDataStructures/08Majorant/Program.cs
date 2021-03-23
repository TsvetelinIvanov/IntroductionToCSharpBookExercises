using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Majorant
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse).ToArray();
            Dictionary<double, int> numbersCounts = new Dictionary<double, int>();
            foreach (double number in numbers)
            {
                if (!numbersCounts.ContainsKey(number))
                {
                    numbersCounts.Add(number, 0);
                }

                numbersCounts[number]++;
            }

            KeyValuePair<double, int> majorant = numbersCounts.FirstOrDefault(nc => nc.Value >= numbers.Length / 2 + 1);
            if (majorant.Value > 0)
            {
                Console.WriteLine("The majorant is " + majorant.Key);
            }
            else
            {
                Console.WriteLine("The majorant does not exist!");
            }
        }
    }
}