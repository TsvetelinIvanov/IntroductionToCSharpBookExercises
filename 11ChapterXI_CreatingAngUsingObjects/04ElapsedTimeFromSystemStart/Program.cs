using System;

namespace _04ElapsedTimeFromSystemStart
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datePlusTickCountAdded = DateTime.Now.AddMilliseconds(Environment.TickCount);
            Console.WriteLine(datePlusTickCountAdded - DateTime.Now);
        }
    }
}