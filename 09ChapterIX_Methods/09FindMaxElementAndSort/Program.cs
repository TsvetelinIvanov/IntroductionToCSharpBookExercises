using System;
using System.Linq;

namespace _09FindMaxElementAndSort
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] array = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            SortArray(array);
            Console.WriteLine(string.Join(", ", array));
        }

        private static void SortArray(decimal[] array)
        {            
            for (int i = 0; i < array.Length; i++)
            {
                decimal maxElement = GetMaxElement(array, i, array.Length - 1);
                int maxElementIndex = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == maxElement)
                    {
                        maxElementIndex = j;
                    }
                }

                decimal temp = array[i];
                array[i] = array[maxElementIndex];
                array[maxElementIndex] = temp;
            }
        }

        private static decimal GetMaxElement(decimal[] array, int startIndex, int endIndex)
        {
            decimal maxElement = array[startIndex];
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }        
    }
}