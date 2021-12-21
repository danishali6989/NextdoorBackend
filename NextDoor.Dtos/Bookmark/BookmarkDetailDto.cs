using NextDoor.Dtos.Comment;
using NextDoor.Dtos.Like;
using NextDoor.Dtos.Poll;
using NextDoor.Dtos.Post;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Bookmark
{
    public class BookmarkDetailDto
    {
        public int Id { get; set; }
        public int categoryid { get; set; }
        public int postid { get; set; }
        public int eventid{ get; set; }
        public int eventcategoryid { get; set; }
        public int pollid { get; set; }
        public List<PostPersons> persons { get; set; }
        public List<PostVehicle> vehicles { get; set; }
        public List<PostMultimedia> multimedia { get; set; }
        public List<PostLikes> postlikes { get; set; }
      //  public List<PostComment> postComments { get; set; }
      
        public List<PostComment> postcomments { get; set; }
        public Constants.ReactionStatus Reaction_Id { get; set; }

        public List<EventComment> eventcomments { get; set; }
        public List<EventLikes> eventlikes { get; set; }


        public List<PollOptionDto> options { get; set; }
        public List<PollMultimediDto> pollmultimedia { get; set; }

    }
}
