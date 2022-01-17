using NextDoor.Entities;
using NextDoor.Models.Group;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class JoinGroupFactory
    {

        public static JoinGroup Create(JoinGroupAddModel model, string userId)
        {
            var data = new JoinGroup
            {
                USerid = model.UserId,
                Groupid = model.GroupId,
                GroupTimeStamp = model.TimeStamp == null ?"":model.TimeStamp,
                CreatedBy = userId ?? "0",
                // USerId = model.userid,
                CreatedOn = Utility.GetDateTime(),


            };
            return data;
        }
    }
}
