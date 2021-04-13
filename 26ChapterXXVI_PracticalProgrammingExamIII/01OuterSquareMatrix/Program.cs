using System;

namespace _01OuterSquareMatrix
{
    class Program
    {
        private const int Down = 0;
        private const int Left = 1;
        private const int Up = 2;
        private const int Right = 3;

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            FillMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            int count = matrix.GetLength(0) * matrix.GetLength(1);
            int positionX = matrix.GetLength(1) - 1;
            int positionY = 0;
            int direction = Down;

            for (int i = 1; i <= count; i++)
            {
                matrix[positionY, positionX] = i;
                Move(i, matrix, ref direction, ref positionX, ref positionY);
            }
        }

        private static void Move(int counter, int[,] matrix, ref int direction, ref int positionX, ref int positionY)
        {
            if (direction == Down && positionY + 1 < matrix.GetLength(0) && IsFree(matrix, positionY + 1, positionX))
            {
                positionY++;
            }
            else if (direction == Left && positionX - 1 >= 0 && IsFree(matrix, positionY, positionX - 1))
            {
                positionX--;
            }
            else if (direction == Up && positionY - 1 >= 0 && IsFree(matrix, positionY - 1, positionX))
            {
                positionY--;
            }
            else if (direction == Right && positionX + 1 < matrix.GetLength(0) && IsFree(matrix, positionY, positionX + 1))
            {
                positionX++;
            }
            else if (counter < matrix.GetLength(0) * matrix.GetLength(1))
            {
                direction = (direction + 1) % 4;
                Move(counter, matrix, ref direction, ref positionX, ref positionY);
            }
        }

        private static bool IsFree(int[,] matrix, int positionX, int positionY)
        {            
            return matrix[positionX, positionY] == 0;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,5}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}