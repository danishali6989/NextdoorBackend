using NextDoor.Entities;
using NextDoor.Models.NextDoorUser;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;


namespace UserManagement.Factories
{
    public class NextDoorUserFactory
    {

        public static NextDoorUser Create(AddNextDoorUserModel model, string userId,string header)
        {
            var data = new NextDoorUser
            {
                UserId = model.UserId,
                FirstName = model.Usr_FName,
                LastName = model.Usr_LName,
                Gender = model.Gender,
                Email = model.Email,
                City = model.City,
                State = model.State,
                Postalcode = model.Postalcode,
                StreetAdress = model.StreetAdress,
                ApartmentNo = model.ApartmentNo,
                Lan = model.Lan,
                Lat = model.Lat,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
               // CompanyId = Convert.ToInt32(header)
               CompanyId = Int32.Parse(header)
               

            };
            return data;
        }


        public static void Create(EditNextDoorUser model, NextDoorUser entity, string userId)
        {
            entity.FirstName    = model.FirstName;
            entity.LastName     = model.LastName;
            entity.Email        = model.Email;
            entity.Gender       = model.Gender;
            entity.Pronoun      = model.Pronoun;
            entity.FAPreference = model.FA_Preference;
            entity.UpdatedBy    = userId ?? "0";
            entity.UpdatedOn    = Utility.GetDateTime();

        }
    }
}
