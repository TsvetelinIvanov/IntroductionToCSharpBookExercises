using System;
using System.Collections.Generic;

namespace _15MinPaths
{
    class Program
    {
		//input example:
		//2 2
		//0 1 5
		//1 0 7
		//0
		//expected output: 
		//From 0 to 1 -> 5
		static List<Vertex>[] vertices;		

		static void Main(string[] args)
		{
			ReadGraph();
			int startNode = int.Parse(Console.ReadLine());
			DijkstraAlgorithm(startNode);
		}

		public static void ReadGraph()
		{
			string[] nodesAndEdgesCounts = Console.ReadLine().Split();
			int nodesCount = int.Parse(nodesAndEdgesCounts[0]);
			int edgesCount = int.Parse(nodesAndEdgesCounts[1]);

			vertices = new List<Vertex>[nodesCount];
			for (int i = 0; i < nodesCount; i++)
			{
				vertices[i] = new List<Vertex>();
			}

			for (int i = 0; i < edgesCount; i++)
			{
				string[] currentEdge = Console.ReadLine().Split();
				int start = int.Parse(currentEdge[0]);
				int end = int.Parse(currentEdge[1]);
				int length = int.Parse(currentEdge[2]);
				vertices[start].Add(new Vertex(end, length));
			}
		}

		static void DijkstraAlgorithm(int startNode)
		{
			long[] shortestPaths = new long[vertices.GetLength(0)];
			bool[] visitedVertices = new bool[vertices.GetLength(0)];

			for (int i = 0; i < vertices.GetLength(0); i++)
			{
				shortestPaths[i] = int.MaxValue;
			}

			Queue<int> nodesQueue = new Queue<int>();
			shortestPaths[startNode] = 0;
			nodesQueue.Enqueue(startNode);

			int currentNode;
			while (nodesQueue.Count > 0)
			{
				currentNode = nodesQueue.Dequeue();
				if (visitedVertices[currentNode])
				{
					continue;
				}

				visitedVertices[currentNode] = true;
				for (int i = 0; i < vertices[currentNode].Count; i++)
				{
					int destination = vertices[currentNode][i].Destination;
					int length = vertices[currentNode][i].Length;
					long currentDistance = shortestPaths[currentNode] + length;
					if (currentDistance < shortestPaths[destination])
					{
						shortestPaths[destination] = currentDistance;
						nodesQueue.Enqueue(destination);
						visitedVertices[destination] = false;
					}
				}
			}

			for (int i = 0; i < shortestPaths.Length; i++)
			{
				if (i == startNode)
				{
					continue;
				}

				if (shortestPaths[i] == int.MaxValue)
				{
					Console.WriteLine("From {0} to {1} -> No path", startNode, i);
				}
				else
				{
					Console.WriteLine("From {0} to {1} -> {2}", startNode, i, shortestPaths[i]);
				}
			}
		}
	}
}