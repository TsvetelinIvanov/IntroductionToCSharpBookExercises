using System;
using System.Collections.Generic;
using System.Text;

namespace _15MinPaths
{
    public class Vertex
    {
		private int destination;
		private int length;

		public Vertex(int destination, int length)
		{
			this.Destination = destination;
			this.Length = length;
		}

		public int Destination
		{
			get { return this.destination; }
			set { this.destination = value; }
		}

		public int Length
		{
			get { return this.length; }
			set { this.length = value; }
		}
	}
}