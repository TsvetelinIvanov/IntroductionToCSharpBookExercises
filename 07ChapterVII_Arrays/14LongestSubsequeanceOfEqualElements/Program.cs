using System;
using System.Linq;
using System.Collections.Generic;

namespace _14LongestSubsequeanceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCountN = int.Parse(Console.ReadLine());
            int columnsCountM = int.Parse(Console.ReadLine());
            if (rowsCountN < 0 || columnsCountM < 0)
            {
                Console.WriteLine("Invalid input!");
                
                return;
            }

            string[,] matrix = new string[rowsCountN, columnsCountM];
            for (int row = 0; row < rowsCountN; row++)
            {
                string[] rowValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < columnsCountM; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            Dictionary<string, int> subsequences = new Dictionary<string, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int neighboursCount = CountNeighbours(matrix, row, col);
                    if (neighboursCount == 0)
                    {
                        if (subsequences.ContainsKey(matrix[row, col]))
                        {
                            subsequences.Remove(matrix[row, col]);
                        }
                    }
                    else
                    {
                        if (!subsequences.ContainsKey(matrix[row, col]))
                        {
                            subsequences.Add(matrix[row, col], 0);                            
                        }

                        subsequences[matrix[row, col]]++;
                    }
                }
            }

            subsequences = subsequences.OrderBy(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            int index = subsequences.Count - 1;
            KeyValuePair<string, int> element;            
            element = subsequences.ElementAt(index);
            for (int i = 0; i < element.Value; i++)
            {
                if (i == element.Value - 1)
                {
                    Console.WriteLine(element.Key);
                    break;
                }

                Console.Write(element.Key + ", ");
            }            
        }

        private static int CountNeighbours(string[,] matrix, int row, int col)
        {
            int count = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i < 0 || i > matrix.GetLength(0) - 1)
                {
                    continue;
                }

                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (j < 0 || j > matrix.GetLength(1) - 1 || (i == row && j == col))
                    {
                        continue;
                    }

                    if (matrix[i, j] == matrix[row, col])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
