using System;

namespace _05SubstringCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string substring = Console.ReadLine().ToLower();
            int substringCount = GetSubstringCount(text, substring);
            Console.WriteLine(substringCount);
        }

        private static int GetSubstringCount(string text, string substring)
        {
            int count = 0;
            if (text.Length == 0 || substring.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < text.Length; i++)
            {
                int currentIndex = text.IndexOf(substring, i);
                if (currentIndex >= 0)
                {
                    count++;
                    i = currentIndex;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}