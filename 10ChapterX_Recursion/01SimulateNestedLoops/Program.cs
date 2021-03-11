using System;

namespace _01SimulateNestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int loopsCount = int.Parse(Console.ReadLine());
            if (loopsCount < 1)
            {
                throw new ArgumentException("Number of loops should be 1 or higher.");
            }

            int[] numbers = new int[loopsCount];
            PrintNumbers(numbers, 0);
        }

        private static void PrintNumbers(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                foreach (int number in numbers)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
                return;
            }

            for (int i = 1; i <= numbers.Length; i++)
            {
                numbers[index] = i;
                PrintNumbers(numbers, index + 1);
            }
        }
    }
}