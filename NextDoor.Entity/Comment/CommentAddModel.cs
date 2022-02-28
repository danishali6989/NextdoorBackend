using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Comment
{
    public class CommentAddModel
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int PostId { get; set; }
        public int Poll_id { get; set; }
        
        public int EventId { get; set; }
        public int Comment_Parent_Id { get; set; }
        public string CommentText { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public string TimeStamp { get; set; }

        public string File1 { get; set; }
        public string File2 { get; set; }
        public string File3 { get; set; }
        public string FileUrl1 { get; set; }
        public string FileUrl2 { get; set; }
        public string FileUrl3 { get; set; }
        public string MediaType1 { get; set; }
        public string MediaType2 { get; set; }
        public string MediaType3 { get; set; }
        public string Extension1 { get; set; }
        public string Extension2 { get; set; }
        public string Extension3 { get; set; }
        
    }
}
