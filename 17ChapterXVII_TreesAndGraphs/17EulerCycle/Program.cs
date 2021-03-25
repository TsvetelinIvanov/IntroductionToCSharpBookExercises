using System;
using System.Collections.Generic;
using System.Linq;

namespace _17EulerCycle
{
    class Program
    {
        //input example:
        //6
        //1 2
        //0 2
        //1 0 3
        //2 1
        //2 5
        //4
        //expected output: True
        public static bool[] visitedNodes;

        static void Main()
        {
            Graph graph = ReadGraph();
            bool isEulerCycle = IsEulerCycle(graph);
            Console.WriteLine(isEulerCycle);
        }

        private static Graph ReadGraph()
        {
            int verticesCount = int.Parse(Console.ReadLine());
            int[][] graphArray = new int[verticesCount][];
            visitedNodes = new bool[verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {                
                string[] currentVertexInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> currentVertexSuccessors = new List<string>();
                for (int index = 0; index < currentVertexInput.Length; index++)
                {
                    currentVertexSuccessors.Add(currentVertexInput[index]);
                }

                graphArray[i] = currentVertexSuccessors.Select(item => int.Parse(item)).ToArray();
                if (graphArray[i].Contains(i))
                {
                    throw new ApplicationException("A vertex cannot be it's own successor!");
                }
            }

            Graph graph = new Graph(graphArray);

            return graph;
        }

        private static bool IsEulerCycle(Graph graph)
        {
            Queue<int> openList = new Queue<int>();
            Queue<int> closedList = new Queue<int>();
            int currentNode = 0;
            openList.Enqueue(currentNode);
            while (openList.Count != 0)
            {
                currentNode = openList.Peek();
                int[] currentNodeNeighbours = graph.ChildNodes[currentNode];
                foreach (int neighbour in currentNodeNeighbours)
                {
                    openList.Enqueue(neighbour);
                    int[] newNeighbours = FindNewNeighbours(graph, currentNode, neighbour);
                    graph.ChildNodes[currentNode] = newNeighbours;
                    newNeighbours = FindNewNeighbours(graph, neighbour, currentNode);
                    graph.ChildNodes[neighbour] = newNeighbours;
                }

                openList.Dequeue();
                closedList.Enqueue(currentNode);
            }

            Queue<int> inputNodes = new Queue<int>();
            for (int i = 0; i < graph.ChildNodes.Count(); i++)
            {
                inputNodes.Enqueue(i);
            }

            if (closedList.Count == inputNodes.Count)
            {
                return true;
            }

            return false;
        }

        private static int[] FindNewNeighbours(Graph graph, int currentNode, int neighbour)
        {
            List<int> newNeighbours = new List<int>();

            foreach (int newNeighbour in graph.ChildNodes[currentNode])
            {
                if (newNeighbour != neighbour)
                {
                    newNeighbours.Add(newNeighbour);
                }
            }

            return newNeighbours.ToArray();
        }
    }
}