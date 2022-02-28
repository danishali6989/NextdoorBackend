using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int CommentParent_Id { get; set; }
        public int User_id { get; set; }
        public NextDoorUser NextDoorUser { get; set; }
        public int Post_id { get; set; }
        public int Poll_id { get; set; }
        public int Event_id { get; set; }
        public string CommentText { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }
        public string AttachmentType1 { get; set; }
        public string AttachmentType2 { get; set; }
        public string AttachmentType3 { get; set; }
        public string TimeStamp { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
