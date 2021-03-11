using System;
using System.Text;

namespace _05SubsetsOfWords
{
    class Program
    {
        private static StringBuilder subsetsBuilder = new StringBuilder("(), ");

        static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            FindSubsets(words);
            Console.WriteLine(subsetsBuilder.ToString().TrimEnd(',', ' '));
        }

        private static void FindSubsets(string[] words)
        {
            for (int i = 1; i <= words.Length; i++)
            {
                string[] subset = new string[i];
                FindSubset(words, subset, i, 0, 0);
            }
        }

        static void FindSubset(string[] words, string[] subset, int subsetElementsCount, int wordsStartIndex, int subsetIndex)
        {
            if (subsetIndex < subsetElementsCount)
            {
                for (int i = wordsStartIndex; i <= words.Length - subsetElementsCount + subsetIndex; i++)
                {
                    subset[subsetIndex] = words[i];
                    FindSubset(words, subset, subsetElementsCount, i + 1, subsetIndex + 1);
                }
            }
            else
            {
                ApendSubset(subset);
                return;
            }
        }

        static void ApendSubset(string[] subset)
        {
            subsetsBuilder.Append("(");
            for (int i = 0; i < subset.Length; i++)
            {
                subsetsBuilder.Append(subset[i]);
                if (i < subset.Length - 1)
                {
                    subsetsBuilder.Append(" ");
                }
            }

            subsetsBuilder.Append("), ");
        }
    }
}