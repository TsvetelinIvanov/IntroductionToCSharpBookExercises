using System;

namespace _26PrintMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = DoMatrixA(size);
            PrintMatrix(matrix);
            Console.WriteLine();
            matrix = DoMatrixB(size);
            PrintMatrix(matrix);
        }

        private static int[,] DoMatrixA(int size)
        {
            int[,] matrix = new int[size, size];
            matrix[0, 0] = size * size;
            matrix[size - 1, size - 1] = 1;

            int counter = 1;
            for (int col = 1; col < size; col++)
            {
                matrix[0, col] = matrix[0, col - 1] - counter;
                counter++;
            }

            for (int index = size - 1; index > 0; index--)
            {
                int row = 0;
                int col = index;
                while (CheckInRange(size, row + 1, col - 1))
                {
                    matrix[row + 1, col - 1] = matrix[row, col] - 1;
                    row++;
                    col--;
                }
            }

            int previous = matrix[size - 1, 0];
            for (int index = 1; index < size - 1; index++)
            {
                int row = index;
                int col = size - 1;
                matrix[row, col] = previous - 1;
                while (CheckInRange(size, row + 1, col - 1))
                {
                    matrix[row + 1, col - 1] = matrix[row, col] - 1;
                    previous = matrix[row + 1, col - 1];
                    row++;
                    col--;
                }
            }

            return matrix;
        }

        private static int[,] DoMatrixB(int size)
        {
            int[,] matrix = new int[size, size];
            matrix[size - 1, 0] = 1;
            int counter = 1;
            for (int row = size - 2; row >= 0; row--)
            {
                matrix[row, 0] = matrix[row + 1, 0] + counter;
                int newRow = row;
                for (int diagonal = 1; diagonal <= counter; diagonal++)
                {
                    matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                    newRow++;
                }
                counter++;
            }

            matrix[0, size - 1] = size * size;
            int diagonalLength = 2;
            int posRow = 1;
            int posCol = size - 1;
            int prevRow = 0;
            int prevCol = size - 1;

            for (int i = 1; i < counter - 1; i++)
            {
                for (int j = 1; j <= diagonalLength; j++)
                {
                    matrix[posRow, posCol] = matrix[prevRow, prevCol] - 1;
                    prevRow = posRow;
                    prevCol = posCol;
                    posRow--;
                    posCol--;
                }

                diagonalLength++;
                posRow = i + 1;
                posCol = size - 1;
            }

            return matrix;
        }

        private static bool CheckInRange(int size, int row, int col)
        {
            bool rowInRange = row >= 0 && row < size;
            bool colInRange = col >= 0 && col < size;

            return rowInRange && colInRange;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}