using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _23CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> wordsCounts = new SortedDictionary<string, int>();
            string text = Console.ReadLine();
            string[] words = Regex.Split(text, @"\W+");
            foreach (string word in words)
            {
                if (!wordsCounts.ContainsKey(word))
                {
                    wordsCounts.Add(word, 0);
                }

                wordsCounts[word]++;
            }

            foreach (KeyValuePair<string, int> wordCount in wordsCounts.Where(wc => wc.Key != string.Empty))
            {
                Console.WriteLine($"{wordCount.Key} -> {wordCount.Value}");
            }
        }
    }
}