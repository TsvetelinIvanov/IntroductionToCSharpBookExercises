using System;
using System.Text;

namespace _24RemoveEqualLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder removedEqualLettersBuilder = new StringBuilder(input);

            for (int i = 1; i < removedEqualLettersBuilder.Length; i++)
            {
                bool isLatinLetter = removedEqualLettersBuilder[i] >= 'a' && removedEqualLettersBuilder[i] <= 'z' ||  removedEqualLettersBuilder[i] >= 'A' && removedEqualLettersBuilder[i] <= 'Z';
                if (removedEqualLettersBuilder[i] == removedEqualLettersBuilder[i - 1] && isLatinLetter)
                {
                    removedEqualLettersBuilder.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(removedEqualLettersBuilder);
        }
    }
}