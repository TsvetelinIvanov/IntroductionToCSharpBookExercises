using System;

namespace _03Is7ThirdDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = n / 100;
            if (m % 10 == 7)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
