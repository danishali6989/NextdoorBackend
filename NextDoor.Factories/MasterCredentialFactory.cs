using NextDoor.Entities;
using NextDoor.Models.MasterCre;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class MasterCredentialFactory
    {
        public static MasterCredential Create(AddMasterModel model, string userId)
        {
            var data = new MasterCredential
            {
                Server = model.Server,
                Origin = model.Origin,
                UserName = model.UserName,
                Password = Utility.Encrypt(model.Password),
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),


            };
            return data;
        }
    }
}
