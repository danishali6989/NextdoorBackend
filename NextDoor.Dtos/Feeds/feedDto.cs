using System;
using System.Collections.Generic;
using System.Text;
using NextDoor.Dtos.Poll;
using NextDoor.Dtos.Event;
using NextDoor.Dtos.Post;
using NextDoor.Utilities;

namespace NextDoor.Dtos.Feeds
{
    public class feedDto
    {
        public string posttype { get; set; }
        public DateTime CreatedOn { get; set; }
        #region post
        public int Id { get; set; }
        public int User_id { get; set; }
        public   string FirstName { get; set; }
        public string LastName { get; set; }
        public int Category_id { get; set; }
        public bool? Bookmark { get; set; }
        public string SafetyDescription { get; set; }
        public string SafetyPersonDescription { get; set; }
        public string Category_Name { get; set; }
        public int Listing_CategoryId { get; set; }
        public string Listing_Category_Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public double Price { get; set; }
        public double lat { get; set; }
        public double lan { get; set; }
        public string Attachment { get; set; }
        public string AttachmentType { get; set; }
        public Constants.RecordStatus Status { get; set; }


        public List<PostPersons> persons { get; set; }
        public List<PostVehicle> vehicles { get; set; }
        public List<PostMultimedia> postmultimedia { get; set; }
        public int PostMultimediaCount { get; set; }
        public List<PostComment> postComments { get; set; }
        public int PostCommentCount { get; set; }
        public List<PostLikes> Postlikes { get; set; }
        public int postAllLikes { get; set; }
        public Constants.ReactionStatus User_ReactionId { get; set; }

        #endregion post

        #region Poll
        public int PollId { get; set; }
        //public int User_id { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        //public string Response1 { get; set; }
        //public string Response2 { get; set; }
        public string OptionName { get; set; }
        public string Attachments { get; set; }
        public string AttachmentPollType { get; set; }
        public bool? PollBookmark { get; set; }

        public int response_id { get; set; }
        public List<PollOptionDto> options { get; set; }
        public List<PollMultimediDto> multimedia { get; set; }
        public int PollMultimedia { get; set; }
        public List<PollComment> pollComments { get; set; }
        public int PollCommentCount { get; set; }

        public List<PollLikes> pollLike { get; set; }
        public int pollLikes { get; set; }
        public int? count { get; set; }
        public Constants.RecordStatus PollStatus { get; set; }
        public Constants.ReactionStatus UserPollReaction_Id { get; set; }

        #endregion Poll

        #region Events
        public int EventID { get; set; }
        public int EventCategory_id { get; set; }
        public string EventCategoryName { get; set; }
        public string Title { get; set; }
        public string EventDescription { get; set; }
        public bool? EventBookmark { get; set; }
        public string Attachmentfile { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string Address { get; set; }
        public Constants.RecordStatus EventStatus { get; set; }
        public List<EventComment> eventComments { get; set; }
        public int EventCommentCount { get; set; }
        public List<EventLikes> eventLike { get; set; }
        public int eventLikes { get; set; }
        public Constants.ReactionStatus UserReaction_Id { get; set; }

        #endregion Events

        //public int Bookmarkid { get; set; }
    }
}
