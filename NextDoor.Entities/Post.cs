using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public NextDoorUser NextDoorUser { get; set; }
        public int Category_id { get; set; }
        public Categories Categories { get; set; }
        public int ListingCategoryId { get; set; }
        public ListingCategories ListingCategories { get; set; }
        public int ShareCount { get; set; }
        public bool? Bookmark { get; set; }
        public string Subject { get; set; }
        public string SafetyDescription { get; set; }
        public string SafetyPersonDescription { get; set; }
        public string Message { get; set; }
        public double Price { get; set; }
        public double lat { get; set; }
        public double lan { get; set; }
        public string PostTimeStamp { get;set;}
        public string Attachment { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}
