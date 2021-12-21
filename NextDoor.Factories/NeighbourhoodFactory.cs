using NextDoor.Entities;
using NextDoor.Models.Location;
using NextDoor.Models.Neigbourhood;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class NeighbourhoodFactory
    {

        public static Neighbourhood Create(NeighbourhoodAddModel model, string userId)
        {
            var data = new Neighbourhood
            {
                Userid = model.userid,
                NeighbourhoodName = model.NeighbourhoodName,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),


            };
            return data;
        }


        public static Location Create(AddLocationModel model, string userId)
        {
            var data = new Location
            {
                UserId = model.userid,
                NeighbourhoodId = model.NeighbourhoodId,
                lat = model.lat,
                lng = model.lng,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(NeighbourhoodAddModel model, Neighbourhood entity, string userId)
        {
            entity.Userid = model.userid;
            entity.NeighbourhoodName = model.NeighbourhoodName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

        }
    }
}
