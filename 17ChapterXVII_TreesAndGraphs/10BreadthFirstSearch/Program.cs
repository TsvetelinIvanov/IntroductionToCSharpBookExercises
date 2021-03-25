using System;
using System.Linq;

namespace _10BreadthFirstSearch
{
    class Program
    {
		//input example:
		//3
		//1,2
		//0,2
		//1,0
		//expected output: 0 1 2
		public static Graph CreateGraph()
		{
			int vertexCount = int.Parse(Console.ReadLine());
			int[][] graphArray = new int[vertexCount][];

			for (int i = 0; i < vertexCount; i++)
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

		static void Main(string[] args)
		{
			Graph graph = CreateGraph();
			graph.BreadthFirstSearch();
            Console.WriteLine();
		}
	}
}