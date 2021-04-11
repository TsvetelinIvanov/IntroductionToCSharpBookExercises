using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace _02FindLabyrinthExits
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] labyrinthLines = File.ReadAllLines("Problem.in.txt");
            int linesCountN = int.Parse(labyrinthLines[0]);
            char[,] labyrinth = new char[linesCountN, linesCountN];
            labyrinthLines = labyrinthLines.Skip(1).ToArray();
            Cell startCell = null;
            for (int i = 0; i < linesCountN; i++)
            {
                string[] labyrinthLine = labyrinthLines[i].Split();
                for (int j = 0; j < linesCountN; j++)
                {
                    labyrinth[i, j] = labyrinthLine[j][0];
                    if (labyrinth[i, j] == '*')
                    {
                        startCell = new Cell(i, j);
                    }
                }
            }

            MatkPaths(labyrinth, startCell);
            //PrintLabyrinth(labyrinth);

            int exitsCount = CountExits(labyrinth);
            //Console.WriteLine(exitsCount);
            
            File.WriteAllText("Problem.out.txt", "The number of found exits is: " + exitsCount);
        }        

        private static void MatkPaths(char[,] labyrinth, Cell startCell)
        {
            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(startCell);
            while (cells.Count > 0)
            {
                Cell currentCell = cells.Dequeue();
                if (currentCell.Row - 1 >= 0 && labyrinth[currentCell.Row - 1, currentCell.Col] == '0')
                {
                    cells.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col));
                    labyrinth[currentCell.Row - 1, currentCell.Col] = 'a';
                }                

                if (currentCell.Col + 1 < labyrinth.GetLength(1) && labyrinth[currentCell.Row, currentCell.Col + 1] == '0')
                {
                    cells.Enqueue(new Cell(currentCell.Row, currentCell.Col + 1));
                    labyrinth[currentCell.Row, currentCell.Col + 1] = 'a';
                }

                if (currentCell.Row + 1 < labyrinth.GetLength(0) && labyrinth[currentCell.Row + 1, currentCell.Col] == '0')
                {
                    cells.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col));
                    labyrinth[currentCell.Row + 1, currentCell.Col] = 'a';
                }

                if (currentCell.Col - 1 >= 0 && labyrinth[currentCell.Row, currentCell.Col - 1] == '0')
                {
                    cells.Enqueue(new Cell(currentCell.Row, currentCell.Col - 1));
                    labyrinth[currentCell.Row, currentCell.Col - 1] = 'a';
                }
            }
        }

        //private static void PrintLabyrinth(char[,] labyrinth)
        //{
        //    for (int i = 0; i < labyrinth.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < labyrinth.GetLength(1); j++)
        //        {
        //            Console.Write(labyrinth[i, j] + " ");
        //        }

        //        Console.WriteLine();
        //    }
        //}

        private static int CountExits(char[,] labyrinth)
        {
            int exitsCount = 0;
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                if (labyrinth[i, 0] == 'a')
                {
                    exitsCount++;
                    if (i == 0)
                    {
                        continue;
                    }
                }

                if (labyrinth[0, i] == 'a')
                {
                    exitsCount++;
                }
            }

            for (int i = labyrinth.GetLength(0) - 1; i > 0; i--)
            {
                if (labyrinth[i, labyrinth.GetLength(1) - 1] == 'a')
                {
                    exitsCount++;
                    if (i == labyrinth.GetLength(1) - 1)
                    {
                        continue;
                    }
                }

                if (labyrinth[labyrinth.GetLength(0) - 1, i] == 'a')
                {
                    exitsCount++;
                }
            }

            return exitsCount;
        }
    }
}