using System;
using System.Collections.Generic;

namespace _18HamiltonianCycle
{
    class Program
    {
		//input example:
		//11 11
		//0 1 5
		//1 3 6
		//3 2 7
		//2 4 8
		//4 5 1
		//5 9 2
		//9 8 4
		//8 7 3
		//7 6 1
		//6 10 2
		//10 0 10
		//expected output:
		//0 1 3 2 4 5 9 8 7 6 10
		//49
		private const int MaxVerticesCount = 151;
		
		static int minimumSum = int.MaxValue;
		static int currentSum;
		static int[] minimumCycle;
		static int[] currentCycle;
		static bool[] visitedNodes;
		public static List<Vertex>[] graph;		

		static void Main(string[] args)
		{
			ReadGraph();
			FindHamiltonCycle(0);

			if (minimumSum != int.MaxValue)
			{
				PrintHamiltonCycle();
			}
			else
			{
				Console.WriteLine("No Hamilton cycle is found!");
			}
		}

		private static void ReadGraph()
		{
			string[] nodesEdgesCounts = Console.ReadLine().Split();
			int nodesCount = int.Parse(nodesEdgesCounts[0]);
			int edgesCount = int.Parse(nodesEdgesCounts[1]);

			graph = new List<Vertex>[nodesCount];
			for (int i = 0; i < nodesCount; i++)
			{
				graph[i] = new List<Vertex>();
			}

			for (int i = 0; i < edgesCount; i++)
			{
				string[] currentEdge = Console.ReadLine().Split();
				int start = int.Parse(currentEdge[0]);
				int end = int.Parse(currentEdge[1]);
				int length = int.Parse(currentEdge[2]);
				graph[start].Add(new Vertex(end, length));
			}
		}

		private static void FindHamiltonCycle(int startNode)
		{
			currentSum = 0;
			minimumCycle = new int[MaxVerticesCount];
			currentCycle = new int[MaxVerticesCount];
			visitedNodes = new bool[graph.GetLength(0)];
			currentCycle[0] = 0;
			FindHamiltonCycle(startNode, 0);
		}

		private static void FindHamiltonCycle(int currentNode, int level)
		{
			if (currentNode == 0 && level > 0)
			{
				if (level == graph.GetLength(0))
				{
					minimumSum = currentSum;
					for (int i = 0; i < graph.GetLength(0); i++)
					{
						minimumCycle[i] = currentCycle[i];
					}
				}

				return;
			}

			if (visitedNodes[currentNode])
			{
				return;
			}

			visitedNodes[currentNode] = true;

			for (int i = 0; i < graph[currentNode].Count; i++)
			{
				int nextVertex = graph[currentNode][i].Destination;
				int length = graph[currentNode][i].Length;

				currentCycle[level] = nextVertex;
				currentSum += length;
				if (currentSum < minimumSum)
				{
					FindHamiltonCycle(nextVertex, level + 1);
				}

				currentSum -= length;
			}

			visitedNodes[currentNode] = false;
		}

		public static void PrintHamiltonCycle()
		{
			Console.Write(0);
			for (int i = 0; i < graph.GetLength(0) - 1; i++)
			{
				Console.Write(" " + minimumCycle[i]);
			}

			Console.WriteLine();
			Console.WriteLine(minimumSum);
		}
	}
}