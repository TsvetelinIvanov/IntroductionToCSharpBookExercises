using System;

namespace _13SpecialSum
{
    class Program
    {
        static void Main(string[] args)
        {
            double oldSum = 0;
            double currentSum = 0;
            for (int i = 1; i < double.MaxValue; i++)
            {
                currentSum += (1.0 / i);
                if (currentSum - oldSum < 0.001) break;
                oldSum = currentSum;
            }

            Console.WriteLine(Math.Round(oldSum, 3));
        }
    }
}
