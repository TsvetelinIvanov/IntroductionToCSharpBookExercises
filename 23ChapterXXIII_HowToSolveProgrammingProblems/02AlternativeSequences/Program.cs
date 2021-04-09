using System;
using System.Collections.Generic;
using System.Linq;

namespace _02AlternativeSequences
{
    class Program
    {
        private static int[] numbers;
        private static bool[] usedNumbers;
        private static int sequenceLengthK;        
        private static List<int> sequence = new List<int>();
        private static List<List<int>> sequences = new List<List<int>>();               
        
        static void Main(string[] args)
        {
            numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            usedNumbers = new bool[numbers.Length];
            sequenceLengthK = int.Parse(Console.ReadLine());

            GenerateSequences(true);

            sequences.Sort(CompareLists);
            Console.WriteLine("The count of alternative sequences is: " + sequences.Count);
            for (int i = 0; i < sequences.Count; i++)
            {
                if (i == sequences.Count - 1)
                {
                    Console.WriteLine($"{{{string.Join(", ", sequences[i])}}}.");

                    break;
                }

                Console.Write($"{{{string.Join(", ", sequences[i])}}}, ");
            }
        }

        static void GenerateSequences(bool isUp)
        {
            if (sequence.Count == 0)
            {
                for (int i = 0; i < usedNumbers.Length; i++)
                {
                    if (!usedNumbers[i])
                    {
                        usedNumbers[i] = true;
                        sequence.Add(numbers[i]);

                        GenerateSequences(true);
                        if (sequenceLengthK > 1)
                        {
                            GenerateSequences(false);
                        }

                        usedNumbers[i] = false;
                        sequence.RemoveAt(sequence.Count - 1);
                    }
                }
            }
            else if (sequence.Count == sequenceLengthK)
            {
                List<int> currentSequence = new List<int>(sequence);
                sequences.Add(currentSequence);

                return;
            }
            else
            {
                for (int i = 0; i < usedNumbers.Length; i++)
                {
                    if (!usedNumbers[i])
                    {
                        if (isUp && numbers[i] > sequence.Last())
                        {
                            usedNumbers[i] = true;
                            sequence.Add(numbers[i]);

                            GenerateSequences(false);

                            usedNumbers[i] = false;
                            sequence.RemoveAt(sequence.Count - 1);
                        }
                        else if (!isUp && numbers[i] < sequence.Last())
                        {
                            usedNumbers[i] = true;
                            sequence.Add(numbers[i]);

                            GenerateSequences(true);

                            usedNumbers[i] = false;
                            sequence.RemoveAt(sequence.Count - 1);
                        }
                    }
                }
            }
        }

        private static int CompareLists(List<int> firstList, List<int> secondList)
        {
            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i] < secondList[i])
                {
                    return -1;
                }
                else if (firstList[i] > secondList[i])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}