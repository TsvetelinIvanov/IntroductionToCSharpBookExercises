using System;
using System.Linq;

namespace _05CheckNeighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());
            decimal[] array = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            CheckNeighbours(array, index);
        }

        private static void CheckNeighbours(decimal[] array, int index)
        {
            if (index < 0 || index >= array.Length)
            {
                Console.WriteLine($"The index {index} is not in array!");
            }
            else if (array.Length == 1)
            {
                Console.WriteLine("No neighbours!");
            }
            else if (index == 0)
            {
                Console.WriteLine($"{array[index]} {CheckNeighbour(array[index], array[index + 1])} {array[index + 1]}");
            }
            else if (index == array.Length - 1)
            {
                Console.WriteLine($"{array[index - 1]} {CheckNeighbour(array[index - 1], array[index])} {array[index]}");
            }
            else
            {
                Console.WriteLine($"{array[index - 1]} {CheckNeighbour(array[index - 1], array[index])} {array[index]} {CheckNeighbour(array[index], array[index + 1])} {array[index + 1]}");
            }
        }

        private static string CheckNeighbour(decimal first, decimal second)
        {
            if (first > second)
            {
                return ">";
            }
            else if (first < second)
            {
                return "<";
            }
            else
            {
                return "=";
            }
        }
    }
}