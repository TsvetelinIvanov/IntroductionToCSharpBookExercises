using System;
using System.Linq;

namespace _03LeafsAndInnerNodesCount
{
    class Program
    {
        //input example:
        //8
        //1 2
        //3 4
        //4 5
        //(празен ред)
        //(празен ред)
        //6 7
        //(празен ред)
        //(празен ред)
        //expected output:
        //3
        //4
        private static int nodesCount = 0;
        private static int leafsCount = 0;
        private static bool[] visitedNodes;
        private static Tree tree;        

        static void Main(string[] args)
        {
            try
            {
                tree = CreateTree();
                DepthFirstSearch(tree.ChildNodes[0]);
                Console.WriteLine(nodesCount);
                Console.WriteLine(leafsCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Tree CreateTree()
        {
            int verticesCount = int.Parse(Console.ReadLine());
            visitedNodes = new bool[verticesCount];

            int[][] treeArray = new int[verticesCount][];

            for (int i = 0; i < verticesCount; i++)
            {                
                string[] currentVertexSuccessors = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                treeArray[i] = currentVertexSuccessors.Select(item => int.Parse(item)).ToArray();
                if (treeArray[i].Contains(i))
                {
                    throw new ApplicationException("A vertex cannot be it's own successor!");
                }
            }

            Tree tree = new Tree(treeArray);
            return tree;
        }

        private static void DepthFirstSearch(int[] successors)
        {
            for (int index = 0; index < successors.Length; index++)
            {
                int currentNode = successors[index];
                if (tree.ChildNodes[currentNode].Length > 0)
                {
                    if (!visitedNodes[currentNode])
                    {
                        nodesCount++;
                        visitedNodes[currentNode] = true;
                    }

                    DepthFirstSearch(tree.ChildNodes[currentNode]);
                }

                if (!visitedNodes[currentNode])
                {
                    leafsCount++;
                    visitedNodes[currentNode] = true;
                }
            }
        }
    }
}