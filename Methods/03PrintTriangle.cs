using System;

namespace _03PrintTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }        

        static void PrintTriangle(int n)
        {
            for (int i = 0; i < n; i++) // without blank line -> for (int i = 1; i < n; i++)
            {
                PrintLine(1, i);
            }

            PrintLine(1, n);

            for (int i = n - 1; i > 0; i--)               
            {
                PrintLine(1, i);
            }
        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
