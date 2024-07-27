using System;
using System.Collections.Generic;

namespace _10BreadthFirstSearch
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

		public void BreadthFirstSearch()
		{
			Queue<int> currentNodes = new Queue<int>();
			bool[] visitedNodes = new bool[this.ChildNodes.GetLength(0)];
			int nodesLeft = this.ChildNodes.GetLength(0);

			currentNodes.Enqueue(0);
			visitedNodes[0] = true;
			while (currentNodes.Count > 0)
			{
				int currentNode = currentNodes.Dequeue();
				nodesLeft--;

                                Console.Write(currentNode + " ");

				foreach (int child in ChildNodes[currentNode])
				{
					if (visitedNodes[child] == false)
					{
						currentNodes.Enqueue(child);
						visitedNodes[child] = true;
					}
				}
			}
		}
	}
}
