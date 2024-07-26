using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ExchangeQBitsInANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = uint.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            if (p > q)
            {
                int oldValue = p;
                p = q;
                q = oldValue;
            }

            if (p + k >= q)
            {
                k = k + p - q - 1;
                q += p + k + 1;
            }

            number = ModifyNumber(number, p, q, k);
            Console.WriteLine(number);
        }

        private static uint ModifyNumber(uint number, int p, int q, int k)
        {
            int[] pBits = new int[k];
            int[] qBits = new int[k];
            for (int position = p, i = 0; i < pBits.Length; position++, i++)
            {
                pBits[i] = DoPthBit(number, position);
            }

            for (int position = q, i = 0; i < qBits.Length; position++, i++)
            {
                qBits[i] = DoPthBit(number, position);
            }

            for (int position = p, i = 0; i < qBits.Length; position++, i++)
            {
                number = DoModifiedNumber(number, position, qBits[i]);
            }

            for (int position = q, i = 0; i < pBits.Length; position++, i++)
            {
                number = DoModifiedNumber(number, position, pBits[i]);
            }

            return number;
        }

        private static int DoPthBit(uint number, int position)
        {
            uint pthBit = (number >> position) & 1;
            
            return (int)pthBit;
        }

        private static uint DoModifiedNumber(uint number, int position, int bitValue)
        {
            uint actual = (uint)bitValue << position;
            number = number & (~((uint)1 << position));
            uint result = number | actual;
            
            return result;
        }
    }
}
