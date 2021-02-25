using System;

namespace _17GreatestCommonDevisor
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = Math.Abs(int.Parse(Console.ReadLine()));
            int secondNumber = Math.Abs(int.Parse(Console.ReadLine()));
            
            while (firstNumber > 0 && secondNumber > 0 && firstNumber != secondNumber)
            {
                while (secondNumber > firstNumber)
                {
                    secondNumber -= firstNumber;
                }

                while (firstNumber > secondNumber)
                {
                    firstNumber -= secondNumber;
                }
            }

            if (firstNumber == 0)
            {
                Console.WriteLine(secondNumber);
            }
            else
            {
                Console.WriteLine(firstNumber);
            }
        }
    }
}
