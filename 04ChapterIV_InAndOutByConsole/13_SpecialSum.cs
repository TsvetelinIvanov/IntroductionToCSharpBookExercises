using System;

namespace _13_SpecialSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 1.0;
            for (int i = 2; i <= n; i++)
            {
                sum += (1.0 / i);
            }

            Console.WriteLine("{0:f3}", sum);
        }
    }
}
