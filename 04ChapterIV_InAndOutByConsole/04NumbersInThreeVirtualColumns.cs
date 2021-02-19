using System;

namespace _04NumbersInThreeVirtualColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double number3 = double.Parse(Console.ReadLine());
            Console.WriteLine("{0, -10:x}{1, -10:f2}{2, -10:f2}", number1, number2, number3);//{0:x}(10)-->(16).
        }
    }
}
