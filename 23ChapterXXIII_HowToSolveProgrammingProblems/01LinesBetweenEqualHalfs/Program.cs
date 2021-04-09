using System;
using System.Linq;

namespace _01LinesBetweenEqualHalfs
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointsCount = int.Parse(Console.ReadLine());
            int[] pointsHorizontalCoordinatesX = new int[pointsCount];
            int[] pointsVerticalCoordinatesY = new int[pointsCount];
            for (long i = 0; i < pointsCount; i++)
            {
                int[] pointCoordinates = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                pointsHorizontalCoordinatesX[i] = pointCoordinates[0];
                pointsVerticalCoordinatesY[i] = pointCoordinates[1];
            }

            Array.Sort(pointsHorizontalCoordinatesX);
            Array.Sort(pointsVerticalCoordinatesY);

            int horizontalLinesCount = CountLinesBetweenEqualHalfs(pointsCount, pointsHorizontalCoordinatesX);
            int verticalLinesCount = CountLinesBetweenEqualHalfs(pointsCount, pointsVerticalCoordinatesY);

            Console.WriteLine("Horizontal lines: " + horizontalLinesCount);
            Console.WriteLine("Vertical lines: " + verticalLinesCount);
        }

        private static int CountLinesBetweenEqualHalfs(int pointsCount, int[] pointsDimensionCoordinates)
        {
            int linesCount = 0;
            long firstSideCount = 0;
            long secondSideCount = pointsCount;
            long pointsOnLineCount = 1;
            for (long i = 0; i < pointsCount - 1; i++)
            {
                secondSideCount--;
                if (pointsDimensionCoordinates[i] == pointsDimensionCoordinates[i + 1])
                {
                    pointsOnLineCount++;
                    continue;
                }

                if (firstSideCount == secondSideCount)
                {
                    linesCount++;
                }

                firstSideCount += pointsOnLineCount;
                pointsOnLineCount = 1;
                if (pointsDimensionCoordinates[i + 1] - pointsDimensionCoordinates[i] > 1)
                {
                    if (firstSideCount == secondSideCount)
                    {
                        linesCount += (pointsDimensionCoordinates[i + 1] - pointsDimensionCoordinates[i] - 1);
                    }
                }
            }

            return linesCount;
        }
    }
}