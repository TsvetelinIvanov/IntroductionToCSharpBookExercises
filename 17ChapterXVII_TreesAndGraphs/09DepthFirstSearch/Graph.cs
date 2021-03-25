using System;

namespace _09DepthFirstSearch
{
    public class Graph
    {
        internal const int MaxNode = 1024;
        private int[][] childNodes;

        public Graph(int[][] childNodes)
        {
            this.childNodes = childNodes;
        }

        public void DepthFirstSearch(int node, bool[] visitedNodes)
        {
            if (!visitedNodes[node])
            {
                visitedNodes[node] = true;
                Console.Write(node + " ");
                foreach (int childNode in this.childNodes[node])
                {
                    DepthFirstSearch(childNode, visitedNodes);
                }
            }
        }
    }
}