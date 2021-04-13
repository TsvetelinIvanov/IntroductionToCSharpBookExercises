using System;
using System.Collections.Generic;
using System.Text;

namespace _02CountSubstrings
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();
            SortedDictionary<string, int> substrings = new SortedDictionary<string, int>();
            //If we wish to preserve the input order:
            //Dictionary<string, int> substrings = new Dictionary<string, int>();
            StringBuilder baseSubstring = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];
                baseSubstring.Append(character);
                for (int j = 0; j < baseSubstring.Length; j++)
                {
                    StringBuilder currentSubstring = Substring(baseSubstring, j);
                    SaveSubstring(substrings, currentSubstring);
                }
            }

            foreach (KeyValuePair<string, int> substring in substrings)
            {
                Console.WriteLine($"{substring.Key} -> {substring.Value} times");
            }
        }        

        private static StringBuilder Substring(StringBuilder text, int startIndex)
        {
            StringBuilder substring = new StringBuilder();
            for (int i = startIndex; i < text.Length; i++)
            {
                char character = text[i];
                substring.Append(character);
            }

            return substring;
        }

        private static void SaveSubstring(SortedDictionary<string, int> substrings, StringBuilder substringBuilder)
        {
            if (substringBuilder.Length == 0)
            {
                return;
            }

            string substring = substringBuilder.ToString();
            if (!substrings.ContainsKey(substring))
            {
                substrings.Add(substring, 0);                
            }

            substrings[substring]++;
        }
    }
}