using System;
using System.Collections.Generic;

namespace _13FindAllSequencesFreeCells
{
    class Program
    {
        private static char[,] labyrinth;
        private static List<int[]> sequence;

        static void Main(string[] args)
        {
            ReadInput();
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] != '.')
                    {
                        continue;
                    }

                    sequence = new List<int[]>();
                    FindSequence(row, col);
                    PrintSequenceCoordinates(sequence);
                }
            }
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

        static void FindSequence(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) || col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] == '.')
            {
                labyrinth[row, col] = 'v';
                sequence.Add(new int[] { row, col });
                FindSequence(row - 1, col);
                FindSequence(row, col + 1);
                FindSequence(row + 1, col);
                FindSequence(row, col - 1);                
            }
        }

        static void PrintSequenceCoordinates(List<int[]> sequence)
        {
            Console.WriteLine(sequence.Count);
            foreach (int[] cell in sequence)
            {
                Console.Write("({0}, {1}) ", cell[0], cell[1]);
            }

            Console.WriteLine();
        }
    }
}