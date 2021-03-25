using System;
using System.Collections.Generic;

namespace _16SortTasks
{
    class Program
    {
		//input example:
		//5 4
		//1,2
		//2,5
		//2,4
		//3,1
		//expected output: 3, 1, 2, 5, 4
		public static Graph CreateGraphFromPairs()
		{
			string[] pairsInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			int verticesCount = int.Parse(pairsInfo[0]);
			int pairsCount = int.Parse(pairsInfo[1]);

			if (verticesCount < 2)
			{
				throw new ApplicationException("Graph must have at least two vertices!");
			}

			if (pairsCount < 0)
			{
				throw new ApplicationException("Pairs must be zero or more!");
			}

			List<int>[] graphArray = new List<int>[verticesCount + 1];
			for (int i = 0; i < graphArray.Length; i++)
			{
				graphArray[i] = new List<int>();
			}

			for (int i = 0; i < pairsCount; i++)
			{
				string[] currentPair = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
				int left = int.Parse(currentPair[0]);
				int right = int.Parse(currentPair[1]);

				if (left != right)
				{
					graphArray[left].Add(right);
				}
				else
				{
					throw new ApplicationException("A vertex cannot be it's own successor!");
				}
			}

			Graph graph = new Graph(graphArray);

			return graph;
		}

		static void Main(string[] args)
		{
			Graph tasks = CreateGraphFromPairs();
			tasks.TopologicalSort();
		}

	}
}