using System;
using System.Text;

namespace _10WordInSentences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentences = Console.ReadLine().Split('.');
            string word = Console.ReadLine();             
            StringBuilder sentencesWithWord = new StringBuilder();

            foreach (string sentance in sentences)
            {
                StringBuilder currnetWord = new StringBuilder();
                foreach (char ch in sentance + '.')
                {
                    if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                    {
                        currnetWord.Append(ch);
                    }
                    else
                    {
                        if (currnetWord.ToString().ToLower() == word.ToLower())
                        {
                            sentencesWithWord.AppendLine(sentance.Trim() + '.');
                            break;
                        }

                        currnetWord.Clear();
                    }
                }
            }

            Console.Write(sentencesWithWord);
        }
    }
}