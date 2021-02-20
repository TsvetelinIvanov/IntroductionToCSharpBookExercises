using System;

namespace _09_Multitude5ZeroSum
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMBERS_COUNT = 5;
            double[] numbers = new double[5];
            bool subsetFound = false;
            try
            {
                numbers[0] = double.Parse(Console.In.ReadLine());
                numbers[1] = double.Parse(Console.In.ReadLine());
                numbers[2] = double.Parse(Console.In.ReadLine());
                numbers[3] = double.Parse(Console.In.ReadLine());
                numbers[4] = double.Parse(Console.In.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, input valid number values.");

                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, input valid number.");

                return;
            }

            for (int startPosition = 0; startPosition < NUMBERS_COUNT; startPosition++)
            {
                double sum = 0;
                for (int endPosition = startPosition; endPosition < NUMBERS_COUNT; endPosition++)
                {
                    sum += numbers[endPosition];
                    if (sum == 0)
                    {
                        Console.Write("Subset found: ");
                        subsetFound = true;
                        for (int iterator = startPosition; iterator <= endPosition; iterator++)
                        {
                            Console.Write("{0} ", numbers[iterator]);
                        }

                        Console.WriteLine();
                    }
                }
            }

            if (!subsetFound)
            {
                Console.WriteLine("No subset found!");
            }
        }
    }
}
