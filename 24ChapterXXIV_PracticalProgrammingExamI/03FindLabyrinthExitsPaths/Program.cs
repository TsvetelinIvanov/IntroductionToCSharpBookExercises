using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03FindLabyrinthExitsPaths
{
    class Program
    {      
        private static List<char> path = new List<char>();
        private static List<string> paths = new List<string>();        

        static void Main(string[] args)
        {
            string[] labyrinthLines = File.ReadAllLines("Problem.in.txt");
            int linesCountN = int.Parse(labyrinthLines[0]);
            char[,] labyrinth = new char[linesCountN, linesCountN];
            labyrinthLines = labyrinthLines.Skip(1).ToArray();
            int startPointRow = -1;
            int startPointCol = -1;
            for (int i = 0; i < linesCountN; i++)
            {
                string[] labyrinthLine = labyrinthLines[i].Split();
                for (int j = 0; j < linesCountN; j++)
                {
                    labyrinth[i, j] = labyrinthLine[j][0];
                    if (labyrinth[i, j] == '*')
                    {
                        startPointRow = i;
                        startPointCol = j;
                    }
                }
            }

            bool[,] visitedCells = new bool[labyrinth.GetLength(0), labyrinth.GetLength(1)];
            labyrinth[startPointRow, startPointCol] = 'a';
            FindPathToExit(labyrinth, visitedCells, startPointRow, startPointCol);

            int pathsCount = paths.Count;
            paths.Insert(0, "The number of found paths to found exits is: " + pathsCount);
            File.WriteAllLines("Problem.out.txt", paths);
        }

        private static void FindPathToExit(char[,] labyrinth, bool[,] visitedCells, int row, int col)
        {
            if (!IsInLabyrinth(labyrinth, row, col))
            {
                SavePath();
                return;
            }

            path.Add(labyrinth[row, col]);

            if (Char.IsLetter(labyrinth[row, col]) && !visitedCells[row, col])
            {
                visitedCells[row, col] = true;

                FindPathToExit(labyrinth, visitedCells, row - 1, col);
                FindPathToExit(labyrinth, visitedCells, row, col + 1);
                FindPathToExit(labyrinth, visitedCells, row + 1, col);
                FindPathToExit(labyrinth, visitedCells, row, col - 1);

                visitedCells[row, col] = false;
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsInLabyrinth(char[,] labyrinth, int row, int col)
        {
            bool isInRow = row >= 0 && row < labyrinth.GetLength(0);
            bool isInCol = col >= 0 && col < labyrinth.GetLength(1);

            return isInRow && isInCol;
        }

        private static void SavePath()
        {
            StringBuilder currentPath = new StringBuilder();
            for (int i = 1; i < path.Count; i++)
            {
                currentPath.Append(path[i]);
            }

            if (!paths.Contains(currentPath.ToString()))
            {
                paths.Add(currentPath.ToString());
            }
        }
    }
}