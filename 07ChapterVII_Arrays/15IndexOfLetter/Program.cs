using System;
using System.Linq;

namespace _15IndexOfLetter
{
    class Program
    {
        static void Main(string[] args)
        {            
            string alphabet = string.Empty;
            for (int i = 0; i < 26; i++)
            {
                alphabet += (char)(i + 'a');
            }            

            string word = Console.ReadLine().ToLower();
            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine($"{word[i]} - {alphabet.IndexOf(word[i]) + 1}");
            }
        }
    }
}