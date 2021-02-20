using System;

namespace FindNthDigitXI
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int index = int.Parse(Console.ReadLine());
            int indexN = FindNthDigit(number, index);
            Console.WriteLine(indexN);           
        }

        static int FindNthDigit(int number, int index)
        {
            int counter = 0;
            int indexNumber = 0;
            while (counter <= index)
            {
                counter++;
                if (counter == index)
                {
                    indexNumber = number % 10;
                }
                else
                {
                    number /= 10;
                }
            }

            return indexNumber;
        }
    }
}
