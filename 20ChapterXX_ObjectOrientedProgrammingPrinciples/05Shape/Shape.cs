namespace _05Shape
{
    public abstract class Shape
    {
        private double width;
        private double height;        

        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public Shape() : this(0, 0)
        {

        }

        public double Width => this.width;

        public double Height => this.height;
        
        public virtual double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}