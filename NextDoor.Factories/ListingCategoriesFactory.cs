using NextDoor.Entities;
using NextDoor.Models.ListingCategories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class ListingCategoriesFactory
    {
        public static ListingCategories Create(ListingCategoriesAddModel model, string userId)
        {
            var data = new ListingCategories
            {
                ListingCategoryName = model.ListingCategoryName,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),


            };
            return data;
        }

        public static void Create(ListingCategoriesAddModel model, ListingCategories entity, string userId)
        {
            entity.ListingCategoryName = model.ListingCategoryName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

        }
    }
}
