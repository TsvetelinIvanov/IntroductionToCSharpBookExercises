using System;
using System.Linq;
using System.Text;

namespace _14ReverseSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine();
            char[] punctuationChars = { ' ', '-', ',', ':', ';', '.' };
            bool endsWithPunctoation = false;
            char endPunctuation = ' ';
            if (punctuationChars.Contains(sentence[sentence.Length - 1]))
            {
                endsWithPunctoation = true;
                endPunctuation = sentence[sentence.Length - 1];
                sentence = sentence.Remove(sentence.Length - 1);                
            }

            string[] words = sentence.Split(punctuationChars, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder reversedSentenceBuilder = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversedSentenceBuilder.Append(words[i]);
                sentence = sentence.Remove(sentence.Length - words[i].Length);
                
                StringBuilder punctuaction = new StringBuilder();
                while (sentence.Length > 0 && punctuationChars.Contains(sentence[sentence.Length - 1]))
                {
                    punctuaction.Append(sentence[sentence.Length - 1]);
                    sentence = sentence.Remove(sentence.Length - 1);
                }
                
                for (int j = punctuaction.Length - 1; j >= 0; j--)
                {
                    reversedSentenceBuilder.Append(punctuaction[j]);
                }
            }

            string reversedSentence = reversedSentenceBuilder.ToString();
            if (endsWithPunctoation)
            {
                reversedSentence = endPunctuation + reversedSentence;
            }

            Console.WriteLine(reversedSentence);
        }
    }
}