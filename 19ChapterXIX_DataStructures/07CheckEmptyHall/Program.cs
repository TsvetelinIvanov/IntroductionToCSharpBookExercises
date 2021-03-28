using Magnum.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace _07CheckEmptyHall
{
    class Program
    {        
        static void Main(string[] args)
        {
            OrderedMultiDictionary<DateTime, Event> hallEvents = new OrderedMultiDictionary<DateTime, Event>(true);             

            string[] meetingRange = Console.ReadLine().Split();
            DateTime meetingStart = DateTime.ParseExact(meetingRange[0], Event.DateFormat, CultureInfo.InvariantCulture);
            DateTime meetingEnd = DateTime.ParseExact(meetingRange[1], Event.DateFormat, CultureInfo.InvariantCulture);
            int eventsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < eventsCount; i++)
            {
                string[] meetingInfo = Console.ReadLine().Split(new char[] { '|', ';', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                DateTime currentMeetingStart = DateTime.ParseExact(meetingInfo[1].Trim(), Event.DateFormat, CultureInfo.InvariantCulture);
                DateTime currentMeetingEnd = DateTime.ParseExact(meetingInfo[2].Trim(), Event.DateFormat, CultureInfo.InvariantCulture);
                Event currentEvent = new Event(meetingInfo[0].Trim(), currentMeetingStart, currentMeetingEnd);
                hallEvents.Add(currentMeetingStart, currentEvent);
            }

            OrderedMultiDictionary<DateTime, Event>.View checkedEvents = hallEvents.Range(meetingStart, true, meetingEnd, true);
            if (checkedEvents.Count == 0)
            {
                Console.WriteLine("The hall is empty!");
                return;
            }
            
            foreach (KeyValuePair<DateTime, ICollection<Event>> checkedEventsInTime in checkedEvents)
            {
                foreach (Event @event in checkedEventsInTime.Value)
                {
                    if (@event.MeetingEnd <= meetingEnd)
                    {
                        Console.WriteLine(@event);
                    }
                }
            }            
        }       
    }
}