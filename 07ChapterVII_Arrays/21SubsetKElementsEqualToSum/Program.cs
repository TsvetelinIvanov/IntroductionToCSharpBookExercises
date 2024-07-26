using System;

namespace _21SubsetKElementsEqualToSum
{
    class Program
    {
        private static bool haveSubset = false;

        static void Main(string[] args)
        {
            int numbersLengthN = int.Parse(Console.ReadLine());
            if (numbersLengthN > 20)
            {
                Console.WriteLine("Invalid input! The count of numbers must not be bigger than 20.");
                
                return;
            }

            int subsetLengthK = int.Parse(Console.ReadLine());
            int expectedSumS = int.Parse(Console.ReadLine());
            int[] numbers = new int[numbersLengthN];
            for (int i = 0; i < numbersLengthN; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            
            int[] subset = new int[subsetLengthK];
            for (int i = 1; i <= numbers.Length; i++)
            {
                FindSubset(numbers, subset, expectedSumS, 0, 0, subsetLengthK);
                if (haveSubset)
                {
                    break;
                }
            }

            if (!haveSubset)
            {
                Console.WriteLine("No subset with sum {0} found.", expectedSumS);
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
