using System;
using System.Linq;

namespace _25Combinations
{
    class Program
    {        
        static void Main(string[] args)
        {
            int endNumberN = int.Parse(Console.ReadLine());
            int elementsCountK = int.Parse(Console.ReadLine());

            int[] array = new int[elementsCountK];

            PrintCombinations(array, 0, endNumberN);
        }

        static void PrintCombinations(int[] array, int startNumber, int endNumber)
        {
            if (startNumber == array.Length)
            {
                PrintArray(array);
                return;
            }

            for (int i = 1; i <= endNumber; i++)
            {
                array[startNumber] = i;
                PrintCombinations(array, startNumber + 1, endNumber);
            }
        }

        private static void PrintArray(int[] array)
        {
            if (CheckAscending(array))
            {
                Console.WriteLine(string.Join(", ", array));
            }
        }

        private static bool CheckAscending(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] >= array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}