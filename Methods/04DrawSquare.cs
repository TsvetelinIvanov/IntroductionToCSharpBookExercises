using System;

namespace DrawSquareIV
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            //PrintHeaderFooter(input);
            //for (int i = 0; i < input - 2; i++)
            //{
            //    PrintMiddleRow(input);
            //}
            //PrintHeaderFooter(input);
            DrawSquare(input); //optimization
        }

        static void DrawSquare(int n) //optimization
        {
            PrintHeaderFooter(n);
            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddleRow(n);
            }
            PrintHeaderFooter(n);
        }

        static void PrintHeaderFooter(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }

        static void PrintMiddleRow(int n)
        {
            Console.Write("-");
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write("\\/");
            }

            Console.Write("-");
            Console.WriteLine();
        }        
    }
}
