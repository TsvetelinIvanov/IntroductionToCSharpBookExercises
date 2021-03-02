using System;

namespace _01IndexMultipliedBy5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 5;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}