using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ExchangeThreeBitsInANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());

            int bitAtPosition3 = TakeBit(number, 3);
            int bitAtPosition4 = TakeBit(number, 4);
            int bitAtPosition5 = TakeBit(number, 5);
            int bitAtPosition24 = TakeBit(number, 24);
            int bitAtPosition25 = TakeBit(number, 25);
            int bitAtPosition26 = TakeBit(number, 26);

            number = ModifiyNumber(number, 3, bitAtPosition24);
            number = ModifiyNumber(number, 4, bitAtPosition25);
            number = ModifiyNumber(number, 5, bitAtPosition26);
            number = ModifiyNumber(number, 24, bitAtPosition3);
            number = ModifiyNumber(number, 25, bitAtPosition4);
            number = ModifiyNumber(number, 26, bitAtPosition5);

            Console.WriteLine(number);
        }

        private static int TakeBit(uint number, int position)
        {
            uint PthBit = (number >> position) & 1;
            return (int)PthBit;
        }

        private static uint ModifiyNumber(uint number, int position, int bitValue)
        {
            uint actual = (uint)bitValue << position;
            number = number & (~((uint)1 << position));
            uint result = number | actual;
            return result;
        }
    }
}
