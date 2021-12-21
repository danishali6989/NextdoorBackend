using NextDoor.Dtos.Comment;
using NextDoor.Dtos.Like;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Event
{
    public class EventDetailDto
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int EventCategory_Id { get; set; }
        public string EventCategoryName { get; set; }
        public bool? EventBookmark { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Attachmentfile { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Address { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<EventComment> eventcomments { get; set; }
        public List<EventLikes> eventlikes { get; set; }
       /* public List<CommentDetailDto> replies { get; set; }
        public List<LikeDetailDto> likes { get; set; }*/
        public Constants.ReactionStatus UserReaction_Id { get; set; }
    }
}


public class EventComment
{
    public int id { get; set; }
    public int CommentParent_Id { get; set; }
    public int User_id { get; set; }
    public int Eventid { get; set; }
    public string CommentText { get; set; }
    public double lat { get; set; }
    public double lng { get; set; }
    public string Attachment1 { get; set; }
    public string Attachment2 { get; set; }
    public string Attachment3 { get; set; }
    public List<CommentDetailDto> replies { get; set; }
     public List<LikeDetailDto> like { get; set; }
    public int likes { get; set; }
   
}
public class EventLikes
{
    public int Comment_id { get; set; }
    public int User_id { get; set; }
    public Constants.ReactionStatus Reaction_Id { get; set; }

}