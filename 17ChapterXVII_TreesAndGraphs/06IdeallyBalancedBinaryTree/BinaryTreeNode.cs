using System;

namespace _06IdeallyBalancedBinaryTree
{
    public class BinaryTreeNode
    {
		private int value;
		private bool hasParent;
		private BinaryTreeNode leftChild;
		private BinaryTreeNode rightChild;

		public BinaryTreeNode(int value, BinaryTreeNode leftChild, BinaryTreeNode rightChild)
		{			
			this.value = value;
			this.LeftChild = leftChild;
			this.RightChild = rightChild;
		}

		public BinaryTreeNode(int value) : this(value, null, null)
		{

		}

		public int Value
		{
			get { return this.value; }
			set { this.value = value; }
		}

		public BinaryTreeNode LeftChild
		{
			get { return this.leftChild; }
			set
			{
				if (value == null)
				{
					return;
				}

				if (value.hasParent)
				{
					throw new ArgumentException("The node already has a parent!");
				}

				value.hasParent = true;
				this.leftChild = value;
			}
		}

		public BinaryTreeNode RightChild
		{
			get { return this.rightChild; }
			set
			{
				if (value == null)
				{
					return;
				}

				if (value.hasParent)
				{
					throw new ArgumentException("The node already has a parent!");
				}

				value.hasParent = true;
				this.rightChild = value;
			}
		}
	}
}