using System;

namespace _13BitChangePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int v = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            if (v == 0)
            {
                v = n & (~(1 << p));//or v = ~(1 << p); v = v & n;
                Console.WriteLine(v);
            }
            else if (v == 1)
            {
                v = n | (1 << p);//or v = 1 << p; v = v | n;
                Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
