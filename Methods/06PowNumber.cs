using System;

namespace PowNumberVI
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());
            Console.WriteLine(PowNumber(num, pow));
        }

        static double PowNumber(double number, double power) 
        {
            if (power == 0)
            {
                return 1;
            } 
            else
            {
                double result = number;
                for (int i = 1; i < power; i++)
                {
                    result *= number;
                }

                return result;
            }

            //if you have a problem with pow < 0 or pow x.xx -> use Math.Pow;
            //double result = 0.0;
            //result = Math.Pow(number, power);
            //return result;
        }
    }
}
