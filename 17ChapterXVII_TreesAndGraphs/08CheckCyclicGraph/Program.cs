using System;
using System.Linq;

namespace _08CheckCyclicGraph
{
    class Program
    {
		//input example:
		//3
		//1,2
		//0,2
		//1,0		
		//expected output: True
		static void Main(string[] args)
		{
			Graph graph = CreateGraph();
			Console.WriteLine(graph.IsCyclic());
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