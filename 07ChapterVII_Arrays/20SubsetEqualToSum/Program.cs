using System;
using System.Linq;

namespace _20SubsetEqualToSum//It finds the shortest subset, not the first!
{
    class Program
    {
        private static bool haveSubset = false;

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            if (numbers.Length > 20)
            {
                Console.WriteLine("Invalid input! The count of numbers must not be bigger than 20.");
                
                return;
            }

            int expectedSum = int.Parse(Console.ReadLine());
            int[] subset = new int[numbers.Length];
            for (int i = 1; i <= numbers.Length; i++)
            {
                FindSubset(numbers, subset, expectedSum, 0, 0, i);
                if (haveSubset)
                {
                    break;
                }
            }

            if (!haveSubset)
            {
                Console.WriteLine("No subset with sum {0} found.", expectedSum);
            }
        }

        private static void FindSubset(int[] numbers, int[] subset, int expectedSum, int endIndex, int startIndex, int subsetLength)
        {
            if (endIndex == subsetLength)
            {
                CheckSubsets(subset, expectedSum, subsetLength);
                
                return;
            }

            for (int i = startIndex; i < numbers.Length; i++)
            {
                subset[endIndex] = numbers[i];
                FindSubset(numbers, subset, expectedSum, endIndex + 1, i + 1, subsetLength);
            }
        }

        private static void CheckSubsets(int[] subset, int expectedSum, int subsetLength)
        {
            int sum = 0;
            for (int i = 0; i < subsetLength; i++)
            {
                sum += subset[i];
            }

            if (sum == expectedSum)
            {
                Console.Write("Yes (");
                for (int i = 0; i < subsetLength; i++)
                {
                    if (i == subsetLength - 1)
                    {
                        Console.WriteLine($"{subset[i]}) = {expectedSum}");
                        break;
                    }

                    Console.Write(subset[i] + " + ");
                }

                haveSubset = true;
            }
        }
    }
}
