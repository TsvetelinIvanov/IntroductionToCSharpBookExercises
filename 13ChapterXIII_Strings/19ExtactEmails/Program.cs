using System;
using System.Text.RegularExpressions;

namespace _19ExtactEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] emails = ExtractEmails(text);
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }

        private static string[] ExtractEmails(string input)
        {
            string pattern = @"(\b[A-Z0-9._-]+)@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";

            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

            string[] emails = new string[matches.Count];
            int i = 0;
            foreach (Match match in matches)
            {
                emails[i] = match.ToString();
                i++;
            }

            return emails;
        }
    }
}