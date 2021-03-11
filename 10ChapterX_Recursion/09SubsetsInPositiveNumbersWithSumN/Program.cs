using System;
using System.Collections.Generic;
using System.Linq;

namespace _09SubsetsInPositiveNumbersWithSumN
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumToFindN = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int subsetCombinationsCount = (int)Math.Pow(2, numbers.Length);
            int currentSum = 0;
            bool isSubsetSumFound = false;
            List<int> currentSubset = new List<int>();
            for (int i = 0; i < subsetCombinationsCount; i++)
            {
                currentSum = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    currentSum += (numbers[j] * FindDigitOnPosition(i, j));
                    currentSubset.Add(numbers[j] * FindDigitOnPosition(i, j));
                }

                if (currentSum == sumToFindN)
                {
                    isSubsetSumFound = true;
                    Console.WriteLine(string.Join(" ", currentSubset.Where(n => n != 0)));
                    break;
                }

                currentSubset.Clear();
            }

            if (!isSubsetSumFound)
            {
                Console.WriteLine("No");
            }
        }

        static int FindDigitOnPosition(int number, int position)
        {
            int mask = 1;
            mask <<= position;
            mask &= number;
            if (mask != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}