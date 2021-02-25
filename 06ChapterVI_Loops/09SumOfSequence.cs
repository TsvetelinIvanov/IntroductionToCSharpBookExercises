using System;

namespace _09SumOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int X = int.Parse(Console.ReadLine());
            if (N < 0 || X == 0)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            double sum = 1;
            double factorialOfN = 1;
            double powerOfX = 1;
            for (int i = 1; i <= N; i++)
            {
                factorialOfN *= i;
                powerOfX *= X;
                sum += (factorialOfN / powerOfX);
            }

            Console.WriteLine(sum);
        }
    }
}
