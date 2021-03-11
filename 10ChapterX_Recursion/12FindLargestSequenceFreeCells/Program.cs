using System;

namespace _12FindLargestSequenceFreeCells
{
    class Program
    {
        private static char[,] labyrinth;
        private static int maxCount = 0;
        private static int currentCount = 0;

        static void Main(string[] args)
        {
            ReadInput();

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] != '.')
                    {
                        continue;
                    }

                    currentCount = 0;
                    FindAllPaths(row, col);
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
            }

            Console.WriteLine("The largest connected area is: " + maxCount);
        }

        private static void ReadInput()
        {
            string[] dimensions = Console.ReadLine().Split();
            int rowsCount = int.Parse(dimensions[0]);
            int colsCount = int.Parse(dimensions[1]);
            labyrinth = new char[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                string rowValues = Console.ReadLine();
                for (int col = 0; col < colsCount; col++)
                {
                    labyrinth[row, col] = rowValues[col];
                }
            }
        }

        static void FindAllPaths(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] == '.')
            {
                labyrinth[row, col] = 'v';
                currentCount++;
                FindAllPaths(row - 1, col);
                FindAllPaths(row, col + 1);
                FindAllPaths(row + 1, col);
                FindAllPaths(row, col - 1);                
            }
        }
    }
}