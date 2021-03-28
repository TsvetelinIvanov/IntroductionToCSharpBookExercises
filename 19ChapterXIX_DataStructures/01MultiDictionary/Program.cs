using System;
using System.Collections.Generic;

namespace _01MultiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<string, int> multiDictionary = new MultiDictionary<string, int>();
            int keysCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < keysCount; i++)
            {
                string[] pair = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                multiDictionary.Add(pair[0], int.Parse(pair[1]));
            }

            foreach (KeyValuePair<string, List<int>>  pair in multiDictionary)
            {
                Console.WriteLine(pair.Key + " -> " + string.Join(", ", pair.Value));
            }
        }
    }
}