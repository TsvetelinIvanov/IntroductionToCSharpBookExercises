using System;
using System.Linq;

namespace _05Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] rectangleData = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] triangleData = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] circleData = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Shape[] shapes = new Shape[]
            {
                new Rectangle(rectangleData[0], rectangleData[1]),
                new Triangle(triangleData[0], triangleData[1]),
                new Circle(circleData[0], circleData[1])
            };

            double[] surfaces = new double[shapes.Length];
            for (int i = 0; i < shapes.Length; i++)
            {
                surfaces[i] = Math.Round(shapes[i].CalculateSurface(), 3);
            }

            Console.WriteLine(string.Join(Environment.NewLine, shapes.Select(s => s)));
            Console.WriteLine(string.Join("; ", surfaces));
        }
    }
}