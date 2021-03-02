using System;
using System.Linq;

namespace _09SubsequenceMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int maxSum = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    int currentSum = 0;
            //    for (int j = i; j < numbers.Length; j++)
            //    {
            //        currentSum += numbers[j];
            //        if (currentSum > maxSum)
            //        {
            //            maxSum = currentSum;
            //        }
            //    }
            //}
            int currentSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                else if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}