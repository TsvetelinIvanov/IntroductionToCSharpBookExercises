using System;

namespace _25SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}