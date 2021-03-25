using System;
using System.Collections.Generic;

namespace _07ShortestPathBetweenTwoNodes
{
    public class Graph
    {
        private List<Edge> edges = new List<Edge>();

        public Graph()
        { 

        }

        public List<Edge> Edges
        {
            get { return this.edges; }
        }

        public static Graph CreateGraph()
        {
            Graph graph = new Graph();
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                string[] edgeNodes = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (edgeNodes.Length > 2)
                {
                    throw new ArgumentException("Incorrect input: Graph edges can only have two nodes.");
                }

                graph.AddEdge(Convert.ToChar(edgeNodes[0]), Convert.ToChar(edgeNodes[1]));

                line = Console.ReadLine();
            }

            return graph;
        }

        public void AddEdge(char nodeOne, char nodeTwo)
        {
            edges.Add(new Edge(nodeOne, nodeTwo));
        }        
    }
}