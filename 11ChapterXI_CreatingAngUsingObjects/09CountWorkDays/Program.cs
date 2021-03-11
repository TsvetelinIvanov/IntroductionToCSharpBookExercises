using System;

namespace _09CountWorkDays
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYear = int.Parse(Console.ReadLine());
            int startMonth = int.Parse(Console.ReadLine());
            int startDay = int.Parse(Console.ReadLine());
            DateTime start = new DateTime(startYear, startMonth, startDay);
            int endYear = int.Parse(Console.ReadLine());
            int endMonth = int.Parse(Console.ReadLine());
            int endDay = int.Parse(Console.ReadLine());
            DateTime end = new DateTime(endYear, endMonth, endDay);
            
            int daysCount = (int)(end - start).TotalDays;
            int weeksCount = daysCount / 7;
            
            if (7 - (daysCount % 7) <= (int)start.DayOfWeek)
            {
                daysCount--;
            }
                
            if (7 - (daysCount % 7) <= (int)start.DayOfWeek)
            {
                daysCount--;
            }                
            
            for (int i = startYear; i <= endYear; i++)
            {
                int year = i;

                DateTime[] holidays = new DateTime[10];
                holidays[0] = new DateTime(year, 3, 3);
                holidays[1] = new DateTime(year, 5, 1);
                holidays[2] = new DateTime(year, 5, 6);
                holidays[3] = new DateTime(year, 5, 24);
                holidays[4] = new DateTime(year, 9, 6);
                holidays[5] = new DateTime(year, 9, 22);
                holidays[6] = new DateTime(year, 11, 1);
                holidays[7] = new DateTime(year, 12, 24);
                holidays[8] = new DateTime(year, 12, 26);
                holidays[9] = new DateTime(year, 12, 25);
                foreach (DateTime holiday in holidays)
                {
                    if ((holiday > start) && (holiday < end) && (holiday.DayOfWeek != DayOfWeek.Saturday) && (holiday.DayOfWeek != DayOfWeek.Sunday))
                    {
                        daysCount--;
                    }                        
                }
            }
            
            daysCount -= weeksCount * 2;
            Console.WriteLine(daysCount);
        }
    }
}