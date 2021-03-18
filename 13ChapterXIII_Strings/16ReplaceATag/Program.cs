using System;
using System.Text;

namespace _16ReplaceATag
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder replacedTagsText = new StringBuilder();
            int i = 0;
            while (i >= 0 && text[i..].Contains("<a href="))
            {                
                int lenght = text.IndexOf("<a href=", i) - i;
                replacedTagsText.Append(text, i, lenght);
                replacedTagsText.Append("[URL=");

                i = text.IndexOf("<a href=", i);
                lenght = text.IndexOf('>', i) - i - 10;
                replacedTagsText.Append(text, i + 9, lenght);
                replacedTagsText.Append(']');

                i = text.IndexOf('>', i) + 1;
            }

            replacedTagsText.Append(text[i..]);
            replacedTagsText.Replace("</a>", "[/URL]");

            Console.WriteLine(replacedTagsText);
        }
    }
}