using System;

namespace _09Multitude5ZeroSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());
            int n5 = int.Parse(Console.ReadLine());
            if (n1 + n2 + n3 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}.", n1, n2, n3, n4, n5);
            }

            if (n1 + n2 + n3 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}.", n1, n2, n3, n4);
            }

            if (n1 + n2 + n3 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}.", n1, n2, n3, n5);
            }

            if (n1 + n2 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}.", n1, n2, n4, n5);
            }

            if (n1 + n3 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}.", n1, n3, n4, n5);
            }

            if (n2 + n3 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}.", n2, n3, n4, n5);
            }

            if (n1 + n2 + n3 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n1, n2, n3);
            }

            if (n1 + n2 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n1, n2, n4);
            }

            if (n1 + n3 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n1, n3, n4);
            }

            if (n2 + n3 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n2, n3, n4);
            }

            if (n1 + n2 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n1, n2, n5);
            }

            if (n1 + n3 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n1, n3, n5);
            }

            if (n2 + n3 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n2, n3, n5);
            }

            if (n1 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n1, n4, n5);
            }

            if (n2 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n2, n4, n5);
            }

            if (n3 + n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}, {2}.", n3, n4, n5);
            }

            if (n1 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}.", n1, n5);
            }

            if (n1 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}.", n1, n4);
            }

            if (n1 + n3 == 0)
            {
                Console.WriteLine("{0}, {1}.", n1, n3);
            }

            if (n1 + n2 == 0)
            {
                Console.WriteLine("{0}, {1}.", n1, n2);
            }

            if (n2 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}.", n2, n5);
            }

            if (n2 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}.", n2, n4);
            }

            if (n2 + n3 == 0)
            {
                Console.WriteLine("{0}, {1}.", n2, n3);
            }

            if (n3 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}.", n3, n5);
            }

            if (n3 + n4 == 0)
            {
                Console.WriteLine("{0}, {1}.", n3, n4);
            }

            if (n4 + n5 == 0)
            {
                Console.WriteLine("{0}, {1}.", n4, n5);
            }

            if (n1 == 0)
            {
                Console.WriteLine("{0}", n1);
            }

            if (n2 == 0)
            {
                Console.WriteLine("{0}", n2);
            }

            if (n3 == 0)
            {
                Console.WriteLine("{0}", n3);
            }

            if (n4 == 0)
            {
                Console.WriteLine("{0}", n4);
            }

            if (n5 == 0)
            {
                Console.WriteLine("{0}", n5);
            }
        }
    }
}
