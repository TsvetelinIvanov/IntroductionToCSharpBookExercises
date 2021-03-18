using System;

namespace _03CorrectBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            int leftBrackets = 0, rightBrackets = 0;
            bool areCorrect = true;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')')
                {
                    rightBrackets++;
                }
                else if (expression[i] == '(')
                {
                    leftBrackets++;
                }                
            }

            if (rightBrackets != leftBrackets)
            {
                areCorrect = false;
            }

            Console.WriteLine(areCorrect);
        }
    }
}