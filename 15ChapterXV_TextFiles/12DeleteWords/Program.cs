using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _12DeleteWords
{
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                string text = string.Empty;
                using (StreamReader textReader = new StreamReader("text.txt"))
                {
                    text = textReader.ReadToEnd();
                    using (StreamReader wordsReader = new StreamReader("words.txt"))
                    {
                        string[] words = wordsReader.ReadToEnd().Split(Environment.NewLine);
                        foreach (string word in words)
                        {
                            text = Regex.Replace(text, word, string.Empty);
                        }                        
                    }                    
                }

                using (StreamWriter textWriter = new StreamWriter("text.txt", false))
                {
                    textWriter.Write(text);
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