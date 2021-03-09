using System;
using System.Linq;

namespace _04NumberCountInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            decimal[] array = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            int numberCount = CountNumber(array, number);
            Console.WriteLine(numberCount);
        }

        private static int CountNumber(decimal[] array, decimal number)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    count++;
                }
            }

            return count;
        }
    }
}