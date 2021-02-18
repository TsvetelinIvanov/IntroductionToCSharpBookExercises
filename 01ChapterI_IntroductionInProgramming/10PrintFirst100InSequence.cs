using System;

namespace _10PrintFirst100InSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string members = "2, -3, 4, -5, 6, -7, 8,";
            Console.WriteLine("If your sequence of number is: {0}", members);
            Console.WriteLine("The first 100 members are:");
            for (int i = 2; i <= 101; i++)
            {
                if (i == 101)
                {
                    Console.WriteLine("-{0}.", i);
                }
                if (i % 2 == 0)
                {
                    Console.Write(i + ", ");
                }
                else
                {
                    Console.Write("-{0}, ", i);
                }
            }
        }
    }
}
