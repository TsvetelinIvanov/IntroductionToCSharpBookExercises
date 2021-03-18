using System;
using System.Text.RegularExpressions;

namespace _13URLAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<protocol>[a-zA-Z]*)://(?<domain>[-a-zA-Z0-9.]+)(?<resource>/[-a-zA-Z0-9+&@#/%=~_|!:,.;]*)?$";
            string url = Console.ReadLine();

            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);
            if (!match.Success)
            {
                Console.WriteLine("Wrong URL!");
            }
            else
            {
                string protocol = match.Groups["protocol"].ToString();
                string domain = match.Groups["domain"].ToString();
                string resource = match.Groups["resource"].ToString();

                Console.WriteLine($"[protocol]={protocol}");
                Console.WriteLine($"[domain]={domain}");
                Console.WriteLine($"[resource]={resource}");
            }
        }
    }
}