using System;

namespace _09MinNumber
{
    class Program
    {        
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            //int minAB = GetMin(a, b);
            //int minABC = GetMin(minAB, c); or
            int minABC = GetMin(GetMin(a, b), c);
            Console.WriteLine(minABC);
        }

        static int GetMin(int a, int b)
        {
            if (a <= b)
                return a;
            else
                return b;
        }
    }
}
