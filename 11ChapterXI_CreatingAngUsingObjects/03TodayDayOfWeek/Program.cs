using System;

namespace _03TodayDayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today.DayOfWeek);
        }
    }
}