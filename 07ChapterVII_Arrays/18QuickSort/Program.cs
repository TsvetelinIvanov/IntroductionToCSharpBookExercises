using System;
using System.Linq;

namespace _18QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void QuickSort(int[] array, int left, int right)
        {            
            int i = left; 
            int j = right;
            IComparable pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }

        }
    }
}