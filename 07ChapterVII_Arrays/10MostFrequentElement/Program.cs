using System;

namespace _10MostFrequentElement
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int maxCount = 0;
            string mostFrequentElement = string.Empty;
            for (int i = 0; i < elements.Length; i++)
            {
                int count = 1;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[i] == elements[j])
                    {
                        count++;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    mostFrequentElement = elements[i];
                }
            }

            Console.WriteLine($"{mostFrequentElement} ({maxCount} times)");
        }
    }
}