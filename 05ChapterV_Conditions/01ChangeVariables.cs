using System;

namespace _01ChangeVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            if (a > b)
            {
                int c = b; //or a = a + b; or int c = a + b; 
                b = a; //or b = a - b; or b = c - b;
                a = c; //or a = a - b; or a = c - a;
            }

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}
