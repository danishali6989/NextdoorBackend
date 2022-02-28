using NextDoor.Entities;
using NextDoor.Models.BusinessType;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public  class BusinessTypeFactory
    {
        public static BusinessType Create(AddBusinessTypeModel model, string userId)
        {
            var data = new BusinessType
            {
                BusinessName = model.BusinessName ,
                UserId = model.UserId,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }

        public static void  Create(BusinessType entity,AddBusinessTypeModel model,string userId)
        {
            entity.UserId = model.UserId;
            entity.BusinessName = model.BusinessName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
