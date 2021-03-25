using System;
using System.Collections.Generic;

namespace _14ConnectivityComponents
{
    public class Graph
    {
		private int[][] childNodes;
		private bool[] visitedNodes;
		private SortedSet<int> currentComponent;

		public Graph(int[][] nodes)
		{
			this.ChildNodes = nodes;
			this.visitedNodes = new bool[nodes.GetLength(0)];
		}

		public int[][] ChildNodes
		{
			get { return this.childNodes; }
			set { this.childNodes = value; }
		}	

		public void GetConnectedComponents()
		{
			this.currentComponent = new SortedSet<int>();
			int componentsCounter = 1;
			for (int node = 0; node < this.visitedNodes.Length; node++)
			{
				if (!this.visitedNodes[node])
				{
					Console.Write($"Connected component {componentsCounter}: ");
					this.DepthFirstSearch(node);
					PrintConnectedComponent();
					componentsCounter++;
				}
			}
		}

		private void DepthFirstSearch(int currentNode)
		{
			this.visitedNodes[currentNode] = true;
			this.currentComponent.Add(currentNode);
			foreach (int childNode in this.childNodes[currentNode])
			{
				if (!this.visitedNodes[childNode])
				{
					DepthFirstSearch(childNode);
				}
			}
		}

		private void PrintConnectedComponent()
		{
			foreach (int vertex in currentComponent)
			{
				Console.Write(vertex + " ");
			}

			Console.WriteLine();
			this.currentComponent.Clear();
		}
	}
}