using System;
using System.Text;

namespace _12BusStation
{
    public class TimeInterval
    {
        private TimeSpan arriveTime;
        private TimeSpan leaveTime;

        public TimeInterval(TimeSpan arriveTime, TimeSpan leaveTime)
        {
            this.arriveTime = arriveTime;
            this.leaveTime = leaveTime;
        }

        public TimeInterval(string stringTime)
        {
            StringBuilder timeBuilder = new StringBuilder(stringTime.Length * 2);
            foreach (char item in stringTime)
            {
                if (char.IsDigit(item))
                {
                    timeBuilder.Append(item);
                }
                else
                {
                    timeBuilder.Append(' ');
                }
            }

            string[] times = timeBuilder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.arriveTime = new TimeSpan(int.Parse(times[0]), int.Parse(times[1]), 0);
            this.leaveTime = new TimeSpan(int.Parse(times[2]), int.Parse(times[3]), 0);
        }

        public TimeSpan ArriveTime => this.arriveTime;

        public TimeSpan LeaveTime => this.leaveTime;        
    }
}