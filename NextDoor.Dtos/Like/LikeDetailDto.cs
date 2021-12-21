using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Dtos.Like
{
    public  class LikeDetailDto
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int PostId { get; set; }
        public int EventId { get; set; }
        public int CommentId { get; set; }
        public Constants.ReactionStatus Reaction_Id { get; set; }
    }
}
