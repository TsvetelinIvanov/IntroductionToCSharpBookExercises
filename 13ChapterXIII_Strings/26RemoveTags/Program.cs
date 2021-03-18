using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _26RemoveTags
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "</html>")
            {
                htmlBuilder.Append(line.Trim() + ' ');
            }
            
            StringBuilder textBuilder = new StringBuilder();            
            int indexOfTitle = htmlBuilder.ToString().IndexOf("<title");
            int startIndex = htmlBuilder.ToString().IndexOf('>', indexOfTitle) + 1;
            int lenght = htmlBuilder.ToString().IndexOf("</title>") - startIndex;
            string title = htmlBuilder.ToString().Substring(startIndex, lenght);
            htmlBuilder = htmlBuilder.Remove(0, startIndex + lenght);
            textBuilder.AppendLine("Title: " + title);
            
            Regex tag = new Regex(@"<(?![!/]?[ABIU][>\s])[^>]*>");
            string body = tag.Replace(htmlBuilder.ToString(), "");
            textBuilder.AppendLine("Body:");
            textBuilder.Append(body.Trim());

            Console.WriteLine(textBuilder);
        }
    }
}