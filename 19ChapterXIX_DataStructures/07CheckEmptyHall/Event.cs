using System;

namespace _07CheckEmptyHall
{
    public class Event : IComparable<Event>
    {
        private string name;
        private DateTime meetingStart;
        private DateTime meetingEnd;
        public const string DateFormat = "yyyy-M-dTH:m:s";

        public Event(string name, DateTime meetingStart, DateTime meetingEnd)
        {
            this.name = name;
            this.meetingStart = meetingStart;
            this.meetingEnd = meetingEnd;
        }

        public string Name => this.name;
        
        public DateTime MeetingStart => this.meetingStart;
        
        public DateTime MeetingEnd => this.meetingEnd;
        
        public override string ToString()
        {
            return $"{this.Name}: [{this.MeetingStart} <-> {this.MeetingEnd}]";
        }

        public int CompareTo(Event meeting)
        {            
            return this.meetingStart.CompareTo(meeting.meetingStart);
        }
    }
}