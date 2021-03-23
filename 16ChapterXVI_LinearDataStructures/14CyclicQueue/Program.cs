using System;
using System.Linq;

namespace _14CyclicQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray();
            try
            {
                CyclicQueue<int> invalidCyclicQueue = new CyclicQueue<int>(-7);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.GetType() + ": " + ioe.Message);
            }

            CyclicQueue<int> cyclicQueue = new CyclicQueue<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                cyclicQueue.Enqueue(numbers[i]);
            }

            Console.WriteLine(cyclicQueue.Count);
            Console.WriteLine(cyclicQueue.Capacity);            

            int numbersToDequeue = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersToDequeue; i++)
            {
                try
                {
                    Console.WriteLine(cyclicQueue.Peek());
                    Console.WriteLine(cyclicQueue.Dequeue());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.GetType() + ": " + ioe.Message);
                }
            }

            Console.WriteLine(cyclicQueue.Count);
            Console.WriteLine(cyclicQueue.Capacity);

            for (int i = 0; i < numbers.Length; i++)
            {
                cyclicQueue.Enqueue(numbers[i]);
            }

            Console.WriteLine(cyclicQueue.Count);
            Console.WriteLine(cyclicQueue.Capacity);
            
            for (int i = 0; i < numbersToDequeue; i++)
            {
                try
                {
                    Console.WriteLine(cyclicQueue.Peek());
                    Console.WriteLine(cyclicQueue.Dequeue());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.GetType() + ": " + ioe.Message);
                }
            }

            Console.WriteLine(cyclicQueue.Count);
            Console.WriteLine(cyclicQueue.Capacity);
        }
    }
}