using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
            string path = "file.txt";
            string text = File.ReadAllText(path).ToLower();
            //string text = Console.ReadLine().ToLower();
            string[] words = Regex.Split(text, @"\W+");
            foreach (string word in words.Where(w => w != string.Empty))     
            {
                if (!wordsCounts.ContainsKey(word))
                {
                    wordsCounts.Add(word, 0);
                }

                wordsCounts[word]++;
            }

            foreach (KeyValuePair<string, int> wordCount in wordsCounts.OrderBy(wc => wc.Value))
            {
                Console.WriteLine(wordCount.Key + " -> " + wordCount.Value);
            }
        }
    }
}