using NextDoor.Entities;
using NextDoor.Models.HelpMap;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class HelpMapFactory
    {
        public static HelpMap Create(AddHelpMapModel model, string userId)
        {
            var data = new HelpMap
            {
                UserId = model.UserId,
                Message = model.Message,
                ParentMessageId = model.ParentMessageId,
                lat = model.lat,
                lng = model.lng,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }
        public static void Create(EditHelpMapModel model, HelpMap entity, string userId)
        {
            entity.UserId = model.UserId;
            entity.Message = model.Message;
            entity.ParentMessageId = model.ParentMessageId;
            entity.lat = model.lat;
            entity.lng = model.lng;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
