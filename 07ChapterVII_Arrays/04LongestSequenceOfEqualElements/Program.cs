using System;

namespace _04LongestSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int maxCount = 1;
            int counter = 1;
            string element = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > maxCount)
                {
                    maxCount = counter;
                    element = array[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                if (i == maxCount - 1)
                {
                    Console.WriteLine(element);
                    break;
                }

                Console.Write(element + ", ");
            }
        }
    }
}