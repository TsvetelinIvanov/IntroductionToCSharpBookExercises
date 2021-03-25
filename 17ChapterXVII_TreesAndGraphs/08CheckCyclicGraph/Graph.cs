using System.Collections.Generic;

namespace _08CheckCyclicGraph
{
    public class Graph
    {
		private int[][] childNodes;

		public Graph(int[][] nodes)
		{
			this.ChildNodes = nodes;
		}

		public int[][] ChildNodes
		{
			get { return this.childNodes; }
			set { this.childNodes = value; }
		}

		public bool IsCyclic()
		{
			Queue<int> nodes = new Queue<int>();
			bool[] visitedNodes = new bool[ChildNodes.GetLength(0)];

			nodes.Enqueue(0);
			while (nodes.Count > 0)
			{
				int currentNode = nodes.Dequeue();
				if (visitedNodes[currentNode])
				{
					return true;
				}

				visitedNodes[currentNode] = true;
				foreach (int childNode in this.childNodes[currentNode])
				{
					nodes.Enqueue(childNode);
				}
			}

			return false;
		}
	}
}