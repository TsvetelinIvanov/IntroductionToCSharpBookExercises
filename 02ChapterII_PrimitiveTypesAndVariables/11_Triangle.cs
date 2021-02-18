using System;

namespace _11_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            char COPYRIGHT = '\u009a';
            Console.WriteLine("{0}{1}", new string(' ', 5), COPYRIGHT);
            Console.WriteLine("{0}{1}{2}{1}", new string(' ', 4), COPYRIGHT, new string(' ', 1), COPYRIGHT);
            Console.WriteLine("{0}{1}{2}{1}", new string(' ', 3), COPYRIGHT, new string(' ', 3), COPYRIGHT);
            Console.WriteLine("{0}{1}{2}{1}", new string(' ', 2), COPYRIGHT, new string(' ', 5), COPYRIGHT);
            Console.WriteLine("{0}{1}{2}{1}", new string(' ', 1), COPYRIGHT, new string(' ', 7), COPYRIGHT);
            Console.WriteLine("{0}", new string(COPYRIGHT, 11));
        }
    }
}
