using System;
using System.Collections.Generic;
using System.Text;

namespace _04BinaryTreeLevelNodesSums
{
    class Program
    {
		//input example: (1->(8->7,4),(5->(11->(2->x,15),x),x))		
		//expected output:
		//Level 0 -> 1 (sum of nodes)
		//Level 1 -> 13 (sum of nodes)
		//Level 2 -> 22 (sum of nodes)
		//Level 3 -> 2 (sum of nodes)
		//Level 4 -> 15 (sum of nodes)
		static void Main(string[] args)
		{
			string rawTree = Console.ReadLine();
			BinaryTreeNode root = ParseTree(rawTree);
			BinaryTree tree = new BinaryTree(root);
			tree.PrintLevelSums();
		}

		private static BinaryTreeNode ParseTree(string tree)
		{
			if (!tree.Contains("->"))
			{
				int currentValue = int.Parse(tree);
				return new BinaryTreeNode(currentValue);
			}

			string cleanTree = tree[1..^1];
			string[] currentNodes = cleanTree.Split(new string[] { "->" }, 2, StringSplitOptions.RemoveEmptyEntries);
			BinaryTreeNode currentNode = new BinaryTreeNode(int.Parse(currentNodes[0]));
			if (currentNodes[1].Contains("->"))
			{
				List<string> children = GetChildren(currentNodes[1]);
				if (children[0] != "x")
				{
					currentNode.LeftChild = ParseTree(children[0]);
				}

				if (children[1] != "x")
				{
					currentNode.RightChild = ParseTree(children[1]);
				}
			}
			else
			{
				string[] leafs = currentNodes[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (leafs[0] != "x")
				{
					int leafValue = int.Parse(leafs[0]);
					currentNode.LeftChild = new BinaryTreeNode(leafValue);
				}

				if (leafs[1] != "x")
				{
					int leafValue = int.Parse(leafs[1]);
					currentNode.RightChild = new BinaryTreeNode(leafValue);
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
					while (i < successors.Length && (Char.IsDigit(successors[i]) || successors[i] == 'x'))
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