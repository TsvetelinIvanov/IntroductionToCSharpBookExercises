using System;

namespace _04SubsetsOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int elementsCombinationsCountK = int.Parse(Console.ReadLine());
            int[] combinations = new int[elementsCombinationsCountK];
            FindAndPrintCombinations(combinations, strings, 0, 0, strings.Length);            
        }

        private static void FindAndPrintCombinations(int[] combinations, string[] strings, int index, int start, int end)
        {
            if (index >= combinations.Length)
            {
                PrintCombinations(combinations, strings);                
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    combinations[index] = i;
                    FindAndPrintCombinations(combinations, strings, index + 1, i + 1, end);
                }
            }
        }

        private static void PrintCombinations(int[] combinations, string[] strings)
        {
            for (int i = 0; i < combinations.Length; i++)
            {
                if (i == combinations.Length - 1)
                {
                    Console.WriteLine(strings[combinations[i]]);
                    break;
                }

                Console.Write(strings[combinations[i]] + ", ");
            }            
        }
    }
}