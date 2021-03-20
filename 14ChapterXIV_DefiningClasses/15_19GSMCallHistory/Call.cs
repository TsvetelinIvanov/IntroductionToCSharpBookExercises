using System;
using System.Collections.Generic;
using System.Text;

namespace _15_19GSMCallHistory
{
    public class Call : IComparable<Call>
    {
        private string date;
        private string startTime;
        private int duration;


        public Call(string date, string startTime, int duration)
        {
            this.date = date;
            this.startTime = startTime;
            this.duration = duration;
        }

        public string Date
        {
            get { return this.date; }
        }

        public string StartTime
        {
            get { return this.startTime; }
        }

        public int Duration
        {
            get { return this.duration; }
            //set { this.duration = value; }
        }

        public int CompareTo(Call otherCall)
        {            
            if (this.Duration > otherCall.Duration)
            {
                return 1;
            }
            else if (this.Duration < otherCall.Duration)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {            
            return $"Date: {this.Date}, Start Time: {this.StartTime}, Duration: {this.Duration}";
        }
    }
}