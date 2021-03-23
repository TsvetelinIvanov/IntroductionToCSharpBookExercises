using System;
using System.Collections.Generic;
using System.Linq;

namespace _05RemoveNegativeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
            List<double> positiveNumbers = new List<double>();
            foreach (double number in numbers)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }

            Console.WriteLine("{" + string.Join(", ", positiveNumbers) + "}");
        }
    }
}