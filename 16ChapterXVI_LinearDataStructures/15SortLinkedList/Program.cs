using System;
using System.Collections.Generic;
using System.Linq;

namespace _15SortLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            LinkedList<double> sortedNumbers = new LinkedList<double>(numbers);
            BubbleSort(sortedNumbers);
            Console.WriteLine($"{{{string.Join(", ", sortedNumbers)}}}");
        }

        private static void BubbleSort(LinkedList<double> numbers)
        {
            if (numbers == null)
            {
                return;
            }

            LinkedListNode<double> node = numbers.First;
            while (node != numbers.Last)
            {
                for (LinkedListNode<double> afterNode = node.Next; afterNode != null; afterNode = afterNode.Next)
                {
                    if (afterNode.Value < node.Value)
                    {
                        double nodeOldValue = node.Value;
                        node.Value = afterNode.Value;
                        afterNode.Value = nodeOldValue;
                    }
                }

                node = node.Next;
            }
        }
    }
}