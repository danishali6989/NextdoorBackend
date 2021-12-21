using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Models.Likes
{
    public  class LikesAddModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Post_id { get; set; }
        public int Poll_id { get; set; }
        public int Event_id { get; set; }
        public int Comment_id { get; set; }

        public Constants.ReactionStatus Reaction_Id { get; set; }

    }
}
