using System;
using System.Linq;

namespace _11Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu:");            
            Console.WriteLine("1. Reverses the digits of a number.");
            Console.WriteLine("2. Calculates the average of a sequence of integers.");
            Console.WriteLine("3. Solves a linear equation a * x + b = 0.");            
            Console.Write("Your choice: ");
            int choice = int.Parse(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(ReverseNumber());
                        break;
                    case 2:
                        Console.WriteLine(AverageOfSequence());
                        break;
                    case 3:
                        Console.WriteLine(LinearEquation());
                        break;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static int ReverseNumber()
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentException("Number should be non-negative!");
            }

            int reversedNumber = 0;
            int power = number.ToString().Length - 1;
            while (number > 0)
            {
                reversedNumber += number % 10 * (int)Math.Pow(10, power);
                number /= 10;
                power--;
            }

            return reversedNumber;
        }

        private static decimal AverageOfSequence()
        {
            decimal[] sequence = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            if (sequence.Length == 0)
            {
                throw new ArgumentException("Sequence should not be empty!");
            }

            decimal sum = 0;
            foreach (decimal number in sequence)
            {
                sum += number;
            }

            return Math.Round(sum / sequence.Length, 3);
        }

        private static decimal LinearEquation()
        {
            decimal a = decimal.Parse(Console.ReadLine());
            if (a == 0)
            {
                throw new ArgumentException("The first number should not be zero!");
            }

            decimal b = decimal.Parse(Console.ReadLine());
            decimal x = -b / a;

            return Math.Round(x, 3);
        }
    }
}