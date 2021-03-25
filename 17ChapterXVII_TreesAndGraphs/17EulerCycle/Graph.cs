namespace _17EulerCycle
{
    public class Graph
    {
        private int[][] childNodes;

        public Graph(int[][] nodes)
        {
            this.ChildNodes = nodes;
        }

        public int[][] ChildNodes
        {
            get { return this.childNodes; }
            set { this.childNodes = value; }
        }
    }
}