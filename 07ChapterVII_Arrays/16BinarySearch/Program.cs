using System;
using System.Linq;

namespace _16BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).OrderBy(n => n).ToArray();
            int number = int.Parse(Console.ReadLine());
            if (!array.Contains(number))
            {
                Console.WriteLine("The number is not in this array!");
                return;
            }

            int startIndex = 0;
            int endIndex = array.Length - 1;
            int currentIndex = (startIndex + endIndex) / 2;            
            do
            {
                if (array[currentIndex] == number)
                {
                    Console.WriteLine(currentIndex);
                    return;
                }
                else if (array[currentIndex] > number)
                {
                    endIndex = currentIndex;
                    currentIndex = (startIndex + endIndex - 1) / 2;
                }
                else
                {
                    startIndex = currentIndex;
                    currentIndex = (startIndex + endIndex + 1) / 2;
                }

            } while (startIndex != endIndex);
        }
    }
}