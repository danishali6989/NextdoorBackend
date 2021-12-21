using NextDoor.Entities;
using NextDoor.Models.Location;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
   public class LocationFactory
    {
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
    }
}
