using System;

namespace _07Max5Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            decimal nMax = decimal.MinValue;
            for (int i = 0; i < n; i++)
            {
                decimal N = decimal.Parse(Console.ReadLine());
                if (N > nMax)
                {
                    nMax = N;
                }
            }
            
            Console.WriteLine("The biggest number is " + nMax + ".");
        }
    }
}
