using System;
using System.Linq;

namespace _05LongestIncreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int maxCount = 1;
            int counter = 1;
            int index = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > maxCount)
                {
                    maxCount = counter;
                    index = i + 1;
                }
            }

            for (int i = index + 1 - maxCount; i <= index; i++)
            {
                if (i == index)
                {
                    Console.WriteLine(array[i]);
                    break;
                }

                Console.Write(array[i] + ", ");
            }
        }
    }
}