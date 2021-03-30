using System;

namespace _06RotatingWalkInMatrix
{
    class Program
    {
        private const int DirectionsCount = 8;
        private const int EndDirection = 7;

        private static int[,] matrix;
        private static int matrixSize;       

        static void Main(string[] args)
        {
            matrixSize = int.Parse(Console.ReadLine());
            if (matrixSize == 0)
            {
                Console.WriteLine("The matrix size must be positive number!");

                return;
            }

            matrix = new int[matrixSize, matrixSize];
            int currentNumber = 1;
            int currentRow = 0;
            int currentCol = 0;
            int directionRow = 1;
            int directionCol = 1;

            while (true)
            {
                matrix[currentRow, currentCol] = currentNumber;
                if (!IsFinishedPart(currentRow, currentCol))
                {
                    if (IsEnd())
                    {
                        break;
                    }

                    FindNextFreeCell(out currentRow, out currentCol);
                    directionRow = 1;
                    directionCol = 1;
                    currentNumber++;
                    continue;
                }

                if (CannotMoveInDirection(currentRow, currentCol, directionRow, directionCol))
                {
                    while (CannotMoveInDirection(currentRow, currentCol, directionRow, directionCol))
                    {
                        ChangeDirection(ref directionRow, ref directionCol);
                    }
                }
                else
                {
                    currentRow += directionRow;
                    currentCol += directionCol;
                    currentNumber++;
                }
            }

            PrintMatrix();
        }

        private static bool IsFinishedPart(int row, int col)
        {
            int[] possibleDirectionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < DirectionsCount; i++)
            {
                if (row + possibleDirectionsX[i] < 0 || row + possibleDirectionsX[i] >= matrix.GetLength(0))
                {
                    possibleDirectionsX[i] = 0;
                }

                if (col + possibleDirectionsY[i] < 0 || col + possibleDirectionsY[i] >= matrix.GetLength(1))
                {
                    possibleDirectionsY[i] = 0;
                }
            }

            for (int i = 0; i < DirectionsCount; i++)
            {
                if (matrix[row + possibleDirectionsX[i], col + possibleDirectionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsEnd()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void FindNextFreeCell(out int row, out int col)
        {
            row = 0;
            col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        return;
                    }
                }
            }
        }

        private static bool CannotMoveInDirection(int currentRow, int currentCol, int directionRow, int directionCol)
        {
            bool cannotMoveInRow = currentRow + directionRow < 0 || currentRow + directionRow >= matrixSize;
            bool cannotMoveInCol = currentCol + directionCol < 0 || currentCol + directionCol >= matrixSize;
            if (cannotMoveInRow ||  cannotMoveInCol  || matrix[currentRow + directionRow, currentCol + directionCol] != 0)
            {
                return true;
            }

            return false;
        }

        private static void ChangeDirection(ref int directionRow, ref int directionCol)
        {
            int[] possibleDirectionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;
            for (int i = 0; i < DirectionsCount; i++)
            {
                if (possibleDirectionsRow[i] == directionRow && possibleDirectionsCol[i] == directionCol)
                {
                    currentDirection = i;
                    break;
                }
            }

            if (currentDirection == EndDirection)
            {
                directionRow = possibleDirectionsRow[0];
                directionCol = possibleDirectionsCol[0];
            }
            else
            {
                directionRow = possibleDirectionsRow[currentDirection + 1];
                directionCol = possibleDirectionsCol[currentDirection + 1];
            }

            return;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}