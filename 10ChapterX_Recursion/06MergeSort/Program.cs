using System;
using System.Linq;
using System.Collections.Generic;

namespace _06MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> sortedNumbers = MergeSort(numbers);
            PrintNumbers(sortedNumbers);
        }        

        static List<int> MergeSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();            
            int middle = numbers.Count / 2;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < middle)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            left = MergeSort(left);
            right = MergeSort(right);
            List<int> result = Merge(left, right);

            return result;
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

        static void PrintNumbers(List<int> numbers)
        {
            Console.Write("{ ");
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                Console.Write($"{numbers[i]}, ");
            }

            Console.Write($"{numbers[numbers.Count - 1]} ");
            Console.WriteLine("}");
        }
    }
}