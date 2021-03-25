using System;
using System.Collections.Generic;
using System.Linq;

namespace _01NumberInTree
{
    class Program
    {
        //input example:
        //1
        //8
        //1 - 2 2 - 1
        //3 - 1 4 - 1
        //5 - 2 6 - 3
        //  (празен ред)
        //7 - 1
        //(празен ред)
        //(празен ред)
        //(празен ред)
        //expected output: 1->4
        public static int number;
        public static int occurencesCount = 0;
        public static int[] nodeValues;
        public static bool[] visitedNodes;
        public static Tree tree;

        static void Main(string[] args)
        {
            try
            {
                tree = ReadTree();
                DepthFirstSearch(tree.ChildNodes[0]);
                Console.WriteLine($"{number}->{occurencesCount}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Tree ReadTree()
        {
            number = int.Parse(Console.ReadLine());
            int vertexCount = int.Parse(Console.ReadLine());
            int[][] graphArray = new int[vertexCount][];
            nodeValues = new int[vertexCount];
            visitedNodes = new bool[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {                
                string[] currentVertexInput = Console.ReadLine().Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> currentVertexSuccessors = new List<string>();
                for (int index = 0; index < currentVertexInput.Length; index++)
                {
                    if (index % 2 == 0)
                    {
                        currentVertexSuccessors.Add(currentVertexInput[index]);
                    }
                    else
                    {
                        nodeValues[int.Parse(currentVertexInput[index - 1])] = int.Parse(currentVertexInput[index]);
                    }
                }

                graphArray[i] = currentVertexSuccessors.Select(item => int.Parse(item)).ToArray();
                if (graphArray[i].Contains(i))
                {
                    throw new ApplicationException("A vertex cannot be it's own successor");
                }
            }

            Tree tree = new Tree(graphArray);

            return tree;
        }

        private static void DepthFirstSearch(int[] successors)
        {
            for (int index = 0; index < successors.Length; index++)
            {
                int currentNode = successors[index];
                if (nodeValues[currentNode] == number)
                {
                    if (!visitedNodes[currentNode])//Exclude duplicates
                    {
                        occurencesCount++;
                    }
                }

                visitedNodes[currentNode] = true;
                if (tree.ChildNodes.Length > currentNode)
                {
                    DepthFirstSearch(tree.ChildNodes[currentNode]);
                }
            }
        }
    }
}