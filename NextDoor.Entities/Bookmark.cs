using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Bookmark
    {
        public int id { get; set; }
        public int USerId { get; set; }
        public int Post_id { get; set; }
        public int Event_id { get; set; }
        public int Poll_id { get; set; }
        public int Category_id { get; set; }
        public string BookmarkTimeStamp { get; set; }

        public int Listingcategory_id { get; set; }
        public int EventCategory_id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
