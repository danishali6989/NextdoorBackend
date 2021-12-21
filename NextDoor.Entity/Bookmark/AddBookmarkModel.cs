using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Bookmark
{
    public class AddBookmarkModel
    {
        public int id { get; set; }
        public int Postid { get; set; }
        public int Eventid { get; set; }
        public int Pollid { get; set; }
        public int Categoryid { get; set; }
        public int EventCategoryid { get; set; }
    }
}
