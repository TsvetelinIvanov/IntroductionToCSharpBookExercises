using System;

namespace _05Shape
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double width, double height) : base(width, height)
        {
            if (width != height)
            {
                throw new ArgumentException("The given width and height must be equal to assign the radius!");
            }

            this.radius = width;            
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override string ToString()
        {
            return $"Circle -> radius: {this.radius}; surface: {this.CalculateSurface():f3}.";
        }
    }
}