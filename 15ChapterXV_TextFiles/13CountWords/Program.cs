using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _13CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<string, int> wordsCounts = new Dictionary<string, int>();
                using (StreamReader wordsReader = new StreamReader("words.txt"))
                {
                    string[] words = wordsReader.ReadToEnd().Split(Environment.NewLine);
                    foreach (string word in words)
                    {
                        if (!wordsCounts.ContainsKey(word))
                        {
                            wordsCounts.Add(word, 0);
                        }
                    }
                }

                using (StreamReader textReader = new StreamReader("text.txt"))
                {
                    string text = textReader.ReadToEnd();
                    string[] textWords = Regex.Split(text, @"\W+");
                    foreach (string textWord in textWords)
                    {
                        if (wordsCounts.ContainsKey(textWord))
                        {
                            wordsCounts[textWord]++;
                        }
                    }
                }

                StringBuilder resultBuilder = new StringBuilder();
                foreach (KeyValuePair<string, int> wordCount in wordsCounts.OrderByDescending(wc => wc.Value))
                {
                    resultBuilder.AppendLine($"{wordCount.Key} -> {wordCount.Value}");
                }

                using (StreamWriter resultWriter = new StreamWriter("result.txt", false))
                {
                    resultWriter.Write(resultBuilder.ToString().TrimEnd());
                }
            }
            catch (FileNotFoundException fne)
            {
                Console.WriteLine(fne.Message);
            }
            catch (FileLoadException fle)
            {
                Console.WriteLine(fle.Message);
            }
            catch (FieldAccessException fae)
            {
                Console.WriteLine(fae.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (OutOfMemoryException oome)
            {
                Console.WriteLine(oome.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}