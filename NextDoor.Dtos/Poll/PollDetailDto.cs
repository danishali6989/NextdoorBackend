using NextDoor.Dtos.Comment;
using NextDoor.Dtos.Like;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Poll
{
    public class PollDetailDto
    {
        public int Poll_Id { get; set; }
        public int User_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public bool? PollBookmark { get; set; }
        public string Response1 { get; set; }
        public string Response2 { get; set; }
        public string OptionName { get; set; }
        public string Attachments { get; set; }
        public string AttachmentType{ get; set; }
        public string PollTimeStamp { get; set; }

        public int response_id { get; set; }
        public List<PollOptionDto> options { get; set; }
        public List<PollMultimediDto> multimedia { get; set; }
        public int MultimediaCount { get; set; }
        public List<PollComment> pollcomment { get; set; }
        public int PollCommentCount { get; set; }
        public List<PollLikes> polllike { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public Constants.ReactionStatus UserReaction_id { get; set; }
    }
    public class PollOptionDto
    {
        public int pollid { get; set; }
        public int optionId { get; set; }
        public string OptionName { get; set; }
        public int? count { get; set; }
        //count = s1.Count,
    }
    public class PollMultimediDto
    {
        public int pollid { get; set; }
        public string Attachment { get; set; }
        public string AttachmentType { get; set; }
    }
    public class PollComment
    {
        public int id { get; set; }
        public int CommentParent_Id { get; set; }
        public int User_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pollid { get; set; }
        public string PollTimeStamp { get; set; }

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
    public class PollLikes
    {
        public int Comment_id { get; set; }
        public int User_id { get; set; }
        public Constants.ReactionStatus Reaction_Id { get; set; }

    }
}
