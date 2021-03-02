using System;

namespace _08SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersLength = int.Parse(Console.ReadLine());
            int[] numbers = new int[numbersLength];
            for (int i = 0; i < numbersLength; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int minIndex;
            for (int i = 0; i < numbersLength; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < numbersLength; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = numbers[i];
                numbers[i] = numbers[minIndex];
                numbers[minIndex] = temp;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}