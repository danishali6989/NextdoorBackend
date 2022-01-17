using NextDoor.Dtos.Like;
using NextDoor.Models.Comment;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Comment
{
    public class CommentDetailDto
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostId { get; set; }
        public int EventId { get; set; }
        public int Comment_Parent_Id { get; set; }
        public string CommentText { get; set; }
        public double Lan { get; set; }
        public double Lat { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }
        public string AttachmentType1 { get; set; }
        public string AttachmentType2 { get; set; }
        public string AttachmentType3 { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public string TimeStamp { get; set; }



        public List<LikeDetailDto> likes { get; set; }
         public int Commentlikes { get; set; }
        public List<CommentDetailDto> replies { get; set; }
        public Constants.ReactionStatus Reaction_Id { get; set; }

    }
}
