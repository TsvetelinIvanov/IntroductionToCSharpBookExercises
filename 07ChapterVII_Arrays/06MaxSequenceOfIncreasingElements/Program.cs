using System;
using System.Linq;

namespace _06MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] lengths = new int[array.Length];
            lengths[0] = 1;
            for (int i = 1; i < array.Length; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i])
                    {
                        int current = lengths[j];
                        if (current > max)
                        {
                            max = current;
                        }
                    }
                }

                lengths[i] = 1 + max;
            }

            int maxLength = lengths.Max();
            int[] maxSequenceOfIncreasingElements = new int[maxLength];
            int maxLengthIndex = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                if (lengths[i] == maxLength)
                {
                    maxSequenceOfIncreasingElements[maxLength - 1] = array[i];
                    maxLengthIndex = i;
                    break;
                }
            }
            
            //for (int i = lengths.Length - 1; i >= 0; i--)
            //{
            //    if (lengths[i] == maxLength)
            //    {
            //        maxSequenceOfIncreasingElements[maxLength - 1] = array[i];
            //        maxLengthIndex = i;
            //        break;
            //    }
            //}

            int currentIndex = maxLengthIndex - 1;
            int currentMaxIndex = maxLengthIndex;
            int sequenceIndex = maxLength - 2;
            while (sequenceIndex >= 0 && currentIndex >= 0)
            {                
                if (lengths[currentIndex] == lengths[currentMaxIndex] - 1)
                {
                    maxSequenceOfIncreasingElements[sequenceIndex] = array[currentIndex];
                    sequenceIndex--;
                    currentMaxIndex = currentIndex;
                }

                currentIndex--;
            }

            for (int i = 0; i < maxSequenceOfIncreasingElements.Length; i++)
            {
                if (i == maxSequenceOfIncreasingElements.Length - 1)
                {
                    Console.WriteLine(maxSequenceOfIncreasingElements[i]);
                    break;
                }

                Console.Write(maxSequenceOfIncreasingElements[i] + ", ");
            }
        }
    }
}
