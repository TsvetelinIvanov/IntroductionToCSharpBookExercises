using System;
using System.Collections.Generic;
using System.Text;

namespace _09DepthFirstSearch
{
    public class GraphDepthFirstSearchTest
    {
        public static void TestGraphDepthFirstSearch()
        {
            const int startNode = 0;
            bool[] visitedNodes = new bool[64];
            int[][] graphArray = new int[][]
            {
                new int[]{ 1, 2 },
                new int[]{ 0, 2 },
                new int[]{ 1, 0 }                
            };

            Graph graph = new Graph(graphArray);
            graph.DepthFirstSearch(startNode, visitedNodes);
        }
    }
}