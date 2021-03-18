using System;

namespace _06UpcaseTags
{
    class Program
    {
        static void Main(string[] args)
        {
            const string OpenTag = "<upcase>";
            const string CloseTag = "</upcase>";

            string text = Console.ReadLine();
            while (text.ToLower().Contains(OpenTag) && text.ToLower().Contains(CloseTag))
            {
                int openIndex = text.ToLower().IndexOf(OpenTag);
                int closeIndex = text.ToLower().IndexOf(CloseTag);
                int lenght = closeIndex - openIndex + CloseTag.Length;

                int startIndex = openIndex + OpenTag.Length;
                int lenghtOfSubstring = lenght - OpenTag.Length - CloseTag.Length;
                string substring = text.Substring(startIndex, lenghtOfSubstring).ToUpper();

                text = text.Remove(openIndex, lenght);
                text = text.Insert(openIndex, substring);
            }

            Console.WriteLine(text);
        }
    }
}