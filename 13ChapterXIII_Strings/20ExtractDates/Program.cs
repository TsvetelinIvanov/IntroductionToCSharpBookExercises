using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace _20ExtractDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex dateRegex = new Regex(@"(0?[1-9]|[12][0-9]|3[01])[.](0?[1-9]|1[012])[.]\d{4}");

            MatchCollection dates = dateRegex.Matches(text);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            StringBuilder datesBuilder = new StringBuilder();
            foreach (Match date in dates)
            {
                datesBuilder.AppendLine(date.ToString());
            }

            Console.Write(datesBuilder);
        }
    }
}