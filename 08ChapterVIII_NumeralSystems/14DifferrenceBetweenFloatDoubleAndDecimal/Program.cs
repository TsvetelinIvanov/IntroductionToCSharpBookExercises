using System;

namespace _14DifferrenceBetweenFloatDoubleAndDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberString = Console.ReadLine();
            int multiplicationsCount = int.Parse(Console.ReadLine());

            float floatNumber = float.Parse(numberString);
            float floatResult = 0;
            DateTime floatStartTime = DateTime.Now;
            for (int i = 0; i < multiplicationsCount; i++)
            {
                floatResult += floatNumber;
            }

            DateTime floatEndTime = DateTime.Now;
            TimeSpan floatTime = floatEndTime - floatStartTime;
            Console.WriteLine("{0} - {1}", floatTime, floatResult);

            double doubleNumber = double.Parse(numberString);
            double doubleResult = 0;
            DateTime doubleStartTime = DateTime.Now;
            for (int i = 0; i < multiplicationsCount; i++)
            {
                doubleResult += doubleNumber;
            }

            DateTime doubleEndTime = DateTime.Now;
            TimeSpan doubleTime = doubleEndTime - doubleStartTime;
            Console.WriteLine("{0} - {1}", doubleTime, doubleResult);

            decimal decimalNumber = decimal.Parse(numberString);
            decimal decimalResult = 0;
            DateTime decimalStartTime = DateTime.Now;
            for (int i = 0; i < multiplicationsCount; i++)
            {
                decimalResult += decimalNumber;
            }

            DateTime decimalEndTime = DateTime.Now;
            TimeSpan decimalTime = decimalEndTime - decimalStartTime;
            Console.WriteLine("{0} - {1}", decimalTime, decimalResult);
        }
    }
}