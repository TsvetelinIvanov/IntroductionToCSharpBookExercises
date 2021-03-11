using System;

namespace _03Variations
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsSetN = int.Parse(Console.ReadLine());
            int elementsVariationssCountK = int.Parse(Console.ReadLine());
            int[] variationsArray = new int[elementsVariationssCountK];
            PrintVariations(variationsArray, elementsSetN, 0);
        }

        private static void PrintVariations(int[] variationsArray, int elementsSetN, int index)
        {
            if (index >= variationsArray.Length)
            {
                for (int i = 0; i < variationsArray.Length; i++)
                {
                    if (i == variationsArray.Length - 1)
                    {
                        Console.WriteLine(variationsArray[i]);
                        break;
                    }

                    Console.Write(variationsArray[i] + ", ");
                }
            }
            else
            {
                for (int i = 1; i <= elementsSetN; i++)
                {
                    variationsArray[index] = i;
                    PrintVariations(variationsArray, elementsSetN, index + 1);
                }
            }
        }
    }
}