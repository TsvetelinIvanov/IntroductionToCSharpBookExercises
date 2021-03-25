using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BinaryTreeEndNodes
{
    class Program
    {
        //input example:
        //9
        //1 2
        //3 4
        //5 6
        //(празен ред)
        //(празен ред)
        //7 8
        //(празен ред)
        //(празен ред)
        //(празен ред)
        //expected output: 1, 5        
        private static Tree tree;
        private static bool[] hasGrandChildren;
        private static readonly List<int> endNodesValues = new List<int>();       

        static void Main(string[] args)
        {
            try
            {
                tree = CreateTree();
                DepthFirstSearch(0, tree.ChildNodes[0]);
                endNodesValues.Sort();
                Console.WriteLine(string.Join(", ", endNodesValues));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Tree CreateTree()
        {
            int verticesCount = int.Parse(Console.ReadLine());
            hasGrandChildren = new bool[verticesCount];
            int[][] treeArray = new int[verticesCount][];
            for (int i = 0; i < verticesCount; i++)
            {                
                string[] currentVertexSuccessors = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (currentVertexSuccessors.Length > 2)
                {
                    throw new ArgumentException("Binary tree vertex can only have two successors!");
                }

                treeArray[i] = currentVertexSuccessors.Select(item => int.Parse(item)).ToArray();
                if (treeArray[i].Contains(i))
                {
                    throw new ApplicationException("A vertex cannot be it's own successor!");
                }
            }

            Tree newTree = new Tree(treeArray);

            return newTree;
        }

        private static void DepthFirstSearch(int root, int[] successors)
        {
            for (int index = 0; index < successors.Length; index++)
            {
                int currentNode = successors[index];
                if (tree.ChildNodes[currentNode].Length > 0)
                {
                    hasGrandChildren[root] = true;
                    endNodesValues.Remove(root);
                    DepthFirstSearch(currentNode, tree.ChildNodes[currentNode]);
                }
                else
                {
                    if (!endNodesValues.Contains(root) && !hasGrandChildren[root])
                    {
                        endNodesValues.Add(root);
                    }
                }
            }
        }        
    }
}