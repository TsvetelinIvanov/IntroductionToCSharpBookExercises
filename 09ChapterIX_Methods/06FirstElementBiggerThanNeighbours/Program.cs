using System;
using System.Linq;

namespace _06FirstElementBiggerThanNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] array = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            int index = GetFirstBiggerThanNeighboursIndex(array);
            Console.WriteLine(index);
        }

        private static int GetFirstBiggerThanNeighboursIndex(decimal[] array)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i -1] && array[i] > array[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}