using System;

namespace _08_Max5Number
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal nMax = Decimal.MinValue;
            int N = 5;
            for (int i = 0; i < N; i++)
            {
                decimal n = decimal.Parse(Console.ReadLine());
                if (n > nMax)
                    nMax = n;
            }

            Console.WriteLine("The greatest number is: " + nMax + ".");
        }
    }
}
