using System;

namespace _13ChanchingVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int c = a + b; //or a = a + b;
            a = c - a; //or b = a - b;
            b = c - b; //or a = a - b;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
        }
    }
}
