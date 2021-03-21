using System;
using System.IO;

namespace _05SquareSubmatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] squareMatrix;
            StreamReader streamReader = new StreamReader("file.txt");
            using (streamReader)
            {      
                int size = int.Parse(streamReader.ReadLine());
                squareMatrix = new int[size, size];
                for (int i = 0; i < size; i++)
                {                    
                    string[] rowElements = streamReader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < size; j++)
                    {
                        squareMatrix[i, j] = int.Parse(rowElements[j]);
                    }
                }
            }
                        
            int maxSum = int.MinValue;
            for (int row = 0; row < squareMatrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1) - 1; col++)
                {
                    int sum = squareMatrix[row, col] + squareMatrix[row, col + 1] + squareMatrix[row + 1, col] + squareMatrix[row + 1, col + 1];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                    }
                }
            }

            StreamWriter streamWriter = new StreamWriter("newFile.txt", false);
            using (streamWriter)
            {                
                Console.WriteLine(maxSum);
                streamWriter.WriteLine(maxSum);
            }
        }
    }
}