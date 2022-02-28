using NextDoor.Dtos.Comment;
using NextDoor.Dtos.Like;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Post
{
    public  class PostDetailDto
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Category_id { get; set; }
        public int Bookmarkid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Listing_CategoryId { get; set; }
        public string listingcategoryname { get; set; }
        public string CategoryName { get; set; }
        public string SafetyDescription { get; set; }
        public string SafetyPersonDescription { get; set; }
        public bool? Bookmark { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public double Price { get; set; }
        public double lat { get; set; }
        public double lan { get; set; }
        public string TimeStamp { get; set; }
        public int PostShareCount { get; set; }
        public Constants.RecordStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<PostPersons> persons { get; set; }
        public List<PostVehicle> vehicles { get; set; }
        public List<PostMultimedia> multimedia { get; set; }
        public int multimediaCount { get; set; }
        public List<PostComment> postcomments { get; set; }
        public int PostCommentCount { get; set; }
        public List<PostLikes> postlikes { get; set; }
        public List<CommentDetailDto> replies { get; set; }
        public List<LikeDetailDto> likes { get; set; }
        public Constants.ReactionStatus Reaction_Id { get; set; }
    }

    public class PostPersons
    {
        public int Postid { get; set; }
        public string Hair { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public string Shoes { get; set; }
        public string Age { get; set; }
        public string Build { get; set; }
        public string Ethinicity { get; set; }
        public string Sex { get; set; }
        public string OtherDetails { get; set; }
    }

    public class PostVehicle
    {
        public int Postid { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string RegNo { get; set; }
        public string Other_Details { get; set; }
    }

    public class PostMultimedia
    {
        public int Multimedia_Id { get; set; }
        public int postid { get; set; }
        public string Attachment { get; set; }
        public string AttachmentType { get; set; }
        public int postmultimediaCount { get; set; }
    }

    public class PostComment
    {
        public int id { get; set; }
        public int CommentParent_Id { get; set; }
        public int User_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Post_id { get; set; }
        public string CommentText { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string TimeStamp { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }
        public List<CommentDetailDto> replies { get; set; }
        public int likes { get; set; }
    }
        public class PostLikes
        {
            public int Post_id { get; set; }
            public int Comment_id { get; set; }
            public int User_id { get; set; }
            public Constants.ReactionStatus Reaction_Id { get; set; }
        }
    
}
