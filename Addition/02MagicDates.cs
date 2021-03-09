using System;

namespace _02MagicDates
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYear = int.Parse(Console.ReadLine());
            int endYear = int.Parse(Console.ReadLine());
            int magicWeight = int.Parse(Console.ReadLine());
            int dateWeight = 0;
            DateTime currentDate = new DateTime(startYear, 1, 1);
            bool printed = false;

            while (currentDate.Year <= endYear)
            {                
                int d1 = currentDate.Day / 10;
                int d2 = currentDate.Day % 10;
                int d3 = currentDate.Month / 10;
                int d4 = currentDate.Month % 10;
                int d5 = currentDate.Year / 1000;
                int d6 = (currentDate.Year / 100) % 10;
                int d7 = (currentDate.Year / 10) % 10;
                int d8 = currentDate.Year % 10;
                dateWeight = d1 * (d2 + d3 + d4 + d5 + d6 + d7 + d8) + d2 * (d3 + d4 + d5 + d6 + d7 + d8) +
                    d3 * (d4 + d5 + d6 + d7 + d8) + d4 * (d5 + d6 + d7 + d8) + d5 * (d6 + d7 + d8) +
                    d6 * (d7 + d8) + d7 * d8;

                if (magicWeight == dateWeight)
                {
                    Console.WriteLine(($"{d1}{d2}-{d3}{d4}-{d5}{d6}{d7}{d8}"));
                    printed = true;
                }

                currentDate = currentDate.AddDays(1);
            }

            if (!printed)
            {
                Console.WriteLine("No");
            }                
        }
    }
}
