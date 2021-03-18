using System;
using System.Collections.Generic;

namespace _22CountLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] >= 'A' && text[i] <= 'Z') || (text[i] >= 'a' && text[i] <= 'z'))
                {
                    if (!letters.ContainsKey(text[i]))
                    {
                        letters.Add(text[i], 0);
                    }

                    letters[text[i]]++;
                }
            }

            foreach (KeyValuePair<char, int> letter in letters)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value}");
            }
        }
    }
}