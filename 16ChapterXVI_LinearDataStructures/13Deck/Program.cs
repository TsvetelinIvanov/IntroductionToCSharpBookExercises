using System;
using System.Linq;

namespace _13Deck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck<double> deck = new Deck<double>();
            double[] startNumbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            for (int i = 0; i < startNumbers.Length; i++)
            {
                deck.AddToStart(startNumbers[i]);
            }

            Console.WriteLine(string.Join(", ", deck.ToArray()));

            double[] endNumbers = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            for (int i = 0; i < endNumbers.Length; i++)
            {
                deck.AddToEnd(endNumbers[i]);
            }

            Console.WriteLine(string.Join(", ", deck.ToArray()));
            
            int elementsToRemoveFromStart = int.Parse(Console.ReadLine());
            for (int i = 0; i < elementsToRemoveFromStart; i++)
            {
                try
                {
                    Console.WriteLine(deck.RemoveFromStart());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.GetType() + ": " + ioe.Message);                    
                }
            }

            Console.WriteLine(string.Join(", ", deck.ToArray()));

            int elementsToRemoveFromEnd = int.Parse(Console.ReadLine());
            for (int i = 0; i < elementsToRemoveFromEnd; i++)
            {
                try
                {
                    Console.WriteLine(deck.RemoveFromEnd());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.GetType() + ": " + ioe.Message);                    
                }
            }

            Console.WriteLine(string.Join(", ", deck.ToArray()));

            deck.Clear();
            Console.WriteLine(string.Join(", ", deck.ToArray()));
        }
    }
}