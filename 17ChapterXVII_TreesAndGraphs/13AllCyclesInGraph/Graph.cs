using System;
using System.Collections.Generic;
using System.Text;

namespace _13AllCyclesInGraph
{
    public class Graph
    {
		private bool hasCycle;
		private int cycleCounter;
		private int[][] childNodes;
		private bool[] visitedNodes;
		private StringBuilder cycleBuilder;
		private HashSet<HashSet<int>> cycles = new HashSet<HashSet<int>>();		

		public Graph(int[][] nodes)
		{
			this.ChildNodes = nodes;
			this.cycleCounter = 0;
			this.hasCycle = false;
			this.cycleBuilder = new StringBuilder();
			this.visitedNodes = new bool[nodes.GetLength(0)];	
		}

		public int[][] ChildNodes
		{
			get { return this.childNodes; }
			set { this.childNodes = value; }
		}

		public bool HasCycle => this.hasCycle;

		public void GetAllCycles(int currentNode)
		{
			this.visitedNodes[currentNode] = true;
			this.cycleBuilder.Append(currentNode);

			foreach (int childNode in this.childNodes[currentNode])
			{
				if (this.cycleBuilder.Length > 1 && childNode == Char.GetNumericValue(this.cycleBuilder[cycleBuilder.Length - 2]))
				{
					continue;
				}

				if (!this.visitedNodes[childNode])
				{
					this.GetAllCycles(childNode);
				}
				else
				{
					this.PrintCycle(childNode);
					this.hasCycle = true;
				}
			}

			this.cycleBuilder.Remove(this.cycleBuilder.Length - 1, 1);
			this.visitedNodes[currentNode] = false;
		}

		private void PrintCycle(int childNode)
		{
			int cycleStartIndex = this.cycleBuilder.ToString().LastIndexOf(childNode.ToString());
			string currentCycle = this.cycleBuilder.ToString().Substring(cycleStartIndex);

			HashSet<int> currentCycleSet = new HashSet<int>();
			foreach (char number in currentCycle)
			{
				currentCycleSet.Add((int)Char.GetNumericValue(number));
			}

			foreach (HashSet<int> set in cycles)
			{
				if (set.SetEquals(currentCycleSet))
				{
					return;
				}
			}

			this.cycles.Add(currentCycleSet);
			this.cycleCounter++;
			Console.Write($"Cycle {this.cycleCounter}: ");

			char[] finalCycle = currentCycle.ToCharArray();
			Array.Sort(finalCycle);
			foreach (char letter in finalCycle)
			{
				Console.Write(letter + " ");
			}

			Console.WriteLine();
		}
	}
}