using System;
using System.Linq;
using System.Collections.Generic;

namespace _04LongestSequenceEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> equalNumbers = FindLongestSequenceEqualNumbers(numbers);
            Console.WriteLine(string.Join(", ", equalNumbers));

            LongestSequenceEqualNumbersTest numbersTest = new LongestSequenceEqualNumbersTest();
            Console.WriteLine(numbersTest.TestFindLongestSequenceEqualNumbers());
        }

        public static List<int> FindLongestSequenceEqualNumbers(List<int> numbers)
        {
            int number = numbers[0];
            int longestCount = 1;
            int count = 1;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count > longestCount)
                {
                    longestCount = count;
                    number = numbers[i];
                }
            }

            List<int> equalNumbers = new List<int>();
            for (int i = 0; i < longestCount; i++)
            {
                equalNumbers.Add(number);
            }

            return equalNumbers;
        }
    }
}