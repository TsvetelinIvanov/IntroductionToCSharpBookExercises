using System;

namespace _10BonusPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            if (points >= 1 && points <= 3)
            {
                points *= 10;
                Console.WriteLine("Points: " + points + ".");
            }
            else if (points >= 4 && points <= 6)
            {
                points *= 100;
                Console.WriteLine("Points: " + points + ".");
            }
            else if (points >= 7 && points <= 9)
            {
                points *= 1000;
                Console.WriteLine("Points: " + points + ".");
            }
            else
            {
                Console.WriteLine("Error input! Please enter point from 1 to 9.");
            }
        }
    }
}
