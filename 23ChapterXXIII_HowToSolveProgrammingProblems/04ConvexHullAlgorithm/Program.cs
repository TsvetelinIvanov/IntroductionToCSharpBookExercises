using System;
using System.Collections.Generic;
using System.IO;

namespace _04ConvexHullAlgorithm
{
    class Program
    {
        private static Point mostLeftDownPoint = new Point();
        private struct Point : IComparable<Point>
        {
            public int X { get; set; }
            public int Y { get; set; }

            public int CompareTo(Point otherPoint)
            {
                int orientation = mostLeftDownPoint.X * (this.Y - otherPoint.Y) + this.X * (otherPoint.Y - mostLeftDownPoint.Y) + otherPoint.X * (mostLeftDownPoint.Y - this.Y);

                return -orientation;
            }
        }

        private static int pointsCount;
        private static int indexOfMostDownLeftPoint = 0;
        private static List<Point> hull = new List<Point>();
        private static List<Point> points = new List<Point>();       

        static void Main(string[] args)
        {
            ReadGarden();
            points.RemoveAt(indexOfMostDownLeftPoint);
            pointsCount--;
            points.Sort();
            FindConvexHull();
            PrintConvexHull();
        }

        private static void ReadGarden()
        {
            Queue<string> garden = new Queue<string>(File.ReadAllLines("garden.txt"));
            pointsCount = int.Parse(garden.Dequeue());
            Point currentPoint = new Point();
            mostLeftDownPoint.X = int.MaxValue;
            mostLeftDownPoint.Y = int.MaxValue;
            for (int i = 0; i < pointsCount; i++)
            {
                string[] pointCoordinates = garden.Dequeue().Split();
                currentPoint.X = int.Parse(pointCoordinates[0]);
                currentPoint.Y = int.Parse(pointCoordinates[1]);
                if (currentPoint.X < mostLeftDownPoint.X)
                {
                    mostLeftDownPoint.X = currentPoint.X;
                    mostLeftDownPoint.Y = currentPoint.Y;
                    indexOfMostDownLeftPoint = i;
                }
                else if (currentPoint.X == mostLeftDownPoint.X && currentPoint.Y < mostLeftDownPoint.Y)
                {
                    mostLeftDownPoint.Y = currentPoint.Y;
                    indexOfMostDownLeftPoint = i;
                }

                points.Add(currentPoint);
            }
        }

        private static void FindConvexHull()
        {
            hull.Add(mostLeftDownPoint);
            hull.Add(points[0]);
            int j = 1;
            for (int i = 1; i < pointsCount; i++)
            {
                if (hull.Count == 1)
                {
                    hull.Add(points[i]);
                    j++; i++;
                }

                if (IsInDirection(hull[j - 1], hull[j], points[i]))
                {
                    hull.Add(points[i]);
                    j++;
                }
                else
                {
                    hull.RemoveAt(j);
                    i--;
                    j--;
                }
            }
        }

        private static bool IsInDirection(Point p1, Point p2, Point p3)
        {
            int orientation = p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y);
            if (orientation < 0)
            {
                return false;
            }

            return true;
        }

        private static void PrintConvexHull()
        {
            Console.WriteLine(hull.Count);
            Point basePoint = hull[0];
            hull.RemoveAt(0);
            hull.Reverse();
            Console.Write($"({basePoint.X}, {basePoint.Y}) - ");
            for (int i = 0; i < hull.Count; i++)
            {
                Console.Write($"({hull[i].X}, { hull[i].Y}) - ");
            }

            Console.WriteLine($"({basePoint.X}, {basePoint.Y})");
        }
    }
}