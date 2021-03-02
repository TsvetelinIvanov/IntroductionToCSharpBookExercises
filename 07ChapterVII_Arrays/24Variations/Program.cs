using System;

namespace _24Variations
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumberN = int.Parse(Console.ReadLine());
            int elementsCountK = int.Parse(Console.ReadLine());

            int[] array = new int[elementsCountK];

            PrintVariations(array, 0, endNumberN);
        }

        static void PrintVariations(int[] array, int startNumber, int endNumber)
        {
            if (startNumber == array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
                
                return;
            }

            for (int i = 1; i <= endNumber; i++)
            {
                array[startNumber] = i;
                PrintVariations(array, startNumber + 1, endNumber);
            }
        }
    }
}