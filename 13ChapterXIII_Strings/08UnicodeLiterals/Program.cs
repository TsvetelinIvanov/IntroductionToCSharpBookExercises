using System;
using System.Text;

namespace _08UnicodeLiterals
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder unicodeBuilder = new StringBuilder();

            foreach (char c in text)
            {
                unicodeBuilder.AppendFormat("\\u{0:x4}", (int)c);
            }

            Console.WriteLine(unicodeBuilder);
        }
    }
}