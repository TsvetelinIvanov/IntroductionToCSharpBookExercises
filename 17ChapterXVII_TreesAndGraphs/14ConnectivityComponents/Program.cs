using System;
using System.Linq;

namespace _14ConnectivityComponents
{
    class Program
    {
		//input example:
		//7
		//1,4
		//0,2,4
		//1,4
		//5,6
		//0,1,2
		//6,3
		//3,5
		//expected output:
		//Connected component 1: 0 1 2 4
		//Connected component 2: 3 5 6		
		static void Main(string[] args)
		{
			Graph graph = CreateGraph();
			graph.GetConnectedComponents();
		}

		public static Graph CreateGraph()
		{
			int verticesCount = int.Parse(Console.ReadLine());
			int[][] graphArray = new int[verticesCount][];

			for (int i = 0; i < verticesCount; i++)
			{
				string[] currentVertexSuccessors = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
				graphArray[i] = currentVertexSuccessors.Select(item => int.Parse(item)).ToArray();
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