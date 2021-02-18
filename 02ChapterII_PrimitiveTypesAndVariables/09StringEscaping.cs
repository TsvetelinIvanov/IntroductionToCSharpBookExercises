using System;

namespace _09StringEscaping
{
    class Program
    {
        static void Main(string[] args)
        {
            string escaping = "The \"use\" of quotations causes difficults, like this \\.";
            string quoted = @"The ""use"" of quotations causes difficults like this \.";
            Console.WriteLine(escaping);
            Console.WriteLine(quoted);
        }
    }
}
