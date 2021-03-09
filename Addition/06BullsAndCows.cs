using System;

namespace _06BullsAndCows
{
    class Program
    {
        static void Main()
        {
            string guessNumber = Console.ReadLine();
            int targetBullsCount = int.Parse(Console.ReadLine());
            int targetCowsCount = int.Parse(Console.ReadLine());
            bool hasSolution = false;
            bool isFirst = true;

            for (int num = 1111; num <= 9999; num++)
            {
                int bullsCount = 0;
                int cowsCount = 0;
                char[] numberCharArray = num.ToString().ToCharArray();
                bool[] visitedGuesses = new bool[numberCharArray.Length];
                bool[] visitedNumbers = new bool[numberCharArray.Length];

                if (num.ToString().Contains("0"))
                {
                    continue;
                }

                for (int i = 0; i < guessNumber.Length; i++)
                {
                    if (guessNumber[i] == numberCharArray[i])
                    {
                        bullsCount++;
                        visitedGuesses[i] = true;
                        visitedNumbers[i] = true;
                    }
                }

                for (int i = 0; i < guessNumber.Length; i++)
                {
                    for (int j = 0; j < numberCharArray.Length; j++)
                    {
                        if (i != j && !visitedNumbers[j] && !visitedGuesses[i] && guessNumber[i] == numberCharArray[j])
                        {
                            cowsCount++;
                            visitedGuesses[i] = true;
                            visitedNumbers[j] = true;
                        }
                    }
                }

                if (bullsCount == targetBullsCount && cowsCount == targetCowsCount)
                {
                    hasSolution = true;
                    if (!isFirst)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(num);
                    isFirst = false;
                }
            }

            if (!hasSolution)
            {
                Console.WriteLine("No");
            }
        }
    }
}
