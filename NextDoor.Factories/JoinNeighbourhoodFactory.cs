using NextDoor.Entities;
using NextDoor.Models.JoinNeighbourhood;
using NextDoor.Models.Neigbourhood;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class JoinNeighbourhoodFactory
    {
        public static JoinNeighbourhood Create(JoinNeighbourhoodAddModel model, string userId)
        {
            var data = new JoinNeighbourhood
            {
                
                NeighbourhoodId = model.NeighbourhoodId,
                UserId = model.UserId,
                TimeStamp = model.TimeStamp==null?"":model.TimeStamp,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),


            };
            return data;
        }

        public static JoinNeighbourhood Create(NeighbourhoodAddModel model, string userId)
        {
            var data = new JoinNeighbourhood
            {

                NeighbourhoodId = model.id,
                UserId = model.userid,
                TimeStamp = model.TimeStamp==null?"":model.TimeStamp,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),


            };
            return data;
        }

    }
}
