namespace _05Shape
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height) : base(width, height)
        {

        }

        public override double CalculateSurface()
        {            
            return this.Width * this.Height / 2;
        }

        public override string ToString()
        {            
            return $"Triangle -> width: {this.Width}; height: {this.Height}; surface: {this.CalculateSurface():f3}.";
        }
    }
}