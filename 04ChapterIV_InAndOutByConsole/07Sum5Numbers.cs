using System;

namespace _07Sum5Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = string.Empty;
            int n1 = 0;
            bool isNumberCorect = false;
            while (!isNumberCorect)
            {
                inputLine = (Console.ReadLine());
                isNumberCorect = int.TryParse(inputLine, out n1);
                if (!isNumberCorect)
                {
                    Console.WriteLine("Invalid number, try again");
                }
            }

            int n2 = 0;
            isNumberCorect = false;
            while (!isNumberCorect)
            {
                inputLine = (Console.ReadLine());
                isNumberCorect = int.TryParse(inputLine, out n2);
                if (!isNumberCorect)
                {
                    Console.WriteLine("Invalid number, try again");
                }
            }

            int n3 = 0;
            isNumberCorect = false;
            while (!isNumberCorect)
            {
                inputLine = (Console.ReadLine());
                isNumberCorect = int.TryParse(inputLine, out n3);
                if (!isNumberCorect)
                {
                    Console.WriteLine("Invalid number, try again");
                }
            }

            int n4 = 0;
            isNumberCorect = false;
            while (!isNumberCorect)
            {
                inputLine = (Console.ReadLine());
                isNumberCorect = int.TryParse(inputLine, out n4);
                if (!isNumberCorect)
                {
                    Console.WriteLine("Invalid number, try again");
                }
            }

            int n5 = 0;
            isNumberCorect = false;
            while (!isNumberCorect)
            {
                inputLine = (Console.ReadLine());
                isNumberCorect = int.TryParse(inputLine, out n5);
                if (!isNumberCorect)
                {
                    Console.WriteLine("Invalid number, try again");
                }
            }

            long sum = (long)n1 + n2 + n3 + n4 + n5;
            Console.WriteLine(sum);
        }
    }
}
