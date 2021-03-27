using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13HappySequence
{
    class Program
    {
        private static StringBuilder outputBuilder = new StringBuilder();
        private static List<int> sequence = new List<int>();
        private static ListComparer listComparer = new ListComparer();
        private static TreeMultiSet<List<int>> longestLists = new TreeMultiSet<List<int>>(listComparer);        

        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            sequence = Console.ReadLine().Split(new char[] { ',', ' ', '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            FindLongestSequence(sum);
            PrepareOutput();
            Console.WriteLine(outputBuilder.ToString().TrimEnd());
        }       

        private static void FindLongestSequence(int sum)
        {
            for (int startIndex = 0; startIndex < sequence.Count; startIndex++)
            {
                List<int> list = new List<int>();
                int currentSum = 0;
                for (int i = startIndex; i < sequence.Count; i++)
                {
                    list.Add(sequence[i]);
                    currentSum += sequence[i];
                    if (currentSum == sum)
                    {
                        longestLists.Add(new List<int>(list));
                        if (longestLists.Count > 10)
                        {
                            longestLists.DeleteLast();
                        }
                    }
                }
            }
        }
        
        private static void PrepareOutput()
        {
            if (longestLists.Count == 0)
            {
                outputBuilder.AppendLine("There is no happy sequence!");
            }

            foreach (List<int> list in longestLists)
            {
                outputBuilder.AppendLine($"[{string.Join(", ", list)}]");                
            }
        }
    }
}