using NextDoor.Entities;
using NextDoor.Models.Likes;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class LikeFactory
    {

        public static Likes Create(LikesAddModel model, string userId)
        {
            var data = new Likes
            {
                User_id     = model.User_id,
                Post_id     = model.Post_id != 0 ? model.Post_id : 0  ,
                Poll_id     = model.Poll_id != 0 ? model.Poll_id : 0,
                Event_id    = model.Event_id != 0 ? model.Event_id : 0,
                Comment_id  = model.Comment_id != 0 ? model.Comment_id : 0 ,
                Reaction_Id = model.Reaction_Id,
                CreatedBy   = userId ?? "0",
                CreatedOn   = Utility.GetDateTime(),



            };
            return data;
        }

        public static Likes EditReaction(int userid, int postId, Constants.ReactionStatus reactionid,Likes entity, string userId)
        {
            var data = new Likes
            {
               
               
                Reaction_Id = reactionid,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),



            };
            return data;
        }
    }
}
