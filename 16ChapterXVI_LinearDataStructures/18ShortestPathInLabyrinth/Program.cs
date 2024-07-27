using System;
using System.Collections.Generic;
using System.Text;

namespace _18ShortestPathInLabyrinth
{
    class Program
    {
		static void Main(string[] args)
		{
                        int[,] labyrinth = Read(out Cell startCell);
                        Walk(labyrinth, startCell);
			Print(labyrinth);
		}

		static int[,] Read(out Cell startCell)
		{
			int size = int.Parse(Console.ReadLine());

			int[,] labyrinth = new int[size, size];
			startCell = new Cell(0, 0);
			for (int i = 0; i < labyrinth.GetLength(0); i++)
			{				
				string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
				for (int j = 0; j < labyrinth.GetLength(1); j++)
				{
					switch (line[j][0])
					{
						case 'x':
							labyrinth[i, j] = (int)CellType.NonPassable;
							break;
						case '*':
							labyrinth[i, j] = (int)CellType.Start;
							startCell.Row = i;
							startCell.Col = j;
							break;
						default:
							labyrinth[i, j] = (int)CellType.Normal;
							break;
					}
				}
			}

			return labyrinth;
		}

		static void Walk(int[,] labyrinth, Cell startCell)
		{
			int[] rowOffset = new int[] { -1, 1, 0, 0 };
			int[] colOffset = new int[] { 0, 0, -1, 1 };

			int size = labyrinth.GetLength(0);
			bool[,] visitedCells = new bool[size, size];

			Queue<Cell> cells = new Queue<Cell>();
			cells.Enqueue(startCell);
			while (cells.Count > 0)
			{
				Cell currentCell = cells.Dequeue();
				for (int i = 0; i < rowOffset.Length; i++)
				{
					Cell cell = new Cell(currentCell.Row + rowOffset[i], currentCell.Col + colOffset[i]);
					if (!IsInLabyrinth(cell, size, size))
					{
						continue;
					}

					bool isVisited = visitedCells[cell.Row, cell.Col];
					bool isPassable = labyrinth[cell.Row, cell.Col] >= (int)CellType.Normal;
					if (!isVisited && isPassable)
					{
						cells.Enqueue(cell);
						visitedCells[cell.Row, cell.Col] = true;

						if (labyrinth[currentCell.Row, currentCell.Col] != (int)CellType.Start)
						{
							labyrinth[cell.Row, cell.Col] = labyrinth[currentCell.Row, currentCell.Col] + 1;
						}
						else
						{
							labyrinth[cell.Row, cell.Col] = 1;
						}
					}
				}
			}
		}

		static bool IsInLabyrinth(Cell cell, int rowsCount, int colsCount)
		{
			return cell.Row >= 0 && cell.Row < rowsCount && cell.Col >= 0 && cell.Col < colsCount;
		}

		static void Print(int[,] labyrinth)
		{
			for (int i = 0; i < labyrinth.GetLength(0); i++)
			{
				StringBuilder line = new StringBuilder();
				for (int j = 0; j < labyrinth.GetLength(1); j++)
				{
					switch (labyrinth[i, j])
					{
						case (int)CellType.NonPassable:
							line.Append("x ");
							break;
						case (int)CellType.Start:
							line.Append("* ");
							break;
						case (int)CellType.Normal: // after walk is unpassable
							line.Append("u ");
							break;
						default:
							line.Append(labyrinth[i, j] + " ");
							break;
					}
				}

				Console.WriteLine(line.ToString().Trim());
			}
		}
	}
}
