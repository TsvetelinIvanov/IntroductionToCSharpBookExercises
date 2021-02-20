using System;

namespace _10_BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            try
            {
                switch (points)
                {
                    case 1:
                    case 2:
                    case 3:
                        points *= 10; Console.WriteLine("Points: " + points + ".");
                        break;
                    case 4:
                    case 5:
                    case 6:
                        points *= 100; Console.WriteLine("Points: " + points + ".");
                        break;
                    case 7:
                    case 8:
                    case 9:
                        points *= 1000; Console.WriteLine("Points: " + points + ".");
                        break;
                    default:
                        Console.WriteLine("Error input! Please enter point from 1 to 9.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
