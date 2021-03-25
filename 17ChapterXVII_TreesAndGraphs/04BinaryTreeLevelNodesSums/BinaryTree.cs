using System;
using System.Collections.Generic;

namespace _04BinaryTreeLevelNodesSums
{
    public class BinaryTree
    {
		private BinaryTreeNode root;

		public BinaryTree(BinaryTreeNode value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("Cannot insert null value!");
			}

			this.root = value;
		}

		public BinaryTree(int value, BinaryTree leftChild, BinaryTree rightChild)
		{			
			BinaryTreeNode leftChildNode = leftChild?.root;
			BinaryTreeNode rightChildNode = rightChild?.root;
			this.root = new BinaryTreeNode(value, leftChildNode, rightChildNode);
		}		

		public BinaryTree(int value) : this(value, null, null)
		{

		}

		public BinaryTreeNode Root
		{
			get { return this.root; }
		}

		public void PrintLevelSums()
		{
			Queue<BinaryTreeNode> currentLevelNodes = new Queue<BinaryTreeNode>();
			Queue<BinaryTreeNode> nextLevelNodes = new Queue<BinaryTreeNode>();
			List<long> sums = new List<long>();

			currentLevelNodes.Enqueue(this.root);
			while (currentLevelNodes.Count > 0)
			{
				long nextSum = 0;
				while (currentLevelNodes.Count > 0)
				{
					BinaryTreeNode currentNode = currentLevelNodes.Dequeue();
					nextSum += currentNode.Value;
					if (currentNode.LeftChild != null)
					{
						nextLevelNodes.Enqueue(currentNode.LeftChild);
					}

					if (currentNode.RightChild != null)
					{
						nextLevelNodes.Enqueue(currentNode.RightChild);
					}
				}

				sums.Add(nextSum);
				while (nextLevelNodes.Count > 0)
				{
					BinaryTreeNode currentChild = nextLevelNodes.Dequeue();
					currentLevelNodes.Enqueue(currentChild);
				}
			}

			PrintLevelSums(sums);
		}

		private void PrintLevelSums(List<long> sums)
		{
			long sumCounter = 0;
			foreach (var sum in sums)
			{
				Console.WriteLine($"Level {sumCounter} -> {sum} (sum of nodes)");
				sumCounter++;
			}
		}
	}
}