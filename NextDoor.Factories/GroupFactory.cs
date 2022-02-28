using NextDoor.Entities;
using NextDoor.Models.Group;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class GroupFactory
    {

        public static Group Create(GroupAddModel model, string userId)
        {
            var data = new Group
            {
               UserID = model.UserId,
               GroupName = model.GroupName,
               GroupTimeStamp = model.TimeStamp == null ? "" : model.TimeStamp,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }

        public static void Create(GroupEditModel model, Group entity, string userId)
        {
            entity.GroupName = model.GroupName;
            entity.GroupTimeStamp = model.TimeStamp == null ? "" : model.TimeStamp;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }

    }
}
