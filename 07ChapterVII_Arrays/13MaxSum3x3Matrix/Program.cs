using System;
using System.Linq;

namespace _13MaxSum3x3Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCountN = int.Parse(Console.ReadLine());
            int columnsCountM = int.Parse(Console.ReadLine());
            if (rowsCountN < 3  || columnsCountM < 3)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int[,] matrix = new int[rowsCountN, columnsCountM];            
            for (int row = 0; row < rowsCountN; row++)
            {
                int[] rowValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < columnsCountM; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int maxSum = int.MinValue;
            int[] maxSumStart = new int[2];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {                
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col] + matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1] + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumStart[0] = row;
                        maxSumStart[1] = col;
                    }
                }
            }

            for (int row = maxSumStart[0]; row < maxSumStart[0] + 3; row++)
            {
                for (int col = maxSumStart[1]; col < maxSumStart[1] + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}