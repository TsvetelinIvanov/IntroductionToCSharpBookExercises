using System;
using System.Collections.Generic;

namespace _06IdeallyBalancedBinaryTree
{
    public class BinaryTree
    {
		private BinaryTreeNode root;

		public BinaryTree(BinaryTreeNode binaryTreeNode)
		{
			if (binaryTreeNode == null)
			{
				throw new ArgumentNullException("Cannot insert null value!");
			}

			this.root = binaryTreeNode;
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

		public bool IsIdeallyBalanced()
		{
			return IsIdeallyBalanced(this.root);
		}

		private bool IsIdeallyBalanced(BinaryTreeNode root)
		{
			long leftTreeNodesCount = 0;
			long rightTreeNodesCount = 0;

			if (root == null)
			{
				return true;
			}

			if (root.LeftChild != null)
			{
				leftTreeNodesCount = CountNodesWithDepthFirstSearch(root.LeftChild);
			}

			if (root.RightChild != null)
			{
				rightTreeNodesCount = CountNodesWithDepthFirstSearch(root.RightChild);
			}

			if (Math.Abs(leftTreeNodesCount - rightTreeNodesCount) <= 1 &&
				IsIdeallyBalanced(root.LeftChild) == true &&
				IsIdeallyBalanced(root.RightChild) == true)
			{
				return true;
			}

			return false;
		}

		private int CountNodesWithDepthFirstSearch(BinaryTreeNode root)
		{
			int nodesCount = 1;
			Stack<BinaryTreeNode> currentNodes = new Stack<BinaryTreeNode>();
			currentNodes.Push(root);
			while (currentNodes.Count > 0)
			{
				BinaryTreeNode currentNode = currentNodes.Pop();
				if (currentNode.LeftChild != null)
				{
					currentNodes.Push(currentNode.LeftChild);
					nodesCount++;
				}

				if (currentNode.RightChild != null)
				{
					currentNodes.Push(currentNode.RightChild);
					nodesCount++;
				}
			}

			return nodesCount;
		}
	}
}