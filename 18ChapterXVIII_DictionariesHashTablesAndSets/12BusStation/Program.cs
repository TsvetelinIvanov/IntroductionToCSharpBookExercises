using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12BusStation
{
    class Program
    {
        static StringBuilder outputBuilder = new StringBuilder();
        static void Main(string[] args)
        {
            TimeInterval searchingTimeInterval = new TimeInterval(Console.ReadLine());
            List<TimeInterval> busIntervals = PrepareInputSequence(Console.ReadLine());
            FindBusses(searchingTimeInterval, busIntervals);
            if (outputBuilder.Length > 1)
            {
                Console.WriteLine(outputBuilder.ToString().TrimEnd(' ', ','));
            }
            else
            {
                outputBuilder.Append("There are no busses in this time!");
                Console.WriteLine(outputBuilder);
            }
        }        

        private static List<TimeInterval> PrepareInputSequence(string inputLine)
        {
            string[] stringBusIntervals = inputLine.Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            List<TimeInterval> busIntervals = new List<TimeInterval>();
            foreach (string busInterbal in stringBusIntervals)
            {
                busIntervals.Add(new TimeInterval(busInterbal));
            }

            return busIntervals;
        }

        private static void FindBusses(TimeInterval searchingTimeInterval, List<TimeInterval> busIntervals)
        {
            HashSet<TimeInterval> arriveAfter = new HashSet<TimeInterval>();
            HashSet<TimeInterval> leaveBefore = new HashSet<TimeInterval>();
            foreach (TimeInterval busInterval in busIntervals)
            {
                if (busInterval.ArriveTime >= searchingTimeInterval.ArriveTime)
                {
                    arriveAfter.Add(busInterval);
                }

                if (busInterval.LeaveTime <= searchingTimeInterval.LeaveTime)
                {
                    leaveBefore.Add(busInterval);
                }
            }

            IEnumerable<TimeInterval> searchedBusses = arriveAfter.Intersect(leaveBefore);
            foreach (TimeInterval searchedBus in searchedBusses)
            {
                outputBuilder.Append("[" + searchedBus.ArriveTime.Hours.ToString().PadLeft(2, '0') + ":" + searchedBus.ArriveTime.Minutes.ToString().PadLeft(2, '0'));
                outputBuilder.Append("-" + searchedBus.LeaveTime.Hours.ToString().PadLeft(2, '0') + ":" + searchedBus.LeaveTime.Minutes.ToString().PadLeft(2, '0') + "]");
                outputBuilder.Append(", ");
            }
        }             
    }
}