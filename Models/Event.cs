using System;
using System.Collections.Generic;

namespace EventEaseApp.Models
{
    public class Event
    {
        public int Id {get; set; } = 0;
        public string Name { get; set; } = "";
        public DateTime Date { get; set; }
        public string Location { get; set; } = "";
        public string Details { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string ContactInfo { get; set; } = "";
        public List<Attendee> Attendees { get; set; } = new List<Attendee>();
    }
}