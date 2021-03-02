using System;

namespace _02ArraysComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            bool areEqual = firstArray.Length == secondArray.Length;
            if (areEqual)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        areEqual = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areEqual);
        }
    }
}