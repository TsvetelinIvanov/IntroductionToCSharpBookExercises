using System;
using System.Linq;

namespace _07MaxSumOfSequentialElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsLendthN = int.Parse(Console.ReadLine());
            int sequenceLengthK = int.Parse(Console.ReadLine());
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxSequenceSum = 0;
            int maxSequenceStartIndex = 0;
            for (int i = 0; i <= elementsLendthN - sequenceLengthK; i++)
            {
                int sequenceSum = 0;
                for (int j = i; j < i + sequenceLengthK; j++)
                {
                    sequenceSum += elements[j];
                }

                if (sequenceSum > maxSequenceSum)
                {
                    maxSequenceSum = sequenceSum;
                    maxSequenceStartIndex = i;
                }
            }

            for (int i = maxSequenceStartIndex; i < maxSequenceStartIndex + sequenceLengthK; i++)
            {
                if (i == maxSequenceStartIndex + sequenceLengthK - 1)
                {
                    Console.WriteLine(elements[i]);
                    break;
                }

                Console.Write(elements[i] + ", ");
            }
        }
    }
}