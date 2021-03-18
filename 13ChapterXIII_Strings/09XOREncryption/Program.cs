using System;
using System.Text;

namespace _09XOREncryption
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string key = Console.ReadLine();

            if (key.Length == 0)
            {
                Console.WriteLine(text);
            }
            else
            {
                string encryptedText = EncryptStringXOR(text, key);
                string stringInUnicode = DoStringToUnicode(encryptedText);
                Console.WriteLine(stringInUnicode);
            }
        }

        static string EncryptStringXOR(string text, string key)
        {
            StringBuilder encryptedText = new StringBuilder(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = (char)(text[i] ^ key[i % key.Length]);
                encryptedText.Append(currentChar);
            }

            return encryptedText.ToString();
        }

        static string DoStringToUnicode(string str)
        {
            StringBuilder unicodeBuilder = new StringBuilder();
            foreach (char ch in str)
            {
                string unicode = $"\\u{(int)ch:x4}";
                unicodeBuilder.Append(unicode);
            }

            return unicodeBuilder.ToString();
        }
    }
}