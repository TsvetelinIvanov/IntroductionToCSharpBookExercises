using System;

namespace _03MaxAndMinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < min)
                {
                    min = number;
                }

                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine("The smallest number is " + min + ".");
            Console.WriteLine("The biggest number is " + max + ".");
        }
    }
}
