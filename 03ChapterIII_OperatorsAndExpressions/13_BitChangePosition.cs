using System;

namespace _13_BitChangePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int mask = v << p;
            n = n & (~(1 << p));
            int result = n | mask;
            Console.WriteLine(result);
        }
    }
}
