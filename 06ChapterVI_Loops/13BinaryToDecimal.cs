using System;

namespace _13BinaryToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Base = 2;
            string binaryNumberString = Console.ReadLine();            

            char[] binaryNumberCharArray = binaryNumberString.ToCharArray();
            Array.Reverse(binaryNumberCharArray);

            int decimalNumber = 0;
            for (int i = 0; i < binaryNumberCharArray.Length; i++)
            {
                if (binaryNumberCharArray[i] != '0')
                {
                    decimalNumber += (int)Math.Pow(Base, i);
                }
            }

            Console.WriteLine(decimalNumber);
        }
    }
}
