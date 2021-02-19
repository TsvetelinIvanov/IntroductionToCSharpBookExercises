using System;

namespace _10PlayWithDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int abcd = int.Parse(Console.ReadLine());
            int d1 = abcd / 10;
            int d = abcd % 10;//or int d = abcd % 10;
            int c1 = d1 / 10;
            int c = d1 % 10;//or int c = (abcd % 100) / 10; or or int c = (abcd / 10) % 10;
            int b1 = c1 / 10;
            int b = c1 % 10;//or int b = (abcd % 1000) / 100; or int b = (abcd / 100) % 10;             
            int a = b1 % 10;//or int a = abcd / 1000; 
            int sum = a + b + c + d;
            int dcba = d * 1000 + c * 100 + b * 10 + a;
            int dabc = d * 1000 + a * 100 + b * 10 + c;
            int acbd = a * 1000 + c * 100 + b * 10 + d;
            Console.WriteLine(sum);
            Console.WriteLine("{3}{2}{1}{0}", a, b, c, d);
            Console.WriteLine(dcba);
            Console.WriteLine("{3}{0}{1}{2}", a, b, c, d);
            Console.WriteLine(dabc);
            Console.WriteLine("{0}{2}{1}{3}", a, b, c, d);
            Console.WriteLine(acbd);
        }
    }
}
