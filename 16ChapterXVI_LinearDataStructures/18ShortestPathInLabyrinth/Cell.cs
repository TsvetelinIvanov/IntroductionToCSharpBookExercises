namespace _18ShortestPathInLabyrinth
{
    public class Cell
    {
		private int row;
		private int col;

		public Cell() 
		{ 

		}

		public Cell(int row, int col)
		{
			this.row = row;
			this.col = col;
		}

		public int Row
		{
			get { return this.row; }
			set { this.row = value; }
		}

		public int Col
		{
			get { return this.col; }
			set { this.col = value; }
		}
	}
}