using System;
using System.Collections.Generic;

namespace _02ReverseSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCountN = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < numbersCountN; i++)
            {
                numbers.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}