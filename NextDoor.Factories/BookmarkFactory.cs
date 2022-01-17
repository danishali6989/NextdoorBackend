using NextDoor.Entities;
using NextDoor.Models.Bookmark;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class BookmarkFactory
    {

        public static Bookmark Create(AddBookmarkModel model, string userId)
        {
            var data = new Bookmark
            {
                Post_id          = model.Postid          == 0 ? 0 : model.Postid,
                Event_id         = model.Eventid         == 0 ? 0 : model.Eventid,
                Poll_id          = model.Pollid          == 0 ? 0 : model.Pollid,
                Category_id      = model.Categoryid      == 0 ? 0 : model.Categoryid,
                EventCategory_id = model.EventCategoryid == 0 ? 0 : model.EventCategoryid,
                CreatedBy        = userId ?? "0",
                USerId           = model.userid, 
                BookmarkTimeStamp = model.TimeStamp == null ?"" : model.TimeStamp,
                CreatedOn        = Utility.GetDateTime(),


            };
            return data;
        }
    }
}
