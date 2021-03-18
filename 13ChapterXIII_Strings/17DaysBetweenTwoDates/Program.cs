using System;
using System.Globalization;

namespace _17DaysBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "d.M.yyyy";
            string firstDateString = Console.ReadLine();
            string secondDateString = Console.ReadLine();
            try
            {
                DateTime firstDate = DateTime.ParseExact(firstDateString, format, provider);
                DateTime secondDate = DateTime.ParseExact(secondDateString, format, provider);
                TimeSpan distance = firstDate - secondDate;
                Console.WriteLine(Math.Abs(distance.Days));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalide date!");
            }
        }
    }
}