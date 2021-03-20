using System;

namespace _15_19GSMCallHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            GSMCallHistoryTest gsmCallHistoryTest = new GSMCallHistoryTest();
            Console.WriteLine(gsmCallHistoryTest.TestGSM());
            Console.WriteLine(gsmCallHistoryTest.TestCallHistory());
        }
    }
}