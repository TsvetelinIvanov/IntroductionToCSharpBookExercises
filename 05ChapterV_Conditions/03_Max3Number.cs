using System;

namespace _03_Max3Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            if (a >= b && a >= c)
            {
                Console.WriteLine("The biggest number is " + a + ".");
            }
            else if (b >= a && b >= c)
            {
                Console.WriteLine("The biggest number is " + b + ".");
            }
            else
            {
                Console.WriteLine("The biggest number is " + c + ".");
            }
        }
    }
}
