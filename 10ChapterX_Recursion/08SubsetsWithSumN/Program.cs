using System;
using System.Collections.Generic;
using System.Linq;

namespace _08SubsetsWithSumN
{
    class Program
    {
        private static int[] numbers;
        private static int sumN;
        private static int[] usedNumbers;
        private static List<int[]> allSubsets;       

        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            sumN = int.Parse(Console.ReadLine());
            usedNumbers = new int[numbers.Length];
            allSubsets = new List<int[]>();
            for (int i = 1; i <= numbers.Length; i++)
            {
                int[] subset = new int[i];
                FindSubset(subset, 0);
            }

            List<int[]> subsets = RemoveDuplicates(allSubsets);
            if (subsets.Count > 0)
            {
                foreach (int[] subset in subsets)
                {
                    Console.WriteLine($"{sumN} = {string.Join(" + ", subset)}.");
                }
            }
            else
            {
                Console.WriteLine($"No subsets with sum {sumN} found.");
            }
            
        }

        static void FindSubset(int[] subset, int startIndex)
        {
            if (startIndex >= subset.Length)
            {
                if (subset.Sum() == sumN)
                {
                    int[] extractedSubset = new int[subset.Length];
                    Array.Copy(subset, extractedSubset, subset.Length);
                    Array.Sort(extractedSubset);
                    allSubsets.Add(extractedSubset);
                }

                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (usedNumbers[i] == 0)
                {
                    usedNumbers[i] = 1;
                    subset[startIndex] = numbers[i];
                    FindSubset(subset, startIndex + 1);
                    usedNumbers[i] = 0;
                }
            }
        }

        static List<int[]> RemoveDuplicates(List<int[]> inputList)
        {
            List<int[]> finalList = new List<int[]>();
            foreach (int[] current in inputList)
            {
                if (!Contains(finalList, current))
                {
                    finalList.Add(current);
                }
            }

            return finalList;
        }

        static bool Contains(List<int[]> list, int[] comparedValue)
        {
            foreach (int[] listValue in list)
            {
                if (listValue.SequenceEqual(comparedValue))
                {
                    return true;
                }
            }

            return false;
        }        
    }
}