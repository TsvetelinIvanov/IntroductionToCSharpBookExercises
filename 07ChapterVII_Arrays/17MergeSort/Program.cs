using System;
using System.Collections.Generic;
using System.Linq;

namespace _17MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            array = MergeSort(array);

            Console.WriteLine(string.Join(" ", array));
        }
        
        static int[] MergeSort(int[] arrayToSort)
        {
            if (arrayToSort.Length <= 1)
            {
                return arrayToSort;
            }

            List<int> listToSort = arrayToSort.ToList();
            List<int> left = new List<int>();
            List<int> right = new List<int>();             

            int middle = listToSort.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(listToSort[i]);
            }

            for (int i = middle; i < listToSort.Count; i++)
            {
                right.Add(listToSort[i]);
            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();
            List<int> result = Merge(left, right);

            return result.ToArray();            
        }
        
        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] <= right[0])
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            return result;
        }
    }
}