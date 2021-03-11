using System;
using System.Collections.Generic;

namespace _10FindAllPaths
{
    class Program
    {
        private static char[,] labyrinth;
        private static List<int[]> path = new List<int[]>();

        static void Main(string[] args)
        {
            ReadInput();
            FindStartLocation(out int x, out int y);
            FindPathToExit(x, y);
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

        private static void FindStartLocation(out int x, out int y)
        {
            x = -1;
            y = -1;
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == 's')
                    {
                        x = row;
                        y = col;
                        labyrinth[row, col] = '.';
                        return;
                    }
                }
            }

            if (x == -1 || y == -1)
            {
                throw new ArgumentException("No starting location 's' found!");
            }
        }

        static void FindPathToExit(int row, int col)
        {
            if (!IsInRange(row, col))
            {                
                return;
            }
            
            if (labyrinth[row, col] == 'e')
            {
                int pathLength = path.Count + 1;
                Console.WriteLine(pathLength);
                PrintPath(row, col);
            }

            if (labyrinth[row, col] != '.')
            {                
                return;
            }
            
            labyrinth[row, col] = 'v';
            path.Add(new int[] { row, col });

            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down
            FindPathToExit(row, col - 1); // left
            
            labyrinth[row, col] = '.';
            path.RemoveAt(path.Count - 1);
        }

        static bool IsInRange(int row, int col)
        {
            bool isRowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool isColInRange = col >= 0 && col < labyrinth.GetLength(1);
            return isRowInRange && isColInRange;
        }

        static void PrintPath(int finalRow, int finalCol)
        {
            bool isFilledCell = false;
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    foreach (int[] cell in path)
                    {
                        if (row == cell[0] && col == cell[1])
                        {
                            Console.Write("r");
                            isFilledCell = true;
                        }
                    }

                    if (!isFilledCell)
                    {
                        if (labyrinth[row, col] != '.')
                        {
                            Console.Write(labyrinth[row, col]);
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }

                    isFilledCell = false;
                }

                Console.WriteLine();
            }
        }
    }
}