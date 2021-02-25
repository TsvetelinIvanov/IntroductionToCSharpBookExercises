using System;

namespace _16RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int[] numbers = new int[endNumber];
            for (int i = 0; i < endNumber; i++)
            {
                numbers[i] = i + 1;
            }

            Random random = new Random();
            for (int i = 0; i < endNumber; i++)
            {
                int randomIndex = random.Next(endNumber);
                int temporal = numbers[randomIndex];
                numbers[randomIndex] = numbers[i];
                numbers[i] = temporal;
            }

            for (int i = 0; i < endNumber; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
