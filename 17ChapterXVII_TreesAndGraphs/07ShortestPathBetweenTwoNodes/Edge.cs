using System;

namespace _07ShortestPathBetweenTwoNodes
{
    public class Edge : IComparable<Edge>
    {        
        public int length = 0;

        public Edge(char nodeOne, char nodeTwo)
        {
            this.EdgeNodeOne = nodeOne;
            this.EdgeNodeTwo = nodeTwo;
        }

        public char EdgeNodeOne { get; set; }

        public char EdgeNodeTwo { get; set; }

        public int CompareTo(Edge otherEdge)
        {
            return this.length.CompareTo(otherEdge.length);
        }
    }
}