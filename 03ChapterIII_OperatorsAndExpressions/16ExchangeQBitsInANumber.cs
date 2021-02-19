using System;

namespace _16ExchangeQBitsInANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startExcangePosition = int.Parse(Console.ReadLine());
            int exchangeBits = int.Parse(Console.ReadLine());
            int exchangeFromPosition = int.Parse(Console.ReadLine());
            int firstBits = 0;
            int secondBits = 0;
            for (int i = 0; i < exchangeBits; i++)
            {
                if (0 != (n & (1 << startExcangePosition + i)))
                {
                    firstBits |= (1 << i);
                }

                n &= ~(1 << startExcangePosition + i);
                if (0 != (n & (1 << exchangeFromPosition + i)))
                {
                    secondBits |= (1 << i);
                }

                n &= ~(1 << exchangeFromPosition + i);
            }

            n |= secondBits << startExcangePosition;
            n |= firstBits << exchangeFromPosition;
            Console.WriteLine(n);
        }
    }
}
