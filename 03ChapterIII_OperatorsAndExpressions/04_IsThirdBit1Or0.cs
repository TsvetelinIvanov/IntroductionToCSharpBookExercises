using System;

namespace _04IsThirdBit1or0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int mask = 0x8;
            Console.WriteLine(0 != (n & mask) ? 1 : 0);
        }
    }
}
