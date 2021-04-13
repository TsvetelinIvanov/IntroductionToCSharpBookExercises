using System;
using System.Collections.Generic;
using System.Text;

namespace _01CountWordsInText
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            List<string> uppercaseWords = new List<string>();
            List<string> lowercaseWords = new List<string>();

            string text = Console.ReadLine();
            StringBuilder wordBuilder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    wordBuilder.Append(text[i]);
                }
                else if (wordBuilder.Length > 0)
                {
                    string word = wordBuilder.ToString();
                    wordBuilder.Clear();
                    words.Add(word);
                    if (word == word.ToUpper())
                    {
                        uppercaseWords.Add(word);
                    }
                    else if(word == word.ToLower())
                    {
                        lowercaseWords.Add(word);
                    }
                }
            }

            if (wordBuilder.Length > 0)
            {
                string word = wordBuilder.ToString();                
                words.Add(word);
                if (word == word.ToUpper())
                {
                    uppercaseWords.Add(word);
                }
                else if (word == word.ToLower())
                {
                    lowercaseWords.Add(word);
                }
            }

            Console.WriteLine("The count of words is: " + words.Count);
            Console.WriteLine("Words: " + string.Join(", ", words) + ".");
            Console.WriteLine("The count of uppercase words is: " + uppercaseWords.Count);
            Console.WriteLine("Uppercase words: " + string.Join(", ", uppercaseWords) + ".");
            Console.WriteLine("The count of lowercase words is: " + lowercaseWords.Count);
            Console.WriteLine("Lowercase words: " + string.Join(", ", lowercaseWords) + ".");
        }
    }
}