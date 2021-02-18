using System;

namespace _11Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = (char)169;
            Console.WriteLine("    {0}    ", c);
            Console.WriteLine("   {0} {0}   ", c);
            Console.WriteLine("  {0}   {0}    ", c);
            Console.WriteLine(" {0}     {0}    ", c);
            Console.WriteLine("{0}{0}{0}{0}{0}{0}{0}{0}{0}  ", c);
        }
    }
}
