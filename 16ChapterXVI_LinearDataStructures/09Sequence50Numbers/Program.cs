using System;
using System.Collections.Generic;

namespace _09Sequence50Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            Queue<decimal> sequence = new Queue<decimal>();
            sequence.Enqueue(number);
            int counter = 1;
            for (int i = 1; i < 50; i++, counter++)
            {
                if (counter == 4)
                {
                    Console.Write(sequence.Dequeue() + ", ");
                    counter = 1;
                }

                if (counter == 1)
                {
                    sequence.Enqueue(sequence.Peek() + 1);
                }
                else if (counter == 2)
                {
                    sequence.Enqueue(sequence.Peek() * 2 + 1);
                }
                else if (counter == 3)
                {
                    sequence.Enqueue(sequence.Peek() + 2);
                }
            }

            while (sequence.Count > 0)
            {
                if (sequence.Count != 1)
                {
                    Console.Write(sequence.Dequeue() + ", ");
                }
                else
                {
                    Console.WriteLine(sequence.Dequeue() + ".");
                }
            }
        }
    }
}