using System;
using System.Collections.Generic;
using System.Linq;

namespace _06RemoveOddOccurrences
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

            List<double> evenOccurrencesNumbers = new List<double>();
            foreach (double number in numbers)
            {
                if (numbersCounts[number] % 2 == 0)
                {
                    evenOccurrencesNumbers.Add(number);
                }
            }

            Console.WriteLine("{" + string.Join(", ", evenOccurrencesNumbers) + "}");
        }
    }
}