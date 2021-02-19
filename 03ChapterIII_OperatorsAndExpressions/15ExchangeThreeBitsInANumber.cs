using System;

namespace _15ExchangeThreeBitsInANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int startExchangePosition = 3;
            int exchangeBits = 3;
            int exchangeFromPosition = 24;

            int firstBits = 0;
            int secondtBits = 0;

            for (int i = 0; i < exchangeBits; i++)
            {
                if (0 != (n & (1 << (startExchangePosition + i))))
                {
                    firstBits |= (1 << i);
                }

                n &= ~(1 << (startExchangePosition + i));
                if (0 != (n & (1 << (exchangeFromPosition + i))))
                {
                    secondtBits |= (1 << i);
                }

                n &= ~(1 << (exchangeFromPosition + i));
            }

            n |= secondtBits << startExchangePosition;
            n |= firstBits << exchangeFromPosition;
            Console.WriteLine(n);
        }
    }
}
