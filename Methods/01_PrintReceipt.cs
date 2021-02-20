using System;

namespace _01_BlankReceipt
{
    class BlankReceipt
    {
        static void Main(string[] args)
        {
            PrintHeader();
            PrintReceipt();
            PrintFooter();
        }

        static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        static void PrintReceipt()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(@"(c) SoftUni");
        }        
    }
}
