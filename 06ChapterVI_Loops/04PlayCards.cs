using System;

namespace _04PlayCards
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int card = 2; card <= 14; card++)
            {
                for (int paint = 1; paint <= 4; paint++)
                {
                    if (card >= 2 && card <= 10)
                    {
                        Console.Write(card);
                    }
                    else if (card == 11)
                    {
                        Console.Write("A");
                    }
                    else if (card == 12)
                    {
                        Console.Write("J");
                    }
                    else if (card == 13)
                    {
                        Console.Write("Q");
                    }
                    else if (card == 14)
                    {
                        Console.Write("K");
                    }

                    if (paint == 1)
                    {
                        Console.Write("club ");
                    }
                    else if (paint == 2)
                    {
                        Console.Write("diamond ");
                    }
                    else if (paint == 3)
                    {
                        Console.Write("heart ");
                    }
                    else if (paint == 4)
                    {
                        Console.Write("spade ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
