using System;
using System.Linq;

namespace _23Permutation
{
    class Program
    {
        static void Main(string[] args)
        {

            int endNumberN = int.Parse(Console.ReadLine());

            int[] array = new int[endNumberN];

            PrintPermutations(array, 0, endNumberN);
        }

        static void PrintPermutations(int[] array, int startNumber, int endNumber)
        {
            if (startNumber == array.Length)
            {
                if (array.Length == array.Distinct().Count())
                {
                    Console.WriteLine(string.Join(", ", array));
                }

                return;
            }

            for (int i = 1; i <= endNumber; i++)
            {
                array[startNumber] = i;
                PrintPermutations(array, startNumber + 1, endNumber);
            }
        }
    }
}