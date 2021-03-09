using System;
using System.Collections.Generic;
using System.Linq;

namespace _03FiveSpetialLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());            

            bool printed = false;
            int weight = 0;
            Dictionary<char, int> values = new Dictionary<char, int>();
            values.Add('a', 5);
            values.Add('b', -12);
            values.Add('c', 47);
            values.Add('d', 7);
            values.Add('e', -32);

            for (char c = 'a'; c < 'f'; c++)
            {
                for (char c1 = 'a'; c1 < 'f'; c1++)
                {
                    for (char c2 = 'a'; c2 < 'f'; c2++)
                    {
                        for (char c3 = 'a'; c3 < 'f'; c3++)
                        {
                            for (char c4 = 'a'; c4 < 'f'; c4++)
                            {
                                char[] Ic = string.Format("{0}{1}{2}{3}{4}", c, c1, c2, c3, c4).ToCharArray().Distinct().ToArray();
                                weight = 0;
                                for (int i = 1; i <= Ic.Length; i++)
                                {
                                    weight += values[Ic[i - 1]] * i;
                                }

                                if (weight >= start && weight <= end)
                                {
                                    Console.Write("{0}{1}{2}{3}{4} ", c, c1, c2, c3, c4);
                                    printed = true;
                                }
                            }
                        }
                    }
                }
            }


            if (!printed)
            {
                Console.WriteLine("No");
            }                
        }
    }
}
