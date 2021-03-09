using System;

namespace _01MeetingSequels
{
    class Program
    {
        static void Main(string[] args)
        {
            int tribonacciFirst = int.Parse(Console.ReadLine());
            int tribonacciSecond = int.Parse(Console.ReadLine());
            int tribonacciThird = int.Parse(Console.ReadLine());
            int spiralFirst = int.Parse(Console.ReadLine());
            int spiralStep = int.Parse(Console.ReadLine());
            int tribonacciCurrent = tribonacciFirst;
            int spiralCurrent = spiralFirst;
            int spiralStepMultiplier = 1;
            int spiralIncrement = 0;

            while (tribonacciCurrent <= 1000000 && spiralCurrent <= 1000000)
            {
                if (spiralCurrent == tribonacciFirst || spiralCurrent == tribonacciSecond ||
                    spiralCurrent == tribonacciThird || spiralCurrent == tribonacciCurrent)
                {
                    Console.WriteLine(spiralCurrent);
                    return;
                }
                else if (tribonacciCurrent < spiralCurrent)
                {
                    tribonacciCurrent = tribonacciFirst + tribonacciSecond + tribonacciThird;
                    tribonacciFirst = tribonacciSecond;
                    tribonacciSecond = tribonacciThird;
                    tribonacciThird = tribonacciCurrent;
                }
                else
                {
                    spiralCurrent += spiralStepMultiplier * spiralStep;
                    spiralIncrement++;
                    if (spiralIncrement == 2)
                    {
                        spiralStepMultiplier++;
                        spiralIncrement = 0;
                    }
                }
            }

            Console.WriteLine("No");
        }
    }
}
