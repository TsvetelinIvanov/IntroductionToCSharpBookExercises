using System;
using System.Collections.Generic;

namespace _27AreaFromEqualElements
{
    class Program
    {
        private static int[,] matrix;
        private static readonly List<Tuple<Cell, int>> areas = new List<Tuple<Cell, int>>();
        private static bool[,] visitedCells;

        struct Cell
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Value { get; set; }
        }

        static void Main(string[] args)
        {
            ProcessInput();

            visitedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            
            FindLargestArea(out int maxElement, out int maxAreaLength);

            Console.WriteLine($"Largest area: element = {maxElement}; length = {maxAreaLength}");
        }

        private static void ProcessInput()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());
            matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {                
                string[] rowElements = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(rowElements[col]);
                }
            }
        }

        private static void FindLargestArea(out int maxElement, out int maxAreaLength)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visitedCells[row, col])
                    {
                        Cell cell = new Cell
                        {
                            Row = row,
                            Col = col,
                            Value = matrix[row, col]
                        };

                        DoDepthFirstSearch(cell);
                    }
                }
            }

            maxAreaLength = 0;
            maxElement = int.MinValue;
            foreach (Tuple<Cell, int> cellAndCount in areas)
            {
                int currentAreaLength = cellAndCount.Item2;
                if (currentAreaLength > maxAreaLength)
                {
                    maxElement = cellAndCount.Item1.Value;
                    maxAreaLength = currentAreaLength;                    
                }
            }
        }

        private static void DoDepthFirstSearch(Cell startCell)
        {
            Stack<Cell> cells = new Stack<Cell>();
            cells.Push(startCell);
            visitedCells[startCell.Row, startCell.Col] = true;
            int areaLength = 0;
            while (cells.Count > 0)
            {
                Cell currentCell = cells.Pop();
                areaLength++;
                List<Cell> neighbours = GetNeighbours(currentCell.Row, currentCell.Col, currentCell.Value);
                foreach (Cell neighbour in neighbours)
                {
                    if (!visitedCells[neighbour.Row, neighbour.Col])
                    {
                        cells.Push(neighbour);
                        visitedCells[neighbour.Row, neighbour.Col] = true;
                    }
                }
            }

            areas.Add(new Tuple<Cell, int>(startCell, areaLength));
        }

        private static List<Cell> GetNeighbours(int row, int col, int value)
        {
            List<Cell> neighbours = new List<Cell>();

            if (IsInMatrix(row - 1, col) && (matrix[row - 1, col] == value))
            {
                Cell neighbour = new Cell
                {
                    Row = row - 1,
                    Col = col,
                    Value = value
                };

                neighbours.Add(neighbour);
            }

            if (IsInMatrix(row, col + 1) && (matrix[row, col + 1] == value))
            {
                Cell neighbour = new Cell
                {
                    Row = row,
                    Col = col + 1,
                    Value = value
                };

                neighbours.Add(neighbour);
            }

            if (IsInMatrix(row + 1, col) && (matrix[row + 1, col] == value))
            {
                Cell neighbour = new Cell
                {
                    Row = row + 1,
                    Col = col,
                    Value = value
                };

                neighbours.Add(neighbour);
            }

            if (IsInMatrix(row, col - 1) && (matrix[row, col - 1] == value))
            {
                Cell neighbour = new Cell
                {
                    Row = row,
                    Col = col - 1,
                    Value = value
                };

                neighbours.Add(neighbour);
            }           

            return neighbours;
        }

        private static bool IsInMatrix(int row, int col)
        {
            bool isInRow = row >= 0 && row < matrix.GetLength(0);
            bool isInCol = col >= 0 && col < matrix.GetLength(1);

            return isInRow && isInCol;
        }        
    }
}