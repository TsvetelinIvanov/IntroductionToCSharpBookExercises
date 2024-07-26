using System;

namespace _12RealiseMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if (size <= 0) 
            {
                Console.WriteLine("Ïnvalid input!");
                
                return;
            }

            int[,] matrix = DoMatrixA(size);
            PrintMatrix(matrix);
            Console.WriteLine();

            matrix = DoMatrixB(size);
            PrintMatrix(matrix);
            Console.WriteLine();

            matrix = DoMatrixC(size);
            PrintMatrix(matrix);
            Console.WriteLine();

            matrix = DoMatrixD(size);
            PrintMatrix(matrix);            
        }

        static int[,] DoMatrixA(int size)
        {
            int[,] matrix = new int[size, size];

            matrix[0, 0] = 1;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + size;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrix[row - 1, col] + 1;
                }
            }

            return matrix;
        }

        static int[,] DoMatrixB(int size)
        {
            int[,] matrix = new int[size, size];
            matrix[0, 0] = 1;

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (col % 2 == 0)
                {
                    matrix[0, col] = matrix[0, col - 1] + 1;
                }
                else
                {                    
                    matrix[0, col] = matrix[0, col - 1] + size * 2 - 1;
                }
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col % 2 == 0)
                    {
                        matrix[row, col] = matrix[row - 1, col] + 1;
                    }
                    else
                    {                        
                        matrix[row, col] = matrix[row - 1, col] - 1;
                    }
                }
            }

            return matrix;
        }

        static int[,] DoMatrixC(int size)
        {
            int[,] matrix = new int[size, size];
            matrix[size - 1, 0] = 1;
            int counter = 1;
            for (int oldRow = size - 2; oldRow >= 0; oldRow--)
            {
                matrix[oldRow, 0] = matrix[oldRow + 1, 0] + counter;
                int newRow = oldRow;
                for (int diagonal = 1; diagonal <= counter; diagonal++)
                {
                    matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                    newRow++;
                }

                counter++;
            }

            matrix[0, size - 1] = size * size;
            int diagonalLength = 2;
            int row = 1;
            int col = size - 1;
            int previousRow = 0;
            int previousCol = size - 1;

            for (int i = 1; i < counter - 1; i++)
            {
                for (int j = 1; j <= diagonalLength; j++)
                {
                    matrix[row, col] = matrix[previousRow, previousCol] - 1;
                    previousRow = row;
                    previousCol = col;
                    row--;
                    col--;
                }

                diagonalLength++;
                row = i + 1;
                col = size - 1;
            }

            return matrix;
        }

        static int[,] DoMatrixD(int size)
        {
            int[,] matrix = new int[size, size];
            int concentricSquaresCount = (int)Math.Ceiling((size) / 2.0);
            int j;
            int sideLength = size;
            int currNumber = 0;

            for (int i = 0; i < concentricSquaresCount; i++)
            {
                //left
                for (j = 0; j < sideLength; j++)
                {
                    matrix[i + j, i] = ++currNumber;
                }

                //bottom
                for (j = 1; j < sideLength - 1; j++)
                {
                    matrix[size - 1 - i, i + j] = ++currNumber;
                }

                //right
                for (j = sideLength - 1; j > 0; j--)
                {
                    matrix[i + j, size - 1 - i] = ++currNumber;
                }

                //top
                for (j = sideLength - 1; j > 0; j--)
                {
                    matrix[i, i + j] = ++currNumber;
                }

                sideLength -= 2;
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
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
