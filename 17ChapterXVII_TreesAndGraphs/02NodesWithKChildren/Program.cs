using System;
using System.Collections.Generic;
using System.Text;

namespace _02NodesWithKChildren
{
    class Program
    {
		//input example:
		//(1->(8->7,4,6),(5->(11->(2->15),3)))
		//0		
		//expected output: 3, 4, 6, 7, 15
		static void Main(string[] args)
		{
			string rawTree = Console.ReadLine();
			uint childNodesCountK = uint.Parse(Console.ReadLine());
			TreeNode<int> root = ParseTree(rawTree);
			Tree<int> tree = new Tree<int>(root);
			int[] subTrees = tree.GetSubtreesWithKNodes(childNodesCountK).ToArray();
                        Array.Sort(subTrees);
                        Console.WriteLine(string.Join(", ", subTrees));
		}

		private static TreeNode<int> ParseTree(string tree)
		{
			if (!tree.Contains("->"))
			{
				int currentValue = int.Parse(tree);

				return new TreeNode<int>(currentValue);
			}

			string cleanTree = tree[1..^1];
			string[] currentNodes = cleanTree.Split(new string[] { "->" }, 2, StringSplitOptions.RemoveEmptyEntries);
			TreeNode<int> currentNode = new TreeNode<int>(int.Parse(currentNodes[0]));
			if (currentNodes[1].Contains("->"))
			{
				List<string> children = GetChildren(currentNodes[1]);
				foreach (string child in children)
				{
					TreeNode<int> currentNodeChild = ParseTree(child);
					currentNode.AddChild(currentNodeChild);
				}
			}
			else
			{
				string[] leafs = currentNodes[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string leaf in leafs)
				{
					int leafValue = int.Parse(leaf);
					currentNode.AddChild(new TreeNode<int>(leafValue));
				}
			}

			return currentNode;
		}

		private static List<string> GetChildren(string successors)
		{
			List<string> children = new List<string>();
			int openBrackets = 0;
			StringBuilder currentChildTree = new StringBuilder();
			for (int i = 0; i < successors.Length; i++)
			{
				if (openBrackets == 0 && successors[i] != '(')
				{
					StringBuilder currentLeaf = new StringBuilder();
					while (i < successors.Length && Char.IsDigit(successors[i]))
					{
						currentLeaf.Append(successors[i]);
						i++;
					}

					children.Add(currentLeaf.ToString());
					continue;
				}

				if (successors[i] == ')')
				{
					openBrackets--;
				}
				else if (successors[i] == '(')
				{
					openBrackets++;
				}

				if (openBrackets == 0)
				{
					currentChildTree.Append(')');
					children.Add(currentChildTree.ToString());
					currentChildTree.Clear();
					i++;
				}
				else
				{
					currentChildTree.Append(successors[i]);
				}
			}

			return children;
		}
	}
}
