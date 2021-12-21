using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Event
{
    public class EventAddModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int EventCategory_id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Address { get; set; }
        public string image { get; set; }

        public string FileUrl { get; set; }
    }
}
