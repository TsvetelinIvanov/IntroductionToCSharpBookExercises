using System;

namespace _04_Sort3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double temp = 0.0;
            if (b > a)
            {
                temp = a;
                a = b;
                b = temp;
            }

            if (c > a)
            {
                temp = a;
                a = c;
                c = temp;
            }

            if (c > b)
            {
                temp = c;
                c = b;
                b = temp;
            }

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
