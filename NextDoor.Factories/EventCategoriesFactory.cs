using NextDoor.Entities;
using NextDoor.Models.EventCategories;
using NextDoor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextDoor.Factories
{
    public class EventCategoriesFactory
    {

        public static EventCategories Create(EventCategoriesAddModel model, string userId)
        {
            var data = new EventCategories
            {
                EventCategoryName = model.EventCategoryName,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
            };
            return data;
        }

        public static void Create(EventCategoriesAddModel model, EventCategories entity, string userId)
        {
            entity.EventCategoryName = model.EventCategoryName;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();

        }
    }
}
