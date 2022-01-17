using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Event
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public NextDoorUser NextDoorUser { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategories EventCategories { get; set; }
        public bool? EventBookmark { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Attachmentfile { get; set; }
        public string EventFileData { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Address { get; set; }
        public string EventTimestamp { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}
