using System;

namespace _03Max3Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            if (a > b && a > c)
            {
                Console.WriteLine("The greatest number is " + a + ".");
            }
            else if (b > a && b > c)
            {
                Console.WriteLine("The greatest number is " + b + ".");
            }
            else if (c > b && c > a)
            {
                Console.WriteLine("The greatest number is " + c + ".");
            }
            else if (a == b && a > c)
            {
                Console.WriteLine("There are two greatest numbers, and they are equal to " + a + ".");
            }
            else if (a == c && a > b)
            {
                Console.WriteLine("There are two greatest numbers, and they are equal to " + a + ".");
            }
            else if (c == b && a < c)
            {
                Console.WriteLine("There are two greatest numbers, and they are equal to " + c + ".");
            }
            else if (a == b && b == c && a == c)
            {
                Console.WriteLine("All nubers are equal!");
            }
        }
    }
}
