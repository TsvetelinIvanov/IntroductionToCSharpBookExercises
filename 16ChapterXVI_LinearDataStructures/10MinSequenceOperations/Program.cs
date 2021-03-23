using System;
using System.Collections.Generic;

namespace _10MinSequenceOperations
{
    class Program
    {
        static void Main()
        {
            int startNumberN = int.Parse(Console.ReadLine());
            int endNumberM = int.Parse(Console.ReadLine());
            if (startNumberN < 0 || endNumberM < 0 || endNumberM < startNumberN)
            {
                Console.WriteLine("Invalid input!");
                return;
            }


            Stack<int> sequence = ProceedOperations(startNumberN, endNumberM);

            Console.WriteLine(string.Join(" -> ", sequence));
        }
               
        private static Stack<int> ProceedOperations(int startNumberN, int endNumberM)
        {
            Queue<int> operations = new Queue<int>();
            operations.Enqueue(startNumberN);
            //The value of the dictionary is the parent of the key.
            Dictionary<int, int> predecessors = new Dictionary<int, int>();
            predecessors.Add(startNumberN, int.MinValue);
            while (true)
            {
                int current = operations.Dequeue();
                if (current == endNumberM)
                {
                    return GetSequence(predecessors, current, startNumberN);
                }

                if (!predecessors.ContainsKey(current + 2))
                {
                    predecessors.Add(current + 2, current);
                    operations.Enqueue(current + 2);
                }

                if (!predecessors.ContainsKey(current + 1))
                {
                    predecessors.Add(current + 1, current);
                    operations.Enqueue(current + 1);
                }

                if (!predecessors.ContainsKey(current * 2))
                {
                    predecessors.Add(current * 2, current);
                    operations.Enqueue(current * 2);
                }
            }
        }
                
        private static Stack<int> GetSequence(Dictionary<int, int> predecessors, int start, int end)
        {
            Stack<int> sequence = new Stack<int>();
            int current = start;
            sequence.Push(start);
            while (current != end)
            {
                sequence.Push(predecessors[current]);
                current = predecessors[current];
            }

            return sequence;
        }
    }
}