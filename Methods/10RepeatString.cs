using System;

namespace _10RepeatString
{
    class Program
    {        
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            string repeatedString = RepeatString(str, count);
            Console.WriteLine(repeatedString);
        }

        static string RepeatString(string str, int count)
        {
            string repeatedString = string.Empty;
            for (int i = 0; i < count; i++)
            {
                repeatedString += str;
            }

            return repeatedString;
        }
    }
}
