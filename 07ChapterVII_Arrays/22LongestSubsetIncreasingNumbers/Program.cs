using System;
using System.Linq;

namespace _22LongestSubsetIncreasingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] increasingNumbers = FindLongestSubsetIncreasingNumbers(numbers);
            Console.WriteLine(string.Join(", ", increasingNumbers));
        }

        static int[] FindLongestSubsetIncreasingNumbers(int[] array)
        {
            int[] lengths = new int[array.Length];
            lengths[0] = 1;
            for (int i = 1; i < lengths.Length; i++)
            {
                int maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i] && lengths[j] > maxLength)
                    {
                        maxLength = lengths[j];
                    }
                }

                lengths[i] = maxLength + 1;
            }

            int[] sortedSubset = new int[lengths.Max()];
            int serialNumber = lengths.Max();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (serialNumber == lengths[i])
                {
                    sortedSubset[serialNumber - 1] = array[i];
                    serialNumber--;
                }
            }

            return sortedSubset;
        }
    }
}