using NextDoor.Entities;
using NextDoor.Models.Poll;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class PollFactory
    {
        public static Poll Create(PollAddModel model, string userId)
        {
            var data = new Poll
            {
                UserID        = model.UserID,
                Question      = model.Question,
                Description   = model.Description ,
                PollBookmark  = false,
                PollTimeStamp = model.TimeStamp==null ? "" : model.TimeStamp,
                Status        = Constants.RecordStatus.Active,
                CreatedBy     = userId ?? "0",
                CreatedOn     = Utility.GetDateTime(),
            };
            return data;
        }


        public static PollMultimedia CreateMultimedia(PollAddModel model, string userId)
        {
            var data = new PollMultimedia
            {
                Polld         = model.Id,
                UserId        = model.UserID,
                Atachments    = model.FileUrl,
                AtachmentType = model.MediaType,
                CreatedOn     = Utility.GetDateTime(),
                FileData      = model.FileData
            };
            return data;
        }

        public static PolOption CreateResponse(AddPollOptionModel model, string userId)
        {
            var data = new PolOption
            {
                Poll_id    = model.poll_id,
                User_id    = model.user_id,
                Option_Name = model.OptionName,
                Count = 0,
                CreatedOn  = Utility.GetDateTime(),
            };
            return data;
        }

        //Add vote
        public static void CreateCount(VoteAddModel model, PolOption entity, string userId)
        {
            entity.Count = entity.Count + 1;
        }


        public static CheckUserVote CreateUserVote(VoteAddModel model, string userId)
        {
            var data = new CheckUserVote
            {
                User_Id = model.User_id,
                Poll_Id = model.Poll_id,
                Response_Id = model.ResponseId,
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }

    }
}
