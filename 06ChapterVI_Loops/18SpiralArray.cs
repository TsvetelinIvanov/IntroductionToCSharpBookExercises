using System;

namespace _18SpiralArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] spiralArray = new int[size, size];
            int start = 0;
            int end = size;
            int number = 1;

            while (end - start >= 1)
            {
                for (int i = start; i < end; i++)
                {
                    spiralArray[start, i] = number;
                    number++;
                }

                for (int i = start + 1; i < end; i++)
                {
                    spiralArray[i, end - 1] = number;
                    number++;
                }

                for (int i = end - 2; i >= start; i--)
                {
                    spiralArray[end - 1, i] = number;
                    number++;
                }

                for (int i = end - 2; i >= start + 1; i--)
                {
                    spiralArray[i, start] = number;
                    number++;
                }

                start++;
                end--;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j == size - 1)
                    {
                        Console.Write(spiralArray[i, j]);
                    }
                    else
                    {
                        Console.Write(spiralArray[i, j] + "\t");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
