using System;

namespace _21ExtractPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] separators = { '.', ',', ' ', '!', '?', '-', '_' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (IsPalindrome(word))
                {
                    Console.WriteLine(word);
                }
            }
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}