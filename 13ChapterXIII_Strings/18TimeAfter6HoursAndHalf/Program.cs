using System;
using System.Globalization;

namespace _18TimeAfter6HoursAndHalf
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            DateTime date = DateTime.ParseExact(input, "d.M.yyyy H:mm:ss", CultureInfo.InvariantCulture);

            date = date.AddHours(6);
            date = date.AddMinutes(30);

            Console.WriteLine($"{date:dd.MM.yyyy HH:mm:ss}");
        }
    }
}