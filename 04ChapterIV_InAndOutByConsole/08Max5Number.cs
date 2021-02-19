using System;

namespace _08Max5Number
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n1 = decimal.Parse(Console.ReadLine());
            decimal n2 = decimal.Parse(Console.ReadLine());
            decimal n3 = decimal.Parse(Console.ReadLine());
            decimal n4 = decimal.Parse(Console.ReadLine());
            decimal n5 = decimal.Parse(Console.ReadLine());

            decimal n12 = Math.Max(n1, n2);
            decimal n345 = Math.Max(n3, Math.Max(n4, n5));
            decimal nMax = Math.Max(n12, n345);

            Console.WriteLine("The greatest number is: " + nMax + ".");
        }
    }
}
