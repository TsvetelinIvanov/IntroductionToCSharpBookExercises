using System;
using System.Collections.Generic;
using System.Linq;

namespace _06NumbersDivisibleBy3And7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Console.WriteLine("Numbers divisible by 3 and 7 finded by lambda LINQ expression:");
            IEnumerable<int> lambdaNumbers = numbers.Where(n => n % 3 == 0 && n % 7 == 0);
            if (lambdaNumbers.Count() == 0)
            {
                Console.WriteLine("There are no numbers divisible by 3 and 7!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", lambdaNumbers) + ".");
            }

            Console.WriteLine("Numbers divisible by 3 and 7 finded by query LINQ:");
            IEnumerable<int> linqNumbers =
                from number in numbers
                where number % 3 == 0 && number % 7 == 0
                select number;

            if (linqNumbers.Count() == 0)
            {
                Console.WriteLine("There are no numbers divisible by 3 and 7!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", linqNumbers) + ".");
            }
        }
    }
}