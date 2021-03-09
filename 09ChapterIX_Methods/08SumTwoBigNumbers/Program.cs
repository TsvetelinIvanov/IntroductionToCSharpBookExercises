using System;

namespace _08SumTwoBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            int[] firstArray = MakeInArray(firstNumber);
            int[] secondArray = MakeInArray(secondNumber);
            
            int[] sumArray = new int[Math.Max(firstNumber.Length, secondNumber.Length) + 1];
            if (firstArray.Length > secondArray.Length)
            {
                Array.Copy(secondArray, sumArray, secondArray.Length);
                SumArrays(sumArray, firstArray);
            }
            else
            {
                Array.Copy(firstArray, sumArray, firstArray.Length);
                SumArrays(sumArray, secondArray);
            }

            Array.Reverse(sumArray);
            int i = 0;
            if (sumArray[i] == 0)
            {
                i++;
            }
                
            for (; i < sumArray.Length; i++)
            {
                Console.Write(sumArray[i]);
            }

            Console.WriteLine();
        }

        private static int[] MakeInArray(string number)
        {
            int[] array = new int[number.Length];

            for (int i = 0, j = number.Length - 1; j >= 0; i++, j--)
            {
                array[i] = number[j] - '0';
            }

            return array;
        }

        private static void SumArrays(int[] sumArray, int[] array)
        {
            int addition = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if ((sumArray[i] + array[i] + addition) > 9)
                {
                    sumArray[i] = (sumArray[i] + array[i] + addition) % 10;
                    addition = 1;
                }
                else
                {
                    sumArray[i] = sumArray[i] + array[i] + addition;
                    addition = 0;
                }
            }

            if (addition == 1)
            {
                sumArray[sumArray.Length - 1] = 1;
            }                
        }
    }
}