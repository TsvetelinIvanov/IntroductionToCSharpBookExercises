using System;
using System.Text;

namespace _01StringBuilderSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputBuilder = new StringBuilder();
            while (inputBuilder.Length < 1)
            {
                Console.WriteLine("Enter a string to subtract from: ");
                inputBuilder.Append(Console.ReadLine());
                if (inputBuilder.Length < 1)
                {
                    Console.WriteLine("You have entered an empty string!");
                }
            }

            int startIndex = 0;
            bool isValidStartIndex = false;
            while (!isValidStartIndex)
            {
                Console.WriteLine("Please enter start index: ");
                isValidStartIndex = int.TryParse(Console.ReadLine(), out startIndex);
                if (!isValidStartIndex || startIndex >= inputBuilder.Length)
                {
                    isValidStartIndex = false;
                    Console.WriteLine("You have entered invalid index!");
                }
            }

            int length = 0;
            bool isValidLength = false;
            while (!isValidLength)
            {
                Console.WriteLine("Please enter subtraction length: ");
                isValidLength = int.TryParse(Console.ReadLine(), out length);
                if (!isValidLength || length > inputBuilder.Length - startIndex)
                {
                    Console.WriteLine("You have entered invalid length!");
                    isValidLength = false;
                }
            }

            StringBuilder substring = inputBuilder.Substring(startIndex, length);
            Console.WriteLine(substring);
        }
    }
}