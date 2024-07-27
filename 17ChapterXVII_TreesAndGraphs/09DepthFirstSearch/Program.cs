using System;
using System.Linq;

namespace _09DepthFirstSearch
{
    class Program
    {
		//input example:
		//3
		//1,2
		//0,2
		//1,0
		//expected output: 0 1 2
		public static void Main(string[] args)
		{
			bool[] visitedNodes = new bool[1024];
			Graph graph = CreateGraph();
			graph.DepthFirstSearch(0, visitedNodes);			
			Console.WriteLine();

			GraphDepthFirstSearchTest.TestGraphDepthFirstSearch();
                        Console.WriteLine();
		}

		public static Graph CreateGraph()
		{
			int verticesCount = int.Parse(Console.ReadLine());
			int[][] graphArray = new int[verticesCount][];

			for (int i = 0; i < verticesCount; i++)
			{				
				string[] currentVertexSuccessors = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
				graphArray[i] = currentVertexSuccessors.Select(item => int.Parse(item)).ToArray();
				Array.Sort(graphArray[i]);
				if (graphArray[i].Contains(i))
				{
					throw new ApplicationException("A vertex cannot be it's own successor!");
				}
			}

			Graph graph = new Graph(graphArray);

			return graph;
		}
	}
}
