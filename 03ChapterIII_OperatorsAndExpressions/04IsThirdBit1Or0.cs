using System;

namespace _04IsThirdBit1or0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = 8;
            int k = m & n;
            if (k == 0)
            {
                Console.WriteLine(0);
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(1);
                Console.WriteLine("Yes");
            }
        }
    }
}
