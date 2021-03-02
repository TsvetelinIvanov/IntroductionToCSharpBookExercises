using System;
using System.Linq;

namespace _11SubsequenceOfGivenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSum = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            bool existSum = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    sum += numbers[j];
                    if (sum == numberSum)
                    {
                        existSum = true;
                        for (int k = i; k <= j; k++)
                        {
                            if (k == j)
                            {
                                Console.WriteLine(numbers[k]);
                                break;
                            }

                            Console.Write(numbers[k] + ", ");
                        }
                    }
                }
            }

            if (!existSum)
            {
                Console.WriteLine("There is no sequence of given sum.");
            }
        }
    }
}