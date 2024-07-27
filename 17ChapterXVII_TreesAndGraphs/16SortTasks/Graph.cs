using System;
using System.Collections.Generic;
using System.Linq;

namespace _16SortTasks
{
    public class Graph
    {
		private List<int>[] childNodes;
		private bool[] dependantNodes;

		public Graph(List<int>[] nodes)
		{
			this.ChildNodes = nodes;
		}

		public List<int>[] ChildNodes
		{
			get { return this.childNodes; }
			set { this.childNodes = value; }
		}

		public void TopologicalSort()
		{
			List<int>[] sortingGraph = new List<int>[this.childNodes.Length];
			Array.Copy(this.childNodes, sortingGraph, this.childNodes.Length);

			DetermineDependantNodes();
			Queue<int> startNodes = new Queue<int>();
			for (int i = 0; i < dependantNodes.Length; i++)
			{
				if (!dependantNodes[i])
				{
					startNodes.Enqueue(i);
				}
			}

			List<int> sortedElements = new List<int>();
			while (startNodes.Count > 0)
			{
				int currentNode = startNodes.Dequeue();
				sortedElements.Add(currentNode);
				foreach (int node in sortingGraph[currentNode])
				{
					sortingGraph[currentNode] = sortingGraph[currentNode].Where(n => n != node).ToList();

					bool addToStartNodes = true;
					foreach (List<int> successors in sortingGraph)
					{
						if (successors.Contains(node))
						{
							addToStartNodes = false;
							break;
						}
					}

					if (addToStartNodes)
					{
						startNodes.Enqueue(node);
					}
				}
			}

			bool hasCycles = HasCyclesAfterTopologicalSort(sortingGraph);
			if (hasCycles)
			{
				Console.WriteLine("Cannot sort!");
				
				return;
			}
			else
			{
				sortedElements = sortedElements.Skip(1).ToList();
				Console.WriteLine(string.Join(", ", sortedElements));
				
				return;
			}
		}

		private void DetermineDependantNodes()
		{
			this.dependantNodes = new bool[this.childNodes.GetLength(0)];
			for (int i = 0; i < this.childNodes.GetLength(0); i++)
			{
				for (int j = 0; j < this.childNodes[i].Count; j++)
				{
					dependantNodes[this.childNodes[i][j]] = true;
				}
			}
		}

		private bool HasCyclesAfterTopologicalSort(List<int>[] graph)
		{
			foreach (List<int> successors in graph)
			{
				if (successors.Count > 0)
				{
					return true;
				}
			}

			return false;
		}				
	}
}
