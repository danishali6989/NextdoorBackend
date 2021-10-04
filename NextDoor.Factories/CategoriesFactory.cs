using NextDoor.Entities;
using NextDoor.Models.Categories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class CategoriesFactory
    {

        public static Categories Create(CategoriesAddModel model, string userId)
        {
            var data = new Categories
            {
                CategoryName = model.CategoryName,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                

            };
            return data;
        }

        public static void Create(CategoriesAddModel model, Categories entity, string userId)
        {
            entity.CategoryName = model.CategoryName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
           
        }
    }
}
