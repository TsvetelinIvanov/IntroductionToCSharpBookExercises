using System;

namespace _11FindPath
{
    class Program
    {
        static char[,] labyrinth;
        static bool isPathExist;

        static void Main(string[] args)
        {
            ReadInput();
            FindStartLocation(out int x, out int y);
            isPathExist = false;
            FindPathToExit(x, y);
            Console.WriteLine(isPathExist);
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
                throw new ArgumentException("No starting location 's' found.");
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
                isPathExist = true;
            }

            if (labyrinth[row, col] != '.')
            {                
                return;
            }
            
            labyrinth[row, col] = 'v';
            
            if (!isPathExist)
            {                
                FindPathToExit(row - 1, col); // up
                FindPathToExit(row, col + 1); // right
                FindPathToExit(row + 1, col); // down
                FindPathToExit(row, col - 1); // left
            }
            
            labyrinth[row, col] = '.';
        }

        static bool IsInRange(int row, int col)
        {
            bool IsRowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool IsColInRange = col >= 0 && col < labyrinth.GetLength(1);
            
            return IsRowInRange && IsColInRange;
        }
    }
}
