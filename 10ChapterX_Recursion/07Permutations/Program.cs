using System;
using System.Text;

namespace _07Permutations
{
    class Program
    {
        private static StringBuilder permutationsBuilder = new StringBuilder();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            GetPermutations(numbers, 0);
            Console.WriteLine(permutationsBuilder.ToString().TrimEnd(',', ' '));
        }

        static void GetPermutations(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                permutationsBuilder.Append("(");
                for (int i = 0; i < numbers.Length; i++)
                {
                    if(i == numbers.Length - 1)
                    {
                        permutationsBuilder.Append(numbers[i] + "), ");
                        break;
                    }

                    permutationsBuilder.Append(numbers[i] + ", ");
                }                
            }
            else
            {
                for (int i = index; i < numbers.Length; i++)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[index];
                    numbers[index] = temp;
                    GetPermutations(numbers, index + 1);
                    temp = numbers[i];
                    numbers[i] = numbers[index];
                    numbers[index] = temp;
                }
            }
        }
    }
}