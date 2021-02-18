using System;

namespace _10_PrintFirst100InSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write("{0,4}", i + 2);
                }
                else
                {
                    Console.Write("{0,4}", -(i + 2));
                }
            }
        }
    }
}
