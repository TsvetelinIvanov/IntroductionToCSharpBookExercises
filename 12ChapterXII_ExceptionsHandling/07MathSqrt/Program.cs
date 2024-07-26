using System;

namespace _07MathSqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                uint number = uint.Parse(Console.ReadLine());
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid Number!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
            }
            finally
            {
                Console.WriteLine("Good Bye!");
            }
        }
    }
}
