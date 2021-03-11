using System;

namespace _02Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsSetN = int.Parse(Console.ReadLine());            
            int elementsCombinationsCountK = int.Parse(Console.ReadLine());            
            int[] combinationsArray = new int[elementsCombinationsCountK];
            SimulateNestedLoops(combinationsArray, elementsSetN, elementsCombinationsCountK);
        }

        private static void SimulateNestedLoops(int[] combinationsArray, int elementsSetN, int elementsCombinationsCountK, int startNumber = 1, int currentPosition = 1)
        {

            for (int i = startNumber; i <= elementsSetN; i++)
            {
                combinationsArray[currentPosition - 1] = i;
                if (currentPosition != elementsCombinationsCountK)
                {
                    SimulateNestedLoops(combinationsArray, elementsSetN, elementsCombinationsCountK, startNumber, currentPosition + 1);
                    startNumber++;
                }
                else
                {
                    PrintCombinations(combinationsArray);
                }
            }
        }

        private static void PrintCombinations(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (i == numbersArray.Length - 1)
                {
                    Console.WriteLine(numbersArray[i]);
                    break;
                }

                Console.Write(numbersArray[i] + ", ");
            }            
        }
    }
}