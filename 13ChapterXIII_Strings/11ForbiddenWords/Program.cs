using System;

namespace _11ForbiddenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] forbiddenWords = Console.ReadLine().Split(',');
            string text = Console.ReadLine();
            foreach (string forbiddenWord in forbiddenWords)
            {                
                text = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}