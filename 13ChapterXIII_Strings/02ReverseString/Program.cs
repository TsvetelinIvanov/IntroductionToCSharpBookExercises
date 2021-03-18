using System;

namespace _02ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string reversedString = string.Empty;
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                reversedString += inputString[i];
            }

            Console.WriteLine(reversedString);
        }
    }
}