using System;
using System.Collections.Generic;

namespace _02NodesWithKChildren
{
    public class Tree<T>
    {
		private TreeNode<T> root;

		public Tree(TreeNode<T> root)
		{
			if (root == null)
			{
				throw new ArgumentNullException("Cannot insert null value!");
			}

			this.root = root;
		}

		public Tree(T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("Cannot insert null value!");
			}

			this.root = new TreeNode<T>(value);
		}		

		public Tree(T value, params Tree<T>[] children) : this(value)
		{
			foreach (Tree<T> child in children)
			{
				this.root.AddChild(child.root);
			}
		}

		public TreeNode<T> Root
		{
			get { return this.root; }
		}		

		public List<T> GetSubtreesWithKNodes(uint k)
		{
			List<T> subtreesWithKNodes = new List<T>();
			Stack<TreeNode<T>> nodesToTraverse = new Stack<TreeNode<T>>();
			nodesToTraverse.Push(this.root);
			while (nodesToTraverse.Count > 0)
			{
				TreeNode<T> currentNode = nodesToTraverse.Pop();
				foreach (TreeNode<T> child in currentNode.Children)
				{
					int currentNodeChildrenCount = CountNodesWithDepthFirstSearch(child);
					if (currentNodeChildrenCount > k)
					{
						nodesToTraverse.Push(child);
					}
					else if (currentNodeChildrenCount == k)
					{
						subtreesWithKNodes.Add(child.Value);
					}
				}
			}

			return subtreesWithKNodes;
		}

		private int CountNodesWithDepthFirstSearch(TreeNode<T> root)
		{
			int nodesCount = 0;
			Stack<TreeNode<T>> currentNodes = new Stack<TreeNode<T>>();
			currentNodes.Push(root);

			while (currentNodes.Count > 0)
			{
				TreeNode<T> currentNode = currentNodes.Pop();
				foreach (TreeNode<T> child in currentNode.Children)
				{
					currentNodes.Push(child);
					nodesCount++;
				}
			}

			return nodesCount;
		}
	}
}