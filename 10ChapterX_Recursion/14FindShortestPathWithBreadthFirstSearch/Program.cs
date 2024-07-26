using System;
using System.Collections.Generic;

namespace _14FindShortestPathWithBreadthFirstSearch
{
    class Program
    {
        private static char[,] labyrinth;
        static Queue<Tuple<int, int>> cells = new Queue<Tuple<int, int>>();
        static Dictionary<Tuple<int, int>, Tuple<int, int>> cellsParentTree = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

        static void Main(string[] args)
        {
            ReadInput();
            char location = 's';
            FindLocation(location, out int x, out int y);
            cells.Enqueue(new Tuple<int, int>(x, y));
            BreadthFirstSearch();
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

        private static void FindLocation(char location, out int x, out int y)
        {
            x = -1;
            y = -1;
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == location)
                    {
                        x = row;
                        y = col;
                        labyrinth[row, col] = ' ';
                        
                        return;
                    }
                }
            }

            if (x == -1 || y == -1)
            {
                throw new ArgumentException("No starting location 's' found.");
            }
        }

        static void BreadthFirstSearch()
        {
            Tuple<int, int> cell = cells.Dequeue();

            if (labyrinth[cell.Item1, cell.Item2] == 'e')
            {
                CalculatePathLength();
                
                return;
            }
            
            labyrinth[cell.Item1, cell.Item2] = 's';

            if (IsInRange(cell.Item1 - 1, cell.Item2) && labyrinth[cell.Item1 - 1, cell.Item2] != '*' && labyrinth[cell.Item1 - 1, cell.Item2] != 's')
            {
                cells.Enqueue(new Tuple<int, int>(cell.Item1 - 1, cell.Item2));
            }

            if (IsInRange(cell.Item1, cell.Item2 + 1) && labyrinth[cell.Item1, cell.Item2 + 1] != '*' && labyrinth[cell.Item1, cell.Item2 + 1] != 's')
            {
                cells.Enqueue(new Tuple<int, int>(cell.Item1, cell.Item2 + 1));
            }

            if (IsInRange(cell.Item1 + 1, cell.Item2) && labyrinth[cell.Item1 + 1, cell.Item2] != '*' && labyrinth[cell.Item1 + 1, cell.Item2] != 's')
            {
                cells.Enqueue(new Tuple<int, int>(cell.Item1 + 1, cell.Item2));
            }

            if (IsInRange(cell.Item1, cell.Item2 - 1) && labyrinth[cell.Item1, cell.Item2 - 1] != '*' && labyrinth[cell.Item1, cell.Item2 - 1] != 's')
            {
                cells.Enqueue(new Tuple<int, int>(cell.Item1, cell.Item2 - 1));
            }

            if (cells.Count == 0)
            {
                Console.WriteLine("No");
                
                return;
            }

            foreach (Tuple<int, int> newCell in cells)
            {
                if (!cellsParentTree.ContainsKey(newCell))
                {
                    cellsParentTree.Add(newCell, cell);
                }
            }

            BreadthFirstSearch();
        }

        static void CalculatePathLength()
        {            
            char location = 'e';
            FindLocation(location, out int x, out int y);
            Tuple<int, int> cell = new Tuple<int, int>(x, y);
            int pathLength = 0;
            Tuple<int, int> parentCell = cellsParentTree[cell];
            while (cellsParentTree.ContainsKey(parentCell))
            {
                cell = parentCell;
                parentCell = cellsParentTree[cell];
                pathLength++;
            }

            pathLength++;
            Console.WriteLine(pathLength);
        }

        static bool IsInRange(int row, int col)
        {
            bool isRowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool isColInRange = col >= 0 && col < labyrinth.GetLength(1);
            
            return isRowInRange && isColInRange;
        }
    }
}
