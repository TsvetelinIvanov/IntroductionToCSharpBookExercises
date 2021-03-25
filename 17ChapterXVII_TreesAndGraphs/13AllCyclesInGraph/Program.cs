using System;
using System.Linq;

namespace _13AllCyclesInGraph
{
    class Program
    {
		//input example:
		//7
		//3,6
		//2,3,4,5,6
		//1,4,5
		//0,1,5
		//1,2,6
		//1,2,3
		//0,1,4
		//expected output:
		//Cycle 1: 1 2 4
		//Cycle 2: 0 1 2 3 4 6
		//Cycle 3: 1 2 4 6
		//Cycle 4: 1 2 5
		//Cycle 5: 1 2 3 5
		//Cycle 6: 1 2 4 5
		//Cycle 7: 1 2 3 4 5
		//Cycle 8: 0 1 3 4 6
		//Cycle 9: 1 4 6
		//Cycle 10: 0 1 2 3 4 5 6
		//Cycle 11: 1 2 4 5 6
		//Cycle 12: 1 3 5
		//Cycle 13: 0 1 3 6
		//Cycle 14: 1 2 3 4 5 6
		//Cycle 15: 0 1 3 4 5 6
		//Cycle 16: 0 1 3 5 6
		//Cycle 17: 0 1 2 3 5 6
		//Cycle 18: 0 2 3 4 5 6
		static void Main(string[] args)
		{
			Graph graph = CreateGraph();
			graph.GetAllCycles(0);
			if (!graph.HasCycle)
            {
                Console.WriteLine("No cycles!");
            }            
		}

		private static Graph CreateGraph()
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