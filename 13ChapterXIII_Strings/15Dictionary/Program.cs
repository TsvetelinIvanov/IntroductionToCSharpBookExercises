using System;
using System.Collections.Generic;

namespace _15Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            int wordsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < wordsCount; i++)
            {
                string[] wordAndDescription = Console.ReadLine().Split(" - ");
                dictionary[wordAndDescription[0].ToLower()] = wordAndDescription[1];
            }

            string word;
            while ((word = Console.ReadLine()) != "End")
            {
                if (dictionary.ContainsKey(word.ToLower()))
                {
                    Console.WriteLine($"{word} - {dictionary[word.ToLower()]}");
                }
                else
                {
                    Console.WriteLine($"Our dictionary does't contain the word: {word}!");
                }
            }
        }
    }
}