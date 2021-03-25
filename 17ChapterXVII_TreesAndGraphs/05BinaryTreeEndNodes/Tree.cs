namespace _05BinaryTreeEndNodes
{
    public class Tree
    {
        private int[][] childNodes;

        public Tree(int[][] nodes)
        {
            this.childNodes = nodes;
        }

        public int[][] ChildNodes
        {
            get { return this.childNodes; }
            set { this.childNodes = value; }
        }
    }
}