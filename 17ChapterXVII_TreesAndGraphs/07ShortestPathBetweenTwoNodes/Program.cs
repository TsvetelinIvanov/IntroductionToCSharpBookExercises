using Magnum.Collections;
using System;

namespace _07ShortestPathBetweenTwoNodes
{    
    class Program
    {
        //input example:
        //x f
        //x d
        //f d
        //f j
        //f g
        //d g
        //j g
        //g y
        //(празен ред)
        //expected output: 3
        static void Main(string[] args)
        {
            Graph graph = Graph.CreateGraph();
            PrintShortestPathLegth(graph, 'x', 'y');
        }

        public static void PrintShortestPathLegth(Graph graph, char startNode, char goalNode)
        {            
            int length = 1;
            OrderedBag<Edge> openEdges = new OrderedBag<Edge>();
            char currentNode = startNode;
            bool[] visitedEdges = new bool[graph.Edges.Count];
            for (int index = 0; index < graph.Edges.Count; index++)
            {
                if ((graph.Edges[index].EdgeNodeOne == currentNode) || (graph.Edges[index].EdgeNodeTwo == currentNode))
                {
                    Edge temp = graph.Edges[index];
                    visitedEdges[index] = true;
                    temp.length = length;
                    openEdges.Add(temp);
                }
            }

            while (openEdges.Count != 0)
            {
                Edge currentEdge = openEdges.GetFirst();
                char nextNode = currentEdge.EdgeNodeTwo;
                openEdges.RemoveFirst();
                if (currentEdge.EdgeNodeOne == goalNode || currentEdge.EdgeNodeTwo == goalNode)
                {
                    Console.WriteLine(currentEdge.length);
                    
                    return;
                }

                length = currentEdge.length + 1;
                for (int index = 0; index < graph.Edges.Count; index++)
                {
                    if (!visitedEdges[index])
                    {
                        if ((graph.Edges[index].EdgeNodeOne == nextNode) || (graph.Edges[index].EdgeNodeTwo == nextNode))
                        {
                            Edge temp = graph.Edges[index];
                            visitedEdges[index] = true;
                            temp.length = length;
                            openEdges.Add(temp);
                        }
                    }
                }
            }
        }
    }
}
