using System;

namespace _03LexicographicalComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstCharArray = Console.ReadLine().ToCharArray();
            char[] secondCharArray = Console.ReadLine().ToCharArray();
            for (int i = 0; i < Math.Min(firstCharArray.Length, secondCharArray.Length); i++)
            {
                if (firstCharArray[i] < secondCharArray[i])
                {
                    Console.WriteLine(string.Join("", firstCharArray));
                    
                    return;
                }
                else if (firstCharArray[i] > secondCharArray[i])
                {
                    Console.WriteLine(string.Join("", secondCharArray));
                    
                    return;
                }
            }

            if (firstCharArray.Length < secondCharArray.Length)
            {
                Console.WriteLine(string.Join("", firstCharArray));
            }
            else if (firstCharArray.Length > secondCharArray.Length)
            {
                Console.WriteLine(string.Join("", secondCharArray));
            }
            else
            {
                Console.WriteLine("No difference");
            }
        }
    }
}
